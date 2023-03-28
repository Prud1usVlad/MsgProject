using Msg.Core.BasicModels;
using Msg.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.Interfaces
{
    public interface IDataPieceService
    {
        public Task<DataPiece> GetDataPieceAsync(long id);
        public Task<List<DataPiece>> GetDataPiecesAsync(string name);
        public Task<List<DataPiece>> GetDataPiecesAsync();
        public Task<List<DataPiece>> GetDataPiecesAsync(DataPieceLabel label);
    }
}
