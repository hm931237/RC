using RC.Models;
using RC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace RC.Controllers.API
{
    public class ReactController : ApiController
    {
        private ApplicationDbContext _context;
        public ReactController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateReact(React React)
        {
            var reactions = _context.PostReactions.ToList();
            int found = 0;
            foreach (var reaction in reactions)
            {
                if(reaction.clientId == React.clientId && reaction.postId == React.postId && React.reactType == "Like")
                {
                    reaction.Reaction = 1;
                    found++;
                    _context.SaveChanges();
                }
                else if (reaction.clientId == React.clientId && reaction.postId == React.postId && React.reactType == "RemoveLike")
                {
                    reaction.Reaction = 0;
                    found++;
                    _context.SaveChanges();
                }
                else if (reaction.clientId == React.clientId && reaction.postId == React.postId && React.reactType == "DisLike")
                {
                    reaction.Reaction = 2;
                    found++;
                    _context.SaveChanges();
                }
                else if (reaction.clientId == React.clientId && reaction.postId == React.postId && React.reactType == "RemoveDislike")
                {
                    reaction.Reaction = 0;
                    found++;
                    _context.SaveChanges();
                }
            }

            if(found == 0 && React.reactType == "Like")
            {
                var reaction = new PostReaction
                {
                    clientId = React.clientId,
                    postId = React.postId,
                    Reaction = 1

                };
                _context.PostReactions.Add(reaction);
                _context.SaveChanges();
                found++;
            }

            if (found == 0 && React.reactType == "DisLike")
            {
                var reaction = new PostReaction
                {
                    clientId = React.clientId,
                    postId = React.postId,
                    Reaction = 2

                };
                _context.PostReactions.Add(reaction);
                _context.SaveChanges();
                found++;
            }


            var reacts = _context.PostReactions.Where(c => c.postId == React.postId).ToList();
            int like = 0;
            int dlike = 0;
            foreach (var re in reacts)
            {
                if (re.Reaction == 1)
                {
                    like++;
                }
                if (re.Reaction == 2)
                {
                    dlike++;
                }
            }
            var numOfReactionVM = new ViewModels.NumberOfReactions
            {
                Likes = like,
                disLikes = dlike
            };

            return Ok(numOfReactionVM);
            //return Ok();
        }

        //public IHttpActionResult AddReact(React React)
        //{
        //    if(React.reactType == "Like")
        //    {
        //        var reaction = new PostReaction();
        //        reaction.clientId = React.clientId;
        //        reaction.postId = React.postId;
        //        reaction.Reaction = 1;
        //        _context.PostReactions.Add(reaction);
        //    }

        //    if (React.reactType == "DisLike")
        //    {
        //        var reaction = new PostReaction();
        //        reaction.clientId = React.clientId;
        //        reaction.postId = React.postId;
        //        reaction.Reaction = 2;
        //        _context.PostReactions.Add(reaction);
        //    }

        //    _context.SaveChanges();

        //    //var reactions = _context.PostReactions.Where(c => c.postId == React.postId).ToList();
        //    //int like = 0;
        //    //int dlike = 0;
        //    //foreach (var re in reactions)
        //    //{
        //    //    if (re.Reaction == 1)
        //    //    {
        //    //        like++;
        //    //    }
        //    //    if (re.Reaction == 2)
        //    //    {
        //    //        dlike++;
        //    //    }
        //    //}
        //    //var numOfReactionVM = new NumberOfReactions
        //    //{
        //    //    Likes = like,
        //    //    disLikes = dlike
        //    //};

        //    //return Ok(numOfReactionVM);
        //    return Ok();
        //}
    }
}
