namespace FinalExamBE.Database.Entities
{
    public class User : GenericEntity
    { 
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public Person Person { get; set; }
    }   
}
