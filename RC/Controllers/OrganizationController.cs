using RC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RC.ViewModels;
using System.IO;
using System;
using System.Collections;


namespace RC.Controllers
{
    public class OrganizationController : Controller
    {
     

        ApplicationDbContext _context;

        public OrganizationController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Organization
        public ActionResult Index(int? id)
        {

            var organ = new Organization();
            var postReactions = _context.PostReactions.ToList();
            var UserLoggedIn = new User();
            //   var orgid=0;


            if (id == null)
            {
                if (Session["UserId"] != null && Convert.ToInt32(Session["LoginUserTypeId"]) == 3)
                {
                    var orgid = (int)Session["UserId"];
                    UserLoggedIn = _context.Users.SingleOrDefault(ur => ur.Id == orgid);
                    organ = _context.Organizations.Where(org => org.userId == orgid).Include(org => org.User).SingleOrDefault();
                    Session["LoggedInUser"] = UserLoggedIn;
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                    //UserLoggedIn = null;
                }

            }
            else
            {
                if (Session["UserId"] != null)
                {
                    var UserID = (int)Session["UserId"];
                    Session["orgID"] = id;
                    Session.Timeout = 120;
                    organ = _context.Organizations.Where(org => org.Id == id).Include(org => org.User).SingleOrDefault();
                    UserLoggedIn = _context.Users.SingleOrDefault(ur => ur.Id == organ.userId);
                    Session["LoggedInUser"] = UserLoggedIn;

                }
                else
                {
                    Session["orgID"] = id;
                    Session.Timeout = 120;
                    organ = _context.Organizations.Where(org => org.Id == id).Include(org => org.User).SingleOrDefault();
                    UserLoggedIn = _context.Users.SingleOrDefault(ur => ur.Id == organ.userId);
                    Session["LoggedInUser"] = UserLoggedIn;
                }


            }

            var posts = _context.Posts.Where(post => post.organizationId == organ.Id).ToList();
            Stack<Post> postsStack = new Stack<Post>();
            var promotions = _context.Promotions.ToList();
            var counters = new List<int>();
            //   var orgId = (int)Session["UserId"];
            //     var userLoggedIn = _context.Users.SingleOrDefault(ur => ur.Id == orgId);

            foreach (var post in posts)
            {
                counters.Add(_context.PostImages.Where(p => p.postId == post.Id).Include(p => p.postId).Count());
                postsStack.Push(post);

            }



            OrganizationIndexPost ovm = new OrganizationIndexPost
            {
                posts = postsStack,
                postImages = _context.PostImages.Include(p => p.Post).ToList(),
                organization = organ,
                PostReaction = postReactions,
                Promotions = promotions,
                LoginUser = UserLoggedIn


            };

            return View("index", ovm);

        }
        public JsonResult CheckUsernameAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = _context.Users.Where(x => x.Username.Equals(userdata)).SingleOrDefault();
            if (SeachData != null)
            {

                return Json(1);
            }
            else
            {

                return Json(0);
            }

        }

        public ActionResult UsernameVerification(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = _context.Users.Where(x => x.Username.Equals(userdata) && x.UserTypeId == 2).SingleOrDefault();
            if (SeachData != null)
            {

                return Json(1);
            }
            else
            {

                return Json(0);
            }
            return View();
        }



