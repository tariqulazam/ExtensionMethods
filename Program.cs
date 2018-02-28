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
            var allClassrooms = classRepo.GetAllClassrooms();

            //#region Expressive Expressions

            //// Traditional ways
            //var emptyClassrooms = allClassrooms.Where(
            //    classroom => classroom.ProductId == (int)ProductType.Mathletics && !classroom.StudentsId.Any());

            //emptyClassrooms.ToList().ForEach(cls => cls.IsActive = false);

            //// More expressive ways
            //allClassrooms.GetProductClassrooms(ProductType.Mathletics).GetEmptyClassrooms().Deactivate();

            //#endregion

            //#region Used as dynamic filters

            //Predicate<Classroom> namePredicate = x => x.Name.Contains("1");
            //Predicate<Classroom> productPredicate = x => x.ProductId == 1;

            //var filteredClassrooms = allClassrooms.Filter(new [] { namePredicate, productPredicate });

            //#endregion

            #region Usage of Aggregate

            var mergedClassroom = allClassrooms.GetProductClassrooms(ProductType.Mathletics).Merge();

            #endregion

            Console.ReadLine();
        }
    }
}
