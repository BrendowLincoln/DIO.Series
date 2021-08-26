using System;
using DIO.Series.Classes;
using DIO.Series.Enums;

namespace DIO.Series
{
    class Program
    {

        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {

                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluiSerie();
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
            }      
      
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Vizualizar série");
            Console.WriteLine();
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            var serie = repository.RetornaPorId(idSerie);

            Console.WriteLine(serie);
        }

        private static void ExcluiSerie()
        {
            Console.WriteLine("Excluir série");
            Console.WriteLine();
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            repository.Exclui(idSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Inserir nova série");
            Console.WriteLine();
            Console.Write("Digite o id da série: ");
            int idSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))) 
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(Id: idSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repository.Atualiza(idSerie, atualizaSerie);




        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repository.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhum série cadastrada.");
                return;
            }

            foreach(var serie in lista) 
            {
                Console.WriteLine($"#ID {serie.Id}: {serie.Titulo}");
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero))) 
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(Id: repository.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repository.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario() 
        {

            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();


            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
