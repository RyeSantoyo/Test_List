using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_List.Models.Entities
{
    public class Student
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }    
        
        public string LastName { get; set; }
        public DateTime DateofRegister { get; set; }
        public string Email { get; set; }
        public int Units { get; set; }

    }
}
