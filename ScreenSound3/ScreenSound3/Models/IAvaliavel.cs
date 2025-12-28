using ScreenSound.Models;


internal interface IAvaliavel
{
    double Media { get; }
    void AdicionarNota(Avaliacao nota);
}