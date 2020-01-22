using System;
using System.Collections.Generic;
using System.Text;
using ProjetoXadrez.tabuleiro;
using ProjetoXadrez.Xadrez;

namespace ProjetoXadrez
{
    class Tela
    {
        public static void imprimirPartida(PartidadeXadrez partida)
        {
            ImprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            if (!partida.Terminada)
            {
                Console.WriteLine("Aguardado jogador " + partida.JogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else 
            {
                Console.WriteLine("Xequemate!");
                Console.WriteLine("Vencedor " + partida.JogadorAtual);
            }
        }

        public static void imprimirPecasCapturadas(PartidadeXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void ImprimirTabuleiro(Tabuleiro tab) 
        {
            for (int i = 0; i < tab.linha; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    ImprimirPecas(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkRed;
            for (int i = 0; i < tab.linha; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if(posicoesPossiveis[i,j]) 
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else 
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPecas(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
                Console.BackgroundColor = fundoOriginal;
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void ImprimirPecas (Peca peca) 
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
        public static PosicaoXadrez LerPosicaoXadrez() 
        {
            string s = Console.ReadLine().Trim().ToLower();
            char coluna = s[0];
            int linha = int.Parse(s[1] + " ");
            return new PosicaoXadrez(coluna, linha);
        }
    }
}
