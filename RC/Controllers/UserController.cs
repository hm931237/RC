using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RC.Models;
using RC.ViewModels;
using System.Data.Entity;
using System.Diagnostics;
using System.Web.Helpers;
using QRCoder;
using System.Drawing;

namespace RC.Controllers
{
    public class UserController : Controller
    {
        ApplicationDbContext DB = new ApplicationDbContext();


        public ActionResult Index()
        {
            if (Session["UserId"] != null && Convert.ToInt32(Session["LoginUserTypeId"])==2)
            {
                var cltid = (int)Session["UserId"];
                var user = DB.Clients.SingleOrDefault(c => c.userId == cltid);

                var client = DB.Clients.SingleOrDefault(c => c.userId == cltid);
                //if (client != null)
                //{
                var users = DB.Users.ToList();
                var subscribers = DB.Subscribers.Where(s => s.clientId == client.Id).ToList();
                var organizations = DB.Organizations.ToList();
                var posts = DB.Posts.ToList();
                var postImgs = DB.PostImages.ToList();
                var reactions = DB.PostReactions.ToList();
                var promotions = DB.Promotions.ToList();
                var promotionAges = DB.PromotionAges.ToList();
                var advertisements = DB.Advertisements.ToList();
                var VM = new PostsForEveryUser
                {
                    client = client,
                    user = users,
                    Organizations = organizations,
                    Subscribers = subscribers,
                    PostImages = postImgs,
                    Posts = posts,
                    Reactions = reactions,
                    Promotion = promotions,
                    PromotionAge = promotionAges,
                    Advertisement = advertisements,
                    userID = cltid
                };

                return View("Index", VM);

            }
            else
            {
                if (Convert.ToInt32(Session["LoginUserTypeId"]) == 3)
                {
                    return RedirectToAction("Index", "Organization");
                }
                else if (Convert.ToInt32(Session["LoginUserTypeId"]) == 2)
                {
                    return RedirectToAction("Index", "User");
                }
                else if (Convert.ToInt32(Session["LoginUserTypeId"]) == 1)
                {
                    return RedirectToAction("Home", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }


        [HttpGet]
        public ActionResult SignUp_User()
        {
            var cities = DB.Cities.ToList();

            ClientUser clientuser = new ClientUser
            {
                city = cities

            };
            return View(clientuser);
        }

        [HttpPost]
        public ActionResult SignUp_User(ClientUser clientuser)
        {
            string filename = Path.GetFileNameWithoutExtension(clientuser.ImageFile.FileName);
            string extension = Path.GetExtension(clientuser.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            clientuser.user.imageUrl = filename;
            filename = Path.Combine(Server.MapPath("~/files"), filename);
            clientuser.ImageFile.SaveAs(filename);
            if (clientuser.user!=null)
            {

                clientuser.user.UserTypeId = 2;
                clientuser.client.Points = 0;
                clientuser.user.State = 1;
                clientuser.user.JoniedAt = DateTime.Now;
                clientuser.user.Password = clientuser.Password;
                DB.Users.Add(clientuser.user);
                DB.Clients.Add(clientuser.client);
                DB.SaveChanges();
           
                return RedirectToAction("Index", "Home");
            }
            else
            {

                var cities = DB.Cities.ToList();

                ClientUser clientuser1 = new ClientUser
                {
                    city = cities

                };
                ViewBag.text = "enter all data";
                return View(clientuser1);
            }
            
        }


        public ActionResult Followings()
        {
            if (Session["UserId"] != null && Convert.ToInt32(Session["LoginUserTypeId"]) == 2)
            {
                int id = (int)Session["UserId"];
                var user = DB.Users.SingleOrDefault(c => c.Id == id);
                var client = DB.Clients.SingleOrDefault(c => c.userId == user.Id);
                var subscribers = DB.Subscribers
                    .Where(s => s.clientId == client.Id)
                    .Include(s => s.Organization.User);

                return View("Follwings", subscribers);

            }
            else
            {
                if (Convert.ToInt32(Session["LoginUserTypeId"]) == 3)
                {
                    return RedirectToAction("Index", "Organization");
                }
                else if (Convert.ToInt32(Session["LoginUserTypeId"]) == 2)
                {
                    return RedirectToAction("Index", "User");
                }
                else if (Convert.ToInt32(Session["LoginUserTypeId"]) == 1)
                {
                    return RedirectToAction("Home", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public ActionResult Ratings()
        {
            if (Session["UserId"] != null && Convert.ToInt32(Session["LoginUserTypeId"]) == 2)
            {
                var clt_user_id = (int)Session["UserId"];
                var client = DB.Clients.SingleOrDefault(c => c.userId == clt_user_id);
                var reviews = DB.Reviews.Where(c => c.clientId == client.Id)
                    .Include(c => c.Organization.User)
                    .Include(c => c.Client);

                return View("Ratings", reviews);

            }
            else
            {
                if (Convert.ToInt32(Session["LoginUserTypeId"]) == 3)
                {
                    return RedirectToAction("Index", "Organization");
                }
                else if (Convert.ToInt32(Session["LoginUserTypeId"]) == 2)
                {
                    return RedirectToAction("Index", "User");
                }
                else if (Convert.ToInt32(Session["LoginUserTypeId"]) == 1)
                {
                    return RedirectToAction("Home", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult Edit(int id)
        {
            if (Session["UserId"] == null || Convert.ToInt32(Session["LoginUserTypeId"]) != 2)
            {
                return RedirectToAction("Index", "Home");
            }
            var cities = DB.Cities.ToList();

         
            var updated_client = DB.Clients.Include(o => o.User).Include(o => o.City).SingleOrDefault(o => o.Id == id);
            
            var viewmodel = new ClientUser
            {
                client = updated_client,
                city = cities

            };
            return View("SignUpEditForm", viewmodel);
        }

        [HttpPost]
        public ActionResult Edituser(ClientUser user)
        {
            var id = (int)Session["UserId"];
            var UserInDB = DB.Clients.SingleOrDefault(x => x.userId == id);
            var userauth=DB.Users.SingleOrDefault(x=>x.Id==id);
            UserInDB.firstName = user.client.firstName;
            UserInDB.lastName = user.client.lastName;
            UserInDB.Address = user.client.Address;
            UserInDB.dateOfBirth = user.client.dateOfBirth;
            UserInDB.Age = user.client.Age;
            UserInDB.Address = user.client.Address;
            UserInDB.Points = user.client.Points;



            string filename = Path.GetFileNameWithoutExtension(user.ImageFile.FileName);
            string extension = Path.GetExtension(user.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            userauth.imageUrl = filename;
            filename = Path.Combine(Server.MapPath("~/files"), filename);
            user.ImageFile.SaveAs(filename);

           // userauth.imageUrl = user.user.imageUrl;
            DB.SaveChanges();
            return RedirectToAction("Index","User");
        }

        public ActionResult logout()
        {

            Session["UserId"] = null;
            Session["LoginUserTypeId"] = null;
            Session["orgID"] = null;
            return RedirectToAction("Index","Home");
        }
        public JsonResult CheckUsernameAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = DB.Users.Where(x => x.Username.Equals(userdata)).Count();
            if (SeachData != 0)
            {

                return Json(1);
            }
            else
            {

                return Json(0);
            }

        }
        
        public JsonResult Subscribe(Subscriber subscriber)
        {
            var subscribe = DB.Subscribers.SingleOrDefault(s => s.clientId == subscriber.clientId && s.organizationId == subscriber.organizationId);
            if (subscribe == null)
            {
                var newSubscribe =new Subscriber
                {
                    clientId =subscriber.clientId,
                    organizationId = subscriber.organizationId,
                    Date = DateTime.Now
                };
                DB.Subscribers.Add(newSubscribe);
                DB.SaveChanges();
                return Json("UnFollow");

            }
            else
            {
                DB.Subscribers.Remove(subscribe);
                DB.SaveChanges();
                return Json("Follow");
            }
            
        }
   
        public ActionResult Activity()
        {
            return View("Activity");
        }
        [HttpGet]
        public ActionResult loadingPoint(int Idd)
        {

            var userid = Convert.ToInt32(Session["UserId"]);
            var client = DB.Clients.SingleOrDefault(c => c.userId == userid);
            string myString = client.Points.ToString();
            return Content(myString);
            // return Json(new { Result = client.Points });

        }


        public ActionResult Gifts()
        {

            if (Session["UserId"] == null || Convert.ToInt32(Session["LoginUserTypeId"]) != 2)
            {
                return RedirectToAction("Index", "Home");
            }

            var userid = Convert.ToInt32(Session["UserId"]);
            var client = DB.Clients.SingleOrDefault(c => c.userId == userid);
            var gifts = DB.Offers/*.Where(c => c.requiredPoint <= client.Points)*/.ToList();
            var offerWinner = DB.OfferWinners.Where(c => c.clientId == client.Id).ToList();
            for (int i = 0; i < offerWinner.Count(); i++)
            {
                for (int x = 0; x < gifts.Count(); x++)
                {
                    if (gifts[x].Id == offerWinner[i].offerId)
                    {
                        gifts.RemoveAt(x);
                    }
                }

            }
            return View("Gifts", gifts);
        }
        [HttpGet]
        public ActionResult Getcode(int Id)
        {
            var gift = DB.Offers.Single(c => c.Id == Id);

            string txtQRCode = gift.Qr_Gift;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(txtQRCode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            //imgBarCode.Height = 150;
            //imgBarCode.Width = 150;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ViewBag.imageBytes = ms.ToArray();
                    //imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
            }



            //Random rand = new Random();
            //int ranNum = rand.Next();
            var id = Convert.ToInt32(Session["UserId"]);
            var user = DB.Clients.Single(c => c.userId == id);


            //  var offerWin = DB.Offers.ToList();



            if (user.Points >= gift.requiredPoint)
            {
                var offerwinners = new OfferWinner();
                offerwinners.clientId = user.Id;
                offerwinners.offerId = gift.Id;
                DB.OfferWinners.Add(offerwinners);
                DB.SaveChanges();
                user.Points = user.Points - gift.requiredPoint;
                DB.SaveChanges();
                return PartialView("codepartial");
            }
            else
            {
                string msg = "error";
                return Content(msg);
            }
        }






        /*func2*/

        [HttpGet]
        public ActionResult reloadContent(int Id)
        {
            //var id = Convert.ToInt32(Session["UserId"]);
            //var user = DB.Clients.Single(c => c.userId == id);
            //var gift = DB.Offers.Single(c => c.Id == Id);

            //  var offerWin = DB.Offers.ToList();

            //var offerwinners = new OfferWinner();
            //offerwinners.clientId = user.Id;
            //offerwinners.offerId = gift.Id;
            //DB.OfferWinners.Add(offerwinners);
            //DB.SaveChanges();


            //    user.Points = user.Points - gift.requiredPoint;
            //    DB.SaveChanges();


            var userid = Convert.ToInt32(Session["UserId"]);
            var client = DB.Clients.SingleOrDefault(c => c.userId == userid);
            var gifts = DB.Offers/*.Where(c => c.requiredPoint <= client.Points)*/.ToList();
            var offerWinner = DB.OfferWinners.Where(c => c.clientId == client.Id).ToList();
            for (int i = 0; i < offerWinner.Count(); i++)
            {
                for (int x = 0; x < gifts.Count(); x++)
                {
                    if (gifts[x].Id == offerWinner[i].offerId)
                    {
                        gifts.RemoveAt(x);
                    }
                }

            }


            return PartialView("_partialGift", gifts);


        }




        [HttpGet]
        public ActionResult Getcodebyemail(int Idd)
        {


            Random rand = new Random();
            long ranNum = rand.Next();
            var id = Convert.ToInt32(Session["UserId"]);
            var client = DB.Clients.Single(c => c.userId == id);
            var user = DB.Users.Single(c => c.Id == id);
            var gift = DB.Offers.Single(c => c.Id == Idd);


            if (client.Points >= gift.requiredPoint)
            {
                var offerwinners = new OfferWinner();
                offerwinners.clientId = client.Id;
                offerwinners.offerId = gift.Id;
                DB.OfferWinners.Add(offerwinners);
                DB.SaveChanges();

                SendMail(user, ranNum);
                client.Points = client.Points - gift.requiredPoint;
                DB.SaveChanges();
                string msg = "email";
                return Content(msg);
            }
            else
            {
                string msg = "error";
                return Content(msg);
            }
        }




        public void SendMail(User user, long randomNumber)
        {
            WebMail.SmtpServer = "smtp.gmail.com";
            //gmail port to send emails  
            WebMail.SmtpPort = 587;
            WebMail.SmtpUseDefaultCredentials = true;
            //sending emails with secure protocol  
            WebMail.EnableSsl = true;
            //EmailId used to send emails from application  
            WebMail.UserName = "khaaledessaam@gmail.com";
            WebMail.Password = "khaled18";

            //Sender email address.  
            WebMail.From = "khaaledessaam@gmail.com";

            //Send email  
            try
            {
                WebMail.Send(user.Email, "Rewar Code", "..your gift code is" + randomNumber);
            }

            catch (System.Net.Mail.SmtpException smtpNotFound)
            { }


        }
        public ActionResult Saved()
        {
            return View("Saved");
        }
        public ActionResult Filter()
        {
            return View("Filter");
        }

        public ActionResult Comparison()
        {
            return View("Comparison");
        }

        
    }
}
