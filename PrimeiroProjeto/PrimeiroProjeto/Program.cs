// Screen Sound
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> { "U2", "The Beatles", "Calypso" };

Dictionary<string, List<decimal>> bandasEAsuasNotas = new Dictionary<string, List<decimal>>();
bandasEAsuasNotas.Add("U2", new List<decimal> { 10, 9, 8 });
bandasEAsuasNotas.Add("The Beatles", new List<decimal>());
void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            ExibirMediaAvaliacaoBanda();
            break;
        case -1:
            Console.WriteLine("Fechando programa...s");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasEAsuasNotas.Add(nomeDaBanda, new List<decimal>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000); // Pausa de 2 segundos
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");

    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
    //Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}

    foreach (string banda in bandasEAsuasNotas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void ExibirTituloDaOpcao(string titulo) {
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
}

void AvaliarBanda()
{
    //se a banda existir, atribuir nota
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.WriteLine("Digite o nome da banda que deseja avaliar: ");
    string? nomeBanda = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(nomeBanda) && bandasEAsuasNotas.ContainsKey(nomeBanda))
    {
        Console.WriteLine($"Qual a nota que a banda {nomeBanda} merece: ");
        string? entradaNota = Console.ReadLine();

        if (decimal.TryParse(entradaNota, out decimal nota) && nota >= 0 && nota <= 10)
        {
            bandasEAsuasNotas[nomeBanda].Add(nota);
            Console.WriteLine($"A nota {nota} foi registrada com sucesso para a banda {nomeBanda}!");
            Console.WriteLine("Digite uma tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine("A nota deve ser um número entre 0 e 10");
            Thread.Sleep(2000);
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
    }
    else
    {
        Console.WriteLine($"A banda {nomeBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

void ExibirMediaAvaliacaoBanda() {

    ExibirTituloDaOpcao("Avaliação das Bandas: ");
    Console.WriteLine("Gostaria de ver uma banda em especifica? Digite o nome dela ou tecle enter para ver todas: ");
    string? nomeBanda = Console.ReadLine();

    if (!string.IsNullOrWhiteSpace(nomeBanda))
    {
        if (bandasEAsuasNotas.ContainsKey(nomeBanda))
        {
            List<decimal> notas = bandasEAsuasNotas[nomeBanda];
            if (notas == null || notas.Count == 0)
            {
                Console.WriteLine($"Banda: {nomeBanda}    Média: - (sem avaliações)");
            }
            else
            {
                decimal media = notas.Average();
                Console.WriteLine($"Banda: {nomeBanda}    Média: {media:F1}");
            }
        }
        else
        {
            Console.WriteLine($"A banda {nomeBanda} não foi encontrada");
        }
    }
    else
    {
        foreach (string banda in bandasEAsuasNotas.Keys)
        {

            List<decimal> notas = bandasEAsuasNotas[banda];
            if (notas == null || notas.Count == 0)
            {
                Console.WriteLine($"Banda: {banda}    Média: - (sem avaliações)");
            }
            else
            {
                decimal media = notas.Average();
                Console.WriteLine($"Banda: {banda}    Média: {media:F1}");
            }
        }
    }

    Console.WriteLine("Digite uma tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}


ExibirOpcoesDoMenu();