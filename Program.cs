using System.IO;

Menu();

void Menu()
{
Console.Clear();
Console.WriteLine("O que você precisa?");
Console.WriteLine("1 - Abrir arquivo");
Console.WriteLine("2 - Criar novo arquivo");
Console.WriteLine("0 - Sair");

short option = short.Parse(Console.ReadLine());

switch(option)
{
    case 0 :System.Environment.Exit(0); break;
    case 1 :Open(); break;
    case 2 :Edit(); break;
    default: Menu(); break;

}
}


void Open() 
{
    Console.Clear();
    Console.WriteLine("Qual o caminho do arquivo?");
    string path = Console.ReadLine();

    using(var file = new StreamReader(path))
    {
        string text = file.ReadToEnd();
        Console.WriteLine(text);
    }

    Console.WriteLine("");
    Console.ReadLine();
    Menu();
}

void Edit()
{
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo (ESC PARA SAIR)");
    Console.WriteLine("--------------------");
    string text = "";
    do 
    {
        text += Console.ReadLine();
        text += Environment.NewLine;
    }
    while(Console.ReadKey().Key != ConsoleKey.Escape);
    Console.Write(text);

    SaveFile(text);
    
}

void SaveFile(string text)
{
    Console.Clear();
    Console.WriteLine("Qual caminho para salvar o arquivo?");
    var path = Console.ReadLine();

    using (var file = new StreamWriter(path))
    {
        file.Write(text);
    }

    Console.WriteLine($"Arquivo {path} salvo com sucesso!");
    Console.ReadLine();
    Menu();
}