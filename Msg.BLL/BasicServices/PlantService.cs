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
    public class PlantService : IPlantService
    {
        private readonly ApplicationContext _context;

        public PlantService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<long> AddPlantAsync(Plant plant)
        {
            _context.Plants.Add(plant);

            await _context.SaveChangesAsync();

            return plant.Id;
        }

        public async Task DeletePlantAsync(long id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
                throw new NullReferenceException();

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();
        }

        public async Task<Plant> GetPlantAsync(long id)
        {
            var plant = await _context.Plants
                .Include(p => p.Characteristics)
                .ThenInclude(c => c.DataPiece)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (plant == null)
                throw new NullReferenceException();

            return plant;
        }

        public async Task<Plant> GetPlantAsync(string name)
        {
            var plant = await _context.Plants
                .Include(p => p.Characteristics)
                .ThenInclude(c => c.DataPiece)
                .FirstOrDefaultAsync(p => p.Name == name);

            if (plant == null)
                throw new NullReferenceException();

            return plant;
        }

        public async Task<List<Plant>> GetPlantsAsync()
        {
            return await _context.Plants
                .Include(p => p.Characteristics)
                .ThenInclude(c => c.DataPiece)
                .ToListAsync();
        }

        public async Task UpdatePlantAsync(Plant plant)
        {
            try
            {
                _context.Update(plant);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(plant.Id))
                {
                    throw new NullReferenceException();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool PlantExists(long id) =>
            (_context.Plants?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
