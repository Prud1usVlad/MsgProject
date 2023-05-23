﻿using Msg.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Services.Interfaces
{
    public interface ISubstrateService
    {
        public Task<List<Substrate>> GetSubstrates();
    }
}
