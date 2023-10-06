using System.ComponentModel.DataAnnotations;

namespace WebAPILnkdn.Model
{
    public class Salary
    {
        [Key]
        public int Id { get; set; } 

        public double Amount { get; set; }

        public List<Person> people { get; set; }

    }
}
