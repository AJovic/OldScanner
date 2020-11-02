using OldScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldScanner.Services
{
    public interface ILastMinuteRepository
    {
        void AddLastMinute(LastMinute lastMinute);
    }
}
