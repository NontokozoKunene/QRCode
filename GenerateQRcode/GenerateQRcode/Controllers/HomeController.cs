using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace GenerateQRcode.Controllers
{
   public class HomeController : Controller
{
    // GET: Home
    public ActionResult Index()
    {
        return View();
    }
 
    [HttpPost]
    public ActionResult Index(string qrcode)
    {

            qrcode += " Time out for you\n you well end";
        using (MemoryStream ms = new MemoryStream())
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qRCodeData = qrGenerator.CreateQrCode(" ", QRCodeGenerator.ECCLevel.Q);
                QRCode qRQcode = new QRCode(qRCodeData);

                 
            using (Bitmap bitMap = qRQcode.GetGraphic(20))
            {
                bitMap.Save(ms, ImageFormat.Png);
                ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
            }
        }
 
        return View();
    }
       
      

        
    }
}