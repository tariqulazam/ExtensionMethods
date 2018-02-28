using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReusingLambdas
{
    using System.Collections;

    /// <summary>
    /// The classroom extension.
    /// </summary>
    public static class ClassroomExtension
    {
        /// <summary>
        /// The get classrooms by product id.
        /// </summary>
        private static Func<IEnumerable<Classroom>, int, IEnumerable<Classroom>> getClassroomByProduct =
            (classrooms, productId) => classrooms.Where(cls => cls.ProductId == productId);

        /// <summary>
        /// The is empty.
        /// </summary>
        private static Func<Classroom, bool> isEmpty =
            classroom => classroom.StudentsId != null && !classroom.StudentsId.Any();

        /// <summary>
        /// The deactivate.
        /// </summary>
        private static Action<Classroom> deactivate = classroom => classroom.IsActive = false;

        /// <summary>
        /// The get product classrooms.
        /// </summary>
        /// <param name="classrooms">
        /// The classrooms.
        /// </param>
        /// <param name="productType">
        /// The product type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<Classroom> GetProductClassrooms(
            this IEnumerable<Classroom> classrooms,
            ProductType productType)
        {
            return getClassroomByProduct(classrooms, (int)productType);
        }

        /// <summary>
        /// The filter.
        /// </summary>
        /// <param name="classrooms">
        /// The classrooms.
        /// </param>
        /// <param name="criteria">
        /// The criteria.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<Classroom> Filter(
            this IEnumerable<Classroom> classrooms,
            Func<Classroom, bool> criteria)
        {
            return classrooms.Where(criteria);
        }

        /// <summary>
        /// The filter.
        /// </summary>
        /// <param name="classrooms">
        /// The classrooms.
        /// </param>
        /// <param name="predicates">
        /// The predicates.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<Classroom> Filter(
            this IEnumerable<Classroom> classrooms,
            IEnumerable<Predicate<Classroom>> predicates)
        {
            var filteredResult = classrooms;
            predicates.ToList().ForEach(predicate => filteredResult = filteredResult.Where(predicate.Invoke));
            return filteredResult;
        }

        /// <summary>
        /// The get empty classrooms.
        /// </summary>
        /// <param name="classrooms">
        /// The classrooms.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<Classroom> GetEmptyClassrooms(this IEnumerable<Classroom> classrooms)
        {
            return classrooms.Where(isEmpty);
        }

        /// <summary>
        /// The is empty classroom.
        /// </summary>
        /// <param name="classroom">
        /// The classroom.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsEmptyClassroom(this Classroom classroom)
        {
            return isEmpty(classroom);
        }

        /// <summary>
        /// The deactivate.
        /// </summary>
        /// <param name="classrooms">
        /// The classrooms.
        /// </param>
        public static void Deactivate(this IEnumerable<Classroom> classrooms)
        {
            classrooms.ToList().ForEach(deactivate);
        }

        /// <summary>
        /// The get all assigned students.
        /// </summary>
        /// <param name="classrooms">
        /// The classrooms.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<int> GetAllAssignedStudents(this IEnumerable<Classroom> classrooms)
        {
            return classrooms.SelectMany(cls => cls.StudentsId).Distinct();
        }

        /// <summary>
        /// The merge.
        /// </summary>
        /// <param name="classrooms">
        /// The classrooms.
        /// </param>
        /// <returns>
        /// The <see cref="Classroom"/>.
        /// </returns>
        public static Classroom Merge(this IEnumerable<Classroom> classrooms)
        {
            return classrooms.Aggregate((class1, class2) => new Classroom()
                                                        {
                                                            Name = $"{class1.Name}, {class2.Name}",
                                                            ProductId = class1.ProductId,
                                                            StudentsId = class1.StudentsId.Concat(class2.StudentsId).Distinct()
                                                        });
        }

        /// <summary>
        /// The get all assigned students in classrooms.
        /// </summary>
        /// <param name="classrooms">
        /// The classrooms.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<int> GetAllAssignedStudentsInClassrooms(this IEnumerable<Classroom> classrooms)
        {
            return classrooms.Aggregate(
                Enumerable.Empty<int>(),
                (ids, classroom) => ids.Concat(classroom.StudentsId));
        }
    }
}
