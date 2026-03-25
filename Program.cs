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