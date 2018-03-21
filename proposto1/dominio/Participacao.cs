using System;
using System.Globalization;

namespace proposto1.dominio {
    class Participacao {
        public double descontoArtista;

        public double desconto { get; set; }
        public Artista artista { get; set; }
        public Filme filme { get; set; }

        public Participacao(double desconto, Filme filme, Artista artista) {
            this.desconto = desconto;
            this.filme = filme;
            this.artista = artista;
        }

        public double Custo() {
            descontoArtista = artista.cache - desconto;
            return descontoArtista;
        }

        public override string ToString() {
            return artista.nome
                + ", Cache: "
                + artista.cache.ToString("F2", CultureInfo.InvariantCulture)
                + ", Desconto: "
                + desconto.ToString("F2", CultureInfo.InvariantCulture)
                + ", Custo: "
                + Custo().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
