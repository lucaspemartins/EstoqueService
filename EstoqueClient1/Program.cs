using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EstoqueClient1.EstoqueService;

namespace EstoqueClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();

            // Create a proxy object and connect to the service 
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");
            int quantity;

            // Add a product
            Console.WriteLine("Test 1: Add a product");
            ProductData produto = new ProductData();
            produto.NumeroProduto = "11000";
            produto.NomeProduto = "Produto 11";
            produto.DescricaoProduto = "Este é o produto 11";
            produto.EstoqueProduto = 110;
            if (proxy.IncluirProduto(produto) == true)
            {
                Console.WriteLine("Product added successfully");
            }
            else
            {
                Console.WriteLine("Product was not added");
            }
            Console.WriteLine();

            // Test the operations in the service
            // Obtain a list of all products
            Console.WriteLine("Test 2: Remove a product");
            if (proxy.RemoverProduto("10000") == true)
            {
                Console.WriteLine("Product removed successfully");
            }
            else
            {
                Console.WriteLine("The Product was not removed");
            }
            Console.WriteLine();

            // Obtain a list of all products
            Console.WriteLine("Test 3: List all products");
            List<string> produtos = proxy.ListarProdutos().ToList();
            foreach (string p in produtos)
            {
                Console.WriteLine("Name: {0}", p);
                Console.WriteLine();
            }
            Console.WriteLine();

            // Get details of this product
            Console.WriteLine("Test 4: Display the details of a product");
            ProductData produto1 = proxy.VerProduto("2000");
            Console.WriteLine("Numero Produto: {0}", produto1.NumeroProduto);
            Console.WriteLine("Nome Produto: {0}", produto1.NomeProduto);
            Console.WriteLine("Descricao Produto: {0}", produto1.DescricaoProduto);
            Console.WriteLine("Estoque Produto: {0}", produto1.EstoqueProduto);
            Console.WriteLine();

            // Add stock of this product
            Console.WriteLine("Test 5: Add stock for a product");
            if (proxy.AdicionarEstoque("2000", 10))
            {
                quantity = proxy.ConsultarEstoque("2000");
                Console.WriteLine("Stock changed. Current stock: {0}", quantity);
            }
            else
            {
                Console.WriteLine("Stock update failed");
            }
            Console.WriteLine();

            // Query the stock of this product
            Console.WriteLine("Test 6: Display stock of a product");
            quantity = proxy.ConsultarEstoque("2000");
            Console.WriteLine("Current stock: {0}", quantity);
            Console.WriteLine();

            // Query the stock of this product
            Console.WriteLine("Test 7: Display stock of a product");
            quantity = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Current stock: {0}", quantity);
            Console.WriteLine();

            // Remove the stock of this product
            Console.WriteLine("Test 8: Remove stock of a product");
            if (proxy.RemoverEstoque("1000", 20))
            {
                Console.WriteLine("Stock removed succesfully");
            }
            else
            {
                Console.WriteLine("Stock was not removed");
            }
            Console.WriteLine();

            // Query the stock of this product
            Console.WriteLine("Test 9: Display stock of a product");
            quantity = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Current stock: {0}", quantity);
            Console.WriteLine();

            // Get details of this product
            Console.WriteLine("Test 10: Display the details of a product");
            produto = proxy.VerProduto("1000");
            Console.WriteLine("Numero Produto: {0}", produto.NumeroProduto);
            Console.WriteLine("Nome Produto: {0}", produto.NomeProduto);
            Console.WriteLine("Descricao Produto: {0}", produto.DescricaoProduto);
            Console.WriteLine("Estoque Produto: {0}", produto.EstoqueProduto);
            Console.WriteLine();

            // Disconnect from the service 
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}