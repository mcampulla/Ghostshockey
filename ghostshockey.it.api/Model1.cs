namespace ghosthockey.it.api
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<MatchEvent> MatchEvents { get; set; }
        public virtual DbSet<MatchStat> MatchStats { get; set; }
        public virtual DbSet<MatchType> MatchTypes { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerComment> PlayerComments { get; set; }
        public virtual DbSet<PlayerData> PlayerDatas { get; set; }
        public virtual DbSet<PlayerDataTeam> PlayerDataTeams { get; set; }
        public virtual DbSet<PlayerDoc> PlayerDocs { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Tournament> Tournaments { get; set; }
        public virtual DbSet<Year> Years { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Matches)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.PlayerDatas)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasMany(e => e.MatchEvents)
                .WithRequired(e => e.Match)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasMany(e => e.MatchStats)
                .WithRequired(e => e.Match)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MatchType>()
                .HasMany(e => e.Matches)
                .WithRequired(e => e.MatchType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.PlayerComments)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.PlayerDatas)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Player>()
                .HasMany(e => e.PlayerDocs)
                .WithRequired(e => e.Player)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerData>()
                .HasMany(e => e.PlayerDataTeams)
                .WithRequired(e => e.PlayerData)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Matches)
                .WithRequired(e => e.Team)
                .HasForeignKey(e => e.AwayTeamID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Matches1)
                .WithRequired(e => e.Team1)
                .HasForeignKey(e => e.HomeTeamID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.PlayerDataTeams)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Year>()
                .Property(e => e.Version)
                .IsFixedLength();

            modelBuilder.Entity<Year>()
                .HasMany(e => e.Matches)
                .WithRequired(e => e.Year)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Year>()
                .HasMany(e => e.PlayerDatas)
                .WithRequired(e => e.Year)
                .WillCascadeOnDelete(false);
        }
    }
}
