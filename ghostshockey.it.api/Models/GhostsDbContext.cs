using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;

namespace ghostshockey.it.api.Models
{
    public class GhostsDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        private const string connectionStringName = "Name=MS_TableConnectionString";

        public GhostsDbContext() : base(connectionStringName)
        {
        } 

        public DbSet<Year> Years { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Add(
            //    new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
            //        "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));

            //modelBuilder.Entity<Year>().HasKey(y => y.YearID);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

        }
    }

}
