using OldScanner.Data;
using OldScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldScanner.Services
{
    public class LastMinuteRepository : ILastMinuteRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public LastMinuteRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void AddLastMinute(LastMinute lastMinute)
        {
            _applicationDbContext.lastMinutes.Add(lastMinute);
            _applicationDbContext.SaveChanges();
        }
    }
}
