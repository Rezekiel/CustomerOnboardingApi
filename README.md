# Customer Onboarding Microservice API
This is a microservice API built with **ASP.NET Core** that handles customer onboarding with OTP verification, state–LGA validation, and external bank listing integration.

Requirements
Build a Microservice Api that would have the following endpoints:
1. Onboard a customer: The endpoint should take phone Number, email, password,
state of residence, and LGA.
Business Rule
(i) The phone number should be verified via OTP before onboarding is said to be
completed
(ii) The LGA must be mapped to the state selected.
(iii) Mock sending the OTP.

2. Endpoint to return all existing customers previously onboarded

3. An endpoint that will return the existing Bank: browse the link below, you will find an
endpoint called Getbanks. Consume that endpoint and output the result you

Note.
- Use ASP.NET Core to build the api, add Swagger documentation
- Use Microsoft SQL DB and Entity Framework.
- ensure that you apply all standard engineering principles, be mindful of the pattern you
apply and also consider adding unit testing
- Push your code to a public git repo and share the link



Clone & Run
git clone https://github.com/Rezekiel/CustomerOnboardingApi.giT
cd CustomerOnboardingApi
dotnet restore
dotnet ef database update
dotnet run
https://localhost:5108/swagger


###############################################################################################

# GET /api/bank/list
- Returns bank list fetched live from Wema's API

  
# POST /api/customer/onboard
{
  "email": "john@example.com",
  "phoneNumber": "3126783678",
  "password": "SecureP@ssw0rd",
  "state": "Lagos",
  "lga": "Ikeja"
}

 - Returns OTP message to simulate SMS.
 - Will reject if LGA doesn't belong to the state.

 # POST /api/customer/verify-otp

{
  "phoneNumber": "3126783678",
  "otp": "{random otp}"
}
- Verifies OTP and completes onboarding

# GET /api/customer/all
- Returns all onboarded and verified customers


# LGA-State Validation
- Implemented in Utils/StateLgaValidator.cs with a dictionary map:

 {
        ["Lagos"] = new List<string> { "Ikeja", "Surulere", "Epe", "Ikorodu", "Eti-Osa", "Alimosho" },
        ["Oyo"]= new List<string> { "Ibadan North", "Ibadan South-West", "Ibarapa East", "Ogbomosho North", "Afijio" } ,
        ["Abuja"]= new List<string> { "Abaji", "Bwari", "Gwagwalada", "Kuje", "Kwali", "Municipal Area Council" } ,
        ["Kano"] = new List<string> { "Dala", "Fagge", "Gwale", "Nasarawa", "Tarauni" } ,
        ["Kaduna"] = new List<string> { "Chikun", "Kaduna North", "Kaduna South", "Zaria", "Jema'a" },
        [ "Rivers"] = new  List<string> { "Port Harcourt", "Obio/Akpor", "Bonny", "Ikwerre", "Eleme" },
        ["Enugu"] = new  List<string> { "Enugu East", "Enugu North", "Nsukka", "Udi", "Igbo Etiti" } ,
        ["Anambra"] = new  List<string> { "Awka South", "Awka North", "Onitsha North", "Onitsha South", "Nnewi North" } ,
        ["Delta"] = new  List<string> { "Oshimili North", "Oshimili South", "Warri South", "Sapele", "Ukwuani" } ,
        ["Osun"] = new  List<string> { "Osogbo", "Ife Central", "Ede South", "Ilesa East", "Irewole" }
    }





