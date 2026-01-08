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

            //ue5
            //await p.ue5();

            //ue5 is AI ham im unterricht spau und ich auch nur so gmacht und sonst hats keiner ghabt
            //ue6 hama ned gmacht
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

        public async Task ue5()
        {
            long max = 1000000;
            int kerne = 4;
            long schrittweite = max / kerne;
            List<Task> tasks = new List<Task>();

            

            for (int i = 0; i < kerne; i++)
            {
                long von = i * schrittweite + 1;
                long bis = (i == kerne - 1) ? max : (i + 1) * schrittweite;

                tasks.Add(Task.Run(() =>
                {
                    // Ein StringBuilder ist viel schneller als tausend einzelne Console.Writes
                    System.Text.StringBuilder puffer = new System.Text.StringBuilder();

                    for (long n = von; n <= bis; n++)
                    {
                        if (IsPrime(n))
                        {
                            puffer.AppendLine(n.ToString());
                        }
                    }
                    // Jetzt den ganzen Block für diesen Kern ausgeben
                    Console.Write(puffer.ToString());
                }));
            }

            // Warten, bis alle Kerne fertig gedruckt haben
            await Task.WhenAll(tasks);
            
        }

        private bool IsPrime(long n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            for (long j = 3; j * j <= n; j += 2)
            {
                if (n % j == 0) return false;
            }
            return true;
        }
    }
}
