using System.Security.Cryptography.X509Certificates;

namespace SEW0401AsynchroneProgrammierungconsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Program p = new Program();

            //ue1
            //Task t1 = p.ue1a();
            //Task t2 = p.ue1b();
            //await Task.WhenAll(t2, t1);

            //ue2
            //await p.ue2();

            //ue3
            //await p.ue3();

            //ue4
            await p.ue4b();
        }

        public async Task ue1a()
        {
            Console.WriteLine("AE");
            Thread.Sleep(5000);
            Console.WriteLine("AE2");
        }
        public async Task ue1b()
        {
            Console.WriteLine("BE");
            await Task.Delay(5000);
            Console.WriteLine("BE2");
        }

        public async Task ue2()
        {
            Task t1 = Task.Run(async () =>
            {
                await Task.Delay(2000);
                Console.WriteLine("Task 1 ist fertig");
            });

            Task t2 = Task.Run(async () =>
            {
                await Task.Delay(4000);
                Console.WriteLine("Task 2 ist fertig");
            });

            Task t3 = Task.Run(async () =>
            {
                await Task.Delay(1000);
                Console.WriteLine("Task 3 ist fertig");
            });

            await t1;
            await t2;
            await t3;
        }

        public async Task ue3()
        {
            Task t1 = Task.Run(async () =>
            {
                await Task.Delay(2000);
                Console.WriteLine("Task 1 ist fertig");
            });

            Task t2 = Task.Run(async () =>
            {
                await Task.Delay(4000);
                Console.WriteLine("Task 2 ist fertig");
            });

            Task t3 = Task.Run(async () =>
            {
                await Task.Delay(1000);
                Console.WriteLine("Task 3 ist fertig");
            });

            await Task.WhenAll(t1, t2, t3);
            Console.WriteLine("Alle Tasks sind fertig");
        }


        public async Task ue4a() //ohne lock
        {
            int counter = 0;
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        counter++;
                    }
                }));
            }

            await Task.WhenAll(tasks);
            Console.WriteLine($"Ergebnis = {counter}");

        }
        public async Task ue4b()
        {
            int counter = 0;
            List<Task> tasks = new List<Task>();
            object lockObject = new object();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        lock (lockObject) // entweder das oder das Kommentierte da unten
                        {
                            counter++;
                        }

                        //Interlocked.Increment(ref counter); 
                    }
                }));
            }

            await Task.WhenAll(tasks);
            Console.WriteLine($"Ergebnis = {counter}");

        }
    }
}
