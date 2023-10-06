using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPILnkdn.Model
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Person> people { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public Department department { get; set; }  
    }
}
