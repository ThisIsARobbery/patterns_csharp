using System;

namespace Singleton
{
    class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;

        public static Singleton getInstance()
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
            Singleton s1 = Singleton.getInstance();
            Singleton s2 = Singleton.getInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Dumbest version of singleton works!");
            }
            else
            {
                Console.WriteLine("Nothing works. Pity...");
            }
        }
    }
}
