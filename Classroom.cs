using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReusingLambdas
{
    public class Classroom
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public IEnumerable<int> StudentsId { get; set; }

        /// <summary>
        /// The is active.
        /// </summary>
        public bool IsActive { get; set; }
    }
}
