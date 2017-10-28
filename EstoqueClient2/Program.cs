using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EstoqueClient2.EstoqueService;

namespace EstoqueClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();

            // Create a proxy object and connect to the service 
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("WS2007HttpBinding_IServicoEstoque");
            int quantity;

            // Query the stock of this product
            Console.WriteLine("Test 1: Display stock of a product");
            quantity = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Current stock: {0}", quantity);
            Console.WriteLine();

            // Add stock of this product
            Console.WriteLine("Test 2: Add stock for a product");
            if (proxy.AdicionarEstoque("1000", 20))
            {
                quantity = proxy.ConsultarEstoque("1000");
                Console.WriteLine("Stock changed. Current stock: {0}", quantity);
            }
            else
            {
                Console.WriteLine("Stock update failed");
            }
            Console.WriteLine();

            // Query the stock of this product
            Console.WriteLine("Test 3: Display stock of a product");
            quantity = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Current stock: {0}", quantity);
            Console.WriteLine();

            // Query the stock of this product
            Console.WriteLine("Test 4: Display stock of a product");
            quantity = proxy.ConsultarEstoque("5000");
            Console.WriteLine("Current stock: {0}", quantity);
            Console.WriteLine();

            // Remove the stock of this product
            Console.WriteLine("Test 5: Remove stock of a product");
            if (proxy.RemoverEstoque("5000", 10))
            {
                Console.WriteLine("Stock removed succesfully");
            }
            else
            {
                Console.WriteLine("Stock was not removed");
            }
            Console.WriteLine();

            // Query the stock of this product
            Console.WriteLine("Test 6: Display stock of a product");
            quantity = proxy.ConsultarEstoque("5000");
            Console.WriteLine("Current stock: {0}", quantity);
            Console.WriteLine();
        }
    }
}
