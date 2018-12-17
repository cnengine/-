using Modle;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseService.DB
{
    public class DbContent : DbContext
    {
        public DbContent()
            : base("name=DbContent")
        {
            //Database.SetInitializer(new NullDatabaseInitializer<DbContent>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<DbContent>());
        }

        public DbSet<Humitures> Humitures { get; set; }
        public DbSet<GreenHouse> GreenHouse { get; set; }
        public DbSet<Serial> Serial { get; set; }
        public DbSet<Control> Control { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    public class HumituresMapping : EntityTypeConfiguration<Humitures>
    {
    }
    public class GreenHouseMapping : EntityTypeConfiguration<GreenHouse>
    {
    }
    public class SerialMapping : EntityTypeConfiguration<Serial>
    {
    }
    public class ControlMapping : EntityTypeConfiguration<Control>
    {
    }
}
