using System;
using System.Threading;

namespace Singleton
{
    public class MultithreadSingleton
    {
        private static readonly object _lock = new object();
        private static MultithreadSingleton _instance;
        
        public string Value { get; set; }
        
        private MultithreadSingleton() { }

        public static MultithreadSingleton GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new MultithreadSingleton();
                        _instance.Value = value;
                    }
                }
            }

            return _instance;
        }
    }
}