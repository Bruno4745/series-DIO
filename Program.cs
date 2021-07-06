using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos servicos!");
            Console.ReadLine();
        }
        
        private static void ListarSerie()
        {
            Console.WriteLine("======= Listar Series =======");

            var lista = repositorio.Lista();

            if(lista.Count == 0 )
            {
                Console.WriteLine("Nenhuma serie cadastrda");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0} - {1} {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? " - *EXCLUIDO*" : "");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("======= Inserir Serie =======");
            
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);
            
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("======= Atualizar Serie =======");

            Console.Write("Digite o ID da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("#{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descricao da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);
                            
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            
            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("======= DIO Series =======");
            Console.WriteLine("Informe a opcao desejada:");
            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir serie");
            Console.WriteLine("5 - Visualizar serie");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario.ToUpper();
        }
    }
}
