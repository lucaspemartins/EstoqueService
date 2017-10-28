using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using EstoqueEntityModel;
using System.ServiceModel.Activation;

namespace Estoque
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicoEstoque : IServicoEstoque
    {
        public bool AdicionarEstoque(string NumeroProduto, int quantidade)
        {
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the Stock object that matches the parameters passed
                    // in to the operation
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoque.First(pi => pi.NumeroProduto == NumeroProduto);
                    produtoEstoque.EstoqueProduto = produtoEstoque.EstoqueProduto + quantidade;
                    // Save the change back to the database
                    database.SaveChanges();
                }
            }
            catch
            {
                // If an exception occurs, return false to indicate failure
                return false;
            }
            // Return true to indicate success
            return true;
        }

        public int ConsultarEstoque(string NumeroProduto)
        {
            int quantityTotal = 0;
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Calculate the sum of all quantities for the specified product
                    quantityTotal = (from p in database.ProdutoEstoque
                                     where String.Compare(p.NumeroProduto, NumeroProduto) == 0
                                     select (int)p.EstoqueProduto).Sum();
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the stock level
            return quantityTotal;
        }

        public bool IncluirProduto(ProductData produto)
        {
            try
            {
                ProdutoEstoque produtoEstoque = new ProdutoEstoque();
                produtoEstoque.NumeroProduto = produto.NumeroProduto;
                produtoEstoque.NomeProduto = produto.NomeProduto;
                produtoEstoque.DescricaoProduto = produto.DescricaoProduto;
                produtoEstoque.EstoqueProduto = produto.EstoqueProduto;
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    database.ProdutoEstoque.Add(produtoEstoque);
                    database.SaveChanges();
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
                return false;
            }
            // Return the product
            return true;
        }

        public List<string> ListarProdutos()
        {
            List<string> productsList = new List<string>();
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Fetch the products in the database
                    List<ProdutoEstoque> products = (from productestoque in database.ProdutoEstoque select productestoque).ToList();
                    foreach (ProdutoEstoque produtoestoque in products)
                    {
                        string productData = produtoestoque.NomeProduto;
                        productsList.Add(productData);
                    }
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the list of products
            return productsList;
        }

        public bool RemoverEstoque(string NumeroProduto, int quantidade)
        {
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the Stock object that matches the parameters passed
                    // in to the operation
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoque.First(pi => pi.NumeroProduto == NumeroProduto);
                    produtoEstoque.EstoqueProduto = produtoEstoque.EstoqueProduto - quantidade;
                    // Save the change back to the database
                    database.SaveChanges();
                }
            }
            catch
            {
                // If an exception occurs, return false to indicate failure
                return false;
            }
            // Return true to indicate success
            return true;
        }

        public bool RemoverProduto(string NumeroProduto)
        {
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the Stock object that matches the parameters passed
                    // in to the operation
                    ProdutoEstoque produtoEstoque = database.ProdutoEstoque.First(pi => pi.NumeroProduto == NumeroProduto);
                    database.ProdutoEstoque.Remove(produtoEstoque);
                    // Save the change back to the database
                    database.SaveChanges();
                }
            }
            catch
            {
                // If an exception occurs, return false to indicate failure
                return false;
            }
            // Return true to indicate success
            return true;
        }

        public ProductData VerProduto(string NumeroProduto)
        {
            ProductData productData = null;
            try
            {
                // Connect to the ProductsModel database
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    // Find the first product that matches the specified product code
                    ProdutoEstoque matchingProduct = database.ProdutoEstoque.First(
                    p => String.Compare(p.NumeroProduto, NumeroProduto) == 0);
                    productData = new ProductData()
                    {
                        NumeroProduto = matchingProduct.NumeroProduto,
                        NomeProduto = matchingProduct.NomeProduto,
                        DescricaoProduto = matchingProduct.DescricaoProduto,
                        EstoqueProduto = matchingProduct.EstoqueProduto
                    };
                }
            }
            catch
            {
                // Ignore exceptions in this implementation
            }
            // Return the product
            return productData;
        }
    }

}