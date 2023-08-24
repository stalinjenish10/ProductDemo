using ProductDemo.Models;
using ProductDemo.ViewModels;

namespace ProductDemo.Repository.Interface
{
    public interface IProductRepository
    {
        List<ProductViewModel> GetProducList();
        Product GetProductById(int ProductId);
        void AddProduct(Product product, int CreatedBy);
        void UpdateProduct(Product product, int ModifiedBy);
        void DeletProduct(int ProductId);

    }
}
