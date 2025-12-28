using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuExibirDetalhes : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);
        ExibirTituloDaOpcao("Exibir detalhes da banda");
        Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
        string nomeDaBanda = Console.ReadLine()!;
        Console.WriteLine("Gostaria de ver uma banda em especifica? Digite o nome dela ou tecle enter para ver todas: ");
        string? nomeBanda = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(nomeBanda))
        {
            if (bandasRegistradas.ContainsKey(nomeBanda))
            {
                Banda banda = bandasRegistradas[nomeBanda];
                var avaliacoes = banda.Avaliacoes;
                if (avaliacoes == null || avaliacoes.Count == 0)
                {
                    Console.WriteLine($"Banda: {nomeBanda}    Média: - (sem avaliações)");
                }
                else
                {
                    Console.WriteLine($"Banda: {nomeBanda}    Média: {banda.Media:F1}");
                }
            }
            else
            {
                Console.WriteLine($"A banda {nomeBanda} não foi encontrada");
            }
        }
        else
        {
            foreach (var kv in bandasRegistradas)
            {
                string nome = kv.Key;
                Banda banda = kv.Value;
                var avaliacoes = banda.Avaliacoes;
                if (avaliacoes == null || avaliacoes.Count == 0)
                {
                    Console.WriteLine($"Banda: {nome}    Média: - (sem avaliações)");
                }
                else
                {
                    Console.WriteLine($"Banda: {nome}    Média: {banda.Media:F1}");
                }
            }
        }

        Console.WriteLine("Digite uma tecla para votar ao menu principal");
            Console.ReadKey();
            Console.Clear();
       
    }
}