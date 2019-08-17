namespace RC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate1 : DbMigration
    {
        public override void Up()
        {



            Sql("INSERT INTO UserTypes (Id,Name) VALUES (1,'Admin') ");
            Sql("INSERT INTO UserTypes (Id,Name) VALUES (2,'Client') ");
            Sql("INSERT INTO UserTypes (Id,Name) VALUES (3,'Organization') ");




            Sql("INSERT INTO[dbo].[PriceRanges] ([Name]) VALUES(N'High')");
            Sql("INSERT INTO[dbo].[PriceRanges] ([Name]) VALUES(N'Medium')");
            Sql("INSERT INTO[dbo].[PriceRanges] ([Name]) VALUES(N'Low')");

            Sql("INSERT INTO CITIES (NAME) VALUES ('Alabama')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Alaska')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Arizona')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Arkansas')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('California')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Colorado')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Connecticut')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Delaware')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('District Of Columbia')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Florida')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Tennessee')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Texas')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Utah')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Vermont')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Virginia')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Washington')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('West Virginia')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Wisconsin')");
            Sql("INSERT INTO CITIES (NAME) VALUES ('Wyoming')");

            Sql("INSERT INTO[dbo].[Sectors] ([Name], [IconPath]) VALUES(N'Medical', N'glyphicon glyphicon-plus')");
            Sql("INSERT INTO[dbo].[Sectors] ([Name], [IconPath]) VALUES(N'Educational', N'glyphicon glyphicon-cloud')");
            Sql("INSERT INTO[dbo].[Sectors] ([Name], [IconPath]) VALUES(N'Sport', N'glyphicon glyphicon-flag')");


            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Hospitals', 1)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Doctors', 1)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Clinics', 1)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'HighSchools', 2)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Universities', 2)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Teachers', 2)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Clubs', 3)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Soccer Coaches', 3)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Gyms', 3)");

            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Staff',1)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Cleanliness',1)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Professionalism',1)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Services',1)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Room comfort & condition',1)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('ER Wait Time',1)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Admission Process',1)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Doctors’ Experience',1)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Bedside Manner',1)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Geographical Location',1)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Communication',1)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Billing and Adminstration',1)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Effectivness of Treatment',1)");



            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Punctuality',2)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Appointment Scheduling',2)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Helpfulness',2)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Professionalism',2)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Knowledge',2)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Personnel',2)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Effectivness of Treatment',2)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Price',2)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Communication',2)");

            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Staff',3)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Professionalism',3)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Reception And Check-In',3)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Cleanliness',3)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Facilities',3)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Helpfulness',3)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Appointment Scheduling',3)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Punctuality',3)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Communication',3)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Services',3)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Convenient Official Hours',3)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Geograhical Location',3)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Price',3)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Effectivness of Treatment',3)");

            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Staff',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Professionalism',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Quality of Instruction',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Cleanliness',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Facilities & Resources',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Student Life',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Clubs & Activities',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Punctuality',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Communication With Parents',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Services',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Sports',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Geograhical Location',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Price',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Diversity',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Security',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Culture',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Competitiveness',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Student Affairs',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Adminstration',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Kindergarten Stage',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Primary Stage',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Preparatory Stage',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Secondary Stage',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Playgrounds Quality',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Educational Level',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('School Buses',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Student Uniform',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('School Expenses',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Entertainment Techniques',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Exams Difficulty',4)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Smart Boards Availabilty',4)");

            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Social Life',5)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Quality of Instruction',5)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Experience Gained',5)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Facilities & Resources',5)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Campus',5)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Geographical Location',5)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Cleanliness',5)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Adminstration',5)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Services',5)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Student Affairs',5)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Quality of Food',5)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Proffessors Effeciency',5)");

            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Clarity',6)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Easiness',6)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Helpfulness',6)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Fairness',6)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Knowledge',6)");

            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Overall',7)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Effectivness of Treatment',7)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Price of Membership',7)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Quality of Food',7)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Cleanliness of playgrounds',7)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Hygiene and Sanitation',7)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Security',7)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Staff Friendliness',7)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Geographical Location',7)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Adminstration Effectivness',7)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Trainers Professionalism',7)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Quality of Service',7)");

            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Experience',8)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Competitivness',8)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Knowledge',8)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Technique',8)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Dedication and Loyality',8)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Professionalism',8)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Team Work',8)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Passion',8)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Displine',8)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Mentorship',8)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Fairness',8)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Helpfulness',8)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Ethics',8)");

            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Fees',9)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Cleanliness',9)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Staff',9)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Facilites',9)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Workout Options',9)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Equipment Availability',9)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Equipment Status',9)");
            ////Sql("INSERT INTO FACTORS (NAME ,CATEGORYID) VALUES ('Locker Rooms',9)");












            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('admin','2019-06-13 01:11:03','admin', 1,'ceo.png','k@yahoo.com', 2)");



            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('omar','2019-06-13 01:11:03','12345678', 1,'ceo.png','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('omar','amer','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 26, 0, 1, 3, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('mostafa22','2019-06-13 01:11:03','12345678', 1,'avatar_01.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('mostafa','ahmed','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 26, 0, 2, 5, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('menna22','2019-06-13 01:11:03','12345678', 1,'avatar_04.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('menna','ashraf   ','Female','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 76, 0, 3, 2, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('kareem22','2019-06-13 01:11:03','12345678', 1,'chris.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('kareem','anwar','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 26, 0, 4, 6, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('seif22','2019-06-13 01:11:03','12345678', 1,'client-1.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('seif','metwally','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 46, 0, 5, 4, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('hossam22','2019-06-13 01:11:03','12345678', 1,'client-2.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('hossam','ahmed','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 36, 0, 6, 5, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('mohamed22','2019-06-13 01:11:03','12345678', 1,'avatar_01.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('mohamed','serag','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 46, 0, 7, 5, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('reem22','2019-06-13 01:11:03','12345678', 1,'client-3.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('reem','ayman','Female','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 56, 0, 8, 3, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('marwa22','2019-06-13 01:11:03','12345678', 1,'client-3.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('marwa','awaad','Female','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 26, 0, 9, 1, NULL)");


            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('mona22','2019-06-13 01:11:03','12345678', 1,'leah.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('mona','abdullah','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 26, 0, 10, 1, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('omnia22','2019-06-13 01:11:03','12345678', 1,'marissa.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('omnia','ahmed','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 26, 0, 11, 6, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('yasser22','2019-06-13 01:11:03','12345678', 1,'steve.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('yasser','mahmoud','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 26, 0, 12, 6, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('eslam22','2019-06-13 01:11:03','12345678', 1,'steve.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('eslam','alaa','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 34, 0, 13, 3, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('marwa22','2019-06-13 01:11:03','12345678', 1,'client-3.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('marwa','awaad','Female','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 52, 0, 14, 1, NULL)");


            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('mona12','2019-06-13 01:11:03','12345678', 1,'leah.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('mona','abdullah','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 42, 0, 15, 1, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('omnia202','2019-06-13 01:11:03','12345678', 1,'marissa.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('omnia','ahmed','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 24, 0, 16, 6, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('yasser29','2019-06-13 01:11:03','12345678', 1,'steve.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('yasser','mahmoud','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 24, 0, 17, 6, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('eslam45','2019-06-13 01:11:03','12345678', 1,'steve.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('eslam','alaa','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 42, 0, 18, 3, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('omar35','2019-06-13 01:11:03','12345678', 1,'ceo.png','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('omar','amer','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 24, 0, 19, 3, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('mostafa32','2019-06-13 01:11:03','12345678', 1,'avatar_01.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('mostafa','ahmed','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 44, 0, 20, 5, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('menna2200','2019-06-13 01:11:03','12345678', 1,'avatar_04.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('menna','ashraf   ','Female','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 25, 0, 21, 2, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('kareem2002','2019-06-13 01:11:03','12345678', 1,'chris.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('kareem','anwar','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 36, 0, 22, 6, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('seif98','2019-06-13 01:11:03','12345678', 1,'client-1.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('seif','metwally','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 23, 0, 23, 4, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('hossam2321','2019-06-13 01:11:03','12345678', 1,'client-2.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('hossam','ahmed','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 48, 0, 24, 5, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('mohamed4221','2019-06-13 01:11:03','12345678', 1,'avatar_01.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('mohamed','serag','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 98, 0, 25, 5, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('reem2008','2019-06-13 01:11:03','12345678', 1,'client-3.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('reem','ayman','Female','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 78, 0, 26, 3, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('marwa2001','2019-06-13 01:11:03','12345678', 1,'client-3.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('marwa','awaad','Female','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 55, 0, 27, 1, NULL)");


            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('mona96','2019-06-13 01:11:03','12345678', 1,'leah.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('mona','abdullah','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 43, 0, 28, 1, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('omnia299','2019-06-13 01:11:03','12345678', 1,'marissa.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('omnia','ahmed','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 22, 0, 29, 6, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('yasser2978','2019-06-13 01:11:03','12345678', 1,'steve.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('yasser','mahmoud','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 41, 0, 30, 6, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('eslam95','2019-06-13 01:11:03','12345678', 1,'steve.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('eslam','alaa','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 32, 0, 31, 3, NULL)");


            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('omar','2019-06-13 01:11:03','12345678', 1,'ceo.png','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('omar','amer','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 35, 0, 32, 3, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('mostafa88','2019-06-13 01:11:03','12345678', 1,'avatar_01.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('mostafa','ahmed','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 29, 0, 33, 5, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('menna99','2019-06-13 01:11:03','12345678', 1,'avatar_04.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('menna','ashraf   ','Female','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 27, 0, 34, 2, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('kareem66','2019-06-13 01:11:03','12345678', 1,'chris.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('kareem','anwar','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 19, 0,35, 6, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('seif44','2019-06-13 01:11:03','12345678', 1,'client-1.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('seif','metwally','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 23, 0, 36, 4, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('hossam98','2019-06-13 01:11:03','12345678', 1,'client-2.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('hossam','ahmed','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 22, 0, 37, 5, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('mohamed99','2019-06-13 01:11:03','12345678', 1,'avatar_01.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('mohamed','serag','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 21, 0, 38, 5, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('reem77','2019-06-13 01:11:03','12345678', 1,'client-3.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('reem','ayman','Female','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 20, 0, 39, 3, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('marwa96','2019-06-13 01:11:03','12345678', 1,'client-3.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('marwa','awaad','Female','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 37, 0, 40, 1, NULL)");


            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('mona555','2019-06-13 01:11:03','12345678', 1,'leah.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('mona','abdullah','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 49, 0, 41, 1, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('omnia66','2019-06-13 01:11:03','12345678', 1,'marissa.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('omnia','ahmed','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 55, 0, 42, 6, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('yasser67','2019-06-13 01:11:03','12345678', 1,'steve.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('yasser','mahmoud','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 26, 0, 43, 6, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('eslam68','2019-06-13 01:11:03','12345678', 1,'steve.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('eslam','alaa','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 15, 0, 44, 3, NULL)");
            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('omar69','2019-06-13 01:11:03','12345678', 1,'ceo.png','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('omar','amer','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 14, 0, 45, 3, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('mostafa70','2019-06-13 01:11:03','12345678', 1,'avatar_01.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('mostafa','ahmed','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 56, 0, 46, 5, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('menna120','2019-06-13 01:11:03','12345678', 1,'avatar_04.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('menna','ashraf   ','Female','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 35, 0, 47, 2, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('kareem16','2019-06-13 01:11:03','12345678', 1,'chris.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('kareem','anwar','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 22, 0, 9, 15, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('seif20','2019-06-13 01:11:03','12345678', 1,'client-1.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('seif','metwally','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 33, 0, 49, 4, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('hossam13','2019-06-13 01:11:03','12345678', 1,'client-2.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('hossam','ahmed','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 44, 0, 50, 5, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('mohamed18','2019-06-13 01:11:03','12345678', 1,'avatar_01.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('mohamed','serag','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 19, 0, 51, 5, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('reem38','2019-06-13 01:11:03','12345678', 1,'client-3.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('reem','ayman','Female','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 22, 0, 52, 3, NULL)");

            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('marwa89','2019-06-13 01:11:03','12345678', 1,'client-3.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('marwa','awaad','Female','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 16, 0, 53, 1, NULL)");


            //Sql("INSERT INTO Users (Username,joniedAt,Password,State,imageUrl,Email,UserTypeId) VALUES ('mona977','2019-06-13 01:11:03','12345678', 1,'leah.jpg','k@yahoo.com', 2)");
            //Sql("INSERT INTO Clients ( firstName, lastName, Gender, businessEmail, Address, dateOfBirth, Age, Points, userId, cityId, PostReaction_Id) VALUES('mona','abdullah','Male','k@yahoo.com', 'maadi', '2018-01-01 00:00:00', 56, 0, 54, 1, NULL)");

        }


        public override void Down()
        {
        }
    }
}
