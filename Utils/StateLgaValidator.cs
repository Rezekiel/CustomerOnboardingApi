
using System.Collections.Generic;
public static class StateLgaValidator
{
    private static readonly Dictionary<string, List<string>> ValidStateLga = new()
    {
        ["Lagos"] = new List<string> { "Ikeja", "Epe", "Ikorodu" },
        ["Kano"] = new List<string> { "Nasarawa", "Tarauni", "Dala" }
    };

    public static bool IsValid(string state, string lga)
    {
        return ValidStateLga.TryGetValue(state, out var lgas) && lgas.Contains(lga);
    }
}
