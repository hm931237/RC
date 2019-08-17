using RC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RC.ViewModels;
using WebGrease.Css.Extensions;
using System.Text;

namespace RC.Controllers
{
    public class HomeController : Controller
    {


        ApplicationDbContext DB = new ApplicationDbContext();
        public void AddHospiatals()
        {
            string[] descriptions = new string[2];
            descriptions[0] = "A hospital is a health care institution providing patient treatment with specialized medical and nursing staff and medical equipment.[1] The best - known type of hospital is the general hospital, which typically has an emergency department to treat urgent health problems ranging from fire and accident victims to a sudden illness.A district hospital typically is the major health care facility in its region, with a large number of beds for intensive care and additional beds for patients who need long - term care.Specialized hospitals include trauma centers, rehabilitation hospitals, children's hospitals, seniors'(geriatric) hospitals, and hospitals for dealing with specific medical needs such as psychiatric treatment(see psychiatric hospital) and certain disease categories.Specialized hospitals can help reduce health care costs compared to general hospitals.[2] Hospitals are classified as general, specialty, or government depending on the sources of income received.";
            descriptions[1] = "is a health care institution providing patient treatment with specialized medical and nursing staff and medical equipment.[1] The best-known type of hospital is the general hospital, which typically has an emergency department to treat urgent health problems ranging from fire and accident victims to a sudden illness. A district hospital typically is the major health care facility in its region, with a large number of beds for intensive care and additional beds for patients who need long - term care.Specialized hospitals include trauma centers, rehabilitation hospitals, children's hospitals, seniors'(geriatric) hospitals, and hospitals for dealing with specific medical needs such as psychiatric treatment(see psychiatric hospital) and certain disease categories.Specialized hospitals can help reduce health care costs compared to general hospitals.[2] Hospitals are classified as general, specialty, or government depending on the sources of income received.";
            int desc = 0;
            string[] names =
            {
           "Aaran", "Aaren", "Aarez", "Aarman", "Aaron", "Aaron-James", "Aarron", "Aaryan", "Aaryn", "Aayan", "Aazaan",
           "Abaan", "Abbas", "Abdallah", "Abdalroof", "Abdihakim", "Abdirahman", "Abdisalam", "Abdul", "Abdul-Aziz",
           "Abdulbasir", "Abdulkadir", "Abdulkarem", "Abdulkhader", "Abdullah", "Abdul-Majeed", "Abdulmalik",
           "Abdul-Rehman", "Abdur", "Abdurraheem", "Abdur-Rahman", "Abdur-Rehmaan", "Abel", "Abhinav", "Abhisumant",
           "Abid", "Abir", "Abraham", "Abu", "Abubakar", "Ace", "Adain", "Adam", "Adam-James", "Addison", "Addisson",
           "Adegbola", "Adegbolahan", "Aden", "Adenn", "Adie", "Adil", "Aditya", "Adnan", "Adrian", "Adrien", "Aedan",
           "Aedin", "Aedyn", "Aeron", "Afonso", "Ahmad", "Ahmed", "Ahmed-Aziz", "Ahoua", "Ahtasham", "Aiadan", "Aidan",
           "Aiden", "Aiden-Jack", "Aiden-Vee", "Aidian", "Aidy", "Ailin", "Aiman", "Ainsley", "Ainslie", "Airen",
           "Airidas", "Airlie", "AJ", "Ajay", "A-Jay", "Ajayraj", "Akan", "Akram", "Al", "Ala", "Alan", "Alanas",
           "Alasdair", "Alastair", "Alber", "Albert", "Albie", "Aldred", "Alec", "Aled", "Aleem", "Aleksandar",
           "Aleksander", "Aleksandr", "Aleksandrs", "Alekzander"
       };
            string[] days =
            {
           "Sunday",
           "Monday",
           "Tuesday",
           "Wednesday",
           "Thursday",
           "Friday",
           "Saturday"
       };
            TimeSpan startT = TimeSpan.FromHours(7);
            TimeSpan endT = TimeSpan.FromHours(12);
            int maxMinutes = (int)((endT - startT).TotalMinutes);

            var path = Server.MapPath("~/Content/Hospital General Information.csv");
            string filedate = System.IO.File.ReadAllText(path);
            filedate = filedate.Replace('\n', '\r');
            string[] lines = filedate.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int totalrows = lines.Length;
            int totalcols = lines[0].Split(',').Length;
            string[,] resultValues = new string[totalrows, totalcols];
            for (int row = 0; row < totalrows; row++)
            {
                string[] line_r = lines[row].Split(',');
                for (int col = 0; col < totalcols; col++)
                {
                    resultValues[row, col] = line_r[col];
                }
            }
            for (int row = 1; row < 40; row++)
            {
                if (desc == 0)
                {
                    desc = 1;
                }
                else
                {
                    desc = 0;
                }
                Random gen = new Random();
                DateTime start = new DateTime(1900, 1, 1);
                int range = (DateTime.Today - start).Days;

                Debug.WriteLine(resultValues[row, 0]);
                var user = new User
                {
                    Email = resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString() + "@gmail.com",
                    JoniedAt = DateTime.Now,
                    Password = "12345678",
                    State = 1,
                    UserTypeId = 3,
                    Username = resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString(),
                    imageUrl = row.ToString() + ".jpg"
                };
                DB.Users.Add(user);
                var organization = new Organization
                {
                    Description = descriptions[desc],
                    EstablishOrg = start.AddDays(gen.Next(range)),
                    Fax = resultValues[row, 5].Replace("\"", ""),
                    PriceRangeId = gen.Next(1, 4),
                    UsernameVerification = "",
                    businessEmail = resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString() + "@gmail.com",
                    categoryId = 1,
                    cityId = gen.Next(1, 20),
                    orgRate = 0,
                    orgnizationName = resultValues[row, 1].Replace("\"", ""),
                    ownerFirstName = names[gen.Next(1, 60)],
                    ownerLastName = names[gen.Next(1, 60)],
                    state = 0,
                    websiteUrl = resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + ".com",
                    socialLink_1 = "twitter.com/" + resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString(),
                    socialLink_2 = "www.facebook.com/" + resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString(),
                    userId = user.Id,

                };
                DB.Organizations.Add(organization);
                var phone = new Phone
                {
                    phoneNumber = resultValues[row, 7].Replace("\"", ""),
                    userId = user.Id
                };
                DB.Phones.Add(phone);
                for (int i = 0; i < gen.Next(0, days.Length); i++)
                {
                    int minutes = gen.Next(maxMinutes);
                    TimeSpan t = startT.Add(TimeSpan.FromMinutes(minutes));
                    var worktime = new WorkTime
                    {
                        Day = days[i],
                        From = new DateTime(2019, 3, 6, 8, 15, 0),
                        To = new DateTime(2019, 3, 6, 11, 12, 0),
                        OrganizationId = organization.Id,
                    };
                    DB.WorkTimes.Add(worktime);
                }

                var orgfactors = DB.Factors.Where(f => f.categoryId == 1).ToArray();
                int minId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Min();
                int maxId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Max();

                for (int i = minId, c = 0; i <= maxId; i++, c++)
                {

                    var organizationFactor = new OrganizationFactor
                    {
                        factorRate = 0,
                        organizationId = organization.Id,
                        factorId = orgfactors[c].Id
                    };
                    DB.OrganizationFactors.Add(organizationFactor);


                }
                DB.SaveChanges();
            }
        }
        public void AddClinicss()
        {
            string[] descriptions = new string[2];
            descriptions[0] = "Ambulatory surgical centers, also called outpatient surgical facilities, allow patients to receive certain surgical procedures outside a hospital environment. These environments often offer surgeries at a lower cost than hospitals while also reducing the risk of exposure to infection—since patients are there for surgery, not to recover from sickness and disease.Ambulatory surgical centers don’t provide diagnostic services or clinic hours.Instead, they take patients who have been referred for surgery by a hospital or physician—they’re designed to be “all business” when it comes to surgical care..";
            descriptions[1] = " birth center is a healthcare facility for childbirth that focuses on the midwifery model, according to the American Association of Birth Centers. They aim to create a birth environment that feels more comfortable to the mother and allows for a cost-effective, family-inclusive birth..";
            int desc = 0;
            string[] names =
            {
           "Aaran", "Aaren", "Aarez", "Aarman", "Aaron", "Aaron-James", "Aarron", "Aaryan", "Aaryn", "Aayan", "Aazaan",
           "Abaan", "Abbas", "Abdallah", "Abdalroof", "Abdihakim", "Abdirahman", "Abdisalam", "Abdul", "Abdul-Aziz",
           "Abdulbasir", "Abdulkadir", "Abdulkarem", "Abdulkhader", "Abdullah", "Abdul-Majeed", "Abdulmalik",
           "Abdul-Rehman", "Abdur", "Abdurraheem", "Abdur-Rahman", "Abdur-Rehmaan", "Abel", "Abhinav", "Abhisumant",
           "Abid", "Abir", "Abraham", "Abu", "Abubakar", "Ace", "Adain", "Adam", "Adam-James", "Addison", "Addisson",
           "Adegbola", "Adegbolahan", "Aden", "Adenn", "Adie", "Adil", "Aditya", "Adnan", "Adrian", "Adrien", "Aedan",
           "Aedin", "Aedyn", "Aeron", "Afonso", "Ahmad", "Ahmed", "Ahmed-Aziz", "Ahoua", "Ahtasham", "Aiadan", "Aidan",
           "Aiden", "Aiden-Jack", "Aiden-Vee", "Aidian", "Aidy", "Ailin", "Aiman", "Ainsley", "Ainslie", "Airen",
           "Airidas", "Airlie", "AJ", "Ajay", "A-Jay", "Ajayraj", "Akan", "Akram", "Al", "Ala", "Alan", "Alanas",
           "Alasdair", "Alastair", "Alber", "Albert", "Albie", "Aldred", "Alec", "Aled", "Aleem", "Aleksandar",
           "Aleksander", "Aleksandr", "Aleksandrs", "Alekzander"
       };
            string[] days =
            {
           "Sunday",
           "Monday",
           "Tuesday",
           "Wednesday",
           "Thursday",
           "Friday",
           "Saturday"
       };
            TimeSpan startT = TimeSpan.FromHours(7);
            TimeSpan endT = TimeSpan.FromHours(12);
            int maxMinutes = (int)((endT - startT).TotalMinutes);

            var path = Server.MapPath("~/Content/health-and-hospitals-corporation-hhc-facilities.csv");
            string filedate = System.IO.File.ReadAllText(path);
            filedate = filedate.Replace('\n', '\r');
            string[] lines = filedate.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int totalrows = lines.Length;
            int totalcols = lines[0].Split(',').Length;
            string[,] resultValues = new string[totalrows, totalcols];
            for (int row = 0; row < totalrows; row++)
            {
                string[] line_r = lines[row].Split(',');
                for (int col = 0; col < totalcols; col++)
                {
                    resultValues[row, col] = line_r[col];
                }
            }
            for (int row = 1; row < 45; row++)
            {
                if (desc == 0)
                {
                    desc = 1;
                }
                else
                {
                    desc = 0;
                }
                Random gen = new Random();
                DateTime start = new DateTime(1900, 1, 1);
                int range = (DateTime.Today - start).Days;

                //Debug.WriteLine(resultValues[row, 0]);
                var user = new User
                {
                    Email = resultValues[row, 2].Replace(" ", String.Empty).Replace("\"", "") + row.ToString() + "@gmail.com",
                    JoniedAt = DateTime.Now,
                    Password = "12345678",
                    State = 1,
                    UserTypeId = 3,
                    Username = resultValues[row, 2].Replace(" ", String.Empty).Replace("\"", "") + row.ToString(),
                    imageUrl = row.ToString() + ".jpg"
                };
                DB.Users.Add(user);
                var organization = new Organization
                {
                    Description = descriptions[desc],
                    EstablishOrg = start.AddDays(gen.Next(range)),
                    Fax = resultValues[row, 6].Replace("\"", ""),
                    PriceRangeId = gen.Next(1, 4),
                    UsernameVerification = "",
                    businessEmail = resultValues[row, 2].Replace(" ", String.Empty).Replace("\"", "") + row.ToString() + "@gmail.com",
                    categoryId = 3,
                    cityId = gen.Next(1, 20),
                    orgRate = 0,
                    orgnizationName = resultValues[row, 2].Replace("\"", ""),
                    ownerFirstName = names[gen.Next(1, 60)],
                    ownerLastName = names[gen.Next(1, 60)],
                    state = 0,
                    websiteUrl = resultValues[row, 2].Replace(" ", String.Empty).Replace("\"", "") + ".com",
                    socialLink_1 = "twitter.com/" + resultValues[row, 2].Replace(" ", String.Empty).Replace("\"", "") + row.ToString(),
                    socialLink_2 = "www.facebook.com/" + resultValues[row, 2].Replace(" ", String.Empty).Replace("\"", "") + row.ToString(),
                    userId = user.Id,

                };
                DB.Organizations.Add(organization);
                var phone = new Phone
                {
                    phoneNumber = resultValues[row, 4].Replace("\"", ""),
                    userId = user.Id
                };
                DB.Phones.Add(phone);
                for (int i = 0; i < gen.Next(0, days.Length); i++)
                {
                    int minutes = gen.Next(maxMinutes);
                    TimeSpan t = startT.Add(TimeSpan.FromMinutes(minutes));
                    var worktime = new WorkTime
                    {
                        Day = days[i],
                        From = new DateTime(2019, 3, 6, 8, 15, 0),
                        To = new DateTime(2019, 3, 6, 11, 12, 0),
                        OrganizationId = organization.Id,
                    };
                    DB.WorkTimes.Add(worktime);
                }

                var orgfactors = DB.Factors.Where(f => f.categoryId == 3).ToArray();
                int minId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Min();
                int maxId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Max();

                for (int i = minId, c = 0; i <= maxId; i++, c++)
                {

                    var organizationFactor = new OrganizationFactor
                    {
                        factorRate = 0,
                        organizationId = organization.Id,
                        factorId = orgfactors[c].Id
                    };
                    DB.OrganizationFactors.Add(organizationFactor);


                }
                DB.SaveChanges();
            }
        }
        public void AddDoctors()
        {
            string[] descriptions = new string[2];
            descriptions[0] = "Allergists/Immunologists They treat immune system disorders such as asthma, eczema, food allergies, insect sting allergies, and some autoimmune diseases..";
            descriptions[1] = "These doctors give you drugs to numb your pain or to put you under during surgery, childbirth, or other procedures. They monitor your vital signs while you’re under anesthesia...";
            int desc = 0;
            string[] names =
            {
           "Aaran", "Aaren", "Aarez", "Aarman", "Aaron", "Aaron-James", "Aarron", "Aaryan", "Aaryn", "Aayan", "Aazaan",
           "Abaan", "Abbas", "Abdallah", "Abdalroof", "Abdihakim", "Abdirahman", "Abdisalam", "Abdul", "Abdul-Aziz",
           "Abdulbasir", "Abdulkadir", "Abdulkarem", "Abdulkhader", "Abdullah", "Abdul-Majeed", "Abdulmalik",
           "Abdul-Rehman", "Abdur", "Abdurraheem", "Abdur-Rahman", "Abdur-Rehmaan", "Abel", "Abhinav", "Abhisumant",
           "Abid", "Abir", "Abraham", "Abu", "Abubakar", "Ace", "Adain", "Adam", "Adam-James", "Addison", "Addisson",
           "Adegbola", "Adegbolahan", "Aden", "Adenn", "Adie", "Adil", "Aditya", "Adnan", "Adrian", "Adrien", "Aedan",
           "Aedin", "Aedyn", "Aeron", "Afonso", "Ahmad", "Ahmed", "Ahmed-Aziz", "Ahoua", "Ahtasham", "Aiadan", "Aidan",
           "Aiden", "Aiden-Jack", "Aiden-Vee", "Aidian", "Aidy", "Ailin", "Aiman", "Ainsley", "Ainslie", "Airen",
           "Airidas", "Airlie", "AJ", "Ajay", "A-Jay", "Ajayraj", "Akan", "Akram", "Al", "Ala", "Alan", "Alanas",
           "Alasdair", "Alastair", "Alber", "Albert", "Albie", "Aldred", "Alec", "Aled", "Aleem", "Aleksandar",
           "Aleksander", "Aleksandr", "Aleksandrs", "Alekzander"
       };
            string[] days =
            {
           "Sunday",
           "Monday",
           "Tuesday",
           "Wednesday",
           "Thursday",
           "Friday",
           "Saturday"
       };
            TimeSpan startT = TimeSpan.FromHours(7);
            TimeSpan endT = TimeSpan.FromHours(12);
            int maxMinutes = (int)((endT - startT).TotalMinutes);

            var path = Server.MapPath("~/Content/health-and-hospitals-corporation-hhc-facilities.csv");
            string filedate = System.IO.File.ReadAllText(path);
            filedate = filedate.Replace('\n', '\r');
            string[] lines = filedate.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int totalrows = lines.Length;
            int totalcols = lines[0].Split(',').Length;
            string[,] resultValues = new string[totalrows, totalcols];
            for (int row = 0; row < totalrows; row++)
            {
                string[] line_r = lines[row].Split(',');
                for (int col = 0; col < totalcols; col++)
                {
                    resultValues[row, col] = line_r[col];
                }
            }
            for (int row = 1; row < 39; row++)
            {
                if (desc == 0)
                {
                    desc = 1;
                }
                else
                {
                    desc = 0;
                }
                Random gen = new Random();
                DateTime start = new DateTime(1900, 1, 1);
                int range = (DateTime.Today - start).Days;

                //Debug.WriteLine(resultValues[row, 0]);
                var fname = names[gen.Next(1, 60)];
                var lname = names[gen.Next(1, 60)];
                var user = new User
                {
                    Email = fname + '_' + lname + row.ToString() + "@gmail.com",
                    JoniedAt = DateTime.Now,
                    Password = "12345678",
                    State = 1,
                    UserTypeId = 3,
                    Username = fname + '_' + lname + row.ToString(),
                    imageUrl = row.ToString() + ".jpg"
                };
                DB.Users.Add(user);
                var organization = new Organization
                {
                    Description = descriptions[desc],
                    EstablishOrg = start.AddDays(gen.Next(range)),
                    Fax = resultValues[row, 6].Replace("\"", ""),
                    PriceRangeId = gen.Next(1, 4),
                    UsernameVerification = "",
                    businessEmail = fname + '_' + lname + row.ToString() + "@gmail.com",
                    categoryId = 2,
                    cityId = gen.Next(1, 20),
                    orgRate = 0,
                    orgnizationName = fname + ' ' + lname,
                    ownerFirstName = fname,
                    ownerLastName = lname,
                    state = 0,
                    websiteUrl = "www.vezeeta.com / en / dr / Clinic - " + fname + '-' + lname + '-' + row.ToString(),
                    socialLink_1 = "twitter.com/" + fname + lname + row.ToString(),
                    socialLink_2 = "www.facebook.com/" + fname + lname + row.ToString(),
                    userId = user.Id,

                };
                DB.Organizations.Add(organization);
                var phone = new Phone
                {
                    phoneNumber = resultValues[row, 4].Replace("\"", ""),
                    userId = user.Id
                };
                DB.Phones.Add(phone);
                for (int i = 0; i < gen.Next(0, days.Length); i++)
                {
                    int minutes = gen.Next(maxMinutes);
                    TimeSpan t = startT.Add(TimeSpan.FromMinutes(minutes));
                    var worktime = new WorkTime
                    {
                        Day = days[i],
                        From = new DateTime(2019, 3, 6, 8, 15, 0),
                        To = new DateTime(2019, 3, 6, 11, 12, 0),
                        OrganizationId = organization.Id,
                    };
                    DB.WorkTimes.Add(worktime);
                }

                var orgfactors = DB.Factors.Where(f => f.categoryId == 2).ToArray();
                int minId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Min();
                int maxId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Max();

                for (int i = minId, c = 0; i <= maxId; i++, c++)
                {

                    var organizationFactor = new OrganizationFactor
                    {
                        factorRate = 0,
                        organizationId = organization.Id,
                        factorId = orgfactors[c].Id
                    };
                    DB.OrganizationFactors.Add(organizationFactor);


                }
                DB.SaveChanges();
            }
        }
        public void AddHighSchools()
        {
            string[] descriptions = new string[2];
            descriptions[0] = "Founded in 1778, Phillips Academy, also known as Andover, is an independent, coeducational secondary school with an expansive worldview and a legacy of academic excellence. It is a high school that stands ready to meet, match, and expand the minds and passions of some of the brightest students in the nation and the world. It is a place of great tradition and innovation. Because of its size, Andover offers enormous depth and breadth of activity and opportunity while still feeling like a personal place. With a roster of over 300 courses, 150+ electives, plus independent study and study abroad, the opportunities for growth are limitless. Andover’s “need blind” admission policy is one of the most comprehensive and generous among secondary schools..";
            descriptions[1] = "Harvard-Westlake is an independent, coeducational and college preparatory school for grades 7-12, located in Los Angeles, California. Harvard-Westlake strives to be a diverse and inclusive community united by the joyful pursuit of educational excellence, living and learning with integrity, and purpose beyond ourselves..";
            int desc = 0;
            string[] names =
            {
           "Aaran", "Aaren", "Aarez", "Aarman", "Aaron", "Aaron-James", "Aarron", "Aaryan", "Aaryn", "Aayan", "Aazaan",
           "Abaan", "Abbas", "Abdallah", "Abdalroof", "Abdihakim", "Abdirahman", "Abdisalam", "Abdul", "Abdul-Aziz",
           "Abdulbasir", "Abdulkadir", "Abdulkarem", "Abdulkhader", "Abdullah", "Abdul-Majeed", "Abdulmalik",
           "Abdul-Rehman", "Abdur", "Abdurraheem", "Abdur-Rahman", "Abdur-Rehmaan", "Abel", "Abhinav", "Abhisumant",
           "Abid", "Abir", "Abraham", "Abu", "Abubakar", "Ace", "Adain", "Adam", "Adam-James", "Addison", "Addisson",
           "Adegbola", "Adegbolahan", "Aden", "Adenn", "Adie", "Adil", "Aditya", "Adnan", "Adrian", "Adrien", "Aedan",
           "Aedin", "Aedyn", "Aeron", "Afonso", "Ahmad", "Ahmed", "Ahmed-Aziz", "Ahoua", "Ahtasham", "Aiadan", "Aidan",
           "Aiden", "Aiden-Jack", "Aiden-Vee", "Aidian", "Aidy", "Ailin", "Aiman", "Ainsley", "Ainslie", "Airen",
           "Airidas", "Airlie", "AJ", "Ajay", "A-Jay", "Ajayraj", "Akan", "Akram", "Al", "Ala", "Alan", "Alanas",
           "Alasdair", "Alastair", "Alber", "Albert", "Albie", "Aldred", "Alec", "Aled", "Aleem", "Aleksandar",
           "Aleksander", "Aleksandr", "Aleksandrs", "Alekzander"
       };
            string[] days =
            {
           "Sunday",
           "Monday",
           "Tuesday",
           "Wednesday",
           "Thursday",
           "Friday",
           "Saturday"
       };
            TimeSpan startT = TimeSpan.FromHours(7);
            TimeSpan endT = TimeSpan.FromHours(12);
            int maxMinutes = (int)((endT - startT).TotalMinutes);

            var path = Server.MapPath("~/Content/MA_Public_Schools_2017.csv");
            string filedate = System.IO.File.ReadAllText(path);
            filedate = filedate.Replace('\n', '\r');
            string[] lines = filedate.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int totalrows = lines.Length;
            int totalcols = lines[0].Split(',').Length - 10;
            string[,] resultValues = new string[100, 100];
            for (int row = 0; row < 70; row++)
            {
                string[] line_r = lines[row].Split(',');
                for (int col = 0; col < 70; col++)
                {
                    resultValues[row, col] = line_r[col];
                }
            }
            for (int row = 1; row < 60; row++)
            {
                if (desc == 0)
                {
                    desc = 1;
                }
                else
                {
                    desc = 0;
                }
                Random gen = new Random();
                DateTime start = new DateTime(1900, 1, 1);
                int range = (DateTime.Today - start).Days;

                Debug.WriteLine(resultValues[row, 0]);
                var user = new User
                {
                    Email = resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString() + "@gmail.com",
                    JoniedAt = DateTime.Now,
                    Password = "12345678",
                    State = 1,
                    UserTypeId = 3,
                    Username = resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString(),
                    imageUrl = row.ToString() + ".jpg"
                };
                DB.Users.Add(user);
                var organization = new Organization
                {
                    Description = descriptions[desc],
                    EstablishOrg = start.AddDays(gen.Next(range)),
                    Fax = resultValues[row, 11].Replace("\"", ""),
                    PriceRangeId = gen.Next(1, 4),
                    UsernameVerification = "",
                    businessEmail = resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString() + "@gmail.com",
                    categoryId = 4,
                    cityId = gen.Next(1, 20),
                    orgRate = 0,
                    orgnizationName = resultValues[row, 1].Replace("\"", ""),
                    ownerFirstName = names[gen.Next(1, 60)],
                    ownerLastName = names[gen.Next(1, 60)],
                    state = 0,
                    websiteUrl = resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + ".com",
                    socialLink_1 = "twitter.com/" + resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString(),
                    socialLink_2 = "www.facebook.com/" + resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString(),
                    userId = user.Id,

                };
                DB.Organizations.Add(organization);
                var phone = new Phone
                {
                    phoneNumber = resultValues[row, 10].Replace("\"", ""),
                    userId = user.Id
                };
                DB.Phones.Add(phone);
                for (int i = 0; i < gen.Next(0, days.Length); i++)
                {
                    int minutes = gen.Next(maxMinutes);
                    TimeSpan t = startT.Add(TimeSpan.FromMinutes(minutes));
                    var worktime = new WorkTime
                    {
                        Day = days[i],
                        From = new DateTime(2019, 3, 6, 8, 15, 0),
                        To = new DateTime(2019, 3, 6, 11, 12, 0),
                        OrganizationId = organization.Id,
                    };
                    DB.WorkTimes.Add(worktime);
                }

                var orgfactors = DB.Factors.Where(f => f.categoryId == 4).ToArray();
                int minId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Min();
                int maxId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Max();

                for (int i = minId, c = 0; i <= maxId; i++, c++)
                {

                    var organizationFactor = new OrganizationFactor
                    {
                        factorRate = 0,
                        organizationId = organization.Id,
                        factorId = orgfactors[c].Id
                    };
                    DB.OrganizationFactors.Add(organizationFactor);


                }
                DB.SaveChanges();
            }
        }
        public void AddUniversities()
        {
            string[] descriptions = new string[2];
            descriptions[0] = "Founded in 1851 in Tahlequah, OK, Northeastern State University (NSU) offers 54 undergraduate and 24 graduate programs in fields like elementary education, criminal justice, and psychology. The 5,500 students complete coursework at one of three NSU campuses in the state, but NSU has made significant investments in online learning. Nearly 1,300 learners enroll in distance courses, students can complete a certificate, bachelor's, or master's degree in online or blended formats. Degree seekers can apply for numerous scholarships and grants, thereby significantly reducing the cost and making NSU an affordable university...";
            descriptions[1] = "Cal State Fullerton (CSF), located in sunny Southern California, features nine schools across four different campuses and online. The diverse student body of nearly 40,000 have access to 110 undergraduate and graduate programs, which includes a doctorate in education and a doctor in nursing practice. In-state students pay some of the lowest tuition rates in the country, and the school distributes $5.8 million in loans, grants, and scholarships to learners each year. Additionally, CSF offers several online certificate and degree completion programs...";
            int desc = 0;
            string[] names =
            {
           "Aaran", "Aaren", "Aarez", "Aarman", "Aaron", "Aaron-James", "Aarron", "Aaryan", "Aaryn", "Aayan", "Aazaan",
           "Abaan", "Abbas", "Abdallah", "Abdalroof", "Abdihakim", "Abdirahman", "Abdisalam", "Abdul", "Abdul-Aziz",
           "Abdulbasir", "Abdulkadir", "Abdulkarem", "Abdulkhader", "Abdullah", "Abdul-Majeed", "Abdulmalik",
           "Abdul-Rehman", "Abdur", "Abdurraheem", "Abdur-Rahman", "Abdur-Rehmaan", "Abel", "Abhinav", "Abhisumant",
           "Abid", "Abir", "Abraham", "Abu", "Abubakar", "Ace", "Adain", "Adam", "Adam-James", "Addison", "Addisson",
           "Adegbola", "Adegbolahan", "Aden", "Adenn", "Adie", "Adil", "Aditya", "Adnan", "Adrian", "Adrien", "Aedan",
           "Aedin", "Aedyn", "Aeron", "Afonso", "Ahmad", "Ahmed", "Ahmed-Aziz", "Ahoua", "Ahtasham", "Aiadan", "Aidan",
           "Aiden", "Aiden-Jack", "Aiden-Vee", "Aidian", "Aidy", "Ailin", "Aiman", "Ainsley", "Ainslie", "Airen",
           "Airidas", "Airlie", "AJ", "Ajay", "A-Jay", "Ajayraj", "Akan", "Akram", "Al", "Ala", "Alan", "Alanas",
           "Alasdair", "Alastair", "Alber", "Albert", "Albie", "Aldred", "Alec", "Aled", "Aleem", "Aleksandar",
           "Aleksander", "Aleksandr", "Aleksandrs", "Alekzander"
       };
            string[] days =
            {
           "Sunday",
           "Monday",
           "Tuesday",
           "Wednesday",
           "Thursday",
           "Friday",
           "Saturday"
       };
            TimeSpan startT = TimeSpan.FromHours(7);
            TimeSpan endT = TimeSpan.FromHours(12);
            int maxMinutes = (int)((endT - startT).TotalMinutes);

            var path = Server.MapPath("~/Content/Accreditation_04_2017.csv");
            string filedate = System.IO.File.ReadAllText(path);
            filedate = filedate.Replace('\n', '\r');
            string[] lines = filedate.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int totalrows = lines.Length;
            int totalcols = lines[0].Split(',').Length;
            string[,] resultValues = new string[totalrows, totalcols];
            for (int row = 0; row < totalrows; row++)
            {
                string[] line_r = lines[row].Split(',');
                for (int col = 0; col < totalcols; col++)
                {
                    resultValues[row, col] = line_r[col];
                }
            }
            for (int row = 1; row < 42; row++)
            {
                if (desc == 0)
                {
                    desc = 1;
                }
                else
                {
                    desc = 0;
                }
                Random gen = new Random();
                DateTime start = new DateTime(1900, 1, 1);
                int range = (DateTime.Today - start).Days;

                Debug.WriteLine(resultValues[row, 0]);
                var user = new User
                {
                    Email = resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString() + "@gmail.com",
                    JoniedAt = DateTime.Now,
                    Password = "12345678",
                    State = 1,
                    UserTypeId = 3,
                    Username = resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString(),
                    imageUrl = row.ToString() + ".jpg"
                };
                DB.Users.Add(user);
                var organization = new Organization
                {
                    Description = descriptions[desc],
                    EstablishOrg = start.AddDays(gen.Next(range)),
                    Fax = resultValues[row, 5].Replace("\"", ""),
                    PriceRangeId = gen.Next(1, 4),
                    UsernameVerification = "",
                    businessEmail = resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString() + "@gmail.com",
                    categoryId = 5,
                    cityId = gen.Next(1, 20),
                    orgRate = 0,
                    orgnizationName = resultValues[row, 1].Replace("\"", ""),
                    ownerFirstName = names[gen.Next(1, 60)],
                    ownerLastName = names[gen.Next(1, 60)],
                    state = 0,
                    websiteUrl = resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + ".com",
                    socialLink_1 = "twitter.com/" + resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString(),
                    socialLink_2 = "www.facebook.com/" + resultValues[row, 1].Replace(" ", String.Empty).Replace("\"", "") + row.ToString(),
                    userId = user.Id,

                };
                DB.Organizations.Add(organization);
                var phone = new Phone
                {
                    phoneNumber = resultValues[row, 6].Replace("\"", ""),
                    userId = user.Id
                };
                DB.Phones.Add(phone);
                for (int i = 0; i < gen.Next(0, days.Length); i++)
                {
                    int minutes = gen.Next(maxMinutes);
                    TimeSpan t = startT.Add(TimeSpan.FromMinutes(minutes));
                    var worktime = new WorkTime
                    {
                        Day = days[i],
                        From = new DateTime(2019, 3, 6, 8, 15, 0),
                        To = new DateTime(2019, 3, 6, 11, 12, 0),
                        OrganizationId = organization.Id,
                    };
                    DB.WorkTimes.Add(worktime);
                }

                var orgfactors = DB.Factors.Where(f => f.categoryId == 5).ToArray();
                int minId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Min();
                int maxId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Max();

                for (int i = minId, c = 0; i <= maxId; i++, c++)
                {

                    var organizationFactor = new OrganizationFactor
                    {
                        factorRate = 0,
                        organizationId = organization.Id,
                        factorId = orgfactors[c].Id
                    };
                    DB.OrganizationFactors.Add(organizationFactor);


                }
                DB.SaveChanges();
            }
        }
        public void AddTeachers()
        {
            string[] descriptions = new string[2];
            descriptions[0] = "Science teacher, has an italian background...";
            descriptions[1] = "Angela Touva is a certified Law of Attraction Life Coach. Her education and careers have encompassed the fields of psychology, human evolution, mathematics, advocacy, and human performance. These skills have accumulated into a unique combination of perspective, experience, and knowledge that she now offers to her coaching clients....";
            int desc = 0;
            string[] names =
            {
           "Aaran", "Aaren", "Aarez", "Aarman", "Aaron", "Aaron-James", "Aarron", "Aaryan", "Aaryn", "Aayan", "Aazaan",
           "Abaan", "Abbas", "Abdallah", "Abdalroof", "Abdihakim", "Abdirahman", "Abdisalam", "Abdul", "Abdul-Aziz",
           "Abdulbasir", "Abdulkadir", "Abdulkarem", "Abdulkhader", "Abdullah", "Abdul-Majeed", "Abdulmalik",
           "Abdul-Rehman", "Abdur", "Abdurraheem", "Abdur-Rahman", "Abdur-Rehmaan", "Abel", "Abhinav", "Abhisumant",
           "Abid", "Abir", "Abraham", "Abu", "Abubakar", "Ace", "Adain", "Adam", "Adam-James", "Addison", "Addisson",
           "Adegbola", "Adegbolahan", "Aden", "Adenn", "Adie", "Adil", "Aditya", "Adnan", "Adrian", "Adrien", "Aedan",
           "Aedin", "Aedyn", "Aeron", "Afonso", "Ahmad", "Ahmed", "Ahmed-Aziz", "Ahoua", "Ahtasham", "Aiadan", "Aidan",
           "Aiden", "Aiden-Jack", "Aiden-Vee", "Aidian", "Aidy", "Ailin", "Aiman", "Ainsley", "Ainslie", "Airen",
           "Airidas", "Airlie", "AJ", "Ajay", "A-Jay", "Ajayraj", "Akan", "Akram", "Al", "Ala", "Alan", "Alanas",
           "Alasdair", "Alastair", "Alber", "Albert", "Albie", "Aldred", "Alec", "Aled", "Aleem", "Aleksandar",
           "Aleksander", "Aleksandr", "Aleksandrs", "Alekzander"
       };
            string[] days =
            {
           "Sunday",
           "Monday",
           "Tuesday",
           "Wednesday",
           "Thursday",
           "Friday",
           "Saturday"
       };
            TimeSpan startT = TimeSpan.FromHours(7);
            TimeSpan endT = TimeSpan.FromHours(12);
            int maxMinutes = (int)((endT - startT).TotalMinutes);

            var path = Server.MapPath("~/Content/health-and-hospitals-corporation-hhc-facilities.csv");
            string filedate = System.IO.File.ReadAllText(path);
            filedate = filedate.Replace('\n', '\r');
            string[] lines = filedate.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int totalrows = lines.Length;
            int totalcols = lines[0].Split(',').Length;
            string[,] resultValues = new string[totalrows, totalcols];
            for (int row = 0; row < totalrows; row++)
            {
                string[] line_r = lines[row].Split(',');
                for (int col = 0; col < totalcols; col++)
                {
                    resultValues[row, col] = line_r[col];
                }
            }
            for (int row = 1; row < 35; row++)
            {
                if (desc == 0)
                {
                    desc = 1;
                }
                else
                {
                    desc = 0;
                }
                Random gen = new Random();
                DateTime start = new DateTime(1900, 1, 1);
                int range = (DateTime.Today - start).Days;

                //Debug.WriteLine(resultValues[row, 0]);
                var fname = names[gen.Next(1, 60)];
                var lname = names[gen.Next(1, 60)];
                var user = new User
                {
                    Email = fname + '_' + lname + row.ToString() + "@gmail.com",
                    JoniedAt = DateTime.Now,
                    Password = "12345678",
                    State = 1,
                    UserTypeId = 3,
                    Username = fname + '_' + lname + row.ToString(),
                    imageUrl = row.ToString() + ".jpg"
                };
                DB.Users.Add(user);
                var organization = new Organization
                {
                    Description = descriptions[desc],
                    EstablishOrg = start.AddDays(gen.Next(range)),
                    Fax = resultValues[row, 6].Replace("\"", ""),
                    PriceRangeId = gen.Next(1, 4),
                    UsernameVerification = "",
                    businessEmail = fname + '_' + lname + row.ToString() + "@gmail.com",
                    categoryId = 6,
                    cityId = gen.Next(1, 20),
                    orgRate = 0,
                    orgnizationName = fname + ' ' + lname,
                    ownerFirstName = fname,
                    ownerLastName = lname,
                    state = 0,
                    websiteUrl = "www.vezeeta.com / en / dr / Clinic - " + fname + '-' + lname + '-' + row.ToString(),
                    socialLink_1 = "twitter.com/" + fname + lname + row.ToString(),
                    socialLink_2 = "www.facebook.com/" + fname + lname + row.ToString(),
                    userId = user.Id,

                };
                DB.Organizations.Add(organization);
                var phone = new Phone
                {
                    phoneNumber = resultValues[row, 4].Replace("\"", ""),
                    userId = user.Id
                };
                DB.Phones.Add(phone);
                for (int i = 0; i < gen.Next(0, days.Length); i++)
                {
                    int minutes = gen.Next(maxMinutes);
                    TimeSpan t = startT.Add(TimeSpan.FromMinutes(minutes));
                    var worktime = new WorkTime
                    {
                        Day = days[i],
                        From = new DateTime(2019, 3, 6, 8, 15, 0),
                        To = new DateTime(2019, 3, 6, 11, 12, 0),
                        OrganizationId = organization.Id,
                    };
                    DB.WorkTimes.Add(worktime);
                }

                var orgfactors = DB.Factors.Where(f => f.categoryId == 6).ToArray();
                int minId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Min();
                int maxId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Max();

                for (int i = minId, c = 0; i <= maxId; i++, c++)
                {

                    var organizationFactor = new OrganizationFactor
                    {
                        factorRate = 0,
                        organizationId = organization.Id,
                        factorId = orgfactors[c].Id
                    };
                    DB.OrganizationFactors.Add(organizationFactor);


                }
                DB.SaveChanges();
            }
        }
        public void AddClubs()
        {
            string[] descriptions = new string[2];
            descriptions[0] = " is a professional football club based in Old Trafford, Greater Manchester, England, that competes in the Premier League, the top flight of English football. Nicknamed 'the Red Devils', the club was founded as Newton Heath LYR Football Club in 1878, changed its name to Manchester United in 1902 and moved to its current stadium, Old Trafford, in 1910....";
            descriptions[1] = "The Chicago Bulls are an American professional basketball team based in Chicago, Illinois. The Bulls compete in the National Basketball Association as a member of the league's Eastern Conference Central Division.....";
            int desc = 0;
            string[] names =
            {
           "Aaran", "Aaren", "Aarez", "Aarman", "Aaron", "Aaron-James", "Aarron", "Aaryan", "Aaryn", "Aayan", "Aazaan",
           "Abaan", "Abbas", "Abdallah", "Abdalroof", "Abdihakim", "Abdirahman", "Abdisalam", "Abdul", "Abdul-Aziz",
           "Abdulbasir", "Abdulkadir", "Abdulkarem", "Abdulkhader", "Abdullah", "Abdul-Majeed", "Abdulmalik",
           "Abdul-Rehman", "Abdur", "Abdurraheem", "Abdur-Rahman", "Abdur-Rehmaan", "Abel", "Abhinav", "Abhisumant",
           "Abid", "Abir", "Abraham", "Abu", "Abubakar", "Ace", "Adain", "Adam", "Adam-James", "Addison", "Addisson",
           "Adegbola", "Adegbolahan", "Aden", "Adenn", "Adie", "Adil", "Aditya", "Adnan", "Adrian", "Adrien", "Aedan",
           "Aedin", "Aedyn", "Aeron", "Afonso", "Ahmad", "Ahmed", "Ahmed-Aziz", "Ahoua", "Ahtasham", "Aiadan", "Aidan",
           "Aiden", "Aiden-Jack", "Aiden-Vee", "Aidian", "Aidy", "Ailin", "Aiman", "Ainsley", "Ainslie", "Airen",
           "Airidas", "Airlie", "AJ", "Ajay", "A-Jay", "Ajayraj", "Akan", "Akram", "Al", "Ala", "Alan", "Alanas",
           "Alasdair", "Alastair", "Alber", "Albert", "Albie", "Aldred", "Alec", "Aled", "Aleem", "Aleksandar",
           "Aleksander", "Aleksandr", "Aleksandrs", "Alekzander"
       };
            string[] days =
            {
           "Sunday",
           "Monday",
           "Tuesday",
           "Wednesday",
           "Thursday",
           "Friday",
           "Saturday"
       };
            TimeSpan startT = TimeSpan.FromHours(7);
            TimeSpan endT = TimeSpan.FromHours(12);
            int maxMinutes = (int)((endT - startT).TotalMinutes);

            var path = Server.MapPath("~/Content/epl_1819.csv");
            string filedate = System.IO.File.ReadAllText(path);
            filedate = filedate.Replace('\n', '\r');
            string[] lines = filedate.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int totalrows = lines.Length;
            int totalcols = lines[0].Split(',').Length;
            string[,] resultValues = new string[totalrows, totalcols];
            for (int row = 0; row < totalrows; row++)
            {
                string[] line_r = lines[row].Split(',');
                for (int col = 0; col < totalcols; col++)
                {
                    resultValues[row, col] = line_r[col];
                }
            }
            for (int row = 1; row < 21; row++)
            {
                if (desc == 0)
                {
                    desc = 1;
                }
                else
                {
                    desc = 0;
                }
                Random gen = new Random();
                DateTime start = new DateTime(1900, 1, 1);
                int range = (DateTime.Today - start).Days;

                //Debug.WriteLine(resultValues[row, 0]);
                var fname = names[gen.Next(1, 60)];
                var lname = names[gen.Next(1, 60)];
                var user = new User
                {
                    Email = resultValues[row, 0].Replace(" ", String.Empty).Replace("\"", "") + row.ToString() + "@gmail.com",
                    JoniedAt = DateTime.Now,
                    Password = "12345678",
                    State = 1,
                    UserTypeId = 3,
                    Username = resultValues[row, 0].Replace(" ", String.Empty).Replace("\"", ""),
                    imageUrl = row.ToString() + ".jpg"
                };
                DB.Users.Add(user);
                var organization = new Organization
                {
                    Description = descriptions[desc],
                    EstablishOrg = start.AddDays(gen.Next(range)),
                    Fax = resultValues[row, 16].Replace("\"", ""),
                    PriceRangeId = gen.Next(1, 4),
                    UsernameVerification = "",
                    businessEmail = resultValues[row, 0].Replace(" ", String.Empty).Replace("\"", "") + "@gmail.com",
                    categoryId = 7,
                    cityId = gen.Next(1, 20),
                    orgRate = 0,
                    orgnizationName = resultValues[row, 0].Replace(" ", String.Empty).Replace("\"", ""),
                    ownerFirstName = fname,
                    ownerLastName = lname,
                    state = 0,
                    websiteUrl = "www." + resultValues[row, 0].Replace(" ", String.Empty).Replace("\"", "") + ".com /",

                    socialLink_1 = "twitter.com/" + resultValues[row, 0].Replace(" ", String.Empty).Replace("\"", ""),
                    socialLink_2 = "www.facebook.com/" + resultValues[row, 0].Replace(" ", String.Empty).Replace("\"", ""),
                    userId = user.Id,

                };
                DB.Organizations.Add(organization);
                var phone = new Phone
                {
                    phoneNumber = resultValues[row, 17].Replace("\"", ""),
                    userId = user.Id
                };
                DB.Phones.Add(phone);
                for (int i = 0; i < gen.Next(0, days.Length); i++)
                {
                    int minutes = gen.Next(maxMinutes);
                    TimeSpan t = startT.Add(TimeSpan.FromMinutes(minutes));
                    var worktime = new WorkTime
                    {
                        Day = days[i],
                        From = new DateTime(2019, 3, 6, 8, 15, 0),
                        To = new DateTime(2019, 3, 6, 11, 12, 0),
                        OrganizationId = organization.Id,
                    };
                    DB.WorkTimes.Add(worktime);
                }

                var orgfactors = DB.Factors.Where(f => f.categoryId == 7).ToArray();
                int minId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Min();
                int maxId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Max();

                for (int i = minId, c = 0; i <= maxId; i++, c++)
                {

                    var organizationFactor = new OrganizationFactor
                    {
                        factorRate = 0,
                        organizationId = organization.Id,
                        factorId = orgfactors[c].Id
                    };
                    DB.OrganizationFactors.Add(organizationFactor);


                }
                DB.SaveChanges();
            }
        }
        public void AddCoaches()
        {
            string[] descriptions = new string[2];
            descriptions[0] = " is a Portuguese professional football coach and former player who most recently served as manager of English club Manchester United. As a manager, Mourinho has won 25 major honours, making him one of the most successful managers of all time.[2] He was named Portuguese Coach of the Century by the Portuguese Football Federation (FPF) in 2015,[3] and was the first coach to spend more than £1 billion on transfers.[4] Due to his tactical knowledge, charismatic and controversial personality, and what his opponents regard as an emphasis on getting results over playing beautiful football, he has drawn comparisons, by both admirers and critics, with Argentine manager Helenio Herrera.[5][6] He is regarded as one of the greatest managers of all time...";
            descriptions[1] = "Passionate about health, nutrition, fitness and wellbeing, personal training was a natural career path for me. Today, I am an independent London based personal trainer and an online nutritional consultant based near Old Street, Moorgate and Liverpool Street stations, offering both one to one personal training and online tailored nutrition and training programmes for fat loss, muscle gain and improved performance.....";
            int desc = 0;
            string[] names =
            {
           "Aaran", "Aaren", "Aarez", "Aarman", "Aaron", "Aaron-James", "Aarron", "Aaryan", "Aaryn", "Aayan", "Aazaan",
           "Abaan", "Abbas", "Abdallah", "Abdalroof", "Abdihakim", "Abdirahman", "Abdisalam", "Abdul", "Abdul-Aziz",
           "Abdulbasir", "Abdulkadir", "Abdulkarem", "Abdulkhader", "Abdullah", "Abdul-Majeed", "Abdulmalik",
           "Abdul-Rehman", "Abdur", "Abdurraheem", "Abdur-Rahman", "Abdur-Rehmaan", "Abel", "Abhinav", "Abhisumant",
           "Abid", "Abir", "Abraham", "Abu", "Abubakar", "Ace", "Adain", "Adam", "Adam-James", "Addison", "Addisson",
           "Adegbola", "Adegbolahan", "Aden", "Adenn", "Adie", "Adil", "Aditya", "Adnan", "Adrian", "Adrien", "Aedan",
           "Aedin", "Aedyn", "Aeron", "Afonso", "Ahmad", "Ahmed", "Ahmed-Aziz", "Ahoua", "Ahtasham", "Aiadan", "Aidan",
           "Aiden", "Aiden-Jack", "Aiden-Vee", "Aidian", "Aidy", "Ailin", "Aiman", "Ainsley", "Ainslie", "Airen",
           "Airidas", "Airlie", "AJ", "Ajay", "A-Jay", "Ajayraj", "Akan", "Akram", "Al", "Ala", "Alan", "Alanas",
           "Alasdair", "Alastair", "Alber", "Albert", "Albie", "Aldred", "Alec", "Aled", "Aleem", "Aleksandar",
           "Aleksander", "Aleksandr", "Aleksandrs", "Alekzander"
       };
            string[] days =
            {
           "Sunday",
           "Monday",
           "Tuesday",
           "Wednesday",
           "Thursday",
           "Friday",
           "Saturday"
       };
            TimeSpan startT = TimeSpan.FromHours(7);
            TimeSpan endT = TimeSpan.FromHours(12);
            int maxMinutes = (int)((endT - startT).TotalMinutes);

            var path = Server.MapPath("~/Content/Hospital General Information.csv");
            string filedate = System.IO.File.ReadAllText(path);
            filedate = filedate.Replace('\n', '\r');
            string[] lines = filedate.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int totalrows = lines.Length;
            int totalcols = lines[0].Split(',').Length;
            string[,] resultValues = new string[totalrows, totalcols];
            for (int row = 0; row < totalrows; row++)
            {
                string[] line_r = lines[row].Split(',');
                for (int col = 0; col < totalcols; col++)
                {
                    resultValues[row, col] = line_r[col];
                }
            }
            for (int row = 1; row < 44; row++)
            {
                if (desc == 0)
                {
                    desc = 1;
                }
                else
                {
                    desc = 0;
                }
                Random gen = new Random();
                DateTime start = new DateTime(1900, 1, 1);
                int range = (DateTime.Today - start).Days;

                //Debug.WriteLine(resultValues[row, 0]);
                var fname = names[gen.Next(1, 60)];
                var lname = names[gen.Next(1, 60)];
                var user = new User
                {
                    Email = fname + '_' + lname + row.ToString() + "@gmail.com",
                    JoniedAt = DateTime.Now,
                    Password = "12345678",
                    State = 1,
                    UserTypeId = 3,
                    Username = fname + '_' + lname + row.ToString(),
                    imageUrl = row.ToString() + ".jpg"
                };
                DB.Users.Add(user);
                var organization = new Organization
                {
                    Description = descriptions[desc],
                    EstablishOrg = start.AddDays(gen.Next(range)),
                    Fax = resultValues[row, 5].Replace("\"", ""),
                    PriceRangeId = gen.Next(1, 4),
                    UsernameVerification = "",
                    businessEmail = fname + '_' + lname + row.ToString() + "@gmail.com",
                    categoryId = 8,
                    cityId = gen.Next(1, 20),
                    orgRate = 0,
                    orgnizationName = fname + ' ' + lname,
                    ownerFirstName = fname,
                    ownerLastName = lname,
                    state = 0,
                    websiteUrl = "www.vezeeta.com / en / dr / Clinic - " + fname + '-' + lname + '-' + row.ToString(),
                    socialLink_1 = "twitter.com/" + fname + lname + row.ToString(),
                    socialLink_2 = "www.facebook.com/" + fname + lname + row.ToString(),
                    userId = user.Id,

                };
                DB.Organizations.Add(organization);
                var phone = new Phone
                {
                    phoneNumber = resultValues[row, 7].Replace("\"", ""),
                    userId = user.Id
                };
                DB.Phones.Add(phone);
                for (int i = 0; i < gen.Next(0, days.Length); i++)
                {
                    int minutes = gen.Next(maxMinutes);
                    TimeSpan t = startT.Add(TimeSpan.FromMinutes(minutes));
                    var worktime = new WorkTime
                    {
                        Day = days[i],
                        From = new DateTime(2019, 3, 6, 8, 15, 0),
                        To = new DateTime(2019, 3, 6, 11, 12, 0),
                        OrganizationId = organization.Id,
                    };
                    DB.WorkTimes.Add(worktime);
                }

                var orgfactors = DB.Factors.Where(f => f.categoryId == 8).ToArray();
                int minId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Min();
                int maxId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Max();

                for (int i = minId, c = 0; i <= maxId; i++, c++)
                {

                    var organizationFactor = new OrganizationFactor
                    {
                        factorRate = 0,
                        organizationId = organization.Id,
                        factorId = orgfactors[c].Id
                    };
                    DB.OrganizationFactors.Add(organizationFactor);


                }
                DB.SaveChanges();
            }
        }
        public void AddGyms()
        {
            string[] descriptions = new string[2];
            descriptions[0] = "At Gold's Gym you'll find all of the latest cardio and strength training equipment along with a dynamic group exercise program that includes classes like yoga, group cycling, mixed martial arts, muscle endurance training and pilates. Most importantly, you'll find an energetic, supportive environment full of all kinds of people who are committed to achieving their goals....";
            descriptions[1] = "Today, Gold's Gym has expanded its fitness profile to offer all of the latest equipment and services including, group exercise, personal training, cardiovascular equipment, spinning, Pilates and yoga, while maintaining its core weight lifting tradition. With over 3 million members world wide and over 650 locations, Gold's Gym continues to change lives by helping people achieve their individual potential. Gold's Gym is the preferred gym to the entertainment industry, amateur and professional athletes, and anyone else who is serious about fitness.The Authority on Fitness Since 1965.Gold's Gym has been the authority on fitness since 1965 dating back to the original Gold's Gym in Venice, California.It was the place for serious fitness. Gold's Gym quickly became known as The Mecca of Bodybuilding. In 1977, Gold's Gym received international attention when it was featured in the movie Pumping Iron that starred Arnold Schwarzenegger and Lou Ferrigno.From that first gym in Venice, Gold's Gym has become the largest co-ed gym chain in the world.....";

            int desc = 0;
            string[] gyms =
            {
                "DIY Workout Machine",
                "Eco Fitness Design",
                "Muscle Feast",
                "Muscle Maniac",
                "Aesthetic Den",
                "Chasing Aesthetic",
                "Jungle Fitness",
                "C3 Fitness",
                "Fitness Essentials",
                "Fit Body Boot Camp",
                "Corenetic Gym",
                "Infliction Fitness",
                "AbsoluteFit",
                "Curl Fitness"
            };

            string[] names =
            {
           "Aaran", "Aaren", "Aarez", "Aarman", "Aaron", "Aaron-James", "Aarron", "Aaryan", "Aaryn", "Aayan", "Aazaan",
           "Abaan", "Abbas", "Abdallah", "Abdalroof", "Abdihakim", "Abdirahman", "Abdisalam", "Abdul", "Abdul-Aziz",
           "Abdulbasir", "Abdulkadir", "Abdulkarem", "Abdulkhader", "Abdullah", "Abdul-Majeed", "Abdulmalik",
           "Abdul-Rehman", "Abdur", "Abdurraheem", "Abdur-Rahman", "Abdur-Rehmaan", "Abel", "Abhinav", "Abhisumant",
           "Abid", "Abir", "Abraham", "Abu", "Abubakar", "Ace", "Adain", "Adam", "Adam-James", "Addison", "Addisson",
           "Adegbola", "Adegbolahan", "Aden", "Adenn", "Adie", "Adil", "Aditya", "Adnan", "Adrian", "Adrien", "Aedan",
           "Aedin", "Aedyn", "Aeron", "Afonso", "Ahmad", "Ahmed", "Ahmed-Aziz", "Ahoua", "Ahtasham", "Aiadan", "Aidan",
           "Aiden", "Aiden-Jack", "Aiden-Vee", "Aidian", "Aidy", "Ailin", "Aiman", "Ainsley", "Ainslie", "Airen",
           "Airidas", "Airlie", "AJ", "Ajay", "A-Jay", "Ajayraj", "Akan", "Akram", "Al", "Ala", "Alan", "Alanas",
           "Alasdair", "Alastair", "Alber", "Albert", "Albie", "Aldred", "Alec", "Aled", "Aleem", "Aleksandar",
           "Aleksander", "Aleksandr", "Aleksandrs", "Alekzander"
       };
            string[] days =
            {
           "Sunday",
           "Monday",
           "Tuesday",
           "Wednesday",
           "Thursday",
           "Friday",
           "Saturday"
       };
            TimeSpan startT = TimeSpan.FromHours(7);
            TimeSpan endT = TimeSpan.FromHours(12);
            int maxMinutes = (int)((endT - startT).TotalMinutes);

            var path = Server.MapPath("~/Content/health-and-hospitals-corporation-hhc-facilities.csv");
            string filedate = System.IO.File.ReadAllText(path);
            filedate = filedate.Replace('\n', '\r');
            string[] lines = filedate.Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int totalrows = lines.Length;
            int totalcols = lines[0].Split(',').Length;
            string[,] resultValues = new string[totalrows, totalcols];
            for (int row = 0; row < totalrows; row++)
            {
                string[] line_r = lines[row].Split(',');
                for (int col = 0; col < totalcols; col++)
                {
                    resultValues[row, col] = line_r[col];
                }
            }
            for (int row = 1; row <= gyms.Length; row++)
            {
                if (desc == 0)
                {
                    desc = 1;
                }
                else
                {
                    desc = 0;
                }
                Random gen = new Random();
                DateTime start = new DateTime(1900, 1, 1);
                int range = (DateTime.Today - start).Days;

                //Debug.WriteLine(resultValues[row, 0]);
                var fname = names[gen.Next(1, 60)];
                var lname = names[gen.Next(1, 60)];
                var user = new User
                {
                    Email = gyms[row - 1] + "@gmail.com",
                    JoniedAt = DateTime.Now,
                    Password = "12345678",
                    State = 1,
                    UserTypeId = 3,
                    Username = gyms[row - 1],
                    imageUrl = row.ToString() + ".jpg"
                };
                DB.Users.Add(user);
                var organization = new Organization
                {
                    Description = descriptions[desc],
                    EstablishOrg = start.AddDays(gen.Next(range)),
                    Fax = resultValues[row, 6].Replace("\"", ""),
                    PriceRangeId = gen.Next(1, 4),
                    UsernameVerification = "",
                    businessEmail = fname + '_' + lname + row.ToString() + "@gmail.com",
                    categoryId = 9,
                    cityId = gen.Next(1, 20),
                    orgRate = 0,
                    orgnizationName = gyms[row - 1],
                    ownerFirstName = fname,
                    ownerLastName = lname,
                    state = 0,
                    websiteUrl = "www." + gyms[row - 1] + ".com",
                    socialLink_1 = "twitter.com/" + gyms[row - 1],
                    socialLink_2 = "www.facebook.com/" + gyms[row - 1],
                    userId = user.Id,

                };
                DB.Organizations.Add(organization);
                var phone = new Phone
                {
                    phoneNumber = resultValues[row, 4].Replace("\"", ""),
                    userId = user.Id
                };
                DB.Phones.Add(phone);
                for (int i = 0; i < gen.Next(0, days.Length); i++)
                {
                    int minutes = gen.Next(maxMinutes);
                    TimeSpan t = startT.Add(TimeSpan.FromMinutes(minutes));
                    var worktime = new WorkTime
                    {
                        Day = days[i],
                        From = new DateTime(2019, 3, 6, 8, 15, 0),
                        To = new DateTime(2019, 3, 6, 11, 12, 0),
                        OrganizationId = organization.Id,
                    };
                    DB.WorkTimes.Add(worktime);
                }

                var orgfactors = DB.Factors.Where(f => f.categoryId == 9).ToArray();
                int minId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Min();
                int maxId = orgfactors.Select(f => f.Id).DefaultIfEmpty(0).Max();

                for (int i = minId, c = 0; i <= maxId; i++, c++)
                {

                    var organizationFactor = new OrganizationFactor
                    {
                        factorRate = 0,
                        organizationId = organization.Id,
                        factorId = orgfactors[c].Id
                    };
                    DB.OrganizationFactors.Add(organizationFactor);


                }
                DB.SaveChanges();
            }
        }
        public string passwordgenerator(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString().ToLower();

        }


       


