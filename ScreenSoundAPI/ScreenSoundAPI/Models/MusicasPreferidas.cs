using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ScreenSoundAPI.Models
{
    internal class MusicasPreferidas
    {
        public string Nome { get; set; }
        public List<Musica> ListaDeMusicas { get; set; }

        public MusicasPreferidas(string nome)
        {
            Nome = nome;
            ListaDeMusicas = new List<Musica>();
        }

        public void AdicionarMusica(Musica musica)
        {
            ListaDeMusicas.Add(musica);
        }   

        public void ExibirMusicas()
        {
            Console.WriteLine($"Músicas preferidas de {Nome}:");
            foreach (var musica in ListaDeMusicas)
            {
                Console.WriteLine($"- {musica.Nome} por {musica.Artista}");
            }
        }

        public void GerarArquivoJson()
        {
            string json = JsonSerializer.Serialize(new
            {
                Nome = this.Nome,
                Musicas = this.ListaDeMusicas
            });
            string nomeArquivo = $"{Nome}_musicas_preferidas.json";

            File.WriteAllText(nomeArquivo, json);
            Console.WriteLine($"Arquivo JSON gerado: {nomeArquivo} em {Path.GetFullPath(nomeArquivo)}");

        }

    }
}
