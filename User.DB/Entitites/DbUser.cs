using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.DB.Entitites
{
    /// <summary>
    /// Модель задачи
    /// </summary>
    public class DbUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateOnly Birthday { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? DeletAt { get; set; }


    }
}