        public ActionResult Index ()
        {
            //AddHospiatals();
            //AddDoctors();
            //AddClinicss();
            //AddHighSchools();
            //AddUniversities();
            //AddTeachers();
            //AddClubs();
            //AddCoaches();
            //AddGyms();
            List<NumOfReactions> result = DB.ReviewReactions
                .GroupBy(c => c.clientId)
                .Select(m => new NumOfReactions {  clientId = m.Key, count = m.Count()})
                .OrderByDescending(r=>r.count)
                .Take(10)
                .ToList();

            List<int> clientIds = result.Select(i => i.clientId ).ToList();

            var topReviewers = DB.Clients
                .Where(r => clientIds.Contains(r.Id))
                .Include(r=>r.User);

            ViewBag.topReviewers = topReviewers;

            return View("Index");
        }

        public ActionResult Filter()
        {
            return View("Filter");
        }

        public ActionResult FilteringResult(string query, int sector, int category, int city, int priceRange, int rate)
        {

            var organizations = DB.Organizations
                .Include(c => c.OrganizationFactors.Select(o => o.Factor))
                .ToList();
            var sectors = DB.Sector.ToList();
            var categories = DB.Categories.ToList();
            var cities = DB.Cities.ToList();
            var priceRanges = DB.PriceRanges.ToList();
            var viewModel = new OrganizationFilterVIewModel()
            {
                Organizations = organizations,
                Sectors = sectors,
                Categories = categories,
                Cities = cities,
                PriceRanges = priceRanges,
                Rate = 0,
                query = "",
                cityId = 0,
                categoryId = 0,
                sectorId = sector
            };

            if (query != "0")
            {
                organizations = DB.Organizations
               .Include(c => c.OrganizationFactors.Select(o => o.Factor))
               .Where(c => c.orgnizationName.Contains(query))
               .ToList();
                viewModel.query = query;
            }
            if (sector != 0)
            {
                organizations = organizations.Where(c => c.Category.sectorId == sector).ToList();
                categories = categories.Where(c => c.sectorId == sector).ToList();
                var tempcities = organizations.Select(m => m.cityId).ToList();
                cities = cities.Where(c => tempcities.Contains(c.Id)).ToList();
                viewModel.sectorId = sector;
                viewModel.categoryId = category;
                viewModel.cityId = city;
                viewModel.priceRangeId = priceRange;
                viewModel.Rate = rate;

            }
            if (category != 0)
            {
                organizations = organizations.Where(c => c.categoryId == category).ToList();
                var tempcities = organizations.Select(m => m.cityId).ToList();
                cities = cities.Where(c => tempcities.Contains(c.Id)).ToList();
                viewModel.sectorId = sector;
                viewModel.categoryId = category;
                viewModel.cityId = city;
                viewModel.priceRangeId = priceRange;
                viewModel.Rate = rate;

            }
            if (city != 0)
            {
                organizations = organizations.Where(c => c.cityId == city).ToList();
                viewModel.sectorId = sector;
                viewModel.categoryId = category;
                viewModel.cityId = city;
                viewModel.priceRangeId = priceRange;
                viewModel.Rate = rate;
            }
            if (priceRange != 0)
            {
                organizations = organizations.Where(c => c.PriceRangeId == priceRange).ToList();
                viewModel.sectorId = sector;
                viewModel.categoryId = category;
                viewModel.cityId = city;
                viewModel.priceRangeId = priceRange;
                viewModel.Rate = rate;
            }
            if (rate != 0)
            {
                organizations = organizations.Where(c => c.orgRate >= rate).ToList();
                viewModel.sectorId = sector;
                viewModel.categoryId = category;
                viewModel.cityId = city;
                viewModel.priceRangeId = priceRange;
                viewModel.Rate = rate;
            }

            viewModel.Organizations = organizations;
            viewModel.Categories = categories;
            viewModel.Cities = cities;

            return PartialView("_FilterResultPartialView", viewModel);

        }

