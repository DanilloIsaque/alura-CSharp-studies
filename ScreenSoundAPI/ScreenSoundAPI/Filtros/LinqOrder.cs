using ScreenSoundAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenSoundAPI.Filtros
{
    internal class LinqOrder
    {
        public static void exibirArtistasOrdenados(List<Musica> musicas)
        {
            var artistasOrdenados = musicas.OrderBy(musica => musica.Artista).Select(musica => musica.Artista).
                Distinct().ToList();
            foreach(var artista in artistasOrdenados)
            {
                Console.WriteLine($"- {artista}");
            }
        }
    }
}
