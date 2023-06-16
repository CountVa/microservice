namespace User.API.Models
{
    public class DtoUser
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public DateOnly Birthday { get; set; }

        public DateTime CreatedAt { get; set; }


    }
}
