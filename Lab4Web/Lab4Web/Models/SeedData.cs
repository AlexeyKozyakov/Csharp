using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace lab4Web.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var db = new DataContext(
                serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                if (db.Employees.Any() || db.Projects.Any())
                {
                    return;
                }

                db.Employees.AddRange(
                    new Employee()
                    {
                        Name = "Alexey",
                        Surname = "Kozyakov",
                        Patronymic = "Pavlovich"
                    },
                    new Employee()
                    {
                        Name = "Ivan",
                        Surname = "Ivanov",
                        Patronymic = "Ivanovich"
                    },
                    new Employee()
                    {
                        Name = "Sergey",
                        Surname = "Nikitin",
                        Patronymic = "Valeryevich"
                    },
                    new Employee()
                    {
                        Name = "Maxim",
                        Surname = "Andreev",
                        Patronymic = "Yuryivich"
                    },
                    new Employee()
                    {
                        Name = "Valeriy",
                        Surname = "Jmishenko",
                        Patronymic = "Albertovich"
                    });
                
                db.Projects.AddRange(
                    new Project()
                    {
                        Name = "Opredelenie vesa grifa",
                        Award = 1000,
                        EmployeeId = 1
                        
                    },
                    new Project()
                    {
                        Name = "Raschistka krishi",
                        Award = 300,
                        EmployeeId = 1
                    },
                    new Project()
                    {
                        Name = "Osmotr mesnosty",
                        Award = 25,
                        EmployeeId = 3
                    },
                    new Project()
                    {
                        Name = "Vihod iz zoni comforta",
                        Award = 1000000,
                        EmployeeId = 3
                    },
                    new Project()
                    {
                        Name = "Lol what?",
                        Award = 1337,
                        EmployeeId = 4
                    });
                db.SaveChanges();
            }
        }
    }
}