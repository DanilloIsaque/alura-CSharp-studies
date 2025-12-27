Banda slipknot = new Banda("Slipknot");

Album albumDoSlipknot = new Album("We are not your kind");

Musica musica1 = new Musica(slipknot, "Unsainted")
{
    Duracao = 213,
    Disponivel = true,
};

Musica musica2 = new Musica(slipknot, "Solway Firth")
{
    Duracao = 354,
    Disponivel = false,
};

albumDoSlipknot.AdicionarMusica(musica1);
albumDoSlipknot.AdicionarMusica(musica2);
slipknot.AdicionarAlbum(albumDoSlipknot);

musica1.ExibirFichaTecnica();
musica2.ExibirFichaTecnica();
albumDoSlipknot.ExibirMusicasDoAlbum();
slipknot.ExibirDiscografia();