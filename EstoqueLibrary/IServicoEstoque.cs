using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Estoque
{
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01", Name = "IServicoEstoque")]
    public interface IServicoEstoque
    {
        // Get all products
        [OperationContract]
        List<string> ListarProdutos();
        // Add a product
        [OperationContract]
        bool IncluirProduto(ProductData produto);
        // Remove a product
        [OperationContract]
        bool RemoverProduto(string NumeroProduto);
        // Get the current stock for a product
        [OperationContract]
        int ConsultarEstoque(string NumeroProduto);
        // Add stock for a product
        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int quantidade);
        // Remove stock
        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int quantidade);
        // Get the details of a single product
        [OperationContract]
        ProductData VerProduto(string NumeroProduto);
    }

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02", Name = "IServicoEstoque")]
    public interface IServicoEstoqueV2
    {
        // Get the current stock for a product
        [OperationContract]
        int ConsultarEstoque(string NumeroProduto);
        // Add stock for a product
        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int quantidade);
        // Remove stock
        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int quantidade);
    }

    [DataContract]
    public class ProductData
    {
        [DataMember]
        public string NumeroProduto;
        [DataMember]
        public string NomeProduto;
        [DataMember]
        public string DescricaoProduto;
        [DataMember]
        public int EstoqueProduto;
    }

}
