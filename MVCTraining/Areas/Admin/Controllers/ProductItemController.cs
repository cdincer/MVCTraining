﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCTraining.Models;
using Training.Entities;
using MVCTraining.Areas.Admin.Models;
using MVCTraining.Areas.Admin.Extensions;

namespace MVCTraining.Areas.Admin.Controllers
{
    public class ProductItemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ProductItem
        public async Task<ActionResult> Index()
        {
            return View(await db.ProductItems.Convert(db));
        }

        // GET: Admin/ProductItem/Details/5
        public async Task<ActionResult> Details(int? itemId, int? productId)
        {
            if (itemId == null || productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductItem productItem = await GetProductItem(itemId,productId);
            if (productItem == null)
            {
                return HttpNotFound();
            }
            return View(await productItem.Convert(db));
        }
            
        // GET: Admin/ProductItem/Create
        public async Task<ActionResult> Create()
        {
            var model = new ProductItemModel
            {

                Items = await db.Items.ToListAsync(),
                Products = await db.Products.ToListAsync(),


            };
            return View(model);
        }

        // POST: Admin/ProductItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductId,ItemId")] ProductItem productItem)
        {
            if (ModelState.IsValid)
            {
                db.ProductItems.Add(productItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productItem);
        }

        // GET: Admin/ProductItem/Edit/5
        public async Task<ActionResult> Edit(int? ItemId, int? ProductId)
        {
            if (ItemId == null || ProductId==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductItem productItem = await GetProductItem(ItemId,ProductId);
            if (productItem == null)
            {
                return HttpNotFound();
            }
            return View(await productItem.Convert(db));
        }

     

        // POST: Admin/ProductItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductId,ItemId,OldProductId,OldItemId")] ProductItem productItem)
        {
            if (ModelState.IsValid)
            {
                var canChange = await productItem.CanChange(db);
                if (canChange)
                    await productItem.Change(db);

                return RedirectToAction("Index");
            }
            return View(productItem);
        }

        private async Task<ProductItem> GetProductItem(int? itemId, int? productId)
        {
            try
            {
                int itmId = 0, prdId = 0;
                int.TryParse(itemId.ToString(), out itmId);
                int.TryParse(productId.ToString(), out prdId);
                var productItem = await db.ProductItems.FirstOrDefaultAsync(
                    pi => pi.ProductId.Equals(prdId) && pi.ItemId.Equals(itmId));
                return productItem;

            }
            catch { return null; }
        }

        // GET: Admin/ProductItem/Delete/5
        public async Task<ActionResult> Delete(int? itemId, int? productId)
        {
            if (itemId == null || productId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductItem productItem = await GetProductItem(itemId, productId);
            if (productItem == null)
            {
                return HttpNotFound();
            }
            return View(await productItem.Convert(db));
        }

        // POST: Admin/ProductItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int itemId, int productId)
        {
            ProductItem productItem = await GetProductItem(itemId,productId);
            db.ProductItems.Remove(productItem);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
