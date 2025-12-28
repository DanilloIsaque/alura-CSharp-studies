using ScreenSoundAPI.Filtros;
using ScreenSoundAPI.Models;
using System.Linq;
using System.Text.Json;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://" +
            "guilhermeonrails.github.io/api-csharp-songs/songs.json");
        //Console.WriteLine(resposta);
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta);
        musicas[0].ExibirDetalhesMusica();

        LinqFilter.FiltrarGeneros(musicas);
        LinqFilter.FiltrarMusicasPorArtistas(musicas, "Travis Scott");
        LinqOrder.exibirArtistasOrdenados(musicas);
        LinqFilter.FiltrarArtistasPorGenero(musicas, "rap");

        var musicasPreferidas = new MusicasPreferidas("Danillo");
        musicasPreferidas.AdicionarMusica(musicas[10]);
        musicasPreferidas.AdicionarMusica(musicas[1299]);
        musicasPreferidas.AdicionarMusica(musicas[2]);
        musicasPreferidas.AdicionarMusica(musicas[4]);
        musicasPreferidas.AdicionarMusica(musicas[110]);
        musicasPreferidas.ExibirMusicas();
        musicasPreferidas.GerarArquivoJson();

        //// Ordenar por nome ascendente
        //var ordenadasPorNome = musicas.OrderBy(m => m.Nome).ToList();
        //Console.WriteLine("\nOrdenadas por nome (asc):");
        //foreach (var m in ordenadasPorNome.Take(10))
        //{
        //    Console.WriteLine($"{m.Nome} - {m.Artista}");
        //}

        //// Filtrar por gênero contendo "Rock"
        //var rock = musicas.Where(m => (m.Genero ?? "").ToLower().Contains("rock")).ToList();
        //Console.WriteLine($"\nMúsicas com gênero 'rock' ({rock.Count}):");
        //foreach (var m in rock.Take(10))
        //{
        //    Console.WriteLine($"{m.Nome} - {m.Artista} - {m.Genero}");
        //}

        //// Filtrar por artista (contains)
        //var artistaBusca = "Queen";
        //var porArtista = musicas.Where(m => (m.Artista ?? "").IndexOf(artistaBusca, StringComparison.OrdinalIgnoreCase) >= 0);
        //Console.WriteLine($"\nMúsicas que contém '{artistaBusca}' no artista:");
        //foreach (var m in porArtista)
        //{
        //    Console.WriteLine($"{m.Nome} - {m.Artista}");
        //}
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
