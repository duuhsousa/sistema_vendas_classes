using System;
using System.IO;

namespace sistema_vendas
{
    public class Venda
    {
        Cliente cliente = new Cliente();


        public void ExtratoClientes()
        {
            int valid=0;
            string docCliente;
            string[] clientes,produtos,vendas,findcliente=null,findproduto=null,findvenda=null;
            clientes = File.ReadAllLines("cliente.csv");
            produtos = File.ReadAllLines("Produtos.csv");
            vendas = File.ReadAllLines("Vendas.csv");
            do{
                do{
                    Console.Write("Digite o documento do Cliente: ");
                    docCliente = Console.ReadLine();     
                }while(docCliente.Length!=11 && docCliente.Length!=14);
                if(docCliente.Length==11){
                    Console.WriteLine("Validando CPF...");
                    valid = cliente.validacao.ValidarCPF(docCliente);
                }else{
                    Console.WriteLine("Validando CNPJ...");
                    valid = cliente.validacao.ValidarCNPJ(docCliente);
                } 
                if(valid==0)
                    Console.WriteLine("Documento Inválido!");        
            }while(valid==0);
            foreach(string cliente in clientes){
                    if(cliente.Contains(docCliente)){
                        findcliente = cliente.Split(';');
                }
            }
            Console.WriteLine("\nCliente: "+findcliente[1]+"\neMail: "+findcliente[2]+"\nCPF: "+findcliente[0]+"\n");
            foreach(string venda in vendas){
                if(venda.Contains(docCliente)){
                    findvenda = venda.Split(';');
                    foreach(string cliente in clientes){
                        if(cliente.Contains(findvenda[0])){
                            findcliente = cliente.Split(';');
                        }
                    }
                    foreach(string produto in produtos){
                        if(produto.Contains(findvenda[1])){
                            findproduto = produto.Split(';');
                        }
                    }
                    Console.WriteLine(findvenda[2]+"            "+findproduto[1]);
                }
            }
        }

        public void RealizarVendas()
        {
            int valid=0,valid2,valid3=0;
            string docCliente,codProduto,op1;
            string[] clientes,produtos,findcliente=null,findproduto=null;
            clientes = File.ReadAllLines("cliente.csv");
            produtos = File.ReadAllLines("Produtos.csv");
            if(!File.Exists("Vendas.csv"))
            {
                File.Create("Vendas.csv").Close();
            }
            do{
                StreamWriter sw = new StreamWriter("Vendas.csv",true);
                do{
                    do{
                        Console.Write("Digite o documento do Cliente: ");
                        docCliente = Console.ReadLine();     
                    }while(docCliente.Length!=11 && docCliente.Length!=14);
                    if(docCliente.Length==11){
                        valid = cliente.validacao.ValidarCPF(docCliente);
                    }else
                        valid = cliente.validacao.ValidarCNPJ(docCliente);     
                }while(valid == 0);
                valid2=0;
                foreach(string cliente in clientes){
                    if(cliente.Contains(docCliente)){
                        findcliente = cliente.Split(';');
                        valid2 = 1;
                    }
                }
                
                if(valid2==1){
                    Console.WriteLine("\nCliente Encontrado");
                    Console.WriteLine("\nNome: "+findcliente[1]+"\nCPF: "+findcliente[0]+"\neMail: "+findcliente[2]+"\nDesde: "+findcliente[3]);
                    Console.WriteLine("\nLista de Produtos");
                    int cont=0;
                    foreach(string produto in produtos){
                        findproduto = produto.Split(';');
                        if(cont!=0){
                            Console.WriteLine(findproduto[0]+" - "+findproduto[1]);
                        }
                        cont=1;
                    }
                    do{
                        Console.Write("Digite o Código do Produto: ");
                        codProduto = Console.ReadLine();
                        foreach(string produto in produtos){
                            findproduto = produto.Split(';');
                            if(findproduto[0].Equals(codProduto)){
                                valid3 = 1;
                            }
                        }
                    }while(valid3!=1);
                    sw.WriteLine(docCliente+";"+codProduto+";"+System.DateTime.Now.ToString());
                    sw.Close();
                    Console.WriteLine("Venda Realizada!");
                }else{
                    Console.WriteLine("\nCliente não Encontrado");

                }
                do
                {
                    Console.Write("\nDeseja realizar uma outra venda? (S ou N)");
                    op1 = Console.ReadLine();
                } while (op1!="S" && op1!="N" && op1!="s" && op1!="n");
            } while(op1=="S" || op1=="s");
        }
    }
}