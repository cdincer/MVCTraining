using Memberships.Entities;
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
        public  static async Task<IEnumerable<ProductModel>> Convert(this IEnumerable<Product> products, ApplicationDbContext db)
        {

            var texts = await db.ProductLinkTexts.ToListAsync();
            var types = await db.ProductTypes.ToListAsync();

            return from p in products
                   select new ProductModel
                   {
                       Id = p.Id,
                       Title = p.Title,
                       Description = p.Description,
                       ProductLinkTextId = p.ProductLinkTextId,
                       ProductTypeId = p.ProductTypeId,
                       ProductLinkTexts = texts,
                       ProductTypes = types

                   };
        }
    }
}