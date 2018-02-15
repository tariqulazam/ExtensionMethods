// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClassroomRepository.cs" company="">
//   
// </copyright>
// <summary>
//   The ClassroomRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ReusingLambdas
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The ClassroomRepository interface.
    /// </summary>
    public interface IClassroomRepository
    {
        /// <summary>
        /// The get all classrooms.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<Classroom> GetAllClassrooms();
    }
}
