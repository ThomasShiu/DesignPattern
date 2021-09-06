using System;
using System.Collections.Generic;
using System.Threading;

namespace DesignPattern_thomas
{
    class Program
    {
        static void Main(string[] args)
        {
            // CoffeeTempleteMethod();
            // TeaTempleteMethod();
            // CommanPattern();
            // CommanPattern_market();
            //SignalPattern();
            SignalPattern2();
        }

        #region TempleteMethod
        static void CoffeeTempleteMethod()
        {
            Console.WriteLine("=====================");
            Console.WriteLine("Coffee TempleteMethod.");
            Console.WriteLine("=====================");
            CoffeeWithHook coffee = new CoffeeWithHook();
            coffee.prepareRecipe();
        }

        static void TeaTempleteMethod()
        {
            Console.WriteLine("=====================");
            Console.WriteLine("Tea TempleteMethod.");
            Console.WriteLine("=====================");
            TeaWithHook tea = new TeaWithHook();
            tea.prepareRecipe();
        }
        #endregion
        #region Command Pattern
        static void CommanPattern()
        {
            Console.WriteLine("Command Pattern.");
            Console.WriteLine("=====================");
            // 初始化各個物件
            Invoker invoker = new Invoker(); // 發命令物件
            ReceiverRobot robot = new ReceiverRobot(); // 執行命令物件

            GoAheadCommand cmd_go_ahead = new GoAheadCommand(robot); // 向前走指令
            TurnLeftCommand cmd_turn_left = new TurnLeftCommand(robot); // 左轉指令
            TurnRightCommand cmd_turn_right = new TurnRightCommand(robot); // 右轉指令
            TurnBackCommand cmd_turn_back = new TurnBackCommand(robot); // 向後轉指令

            // 設定要執行的命令
            invoker.SetCommand(cmd_go_ahead);
            invoker.SetCommand(cmd_go_ahead);
            invoker.SetCommand(cmd_turn_left);
            invoker.SetCommand(cmd_go_ahead);
            invoker.SetCommand(cmd_turn_right);
            invoker.SetCommand(cmd_turn_back);
            invoker.SetCommand(cmd_go_ahead);

            // 開始執行命令
            invoker.Run();
            Console.WriteLine("=====================");
            Console.Read();
        }
        static void CommanPattern_market()
        {
            var modifyPrice = new ModifyPrice();// Invoker 發命令物件
            var CurrentPrice = 30000;
            var product = new Product("iPhone 13", CurrentPrice);// Reciver 執行命令物件

            Console.WriteLine(product);
            Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));
            Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 50));
            Execute(modifyPrice, new ProductCommand(product, PriceAction.Decrease, 25));
            Execute(modifyPrice, new ProductCommand(product, PriceAction.Increase, 70));
            Console.WriteLine(product);
            Console.WriteLine("====回復====");
            // modifyPrice.UndoAll();
            modifyPrice.Undo();
            modifyPrice.Undo();
            modifyPrice.Undo();
            modifyPrice.Undo();
            modifyPrice.Undo();
            Console.WriteLine(product);
        }
        private static void Execute(ModifyPrice modifyPrice, ICommand productCommand)
        {
            modifyPrice.SetCommand(productCommand);
            modifyPrice.Invoke();
        }
        #endregion
        #region SignalPattern 單例模式
        private static void SignalPattern1()
        {
            Console.WriteLine("請稍後四秒鐘，正在產生四個單例物件中...");

            // 取得這個類別的單例物件
            Singleton singleton1 = Singleton.Instance;
            Thread.Sleep(1000);
            Singleton singleton2 = Singleton.Instance;
            Thread.Sleep(1000);
            Singleton singleton3 = Singleton.Instance;
            Thread.Sleep(1000);
            Singleton singleton4 = Singleton.Instance;
            Thread.Sleep(1000);

            Console.WriteLine($"單例物件1 HashCode: {singleton1.GetHashCode()} {singleton1.GenerateTime} 的產生時間識別");
            Console.WriteLine($"單例物件2 HashCode: {singleton2.GetHashCode()} {singleton2.GenerateTime} 的產生時間識別");
            Console.WriteLine($"單例物件3 HashCode: {singleton3.GetHashCode()} {singleton3.GenerateTime} 的產生時間識別");
            Console.WriteLine($"單例物件4 HashCode: {singleton4.GetHashCode()} {singleton4.GenerateTime} 的產生時間識別");

            if (singleton1 == singleton2)
            {
                if (singleton2 == singleton3)
                {
                    if (singleton3 == singleton4)
                    {
                        Console.WriteLine($"這四個物件變數，指向同一個物件記憶體位置的單例物件");
                    }
                }
            }

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
        //LazySingleton
        private static void SignalPattern2()
        {
            Console.WriteLine("請稍後四秒鐘，正在產生四個單例物件中...");

            // 取得這個類別的單例物件
            LazySingleton singleton1 = LazySingleton.Instance;
            Thread.Sleep(1000);
            LazySingleton singleton2 = LazySingleton.Instance;
            Thread.Sleep(1000);
            LazySingleton singleton3 = LazySingleton.Instance;
            Thread.Sleep(1000);
            LazySingleton singleton4 = LazySingleton.Instance;
            Thread.Sleep(1000);

            Console.WriteLine($"單例物件1 HashCode: {singleton1.GetHashCode()} {singleton1.GenerateTime} 的產生時間識別");
            Console.WriteLine($"單例物件2 HashCode: {singleton2.GetHashCode()} {singleton2.GenerateTime} 的產生時間識別");
            Console.WriteLine($"單例物件3 HashCode: {singleton3.GetHashCode()} {singleton3.GenerateTime} 的產生時間識別");
            Console.WriteLine($"單例物件4 HashCode: {singleton4.GetHashCode()} {singleton4.GenerateTime} 的產生時間識別");

            if (singleton1 == singleton2)
            {
                if (singleton2 == singleton3)
                {
                    if (singleton3 == singleton4)
                    {
                        Console.WriteLine($"這四個物件變數，指向同一個物件記憶體位置的單例物件");
                    }
                }
            }

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
        //SimpleThreadSafetySingleton
        private static void SignalPattern3()
        {
            Console.WriteLine("請稍後四秒鐘，正在產生四個單例物件中...");

            // 取得這個類別的單例物件
            SimpleThreadSafetySingleton singleton1 = SimpleThreadSafetySingleton.Instance;
            Thread.Sleep(1000);
            SimpleThreadSafetySingleton singleton2 = SimpleThreadSafetySingleton.Instance;
            Thread.Sleep(1000);
            SimpleThreadSafetySingleton singleton3 = SimpleThreadSafetySingleton.Instance;
            Thread.Sleep(1000);
            SimpleThreadSafetySingleton singleton4 = SimpleThreadSafetySingleton.Instance;
            Thread.Sleep(1000);

            Console.WriteLine($"單例物件1 HashCode: {singleton1.GetHashCode()} {singleton1.GenerateTime} 的產生時間識別");
            Console.WriteLine($"單例物件2 HashCode: {singleton2.GetHashCode()} {singleton2.GenerateTime} 的產生時間識別");
            Console.WriteLine($"單例物件3 HashCode: {singleton3.GetHashCode()} {singleton3.GenerateTime} 的產生時間識別");
            Console.WriteLine($"單例物件4 HashCode: {singleton4.GetHashCode()} {singleton4.GenerateTime} 的產生時間識別");

            if (singleton1 == singleton2)
            {
                if (singleton2 == singleton3)
                {
                    if (singleton3 == singleton4)
                    {
                        Console.WriteLine($"這四個物件變數，指向同一個物件記憶體位置的單例物件");
                    }
                }
            }

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
        #endregion
    }
}
