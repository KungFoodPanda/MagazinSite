using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductCommands
    {
        private ProductContext context { get; set; }
        public List<Product> Products()
        {
            using(context=new ProductContext())
            {
                return context.Products.ToList();
            }
        }
        public Product Show(int id)
        {
            using (context=new ProductContext())
            {
                return context.Products.Find(id);
            }
        }
        public void Add(Product product)
        {
            using (context = new ProductContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public void Update(Product newProduct)
        {
            using (context = new ProductContext())
            {
                var item = context.Products.Find(newProduct.ID);
                if (item != null)
                {

                    context.Entry(item).CurrentValues.SetValues(newProduct);
                    context.SaveChanges();
				}
            }
        }
        public void Delete(int id)
        {
            using (context = new ProductContext())
            {
                var product=context.Products.Find(id);
                if (product!=null)
                {
					context.Products.Remove(product);
                    context.SaveChanges();
				}
            }
        }
    }
}
