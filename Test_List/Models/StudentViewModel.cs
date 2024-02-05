using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_List.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string Name { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Enrolled")]
        public DateTime DateofRegister { get; set; }
        [DisplayName("Email Address")]
        public string Email { get; set; }
        public int Units { get; set; }

        public string fullname
        {
            get { return Name + "" + LastName; }
        }
    }
}
