using Microsoft.EntityFrameworkCore;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.BasicServices
{
    public class PackTypeService : IPackTypeService
    {
        private readonly ApplicationContext _context;

        public PackTypeService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<long> AddPackTypeAsync(PackType type)
        {
            _context.PackTypes.Add(type);

            await _context.SaveChangesAsync();

            return type.Id;
        }

        public async Task DeletePackTypeAsync(long id)
        {
            var type = await _context.PackTypes.FindAsync(id);
            if (type == null)
                throw new NullReferenceException();

            _context.PackTypes.Remove(type);
            await _context.SaveChangesAsync();
        }

        public async Task<PackType> GetPackTypeAsync(long id)
        {
            var type = await _context.PackTypes
                .Include(t => t.DevicesInPack)
                .ThenInclude(c => c.DeviceType)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (type == null)
                throw new NullReferenceException();

            return type;
        }

        public async Task<List<PackType>> GetPackTypesAsync(string name)
        {
            var normalizedName = name.ToUpper();
            return await _context.PackTypes
                .Include(t => t.DevicesInPack)
                .ThenInclude(c => c.DeviceType)
                .Where(p => p.Name.ToUpper().Contains(normalizedName))
                .ToListAsync();
        }

        public async Task<List<PackType>> GetPackTypesAsync()
        {
            return await _context.PackTypes
                .Include(t => t.DevicesInPack)
                .ThenInclude(c => c.DeviceType)
                .ToListAsync();
        }

        public async Task UpdatePackTypeAsync(PackType type)
        {
            var dbEntity = await GetPackTypeAsync(type.Id);

            if (dbEntity is null)
                throw new NullReferenceException();

            _context.DevicesInPacks.RemoveRange(dbEntity.DevicesInPack);

            CopyProperties(type, dbEntity);
            
            _context.Update(dbEntity);
            await _context.SaveChangesAsync();
        }

        private void CopyProperties(PackType from, PackType to)
        {
            to.DevicesInPack = from.DevicesInPack;
            to.Price = from.Price;
            to.Name = from.Name;
            to.Description = from.Description;
        }

    }
}
