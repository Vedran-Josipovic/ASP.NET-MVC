namespace YourNamespace
{
    class MainClass
    {
        static Task zadatak1 = Task.Run(() =>
        {
            Console.WriteLine("Zadatak 1 započeo");
            Thread.Sleep(1000);
            Console.WriteLine("Zadatak 1 završio");
        });

        static Task zadatak2 = Task.Run(() =>
        {
            Console.WriteLine("Zadatak 2 započeo");
            Thread.Sleep(1500);
            Console.WriteLine("Zadatak 2 završio");
        });

        public static void Main(string[] args)
        {
            //Task.WaitAll(zadatak1, zadatak2);
            //.WaitAny(zadatak1, zadatak2);

            Task t1 = SleepF1();
            Console.WriteLine($"Waiting on task SleepF1()..");
            t1.Wait();

        }

        private static async Task SleepF1()
        {
            Console.WriteLine($"Sleeping 1 started");
            await Task.Delay(1000);
            Console.WriteLine($"SleepF2 called");
            await SleepF2();
            Console.WriteLine($"Sleeping 1 completed");
        }

        private static async Task SleepF2()
        {
            Console.WriteLine($"Sleeping 2 started");
            await Task.Delay(2000);
            Console.WriteLine($"Sleeping 2 completed");
        }

    }
}