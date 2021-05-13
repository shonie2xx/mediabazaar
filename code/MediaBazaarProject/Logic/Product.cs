using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarProject.Logic
{
    public class Product
    {
        private ConnectionClass conn;
        private string name;
        private int id;
        private double price;
        private int stock;
        private int sold;
        private string category;
        private int amountRequest;
        public Product(string name, double price, int stock, int sold, string category, int amountRequest)
        {
            this.name = name;

            this.price = price;
            this.stock = stock;
            this.sold = sold;
            this.category = category;
            this.amountRequest = amountRequest;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public int Stocks
        {
            get { return this.stock; }
            set { this.stock = value; }
        }

        public int Sold
        {
            get { return this.sold; }
            set { this.sold = value; }
        }
        public string Category
        {
            get { return this.category; }
            set { this.category = value; }
        }

        public int Requested
        {
            get { return this.amountRequest; }
            set { this.amountRequest = value; }
        }

        public string GetInfo()
        {
            string m;
            m = "name: " + name + " " + "price:" + price + " " + "stock: " + stock + " " + "sold: " + sold;
            return m;
        }

        public string GetRequestInfo()
        {
            string m;
            m = "name: " + name + " " + "Requested: " + Requested;
            return m;
        }
    }
}
