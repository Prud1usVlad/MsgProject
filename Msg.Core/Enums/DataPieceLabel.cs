using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.Enums
{
    public enum DataPieceLabel
    {
        None = 0,
        PlantRequired = 1,
        SubstrateRequired = 2,
        OptimizingModelRequired = 3,
        DeviceActionRequired = 4,
        Optional = 5,
    }
}
