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
            Database.SetInitializer<GhostsDbContext>(null);
        } 

        public DbSet<Year> Years { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchType> MatchTypes { get; set; }
        public DbSet<MatchEvent> MatchEvents { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerData> PlayerDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Add(
            //    new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
            //        "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));

            //modelBuilder.Entity<Year>().HasKey(y => y.YearID);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Matches)
                .WithRequired(e => e.AwayTeam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Matches)
                .WithRequired(e => e.HomeTeam)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.PlayerDatas)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<PlayerData>()
            //    .HasMany(e => e.Stats)
            //    .WithRequired(e => e.PlayerData)
            //    .WillCascadeOnDelete(false);


            //modelBuilder.Entity<PlayerData>()
            //    .HasMany(e => e.Teams)
            //    .WithMany(e => e.PlayerDatas);

            //modelBuilder.Entity<Team>()
            //  .HasMany(e => e.player)
            //  .WithRequired(e => e.Category)
            //  .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Category>()
            //    .HasMany(e => e.PlayerDatas)
            //    .WithRequired(e => e.Category)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Match>()
            //    .HasMany(e => e.MatchEvents)
            //    .WithRequired(e => e.Match)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Match>()
            //    .HasMany(e => e.MatchStats)
            //    .WithRequired(e => e.Match)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<MatchType>()
            //    .HasMany(e => e.Matches)
            //    .WithRequired(e => e.MatchType)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Player>()
            //    .HasMany(e => e.PlayerComments)
            //    .WithRequired(e => e.Player)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Player>()
            //    .HasMany(e => e.PlayerDatas)
            //    .WithRequired(e => e.Player)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Player>()
            //    .HasMany(e => e.PlayerDocs)
            //    .WithRequired(e => e.Player)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<PlayerData>()
            //    .HasMany(e => e.PlayerDataTeams)
            //    .WithRequired(e => e.PlayerData)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Team>()
            //    .HasMany(e => e.Matches)
            //    .WithRequired(e => e.Team)
            //    .HasForeignKey(e => e.AwayTeamID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Team>()
            //    .HasMany(e => e.Matches1)
            //    .WithRequired(e => e.Team1)
            //    .HasForeignKey(e => e.HomeTeamID)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Team>()
            //    .HasMany(e => e.PlayerDataTeams)
            //    .WithRequired(e => e.Team)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Year>()
            //    .Property(e => e.Version)
            //    .IsFixedLength();

            //modelBuilder.Entity<Year>()
            //    .HasMany(e => e.Matches)
            //    .WithRequired(e => e.Year)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Year>()
            //    .HasMany(e => e.PlayerDatas)
            //    .WithRequired(e => e.Year)
            //    .WillCascadeOnDelete(false);
        }
    }

    public class SchoolDBInitializer : CreateDatabaseIfNotExists<GhostsDbContext>
    {
        protected override void Seed(GhostsDbContext context)
        {
            base.Seed(context);
        }
    }


}
