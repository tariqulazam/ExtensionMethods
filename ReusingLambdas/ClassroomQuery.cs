// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassroomQuery.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the ClassroomQuery type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ReusingLambdas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The classroom query.
    /// </summary>
    public static class ClassroomQuery
    {
        /// <summary>
        /// The get classrooms by product id.
        /// </summary>
        private static Func<IEnumerable<Classroom>, int, IEnumerable<Classroom>> getClassroomByProduct =
            (classrooms, productId) => classrooms.Where(cls => cls.ProductId == productId);

        /// <summary>
        /// The get classrooms by product.
        /// </summary>
        /// <param name="classrooms">
        /// The classrooms.
        /// </param>
        /// <param name="productType">
        /// The product Type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public static IEnumerable<Classroom> getClassroomsByProduct(
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
        /// The get classrooms by product.
        /// </summary>
        /// <param name="classrooms">
        /// The classrooms.
        /// </param>
        /// <param name="predicate">
        /// The predicate.
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

        public static IEnumerable<Classroom> getEmptyClassrooms(this IEnumerable<Classroom> classrooms)
        {
            return classrooms.Where(cls => cls.isEmptyClassroom());
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
        public static bool isEmptyClassroom(this Classroom classroom)
        {
            return classroom.StudentsId == null || !classroom.StudentsId.Any();
        }
    }
}
