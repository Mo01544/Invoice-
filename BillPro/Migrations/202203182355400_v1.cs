namespace BillPro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        clientNumber = c.Int(nullable: false, identity: true),
                        clientName = c.String(nullable: false),
                        clientAddress = c.String(maxLength: 60),
                        clientPhone = c.String(nullable: false, maxLength: 14, unicode: false),
                    })
                .PrimaryKey(t => t.clientNumber);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        invoiceNamber = c.Int(nullable: false, identity: true),
                        clientNumber = c.Int(nullable: false),
                        invoiceDate = c.DateTime(nullable: false, storeType: "date"),
                        invoicePaidup = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.invoiceNamber)
                .ForeignKey("dbo.Clients", t => t.clientNumber, cascadeDelete: true)
                .Index(t => t.clientNumber);
            
            CreateTable(
                "dbo.itemInvoices",
                c => new
                    {
                        itemId = c.Int(nullable: false),
                        invoiceNumber = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.itemId, t.invoiceNumber })
                .ForeignKey("dbo.Invoices", t => t.invoiceNumber, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.itemId, cascadeDelete: true)
                .Index(t => t.itemId)
                .Index(t => t.invoiceNumber);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        itemId = c.Int(nullable: false, identity: true),
                        itemName = c.String(nullable: false),
                        companyName = c.String(maxLength: 128),
                        typeName = c.String(maxLength: 128),
                        unitName = c.String(maxLength: 128),
                        itemNotes = c.String(maxLength: 100),
                        itemBuyingPrice = c.Int(nullable: false),
                        itemSellingPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.itemId)
                .ForeignKey("dbo.Companies", t => t.companyName)
                .ForeignKey("dbo.Typees", t => t.typeName)
                .ForeignKey("dbo.Units", t => t.unitName)
                .Index(t => t.companyName)
                .Index(t => t.typeName)
                .Index(t => t.unitName);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        companyName = c.String(nullable: false, maxLength: 128),
                        companyNotes = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.companyName);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        empId = c.Int(nullable: false, identity: true),
                        cName = c.String(maxLength: 128),
                        empName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.empId)
                .ForeignKey("dbo.Companies", t => t.cName)
                .Index(t => t.cName);
            
            CreateTable(
                "dbo.Typees",
                c => new
                    {
                        typeName = c.String(nullable: false, maxLength: 128),
                        typeNotes = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.typeName);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        unitName = c.String(nullable: false, maxLength: 128),
                        unitNotes = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.unitName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.itemInvoices", "itemId", "dbo.Items");
            DropForeignKey("dbo.Items", "unitName", "dbo.Units");
            DropForeignKey("dbo.Items", "typeName", "dbo.Typees");
            DropForeignKey("dbo.Items", "companyName", "dbo.Companies");
            DropForeignKey("dbo.Employees", "cName", "dbo.Companies");
            DropForeignKey("dbo.itemInvoices", "invoiceNumber", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "clientNumber", "dbo.Clients");
            DropIndex("dbo.Employees", new[] { "cName" });
            DropIndex("dbo.Items", new[] { "unitName" });
            DropIndex("dbo.Items", new[] { "typeName" });
            DropIndex("dbo.Items", new[] { "companyName" });
            DropIndex("dbo.itemInvoices", new[] { "invoiceNumber" });
            DropIndex("dbo.itemInvoices", new[] { "itemId" });
            DropIndex("dbo.Invoices", new[] { "clientNumber" });
            DropTable("dbo.Units");
            DropTable("dbo.Typees");
            DropTable("dbo.Employees");
            DropTable("dbo.Companies");
            DropTable("dbo.Items");
            DropTable("dbo.itemInvoices");
            DropTable("dbo.Invoices");
            DropTable("dbo.Clients");
        }
    }
}
