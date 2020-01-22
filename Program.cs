using ProjetoXadrez.tabuleiro;
using System;
using ProjetoXadrez.Xadrez;
namespace ProjetoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                PartidadeXadrez p = new PartidadeXadrez();
                while(p.Terminada != true) 
                {
                    try
                    {
                        
                        Console.Clear();
                        Tela.imprimirPartida(p);
                        Console.WriteLine("Digite a posição da peça origem");


                        Posicao origem = Tela.LerPosicaoXadrez().ConverterPosicao();
                        p.ValidarPecas(origem);

                        bool[,] posicoesPossiveis = p.tab.peca(origem).LugaresPecas();
                        Console.Clear();
                        Console.WriteLine();
                        Tela.ImprimirTabuleiro(p.tab, posicoesPossiveis);
                        Console.WriteLine("Digite a posição da peça Destino");
                        Posicao destino = Tela.LerPosicaoXadrez().ConverterPosicao();
                        p.ValidarPecasDestino(origem, destino);
                        p.RealizarJogadas(origem, destino);
                    }
                    catch(TabuleiroExcpetion e) 
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadKey();
                    }
                    catch(Exception) 
                    {
                        Console.WriteLine("Posição não existe");
                        Console.ReadKey();
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(p);
            }
            catch(TabuleiroExcpetion e) 
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }


        }
    }
}
