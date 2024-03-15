namespace YourNamespace
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Task zadatak1 = Task.Run(() =>
            {
                Console.WriteLine("Zadatak 1 započeo");
                Thread.Sleep(1000);
                Console.WriteLine("Zadatak 1 završio");
            });
            Console.WriteLine("Čekam zadatak 1..");


            Task zadatak2 = Task.Run(() =>
            {
                Console.WriteLine("Zadatak 2 započeo");
                Thread.Sleep(1500);
                Console.WriteLine("Zadatak 2 završio");
            });
            Console.WriteLine("Čekam zadatak 2..");

            Task.WaitAll(zadatak1, zadatak2);


            /*
            OUTPUT SA Task.WaitAll() --> Čeka se da svi zadatci završe
            Čekam zadatak 1..
            Zadatak 1 započeo
            Čekam zadatak 2..
            Zadatak 2 započeo
            Zadatak 1 završio
            Zadatak 2 završio
            */

            /*
            OUTPUT SA Task.WaitAny() --> Čeka se da jedan zadatka završe
            Čekam zadatak 1..
            Zadatak 1 započeo
            Čekam zadatak 2..
            Zadatak 2 započeo
            Zadatak 1 završio
            */

        }



    }
}