using System;
using System.Collections.Generic;

namespace BibliotecaNewbies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao sistema da biblioteca Newbies!");
            List<Livro> livros = PreencherLivros();
            bool sair = false;

            while(!sair)
            {
               int resposta = Menu();
               if(resposta == 0){
                    Console.Clear();
                    Console.WriteLine("Opção inválida.");
                    continue;
               } 
               else
               {
                    Console.Clear();
                    switch (resposta)
                    {
                        case 1:
                            livros.Add(AddLivro(livros.Count));
                            break;
                        case 2:
                            livros = AlterarQuantidadeExemplares(livros);
                            break;
                        case 3:
                            Pesquisar(livros);
                            break;
                        case 4:
                            livros = Editar(livros);
                            break;
                        case 5:
                            livros = Remover(livros);
                            break;
                        case 6:
                            ListarLivros(livros);
                            break;
                        case 7:
                            sair = true;
                            break;

                    }
                }
            }
        }

        static void ListarLivros(List<Livro> livros)
        {
            livros.ForEach(delegate (Livro livro)
            {
                Console.WriteLine(livro);
            });
        }

        static List<Livro> PreencherLivros()
        {
            List<Livro> list = new List<Livro>();

            list.Add(new Livro("As Cronicas de Nárnia", "CS Lewis", 5, list.Count));
            list.Add(new Livro("Percy Jackson - O Mar de Monstros", "Rick Riordan", 5, list.Count));
            list.Add(new Livro("Percy Jackson - O Ladrão de raios", "Rik Riordan", 5, list.Count));
            list.Add(new Livro("12 Regras para a vida", "Jordan Peterson", 5, list.Count));
            list.Add(new Livro("Harry Potter e a Pedra Filosofal", "J. K. Rowling", 5, list.Count));
            list.Add(new Livro("Este Livro não vai te deixar rico", "Startup da real", 5, list.Count));

            return list;
        }

        static void Pesquisar(List<Livro> livros)
        {
            Console.WriteLine("1 - Pesquisar por título");
            Console.WriteLine("2 - Pesquisar por autor");

            string resposta = Console.ReadLine();

            if(resposta.Equals("1"))
            {
                Console.WriteLine("Digite o titulo do livro que está procurando");
                string pesquisa = Console.ReadLine();
                ListarLivros(livros.FindAll(livro => livro.getTitulo().Equals(pesquisa)));
            }

            if (resposta.Equals("2"))
            {
                Console.WriteLine("Digite o nome do autor do livro que está procurando");
                string pesquisa = Console.ReadLine();
                ListarLivros(livros.FindAll(livro => livro.getAutor().Equals(pesquisa)));
            }
        }

        static int findBookById(List<Livro> livros)
        {
            //Pergunto qual livro quero alterar e listo os livros
            Console.WriteLine("Selecione o Livro que deseja alterar");
            ListarLivros(livros);

            //Pego a resposta e busco o livro desejado dentro da minha lista
            string livroSelecionado = Console.ReadLine();
            int indexLivro = livros.FindIndex(livro => livro.getId().Equals(Int32.Parse(livroSelecionado)));
            return indexLivro;
        }

        static List<Livro> AlterarQuantidadeExemplares(List<Livro> livros)
        {

            int indexLivro = findBookById(livros);

            if (indexLivro > -1)
            {
                //Se o livro existe, pego o numero de exemplares
                Console.WriteLine("Quantos exemplares deste livro estão na biblioteca?");
                string exemplares = Console.ReadLine();

                //Transformo a minha lista em um array para poder alterar com o index
                Livro[] array = livros.ToArray();
                array[indexLivro]
                    .setNumeroExemplaresDisponiveis(Int32.Parse(exemplares));

                //Retorno uma nova lista com o valor alterado
                return new List<Livro>(array);
            } else
            {
                //Retorno a lista recebida por parametro
                Console.WriteLine("Livro não encontrado");
                return livros;
            }
        }

        static List<Livro> Editar(List<Livro> livros)
        {
            int indexLivro = findBookById(livros);

            if(indexLivro > -1)
            {
                Console.WriteLine("Digite o novo valor ou aperte apenas enter para usar o atual");

                Livro[] array = livros.ToArray();
                Console.WriteLine("Digite o título (" + array[indexLivro].getTitulo() + "): ");
                string titulo = Console.ReadLine();

                Console.WriteLine("Digite o autor (" + array[indexLivro].getAutor() + "): ");
                string autor = Console.ReadLine();

                Console.WriteLine("Digite o n de exemplares (" + array[indexLivro].getNumeroExemplaresDisponiveis() + "): ");
                string exemplares = Console.ReadLine();

                if (titulo.Length > 0) array[indexLivro].setTitulo(titulo);
                if (autor.Length > 0) array[indexLivro].setAutor(autor);
                if (exemplares.Length > 0) array[indexLivro].setNumeroExemplaresDisponiveis(Int32.Parse(exemplares));


                //Retorno uma nova lista com o valor alterado
                return new List<Livro>(array);
            } else
            {
                //Retorno a lista recebida por parametro
                Console.WriteLine("Livro não encontrado");
                return livros;
            }
        }

        static Livro AddLivro(int tamanhoLista)
        {
            Console.WriteLine("Digite o Título do livro");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite o nome do Autor do livro");
            string autor = Console.ReadLine();
            Console.WriteLine("Digite a quantidade de exemplares deste livro");
            string exemplares = Console.ReadLine();

            Livro livro = new Livro(titulo, autor, Int32.Parse(exemplares), ++tamanhoLista);
            return livro;
        }

        static int Menu()
        {
            Console.WriteLine("Selecione um das opções: ");
            Console.WriteLine("1 - Adicionar Livro");
            Console.WriteLine("2 - Modificar estoque de exemplares");
            Console.WriteLine("3 - Pesquisar Livro");
            Console.WriteLine("4 - Editar Livro");
            Console.WriteLine("5 - Remover Livro");
            Console.WriteLine("6 - Listar Livros");
            Console.WriteLine("7 - Sair");

            string resposta = Console.ReadLine();
            int intResposta = Int32.Parse(resposta);

            if(intResposta > 7 || intResposta < 1)
            {
                return 0;
            }

            return intResposta;
        }

        static List<Livro> Remover(List<Livro> livros)
        {

            //Pergunto qual livro quero alterar e listo os livros
            Console.WriteLine("Selecione o Livro que deseja remover");
            ListarLivros(livros);

            //Pego a resposta e busco o livro desejado dentro da minha lista
            string idSelecionado = Console.ReadLine();

            Livro livro = livros.Find(livro => livro.getId().Equals(Int32.Parse(idSelecionado)));
            if(livro != null)
            {
                livros.Remove(livro);
            }

            return livros;
        }
    }
}


// Carro
// - Modelo
// - Marca
// Kms Rodados
// Cor
// Manutenções
// Status (Em Estoque, Vendido)
// Vendido para: Cliente

//Cliente
//Nome
//CPF

//Manutenções
// Oficina
// Quando
//Quais peças foram trocadas (lista de string com o nome das peças)

//Dar entrada em um carro
//Pesquisar carro por Modelo, Marca, Cor
//Pesquisar por km rodados (por exemplo, todos os carros que rodaram menos que 50.000km)
//Filtrar o carro pelo status (Em estoque/vendido)
//Adicionar uma manutenção para um dos meus carros
//Vender um carro

