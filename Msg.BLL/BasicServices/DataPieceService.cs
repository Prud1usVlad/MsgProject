using Microsoft.EntityFrameworkCore;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.Core.Enums;
using Msg.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.BasicServices
{
    public class DataPieceService : IDataPieceService
    {
        private readonly ApplicationContext _context;

        public DataPieceService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<DataPiece> GetDataPieceAsync(long id)
        {
            var dataPiece = await _context.DataPieces
                .Include(p => p.DataLabelDataPieces)
                .ThenInclude(i => i.DataLabel)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (dataPiece == null)
                throw new NullReferenceException();

            return dataPiece;
        }

        public async Task<List<DataPiece>> GetDataPiecesAsync(string name)
        {
            var normalizedName = name.ToUpper();
            return await _context.DataPieces
                .Include(p => p.DataLabelDataPieces)
                .ThenInclude(i => i.DataLabel)
                .Where(p => p.Name.ToUpper().Contains(normalizedName))
                .ToListAsync();
        }

        public async Task<List<DataPiece>> GetDataPiecesAsync()
        {
            return await _context.DataPieces
                .Include(p => p.DataLabelDataPieces)
                .ThenInclude(i => i.DataLabel)
                .ToListAsync();
        }

        public async Task<List<DataPiece>> GetDataPiecesAsync(DataPieceLabel label)
        {
            return await _context.DataPieces
                .Include(p => p.DataLabelDataPieces)
                .ThenInclude(i => i.DataLabel)
                .Where(p => p.DataLabelDataPieces
                    .Any(i => i.DataLabelId == (long)label)
                 ).ToListAsync();
        }
    }
}
