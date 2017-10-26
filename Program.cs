using System;
using System.IO;

namespace sistema_vendas
{
    class Program
    {
        static Cliente cliente = new Cliente();
        static Venda venda = new Venda();
        static Produto produto = new Produto();

        static void Main(string[] args)
        {
            string op2;
            do
            {
                Console.WriteLine("\nEscolha uma das opções abaixo\n1 - Cadastrar Clientes\n2 - Cadastrar Produtos\n3 - Realizar Vendas\n4 - Extrato de Clientes\n\n0 - Sair");
                do
                {
                    op2 = Console.ReadLine();
                } while (op2 != "1" && op2 != "2" && op2 != "3" && op2 != "4" && op2 != "0");

                switch (op2)
                {
                    case "0": Environment.Exit(0); break;
                    case "1": cliente.CadastrarClientes(); break;
                    case "2": produto.CadastrarProdutos(); break;
                    case "3": venda.RealizarVendas(); break;
                    case "4": venda.ExtratoClientes(); break;
                }
            } while (op2 != "0");

        }
    }
}
