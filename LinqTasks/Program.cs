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
             var query7 = buyers.SelectMany(b => b.Cars).GroupBy(c => c.Model)
                .Select(g => new { Model = g.Key, Count = g.Count() })
                .OrderByDescending(c => c.Count).Take(3);

            /* 8. Названия улиц и названия моделей автомобилей, встречающихся у жильцов этой улицы
                (названия моделей хранятся в одном свойстве через запятую, и отсортированы по их количеству на этой улице) */
            //
            var query8 = buyers.GroupBy(b => b.Address.Street)
                .Select(s => new { Street = s.Key, Cars = string.Join(", ", s.SelectMany(b => b.Cars).GroupBy(c => c.Model).OrderByDescending(c => c.Count()).Select(c => c.Key)) });
     
            /* 9. Полные имена, зарплаты и полный адрес покупателей не имеющих автомобилей */

                var query9 = buyers.Where(b => !b.Cars.Any())
                .Select(r => new { Name = $"{r.FirstName} {r.LastName}", Adress = $"{r.Address.Street} {r.Address.Building}", Salary = r.Salary});

            /* 10. Фамилии покупателей, которые не имеют машин, но которые могут себе позволить за пол года, 
                откладывая по 20 % зарплаты, купить самый недорогой из проданных автомобилей */
            // 
            var query10 = buyers.Where(b => !b.Cars.Any())
               .Where(b => b.Salary * 6 * 0.2 >= buyers.SelectMany(b => b.Cars).Min(x => x.Price))
               .Select(r => r.LastName);


            // Названия улиц и названия моделей самого дорогого и самого дешевого автомобиля на ней
            var query11_1 = buyers.GroupBy(b => b.Address.Street)
                .Select(g => new { Street = g.Key, Max = g.SelectMany(b => b.Cars).OrderByDescending(c => c.Price).FirstOrDefault()?.Model});
            var query11_2 = buyers.GroupBy(b => b.Address.Street)
               .Select(g => new { Street = g.Key, Min = g.SelectMany(b => b.Cars).OrderBy(c => c.Price).FirstOrDefault()?.Model });
            var query11 = query11_1.Join(query11_2, s => s.Street, t => t.Street, (max, min) => new { Street = min.Street, Min = min.Min, Max = max.Max});

            //12. Фамилии покупателей и названия моделей автомобилей (строка через запятую), которых нет у
            //соседей (соседями считаются один или два дома, находящиеся на той же стороне улицы)


           /* var query12 = buyers.Where(b => !b.Cars.Any())
             .Where(b => b.Address.Building % 2 > 0)
             .OrderBy(b => b.Address.Building)
             .GroupBy(b => b.Address.Street)
             .Select(b => new LinkedList<Buyer>(b))
             .Aggregate(new List<object>(), (list, linkedList) =>
             {

             }; */


            //15. Название модели, самая дорогая модель, самая дешёвая

            var query15_1 = buyers.SelectMany(b => b.Cars).GroupBy(c => c.Model).Select(g => new { Model = g.Key, Max = g.Select(c=> c.Price).Max()});
            var query15_2 = buyers.SelectMany(b => b.Cars).GroupBy(c => c.Model).Select(g => new { Model = g.Key, Min = g.Select(c => c.Price).Min() });
            var query15 = query15_1.Join(query15_2, c => c.Model, b => b.Model, (max, min) => new { Model = max.Model, Max = max.Max, Min = min.Min });

            foreach (var item in query8)
            {
                Console.WriteLine(item);
            }
        }
    }
}
