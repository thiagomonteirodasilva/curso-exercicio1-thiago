using System;
using System.Globalization;
using proposto1.dominio;

namespace proposto1 {
    class Tela {
        //o "front end" do usuario
        public static void mostrarMenu() {
            Console.WriteLine("1 - Listar artistas ordenadamente");
            Console.WriteLine("2 - Cadastrar artista");
            Console.WriteLine("3 - Cadastrar filme");
            Console.WriteLine("4 - Mostrar dados de um filme");
            Console.WriteLine("5 - Sair");
            Console.Write("Digite uma opção: ");
        }
        
        //listar produtos ordenadamente
        public static void mostrarArtistas() {
            Console.WriteLine("Listagem de artistas");
            for (int i = 0; i < Program.artistas.Count; i++) {
                Console.WriteLine(Program.artistas[i]);
            }
        }

        public static void cadastrarArtista() {
            Console.Write("Digite os dados do artista: ");
            Console.WriteLine();
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Nome do artista: ");
            string nome = (Console.ReadLine());
            Console.Write("Valor do cachê: ");
            double cache = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Artista A = new Artista(codigo, nome, cache);
            Program.artistas.Add(A);
            Program.artistas.Sort();
        }

        public static void cadastrarFilme() {
            Console.Write("Digite os dados do filme: ");
            Console.WriteLine();
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());
            Console.Write("Nome do filme: ");
            string titulo = Console.ReadLine();
            Console.Write("Ano: ");
            int ano = int.Parse(Console.ReadLine());
            Filme F = new Filme(codigo, titulo, ano);
            Console.Write("Quantos artistas participarão do filme? ");
            int N = int.Parse(Console.ReadLine());
                for(int i=1; i<=N; i++) {
                Console.Write("Digite os dados do " + i + "º artista: ");
                Console.Write("Código do artista: ");
                int codArtista = int.Parse(Console.ReadLine());
                int pos = Program.artistas.FindIndex(x => x.codigo == codArtista);
                if(pos == -1) {
                    throw new ModelException("Código de artista não encontrado: " + codArtista);
                }
                Console.Write("Desconto: ");
                double desconto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Participacao P = new Participacao(desconto, F, Program.artistas[pos]);
                F.participacoes.Add(P);
         
            }
            Program.filmes.Add(F);
        }

        public static void mostrarFilme() {
            Console.Write("Digite o código do filme:");
            int codFilme = int.Parse(Console.ReadLine());
            int pos = Program.filmes.FindIndex(x => x.codigo == codFilme);
            if(pos == -1) {
                throw new ModelException("Código de filme não encontrado: " + codFilme);
            }
            Console.WriteLine(Program.filmes[pos]);
            Console.WriteLine();
        }

    }
}
