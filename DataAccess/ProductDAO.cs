using BusinessObject.Models;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instancelock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> productList;
            try
            {
                using (var ctx = new WPF_Sale_ManagerContext())
                {
                    productList = ctx.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productList;
        }

        public IEnumerable<Product> GetProductsByPrice(decimal price)
        {
            List<Product> productList;
            try
            {
                using (var ctx = new WPF_Sale_ManagerContext())
                {
                    productList = ctx.Products.Where(p => p.UnitPrice == price).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productList;
        }

        public IEnumerable<Product> GetProductsByUnitInStock(int unit)
        {
            List<Product> productList;
            try
            {
                using (var ctx = new WPF_Sale_ManagerContext())
                {
                    productList = ctx.Products.Where(p => p.UnitsInStock == unit).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productList;
        }

        public Product getProductById(int id)
        {
            Product product = null;
            try
            {
                using (var ctx = new WPF_Sale_ManagerContext())
                {
                    product = ctx.Products
                        .Include(p => p.OrderDetails)
                        .SingleOrDefault(m => m.ProductId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public void AddProduct(Product product)
        {
            try
            {
                Product m = getProductById(product.ProductId);
                if (m == null)
                {
                    using (var ctx = new WPF_Sale_ManagerContext())
                    {
                        ctx.Products.Add(product);
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                Product p = getProductById(product.ProductId);
                if (p != null)
                {
                    using (var ctx = new WPF_Sale_ManagerContext())
                    {
                        ctx.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Product does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                Product p = getProductById(product.ProductId);
                if (p != null)
                {
                    using (var ctx = new WPF_Sale_ManagerContext())
                    {
                        if (p.OrderDetails.Count != 0)
                        {
                            List<OrderDetail> list = p.OrderDetails.ToList();
                            foreach (var detail in list)
                            {
                                ctx.OrderDetails.Remove(detail);
                            }
                        }
                        ctx.Products.Remove(p);
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception("Product does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Product> GetProductsByFilter(ProductFilter filter)
        {
            if (filter != null)
            {
                List<Product> productList;
                try
                {
                    using (var ctx = new WPF_Sale_ManagerContext())
                    {
                        productList = ctx.Products
                            .Where(product =>   (filter.ProductId == null || product.ProductId.Equals(filter.ProductId)) &&
                                                (filter.ProductName == null || product.ProductName.ToLower().Contains(filter.ProductName.ToLower())) &&
                                                (filter.UnitPrice == null || product.UnitPrice.Equals(filter.UnitPrice)) &&
                                                (filter.CategoryId == null || product.CategoryId.Equals(filter.CategoryId)) &&
                                                (filter.UnitsInStock == null || product.UnitsInStock.Equals(filter.UnitsInStock))).ToList();
                        return productList;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return GetAllProducts();
        }
    }
}
