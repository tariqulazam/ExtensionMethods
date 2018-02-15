using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReusingLambdas
{
    using System.Security.Cryptography.X509Certificates;

    //public class Program
    //{
    //    public static void Main()
    //    {
    //        var classRepo = new ClassroomRepository();
    //        var allClassrooms = classRepo.GetAllClassrooms().AsEnumerable();

    //        var productClassrooms = allClassrooms.getEmptyClassrooms();
    //        productClassrooms.ToList().ForEach(c => Console.WriteLine(c.Name));

    //        // Predicate<Classroom> namePredicate = x => x.Name.Contains("1");
    //        // Predicate<Classroom> productPredicate = x => x.ProductId == 1;

    //        // var cls = allClassrooms.Filter(new [] { namePredicate, productPredicate });

    //        //var cls = allClassrooms.getClassroomsByProduct(ProductType.Mathletics).getEmptyClassrooms();


    //        var cls = allClassrooms.Filter(classroom => classroom.Name.Contains("Math"));
    //        cls.ToList().ForEach(c => Console.WriteLine(c.Name));



    //    }
    //}

    interface IFoo
    {
        void Say();
    }

    class Foo : IFoo
    {
        public void Say()
        {
            Console.WriteLine("Instance");
        }
    }

    static class FooExts
    {
        public static void Say(this IFoo foo)
        {
            Console.WriteLine("Extension method");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFoo foo = new Foo();
            foo.Say();
        }
    }
}
