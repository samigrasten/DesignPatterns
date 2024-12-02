namespace ECommerceSystem.Features.Shared.Renderers;

public static class Screen
{
    public static void Output(string message = "")
        => Output(message, ConsoleColor.Gray);
    
    public static void OutputHighlight(string message)
        => Output(message, ConsoleColor.White);
    
    public static void OutputSuccess(string message)
        => Output(message, ConsoleColor.Green);
    
    public static void OutputWarning(string message)
        => Output(message, ConsoleColor.Yellow);

    public static void OutputError(string message)
        => Output(message, ConsoleColor.Red);


    private static void Output(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
    }

    public static int GetInteger(string message, int? minValue = null, int? maxValue = null, string? errorMessage = null)
    {
        while(true) 
        {
            Console.Write(message);
            var isValidInteger = int.TryParse(Console.ReadLine(), out var value);
            if (isValidInteger 
                && (minValue == null || value >= minValue) 
                && (maxValue == null || value <= maxValue)) return value;
            
            if (errorMessage != null) Console.WriteLine(errorMessage);
        } 
    }

    public static int GetChoice(string title, string[] options, string prompt)
    {
        Output($"\n{title}");
        var index = 1;
        foreach (var option in options) Output($"{index++}. {option}");
        var choice = GetInteger(prompt, 1, options.Length);
        return choice;
    }
}