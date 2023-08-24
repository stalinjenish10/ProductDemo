using ProductDemo.Models;
using ProductDemo.Repository.Interface;
using ProductDemo.ViewModels;

namespace ProductDemo.Repository.BL
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDemoContext _context;
        public ProductRepository(ProductDemoContext context)
        {
            _context = context;
        }


        public List<ProductViewModel> GetProducList()
        {
            var productData = (from p in _context.Products
                                   join u in _context.UserInfos on p.CreatedBy equals u.UserId
                                   join u1 in _context.UserInfos on p.ModifiedBy equals u1.UserId into table2
                                   from t2 in table2.DefaultIfEmpty()
                                   orderby p.ProductId
                                   select new ProductViewModel
                                   {
                                       ProductId = p.ProductId,
                                       ProductName = p.ProductName,
                                       CreatedBy = u.FirstName + " "+u.LastName,
                                       CreatedDate = p.CreatedDate,
                                       ModifiedBy = t2.FirstName + " " + t2.LastName,
                                       ModifiedDate = p.ModifiedDate
                                   }).ToList();

            return productData;
        }


        public Product GetProductById(int ProductId)
        {
            var product = _context.Products.Where(x=> x.ProductId == ProductId).FirstOrDefault();
            return product;
        }


        public void AddProduct(Product product, int CreatedBy)
        {
            product.CreatedBy = CreatedBy;
            product.CreatedDate = DateTime.Now;
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product productData, int ModifiedBy)
        {
            var existingProduct = _context.Products.Where(x=> x.ProductId == productData.ProductId).FirstOrDefault();
            if(existingProduct != null)
            {
                existingProduct.ProductName = productData.ProductName;
                existingProduct.ModifiedBy = ModifiedBy;
                existingProduct.ModifiedDate = DateTime.Now;
                _context.Products.Update(existingProduct);
                _context.SaveChanges();
            }
            
        }


        public void DeletProduct(int ProductId)
        {
            var productData  = _context.Products.Where(x => x.ProductId == ProductId).FirstOrDefault();
            if(productData != null)
            {
                _context.Products.Remove(productData);
                _context.SaveChanges();
            }

        }

    }
}
