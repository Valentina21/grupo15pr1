using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [Table("PART_TIME_EMP")]
    public class PartTimeEmployee : Employee
    {
        [Column("RATE")]
        public double HourlyDate { get; set; }
    }
}
