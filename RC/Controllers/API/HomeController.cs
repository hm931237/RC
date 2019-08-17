using RC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RC.Controllers.API
{
    public class HomeController : ApiController
    {
        ApplicationDbContext DB = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult Index(UserLogin psg)
        {
            string err = "null";
            if (ModelState.IsValid)
            {
                var user = DB.Users.Where(u => u.Username == psg.username && u.Password == psg.Password).FirstOrDefault();
                UserLogin authUser = new UserLogin();

                if (user != null)
                {


                    authUser.Password = user.Password;
                    authUser.username = user.Username;
                    authUser.Id = user.Id;
                    authUser.imageUrl = user.imageUrl;
                    authUser.roleId = user.UserTypeId;
                    Console.WriteLine("user : " + user);

                    if (user.State == 1)
                    {
                        if (user.UserTypeId == 3)
                        {
                            var org = DB.Organizations.Where(u => u.userId == user.Id).SingleOrDefault();
                            authUser.path = "/Admin/Home";

                            return Ok(authUser);
                        }

                        else if (user.UserTypeId == 2)
                        {
                            authUser.path = "/User/Index";

                            return Ok(authUser);
                        }
                        else if (user.UserTypeId == 1)
                        {
                            var org = DB.Organizations.Where(u => u.userId == user.Id).FirstOrDefault();
                            if (org.state == 0)
                            {
                                authUser.path = "/Organization/Index";

                                return Ok(authUser);
                            }

                            else
                            {

                                err = "The organization has not yet been accepted";
                                BadRequest(err);
                            }
                        }

                    }
                    else
                    {
                        err = "you are blocked";
                        BadRequest(err);
                    }
                }
                else
                {

                    err = "wrong username or password";
                    BadRequest(err);
                }

            }

            return BadRequest();
        }

    }
}
