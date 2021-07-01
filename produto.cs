using System;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;

public class produto 
{
  private int _identificacao;

    private double _preçodoproduto;

    private string _nomedoproduto;
  

      public int identificacao
      {
        get {
          return _identificacao;
        }
      }

    public double preçodoproduto
    {
        get
        {
            return _preçodoproduto;
        }
    }

        public string nomedoproduto
      {
        get {
          return _nomedoproduto;
        }
      }

  

              public produto(string nomedoproduto, double preçodoproduto)
              {
                this._nomedoproduto = nomedoproduto;
                this._preçodoproduto = preçodoproduto;
              }

  public void Imprimir()
  {
    
            Console.WriteLine("ID:\t\t\t{0}", this._identificacao);

            Console.WriteLine("produto:\t{0}", this._nomedoproduto);

            Console.WriteLine("Preço:\t\tR$ {0:0.00}\n", this._preçodoproduto);

  

  }

  







          public static List<produto> Procurarprodutos(string produto_)
          {
   
            List<produto> produtos = new List<produto>();

            using (var connection = new SqliteConnection("Data Source=banco.db"))
            {
              connection.Open();

              var command = connection.CreateCommand();
              command.CommandText =
              @"
                SELECT identificacao, nomedoproduto, preçodoproduto
                FROM produto
                WHERE nomedoproduto LIKE '%' || @item ||'%';
              ";     

              command.Parameters.AddWithValue("@item", produto_);
  
              using (var reader = command.ExecuteReader())
              {
                while (reader.Read())
                {
                  var identificacao = reader.GetInt32(0);

                  var nomedoproduto = reader.GetString(1);

                  var preçodoproduto = reader.GetDouble(2);

                  produto p = new produto(nomedoproduto, preçodoproduto);
                  p._identificacao = identificacao;

                  produtos.Add(p);
                }
              }

            }

          return produtos;
          }


          public static List<produto> Consultarprodutos()
            {
              List<produto> produtos = new List<produto>();

              using (var connection = new SqliteConnection("Data Source=banco.db"))
              {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                  SELECT identificacao, nomedoproduto, preçodoproduto
                  FROM produto;
                ";

                using (var reader = command.ExecuteReader())
                {
                  while (reader.Read())
                  {
                    var identificacao = reader.GetInt32(0);
                    var nomedoproduto = reader.GetString(1);
                    var preçodoproduto = reader.GetDouble(2);

                    produto p = new produto(nomedoproduto, preçodoproduto);
                    p._identificacao = identificacao;

                    produtos.Add(p);
                  }
                }

              }

              return produtos;
            }






          public static void Deletar()
         {
            using( var connection = new SqliteConnection("Data Source=banco.db"))
             {
                  connection.Open();
                  var command = connection.CreateCommand();
                  command.CommandText =
                  @"
                   DELETE FROM produto;
                  ";

                  command.ExecuteNonQuery();
                       Console.WriteLine(" Digite qualquer coisa para retornar ao menu principal")
             }
         }






 

}