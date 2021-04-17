using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    public class Program
    {
        public bool appliedJam = false;
        public bool appliedButter = false;
        public bool madeToast = false;
        public bool pouredOJ = false;
        public bool baconDone = false;
        public bool eggsDone = false;
        public bool pouredCoffee = false;
        public static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffe is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while(breakfastTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTasks);
                if(finishedTask == eggsTask)
                {
                    Console.WriteLine("eggs are ready");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }
                else if(finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                breakfastTasks.Remove(finishedTask);
            }

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        public async Task<Toast> MakeToastWithButterAndJamAsyncMock(int number)
        {
            var toast = await ToastBreadAsync(number);
            madeToast = true;
            ApplyButter(toast);
            appliedButter = true;
            ApplyJam(toast);
            appliedJam = true;
            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }
        public Juice PourOJMock()
        {
            Console.WriteLine("Pouring orange juice");
            pouredOJ = true;
            return new Juice();
        }

        private static void ApplyJam(Toast toast)
        {
            Console.WriteLine("Putting jam on the toast");
        }

        private static void ApplyButter(Toast toast)
        {
            Console.WriteLine("Putting butter on the toast");
        }

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for(int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting. . .");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon. . .");
            await Task.Delay(3000);
            for(int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon. . .");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }
        public async Task<Bacon> FryBaconAsyncMock(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon. . .");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon. . .");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");
            baconDone = true;

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan. . .");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs. . .");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        public async Task<Egg> FryEggsAsyncMock(int howMany)
        {
            Console.WriteLine("Warming the egg pan. . .");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs. . .");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");
            eggsDone = true;

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        public Coffee PourCoffeeMock()
        {
            Console.WriteLine("Pouring coffee");
            pouredCoffee = true;
            return new Coffee();
        }
    }
}
