using System;
using System.Globalization;

namespace proposto1.dominio {
        class Artista : IComparable {
        public int codigo { get; set;}
        public string nome { get; set; }
        public double cache { get; set; }

        public Artista (int codigo, string nome, double cache) {
            this.codigo = codigo;
            this.nome = nome;
            this.cache = cache;
        }

        public override string ToString() {
            return codigo
                + ", "
                + nome
                + ", "
                + cache.ToString("F2", CultureInfo.InvariantCulture);
        }

        public int CompareTo(object obj) {
            Artista outro = (Artista)obj;
            int resultado = nome.CompareTo(outro.nome);
            if (resultado != 0) {
                return resultado;
            }
            else {
                return -cache.CompareTo(outro.cache); //o "-" para que seja em ordem decrescente
            }
        }
    }
}