        public ActionResult FilteringBar(string query, int sector, int category, int city, int priceRange, int rate)
        {

            var organizations = DB.Organizations
                .Include(c => c.OrganizationFactors.Select(o => o.Factor))
                .ToList();
            var sectors = DB.Sector.ToList();
            var categories = DB.Categories.ToList();
            var cities = DB.Cities.ToList();
            var priceRanges = DB.PriceRanges.ToList();
            var viewModel = new OrganizationFilterVIewModel()
            {
                Organizations = organizations,
                Sectors = sectors,
                Categories = categories,
                Cities = cities,
                PriceRanges = priceRanges,
                Rate = 0,
                query = "",
                cityId = 0,
                categoryId = 0,
                sectorId = sector
            };

            if (query != "0")
            {
                organizations = DB.Organizations
               .Include(c => c.OrganizationFactors.Select(o => o.Factor))
               .Where(c => c.orgnizationName.Contains(query))
               .ToList();
                viewModel.query = query;
            }
            if (sector != 0)
            {
                organizations = organizations.Where(c => c.Category.sectorId == sector).ToList();
                categories = categories.Where(c => c.sectorId == sector).ToList();
                var tempcities = organizations.Select(m => m.cityId).ToList();
                cities = cities.Where(c => tempcities.Contains(c.Id)).ToList();
                viewModel.sectorId = sector;
                viewModel.categoryId = category;
                viewModel.cityId = city;
                viewModel.priceRangeId = priceRange;
                viewModel.Rate = rate;

            }
            if (category != 0)
            {
                organizations = organizations.Where(c => c.categoryId == category).ToList();
                var tempcities = organizations.Select(m => m.cityId).ToList();
                cities = cities.Where(c => tempcities.Contains(c.Id)).ToList();
                viewModel.sectorId = sector;
                viewModel.categoryId = category;
                viewModel.cityId = city;
                viewModel.priceRangeId = priceRange;
                viewModel.Rate = rate;

            }
            if (city != 0)
            {
                organizations = organizations.Where(c => c.cityId == city).ToList();
                viewModel.sectorId = sector;
                viewModel.categoryId = category;
                viewModel.cityId = city;
                viewModel.priceRangeId = priceRange;
                viewModel.Rate = rate;
            }
            if (priceRange != 0)
            {
                organizations = organizations.Where(c => c.PriceRangeId == priceRange).ToList();
                viewModel.sectorId = sector;
                viewModel.categoryId = category;
                viewModel.cityId = city;
                viewModel.priceRangeId = priceRange;
                viewModel.Rate = rate;
            }
            if (rate != 0)
            {
                organizations = organizations.Where(c => c.orgRate >= rate).ToList();
                viewModel.sectorId = sector;
                viewModel.categoryId = category;
                viewModel.cityId = city;
                viewModel.priceRangeId = priceRange;
                viewModel.Rate = rate;
            }

            viewModel.Organizations = organizations;
            viewModel.Categories = categories;
            viewModel.Cities = cities;

            return PartialView("_FilterBarPartialView", viewModel);

        }

