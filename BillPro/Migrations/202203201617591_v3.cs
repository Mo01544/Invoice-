namespace BillPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "percentageDiscount", c => c.Double(nullable: false));
            AddColumn("dbo.Invoices", "valueDiscount", c => c.Double(nullable: false));
            AddColumn("dbo.Invoices", "billTolal", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "billTolal");
            DropColumn("dbo.Invoices", "valueDiscount");
            DropColumn("dbo.Invoices", "percentageDiscount");
        }
    }
}
