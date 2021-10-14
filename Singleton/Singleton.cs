using System;
using System.Threading;

namespace Singleton
{
    public class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing dumb singleton...");

            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Dumb singletones work!");
            }
            else
            {
                Console.WriteLine("Dumb singletones are rly dumb!");
            }

            Console.WriteLine("Testing multithread singletones...");
            Thread process1 = new Thread(() => { TestingSingleton("FOO"); });
            Thread process2 = new Thread(() => { TestingSingleton("Bar"); });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
        }

        private static void TestingSingleton(string value)
        {
            MultithreadSingleton singleton = MultithreadSingleton.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }
    }
}
