using ExerciciosTargetSp.Models;
using Newtonsoft.Json;

namespace ExerciciosTargetSp.Services;

public class FormulasService
{
    public static int Result(int index, int sum, int k)
    {
        while (k < index)
        {
            k++;
            sum += k; 
        }
        return sum;
    }

    public static string Fibonacci(int number)
    {
        int lastNumber = 0;
        int currentNumber = 1;
        int result;

        for (int i = 0; i < number; i++)
        {
            result = lastNumber + currentNumber;
            
            if (result == number)
            {
                return $"O número {number} pertence a sequência Fibonacci.\n\n";
            }

            lastNumber = currentNumber;
            currentNumber = result;
        }
        return $"O número {number} não pertence a sequência Fibonacci.\n\n";
    }
    
    public static string MonthlyBilling()
    {
        double lowerValue = 0;
        double upperValue = 0;
        double totalValue = 0;
        double averageValue = 0;
        int daysWithBilling = 0;
        int lowerValueDay = 0;
        int upperValueDay = 0;
        int sucessfulDays = 0;

        List<DailyBilling> billing = new List<DailyBilling>();

        using (StreamReader file = File.OpenText("../../../data/dados.json"))
        {
            string jsonString = file.ReadToEnd();
            billing = JsonConvert.DeserializeObject<List<DailyBilling>>(jsonString);
        }

        lowerValue = billing[0].Value;
        lowerValueDay = billing[0].Day;

        foreach (var dayBilling in billing)
        {
            if (dayBilling.Value > 0)
            {
                totalValue += dayBilling.Value;
                daysWithBilling++;
            }

            if (dayBilling.Value < lowerValue && dayBilling.Value > 0)
            {
                lowerValue = dayBilling.Value;
                lowerValueDay = dayBilling.Day;
            }
            else if (dayBilling.Value > upperValue)
            {
                upperValue = dayBilling.Value;
                upperValueDay = dayBilling.Day;
            }
        }

        averageValue = totalValue / daysWithBilling;

        foreach (var dayBilling in billing)
        {
            if (dayBilling.Value >= averageValue)
            {
                sucessfulDays++;
            }
        }

        return $"O menor valor faturado foi R$ {lowerValue.ToString("F2")} no dia {lowerValueDay}.\n" +
               $"O maior valor faturado foi R$ {upperValue.ToString("F2")} no dia {upperValueDay}.\n" +
               $"Em {sucessfulDays} dias do mês o faturamento médio de R$ {averageValue.ToString("F2")} foi ultrapassado.\n\n";
    }

    public static string Billing(double spBilling, double rjBilling, double mgBilling, double esBilling, double othersBilling)
    {
        double totalValue = spBilling + rjBilling + mgBilling + esBilling + othersBilling;

        double spPercent = spBilling / totalValue * 100;
        double rjPercent = rjBilling / totalValue * 100;
        double mgPercent = mgBilling / totalValue * 100;
        double esPercent = esBilling / totalValue * 100;
        double othersPercent = othersBilling / totalValue * 100;

        return $"O valor total de faturamento foi R$ {totalValue.ToString("F2")} e as porcentagens por estado foram:\n" +
               $"SP: {spPercent.ToString("F2")}%\n" +
               $"RJ: {rjPercent.ToString("F2")}%\n" +
               $"MG: {mgPercent.ToString("F2")}%\n" +
               $"ES: {esPercent.ToString("F2")}%\n" +
               $"Outras: {othersPercent.ToString("F2")}%\n\n";
    }

    public static string ReverseWord(string word)
    {
        string newWord = "";

        for (int i = word.Length; i > 0; i--)
        {
            newWord += word[i-1];
        }

        return newWord;
    }
}
