using RC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RC.ViewModels;
using System.IO;
using System.Text;

namespace RC.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext _Context = new ApplicationDbContext();

        public ActionResult addAds(Advertisement advertisement, HttpPostedFileBase upload)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var adminId = (int)Session["UserId"];
                var admin = _Context.Users.SingleOrDefault(O => O.Id == adminId);
                if (admin.UserTypeId == 1)
                {
                    if (advertisement != null)
                    {
                        //if (!ModelState.IsValid)
                        //{
                        //    return View(advertisement);
                        //}

                        //else
                        //{
                        if (advertisement.startDate > DateTime.Now && advertisement.endDate > DateTime.Now && advertisement.endDate > advertisement.startDate)
                        {
                            var Ad = new Advertisement();
                            Ad.startDate = advertisement.startDate;
                            Ad.endDate = advertisement.endDate;
                            Ad.Link = advertisement.Link;
                            if (upload != null)
                            {
                                string path = Path.Combine(Server.MapPath("~/Content/img/AdsImgs"), upload.FileName);
                                upload.SaveAs(path);
                                Ad.imageUrl = upload.FileName;
                            }

                            _Context.Advertisements.Add(Ad);
                            _Context.SaveChanges();
                            return RedirectToAction("Home", "Admin");
                        }

                        else
                        {
                            ViewBag.Ads = "class = active";
                            //return View();
                            return View(advertisement);
                        }
                        //}
                    }
                }

                else
                {
                    Session["UserId"] = null;
                    Session["LoginUserTypeId"] = null;
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Home()
        {
            
            if (Session["UserId"] != null && Convert.ToInt32(Session["LoginUserTypeId"]) == 1)
            {
                ViewBag.Home = "class = active";
                var Organizations = _Context.Organizations.Include(c => c.Category.Sector)
                    .Include(c=> c.User).Include(c=> c.PriceRange).Include(c=> c.City).Where(m => m.state == 0);
                return View(Organizations);

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

        [HttpPut]
        public Boolean Block(int id)
        {

            var organization = _Context.Organizations.Include(c => c.User).SingleOrDefault(c => c.Id == id);
            if (organization != null)
            {

                organization.User.State = 0;
                _Context.SaveChanges();
                return true;

            }

            return false;
        }


        //Unblock orgainzation Function
        [HttpPut]
        public Boolean Unblock(int id)
        {

            var organization = _Context.Organizations.Include(c => c.User).SingleOrDefault(c => c.Id == id);
            if (organization != null)
            {

                organization.User.State = 1;
                _Context.SaveChanges();
                return true;

            }

            return false;
        }

        //block user function
        [HttpPut]
        public Boolean BlockClient(int id)
        {

            var client = _Context.Clients.Include(c => c.User).SingleOrDefault(c => c.Id == id);
            if (client != null)
            {

                client.User.State = 0;
                _Context.SaveChanges();
                return true;

            }

            return false;
        }

        //unblock user function
        [HttpPut]
        public Boolean UnblockClient(int id)
        {

            var client = _Context.Clients.Include(c => c.User).SingleOrDefault(c => c.Id == id);
            if (client != null)
            {

                client.User.State = 1;
                _Context.SaveChanges();
                return true;

            }

            return false;
        }


        public ActionResult getUsers()
        {

            if (Session["UserId"] != null)
            {
                var AdminSessionID = (int)Session["UserId"];
                var admin = _Context.Users.Where(x => x.Id == AdminSessionID).FirstOrDefault();


                if (admin.UserTypeId == 1)
                {
                    var users = _Context.Clients.Include(c => c.User).Include(c => c.City).ToList();

                    ViewBag.Users = "class = active";
                    return View("Users", users);
                }
                else if (admin.UserTypeId == 2)
                {
                    return RedirectToAction("Index", "User");
                }

                else
                {
                    return RedirectToAction("Index", "Organization");
                }
            }

            else
            {

                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult getOrganizations()
        {
            if (Session["UserId"] != null)
            {
                var AdminSessionID = (int)Session["UserId"];
                var admin = _Context.Users.Where(x => x.Id == AdminSessionID).FirstOrDefault();


                if (admin.UserTypeId == 1)
                {
                    var organizations = _Context.Organizations.Include(c => c.User).Include(c => c.Category.Sector).Include(c => c.City).Include(c => c.PriceRange).Where(c=>c.state==1).ToList();

                    ViewBag.Organizations = "class = active";
                    return View("Organizations", organizations);
                }
                else if (admin.UserTypeId == 2)
                {
                    return RedirectToAction("Index", "User");
                }

                else
                {
                    return RedirectToAction("Index", "Organization");
                }
            }

            else
            {

                return RedirectToAction("Index", "Home");
            }


        }

        public ActionResult getInsights()
        {

            //Organizations Reviews 

            if (Session["UserId"] != null)
            {
                var AdminSessionID = (int)Session["UserId"];
                var admin = _Context.Users.Where(x => x.Id == AdminSessionID).FirstOrDefault();


                if (admin.UserTypeId == 1)
                {
                    var orgReviews = 0;
                    var organizations = _Context.Organizations.Where(x => x.state == 1).Include(x => x.User).ToList();
                    List<Organization> orgNames = new List<Organization>();
                    List<int> orgReviewsBag = new List<int>();
                    var OrgsReviewsTuple = new List<Tuple<Organization, int, int, int>>();

                    foreach (var org in organizations)
                    {
                        var MalesCounter = 0;
                        var FemalesCounter = 0;
                        orgNames.Add(org);
                        orgReviews = _Context.Reviews.Count(x => x.organizationId == org.Id);
                        var OrgReviewsList = _Context.Reviews.Where(x => x.organizationId == org.Id).Include(x => x.Client).ToList();
                        orgReviewsBag.Add(orgReviews);

                        foreach (var x in OrgReviewsList)
                        {
                            if (x.Client.Gender == "Male")
                            {
                                MalesCounter++;
                            }
                            else if (x.Client.Gender == "Female")
                            {
                                FemalesCounter++;

                            }


                        }
                        OrgsReviewsTuple.Add(new Tuple<Organization, int, int, int>(org, orgReviews, MalesCounter, FemalesCounter));

                    }


                    var orderedReviewsTuple = OrgsReviewsTuple.OrderByDescending(x => x.Item2);

                    ////Lists
                    //orgNames = new List<Organization>();
                    //orgReviewsBag = new List<int>();
                    //var MalesList = new List<int>();
                    //var FemalesList = new List<int>();

                    //foreach (var x in OrgsReviewsTuple)
                    //{
                    //    orgNames.Add(x.Item1);
                    //    orgReviewsBag.Add(x.Item2);
                    //    MalesList.Add(x.Item3);
                    //    FemalesList.Add(x.Item4);




                    //}


                    ViewBag.orderedReviewsTuple = orderedReviewsTuple;
                    //ViewBag.OrgReviews = orgReviewsBag;
                    //ViewBag.MalesList = MalesList;
                    //ViewBag.FemalesList = FemalesList;





                    ////////////////////////////////////////////////////////////////////////

                    //Number of organizations in cities

                    var cities = _Context.Cities.ToList();

                    List<int> orgcities = new List<int>();
                    List<string> citiesNames = new List<string>();

                    foreach (var city in cities)
                    {
                        var organizationsInCity = _Context.Organizations.Where(x => x.state == 1).Count(x => x.cityId == city.Id);
                        citiesNames.Add(city.Name);
                        orgcities.Add(organizationsInCity);

                    }

                    ViewBag.Cities = citiesNames;
                    ViewBag.orgCities = orgcities;




                    //Number of organizations in Categories 

                    var Categories = _Context.Categories.ToList();

                    List<int> orgcategories = new List<int>();
                    List<string> CategoriesNames = new List<string>();

                    foreach (var category in Categories)
                    {
                        var organizationsInCategories = _Context.Organizations.Where(x => x.state == 1).Count(x => x.categoryId == category.Id);
                        CategoriesNames.Add(category.Name);
                        orgcategories.Add(organizationsInCategories);

                    }

                    ViewBag.Categories = CategoriesNames;
                    ViewBag.orgCategories = orgcategories;




                    //Number of org Joined  every year 
                    List<int> orgNumbers = new List<int>();
                    List<String> years = new List<String>();


                    //Get years/
                    var yearsInDB = _Context.Users.Select(u => u.JoniedAt.Year).Distinct().ToList();


                    foreach (var year in yearsInDB)
                    {
                        var organizationInYear = _Context.Organizations
                            .Where(user => user.User.UserTypeId == 3 && user.User.JoniedAt.Year == year && user.state == 1).Count();



                        //var orgsPerYearList = _Context.Users
                        //    .Where(user => user.UserTypeId == 3 && user.JoniedAt.Year == year).ToList();


                        orgNumbers.Add(organizationInYear);
                        years.Add(year.ToString());

                    }

                    ViewBag.orgInYears = orgNumbers;
                    ViewBag.Years = years;






                    //Numbers of Subscribers in evevry Organizations 

                    List<int> subscribersNumber = new List<int>();
                    var SubsorganizationsLTuple = new List<Tuple<Organization, int, int, int>>();

                    var organizationsInDb = _Context.Organizations.Where(x => x.state == 1).ToList();

                    foreach (var orgName in organizationsInDb)
                    {

                        var SubsMales = _Context.Subscribers.Where(x => x.Client.Gender == "Male" && orgName.Id == x.organizationId).Count();
                        var SubsFemales = _Context.Subscribers.Where(x => x.Client.Gender == "Female" && orgName.Id == x.organizationId).Count();
                        // organizationsList.Add(orgName);
                        var SusbscribersTotal = _Context.Subscribers.Where(x => x.organizationId == orgName.Id).Count();


                        SubsorganizationsLTuple.Add(new Tuple<Organization, int, int, int>(orgName, SusbscribersTotal, SubsMales, SubsFemales));

                    }

                    ViewBag.SubsorganizationsLTuple = SubsorganizationsLTuple;
                    // ViewBag.Susbscribers = subscribersNumber;



                    //Numbers of Users Each Month 

                    List<int> ClientsPerYear = new List<int>();
                    List<int> OrgsPerYear = new List<int>();
                    List<String> YearsInDB = new List<String>();

                    List<int> MalesMonths = new List<int>();
                    List<int> FemalesMonths = new List<int>();

                    List<string> AllMonths = new List<string>();
                    var UsersInDb = _Context.Users.ToList();

                    //Getting 12 months of the year

                    DateTime now = DateTime.Now;
                    for (int i = 0; i < 12; i++)
                    {
                        AllMonths.Add(now.Month.ToString());
                        now = now.AddMonths(1);

                    }


                    var monthsTuple = new List<Tuple<string, int, int, int, int>>();


                    foreach (var month in AllMonths)
                    {
                        //var Month = month.ToString();
                        var Clients = _Context.Users.Where(x => x.UserTypeId == 2 && x.JoniedAt.Month.ToString() == month).Count();
                        var orgs = _Context.Organizations.Where(x => x.User.UserTypeId == 3 && x.User.JoniedAt.Month.ToString() == month && x.state == 1).Count();

                        var MalesCount = 0;
                        var FemalesCount = 0;

                        var ClientsList = _Context.Clients
                            .Where(x => x.User.UserTypeId == 2 && x.User.JoniedAt.Month.ToString() == month)
                            .Include(x => x.User)
                            .ToList();



                        foreach (var x in ClientsList)
                        {
                            if (x.Gender == "Male")
                                MalesCount++;
                            else if (x.Gender == "Female")
                                FemalesCount++;

                        }

                        monthsTuple.Add(new Tuple<string, int, int, int, int>(month, Clients, orgs, MalesCount, FemalesCount));
                        //ClientsPerYear.Add(Clients);
                        //OrgsPerYear.Add(orgs);
                        //YearsInDB.Add(month);



                    }

                    var NewTupleMonths = new List<Tuple<string, int, int, int, int>>();

                    foreach (var x in monthsTuple)
                    {
                        if (x.Item1 == "1")
                            NewTupleMonths.Add(new Tuple<string, int, int, int, int>("January", x.Item2, x.Item3, x.Item4, x.Item5));
                        else if (x.Item1 == "2")
                            NewTupleMonths.Add(new Tuple<string, int, int, int, int>("Febraury", x.Item2, x.Item3, x.Item4, x.Item5));
                        else if (x.Item1 == "3")
                            NewTupleMonths.Add(new Tuple<string, int, int, int, int>("March", x.Item2, x.Item3, x.Item4, x.Item5));
                        else if (x.Item1 == "4")
                            NewTupleMonths.Add(new Tuple<string, int, int, int, int>("April", x.Item2, x.Item3, x.Item4, x.Item5));
                        else if (x.Item1 == "5")
                            NewTupleMonths.Add(new Tuple<string, int, int, int, int>("May", x.Item2, x.Item3, x.Item4, x.Item5));
                        else if (x.Item1 == "6")
                            NewTupleMonths.Add(new Tuple<string, int, int, int, int>("June", x.Item2, x.Item3, x.Item4, x.Item5));
                        else if (x.Item1 == "7")
                            NewTupleMonths.Add(new Tuple<string, int, int, int, int>("July", x.Item2, x.Item3, x.Item4, x.Item5));
                        else if (x.Item1 == "8")
                            NewTupleMonths.Add(new Tuple<string, int, int, int, int>("August", x.Item2, x.Item3, x.Item4, x.Item5));
                        else if (x.Item1 == "9")
                            NewTupleMonths.Add(new Tuple<string, int, int, int, int>("September", x.Item2, x.Item3, x.Item4, x.Item5));
                        else if (x.Item1 == "10")
                            NewTupleMonths.Add(new Tuple<string, int, int, int, int>("October", x.Item2, x.Item3, x.Item4, x.Item5));
                        else if (x.Item1 == "11")
                            NewTupleMonths.Add(new Tuple<string, int, int, int, int>("November", x.Item2, x.Item3, x.Item4, x.Item5));
                        else if (x.Item1 == "12")
                            NewTupleMonths.Add(new Tuple<string, int, int, int, int>("December", x.Item2, x.Item3, x.Item4, x.Item5));


                    }


                    foreach (var data in NewTupleMonths)
                    {
                        ClientsPerYear.Add(data.Item2);
                        OrgsPerYear.Add(data.Item3);
                        YearsInDB.Add(data.Item1);
                        FemalesMonths.Add(data.Item5);
                        MalesMonths.Add(data.Item4);


                    }


                    ViewBag.ClientsPerYear = ClientsPerYear;
                    ViewBag.OrgsPerYear = OrgsPerYear;
                    ViewBag.YearsInDB = YearsInDB;

                    ViewBag.MalesMonths = MalesMonths;
                    ViewBag.FemalesMonths = FemalesMonths;


                    //Top 10 Organizations 

                    var TopOrganizations = _Context.OrganizationFactors.OrderBy(x => x.organizationId).GroupBy(x => x.organizationId).ToList();

                    //List<IGrouping<int, float>> orgTotalRates = new List<IGrouping<int, float>>();
                    var tuple = new List<Tuple<int, double>>();

                    foreach (var org in TopOrganizations)
                    {

                        var organizationID = org.Key;

                        float factorsRateCount = _Context.OrganizationFactors.Where(x => x.organizationId == organizationID).Select(x => x.factorRate).Count();
                        float factorRates = 0;
                        foreach (var data in org)
                        {

                            factorRates = (factorRates + data.factorRate);



                        }

                        float AverageOFRates = (factorRates / factorsRateCount) * 10;
                        double FinalAverageApprox = Math.Round(AverageOFRates, 2);

                        tuple.Add(new Tuple<int, double>(organizationID, FinalAverageApprox));

                    }


                    var TupleOrgNames = new List<Tuple<Organization, double>>();
                    //var BestOrg = new Organization();

                    foreach (var t in tuple)
                    {
                        var org = _Context.Organizations.Where(x => x.Id == t.Item1).Include(x => x.User).SingleOrDefault();

                        TupleOrgNames.Add(new Tuple<Organization, double>(org, t.Item2));


                    }

                    var finalTuple = TupleOrgNames.OrderByDescending(x => x.Item2).ToList();
                    var TopTenOrganizationsTuple = finalTuple.Take(10);
                    var FirstOrg = TopTenOrganizationsTuple.First().Item1;

                    //Get the best organization 

                    var BestOrg = _Context.Organizations.Where(x => x.orgnizationName == FirstOrg.orgnizationName).FirstOrDefault();
                    ViewBag.BestOrg = BestOrg;



                    //Create Lists 
                    //var RatesList = new List<double>();
                    //var TopTenList = new List<Organization>();


                    //foreach (var x in TopTenOrganizationsTuple)
                    //{

                    //    RatesList.Add(x.Item2);
                    //    TopTenList.Add(x.Item1);



                    //}

                    //ViewBag.RatesList = RatesList;
                    //ViewBag.TopTenList = TopTenList;
                    ViewBag.TopTenOrganizationsTuple = TopTenOrganizationsTuple;





                    ////Least Ten Organizations 


                    var LeastOrganizations = _Context.OrganizationFactors.OrderBy(x => x.organizationId).GroupBy(x => x.organizationId).ToList();

                    //List<IGrouping<int, float>> orgTotalRates = new List<IGrouping<int, float>>();
                    var FirstLeastTuple = new List<Tuple<int, double>>();

                    foreach (var org in TopOrganizations)
                    {

                        var organizationID = org.Key;

                        float factorsRateCount = _Context.OrganizationFactors.Where(x => x.organizationId == organizationID).Select(x => x.factorRate).Count();
                        float factorRates = 0;
                        foreach (var data in org)
                        {

                            factorRates = (factorRates + data.factorRate);



                        }

                        float AverageOFRates = factorRates / factorsRateCount;
                        double FinalAverageApprox = Math.Round(AverageOFRates, 2);

                        FirstLeastTuple.Add(new Tuple<int, double>(organizationID, FinalAverageApprox));

                    }


                    var TupleLeastOrgNames = new List<Tuple<Organization, double>>();
                    //var BestOrg = new Organization();

                    foreach (var t in tuple)
                    {
                        var org = _Context.Organizations.Where(x => x.Id == t.Item1).SingleOrDefault();
                        // var orgName = org.orgnizationName;
                        TupleLeastOrgNames.Add(new Tuple<Organization, double>(org, t.Item2));


                    }

                    var finalLeastTuple = TupleOrgNames.OrderBy(x => x.Item2).ToList();
                    var LeastTenOrganizationsTuple = finalLeastTuple.Take(10);


                    //Get the Least organization 
                    var FirstLeastOrg = LeastTenOrganizationsTuple.First().Item1.ToString();
                    var WorstOrg = _Context.Organizations.Where(x => x.orgnizationName == FirstLeastOrg).FirstOrDefault();
                    ViewBag.WorstOrg = WorstOrg;



                    //Create Lists 
                    //var LeastRatesList = new List<double>();
                    //var LeastTenList = new List<string>();

                    //foreach (var x in LeastTenOrganizationsTuple)
                    //{

                    //    LeastRatesList.Add(x.Item3);
                    //    LeastTenList.Add(x.Item1);


                    //}

                    //ViewBag.LeastRatesList = LeastRatesList;
                    //ViewBag.LeastTenList = LeastTenList;

                    ViewBag.LeastTenOrganizationsTuple = LeastTenOrganizationsTuple;




                    //Get Total PriceRanges 
                    var PriceRanges = _Context.PriceRanges.ToList();

                    //Create Two Lists 
                    var OrganizationsPriceRanges = new List<int>();
                    var PriceRangesList = new List<string>();


                    foreach (var range in PriceRanges)
                    {
                        var orgRange = _Context.Organizations.Where(x => x.PriceRangeId == range.ID && x.state == 1).Count();
                        OrganizationsPriceRanges.Add(orgRange);
                        PriceRangesList.Add(range.Name);

                    }


                    ViewBag.OrganizationsPriceRanges = OrganizationsPriceRanges;
                    ViewBag.PriceRangesList = PriceRangesList;




                    //Getting Users Joined Every Year
                    var ListOfYears = _Context.Users.Where(x => x.UserTypeId == 2 || x.UserTypeId == 3).Select(x => x.JoniedAt.Year).Distinct().ToList();

                    var ClientsListofYear = new List<int>();
                    var OrgsListsofYear = new List<int>();
                    var AllYears = new List<int>();
                    var MalesUsList = new List<int>();
                    var FemalesUsList = new List<int>();

                    var UsersYearTuple = new List<Tuple<int, int, int, int, int>>();


                    foreach (var year in ListOfYears)
                    {
                        var MalesCount = 0;
                        var FemalesCount = 0;
                        var orgs = _Context.Organizations.Where(x => x.User.UserTypeId == 3 && x.User.JoniedAt.Year == year && x.state == 1).Count();
                        var Clients = _Context.Users.Where(x => x.UserTypeId == 2 && x.JoniedAt.Year == year).Count();
                        var ClientsList = _Context.Clients
                            .Where(x => x.User.UserTypeId == 2 && x.User.JoniedAt.Year == year)
                            .Include(x => x.User)
                            .ToList();



                        foreach (var x in ClientsList)
                        {
                            if (x.Gender == "Male")
                                MalesCount++;
                            else if (x.Gender == "Female")
                                FemalesCount++;

                        }

                        UsersYearTuple.Add(new Tuple<int, int, int, int, int>(year, orgs, Clients, MalesCount, FemalesCount));
                        //ClientsListofYear.Add(Clients);
                        //OrgsListsofYear.Add(orgs);
                        //AllYears.Add(year.ToString());


                    }


                    foreach (var x in UsersYearTuple)
                    {
                        AllYears.Add(x.Item1);
                        OrgsListsofYear.Add(x.Item2);
                        ClientsListofYear.Add(x.Item3);
                        MalesUsList.Add(x.Item4);
                        FemalesUsList.Add(x.Item5);

                    }

                    ViewBag.ClientsListofYear = ClientsListofYear;
                    ViewBag.OrgsListsofYear = OrgsListsofYear;
                    ViewBag.AllYears = AllYears;
                    ViewBag.MalesUsList = MalesUsList;
                    ViewBag.FemalesUsList = FemalesUsList;





                    //Percent of Reviews Males and Females

                    var TotalReviews = _Context.Reviews.Count();
                    var TotalReviewsMales = _Context.Reviews.ToList();

                    var MalesReviewsCounter = 0;
                    var FemalesReviewsCounter = 0;

                    foreach (var x in TotalReviewsMales)
                    {
                        if (x.Client.Gender == "Male")
                        {

                            MalesReviewsCounter++;
                        }
                        else if (x.Client.Gender == "Female")
                        {
                            FemalesReviewsCounter++;

                        }

                    }

                    var MalesPercent = "";
                    var FemalesPercent = "";
                    if (TotalReviews != 0)
                    {
                         MalesPercent = (Decimal.Divide(MalesReviewsCounter, TotalReviews) * 100).ToString("#.##");
                         FemalesPercent = (Decimal.Divide(FemalesReviewsCounter, TotalReviews) * 100).ToString("#.##");
                    }

               


                    ViewBag.MalesPercent = MalesPercent;
                    ViewBag.FemalesPercent = FemalesPercent;



                    //Users Percentages 

                    var TotalUsers = _Context.Clients.Count();
                    var TotalUsersList = _Context.Clients.ToList();

                    var MalesUsersCounter = 0;
                    var FemalesUsersCounter = 0;

                    foreach (var x in TotalUsersList)
                    {
                        if (x.Gender == "Male")
                        {

                            MalesUsersCounter++;
                        }
                        else if (x.Gender == "Female")
                        {
                            FemalesUsersCounter++;

                        }

                    }

                    var MalesClientsPercent = (Decimal.Divide(MalesUsersCounter, TotalUsers) * 100).ToString("#.##");
                    var FemalesClientsPercent = (Decimal.Divide(FemalesUsersCounter, TotalUsers) * 100).ToString("#.##");


                    ViewBag.MalesClientsPercent = MalesClientsPercent;
                    ViewBag.FemalesClientsPercent = FemalesClientsPercent;



                    //Reports Table 
                    // var Reports = _Context.Reports.Count();

                    var MalesFemales = 0;
                    var MalesMales = 0;

                    var FemalesMales = 0;
                    var FemalesFemales = 0;

                    var ReporterClients = _Context.Reports.Where(x => x.reportKindId == 2).ToList();
                    var ReporterClientsCount = _Context.Reports.Where(x => x.reportKindId == 2).Count();

                    foreach (var report in ReporterClients)
                    {
                        var Client1 = _Context.Clients.Where(x => x.userId == report.reporterId).FirstOrDefault();
                        var Client2 = _Context.Clients.Where(x => x.userId == report.reportedId).FirstOrDefault();
                        if (Client1.Gender == "Male" && Client2.Gender == "Female")
                            MalesFemales++;
                        else if (Client1.Gender == "Male" && Client2.Gender == "Male")
                            MalesMales++;
                        else if (Client1.Gender == "Female" && Client2.Gender == "Male")
                            FemalesMales++;
                        else if (Client1.Gender == "Female" && Client2.Gender == "Female")
                            FemalesFemales++;


                    }


                    var V_MalesFemales = "";
                    var V_MalesMales = "";
                    var V_FemalesMales = "";
                    var V_FemalesFemales = "";
                    if (ReporterClientsCount != 0)
                    {
                        V_MalesFemales = (Decimal.Divide(MalesFemales, ReporterClientsCount) * 100).ToString("#.##");
                        V_MalesMales = (Decimal.Divide(MalesMales, ReporterClientsCount) * 100).ToString("#.##");
                        V_FemalesMales = (Decimal.Divide(FemalesMales, ReporterClientsCount) * 100).ToString("#.##");
                        V_FemalesFemales = (Decimal.Divide(FemalesFemales, ReporterClientsCount) * 100).ToString("#.##");
                    }

                    //user vs org 

                    var Reportedorgs = _Context.Reports.Where(x => x.reported.UserTypeId == 3).ToList();
                    var ReportedorgsCount = _Context.Reports.Where(x => x.reported.UserTypeId == 3).Count();

                    var Malesorg = 0;
                    var Femalesorg = 0;

                    foreach (var x in Reportedorgs)
                    {
                        var ClientsOrgs = _Context.Reports.Where(k => k.reporterId == x.reporterId && k.reportedId == x.reportedId).FirstOrDefault();

                        var user = _Context.Clients.Where(j => j.userId == ClientsOrgs.reporterId).FirstOrDefault();
                        if (user.Gender == "Male")
                        {
                            Malesorg++;


                        }
                        else if (user.Gender == "Female")
                            Femalesorg++;






                    }

                    var malesOrg = "";
                    var femalesOrg = "";
                    if (ReportedorgsCount != 0)
                    {
                        malesOrg = (Decimal.Divide(Malesorg, ReportedorgsCount) * 100).ToString("#.##");
                        femalesOrg = (Decimal.Divide(Femalesorg, ReportedorgsCount) * 100).ToString("#.##");
                    }



                    double MM, MF, FF, FM, OF, OM;

                    Double.TryParse(V_MalesMales, out MM);
                    Double.TryParse(V_MalesFemales, out MF);
                    Double.TryParse(V_FemalesMales, out FM);
                    Double.TryParse(V_FemalesFemales, out FF);
                    Double.TryParse(malesOrg, out OM);
                    Double.TryParse(femalesOrg, out OF);


                    ViewBag.V_MalesFemales = MF;
                    ViewBag.V_MalesMales = MM;
                    ViewBag.V_FemalesMales = FM;
                    ViewBag.V_FemalesFemales = FF;
                    ViewBag.malesOrg = OM;
                    ViewBag.femalesOrg = OF;




                    //Reports of every org Males and Females 


                    var ReportTuple = new List<Tuple<Organization, int, int, int>>();
                    var EveryReportedOrgs = _Context.Organizations.Where(x => x.state == 1).Include(x => x.User).ToList();


                    foreach (var orgGenders in EveryReportedOrgs)
                    {
                        var MalesReportCounter = 0;
                        var FemalesReportCounter = 0;
                        //var orguser = _Context.Organizations.Where(x => x.userId == orgGenders.reportedId && x.state==1).FirstOrDefault();
                        var ClientsOrgs = _Context.Reports.Where(k => k.reportedId == orgGenders.User.Id).ToList();
                        var ClientsOrgsCount = _Context.Reports.Where(k => k.reportedId == orgGenders.User.Id).Count();




                        foreach (var gender in ClientsOrgs)
                        {

                            var user = _Context.Clients.Where(j => j.userId == gender.reporterId).FirstOrDefault();
                            if (user.Gender == "Male")
                            {
                                MalesReportCounter++;


                            }
                            else if (user.Gender == "Female")
                                FemalesReportCounter++;

                        }
                        ReportTuple.Add(new Tuple<Organization, int, int, int>(orgGenders, ClientsOrgsCount, MalesReportCounter, FemalesReportCounter));

                    }


                
                    //Lists

                    //var ReportMalesList = new List<int>();
                    //var ReportFemalesList = new List<int>();
                    //var OrganName = new List<string>();

                    //foreach (var tu in ReportTuple)
                    //{

                    //    OrganName.Add(tu.Item1);
                    //    ReportMalesList.Add(tu.Item2);
                    //    ReportFemalesList.Add(tu.Item3);


                    //}

                    ViewBag.ReportTuple = ReportTuple.OrderByDescending(x=> x.Item2);
                    //ViewBag.ReportMalesList = ReportMalesList;
                    //ViewBag.ReportFemalesList = ReportFemalesList;


                    //percent useful Reviews  Females and Males 

                    var usefulReviews = _Context.Reviews.Where(x => x.numberOfUseful > 0).Include(x => x.Client.User).OrderByDescending(x => x.numberOfUseful).Take(10).ToList();
                    ViewBag.usefulRev = usefulReviews;










                    //Best Reviewer


                    var bestReviewer = _Context.Reviews.OrderByDescending(x => x.numberOfUseful).Take(1).Include(x => x.Client).FirstOrDefault();
                    var ReviewIntPoints = 0;
                    if (bestReviewer != null)
                    {
                        var ReviewPoints = bestReviewer.numberOfUseful.ToString();
                        Int32.TryParse(ReviewPoints, out ReviewIntPoints);
                    }

                   
                    
                  



                    ViewBag.bestReviewer = bestReviewer;
                    ViewBag.ReviewIntPoints = ReviewIntPoints;



                    //Profite of Promoted Posts

                    var WholeOrganizations = _Context.Organizations.Where(x => x.state == 1).ToList();

                    var ProfitList = new List<double>();

                    var ProfitTuple = new List<Tuple<Organization, int, double>>();

                    foreach (var org in WholeOrganizations)
                    {
                        var PromotionCounter = 0;
                        var Profit = 0.0;
                        var orgPosts = _Context.Posts.Where(x => x.organizationId == org.Id).ToList();
                        //  var orgPostsCount = _Context.Posts.Where(x => x.organizationId == org.Id).Count();
                        foreach (var post in orgPosts)
                        {
                            var PromotedPosts = _Context.Promotions.Where(x => x.postId == post.Id).FirstOrDefault();

                            var ConvertDouble = 0.0;

                            if (PromotedPosts != null)
                                Double.TryParse(PromotedPosts.Profit.ToString(), out ConvertDouble);



                            if (PromotedPosts != null)
                            {
                                PromotionCounter++;
                                Profit += ConvertDouble;

                            }




                        }
                        ProfitList.Add(Profit);
                        ProfitTuple.Add(new Tuple<Organization, int, double>(org, PromotionCounter, Profit));


                    }



                    //Lists

                    //var OrgNames = new List<Organization>();
                    //var Promoted = new List<int>();
                    //var Profits = new List<double>();


                    //foreach (var profit in ProfitTuple)
                    //{
                    //    OrgNames.Add(profit.Item1);
                    //    Promoted.Add(profit.Item2);
                    //    Profits.Add(profit.Item3);

                    //}


                    var ProfitResult = 0.0;
                    for (var k = 0; k < ProfitList.Count; k++)
                    {

                        ProfitResult = ProfitResult + ProfitList[k];

                    }

                    //ViewBag.OrgNames = OrgNames;
                    //ViewBag.Promoted = Promoted;
                    //ViewBag.Profits = Profits;
                    ViewBag.ProfitResult = ProfitResult;
                    ViewBag.ProfitTuple = ProfitTuple.OrderByDescending(x=> x.Item3);

                    ViewBag.Insights = "class = active";
                    return View("Insights");
                }
                else if (admin.UserTypeId == 2)
                {
                    return RedirectToAction("Index", "User");
                }

                else
                {
                    return RedirectToAction("Index", "Organization");
                }
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }









        }
        public ActionResult getReports()
        {
            if (Session["UserId"] == null || Convert.ToInt32(Session["LoginUserTypeId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            var reports = _Context.Reports.Include(c =>c.reportType).Include(rep => rep.reportKind).Include(rep => rep.reporter).Include(rep => rep.reported).ToList();
            ViewBag.Reports = "class = active";
            return View("Reports", reports);
        }

        public ActionResult getUserTypes()
        {
            var roles = _Context.UserTypes.ToList();
            ViewBag.UserTypes = "class = active";
            return View("UserTypes",roles);
        }


        public ActionResult addSectorAndCategory()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var adminId = (int)Session["UserId"];
                var admin = _Context.Users.SingleOrDefault(O => O.Id == adminId);
                if (admin.UserTypeId == 1)
                {
                    ViewBag.Sector = "class = active";
                    var sectors = _Context.Sector.ToList();
                    var categories = _Context.Categories.ToList();
                    var vm = new SectorAndCategoryViewModel
                    {
                        Sectors = sectors,
                        Categories = categories
                    };
                    return View(vm);
                }
                else
                {
                    Session["UserId"] = null;
                    Session["LoginUserTypeId"] = null;
                    return RedirectToAction("Index", "Home");
                }
            }
        }




        public ActionResult CreateRole()
        {

            return View();
        }
        

        [HttpPost]
        public ActionResult CreateRole(UserType usertype)
        {


                _Context.UserTypes.Add(usertype);
                _Context.SaveChanges();
                return RedirectToAction("getUserTypes", "Admin");

  
        }


        //public ActionResult EditRole(int id)
        //{
        //    var role = _Context.UserTypes.Find(id);

        //    return ViewBagrole)
        //}


        [HttpPost]
        public ActionResult EditRole(UserType usertype)
        {

            var role = _Context.UserTypes.Find(usertype.Id);
            if (role != null)
            {

                role.Name = usertype.Name;
                _Context.SaveChanges();
               
                
            }


            return RedirectToAction("getUserTypes", "Admin");
        }

        public ActionResult Fedbacks()
        {
            if (Session["UserId"] != null && Convert.ToInt32(Session["LoginUserTypeId"]) == 1)
            {
                var feedbacks = _Context.FeedBacks.ToList();
                return View("Fedbacks", feedbacks);
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
        /*[HttpPost]
        public ActionResult SaveSector(Sector sector)
        {
            if(!ModelState.IsValid)
            {
                var sectors = _Context.Sector.ToList();
                var vm = new SectorAndCategoryViewModel
                {
                    Sectors = sectors,
                    Sector =sector
                };
                return View("addSectorAndCategory", vm);
            }

            _Context.Sector.Add(sector);
            _Context.SaveChanges();                       
                return RedirectToAction("Home","Admin");
        }*/
        /* [HttpPost]
         public ActionResult SaveCategory(Category category)
         {
             if (!ModelState.IsValid)
             {
                 var sectors = _Context.Sector.ToList();
                 var vm = new SectorAndCategoryViewModel
                 {
                     Sectors = sectors,
                     Category = category
                 };
                 return View("addSectorAndCategory", vm);
             }
             _Context.Categories.Add(category);
             _Context.SaveChanges();
             return RedirectToAction("Home", "Admin");
         }*/

        public ActionResult addReward()
        {
            if (Session["UserId"] == null || Convert.ToInt32(Session["LoginUserTypeId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }

            var gifts = _Context.Offers.ToList();
            var viewmodel = new OfferImage
            {
                offers = gifts

            };
            var client = new Client();
            ViewBag.Reward = "class = active";
            return View("Reward", viewmodel);
        }

        public ActionResult saveReward(OfferImage gift)
        {

            if (gift.offer != null)
            {


                string filename = Path.GetFileNameWithoutExtension(gift.ImageFile.FileName);
                string extension = Path.GetExtension(gift.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                gift.offer.imageUrl = filename;
                filename = Path.Combine(Server.MapPath("~/files"), filename);
                gift.ImageFile.SaveAs(filename);

                //genearate code
                int length = 10;

                const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                while (0 < length--)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                }

                gift.offer.Qr_Gift = res.ToString();

                _Context.Offers.Add(gift.offer);
                _Context.SaveChanges();
            }
            return RedirectToAction("addReward", "Admin");
        }


        [HttpGet]
        public ActionResult EditReward(int Id)
        {


            var id = Convert.ToInt32(Session["UserId"]);

            var gift = _Context.Offers.Single(c => c.Id == Id);
            OfferImage viewmodel = new OfferImage
            {
                offer = gift
            };

            return PartialView("EditRewardPartial", viewmodel);
        }

        [HttpPost]
        public ActionResult SaveEditReward(OfferImage reward)
        {


            // var id = Convert.ToInt32(Session["UserId"]);

            var gift = _Context.Offers.Single(c => c.Id == reward.offer.Id);
            if (reward.ImageFile != null)
            {
                string filename = Path.GetFileNameWithoutExtension(reward.ImageFile.FileName);
                string extension = Path.GetExtension(reward.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                reward.offer.imageUrl = filename;
                filename = Path.Combine(Server.MapPath("~/files"), filename);
                reward.ImageFile.SaveAs(filename);
            }
            else { reward.offer.imageUrl = gift.imageUrl; }
            gift.Description = reward.offer.Description;
            gift.imageUrl = reward.offer.imageUrl;
            gift.rewardName = reward.offer.rewardName;
            gift.requiredPoint = reward.offer.requiredPoint;
            gift.Quantity = reward.offer.Quantity;
            _Context.SaveChanges();

            return RedirectToAction("addReward", "Admin");
        }


        public ActionResult DeleteReward(int Id)
        {
            var gift = _Context.Offers.Single(c => c.Id == Id);
            _Context.Offers.Remove(gift);
            _Context.SaveChanges();
            return Content("");
        }


    }
}
