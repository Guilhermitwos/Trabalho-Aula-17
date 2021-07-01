using System;
using System.Collections.Generic;
using Mono.Data.Sqlite;


class MainClass {

   
  public static void Cadastrar(){
 
    Console.WriteLine("\n\nCadastrar produto");
    Console.Write("Nome do produto: ");

    string nomedoproduto = Console.ReadLine();

    Console.Write("Preço do produto: ");
    double precodoproduto = Convert.ToDouble(Console.ReadLine());

    Produto p = new Produto(nomedoproduto, precodoproduto);

   

  }

  public static void Listar()
  {
    Console.WriteLine("\n");
    List<Produto> produtos = Produto.ConsultarProdutos();
    foreach(var produto in produtos)
    {
      produto.Mostrar();
    }
   
    Console.WriteLine("Digite qualquer coisa para retornar ao menu principal");
    
  }
    //só pra lembrar, deletar está no outro .cs

  public static void Pesquisar()
  {  
    Console.Clear();
    
    Console.WriteLine("Escreva o nome do produto de que deseja Pesquisar");
    

    string Pesquisar_ = Console.ReadLine();
 
    Console.Clear();
   
    Console.WriteLine("Mostrando todos os registros de: {0}", Pesquisar_);
  
  
    List<Produto> produtos = Produto.PesquisarProdutos(Pesquisar_);
    foreach(var produto in produtos)

    {
      produto.Mostrar();
    }
  

    Console.WriteLine("Digite qualquer coisa para retornar ao menu principal");

  }
 

 
    public static void Main(string[] args)
          {                 
                bool Menu = true;
                while (Menu)
                {
                    Menu = MenuPrincipal();
                }
          }




          private static bool MenuPrincipal()
            {

                Console.Clear();
             
                Console.WriteLine("Digite 1 para fazer o cadastro dos produtos.");
                Console.WriteLine("Digite 2 para fazer a listagem dos produtos.");
                Console.WriteLine("Digite 3 para deletar todos os produtos.");
                Console.WriteLine("Digite 4 para fazer a pesquisa de um produto.");
        Console.WriteLine("Digite 5 para fechar.");

        int opcao = Console.ReadLine();



        if (opcao == 1)
        {
            Cadastrar();
            Console.Read();
        }



        if (opcao == 2)
        { 
             Listar();
        Console.Read();
        }

        if (opcao == 3)
        {
            Produto.Deletar();
                            Console.Read();

        }
        if (opcao == 4)
        {
            Pesquisar();
                            Console.Read();   
                        


        }
        if (opcao == 5)
        {
            Console.Clear();
                           
                           Console.WriteLine("Pronto, Tudo certo!");
                          
        }          
                           
                 

                }




            }


}