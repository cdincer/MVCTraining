using Training.Entities;
using MVCTraining.Areas.Admin.Models;
using MVCTraining.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCTraining.Areas.Admin.Extensions
{
    public static  class ConversionExtensions
    {
        //For Product Index Page
        public  static async Task<IEnumerable<ProductModel>> Convert(this IEnumerable<Product> products, ApplicationDbContext db)
        {
            if (products.Count().Equals(0))
                return new List<ProductModel>();
         

            var texts = await db.ProductLinkTexts.ToListAsync();
            var types = await db.ProductTypes.ToListAsync();

            return from p in products
                   select new ProductModel
                   {
                       Id = p.Id,
                       Title = p.Title,
                       Description = p.Description,
                       ImageUrl = p.ImageUrl,
                       ProductLinkTextId = p.ProductLinkTextId,
                       ProductTypeId = p.ProductTypeId,
                       ProductLinkTexts = texts,
                       ProductTypes = types

                   };
        }


        //For Product Detail Page
        public static async Task<ProductModel> Convert(this Product product, ApplicationDbContext db)
        {



            var text = await db.ProductLinkTexts.FirstOrDefaultAsync(p=>p.Id.Equals(product.ProductLinkTextId));
            var type = await db.ProductTypes.FirstOrDefaultAsync(p => p.Id.Equals(product.ProductTypeId));

            var model = new ProductModel
                   {
                       Id = product.Id,
                       Title = product.Title,
                       Description = product.Description,
                       ImageUrl = product.ImageUrl,
                       ProductLinkTextId = product.ProductLinkTextId,
                       ProductTypeId = product.ProductTypeId,
                       ProductLinkTexts = new List<ProductLinkText>(),
                       ProductTypes = new List<ProductType>()

            };

            model.ProductLinkTexts.Add(text);
            model.ProductTypes.Add(type);

            return model;

        }


        //For ProductItem Index Page
        public static async Task<IEnumerable<ProductItemModel>> Convert(this IQueryable<ProductItem> productItems, ApplicationDbContext db)
        {
            if (productItems.Count().Equals(0))
                return new List<ProductItemModel>();



            return await (from pi in productItems
                          select new ProductItemModel
                          {
                              ItemId = pi.ItemId,
                              ProductId = pi.ProductId,
                              ItemTitle = db.Items.FirstOrDefault(i=>i.Id.Equals(pi.ItemId)).Title,
                              ProductTitle = db.Products.FirstOrDefault(i => i.Id.Equals(pi.ProductId)).Title

                          }).ToListAsync();
        }
        //For ProductItem Edit Page
        public static async Task<ProductItemModel> Convert(this ProductItem productitem, ApplicationDbContext db)
        {

            var model = new ProductItemModel
            {
                ItemId = productitem.ItemId,
                ProductId = productitem.ProductId,
                Items = await db.Items.ToListAsync(),
                Products = await db.Products.ToListAsync()

            };

         

            return model;

        }
    }
}