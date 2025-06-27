namespace CustomerOnboardingApi.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string State { get; set; }

        public string Lga { get; set; }

        public bool IsPhoneVerified { get; set; }
    }
}
