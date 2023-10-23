using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using (var context = new TestApi2010Context())
                {
                    listProducts = context.Products.ToList();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listProducts;
        }
        /*public static Product FindProductById(int id)
        {
            Product p = new Product();
            try
            {
                using (var context = new TestApi2010Context())
                {
                    p = context.Products.SingleOrDefault(x => x.ProductId == id);

                };


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return p;
        }*/
        public static void SaveProduct(Product p)
        {
            try
            {
                using (var context = new TestApi2010Context())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public static void UpdateProduct(Product p)
        {
            try
            {
                using (var context = new TestApi2010Context())
                {
                    context.Entry<Product>(p).State = EntityState.Modified;
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        public static void DeleteProduct(Product p)
        {
            try
            {
                using (var context = new TestApi2010Context())
                {
                    var p1 = context.Products.SingleOrDefault(x => x.ProductId == p.ProductId);
                    context.Products.Remove(p1);
                    context.SaveChanges();

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        public static void AddNewProduct(Product p)
        {
            try
            {
                using (var context = new TestApi2010Context())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding a new product: " + ex.Message);
            }
        }
        /*public Product GetProductById(int id)
        {
            Product p = null;
            try
            {
                using var context = new TestApi2010Context();
                p = context.Products.SingleOrDefault(k => k.ProductId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return p;
        }*/

        public static Product GetProductById(int id)
        {
            try
            {
                using (var context = new TestApi2010Context())
                {
                    // Use LINQ to retrieve the product with the given ID
                    Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
                    return product;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions or log errors as needed
                throw new Exception("Error retrieving product by ID: " + ex.Message);
            }
        }

    }
}
