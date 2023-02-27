using ExerciciosTargetSp.Services;

namespace Exercicios;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Exercício 1:");
        Console.WriteLine($"O resultado foi: {FormulasService.Result(13, 0, 0)}\n\n");


        Console.WriteLine("Exercício 2:");
        Console.Write("Informe o número que deseja saber se pertence a sequência Fibonacci: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(FormulasService.Fibonacci(number));


        Console.WriteLine("Exercício 3:");
        Console.WriteLine(FormulasService.MonthlyBilling());


        Console.WriteLine("Exercício 4:");
        double spBilling = 67836.43;
        double rjBilling = 36678.66;
        double mgBilling = 29229.88;
        double esBilling = 27165.48;
        double othersBilling = 19849.53;
        Console.WriteLine(FormulasService.Billing(spBilling, rjBilling, mgBilling, esBilling, othersBilling));


        Console.WriteLine("Exercício 5:");
        Console.Write("Digite a palavra que deseja inverter: ");
        string word = Console.ReadLine();
        Console.WriteLine(FormulasService.ReverseWord(word));
    }
}