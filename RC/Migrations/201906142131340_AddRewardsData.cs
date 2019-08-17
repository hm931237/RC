namespace RC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRewardsData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (10,100,'MICHEAL KORS WATCH','1.jpg','Claim your points now to achieve Original MICHEAL KORS WATCH which is one of the best watches in the world.Just Make your Reviews to achieve it Now !','mx1mfh2jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (3,150,'MICHEAL KORS WATCH','2.jpg','Claim your points now to achieve Original MICHEAL KORS WATCH which is one of the best watches in the world.Just Make your Reviews to achieve it NOw !.','mx2mfh3jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (4,200,'MVMT WATCH','3.jpg','Claim your points now to achieve Original MVMT KORS WATCH which is one of the best watches in the world.Just Make your Reviews to achieve it Now !.','mx3mfh4jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (6,250,'BRIGADA WATCH','4.jpg','Claim your points now to achieve Original BRIGADA WATCH which is one of the best watches in the world.Just Make your Reviews to achieve it Now !.','mx4mfh5jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (15,300,'FOSSIL WATCH','5.jpg','Claim your points now to achieve Original FOSSIL KORS WATCH which is one of the best watches in the world.Just Make your Reviews to achieve it Now !','mx6mfh7jkl')");

            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (6,500,'HP LAPTOP','6.jpg','Claim your points now to achieve HP Laptop which is one of the best Laptops in the world.Just Make your Reviews to achieve it Now !','mx7mfh8jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (19,700,'MACBOOK LAPTOP','7.jpg','Claim your points now to achieve MACBOOK Laptop which is one of the best Laptops in the world.Just Make your Reviews to achieve it Now !','mx8mfh9jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (15,450,'AERO GAMING LAPTOP','8.jpg','Claim your points now to achieve AERO GAMING Laptop which is one of the best Laptops in the world.Just Make your Reviews to achieve it Now !','mx9mfh8jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (11,500,'HP LAPTOP','9.jpg','Claim your points now to achieve HP Laptop which is one of the best Laptops in the world.Just Make your Reviews to achieve it Now !','mx8mfh7jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (13,550,'DELL LAPTOP','10.jpg','Claim your points now to achieve DELL Laptop which is one of the best Laptops in the world.Just Make your Reviews to achieve it Now !','mx7mfh6jkl')");

            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (5,600,'SAMSUNG S10 PLUS','11.jpg','Claim your points now to achieve SAMSUNG S10 PLUS which is one of the best Smartphones in the world.Just Make your Reviews to achieve it Now !','mx6mfh5jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (10,650,'SAMSUNG NOTE 9','12.jpg','Claim your points now to achieve SAMSUNG NOTE 9 which is one of the best Smartphones in the world.Just Make your Reviews to achieve it Now !','mx5mfh4jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (5,700,'SAMSUNG S8','13.jpg','Claim your points now to achieve SAMSUNG S8 which is one of the best Smartphones in the world.Just Make your Reviews to achieve it Now !','mx4mfh3jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (20,750,'Iphone X','14.jpg','Claim your points now to achieve Iphone X which is one of the best Smartphones in the world.Just Make your Reviews to achieve it Now !','mx3mfh2jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (18,800,'Iphone XS MAX','15.jpg','Claim your points now to achieve Iphone XS MAX which is one of the best Smartphones in the world.Just Make your Reviews to achieve it Now !','mx2mfh1jkl')");

            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (17,850,'SAMSUNG SMART 4K UHD 40 INCH','16.jpg','Claim your points now to achieve SAMSUNG SMART 4K UHD 40 INCH which is one of the best Smart TVs in the world.Just Make your Reviews to achieve it Now !','mx1mfh1jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (12,900,'LG SMART 4K UHD 49 INCH','17.jpg','Claim your points now to achieve LG SMART 4K UHD 49 INCH which is one of the best Smart TVs in the world.Just Make your Reviews to achieve it Now !','mx2mfh2jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (12,950,'SAMSUNG SMART 4K UHD 50 INCH','18.jpg','Claim your points now to achieve SAMSUNG SMART 4K UHD 50 INCH which is one of the best Smart TVs in the world.Just Make your Reviews to achieve it Now !','mx3mfh3jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (6,1000,'SHARP SMART 4K UHD 60 INCH','19.jpg','Claim your points now to achieve SHARP SMART 4K UHD 60 INCH which is one of the best Smart TVs in the world.Just Make your Reviews to achieve it Now !','mx4mfh4jkl')");
            Sql("INSERT INTO Offers(Quantity,requiredPoint,rewardName,imageUrl,Description,Qr_Gift) VALUES (6,1050,'LG SMART 4K UHD 60 INCH','20.jpg','Claim your points now to achieve LG SMART 4K UHD 60 INCH which is one of the best Smart TVs in the world.Just Make your Reviews to achieve it Now !','mx5mfh5jkl')");
        }
        
        public override void Down()
        {
        }
    }
}
