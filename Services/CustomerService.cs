using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerOnboardingApi.Data;
using CustomerOnboardingApi.DTOs;
using CustomerOnboardingApi.Models;
using Microsoft.EntityFrameworkCore;


namespace CustomerOnboardingApi.Services
{
    public class CustomerService
    {
        private readonly AppDbContext _context;
        private readonly OtpService _otpService;

        private readonly Dictionary<string, List<string>> _stateLgaMap = new()
        {
            { "Lagos", new List<string> { "Ikeja", "Surulere", "Epe", "Ikorodu", "Eti-Osa", "Alimosho" } },
        { "Oyo", new List<string> { "Ibadan North", "Ibadan South-West", "Ibarapa East", "Ogbomosho North", "Afijio" } },
        { "Abuja", new List<string> { "Abaji", "Bwari", "Gwagwalada", "Kuje", "Kwali", "Municipal Area Council" } },
        { "Kano", new List<string> { "Dala", "Fagge", "Gwale", "Nasarawa", "Tarauni" } },
        { "Kaduna", new List<string> { "Chikun", "Kaduna North", "Kaduna South", "Zaria", "Jema'a" } },
        { "Rivers", new List<string> { "Port Harcourt", "Obio/Akpor", "Bonny", "Ikwerre", "Eleme" } },
        { "Enugu", new List<string> { "Enugu East", "Enugu North", "Nsukka", "Udi", "Igbo Etiti" } },
        { "Anambra", new List<string> { "Awka South", "Awka North", "Onitsha North", "Onitsha South", "Nnewi North" } },
        { "Delta", new List<string> { "Oshimili North", "Oshimili South", "Warri South", "Sapele", "Ukwuani" } },
        { "Osun", new List<string> { "Osogbo", "Ife Central", "Ede South", "Ilesa East", "Irewole" } }
        };

        public CustomerService(AppDbContext context, OtpService otpService)
        {
            _context = context;
            _otpService = otpService;
        }

        public bool ValidateLga(string state, string lga)
        {
            return _stateLgaMap.ContainsKey(state) && _stateLgaMap[state].Contains(lga);
        }

        public async Task<string> OnboardCustomerAsync(CustomerOnboardRequest request)
        {
            if (!ValidateLga(request.State, request.Lga))
                return "Invalid LGA for selected state.";

            var existing = await _context.Customers
                .FirstOrDefaultAsync(c => c.PhoneNumber == request.PhoneNumber);

            if (existing != null)
                return "Phone number already exists.";

            var customer = new Customer
            {
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Password = request.Password,
                State = request.State,
                Lga = request.Lga,
                IsPhoneVerified = false
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            _otpService.GenerateOtp(request.PhoneNumber);
            return "OTP sent to phone number.";
        }

        public async Task<string> VerifyOtpAsync(OtpVerificationRequest request)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.PhoneNumber == request.PhoneNumber);

            if (customer == null)
                return "Customer not found.";

            if (_otpService.VerifyOtp(request.PhoneNumber, request.Otp))
            {
                customer.IsPhoneVerified = true;
                await _context.SaveChangesAsync();
                return "Phone number verified.";
            }

            return "Invalid OTP.";
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}