        public ActionResult SeeAllOrOneSector(int? id)
        {
            var client = new Client();
            var subsribersList=new List<int>();
            if (Session["UserId"] != null && Convert.ToInt32(Session["LoginUserTypeId"]) == 2)
            {
                int userid = Convert.ToInt32(Session["UserId"]);
                client = DB.Clients.SingleOrDefault(c => c.userId == userid);
                subsribersList = DB.Subscribers.Where(s => s.clientId == client.Id).Select(m => m.organizationId).ToList();

            }
            if (id == null)
            {
                var organizations = DB.Organizations
                    .Include(c => c.OrganizationFactors.Select(o => o.Factor))
                    .ToList();
                var sectors = DB.Sector.ToList();
                var categories = DB.Categories.ToList();
                var cities = DB.Cities.ToList();
                var priceRages = DB.PriceRanges.ToList();

                var viewModel = new OrganizationFilterVIewModel
                {
                    Organizations = organizations,
                    Sectors = sectors,
                    Categories = categories,
                    Cities = cities,
                    PriceRanges = priceRages,
                    Rate = 0,
                    client_id =Convert.ToInt32(client.Id),
                    OrganizationIdList = subsribersList
                };
                return View("Filter", viewModel);
            }
            else
            {
                var organizations = DB.Organizations
                    .Include(c => c.OrganizationFactors.Select(o => o.Factor))
                    .Where(o=>o.Category.sectorId==id)
                    .ToList();
                var sectors = DB.Sector.ToList();
                var categories = DB.Categories.ToList();
                var cities = DB.Cities.ToList();
                var priceRages = DB.PriceRanges.ToList();

                var viewModel = new OrganizationFilterVIewModel
                {
                    Organizations = organizations,
                    Sectors = sectors,
                    Categories = categories,
                    Cities = cities,
                    PriceRanges = priceRages,
                    Rate = 0,
                    sectorId = Convert.ToInt32(id),
                    client_id = Convert.ToInt32(client.Id),
                    OrganizationIdList = subsribersList
                };
                return View("Filter", viewModel);
            }
        }
        [HttpPost]
        public ActionResult Search(string organization)
        {
            var client = new Client();
            var subsribersList = new List<int>();

            if (Session["UserId"] != null && Convert.ToInt32(Session["LoginUserTypeId"]) == 2)
            {
                int userid = Convert.ToInt32(Session["UserId"]);
                client = DB.Clients.SingleOrDefault(c => c.userId == userid);
                subsribersList = DB.Subscribers.Where(s => s.clientId == client.Id).Select(m => m.organizationId).ToList();

            }
            var organizations = DB.Organizations
                .Include(c => c.OrganizationFactors.Select(o => o.Factor))
                .Where(c => c.orgnizationName.Contains(organization))
                .ToList();
            var sectors = DB.Sector.ToList();
            var categories = DB.Categories.ToList();
            var cities = DB.Cities.ToList();
            var priceRages = DB.PriceRanges.ToList();

            var viewModel = new OrganizationFilterVIewModel
            {
                Organizations = organizations,
                Sectors = sectors,
                Categories = categories,
                Cities = cities,
                PriceRanges = priceRages,
                Rate = 0,
                query = organization,
                client_id = Convert.ToInt32(client.Id),
                OrganizationIdList = subsribersList
            };
            return View("Filter", viewModel);

        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Login(UserLogin psg)
        {
                
                var user = DB.Users.Where(u => u.Username == psg.username && u.Password == psg.Password).FirstOrDefault();
                if (user != null)
                {
                    
                    if (user.State == 1)
                    {
                        if (user.UserTypeId == 1)
                        {
                            Session["UserId"] = user.Id;
                            Session["LoginUserTypeId"] = user.UserTypeId;
                            Session.Timeout = 120;
                            var result = new { message = "", route = "/Admin/Home" };
                            return Json(result);
                        }

                        else if (user.UserTypeId == 2)
                        {
                            Session["UserId"] = user.Id;
                            Session["LoginUserTypeId"] = user.UserTypeId;
                            Session.Timeout = 120;
                        var result = new { message = "", route = "/User/Index" };
                            return Json(result);
                        }
                        else if (user.UserTypeId == 3)
                        {
                            var org = DB.Organizations.Where(u => u.userId == user.Id).FirstOrDefault();
                            if (org.state == 0)
                            {
                                var result = new { message = "your registeration information still being revised", route = "" };
                                return Json(result);
                            }
                            else
                            {
                                Session["UserId"] = user.Id;
                                Session["LoginUserTypeId"] = user.UserTypeId;
                                Session.Timeout = 120;
                            var result = new { message = "", route = "/Organization/Index" };
                                return Json(result);
                            }
                        }
                        else
                        {
                            var result = new { message = "you are blocked", route = "" };
                            return Json(result);
                        }

                }
                    else
                    {
                        var result = new { message = "you are blocked", route = "" };
                        return Json(result);
                    }

            }
                else
                {
                    
                    var result = new { message = "wrong username or password", route = "" };
                    return Json(result);
                }
        }
        public ActionResult loading()
        {

            return View("LoadingPage");
        }
        public JsonResult Feedback(FeedBack feedBack)
        {
            feedBack.Date=DateTime.Now;
            DB.FeedBacks.Add(feedBack);
            DB.SaveChanges();
            return Json("Your feedback has been sent");
        }

        

    }

}

 