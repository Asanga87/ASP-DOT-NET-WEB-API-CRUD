using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPILnkdn.Model
{
    public class PersonDetail
    {
        [Key]
        public int Id { get; set; } 

        public string PersonCity { get; set; }

        public DateTime Birthday { get; set; }

        [ForeignKey("Person")]
        public int PersonID { get; set; }

        public Person Person { get; set; }  
    }
}
