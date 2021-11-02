using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Computer
    {
        public float Code { get; set; }
        public string Mark { get; set; }
        public string CPU { get; set; }
        public double FreqProc { get; set; }
        public int RAM { get; set; }
        public int HDD { get; set; }
        public int VRAM { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer(){Code=2548624,Mark="Avalon",CPU="AMD",FreqProc=3.7,RAM=1024,HDD=650,VRAM=512,Price=210,Count=5},
                new Computer(){Code=7895614,Mark="Intel",CPU="Intel",FreqProc=2.9,RAM=2048,HDD=800,VRAM=1024,Price=360,Count=6},
                new Computer(){Code=2548624,Mark="IBM",CPU="AMD",FreqProc=3.8,RAM=4096,HDD=270,VRAM=2048,Price=420,Count=7},
                new Computer(){Code=2548624,Mark="SGI",CPU="AMD",FreqProc=3.0,RAM=8192,HDD=550,VRAM=4096,Price=560,Count=18},
                new Computer(){Code=2548624,Mark="Intel",CPU="Intel",FreqProc=3.5,RAM=4096,HDD=600,VRAM=2048,Price=400,Count=9},
                new Computer(){Code=2548624,Mark="Sequent",CPU="AMD",FreqProc=3.4,RAM=2048,HDD=400,VRAM=1024,Price=390,Count=14},
                new Computer(){Code=2548624,Mark="Parsytec",CPU="AMD",FreqProc=2.7,RAM=1024,HDD=500,VRAM=512,Price=185,Count=20},
                new Computer(){Code=2548624,Mark="Intel",CPU="Intel",FreqProc=4.0,RAM=8192,HDD=1000,VRAM=4096,Price=720,Count=2},
                new Computer(){Code=2548624,Mark="Avalon",CPU="AMD",FreqProc=1.5,RAM=4096,HDD=370,VRAM=2048,Price=395,Count=21},
                new Computer(){Code=2548624,Mark="Intel",CPU="Intel",FreqProc=3.8,RAM=2048,HDD=250,VRAM=1024,Price=435,Count=17}
            };

            Console.Write("Введите CPU:");
            string CPU = Console.ReadLine();
            Console.Write("Введите RAM:");
            int RAM = Convert.ToInt32(Console.ReadLine());
            //Определение по определенному процесору и по объему ОУЗ
            List<Computer> COMP = computers
                .Where(c => c.RAM > RAM)
                .Where(c => c.CPU == CPU)
                .ToList();
            Console.WriteLine();

            //Сортировка по увелечению цены
            List<Computer> comp0 = computers
                .OrderBy(c => c.Price)
                .ToList();
            foreach (Computer c in comp0)
                Console.WriteLine($" Code:{c.Code}\n Mark:{c.Mark}\n CPU:{c.CPU}\n FreqProc:{c.FreqProc} HZ\n RAM:{c.RAM} MB\n HDD:{c.HDD} TB\n VRAM:{c.VRAM} MB\n Price:{c.Price} y.e\n Count:{c.Count} шт.\n");
            Console.WriteLine();

            //Групипировка по типу Процессоров. P.s Подсмотрел на docs.MS ^_^
            var comp2 = computers
                .GroupBy(com => (com.CPU)
                , (cpu, count) => new
                {
                    CPU = cpu,
                    Count = count.Count(),
                });
            foreach (var result in comp2)
            {
                Console.WriteLine("\nCPU: " + result.CPU);
                Console.WriteLine("Колличество: " + result.Count);
            }
            Console.WriteLine();

            //Минимальная цена
            var comp = computers
                .Min(c => c.Price);
            Console.WriteLine($"Min Computer's Price : {comp} y.e.");
            Console.WriteLine();

            //Максимальная цена
            var comp1 = computers
                .Max(c => c.Price);
            Console.WriteLine($"Max Computer's Price : {comp1} y.e.");
            Console.WriteLine();

            //Есть ли хотя бы один компьютер в количестве не менее 30 штук?
            var comp3 = computers
                .Any(c => c.Count > 30);
            bool YoN = comp3;
            Console.WriteLine("В списке {0} компов больше 30 шт.", YoN ? "есть" : "нет");

            Console.ReadKey();
        }
    }
}
