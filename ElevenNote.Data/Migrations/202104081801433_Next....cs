namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Next : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "TableId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "TableId");
        }
    }
}
