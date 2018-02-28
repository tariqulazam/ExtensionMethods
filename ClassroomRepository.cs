// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassroomRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The classroom repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ReusingLambdas
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The classroom repository.
    /// </summary>
    public class ClassroomRepository : IClassroomRepository
    {
        /// <summary>
        /// The get all classrooms.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IQueryable<Classroom> GetAllClassrooms()
        {
            return new[]
                       {
                           new Classroom() { Id = 1, ProductId = 1, Name = "Math 1", IsActive = true, StudentsId = Enumerable.Empty<int>() },
                           new Classroom() { Id = 2, ProductId = 1, Name = "Math 2", IsActive = false, StudentsId = new[]{ 1, 2, 3 }},
                           new Classroom() { Id = 3, ProductId = 1, Name = "Math 3", IsActive = true, StudentsId = new[]{ 3, 4, 5 } },
                           new Classroom() { Id = 4, ProductId = 3, Name = "Spello 1", IsActive = true, StudentsId = new[]{ 3, 4, 6, 7 }},
                           new Classroom() { Id = 5, ProductId = 3, Name = "Spello 2", IsActive = true, StudentsId = Enumerable.Empty<int>() },
                           new Classroom() { Id = 6, ProductId = 8, Name = "ReadiWriter 1", IsActive = true, StudentsId = Enumerable.Empty<int>() }
                       }.AsQueryable();
        }
    }
}
