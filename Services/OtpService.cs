using System;
using System.Collections.Generic;

namespace CustomerOnboardingApi.Services
{
    public class OtpService
    {
        private readonly Dictionary<string, string> _otpStore = new();

        public string GenerateOtp(string phoneNumber)
        {
            var otp = new Random().Next(100000, 999999).ToString();
            _otpStore[phoneNumber] = otp;
            Console.WriteLine($"Mock OTP sent to {phoneNumber}: {otp}");
            return otp;
        }

        public bool VerifyOtp(string phoneNumber, string otp)
        {
            return _otpStore.TryGetValue(phoneNumber, out var storedOtp) && storedOtp == otp;
        }
    }
}
