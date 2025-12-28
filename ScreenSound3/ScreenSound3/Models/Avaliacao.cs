namespace ScreenSound.Models;

internal class Avaliacao // interno tem a ver com visibilidade para ela nao ser vista em outros projeto
{
    public Avaliacao(int nota)
    {
        Nota = nota;
    }

    public int Nota { get; }

    public static Avaliacao Parse(string texto) // static pq n usa nada de fora do metodo
    {
        int nota = int.Parse(texto);
        return new Avaliacao(nota);
    }
}