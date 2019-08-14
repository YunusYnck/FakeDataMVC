using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FakeData_MVC.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Ulke> Ulkeler { get; set; }
        public DbSet<Adresler> Adres{ get; set; }
        public DatabaseContext()
        {
            Database.SetInitializer < DatabaseContext>(new Olusturucu());
        }
    }
    public class Olusturucu : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            List<Ulke> ulkeList = new List<Ulke>();
            for (int i = 0; i < 10; i++)
            {
                Ulke ulke = new Ulke();
                ulke.Ad = FakeData.PlaceData.GetCountry();
                ulkeList.Add(ulke);
                context.Ulkeler.Add(ulke);
            }
            context.SaveChanges();
            for(int i=0;i<100;i++)
            {
                Personel personel = new Personel();
                personel.Ad = FakeData.NameData.GetFirstName();
                personel.Soyad = FakeData.NameData.GetSurname();
                personel.Yas = FakeData.NumberData.GetNumber(10,90);
                Random r = new Random();
                int deger = r.Next(0, 10);
                personel.Ulke = ulkeList[deger];
                context.Personeller.Add(personel);
            }
            context.SaveChanges();
        }

    }

}