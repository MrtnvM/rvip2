using System;
using System.Collections;
using System.Threading.Tasks;

namespace RVIP2
{
    class Server
    {
        private static readonly Queue Queue = Queue.Synchronized(new Queue());

        private static readonly Action proccesingAction = async () =>
        {
            while (Queue.Count != 0)
            {
                var request = (PerformanceRequest) Queue.Dequeue();

                var random = new Random();
                var perfInfo = new PerformanceInfo(
                    random.Next(0, 100),
                    random.Next(1024, 8096),
                    random.Next(0, 100)
                    );

                await Task.Delay(random.Next(1000, 3000));

                request.OnInfoReceived(perfInfo);
            }
        };

        public static void GetServerPerformanceInfo(Action<PerformanceInfo> onPerformanceInfoReceived)
        {
            Queue.Enqueue(new PerformanceRequest(onPerformanceInfoReceived));

            new Task(proccesingAction).Start();
        }
    }
}
