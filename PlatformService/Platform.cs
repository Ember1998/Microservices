using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService
{
    public record Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public decimal Cost { get; set; }
    }
}