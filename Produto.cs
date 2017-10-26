using System.IO;
using System;

namespace sistema_vendas
{
    public class Produto
    {
        private int codigo {get;set;}
        private string nome {get;set;}

        public void CadastrarProdutos()
        {
            string[] produtos, temp;
            string op1;

            //Verifica se o arquivo existe
            if(!File.Exists("Produtos.csv"))
            {
                File.Create("Produtos.csv").Close();
                StreamWriter sw = new StreamWriter("Produtos.csv",true);
                sw.Write("0;DescProdutos");
                sw.Close();
            }
            //Inicio do Cadastro
            do
            {
                codigo = 0;
                produtos = File.ReadAllLines("Produtos.csv");
                //Leitura do código da última linha
                temp = produtos[produtos.Length-1].Split(';');
                codigo = int.Parse(temp[0])+1;
                //Inicio da escrita em arquivo
                StreamWriter sw = new StreamWriter("Produtos.csv",true);
                sw.WriteLine();
                Console.WriteLine("\n### Cadastro de Produtos ###\n\nCód.Produto = "+codigo);
                Console.Write("Digite o nome do Produto: ");
                nome = Console.ReadLine();
                sw.Write(codigo+";"+nome);
                sw.Close();
                do
                {
                    Console.Write("\nDeseja realizar um novo cadastro? (S ou N)");
                    op1 = Console.ReadLine();
                } while (op1!="S" && op1!="N" && op1!="s" && op1!="n");
            } while(op1=="S" || op1=="s");
            
        }
    }
}