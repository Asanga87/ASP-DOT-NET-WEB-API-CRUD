using System.ComponentModel.DataAnnotations;

namespace WebAPILnkdn.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; } 

        public string Name { get; set; }

        public List<Position> positions { get; set; }   
    }
}
