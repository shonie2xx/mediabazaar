using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarProject.Logic
{
    public class ProductRequest
    {
        private List<Product> requestedProducts;
        int requests;

        public ProductRequest(List<Product> requestProducts, int NumRequested)
        {
            this.requestedProducts = requestProducts;
            this.requests = NumRequested;
        }

        public void AddRequest(Product prod)
        {
            if (requests > 0)
            {
                requestedProducts.Add(prod);
            }
        }
    }
}
