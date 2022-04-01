using System;

namespace PatternsCsharp.Proxy.Conceptual
{

    public interface ISubject
    {
        void Request();
    }

    public class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling request...");
        }
    }

    public class ProxySubject : ISubject
    {
        private RealSubject _realSubject;

        public ProxySubject(RealSubject subject)
        {
            this._realSubject = subject;
        }

        public void Request()
        {
            if (this.CheckAccess()) {
                this._realSubject.Request();
                this.LogAccess();
            }
        }

        public bool CheckAccess()
        {
            Console.WriteLine("Proxy: Checking access...");

            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("Proxy: Logging access...");
        }
    }

    public class Client
    {
        public void ClientCode(ISubject subject)
        {
            subject.Request();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Console.WriteLine("Code with real subject:");;
            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);

            Console.WriteLine("Code with proxy:");
            ProxySubject proxy = new ProxySubject(realSubject);
            client.ClientCode(proxy);
        }
    }
}
