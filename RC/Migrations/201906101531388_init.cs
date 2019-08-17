namespace RC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdsClicks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    advertismentId = c.Int(nullable: false),
                    userId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Advertisements", t => t.advertismentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.advertismentId)
                .Index(t => t.userId);

            CreateTable(
                "dbo.Advertisements",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Link = c.String(nullable: false),
                    imageUrl = c.String(),
                    startDate = c.DateTime(nullable: false),
                    endDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Username = c.String(nullable: false),
                    JoniedAt = c.DateTime(nullable: false),
                    Password = c.String(nullable: false),
                    State = c.Int(nullable: false),
                    imageUrl = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    UserTypeId = c.Byte(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);

            CreateTable(
                "dbo.UserTypes",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.averageRatings",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    DateOfUpdate = c.DateTime(nullable: false),
                    OrganizationId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);

            CreateTable(
                "dbo.Organizations",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    state = c.Int(nullable: false),
                    UsernameVerification = c.String(),
                    ownerFirstName = c.String(nullable: false),
                    EstablishOrg = c.DateTime(nullable: false),
                    ownerLastName = c.String(nullable: false),
                    orgnizationName = c.String(nullable: false),
                    websiteUrl = c.String(nullable: false),
                    Fax = c.String(nullable: false),
                    businessEmail = c.String(nullable: false),
                    socialLink_1 = c.String(nullable: false),
                    socialLink_2 = c.String(),
                    Description = c.String(nullable: false),
                    orgRate = c.Single(nullable: false),
                    categoryId = c.Int(nullable: false),
                    userId = c.Int(nullable: false),
                    cityId = c.Int(nullable: false),
                    PriceRangeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.categoryId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.cityId, cascadeDelete: true)
                .ForeignKey("dbo.PriceRanges", t => t.PriceRangeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.categoryId)
                .Index(t => t.userId)
                .Index(t => t.cityId)
                .Index(t => t.PriceRangeId);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    sectorId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sectors", t => t.sectorId, cascadeDelete: true)
                .Index(t => t.sectorId);

            CreateTable(
                "dbo.Factors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    categoryId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.categoryId);

            CreateTable(
                "dbo.Sectors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    IconPath = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Cities",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OrganizationFactors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    factorRate = c.Single(nullable: false),
                    factorId = c.Int(nullable: false),
                    organizationId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factors", t => t.factorId, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.organizationId, cascadeDelete: false)
                .Index(t => t.factorId)
                .Index(t => t.organizationId);

            CreateTable(
                "dbo.PriceRanges",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Reviews",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    generalFeedback = c.String(),
                    Date = c.DateTime(nullable: false),
                    clientId = c.Int(nullable: false),
                    organizationId = c.Int(nullable: false),
                    TotalRate = c.Single(nullable: false),
                    numberOfUseful = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.clientId, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.organizationId, cascadeDelete: true)
                .Index(t => t.clientId)
                .Index(t => t.organizationId);

            CreateTable(
                "dbo.Clients",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    firstName = c.String(),
                    lastName = c.String(),
                    Gender = c.String(),
                    businessEmail = c.String(),
                    Address = c.String(),
                    dateOfBirth = c.DateTime(nullable: false),
                    Age = c.Int(nullable: false),
                    Points = c.Int(nullable: false),
                    userId = c.Int(nullable: false),
                    cityId = c.Int(nullable: false),
                    PostReaction_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.cityId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: false)
                .ForeignKey("dbo.PostReactions", t => t.PostReaction_Id)
                .Index(t => t.userId)
                .Index(t => t.cityId)
                .Index(t => t.PostReaction_Id);

            CreateTable(
                "dbo.ReviewFactors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Rate = c.Single(nullable: false),
                    reviewId = c.Int(nullable: false),
                    organizationFactorId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrganizationFactors", t => t.organizationFactorId, cascadeDelete: false)
                .ForeignKey("dbo.Reviews", t => t.reviewId, cascadeDelete: false)
                .Index(t => t.reviewId)
                .Index(t => t.organizationFactorId);

            CreateTable(
                "dbo.WorkTimes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    From = c.DateTime(nullable: false),
                    To = c.DateTime(nullable: false),
                    Day = c.String(),
                    OrganizationId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);

            CreateTable(
                "dbo.ReportKinds",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.FeedBacks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Content = c.String(),
                    Date = c.DateTime(nullable: false),
                    Email = c.String(),
                    FullName = c.String(),
                    userType = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Offers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Quantity = c.Int(nullable: false),
                    requiredPoint = c.Int(nullable: false),
                    rewardName = c.String(),
                    imageUrl = c.String(),
                    Description = c.String(),
                    Qr_Gift = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.OfferWinners",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    clientId = c.Int(nullable: false),
                    offerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.clientId, cascadeDelete: true)
                .ForeignKey("dbo.Offers", t => t.offerId, cascadeDelete: true)
                .Index(t => t.clientId)
                .Index(t => t.offerId);

            CreateTable(
                "dbo.Phones",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    phoneNumber = c.String(),
                    userId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);

            CreateTable(
                "dbo.PointPolicies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Points = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.PostImages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Path = c.String(),
                    postId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.postId, cascadeDelete: true)
                .Index(t => t.postId);

            CreateTable(
                "dbo.Posts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Content = c.String(),
                    Date = c.DateTime(nullable: false),
                    organizationId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.organizationId, cascadeDelete: true)
                .Index(t => t.organizationId);

            CreateTable(
                "dbo.PostReactions",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Reaction = c.Int(nullable: false),
                    postId = c.Int(nullable: false),
                    clientId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.postId, cascadeDelete: true)
                .Index(t => t.postId);

            CreateTable(
                "dbo.PromotionAges",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    startAge = c.Int(),
                    endAge = c.Int(),
                    promotionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Promotions", t => t.promotionId, cascadeDelete: true)
                .Index(t => t.promotionId);

            CreateTable(
                "dbo.Promotions",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Reaches = c.Int(nullable: false),
                    Profit = c.Int(nullable: false),
                    Gender = c.Int(nullable: false),
                    postId = c.Int(nullable: false),
                    isDone = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.postId, cascadeDelete: true)
                .Index(t => t.postId);

            CreateTable(
                "dbo.PromotionViewers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    promotionId = c.Int(nullable: false),
                    clientId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.clientId, cascadeDelete: true)
                .ForeignKey("dbo.Promotions", t => t.promotionId, cascadeDelete: true)
                .Index(t => t.promotionId)
                .Index(t => t.clientId);

            CreateTable(
                "dbo.Reports",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Content = c.String(),
                    Date = c.DateTime(nullable: false),
                    reportTypeId = c.Int(nullable: false),
                    reporterId = c.Int(nullable: false),
                    reportedId = c.Int(nullable: false),
                    reportKindId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.reportedId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.reporterId, cascadeDelete: false)
                .ForeignKey("dbo.ReportKinds", t => t.reportKindId, cascadeDelete: true)
                .ForeignKey("dbo.ReportTypes", t => t.reportTypeId, cascadeDelete: true)
                .Index(t => t.reportTypeId)
                .Index(t => t.reporterId)
                .Index(t => t.reportedId)
                .Index(t => t.reportKindId);

            CreateTable(
                "dbo.ReportTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ReviewReactions",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    reviewId = c.Int(nullable: false),
                    clientId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.clientId, cascadeDelete: true)
                .ForeignKey("dbo.Reviews", t => t.reviewId, cascadeDelete: false)
                .Index(t => t.reviewId)
                .Index(t => t.clientId);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Subscribers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    clientId = c.Int(nullable: false),
                    organizationId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.clientId, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.organizationId, cascadeDelete: true)
                .Index(t => t.clientId)
                .Index(t => t.organizationId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subscribers", "organizationId", "dbo.Organizations");
            DropForeignKey("dbo.Subscribers", "clientId", "dbo.Clients");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ReviewReactions", "reviewId", "dbo.Reviews");
            DropForeignKey("dbo.ReviewReactions", "clientId", "dbo.Clients");
            DropForeignKey("dbo.Reports", "reportTypeId", "dbo.ReportTypes");
            DropForeignKey("dbo.Reports", "reportKindId", "dbo.ReportKinds");
            DropForeignKey("dbo.Reports", "reporterId", "dbo.Users");
            DropForeignKey("dbo.Reports", "reportedId", "dbo.Users");
            DropForeignKey("dbo.PromotionViewers", "promotionId", "dbo.Promotions");
            DropForeignKey("dbo.PromotionViewers", "clientId", "dbo.Clients");
            DropForeignKey("dbo.PromotionAges", "promotionId", "dbo.Promotions");
            DropForeignKey("dbo.Promotions", "postId", "dbo.Posts");
            DropForeignKey("dbo.PostReactions", "postId", "dbo.Posts");
            DropForeignKey("dbo.Clients", "PostReaction_Id", "dbo.PostReactions");
            DropForeignKey("dbo.PostImages", "postId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "organizationId", "dbo.Organizations");
            DropForeignKey("dbo.Phones", "userId", "dbo.Users");
            DropForeignKey("dbo.OfferWinners", "offerId", "dbo.Offers");
            DropForeignKey("dbo.OfferWinners", "clientId", "dbo.Clients");
            DropForeignKey("dbo.averageRatings", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.WorkTimes", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Organizations", "userId", "dbo.Users");
            DropForeignKey("dbo.ReviewFactors", "reviewId", "dbo.Reviews");
            DropForeignKey("dbo.ReviewFactors", "organizationFactorId", "dbo.OrganizationFactors");
            DropForeignKey("dbo.Reviews", "organizationId", "dbo.Organizations");
            DropForeignKey("dbo.Reviews", "clientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "userId", "dbo.Users");
            DropForeignKey("dbo.Clients", "cityId", "dbo.Cities");
            DropForeignKey("dbo.Organizations", "PriceRangeId", "dbo.PriceRanges");
            DropForeignKey("dbo.OrganizationFactors", "organizationId", "dbo.Organizations");
            DropForeignKey("dbo.OrganizationFactors", "factorId", "dbo.Factors");
            DropForeignKey("dbo.Organizations", "cityId", "dbo.Cities");
            DropForeignKey("dbo.Organizations", "categoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "sectorId", "dbo.Sectors");
            DropForeignKey("dbo.Factors", "categoryId", "dbo.Categories");
            DropForeignKey("dbo.AdsClicks", "userId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.AdsClicks", "advertismentId", "dbo.Advertisements");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Subscribers", new[] { "organizationId" });
            DropIndex("dbo.Subscribers", new[] { "clientId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ReviewReactions", new[] { "clientId" });
            DropIndex("dbo.ReviewReactions", new[] { "reviewId" });
            DropIndex("dbo.Reports", new[] { "reportKindId" });
            DropIndex("dbo.Reports", new[] { "reportedId" });
            DropIndex("dbo.Reports", new[] { "reporterId" });
            DropIndex("dbo.Reports", new[] { "reportTypeId" });
            DropIndex("dbo.PromotionViewers", new[] { "clientId" });
            DropIndex("dbo.PromotionViewers", new[] { "promotionId" });
            DropIndex("dbo.Promotions", new[] { "postId" });
            DropIndex("dbo.PromotionAges", new[] { "promotionId" });
            DropIndex("dbo.PostReactions", new[] { "postId" });
            DropIndex("dbo.Posts", new[] { "organizationId" });
            DropIndex("dbo.PostImages", new[] { "postId" });
            DropIndex("dbo.Phones", new[] { "userId" });
            DropIndex("dbo.OfferWinners", new[] { "offerId" });
            DropIndex("dbo.OfferWinners", new[] { "clientId" });
            DropIndex("dbo.WorkTimes", new[] { "OrganizationId" });
            DropIndex("dbo.ReviewFactors", new[] { "organizationFactorId" });
            DropIndex("dbo.ReviewFactors", new[] { "reviewId" });
            DropIndex("dbo.Clients", new[] { "PostReaction_Id" });
            DropIndex("dbo.Clients", new[] { "cityId" });
            DropIndex("dbo.Clients", new[] { "userId" });
            DropIndex("dbo.Reviews", new[] { "organizationId" });
            DropIndex("dbo.Reviews", new[] { "clientId" });
            DropIndex("dbo.OrganizationFactors", new[] { "organizationId" });
            DropIndex("dbo.OrganizationFactors", new[] { "factorId" });
            DropIndex("dbo.Factors", new[] { "categoryId" });
            DropIndex("dbo.Categories", new[] { "sectorId" });
            DropIndex("dbo.Organizations", new[] { "PriceRangeId" });
            DropIndex("dbo.Organizations", new[] { "cityId" });
            DropIndex("dbo.Organizations", new[] { "userId" });
            DropIndex("dbo.Organizations", new[] { "categoryId" });
            DropIndex("dbo.averageRatings", new[] { "OrganizationId" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.AdsClicks", new[] { "userId" });
            DropIndex("dbo.AdsClicks", new[] { "advertismentId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Subscribers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ReviewReactions");
            DropTable("dbo.ReportTypes");
            DropTable("dbo.Reports");
            DropTable("dbo.PromotionViewers");
            DropTable("dbo.Promotions");
            DropTable("dbo.PromotionAges");
            DropTable("dbo.PostReactions");
            DropTable("dbo.Posts");
            DropTable("dbo.PostImages");
            DropTable("dbo.PointPolicies");
            DropTable("dbo.Phones");
            DropTable("dbo.OfferWinners");
            DropTable("dbo.Offers");
            DropTable("dbo.FeedBacks");
            DropTable("dbo.ReportKinds");
            DropTable("dbo.WorkTimes");
            DropTable("dbo.ReviewFactors");
            DropTable("dbo.Clients");
            DropTable("dbo.Reviews");
            DropTable("dbo.PriceRanges");
            DropTable("dbo.OrganizationFactors");
            DropTable("dbo.Cities");
            DropTable("dbo.Sectors");
            DropTable("dbo.Factors");
            DropTable("dbo.Categories");
            DropTable("dbo.Organizations");
            DropTable("dbo.averageRatings");
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
            DropTable("dbo.Advertisements");
            DropTable("dbo.AdsClicks");
        }
    }
}
