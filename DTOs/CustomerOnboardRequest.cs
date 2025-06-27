namespace CustomerOnboardingApi.DTOs
{
    public class CustomerOnboardRequest
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }
    }
}
