using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Buyer> buyers = Initializer.GenerateData().ToList();

            /* 1. Полные имена и количество машин у покупателей, чья зарплата больше 1000 */
            var query = buyers.Where(b => b.Salary > 1000)
                .Select(b => new { FullName = $"{b.FirstName} {b.LastName}", CarCount = b.Cars.Count() });

            /* 2. Имена покупателей, которые могут купить хотя бы один из своих автомобилей за одну зарплату 
                (если таких автомобилей несколько вывести первый из них) */
            var query2 = buyers.Where(b => b.Cars.Any(c => c.Price > b.Salary))
                .Select(b => new { b.FirstName });

            /* 3. Названия улиц и фамилии покупателей живущих на ней(фамилии хранятся в одном свойстве через запятую) */
            var query3 = buyers.GroupBy(b => b.Address.Street)
                .Select(r => new { Street = r.Key, Persons = string.Join(", ", r.Select(b => b.LastName)) });

            /* 4. Имена покупателей, чья годовая зарплата меньше стоимости всех машин, 
                которыми он владеет и сумма на которую годовая зарплата меньше */
            var query4 = buyers.Where(b => b.Cars.Sum(c => c.Price) > b.Salary * 12)
                .Select(r => new { Name = r.FirstName, Difr = r.Cars.Sum(c => c.Price) - r.Salary * 12 });

            /* 5. Названия улиц и количество покупателей живущих на нечетной стороне каждой из улиц */
            var query5 = buyers.Where(b => b.Address.Building % 2 != 0).GroupBy(b => b.Address.Street)
                .Select(r => new { Street = r.Key, Count = r.Count() });

           /* 6. Полные имена и полный адрес покупателей, владеющих хотя бы одной машиной не старше 2 лет */
            var query6 = buyers.Where(b => b.Cars.Any(c => c.ReleaseDate.AddYears(2) >= DateTime.Now))
                .Select(r => new { Name = $"{r.FirstName} {r.LastName}", Adress = $"{r.Address.Street} {r.Address.Building}" });

           /* 7. Топ 3 автомобилей по продажам: название модели и количество продаж */
  //
            var query7 = buyers.SelectMany(b => b.Cars)
                .OrderByDescending(d => d.Buyer.FirstName.Count())
                .Select(r => new { Model = r.Model, Count = r.Buyer.FirstName.Count() });

            //var query767 = buyers.GroupBy(b => b.Cars.Select(c => c.Model))
            //    .OrderByDescending(d => d.Select(v => v.FirstName.Count()))
            //    .Select(r => new { Model = r.Key, Count = string.Join(", ", r.Select(v => v.FirstName)) });

            /* 8. Названия улиц и названия моделей автомобилей, встречающихся у жильцов этой улицы
                (названия моделей хранятся в одном свойстве через запятую, и отсортированы по их количеству на этой улице) */
            //
            var query8 = buyers.GroupBy(b => b.Address)
                .Select(r => new { Street = r.Key.Street, Models = string.Join(", ", r.Select(c => c.Cars)) });

            /* 9. Полные имена, зарплаты и полный адрес покупателей не имеющих автомобилей */
            var query9 = buyers.Where(b => !b.Cars.Any())
                .Select(r => new { Name = $"{r.FirstName} {r.LastName}", Adress = $"{r.Address.Street} {r.Address.Building}", Salary = r.Salary});

            /* 10. Фамилии покупателей, которые не имеют машин, но которые могут себе позволить за пол года, 
                откладывая по 20 % зарплаты, купить самый недорогой из проданных автомобилей */
  // 
            var query10 = buyers.Where(b => !b.Cars.Any())
                //  .Where(b => b.Cars.SelectMany(c => b.Salary.CompareTo(b => b*6*20%) > c.Price))         //(c => c.Price < b.Salary *6*20%))
                  .Select(r => r.LastName);

            foreach (var item in query7)
            {
                Console.WriteLine(item);
            }
        }
    }
}
