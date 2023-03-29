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
    public class DeviceTypeService : IDeviceTypeService
    {
        private readonly ApplicationContext _context;

        public DeviceTypeService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<long> AddDeviceTypeAsync(DeviceType type)
        {
            _context.DeviceTypes.Add(type);

            await _context.SaveChangesAsync();

            return type.Id;
        }

        public async Task DeleteDeviceTypeAsync(long id)
        {
            var type = await _context.DeviceTypes.FindAsync(id);
            if (type == null)
                throw new NullReferenceException();

            _context.DeviceTypes.Remove(type);
            await _context.SaveChangesAsync();
        }

        public async Task<DeviceType> GetDeviceTypeAsync(long id)
        {
            var type = await _context.DeviceTypes
                .Include(t => t.Devices)
                .Include(t => t.DeviceInPacks)
                .ThenInclude(c => c.PackType)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (type == null)
                throw new NullReferenceException();

            return type;
        }

        public async Task<List<DeviceType>> GetDeviceTypesAsync(string name)
        {
            var normalizedName = name.ToUpper();
            return await _context.DeviceTypes
                .Where(p => p.Name.ToUpper().Contains(normalizedName))
                .ToListAsync();
        }

        public async Task<List<DeviceType>> GetDeviceTypesAsync()
        {
            return await _context.DeviceTypes.ToListAsync();
        }

        public async Task UpdateDeviceTypeAsync(DeviceType type)
        {
            try
            {
                _context.Update(type);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceTypeExists(type.Id))
                {
                    throw new NullReferenceException();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool DeviceTypeExists(long id) =>
            (_context.DeviceTypes?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
