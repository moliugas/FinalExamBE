namespace FinalExamBE.Database.Entities
{
    public class PersonDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[]? ProfilePicture { get; set; }
    }
}
