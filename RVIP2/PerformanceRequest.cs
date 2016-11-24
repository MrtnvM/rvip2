using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVIP2
{
    class PerformanceRequest
    {
        public Action<PerformanceInfo> OnInfoReceived { get; }

        public PerformanceRequest(Action<PerformanceInfo> onInfoReceived)
        {
            OnInfoReceived = onInfoReceived;
        }
    }
}