        public JsonResult CheckPersonalEmailAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = _context.Users.Where(x => x.Email.Equals(userdata)).SingleOrDefault();
            if (SeachData != null)
            {

                return Json(1);
            }
            else
            {

                return Json(0);
            }

        }


        public JsonResult CheckBusinessEmailAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = _context.Organizations.Where(x => x.businessEmail.Equals(userdata)).SingleOrDefault();
            if (SeachData != null)
            {

                return Json(1);
            }
            else
            {

                return Json(0);
            }

        }


        public JsonResult CheckOrgNameAvailability(string userdata)
        {
            System.Threading.Thread.Sleep(200);
            var SeachData = _context.Organizations.Where(x => x.orgnizationName.Equals(userdata)).SingleOrDefault();
            if (SeachData != null)
            {

                return Json(1);
            }
            else
            {

                return Json(0);
            }

        }

        //Organization Sign Up View
        public ActionResult SignUp_Org()
        {

            var sectors = _context.Sector.ToList();
            var factors = _context.Factors.ToList();
            var cities = _context.Cities.ToList();
            var categories = _context.Categories.ToList();
            var priceRanges = _context.PriceRanges.ToList();
            User user = new Models.User();
            Phone phone = new Phone();

            var viewmodel = new OrganizationViewModel
            {

                Sectors = sectors,
                Factors = factors,
                Cities = cities,
                Categories = categories,
                PriceRanges = priceRanges,
                user=user,
                Phone=phone


            };
            return View(viewmodel);
        }

        public ActionResult Edit(int id)
        {


            OrganizationEditViewModel viewmodel;
            if (Session["UserId"] != null)
            {

                var editorgSession = (int)Session["UserId"];
                var CheckSession = _context.Users.Where(x => x.Id == editorgSession && x.UserTypeId == 3).FirstOrDefault();


                if (CheckSession != null)
                {
                    var CheckOrgSession = _context.Organizations.Where(x => x.userId == CheckSession.Id).FirstOrDefault();
                    if (CheckOrgSession.Id == id)
                    {

                        var organization = _context.Organizations.Include(o => o.User).Include(o => o.Category.Sector).Include(o => o.Worktimes).SingleOrDefault(o => o.Id == id);
                        var category = _context.Categories.Find(organization.categoryId);
                        var sector = _context.Sector.Find(category.sectorId);

                        // var factors = _context.Factors.ToList();
                        var cities = _context.Cities.ToList();

                        var userID = _context.Users.Find(organization.userId);

                        var priceranges = _context.PriceRanges.ToList();
                        var phone = _context.Phones.Where(p => p.userId == userID.Id).ToList();
                        var worktimes = _context.WorkTimes.Where(work => work.OrganizationId == id).ToList();
                        var user = _context.Users.Find(organization.userId).imageUrl;
                        var factors = _context.Factors.Where(fac => fac.categoryId == organization.categoryId).ToList();
                        var orgFactors = _context.OrganizationFactors.Include(org => org.Factor).Where(org => org.organizationId == organization.Id).ToList();


                        //Session["UserImage"] = user;

                        // Session["orgFactors"] = orgFactors;

                        //List<String> organizationFactors = new List<string>();

                        //foreach (var org in orgFactors)
                        //{

                        //    organizationFactors.Add(org.Factor.Name);


                        //}
                        //Session["FactorsList"] = organizationFactors;

                        ViewData["WorkTimes"] = worktimes;



                        // Session["imgURL"] = organization.User.imageUrl;

                        var EditsectorId = _context.Categories.Find(organization.categoryId).sectorId;
                        var EditsectorName = _context.Sector.Where(sec => sec.Id == EditsectorId).ToList();

                        string phoneInDb = null;
                        foreach (var p in phone)
                        {
                            phoneInDb = p.phoneNumber;
                        }
                        foreach (var x in EditsectorName)
                        {
                            Session["EditSectorName"] = x.Name;
                            Session["EditSectorId"] = x.Id;
                        }


                        //foreach (var phone in phones)
                        //{
                        //    ViewBag.Result = phone.phoneNumber;

                        //};

                        if (organization == null)
                            return HttpNotFound();
                        else
                        {

                            viewmodel = new OrganizationEditViewModel
                            {
                                Organization = organization,
                                Sector = sector,
                                Category = category,
                                Factors = factors,
                                Cities = cities,
                                PriceRanges = priceranges,
                                Password = userID.Password,
                                ConfirmPassword = userID.Password,
                                phone = phoneInDb,
                                orgFactors = orgFactors

                            };


                            return View("SignUpEditForm", viewmodel);
                        }



                    }
                    else
                    {
                        return RedirectToAction("Index", "Organization");

                    }

                }

                else
                {
                    return RedirectToAction("Index", "User");

                }

            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }


        [HttpPost]
        public ActionResult Save(OrganizationViewModel organizationViewModel, HttpPostedFileBase upload)
        {
            List<String> holidays = new List<String>();
            List<WorkTime> NewWorkTimes = new List<WorkTime>();









            if (organizationViewModel.Organization.Id == 0)
            {

                User newUSer = new Models.User();
                string path = Path.Combine(Server.MapPath("~/Content/img/OrganizationsProfilePics"), upload.FileName);
                upload.SaveAs(path);



                newUSer.Email = organizationViewModel.user.Email;
                newUSer.Password = organizationViewModel.Password;
                newUSer.Username = organizationViewModel.user.Username;
                newUSer.imageUrl = upload.FileName;
                newUSer.UserTypeId = 3;
                newUSer.JoniedAt = DateTime.Now;
                _context.Users.Add(newUSer);
                _context.SaveChanges();


                Phone curPHone = new Phone();
                curPHone.phoneNumber = organizationViewModel.Phone.phoneNumber;
                curPHone.userId = newUSer.Id;

                _context.Phones.Add(curPHone);
                _context.SaveChanges();



                organizationViewModel.Organization.userId = newUSer.Id;

                _context.Organizations.Add(organizationViewModel.Organization);
                _context.SaveChanges();

                OrganizationFactor orgFactor = null;



                var factors = _context.Factors.Where(fac => fac.categoryId == organizationViewModel.Organization.categoryId).ToList();
                //Session["FactorsList"] 
                if (factors != null)
                {
                    string factor = null;

                    for (int i = 1; i <= factors.Count; i++)
                    {
                        factor = Request.Form["factor_" + i.ToString()];
                        if (factor != null)
                        {
                            orgFactor = new OrganizationFactor();
                            orgFactor.organizationId = organizationViewModel.Organization.Id;
                            orgFactor.factorId = factors[i - 1].Id;
                            _context.OrganizationFactors.Add(orgFactor);
                        }
                    }


                }



                _context.SaveChanges();



                //WorkTime 

                WorkTime worktime = null;
              


                for (int i = 1; i <= 7; i++)
                {

                    worktime = new WorkTime();
                    worktime.Day = Request.Form["Day_" + i.ToString()];
                    //  Console.WriteLine(Request.Form["Day_" + i.ToString()]);
                    worktime.From = Convert.ToDateTime(Request.Form["From_" + i.ToString()]);
                    worktime.To = Convert.ToDateTime(Request.Form["To_" + i.ToString()]);

                    if (worktime.From.Year == 0001 && worktime.To.Year == 0001)
                    {
                        holidays.Add(worktime.Day);
                        continue;
                    }

                    worktime.OrganizationId = organizationViewModel.Organization.Id;
                    _context.WorkTimes.Add(worktime);
                    NewWorkTimes.Add(worktime);
                    _context.SaveChanges();




                }

                //  _context.SaveChanges();


            }


            else
            {



                //else
                //{
                var organizationInDb = _context.Organizations.Single(c => c.Id == organizationViewModel.Organization.Id);
                var category = _context.Categories.Find(organizationInDb.categoryId);
                var sector = _context.Sector.Find(category.sectorId);

                ////org info 
                organizationInDb.orgnizationName = organizationViewModel.Organization.orgnizationName;
                organizationInDb.businessEmail = organizationViewModel.Organization.businessEmail;
                organizationInDb.categoryId = organizationViewModel.Organization.categoryId;
                organizationInDb.cityId = organizationViewModel.Organization.cityId;

                organizationInDb.Description = organizationViewModel.Organization.Description;
                organizationInDb.Fax = organizationViewModel.Organization.Fax;
                organizationInDb.ownerFirstName = organizationViewModel.Organization.ownerFirstName;
                organizationInDb.ownerLastName = organizationViewModel.Organization.ownerLastName;
                organizationInDb.PriceRangeId = organizationViewModel.Organization.PriceRangeId;
                organizationInDb.socialLink_1 = organizationViewModel.Organization.socialLink_1;
                organizationInDb.socialLink_2 = organizationViewModel.Organization.socialLink_2;
                organizationInDb.websiteUrl = organizationViewModel.Organization.websiteUrl;
                organizationInDb.categoryId = category.Id;
                organizationInDb.EstablishOrg = organizationViewModel.Organization.EstablishOrg;





                ////user info
                // organizationInDb.userId = organization.userId;

                var user = _context.Users.Single(u => u.Id == organizationInDb.userId);
                user.Email = organizationViewModel.Organization.User.Email;
                user.Password = organizationViewModel.Password;
                user.Username = organizationViewModel.Organization.User.Username;
                if (upload != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Content/img/OrganizationsProfilePics"), upload.FileName);
                    upload.SaveAs(path);
                    user.imageUrl = upload.FileName;
                }


                organizationInDb.userId = user.Id;
                _context.SaveChanges();



                //Worktime Updates 

                WorkTime Newworktime = null;
                var wktimes = _context.WorkTimes.Where(wk => wk.OrganizationId == organizationInDb.Id).ToList();
                List<WorkTime> wktimesUpdated = new List<WorkTime>();


                foreach (var wk in wktimes)
                {
                    _context.WorkTimes.Remove(wk);
                    _context.SaveChanges();


                }
                for (int i = 1; i <= 7; i++)
                {
                    Newworktime = new WorkTime();
                    Newworktime.Day = Request.Form["Day_" + i.ToString()];
                    Newworktime.From = Convert.ToDateTime(Request.Form["From_" + i.ToString()]);
                    Newworktime.To = Convert.ToDateTime(Request.Form["To_" + i.ToString()]);

                    if (Newworktime.From.Year == 0001 && Newworktime.To.Year == 0001)
                    {
                        holidays.Add(Newworktime.Day);
                        continue;
                    }

                    Newworktime.OrganizationId = organizationInDb.Id;
                    _context.WorkTimes.Add(Newworktime);
                    wktimesUpdated.Add(Newworktime);



                }

                _context.SaveChanges();
             
                return RedirectToAction("index", "Organization");

            }


      
            return RedirectToAction("index", "Home");
        }





        //Get sectors List in Json
        public JsonResult GetSectorsList()
        {
            _context.Configuration.ProxyCreationEnabled = false;
            List<Sector> sectorsList = _context.Sector.ToList();
            return Json(sectorsList, JsonRequestBehavior.AllowGet);

        }
        //Get the Cascading Categories List
        public JsonResult GetCategoriesList(int Id)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            List<Category> CategoryList = _context.Categories.Where(x => x.sectorId == Id).ToList();
            return Json(CategoryList, JsonRequestBehavior.AllowGet);

        }
        //Get the Cascading Factors List
        public JsonResult GetFactorsList(int Id)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            List<Factor> FactorList = _context.Factors.Where(x => x.categoryId == Id).ToList();
            return Json(FactorList, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Reviews(int? id)
        {

            var LoggedInuser =new User();
            var userID=new int();
            var usertype=new byte();
            var organizationDb = new Organization();

            if (id == null)
            {
                if (Session["UserId"] != null && Convert.ToInt32(Session["LoginUserTypeId"]) ==3)
                {
                    userID = (int)Session["UserId"];
                    LoggedInuser = _context.Users.Where(u => u.Id == userID).SingleOrDefault();
                    organizationDb = _context.Organizations.Where(org => org.userId == userID)
                        .Include(org => org.User).Include(c => c.OrganizationFactors)
                        .Include(c => c.City).SingleOrDefault();

                }
                else if(Session["orgID"] != null )
                {
                    var orgID = (int)Session["orgID"];
                    organizationDb = _context.Organizations.Where(org => org.Id == orgID)
                        .Include(org => org.User).Include(c => c.OrganizationFactors)
                        .Include(c => c.City).SingleOrDefault();
                }
                else
                {
                    return RedirectToAction("Index", "Home");

                }
            }
            else
            {
                if (Session["UserId"] != null)
                {

                    Session["orgID"] = id;
                    Session.Timeout = 120;
                    var org = _context.Organizations.SingleOrDefault(o => o.Id == id);
                    var UserLoggedIn = _context.Users.SingleOrDefault(ur => ur.Id == org.userId);
                    Session["LoggedInUser"] = UserLoggedIn;
                    organizationDb = _context.Organizations.Where(o => o.Id == id)
                        .Include(o => o.User).Include(c => c.OrganizationFactors)
                        .Include(c => c.City).SingleOrDefault();

                }
                else
                {
                    Session["orgID"] = id;
                    Session.Timeout = 120;
                    var org = _context.Organizations.SingleOrDefault(o => o.Id == id);
                    var UserLoggedIn = _context.Users.SingleOrDefault(ur => ur.Id == org.userId);
                    Session["LoggedInUser"] = UserLoggedIn;
                    organizationDb = _context.Organizations.Where(o => o.Id == id)
                        .Include(o => o.User).Include(c => c.OrganizationFactors)
                        .Include(c => c.City).SingleOrDefault();
                }
            }  

            
            
            
           


            var worktimes = _context.WorkTimes.Where(wk => wk.OrganizationId == organizationDb.Id).ToList();
            List<string> DaysOfWeek = new List<string> {
                "Sunday",
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday"

            };
            List<string> holidays = new List<string>();

            var i = 1;
            foreach (var wk in worktimes)
            {

                if (DaysOfWeek.Contains(wk.Day))
                {
                    DaysOfWeek.Remove(wk.Day);
                    i++;

                }


            }
            foreach (var x in DaysOfWeek)
            {
                holidays.Add(x);
            }




            ViewData["Worktimes"] = worktimes;
            ViewData["holidays"] = holidays;



            var organizationfactors = _context.OrganizationFactors.Include(c => c.Factor).Where(c => c.organizationId == organizationDb.Id).ToList();
            ViewBag.organizationfactors = _context.OrganizationFactors.Include(c => c.Factor).Where(c => c.organizationId == organizationDb.Id).Count();


            var user = _context.Users.Find(organizationDb.userId);

            var phone = _context.Phones.Where(c => c.userId == user.Id).ToList();


            // var phone = _context.Phones.Find(user.Id).phoneNumber;

            //Getting Org Reviewers
            var reviews = _context.Reviews.Where(c => c.organizationId == organizationDb.Id).ToList();
            ViewBag.Count_reviews = _context.Reviews.Include(c => c.Client).Where(c => c.organizationId == organizationDb.Id).Count();



            List<Client> ClientsReviews = new List<Client>();
            List<ReviewFactors> reviewFactorsInDb = new List<ReviewFactors>();
            var ClientReviewsNumber = new List<KeyValuePair<int, int>>();


          

            foreach (var review in reviews)
            {
                var Reviewsclients = _context.Clients.Include(c => c.City).Include(c => c.User).Where(c => c.Id == review.clientId).ToList();
                var reviewFactors = _context.ReviewFactors.Where(rev => rev.reviewId==review.Id).ToList();


                foreach (var client in Reviewsclients)
                {
                    ClientsReviews.Add(client);
                    var countReviews = _context.Reviews.Where(c=> c.clientId == client.Id).Count();
                    ClientReviewsNumber.Insert(0, new KeyValuePair<int, int>(client.Id,countReviews));

                }

                foreach (var rf in reviewFactors)
                {
                    reviewFactorsInDb.Add(rf);

                }





            }


           

            //Session["ClientReviewsView"] = ClientsReviews;

            foreach (var ph in phone)
            {
                ViewBag.phoneReview = ph.phoneNumber;
            }



            // ViewBag.Reports= new SelectList(_context.ReportTypes, "Id", "Name");
           // ViewBag.Reports = new SelectList(_context.ReportTypes, "Id", "Name");
            var viewmodel = new OrganizationFactorViewModel()
            {

                Organization = organizationDb,
                feedback = "",
                OrganizationFactors = organizationfactors,
                clients = ClientsReviews,
                ReviewFactors = reviewFactorsInDb,
                Reviews = reviews,
                ReportTypes=_context.ReportTypes.ToList(),
                ClientReviewsNumber= ClientReviewsNumber
            

            };
            return View("Reviews", viewmodel);
            //return View("Reviews", viewmodel);
        }
        public ActionResult editPost(int Id)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                var orgid = (int)Session["UserId"];
                var Org = _context.Organizations.SingleOrDefault(O => O.userId == orgid);
                var post = _context.Posts.SingleOrDefault(c => c.Id == Id);
                if (Org.Id == post.organizationId)
                {
                    var postImgs = _context.PostImages.Where(i => i.postId == post.Id).ToList();
                    var postImagesVM = new PostImgs
                    {
                        post = post,
                        PostImages = postImgs
                    };
                    return PartialView("_EditPostPartial", postImagesVM);
                }

                else
                {
                    Session["UserId"] = null;
                    Session["LoginUserTypeId"] = null;
                    return RedirectToAction("Index", "Home");
                }
            }


        }
        public ActionResult UpdatePost(Post post, IEnumerable<HttpPostedFileBase> upload)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var orgid = (int)Session["UserId"];
                var Org = _context.Organizations.SingleOrDefault(O => O.userId == orgid);
                var Post = _context.Posts.SingleOrDefault(P=>P.Id == post.Id);

                if (Org.Id == Post.organizationId)
                {
                    //var Post = _context.Posts.SingleOrDefault(c => c.Id == post.Id);
                    if (Post != null)
                    {

                        Post.Content = post.Content;

                        foreach (var file in upload)
                        {

                            if (file == null)
                                continue;
                            else
                            {
                                string path = Path.Combine(Server.MapPath("~/Content/img/Posts"), file.FileName);
                                file.SaveAs(path);


                                PostImage postimage = new PostImage();
                                postimage.postId = post.Id;
                                postimage.Path = file.FileName;
                                _context.PostImages.Add(postimage);

                            }

                        }
                        _context.SaveChanges();



                    }

                    return RedirectToAction("Index", "organization");
                }

                else
                {
                    Session["UserId"] = null;
                    Session["LoginUserTypeId"] = null;
                    return RedirectToAction("Index", "Home");

                }
            }

        }
        public ActionResult promotePost()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var orgid = (int)Session["UserId"];
                var UserLoggedIn = _context.Users.SingleOrDefault(ur => ur.Id == orgid);

                var organization = _context.Organizations.SingleOrDefault(O => O.userId == orgid);
                var posts = _context.Posts.Where(P => P.organizationId == organization.Id);
                var promotions = _context.Promotions.ToList();
                var promotionViewers = _context.PromotionViewers.ToList();
                var PostImages = _context.PostImages.ToList();

                var VM = new OrganizationPromotions
                {
                    organization = organization,
                    posts = posts,
                    promotions = promotions,
                    PromotionViewer = promotionViewers,
                    UserLoggedIn = UserLoggedIn,
                    PostImages = PostImages
                };
                return View("PromotedPosts", VM);
            }
        }
        public ActionResult followers()
        {
            List<Subscriber> subcribers = null;
            if (Session["UserId"] != null && Convert.ToInt32(Session["LoginUserTypeId"]) == 3)
            {
                var user_id = (int)Session["UserId"];
                var User = _context.Users.SingleOrDefault(u => u.Id == user_id);
                if (User.UserTypeId == 3)
                {
                    var org = _context.Organizations.Where(c => c.userId == User.Id).Include(c => c.User).SingleOrDefault();
                    subcribers = _context.Subscribers
                        .Where(c => c.organizationId == org.Id)
                        .Include(c => c.Client.User)
                        .Include(c => c.Client.City)
                        .ToList();

                }
                else
                {
                    var org_id = (int)Session["orgID"];
                    var org = _context.Organizations.Where(c => c.Id == org_id).Include(c => c.User).SingleOrDefault();
                    subcribers = _context.Subscribers
                        .Where(c => c.organizationId == org.Id)
                        .Include(c => c.Client.User)
                        .Include(c => c.Client.City)
                        .ToList();

                }
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

            return View("Followers", subcribers);
        }
        
      /*  [HttpPost]
        public ActionResult Report_org(OrganizationFactorViewModel ofvm)
        {
            
                var reporterId = 3;
                var org = _context.Organizations.SingleOrDefault(c => c.Id==ofvm.Organization.Id);

                 var reportedId = org.userId;
            

                Report report = new Report();
                report.Content = ofvm.orgContent;
                report.reporterId = reporterId;
                report.reportedId = reportedId;
                report.reportTypeId = 1;
                var dateAndTime = DateTime.Now;
                var date = dateAndTime.Date;
                report.Date = date;
                _context.Reports.Add(report);
                _context.SaveChanges();

                return RedirectToAction("Reviews", "Organization", new { id = org.Id });

            
        }
        */
        [HttpPost]
        public ActionResult Report_org(OrganizationFactorViewModel ofvm)
        {
            if (Session["UserId"] == null || Convert.ToInt32(Session["LoginUserTypeId"]) != 2)
            {
                return RedirectToAction("Index", "Home");
            }
            // var reporterId = 3;
            var org = _context.Organizations.Include(c => c.User).SingleOrDefault(c => c.Id == ofvm.Organization.Id);
            var reporterId = (int)Session["UserId"];
            var reportedId = org.userId;


            Report report = new Report();
            report.Content = ofvm.orgContent;
            report.reporterId = reporterId;
            report.reportedId = reportedId;
            report.reportKindId = 1;
            report.reportTypeId = 1;
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            report.Date = date;
            _context.Reports.Add(report);
            _context.SaveChanges();

            return RedirectToAction("Reviews", "Organization", new { id = org.Id });


        }



        [HttpPost]
        public ActionResult Report_rev(OrganizationFactorViewModel ofvm)
        {
            var reporterId = 3;
            var org = _context.Organizations.SingleOrDefault(c => c.Id == ofvm.Organization.Id);

            var reportedId = org.userId;
            Report report = new Report();
            report.Content = ofvm.orgContent;
            report.reporterId = reporterId;
            report.reportedId = reportedId;
            report.reportTypeId = 2;
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.Date;
            report.Date = date;
            _context.Reports.Add(report);
            _context.SaveChanges();


            return RedirectToAction("Reviews", "Organization",new { id = org.Id });
        }



        //Save Report 

        //Save Report 
        [HttpPost]
        public ActionResult Report(OrganizationFactorViewModel ofvm)
        {

            Report report = new Report();
            report.reporterId = Convert.ToInt32(Request.Form["reporterID"]);
            report.reportedId = Convert.ToInt32(Request.Form["reportedID"]);

            var reportedClient = _context.Reports.Where(x => x.reportedId == report.reportedId).FirstOrDefault();
            if (reportedClient == null)
            {


                report.reportKindId = 2;
                report.Date = DateTime.Now;
                report.Content = ofvm.report.Content;
                report.reportTypeId = ofvm.report.reportTypeId;
                _context.Reports.Add(report);

            }

            else
            {

                reportedClient.Content = ofvm.report.Content;
                reportedClient.reportTypeId = ofvm.report.reportTypeId;
                reportedClient.Date = DateTime.Now;


            }

            _context.SaveChanges();

            return RedirectToAction("Reviews", "Organization");


        }


        //Create New Post

        public ActionResult CreatePost(Post post, IEnumerable<HttpPostedFileBase> upload)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                post.Date = DateTime.Now;
                var orgID = Convert.ToInt32(Request.Form["orgID"]);
                post.organizationId = orgID;
                _context.Posts.Add(post);
                _context.SaveChanges();


                foreach (var file in upload)
                {

                    if (file == null)
                        continue;
                    else
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/img/Posts"), file.FileName);
                        file.SaveAs(path);


                        PostImage postimage = new PostImage();
                        postimage.postId = post.Id;
                        postimage.Path = file.FileName;
                        _context.PostImages.Add(postimage);

                    }

                }

                _context.SaveChanges();



                return RedirectToAction("Index", "organization");
            }
        }

        //Search Comaprison 



        public ActionResult Search()
        {
            if (Session["UserId"] != null)
            {

                var SessionID = (int)Session["UserId"];
                var User = _context.Users.Where(x => x.Id == SessionID).FirstOrDefault();

                if (User.UserTypeId == 2)
                {
                    if (Session["orgID"] != null)

                        return View();

                    else
                        return RedirectToAction("Index", "User");
                }
                else if (User.UserTypeId == 3)
                {
                    return RedirectToAction("Index", "Organization");

                }

                else
                    return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }


        public JsonResult Organizations()
        {

            if (Session["UserId"] != null)
            {

                var SessionUser = (int)Session["UserId"];
                var user = _context.Users.Where(x => x.Id == SessionUser).FirstOrDefault();
                if (user.UserTypeId == 1)
                {
                    _context.Configuration.ProxyCreationEnabled = false;
                    List<Organization> organiations = _context.Organizations.Include(c => c.User).ToList();
                    return Json(organiations, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(JsonRequestBehavior.DenyGet);
                }
            }

            else
                return Json(JsonRequestBehavior.DenyGet);
        }
        [HttpPost]
        public JsonResult Search(string searchName)
        {
            //if (searchName == "")
            //    return RedirectToAction("Search");



            _context.Configuration.ProxyCreationEnabled = false;
            List<Organization> result = _context.Organizations.Include(User => User.User).Where(a => a.orgnizationName.Contains(searchName)).ToList();

            //ViewBag.Results = result;


            //return View("Search");

            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public ActionResult getOrganization(int id)
        {

            if (Session["UserId"] != null)
            {
                var SessionID = (int)Session["UserId"];
                var User = _context.Users.Where(x => x.Id == SessionID).FirstOrDefault();

                if (User.UserTypeId == 2)
                {

                    if (Session["orgID"] != null)
                    {
                        var org = _context.Organizations
                            .Include(u => u.User)
                            .Include(c => c.Category.Sector)
                            .Include(c => c.City)
                            .Include(c => c.PriceRange).SingleOrDefault(u => u.Id == id);


                        var LoggedInorgID = (int)Session["orgID"];

                        var LoggedInorg = _context.Organizations
                            .Include(u => u.User)
                            .Include(c => c.Category.Sector)
                            .Include(c => c.City)
                            .Include(c => c.PriceRange).SingleOrDefault(u => u.Id == LoggedInorgID);



                        List<Organization> organizations = new List<Organization>();
                        List<int> Reviews = new List<int>();
                        List<int> ReportsInDB = new List<int>();
                        List<int> Followers = new List<int>();
                        List<float> orgRatesInDB = new List<float>();



                        organizations.Add(org);
                        organizations.Add(LoggedInorg);


                        foreach (var organization in organizations)
                        {


                            var reviews = _context.Reviews.Where(c => c.organizationId == organization.Id).Count();
                            Reviews.Add(reviews);

                            var reports = _context.Reports.Where(c => c.reportedId == organization.Id).Count();
                            ReportsInDB.Add(reports);

                            var followers = _context.Subscribers.Where(c => c.organizationId == organization.Id).Count();
                            Followers.Add(followers);

                            var orgRates = (_context.OrganizationFactors
                                .Where(c => c.organizationId == organization.Id).Sum(c => c.factorRate)
                                / _context.OrganizationFactors.Where(c => c.organizationId == organization.Id).Count())*10;

                            orgRatesInDB.Add(orgRates);



                        }


                        CompareViewModel cvm = new CompareViewModel
                        {

                            organizations = organizations,
                            Reviews = Reviews,
                            Reports = ReportsInDB,
                            Followers = Followers,
                            orgRates = orgRatesInDB

                        };

                        return View("SearchCompare", cvm);
                    }

                    else
                    {
                        return RedirectToAction("Index", "User");

                    }
                }
                else if (User.UserTypeId == 3)
                {

                    return RedirectToAction("Index", "Organization");
                }
                else
                {

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {

                return RedirectToAction("Index", "Home");

            }
        }
        //Get Insights 


            public ActionResult getInsights()
        {


            if (Session["userId"] != null)
            {
                //Posts,Likes and Dislikes 

                var orgid = (int)Session["UserId"];

                var User = _context.Users.Where(x => x.Id == orgid).FirstOrDefault();


                if (User.UserTypeId == 3)
                {

                    if (orgid == User.Id)
                    {

                        var orgInDb = _context.Organizations.Where(x => x.userId == orgid).FirstOrDefault();
                        var Posts = _context.Posts.Where(x => x.organizationId == orgInDb.Id).ToList();


                        //Lists 
                        var DateList = new List<string>();
                        var LikesList = new List<int>();
                        var DislikesList = new List<int>();


                        foreach (var post in Posts)
                        {
                            var Date = post.Date.ToString("dd MMMM yyyy");
                            var Likes = _context.PostReactions.Where(x => x.postId == post.Id && x.Reaction == 1).Count();
                            var Dislikes = _context.PostReactions.Where(x => x.postId == post.Id && x.Reaction == 0).Count();

                            DateList.Add(Date);
                            LikesList.Add(Likes);
                            DislikesList.Add(Dislikes);


                        }



                        ViewBag.DateList = DateList;
                        ViewBag.LikesList = LikesList;
                        ViewBag.DislikesList = DislikesList;


                        //////////////////////////////////////////////////////////////////////////////
                        //Numbers of Users Each Month 

                        List<int> ClientsPerMonth = new List<int>();
                        List<String> MonthsInDB = new List<String>();

                        List<string> AllMonths = new List<string>();

                        List<int> ClientMales = new List<int>();
                        List<int> ClientFemales = new List<int>();


                        List<int> ClientMalesDiverse = new List<int>();
                        List<int> ClientFemalesDiverse = new List<int>();
                        //var UsersInDb = _context.Users.Where(x => x.UserTypeId==2).ToList();




                        //Getting 12 months of the year

                        DateTime now = DateTime.Now;
                        for (int i = 0; i < 12; i++)
                        {
                            AllMonths.Add(now.Month.ToString());
                            now = now.AddMonths(1);

                        }


                        var monthsTuple = new List<Tuple<string, int, int, int>>();

                        //var subs = _context.Subscribers.ToList();
                        //foreach (var sub in subs)
                        //{
                        //    var x = sub.Date.Month.ToString();
                        //}


                        foreach (var month in AllMonths)
                        {
                            var monthInt = Convert.ToInt32(month);
                            //var Month = month.ToString();
                            var Clients = _context.Subscribers.Where(x => x.organizationId == orgInDb.Id && x.Date.Month == monthInt).Count();
                            var ClientsList = _context.Subscribers.Where(x => x.organizationId == orgInDb.Id && x.Date.Month == monthInt).ToList();
                            int MaleCounter = 0;
                            int FemaleCounter = 0;

                            foreach (var client in ClientsList)
                            {

                                var Client = _context.Clients.Where(x => x.Id == client.clientId).FirstOrDefault();
                                if (Client.Gender == "Male")
                                {
                                    MaleCounter++;
                                    ClientMales.Add(MaleCounter);
                                }

                                else if (Client.Gender == "Female")
                                {
                                    FemaleCounter++;
                                    ClientFemales.Add(FemaleCounter);
                                }

                                //var clientFemale = _context.Clients.Where(x => x.Gender == "Female").Count();
                                //ClientFemales.Add(clientFemale);



                            }
                            monthsTuple.Add(new Tuple<string, int, int, int>(month, Clients, MaleCounter, FemaleCounter));



                            // ClientsPerMonth.Add(Clients);
                            //MonthsInDB.Add(month);
                            //YearsInDB.Add(month);



                        }

                        var NewTupleMonths = new List<Tuple<string, int, int, int>>();

                        foreach (var x in monthsTuple)
                        {
                            if (x.Item1 == "1")
                                NewTupleMonths.Add(new Tuple<string, int, int, int>("January", x.Item2, x.Item3, x.Item4));
                            else if (x.Item1 == "2")
                                NewTupleMonths.Add(new Tuple<string, int, int, int>("Febraury", x.Item2, x.Item3, x.Item4));
                            else if (x.Item1 == "3")
                                NewTupleMonths.Add(new Tuple<string, int, int, int>("March", x.Item2, x.Item3, x.Item4));
                            else if (x.Item1 == "4")
                                NewTupleMonths.Add(new Tuple<string, int, int, int>("April", x.Item2, x.Item3, x.Item4));
                            else if (x.Item1 == "5")
                                NewTupleMonths.Add(new Tuple<string, int, int, int>("May", x.Item2, x.Item3, x.Item4));
                            else if (x.Item1 == "6")
                                NewTupleMonths.Add(new Tuple<string, int, int, int>("June", x.Item2, x.Item3, x.Item4));
                            else if (x.Item1 == "7")
                                NewTupleMonths.Add(new Tuple<string, int, int, int>("July", x.Item2, x.Item3, x.Item4));
                            else if (x.Item1 == "8")
                                NewTupleMonths.Add(new Tuple<string, int, int, int>("August", x.Item2, x.Item3, x.Item4));
                            else if (x.Item1 == "9")
                                NewTupleMonths.Add(new Tuple<string, int, int, int>("September", x.Item2, x.Item3, x.Item4));
                            else if (x.Item1 == "10")
                                NewTupleMonths.Add(new Tuple<string, int, int, int>("October", x.Item2, x.Item3, x.Item4));
                            else if (x.Item1 == "11")
                                NewTupleMonths.Add(new Tuple<string, int, int, int>("November", x.Item2, x.Item3, x.Item4));
                            else if (x.Item1 == "12")
                                NewTupleMonths.Add(new Tuple<string, int, int, int>("December", x.Item2, x.Item3, x.Item4));


                        }


                        foreach (var data in NewTupleMonths)
                        {
                            ClientsPerMonth.Add(data.Item2);
                            MonthsInDB.Add(data.Item1);
                            ClientMalesDiverse.Add(data.Item3);
                            ClientFemalesDiverse.Add(data.Item4);



                        }


                        ViewBag.ClientsPerMonth = ClientsPerMonth;
                        ViewBag.MonthsInDB = MonthsInDB;
                        ViewBag.ClientMalesDiverse = ClientMalesDiverse;
                        ViewBag.ClientFemalesDiverse = ClientFemalesDiverse;

                        /////////////////////////////////////////////////////////////////////////


                        //Clients Number in Each City 

                        var Cities = _context.Cities.ToList();

                        var SubsCount = _context.Subscribers.Where(x => x.organizationId == orgInDb.Id).Count();
                        var SubsInDb = _context.Subscribers.Where(x => x.organizationId == orgInDb.Id).ToList();



                        List<int> MalesCity = new List<int>();
                        List<int> FemalesCity = new List<int>();
                        List<string> CityNames = new List<string>();
                        List<int> CityCounter = new List<int>();

                        var tupleCity = new List<Tuple<string, int, int, int>>();


                        foreach (var city in Cities)
                        {


                            var MaleCityCounter = 0;
                            var FemaleCityCounter = 0;
                            int CitiesCounter = 0;

                            foreach (var sub in SubsInDb)
                            {
                                var client = _context.Clients.Where(x => x.cityId == city.Id && x.Id == sub.clientId).FirstOrDefault();
                                //  var client = _context.Clients.Include(x => x.City).Where(x => x.Id == sub.clientId).FirstOrDefault();
                                //  var ClientCity = client.City.Name;

                                if (client != null)
                                {
                                    CitiesCounter++;
                                    //CityCounter.Add(CitiesCounter);

                                    if (client.Gender == "Male")
                                    {
                                        MaleCityCounter++;
                                        //  MalesCity.Add(MaleCityCounter);
                                    }

                                    else if (client.Gender == "Female")
                                    {
                                        FemaleCityCounter++;
                                        // FemalesCity.Add(FemaleCityCounter);
                                    }

                                }




                            }

                            tupleCity.Add(new Tuple<string, int, int, int>(city.Name, CitiesCounter, MaleCityCounter, FemaleCityCounter));


                        }


                        foreach (var t in tupleCity)
                        {

                            CityNames.Add(t.Item1);
                            CityCounter.Add(t.Item2);
                            MalesCity.Add(t.Item3);
                            FemalesCity.Add(t.Item4);





                        }

                        ViewBag.CityNames = CityNames;
                        ViewBag.CityCounter = CityCounter;
                        ViewBag.MalesCity = MalesCity;
                        ViewBag.FemalesCity = FemalesCity;
                        /////////////////////////////////////////////////////////////////////////////

                        //Ages of Followers 

                        //var LessThan20 = new List<int>();
                        //var Between20And40 = new List<int>();
                        //var Morethan40 = new List<int>();
                        //var AgesRanges = new List<string>() {"-18","18-35","35+"};
                        //var TupleAges = new List<Tuple<string,int,int,int>>();



                        ////Counters

                        var Less18 = 0;
                        var Between18_35 = 0;
                        var More35 = 0;


                        var MalesCounter18 = 0;
                        var FemalesCounter18 = 0;


                        var MalesCounter18_35 = 0;
                        var FemalesCounter18_35 = 0;

                        var MalesCounter35 = 0;
                        var FemalesCounter35 = 0;

                        //Lists 
                        var Ages_Of_Followers_Labels = new List<string>();
                        var MalesAgesList = new List<int>();
                        var FemalesAgesList = new List<int>();


                        foreach (var sub in SubsInDb)
                        {

                            var client = _context.Clients.Where(x => x.Id == sub.clientId).FirstOrDefault();

                            if (client != null)
                            {
                                if (client.Age <= 18)
                                {
                                    Less18++;
                                    if (client.Gender == "Male")
                                    {
                                        MalesCounter18++;

                                    }
                                    else if (client.Gender == "Female")
                                    {
                                        FemalesCounter18++;
                                    }

                                }
                                else if (client.Age > 18 && client.Age < 35)
                                {
                                    Between18_35++;
                                    if (client.Gender == "Male")
                                    {
                                        MalesCounter18_35++;

                                    }
                                    else if (client.Gender == "Female")
                                    {
                                        FemalesCounter18_35++;
                                    }

                                }


                                else if (client.Age > 35)
                                {
                                    More35++;
                                    if (client.Gender == "Male")
                                    {
                                        MalesCounter35++;

                                    }
                                    else if (client.Gender == "Female")
                                    {
                                        FemalesCounter35++;
                                    }

                                }

                            }






                        }
                        int TotalPercentage = Less18 + Between18_35 + More35;
                        int TotalManPercent = MalesCounter18 + MalesCounter18_35 + MalesCounter35;
                        int TotalWomenPercent = FemalesCounter18 + FemalesCounter18_35 + FemalesCounter35;
                        var MalesPercent = "";
                        var FemalesPercent = "";
                        if (TotalPercentage != 0)
                        {


                            MalesPercent = (Decimal.Divide(TotalManPercent, TotalPercentage) * 100).ToString("#.##");
                            FemalesPercent = (Decimal.Divide(TotalWomenPercent, TotalPercentage) * 100).ToString("#.##");

                        }

                        ViewBag.MalesPercent = MalesPercent;
                        ViewBag.FemalesPercent = FemalesPercent;
                        //Create Lists 

                        var TotalGendersList = new List<int>();
                        TotalGendersList.Add(MalesCounter18);
                        TotalGendersList.Add(FemalesCounter18);
                        TotalGendersList.Add(MalesCounter18_35);
                        TotalGendersList.Add(FemalesCounter18_35);
                        TotalGendersList.Add(MalesCounter35);
                        TotalGendersList.Add(FemalesCounter35);


                        //Create a tuple 

                        var FollowersAgesRanges = new List<Tuple<string, int, int>>();
                        FollowersAgesRanges.Add(new Tuple<string, int, int>("-18", TotalGendersList[0], TotalGendersList[1]));
                        FollowersAgesRanges.Add(new Tuple<string, int, int>("18-35", TotalGendersList[2], TotalGendersList[3]));
                        FollowersAgesRanges.Add(new Tuple<string, int, int>("35+", TotalGendersList[4], TotalGendersList[5]));



                        //Create Lists 
                        var LabelsFollowers = new List<string>();
                        var MalesFollowersList = new List<int>();
                        var FemalesFollowersList = new List<int>();

                        foreach (var item in FollowersAgesRanges)
                        {
                            LabelsFollowers.Add(item.Item1);
                            MalesFollowersList.Add(item.Item2);
                            FemalesFollowersList.Add(item.Item3);

                        }


                        ViewBag.LabelsFollowers = LabelsFollowers;
                        ViewBag.MalesFollowersList = MalesFollowersList;
                        ViewBag.FemalesFollowersList = FemalesFollowersList;



                        //Reviews Number on Organization  SubsInDb


                        //Most Interactive User 
                        //  var SubsInDb = _context.Subscribers.Where(x => x.organizationId == orgInDb.Id).ToList();

                        var PostsOforg = _context.Posts.Where(x => x.organizationId == orgInDb.Id).ToList();
                        var ReactionsTuple = new List<Tuple<int, int>>();
                        var postReactionsCount = 0;

                        if (SubsInDb.Count != 0)
                        {
                            foreach (var sub in SubsInDb)
                            {
                                foreach (var post in PostsOforg)
                                {
                                    var PostReactions = _context.PostReactions.Where(x => x.postId == post.Id).ToList();

                                    foreach (var pr in PostReactions)
                                    {

                                        // var client = _context.Clients.Where(x => x.Id == sub.clientId).FirstOrDefault();
                                        postReactionsCount = _context.PostReactions.Where(x => x.clientId == sub.clientId).Count();




                                    }




                                }

                                ReactionsTuple.Add(new Tuple<int, int>(sub.clientId, postReactionsCount));

                            }


                        }
                        var SortedTuple = ReactionsTuple.OrderByDescending(x => x.Item2);

                        var topUser = SortedTuple.Take(1);
                        var TopSub = new Client();
                        var TopUserReactions = 0;

                        foreach (var user in topUser)
                        {
                            TopSub = _context.Clients.Where(x => x.Id == user.Item1).Include(x => x.User).Include(x => x.City).FirstOrDefault();


                            TopUserReactions = user.Item2;
                        }

                        ViewBag.TopClient = TopSub;
                        ViewBag.ReactionsNumber = TopUserReactions;

                        ///////////////////////////////////////////////////////////////////


                        //Organization Reviews 
                        var ReviewsOrg = _context.Reviews.Where(x => x.organizationId == orgInDb.Id).ToList();


                        //Reviews Lists
                        var Labels = new List<string>();
                        var Ages = new List<int>();
                        var More = new List<int>();
                        var ClientReviews = new List<Client>();

                        var TotalReviewsList = new List<int>();
                        var TotalAgesList = new List<int>();


                        //Counters Ages 
                        var LessCounter = 0;
                        var BetweenCounter = 0;
                        var MoreCounter = 0;


                        //Counters Reviews 
                        var LessReviewCounter = 0;
                        var BetweenReviewCounter = 0;
                        var MoreReviewCounter = 0;

                        foreach (var client in SubsInDb)
                        {
                            foreach (var review in ReviewsOrg)
                            {
                                var ClientsReviews = _context.Clients.Where(x => x.Id == client.clientId && x.Id == review.clientId).FirstOrDefault();
                                if (ClientsReviews != null)
                                {
                                    ClientReviews.Add(ClientsReviews);
                                }

                            }
                        }

                        foreach (var r in ReviewsOrg)
                        {
                            foreach (var x in ClientReviews)
                            {
                                if (x.Age <= 18 && x.Id == r.clientId)
                                {
                                    LessCounter++;
                                    LessReviewCounter++;

                                    //Less.Add(LessCounter);
                                }
                                else if (x.Age > 18 && x.Age < 35 && x.Id == r.clientId)
                                {
                                    BetweenCounter++;
                                    BetweenReviewCounter++;
                                    //Between.Add(BetweenCounter);

                                }
                                else if (x.Age >= 35 && x.Id == r.clientId)
                                {
                                    MoreCounter++;
                                    MoreReviewCounter++;
                                    //  More.Add(MoreCounter);

                                }

                            }


                        }


                        TotalAgesList.Add(LessCounter);
                        TotalAgesList.Add(BetweenCounter);
                        TotalAgesList.Add(MoreCounter);

                        TotalReviewsList.Add(LessReviewCounter);
                        TotalReviewsList.Add(BetweenReviewCounter);
                        TotalReviewsList.Add(MoreReviewCounter);

                        var ReviewsTuple = new List<Tuple<int, int>>();

                        ReviewsTuple.Add(new Tuple<int, int>(TotalAgesList[0], TotalReviewsList[0]));
                        ReviewsTuple.Add(new Tuple<int, int>(TotalAgesList[1], TotalReviewsList[1]));
                        ReviewsTuple.Add(new Tuple<int, int>(TotalAgesList[2], TotalReviewsList[2]));

                        var FinalReviewsTuple = new List<Tuple<string, int, int>>();

                        FinalReviewsTuple.Add(new Tuple<string, int, int>("-18", TotalAgesList[0], TotalReviewsList[0]));
                        FinalReviewsTuple.Add(new Tuple<string, int, int>("18-35", TotalAgesList[1], TotalReviewsList[1]));
                        FinalReviewsTuple.Add(new Tuple<string, int, int>("35+", TotalAgesList[2], TotalReviewsList[2]));


                        foreach (var item in FinalReviewsTuple)
                        {
                            Labels.Add(item.Item1);
                            Ages.Add(item.Item2);
                            More.Add(item.Item3);


                        }
                        ViewBag.Labels = Labels;
                        ViewBag.Ages = Ages;
                        ViewBag.More = More;



                        //////////////////////////////////////////////////////////////////

                        //Reviews Every Year 

                        var ClientsReviewsyears = _context.Reviews
                            .Where(x => x.Client.User.UserTypeId == 2)
                            .Include(x => x.Client.User).Select(x => x.Date.Year).Distinct().ToList();

                        var ReviewsInYear = new List<Tuple<int, int>>();

                        foreach (var year in ClientsReviewsyears)
                        {
                            var ReviewsYear = 0;
                            foreach (var review in ReviewsOrg)
                            {
                                if (review.Date.Year == year)
                                {
                                    ReviewsYear++;

                                }


                            }
                            ReviewsInYear.Add(new Tuple<int, int>(year, ReviewsYear));


                        }


                        //Lists 
                        var ReviewsYears = new List<int>();
                        var TotalReviewsPerYear = new List<int>();
                        foreach (var item in ReviewsInYear)
                        {
                            ReviewsYears.Add(item.Item1);
                            TotalReviewsPerYear.Add(item.Item2);

                        }

                        ViewBag.ReviewsYears = ReviewsYears;
                        ViewBag.TotalReviewsPerYear = TotalReviewsPerYear;





                        //Total Reviews Per Months 


                        var ReviewsPerMonthTuple = new List<Tuple<string, int>>();
                        foreach (var month in AllMonths)
                        {
                            var monthInt = Convert.ToInt32(month);

                            var ReviewsPerMonthCounter = 0;
                            //var Month = month.ToString();
                            foreach (var review in ReviewsOrg)
                            {
                                if (review.Date.Month == monthInt)
                                {
                                    ReviewsPerMonthCounter++;

                                }

                            }

                            ReviewsPerMonthTuple.Add(new Tuple<string, int>(month, ReviewsPerMonthCounter));

                        }


                        var ReviewsPerMonthTupleInDetail = new List<Tuple<string, int>>();

                        foreach (var x in ReviewsPerMonthTuple)
                        {
                            if (x.Item1 == "1")
                                ReviewsPerMonthTupleInDetail.Add(new Tuple<string, int>("January", x.Item2));
                            else if (x.Item1 == "2")
                                ReviewsPerMonthTupleInDetail.Add(new Tuple<string, int>("Febraury", x.Item2));
                            else if (x.Item1 == "3")
                                ReviewsPerMonthTupleInDetail.Add(new Tuple<string, int>("March", x.Item2));
                            else if (x.Item1 == "4")
                                ReviewsPerMonthTupleInDetail.Add(new Tuple<string, int>("April", x.Item2));
                            else if (x.Item1 == "5")
                                ReviewsPerMonthTupleInDetail.Add(new Tuple<string, int>("May", x.Item2));
                            else if (x.Item1 == "6")
                                ReviewsPerMonthTupleInDetail.Add(new Tuple<string, int>("June", x.Item2));
                            else if (x.Item1 == "7")
                                ReviewsPerMonthTupleInDetail.Add(new Tuple<string, int>("July", x.Item2));
                            else if (x.Item1 == "8")
                                ReviewsPerMonthTupleInDetail.Add(new Tuple<string, int>("August", x.Item2));
                            else if (x.Item1 == "9")
                                ReviewsPerMonthTupleInDetail.Add(new Tuple<string, int>("September", x.Item2));
                            else if (x.Item1 == "10")
                                ReviewsPerMonthTupleInDetail.Add(new Tuple<string, int>("October", x.Item2));
                            else if (x.Item1 == "11")
                                ReviewsPerMonthTupleInDetail.Add(new Tuple<string, int>("November", x.Item2));
                            else if (x.Item1 == "12")
                                ReviewsPerMonthTupleInDetail.Add(new Tuple<string, int>("December", x.Item2));


                        }


                        //Create Lists 
                        var MonthsReviews = new List<string>();
                        var TotalReviewsInMonths = new List<int>();


                        foreach (var item in ReviewsPerMonthTupleInDetail)
                        {
                            MonthsReviews.Add(item.Item1);
                            TotalReviewsInMonths.Add(item.Item2);

                        }

                        ViewBag.MonthsReviews = MonthsReviews;
                        ViewBag.TotalReviewsInMonths = TotalReviewsInMonths;




                        //useful Reviews every year   (8/6/2019)

                        var usefulyears = _context.Reviews.Where(x => x.numberOfUseful > 0)
                            .Select(x => x.Date.Year)
                            .Distinct().ToList();


                        var UsefulClients = _context.Reviews.Where(x => x.numberOfUseful > 0).Include(x => x.Client).ToList();
                        var usefulYears = new List<Tuple<int, int, int>>();

                        foreach (var year in usefulyears)
                        {
                            var UsefulMales = 0;
                            var UsefulFemales = 0;

                            foreach (var client in UsefulClients)
                            {
                                if (client.Client.Gender == "Male" && client.Date.Year == year)
                                {
                                    UsefulMales++;
                                }
                                else if (client.Client.Gender == "Female" && client.Date.Year == year)
                                {
                                    UsefulFemales++;

                                }


                            }
                            usefulYears.Add(new Tuple<int, int, int>(year, UsefulMales, UsefulFemales));

                        }


                        //lists 

                        var usefulyearsList = new List<int>();
                        var usefulMalesList = new List<int>();
                        var usefulFemalesList = new List<int>();

                        foreach (var useful in usefulYears)
                        {
                            usefulyearsList.Add(useful.Item1);
                            usefulMalesList.Add(useful.Item2);
                            usefulFemalesList.Add(useful.Item3);

                        }


                        ViewBag.usefulyearsList = usefulyearsList;
                        ViewBag.usefulMalesList = usefulMalesList;
                        ViewBag.usefulFemalesList = usefulFemalesList;
                        //////////////////////////////////////////////////////////////////////

                        //useful Reviews in MOnths

                        var UsefulMonthsTuple = new List<Tuple<string, int, int>>();
                        foreach (var month in AllMonths)
                        {

                            var usefulMales = 0;
                            var usefulFemales = 0;
                            var monthInt = Convert.ToInt32(month);
                            var usefulMonths = _context.Reviews.Where(x => x.numberOfUseful > 0 && x.Date.Month == monthInt)
                          .ToList();

                            foreach (var usefulmonth in usefulMonths)
                            {

                                if (usefulmonth.Client.Gender == "Male")
                                {
                                    usefulMales++;


                                }
                                else if (usefulmonth.Client.Gender == "Female")
                                {
                                    usefulFemales++;

                                }


                            }
                            UsefulMonthsTuple.Add(new Tuple<string, int, int>(month, usefulMales, usefulFemales));


                        }


                        var UsefulNewTupleMonths = new List<Tuple<string, int, int>>();

                        foreach (var x in UsefulMonthsTuple)
                        {
                            if (x.Item1 == "1")
                                UsefulNewTupleMonths.Add(new Tuple<string, int, int>("January", x.Item2, x.Item3));
                            else if (x.Item1 == "2")
                                UsefulNewTupleMonths.Add(new Tuple<string, int, int>("Febraury", x.Item2, x.Item3));
                            else if (x.Item1 == "3")
                                UsefulNewTupleMonths.Add(new Tuple<string, int, int>("March", x.Item2, x.Item3));
                            else if (x.Item1 == "4")
                                UsefulNewTupleMonths.Add(new Tuple<string, int, int>("April", x.Item2, x.Item3));
                            else if (x.Item1 == "5")
                                UsefulNewTupleMonths.Add(new Tuple<string, int, int>("May", x.Item2, x.Item3));
                            else if (x.Item1 == "6")
                                UsefulNewTupleMonths.Add(new Tuple<string, int, int>("June", x.Item2, x.Item3));
                            else if (x.Item1 == "7")
                                UsefulNewTupleMonths.Add(new Tuple<string, int, int>("July", x.Item2, x.Item3));
                            else if (x.Item1 == "8")
                                UsefulNewTupleMonths.Add(new Tuple<string, int, int>("August", x.Item2, x.Item3));
                            else if (x.Item1 == "9")
                                UsefulNewTupleMonths.Add(new Tuple<string, int, int>("September", x.Item2, x.Item3));
                            else if (x.Item1 == "10")
                                UsefulNewTupleMonths.Add(new Tuple<string, int, int>("October", x.Item2, x.Item3));
                            else if (x.Item1 == "11")
                                UsefulNewTupleMonths.Add(new Tuple<string, int, int>("November", x.Item2, x.Item3));
                            else if (x.Item1 == "12")
                                UsefulNewTupleMonths.Add(new Tuple<string, int, int>("December", x.Item2, x.Item3));


                        }

                        //Lists 

                        var usefulMonthsList = new List<string>();
                        var usefulMonthsMales = new List<int>();
                        var usefulMonthsFemales = new List<int>();


                        foreach (var tuple in UsefulNewTupleMonths)
                        {
                            usefulMonthsList.Add(tuple.Item1);
                            usefulMonthsMales.Add(tuple.Item2);
                            usefulMonthsFemales.Add(tuple.Item3);


                        }
                        ViewBag.usefulMonthsList = usefulMonthsList;
                        ViewBag.usefulMonthsMales = usefulMonthsMales;
                        ViewBag.usefulMonthsFemales = usefulMonthsFemales;


                        //Percent of Males and Females useful Reviews
                        var TotalusefulReviews = _context.Reviews.Include(x => x.Client).Where(x => x.numberOfUseful > 0)
                        .ToList();
                        var TotalusefulReviewsCount = _context.Reviews.Include(x => x.Client).Where(x => x.numberOfUseful > 0)
                        .Count();

                        var TotalMalesCounter = 0;
                        var TotalFemalesCounter = 0;

                        foreach (var rev in TotalusefulReviews)
                        {

                            if (rev.Client.Gender == "Male")
                                TotalMalesCounter++;
                            else if (rev.Client.Gender == "Female")
                                TotalFemalesCounter++;


                        }


                        var MalesUsefulPercent = "";
                        var FemalesUsefulPercent = "";
                        if (TotalusefulReviewsCount != 0)
                        {

                            MalesUsefulPercent = (Decimal.Divide(TotalMalesCounter, TotalusefulReviewsCount) * 100).ToString("#.##");
                            FemalesUsefulPercent = (Decimal.Divide(TotalFemalesCounter, TotalusefulReviewsCount) * 100).ToString("#.##");

                        }


                        //Double Vars 

                        var MalesDouble = 0.0;
                        var FemalesDouble = 0.0;

                        Double.TryParse(MalesUsefulPercent, out MalesDouble);
                        Double.TryParse(FemalesUsefulPercent, out FemalesDouble);



                        ViewBag.MalesUsefulPercent = MalesDouble;
                        ViewBag.FemalesUsefulPercent = FemalesDouble;




                        //Number of Reports in years

                        var ReportsYears = _context.Reports.Where(x => x.reportedId == orgInDb.userId).Select(x => x.Date.Year).Distinct().ToList();
                        var Reports = _context.Reports.Where(x => x.reportedId == orgInDb.userId).ToList();
                        var ReportsYearsTuple = new List<Tuple<int, int, int>>();



                        foreach (var report in ReportsYears)
                        {
                            var ReportsMales = 0;
                            var ReportsFemales = 0;


                            var ReportsInYear = _context.Reports.Where(x => x.Date.Year == report && x.reportedId == orgInDb.userId).Include(x => x.reporter).ToList();
                            //var ClientsReports= _context.Users.Where(x=> x.Id==)
                            foreach (var rep in ReportsInYear)
                            {

                                var clients = _context.Clients.Where(x => x.userId == rep.reporterId).ToList();
                                foreach (var client in clients)
                                {
                                    if (client.Gender == "Male")
                                        ReportsMales++;
                                    else if (client.Gender == "Female")
                                        ReportsFemales++;


                                }



                            }
                            ReportsYearsTuple.Add(new Tuple<int, int, int>(report, ReportsMales, ReportsFemales));

                        }


                        //Lists 
                        var ReportsyearsList = new List<int>();
                        var ReportsMalesList = new List<int>();
                        var ReportsFemalesList = new List<int>();


                        foreach (var report in ReportsYearsTuple)
                        {
                            ReportsyearsList.Add(report.Item1);
                            ReportsMalesList.Add(report.Item2);
                            ReportsFemalesList.Add(report.Item3);

                        }


                        ViewBag.ReportsyearsList = ReportsyearsList;
                        ViewBag.ReportsMalesList = ReportsMalesList;
                        ViewBag.ReportsFemalesList = ReportsFemalesList;




                        //Percentage of Males and Femlaes Reports 

                        var WantedorganReports = _context.Reports.Where(x => x.reportedId == orgInDb.userId).ToList();
                        var WantedorganReportsCount = _context.Reports.Where(x => x.reportedId == orgInDb.userId).Count();
                        var MalesReportsCounter = 0;
                        var FemalesReportsCounter = 0;
                        foreach (var rep in WantedorganReports)
                        {
                            var client = _context.Clients.Where(x => x.userId == rep.reporterId).FirstOrDefault();
                            if (client.Gender == "Male")
                            {
                                MalesReportsCounter++;
                            }
                            else if (client.Gender == "Female")
                            {
                                FemalesReportsCounter++;
                            }


                        }

                        var MalesReportsDouble = 0.0;
                        var FemalesReportsDouble = 0.0;

                        var MalesReportsPercent = "";
                        var FemalesReportsPercent = "";

                        if (WantedorganReportsCount != 0)
                        {

                            MalesReportsPercent = (Decimal.Divide(MalesReportsCounter, WantedorganReportsCount) * 100).ToString("#.##");
                            FemalesReportsPercent = (Decimal.Divide(FemalesReportsCounter, WantedorganReportsCount) * 100).ToString("#.##");

                        }

                        double.TryParse(MalesReportsPercent, out MalesReportsDouble);
                        double.TryParse(FemalesReportsPercent, out FemalesReportsDouble);


                        ViewBag.MalesReportsDouble = MalesReportsDouble;
                        ViewBag.FemalesReportsDouble = FemalesReportsDouble;

                        //Reports in Months 

                        var TupleReportsInMonthsInDB = new List<Tuple<string, int, int>>();
                        var ReportsMonthsList = _context.Reports.Where(x => x.reportedId == orgInDb.userId).ToList();
                        foreach (var mo in AllMonths)
                        {
                            var moInt = Convert.ToInt32(mo);
                            var ReportsInMonth = _context.Reports.Where(x => x.Date.Month == moInt && x.reportedId == orgInDb.userId).ToList();

                            var ReportsMonthsMalesCount = 0;
                            var ReportsMonthsFemalesCount = 0;

                            foreach (var x in ReportsInMonth)
                            {

                                var ClientIndb = _context.Clients.Where(k => k.userId == x.reporterId).FirstOrDefault();

                                if (ClientIndb.Gender == "Male")
                                {

                                    ReportsMonthsMalesCount++;
                                }

                                else if (ClientIndb.Gender == "Female")
                                {

                                    ReportsMonthsFemalesCount++;
                                }






                            }
                            TupleReportsInMonthsInDB.Add(new Tuple<string, int, int>(mo, ReportsMonthsMalesCount, ReportsMonthsFemalesCount));


                        }

                        var TupleReportsInMonthsInDBFinal = new List<Tuple<string, int, int>>();
                        foreach (var x in TupleReportsInMonthsInDB)
                        {
                            if (x.Item1 == "1")
                                TupleReportsInMonthsInDBFinal.Add(new Tuple<string, int, int>("January", x.Item2, x.Item3));
                            else if (x.Item1 == "2")
                                TupleReportsInMonthsInDBFinal.Add(new Tuple<string, int, int>("Febraury", x.Item2, x.Item3));
                            else if (x.Item1 == "3")
                                TupleReportsInMonthsInDBFinal.Add(new Tuple<string, int, int>("March", x.Item2, x.Item3));
                            else if (x.Item1 == "4")
                                TupleReportsInMonthsInDBFinal.Add(new Tuple<string, int, int>("April", x.Item2, x.Item3));
                            else if (x.Item1 == "5")
                                TupleReportsInMonthsInDBFinal.Add(new Tuple<string, int, int>("May", x.Item2, x.Item3));
                            else if (x.Item1 == "6")
                                TupleReportsInMonthsInDBFinal.Add(new Tuple<string, int, int>("June", x.Item2, x.Item3));
                            else if (x.Item1 == "7")
                                TupleReportsInMonthsInDBFinal.Add(new Tuple<string, int, int>("July", x.Item2, x.Item3));
                            else if (x.Item1 == "8")
                                TupleReportsInMonthsInDBFinal.Add(new Tuple<string, int, int>("August", x.Item2, x.Item3));
                            else if (x.Item1 == "9")
                                TupleReportsInMonthsInDBFinal.Add(new Tuple<string, int, int>("September", x.Item2, x.Item3));
                            else if (x.Item1 == "10")
                                TupleReportsInMonthsInDBFinal.Add(new Tuple<string, int, int>("October", x.Item2, x.Item3));
                            else if (x.Item1 == "11")
                                TupleReportsInMonthsInDBFinal.Add(new Tuple<string, int, int>("November", x.Item2, x.Item3));
                            else if (x.Item1 == "12")
                                TupleReportsInMonthsInDBFinal.Add(new Tuple<string, int, int>("December", x.Item2, x.Item3));


                        }


                        //Lists 

                        var ReportsMonths = new List<string>();
                        var ReportsMonthsMales = new List<int>();
                        var ReportsMonthsFemales = new List<int>();

                        foreach (var tuple in TupleReportsInMonthsInDBFinal)
                        {
                            ReportsMonths.Add(tuple.Item1);
                            ReportsMonthsMales.Add(tuple.Item2);
                            ReportsMonthsFemales.Add(tuple.Item3);

                        }


                        ViewBag.ReportsMonths = ReportsMonths;
                        ViewBag.ReportsMonthsMales = ReportsMonthsMales;
                        ViewBag.ReportsMonthsFemales = ReportsMonthsFemales;



                        ViewBag.Insights = "class = active";
                        return View();

                    }

                    else
                    {
                        return RedirectToAction("Index", "Organization");

                    }
                }

                else if (User.UserTypeId == 2)
                {


                    return RedirectToAction("Index", "User");
                }
                else
                {

                    return RedirectToAction("Index", "Admin");

                }
            }
            else
            {
                return RedirectToAction("Index", "Home");

            }
        }
        //Posts,Likes and Dislikes 

        public ActionResult deletePost(int Id)
        {

            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            else
            {

                var orgid = (int)Session["UserId"];
                var Org = _context.Organizations.SingleOrDefault(O => O.userId == orgid);
                var post = _context.Posts.SingleOrDefault(c => c.Id == Id);
                if (Org.Id == post.organizationId)
                {
                    var postImgs = _context.PostImages.Where(i => i.postId == post.Id).ToList();
                    var postReactions = _context.PostReactions.Where(i => i.postId == post.Id).ToList();
                    var promotion = _context.Promotions.SingleOrDefault(p => p.postId == post.Id);
                    if (promotion != null)
                    {
                        var promotionAges = _context.PromotionAges.SingleOrDefault(PA => PA.promotionId == promotion.Id);
                        var promotionViewers = _context.PromotionViewers.Where(PV => PV.promotionId == promotion.Id);
                        if (promotionViewers != null)
                        {
                            foreach (var viewer in promotionViewers)
                            {
                                _context.PromotionViewers.Remove(viewer);
                            }
                        }
                        if (promotionAges != null)
                        {
                            _context.PromotionAges.Remove(promotionAges);
                        }
                    }

                    
                    if (promotion != null)
                    {
                        _context.Promotions.Remove(promotion);
                    }
                    if (postReactions != null)
                    {
                        foreach (var react in postReactions)
                        {
                            _context.PostReactions.Remove(react);
                        }
                    }

                    if (postImgs != null)
                    {
                        foreach (var img in postImgs)
                        {
                            _context.PostImages.Remove(img);
                        }
                    }

                    if (post != null)
                    {
                        _context.Posts.Remove(post);
                    }
                    _context.SaveChanges();
                    return RedirectToAction("Index", "organization");
                }
                else
                {
                    Session["UserId"] = null;
                    Session["LoginUserTypeId"] = null;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
        public ActionResult promotion(OrganizationIndexPost orgIndexPost)
        {

            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            else
            {

                var orgid = (int)Session["UserId"];
                var Org = _context.Organizations.SingleOrDefault(O => O.userId == orgid);
                var post = _context.Posts.SingleOrDefault(p => p.Id == orgIndexPost.Promotion.postId);
                if (Org.Id == post.organizationId)
                {
                    //var post = _context.Posts.SingleOrDefault(p => p.Id == orgIndexPost.Promotion.postId);
                    var promotions = _context.Promotions.ToList();
                    int count = 0;

                    if (post != null)
                    {
                        foreach (var promotedPost in promotions)
                        {
                            if (promotedPost.postId == post.Id)
                            {
                                var promotedPostAge = _context.PromotionAges.SingleOrDefault(p => p.promotionId == promotedPost.Id);

                                promotedPost.Reaches = orgIndexPost.Promotion.Reaches;
                                promotedPost.postId = post.Id;
                                promotedPost.Gender = orgIndexPost.Promotion.Gender;
                                promotedPost.Profit = (1 * promotedPost.Reaches);
                                promotedPost.isDone = false;

                                promotedPostAge.promotionId = promotedPost.Id;
                                promotedPostAge.startAge = orgIndexPost.PromotionAge.startAge;
                                promotedPostAge.endAge = orgIndexPost.PromotionAge.endAge;

                                _context.SaveChanges();
                                count++;
                            }
                        }

                        if (orgIndexPost.Promotion.Reaches > 0 && orgIndexPost.Promotion.Gender != null && orgIndexPost.PromotionAge.startAge != null && orgIndexPost.PromotionAge.endAge != null && count == 0)
                        {

                            var Promotion = new Promotion();
                            Promotion.Reaches = orgIndexPost.Promotion.Reaches;
                            Promotion.postId = post.Id;
                            Promotion.Gender = orgIndexPost.Promotion.Gender;
                            Promotion.Profit = (1 * Promotion.Reaches);

                            _context.Promotions.Add(Promotion);
                            _context.SaveChanges();

                            var PromotionAges = new PromotionAge();
                            PromotionAges.promotionId = Promotion.Id;
                            PromotionAges.startAge = orgIndexPost.PromotionAge.startAge;
                            PromotionAges.endAge = orgIndexPost.PromotionAge.endAge;

                            _context.PromotionAges.Add(PromotionAges);
                            _context.SaveChanges();
                        }


                    }
                    //return RedirectToAction("Index", "organization");
                    var prom = _context.Promotions.SingleOrDefault(p => p.postId == orgIndexPost.Promotion.postId);
                    Session["prom_Id"] = prom.Id;
                    prom.Reaches = (int)0.25;
                    return View("paymentSubmitPage", prom);
                }
                else
                {
                    Session["UserId"] = null;
                    Session["LoginUserTypeId"] = null;
                    return RedirectToAction("Index", "Home");
                }
            }
        }




        public ActionResult GetDataPaypal()
        {
            var getData = new GetDataPaypal();
            var order = getData.InformationOrder(getData.GetPayPalResponse(Request.QueryString["tx"]));
            ViewBag.status = order.PaymentStatus;
            ViewBag.tx = Request.QueryString["tx"];
            int promId = Convert.ToInt32( Session["prom_Id"]);
            var promotion = _context.Promotions.SingleOrDefault(c => c.Id == promId);
            promotion.isDone = true;
            _context.SaveChanges();
            ViewBag.promId = promId;
            Session["paysuccess"] = "success";
            return RedirectToAction("Index", "Organization");
            //  return View();
        }







        public JsonResult NumberOfFollowers(int id)
        {
            var numberOfFollowers = _context.Subscribers.Where(s => s.organizationId == id).Count();
            return Json(numberOfFollowers);
        }
        public JsonResult useful(ReviewReaction reviewReaction)
        {
            var reviewreactioInDB = _context.ReviewReactions
                .SingleOrDefault(rr => rr.reviewId == reviewReaction.reviewId && rr.clientId == reviewReaction.clientId);
            var reviewInDB = _context.Reviews.SingleOrDefault(r => r.Id == reviewReaction.reviewId);
            if (reviewreactioInDB == null)
            {
                _context.ReviewReactions.Add(reviewReaction);
                reviewInDB.numberOfUseful = reviewInDB.numberOfUseful + 1;
                _context.SaveChanges();
                return Json(new { nouc="green" , noun = _context.ReviewReactions.Where(rr => rr.reviewId == reviewReaction.reviewId).Count() });
            }
            else
            {
                _context.ReviewReactions.Remove(reviewreactioInDB);
                reviewInDB.numberOfUseful = reviewInDB.numberOfUseful - 1;
                _context.SaveChanges();
                return Json(new { nouc = "black", noun = _context.ReviewReactions.Where(rr => rr.reviewId == reviewReaction.reviewId).Count() });
            }

        }


    }
}