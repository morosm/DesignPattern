namespace Structural
{
    /// <summary>
    /// The 'Subject interface
    /// </summary>
    public interface IClient
    {
        string GetData();
    }

    /// <summary>
    /// The 'RealSubject' class
    /// </summary>
    public class RealClient : IClient
    {
        string Data;
        public RealClient()
        {
            Console.WriteLine("Real Client: Initialized");
            Data = "Dot Net Tricks";
        }

        public string GetData()
        {
            return Data;
        }
    }

    /// <summary>
    /// The 'Proxy Object' class
    /// </summary>
    public class ProxyClient : IClient
    {
        RealClient client = new RealClient();
        public ProxyClient()
        {
            Console.WriteLine("ProxyClient: Initialized");
        }

        public string GetData()
        {
            return client.GetData();
        }
    }

    /// <summary>
    /// Proxy Pattern Demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ProxyClient proxy = new ProxyClient();
            Console.WriteLine("Data from Proxy Client = {0}", proxy.GetData());

            Console.ReadKey();
        }
    }

}