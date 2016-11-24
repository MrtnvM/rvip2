using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RVIP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Программа опроса текущего состояния сервера");
            Console.WriteLine("Доступные команды:\r\n");
            Console.WriteLine("cpu или с : информация об использовании процессора");
            Console.WriteLine("memory или m : информация об использовании памяти");
            Console.WriteLine("disk или d : информация об использовании винчестера");
            Console.WriteLine("all или a : полная информация об использовании ресурсов\r\n\n");

            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "all":
                        RequestAll();
                        break;
                    case "a":
                        RequestAll();
                        break;
                    case "memory":
                        RequestMemory();
                        break;
                    case "m":
                        RequestMemory();
                        break;
                    case "disk":
                        RequestDisk();
                        break;
                    case "d":
                        RequestDisk();
                        break;
                    case "cpu":
                        RequestCPU();
                        break;
                    case "c":
                        RequestCPU();
                        break;
                    default:
                        Console.WriteLine("Команда не распознана");
                        break;
                }
            }
        }

        static void RequestAll()
        {
            Server.GetServerPerformanceInfo((pi) =>
            {
                All(pi.CpuUsage, pi.MemoryUsage, pi.DiskUsage);
            });
        }

        static void RequestCPU()
        {
            Server.GetServerPerformanceInfo((pi) =>
            {
                Cpu(pi.CpuUsage);
            });
        }

        static void RequestMemory()
        {
            Server.GetServerPerformanceInfo((pi) =>
            {
                Memory(pi.MemoryUsage);
            });
        }

        static void RequestDisk()
        {
            Server.GetServerPerformanceInfo((pi) =>
            {
                Disk(pi.DiskUsage);
            });
        }


        static void Cpu(int cpu)
        {
            Console.WriteLine($"Текущее использование процессора: {cpu}%");
        }

        static void Memory(int memory)
        {
            Console.WriteLine($"Текущее использование памяти: {memory} MB");
        }

        static void Disk(int disk)
        {
            Console.WriteLine($"Текущее использование винчестера: {disk}%");
        }

        static void All(int cpu, int memory, int disk)
        {
            Cpu(cpu);
            Memory(memory);
            Disk(disk);
        }
    }
}
