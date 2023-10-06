using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPILnkdn.Model
{
    public class Person
    {
        [Key]
        public int  ID { get; set; }

        public string Name { get; set; }

        public string Addreess { get; set; }

        //Postion Foreign Key
        [ForeignKey("Position")]
        public int PositionID { get; set; } 

        public Position? position { get; set; }

        //Salary Foreign Key

        [ForeignKey("Salary")]
        public int SalaryID { get; set; }

        public Salary? salary { get; set; }

        public PersonDetail? personDetail { get;  set; }
    }
}
