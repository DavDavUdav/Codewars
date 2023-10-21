using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            Console.WriteLine("Запустилось");
            PRobnik();
            Console.WriteLine("Отработало");
            Console.ReadLine();
        }

        public static async void PRobnik()
        {
            ApplicationContext db = new ApplicationContext();

            await db.Users.AddAsync(new User
            {
                name = "Stepan",
                age = 20
            });
            await db.SaveChangesAsync();

            User users = await db.Users.FirstAsync(x => x.age==20);
            Console.WriteLine(users.name);
        }
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationContext() 
        { 
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb1;Username=postgres;Password=Xe00n@43");
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class User
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; } = "UndefinedName";


        public int age { get; set; }
    }
}