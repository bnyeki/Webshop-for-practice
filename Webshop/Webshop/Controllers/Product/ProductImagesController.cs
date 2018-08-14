using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;

namespace Webshop.Controllers.Product
{
    public class ProductImagesController : Controller
    {
        private WebshopDBEntities db = new WebshopDBEntities();

        // GET: ProductImages
        public async Task<ActionResult> Index()
        {
            List<ProductImageModel> productImageModel = new List<ProductImageModel>();
            await db.ProductImage.ForEachAsync(x =>
            productImageModel.Add(new ProductImageModel()
            {
                Id = x.Id,
                Name = x.Name,
                SourceString = ConvertImageDataToSourceString(x.Data)

            }

            ));

            return View(productImageModel);
        }



        // GET: ProductImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage productImage = db.ProductImage.Find(id);
            ProductImageModel productImageModel = new ProductImageModel();

            if (productImage == null)
            {
                return HttpNotFound();
            }
            else
            {
                productImageModel.Id = productImage.Id;
                productImageModel.Name = productImage.Name;
                productImageModel.SourceString = ConvertImageDataToSourceString(productImage.Data);

            }
            return View(productImageModel);
        }



        // GET: ProductImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DataInHttpPostedFileBase")]  ProductImageModel productImageModel)
        {
            if (ModelState.IsValid)
            {
                //mapping
                ProductImage image = new ProductImage()
                {
                    Name = productImageModel.Name,
                    //Using own method to convert the posted file to a bytearray
                    Data = ConvertHttpPostedFileBaseToByteArray(productImageModel.DataInHttpPostedFileBase)
                };

                db.ProductImage.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productImageModel);
        }

        // GET: ProductImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage image = db.ProductImage.Find(id);

            ProductImageModel productImageModel = new ProductImageModel();

            if (image == null)
            {
                return HttpNotFound();
            }
            else //mapping
            {
                productImageModel.Name = image.Name;
                productImageModel.Id = image.Id;
            }


            return View(productImageModel);
        }

        // POST: ProductImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DataInHttpPostedFileBase")] ProductImageModel productImageModel)
        {
            if (ModelState.IsValid)
            {
                //Finding the image to change
                ProductImage image = db.ProductImage.Find(productImageModel.Id);

                //If the user posted a new picture change the imagedata,
                //else don't do anything with it
                if (productImageModel.DataInHttpPostedFileBase != null)
                {
                    //Using own method to convert the posted file to a bytearray
                    image.Data = ConvertHttpPostedFileBaseToByteArray(productImageModel.DataInHttpPostedFileBase);
                }

                image.Name = productImageModel.Name;

                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productImageModel);
        }

        // GET: ProductImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductImage image = db.ProductImage.Find(id);

            ProductImageModel productImageModel = new ProductImageModel();
            if (image == null)
            {
                return HttpNotFound();
            }
            else //mapping
            {
                productImageModel.Id = image.Id;
                productImageModel.Name = image.Name;
                productImageModel.SourceString = ConvertImageDataToSourceString(image.Data);
            }

            return View(productImageModel);
        }

        // POST: ProductImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductImage productImage = db.ProductImage.Find(id);
            db.ProductImage.Remove(productImage);
            db.SaveChanges();
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

        private string ConvertImageDataToSourceString(byte[] data)
        {
            return String.Format($"data:image/jpg;base64,{Convert.ToBase64String(data)}");
        }

        private byte[] ConvertHttpPostedFileBaseToByteArray(HttpPostedFileBase fileBase)
        {
            byte[] returnData;

            //Using a memory stream, copying the fileBase-s input stream to it, 
            //then converting it to a byteArray and putting it to the returnData
            using (MemoryStream memoryStreamThatContainsTheImage = new MemoryStream())
            {

                fileBase.InputStream.CopyTo(memoryStreamThatContainsTheImage);
                returnData = memoryStreamThatContainsTheImage.GetBuffer();
            }

            return returnData;
        }
    }
}
