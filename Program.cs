/*
C# for Grandchildren: educational console application
*/

using static System.Console;

WriteTitle("Фаренгейт - Цельсий");

while(true)
{
    Action();
    string answer = EnterText("Хотите продолжить? (д/н y/n): ");
    if(answer.ToLower() != "д" && answer.ToLower() != "y")
        break;
    WriteLine();
}

ExitApp();

void Action()
{
    const double absoluteZeroC = -273.15;
    const double absoluteZeroF = -459.67;

    double t = EnterDouble("Введите температуру: ");
    string scale = EnterText("Введите шкалу (C/F): ");

    if(scale.ToLower() == "c")
    {
        if(t < absoluteZeroC)
        {
            WriteLine($"Температура не может быть ниже абсолютного нуля ({absoluteZeroC} C).");
            return;
        }

        double f = t * 9 / 5 + 32;
        WriteLine($"{t} C => {f:F2} F");
    }
    else if(scale.ToLower() == "f")
    {
        if(t < absoluteZeroF) 
        {
            WriteLine($"Температура не может быть ниже абсолютного нуля ({absoluteZeroF} F).");
            return;
        }
        double c = (t - 32) * 5 / 9;
        WriteLine($"{t} F => {c:F2} C");
    }
    else
    {
        WriteLine("Некорректная шкала. Пожалуйста, введите C или F.");
    }
}

void WriteTitle(string title)
{
    WriteLine(title);
    WriteLine(new string('-', title.Length));
    WriteLine();
}

void ExitApp()
{
    WriteLine();
    Write("Для выхода нажми Enter");
    ReadLine();
}

string EnterText(string prompt)
{
    Write(prompt);
    return ReadLine();
}

int EnterInteger(string prompt)
{
    string input = EnterText(prompt);
    bool result = int.TryParse(input, out int number);
    while(!result)
    {
        input = EnterText($"Некорректный ввод. {prompt}");
        result = int.TryParse(input, out number);
    }
    return number;
}

double EnterDouble(string prompt)
{
    string input = EnterText(prompt);
    bool result = double.TryParse(input, out double number);
    while(!result)
    {
        input = EnterText($"Некорректный ввод. {prompt}");
        result = double.TryParse(input, out number);
    }
    return number;
}