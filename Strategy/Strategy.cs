using System;
using System.Collections.Generic;

namespace PatternsCsharp.Strategy.Conceptual
{
    class Context
    {
        private IStrategy _strategy;
        public Context() {}

        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void DoBusinessLogic()
        {
            Console.WriteLine($"Context performs some action with given strategy {this._strategy.GetType()}");
            var result = this._strategy.PerformAlghoritm(new List<string> { "a", "b", "c", "d", "f", "e" });

            string resultString = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultString += element.ToString() + ",";
            }

            Console.WriteLine("Result: " + resultString);
        }
    }

    public interface IStrategy
    {
        object PerformAlghoritm(object obj); 
    }

    class SortStrategy : IStrategy
    {
        public object PerformAlghoritm(object obj)
        {
            var listResult = obj as List<string>;
            listResult.Sort();

            return listResult;
        }
    }

    class SortReverseStrategy : IStrategy
    {
        public object PerformAlghoritm(object obj)
        {
            var listResult = obj as List<string>;
            listResult.Sort();
            listResult.Reverse();

            return listResult;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            IStrategy sortStrategy = new SortStrategy();

            context.SetStrategy(sortStrategy);
            context.DoBusinessLogic();

            IStrategy sortReverseStrategy = new SortReverseStrategy();

            context.SetStrategy(sortReverseStrategy);
            context.DoBusinessLogic();
        }
    }
}
