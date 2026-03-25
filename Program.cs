/*
C# for Grandchildren: educational console application
*/

/*
ввод шкалы сразу после температуры, например: 25 C или 77 F
берем последний символ строки, проверяем, запоминаем и отбрасыаем
убираем пробелы и парсим число
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

    bool success = TryParseTemperature(out double t, out char scale);
    while(!success)
    {
        WriteLine("Ошибка в данных!");
        success = TryParseTemperature(out t, out scale);
    }

    if(scale == 'c')
    {
        if(t < absoluteZeroC)
        {
            WriteLine($"Температура не может быть ниже абсолютного нуля ({absoluteZeroC} C).");
            return;
        }

        double f = t * 9 / 5 + 32;
        WriteLine($"{t} C => {f:F2} F");
    }
    else if(scale == 'f')
    {
        if(t < absoluteZeroF) 
        {
            WriteLine($"Температура не может быть ниже абсолютного нуля ({absoluteZeroF} F).");
            return;
        }
        double c = (t - 32) * 5 / 9;
        WriteLine($"{t} F => {c:F2} C");
    }
}

bool TryParseTemperature(out double temperature, out char scale)
{
    string input = EnterText("Введите температуру и шкалу (например, 25C или 77 F): ");
    scale = input.ToLower()[input.Length - 1];
    string numberPart = input.Substring(0, input.Length - 1).Trim();
    bool success = double.TryParse(numberPart, out temperature);
    return success && (scale == 'c' || scale == 'f');   
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