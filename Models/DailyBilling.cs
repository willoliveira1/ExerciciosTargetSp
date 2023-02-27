using Newtonsoft.Json;

namespace ExerciciosTargetSp.Models;

public class DailyBilling
{
    [JsonProperty(PropertyName = "dia")]
    public int Day { get; set; }

    [JsonProperty(PropertyName = "valor")]
    public double Value { get; set; }

    public DailyBilling()
    {
    }
}