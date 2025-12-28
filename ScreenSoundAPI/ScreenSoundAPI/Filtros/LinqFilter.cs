using ScreenSoundAPI.Models;
using System;
namespace ScreenSoundAPI.Filtros
{
    internal class LinqFilter
    {
        public static void FiltrarGeneros(List<Musica> musicas)
        {
            var todosGeneros = musicas.Select(generos => generos.Genero).Distinct().ToList();
            foreach (var genero in todosGeneros)
            {
                Console.WriteLine(genero);
            }
        }

        public static void FiltrarArtistasPorGenero(List<Musica> musicas, string genero)
        {
            var artistas = musicas.Where(musica => musica.Genero.Contains(genero)).Select(
                musica => musica.Artista).ToList();
            foreach (var artista in artistas)
            {
                Console.WriteLine($"- {artista}");
            }
        }

        public static void FiltrarMusicasPorArtistas(List<Musica> musicas, string artista)
        {
            var musicasArtista = musicas.Where(musica => musica.Artista!.Equals(artista)).Select(
                musica => musica.Nome).Distinct().ToList();
            foreach (var song in musicasArtista)
            {
                Console.WriteLine($"- {song}");
            }
        }
    }
}
