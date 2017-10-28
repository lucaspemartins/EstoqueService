using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Estoque;

namespace ProvedorEstoqueHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost estoqueServiceHost = new ServiceHost(typeof(ServicoEstoque));
            estoqueServiceHost.Open();
            Console.WriteLine("Service Running");
            Console.ReadLine();
            Console.WriteLine("Service Stopping");
            estoqueServiceHost.Close();
        }
    }
}
