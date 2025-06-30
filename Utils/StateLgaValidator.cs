
using System.Collections.Generic;
public static class StateLgaValidator
{
    private static readonly Dictionary<string, List<string>> ValidStateLga = new()
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
    

    };

    public static bool IsValid(string state, string lga)
    {
        return ValidStateLga.TryGetValue(state, out var lgas) && lgas.Contains(lga);
    }
}
