using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarProject.Logic
{
    public class ProductManagement
    {
        private ConnectionClass conn;
        private List<Product> requestedProducts;
        private List<Product> productsSALES;
        private List<Product> productsDEPOT;

        public ProductManagement()
        {
            requestedProducts = new List<Product>();
            productsDEPOT = new List<Product>();
            productsSALES = new List<Product>();
        }

        public List<Product> ProductsSales
        {
            get { return productsSALES; }
            set { productsSALES = value; }
        }

        public List<Product> ProductsDEPOT
        {
            get { return productsDEPOT; }
            set { productsDEPOT = value; }
        }

        public List<Product> RequestedProducts
        {
            get { return requestedProducts; }
            set { requestedProducts = value; }
        }


        public void RestockProducts(string name)
        {
            foreach (var item in requestedProducts)
            {
                if (item.Name == name)
                {
                    item.Stocks += item.Requested;
                    item.Requested = 0;
                }
            }
        }

        public void AddRequest(string name, int amount)
        {
            foreach (var item in productsSALES)
            {
                if (item.Name == name)
                {
                    item.Requested += amount;
                    requestedProducts.Add(item);
                }
            }
        }

        public void ShowProductsDepot()
        {
            foreach (Product p in productsDEPOT)
            {

            }
        }
        public void AddProductSALES(Product p)
        {
            
            productsSALES.Add(p);
        }

        public void AddProductDEPOT(Product p)
        {
            productsDEPOT.Add(p);
            
        }
        public void SellProduct(string name, int quantity)
        {
            
            foreach (var item in productsSALES)
            {
                if (item.Name == name && item.Stocks >= quantity)
                {
                    item.Stocks -= quantity;
                    item.Sold += quantity;
                }
            }
        }
    }
}
