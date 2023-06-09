﻿using Microsoft.EntityFrameworkCore;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.Core.Enums;
using Msg.Core.RequestModels;
using Msg.DAL;

namespace Msg.BLL.BasicServices
{
    public class SubstrateService : ISubstrateService
    {
        private readonly ApplicationContext _context;

        public SubstrateService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<long> AddSubstrateAsync(Substrate substrate)
        {
            _context.Substrates.Add(substrate);

            await _context.SaveChangesAsync();

            return substrate.Id;
        }

        public async Task DeleteSubstrateAsync(long id)
        {
            var substrate = await _context.Substrates.FindAsync(id);
            if (substrate == null)
                throw new NullReferenceException();

            _context.Substrates.Remove(substrate);
            await _context.SaveChangesAsync();
        }

        public async Task<Substrate> GetSubstrateAsync(long id)
        {
            var substrate = await _context.Substrates
                .Include(s => s.Characteristics)
                .ThenInclude(c => c.DataPiece)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (substrate == null)
                throw new NullReferenceException();

            return substrate;
        }

        public async Task<List<Substrate>> GetSubstratesAsync(string name)
        {
            var normalizedName = name.ToUpper();
            return await _context.Substrates
                .Include(p => p.Characteristics)
                .ThenInclude(c => c.DataPiece)
                .Where(p => p.Name.ToUpper().Contains(normalizedName))
                .ToListAsync();
        }

        public async Task<List<Substrate>> GetSubstratesAsync()
        {
            return await _context.Substrates
                .Include(p => p.Characteristics)
                .ThenInclude(c => c.DataPiece)
                .ToListAsync();
        }

        public async Task<List<Substrate>> GetSubstratesAsync(SubstrateFilterModel filter)
        {
            IEnumerable<Substrate> substrates = await _context.Substrates
                .Include(p => p.Characteristics)
                .ThenInclude(c => c.DataPiece)
                .ToListAsync();

            substrates = substrates.Where(substrate =>
                substrate.Volume <= filter.MaxVolume && substrate.Volume >= filter.MinVolume);

            substrates = substrates.Where(substrate =>
                substrate.Price <= filter.MaxPrice && substrate.Price >= filter.MinPrice);

            substrates = substrates.Where(substrate =>
                substrate.Characteristics.FirstOrDefault(c => (
                    c.DataPieceId == (long)DataPieceType.Acidity &&
                    c.Value <= filter.MaxAcidity &&
                    c.Value >= filter.MinAcidity
                )) is not null);

            substrates = substrates.Where(substrate =>
                substrate.Characteristics.FirstOrDefault(c => (
                    c.DataPieceId == (long)DataPieceType.ElectricalCapacity &&
                    c.Value <= filter.MaxElectricalCapacity &&
                    c.Value >= filter.MinElectricalCapacity
                )) is not null);

            substrates = substrates.Where(substrate =>
                substrate.Characteristics.FirstOrDefault(c => (
                    c.DataPieceId == (long)DataPieceType.MoisureContent &&
                    c.Value <= filter.MaxMoisureContent &&
                    c.Value >= filter.MinMoisureContent
                )) is not null);

            return substrates.ToList();
        }

        public async Task UpdateSubstrateAsync(Substrate substrate)
        {
            try
            {
                _context.Update(substrate);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubstrateExists(substrate.Id))
                {
                    throw new NullReferenceException();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool SubstrateExists(long id) =>
            (_context.Substrates?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
