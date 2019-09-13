//using TmTFramework.DataAccess.Concrete.EntityFramework.Mappings;
using TmTFramework.Entities.Concrete;
using System.Data.Entity;

namespace TmTFramework.DataAccess.Concrete.EntityFramework
{
    public  class TMTServisContext : DbContext
    {
        //1-13
        public TMTServisContext()
        {
               //Kod Tarafından Uretilmesini Engelleme
               Database.SetInitializer<TMTServisContext>(null);

            //aptal yukleme kapatmak için false açmak için true olmalı
            //LayzLoading Status is Active?
                this.Configuration.LazyLoadingEnabled = true;
        }

        //public DbSet<Ders> Dersler { get; set; }

        public DbSet<Arac> Arac { get; set; }

        public DbSet<AracArizaKayit> AracArizaKayit { get; set; }

        public DbSet<ArizaKategori> ArizaKategori { get; set; }

        public DbSet<Musteri> Musteri{ get; set; }

        public DbSet<Personel> Personel { get; set; }

        public DbSet<Servis> Servis { get; set; }

        public DbSet<Urun> Urun { get; set; }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; }





        //1-14.video
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arac>().ToTable("Arac");
            modelBuilder.Entity<AracArizaKayit>().ToTable("AracArizaKayit");
            modelBuilder.Entity<ArizaKategori>().ToTable("ArizaKategori");
            modelBuilder.Entity<Musteri>().ToTable("Musteri");
            modelBuilder.Entity<Personel>().ToTable("Personel");
            modelBuilder.Entity<Servis>().ToTable("Servis");
            modelBuilder.Entity<Urun>().ToTable("Urun");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");

            /*
            modelBuilder.Configurations.Add(new DersMap());
            modelBuilder.Configurations.Add(new AkademikPersonelMap());
            modelBuilder.Configurations.Add(new BolumMap());
            modelBuilder.Configurations.Add(new MusteriMap());

    */

        }
    }
}
