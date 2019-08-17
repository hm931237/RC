using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ReportKind> DbSet { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Sector> Sector { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<WorkTime> WorkTimes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Factor> Factors { get; set; }
        public DbSet<OrganizationFactor> OrganizationFactors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewReaction> ReviewReactions { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdsClick> AdsClicks { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionAge> PromotionAges { get; set; }
        public DbSet<PromotionViewer> PromotionViewers { get; set; }
        public DbSet<ReviewFactors> ReviewFactors { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<PointPolicy> PointPolicies { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferWinner> OfferWinners { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<averageRatings> averageRatingses { get; set; }
        public DbSet<PriceRange> PriceRanges { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

      
    
    public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<RC.Models.UserType> UserTypes { get; set; }
    }
}