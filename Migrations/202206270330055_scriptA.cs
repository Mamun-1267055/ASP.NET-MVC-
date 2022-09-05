namespace Work1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scriptA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookRooms",
                c => new
                    {
                        bookid = c.Int(nullable: false, identity: true),
                        checkingdate = c.DateTime(nullable: false),
                        checkingOut = c.DateTime(nullable: false),
                        duration = c.String(nullable: false),
                        cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.bookid);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        bookid = c.Int(nullable: false),
                        custname = c.String(nullable: false, maxLength: 40),
                        phone = c.String(),
                    })
                .PrimaryKey(t => t.bookid)
                .ForeignKey("dbo.BookRooms", t => t.bookid)
                .Index(t => t.bookid);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        bookid = c.Int(nullable: false),
                        roomStatus = c.Boolean(nullable: false),
                        picturePath = c.String(nullable: false),
                        roomType1 = c.String(),
                    })
                .PrimaryKey(t => t.bookid)
                .ForeignKey("dbo.BookRooms", t => t.bookid)
                .Index(t => t.bookid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "bookid", "dbo.BookRooms");
            DropForeignKey("dbo.Customers", "bookid", "dbo.BookRooms");
            DropIndex("dbo.Rooms", new[] { "bookid" });
            DropIndex("dbo.Customers", new[] { "bookid" });
            DropTable("dbo.Rooms");
            DropTable("dbo.Customers");
            DropTable("dbo.BookRooms");
        }
    }
}
