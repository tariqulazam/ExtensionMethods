using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReusingLambdas
{
    public class Program
    {
        public static void Main()
        {
            var classRepo = new ClassroomRepository();
            var allClassrooms = classRepo.GetAllClassrooms().AsEnumerable();

            var productClassrooms = allClassrooms.getEmptyClassrooms();
            productClassrooms.ToList().ForEach(c => Console.WriteLine(c.Name));

            Predicate<Classroom> namePredicate = x => x.Name.Contains("1");
            Predicate<Classroom> productPredicate = x => x.ProductId == 1;

            var cls = allClassrooms.Filter(new [] { namePredicate, productPredicate });

            cls.ToList().ForEach(c => Console.WriteLine(c.Name));
        }
    }
}
