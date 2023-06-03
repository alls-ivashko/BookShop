namespace BackendApi.Contracts
{
    public class GetUserResponse
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public int? ZipCode { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? House { get; set; }
        public int? Flat { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public bool Deleted { get; set; }
    }
}
