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
    public class WarningService : IWarningService
    {
        private readonly ApplicationContext _context;

        public WarningService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Warning>> GetUserWarnings(string userId)
        {
            return await _context.Warnings
                .Include(w => w.DeviceDataPieces)
                    .ThenInclude(p => p.DataPiece)
                .Include(w => w.DeviceDataPieces)
                    .ThenInclude(p => p.Device)
                        .ThenInclude(d => d.DevicePack)
                .Include(w => w.DeviceDataPieces)
                    .ThenInclude(p => p.Device)
                        .ThenInclude(d => d.Plant)
                            .ThenInclude(p => p.Characteristics)
                                .ThenInclude(c => c.DataPiece)
                .Where(w => !w.IsSolved && w.DeviceDataPieces.First().Device.DevicePack.UserId == userId)
                .ToListAsync();
        }

        public async Task ResolveWarning(string userId, long warningId)
        {
            var warning = await _context.Warnings
                .FirstOrDefaultAsync(w => w.Id == warningId);
        
            warning.IsSolved = true;
            _context.Warnings.Update(warning);
            await _context.SaveChangesAsync();
        }
    }
}
