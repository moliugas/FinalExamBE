using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExamBE.Database.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        [ForeignKey("Person")]
        public Guid? PersonId { get; set; }
    }
}
