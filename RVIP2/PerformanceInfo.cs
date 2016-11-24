using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVIP2
{
    class PerformanceInfo
    {
        public int CpuUsage { get; }
        public int MemoryUsage { get; }
        public int DiskUsage { get; }

        public PerformanceInfo(int cpu, int memory, int disk)
        {
            CpuUsage = cpu;
            MemoryUsage = memory;
            DiskUsage = disk;
        }
    }
}
