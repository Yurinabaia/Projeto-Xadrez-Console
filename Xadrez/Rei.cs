using System;
using System.Collections.Generic;
using System.Text;
using ProjetoXadrez.tabuleiro;

namespace ProjetoXadrez.Xadrez
{
    class Rei : Peca 
    {
        private PartidadeXadrez partida;
        public Rei(Tabuleiro tab, Cor cor, PartidadeXadrez partida) : base(cor, tab)
        {
            this.partida = partida;
        }
        private bool PoderMover(Posicao pos) 
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;

        }
        private bool TesteRoque(Posicao pos) 
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.QtdMovimentos == 0;
        }
        public override bool[,] LugaresPecas()
        {
            bool[,] mat = new bool[tab.linha, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.DefinirValores(posicao.Linhas - 1, posicao.Colunas);
            if (tab.PosicaoValida(pos) && PoderMover(pos) ) 
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //Nordeste
            pos.DefinirValores(posicao.Linhas - 1, posicao.Colunas + 1);
            if (tab.PosicaoValida(pos) && PoderMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //Direita
            pos.DefinirValores(posicao.Linhas, posicao.Colunas + 1);
            if (tab.PosicaoValida(pos) && PoderMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //Sudeste
            pos.DefinirValores(posicao.Linhas + 1, posicao.Colunas + 1);
            if (tab.PosicaoValida(pos) && PoderMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //Abaixo
            pos.DefinirValores(posicao.Linhas + 1, posicao.Colunas);
            if (tab.PosicaoValida(pos) && PoderMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //so
            pos.DefinirValores(posicao.Linhas + 1, posicao.Colunas -1);
            if (tab.PosicaoValida(pos) && PoderMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //Esquerda
            pos.DefinirValores(posicao.Linhas, posicao.Colunas -1);
            if (tab.PosicaoValida(pos) && PoderMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }            
            //Noroeste
            pos.DefinirValores(posicao.Linhas -1, posicao.Colunas -1);
            if (tab.PosicaoValida(pos) && PoderMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            //Jogadar expecial roque
            if (QtdMovimentos == 0 && !partida.xeque) 
            {
                //Todo - #Roque pequeno
                Posicao posT1 = new Posicao(posicao.Linhas, posicao.Colunas + 3);
                if(TesteRoque(posT1) ) 
                {
                    Posicao P1 = new Posicao(posicao.Linhas, posicao.Colunas + 1);
                    Posicao P2 = new Posicao(posicao.Linhas, posicao.Colunas + 2);
                    if (tab.peca(P1) == null && tab.peca(P2) == null) 
                    {
                        mat[posicao.Linhas, posicao.Colunas + 2] = true;
                    }
                }
                //Todo - #Roque grande
                Posicao posT2 = new Posicao(posicao.Linhas, posicao.Colunas + 3);
                if (TesteRoque(posT2))
                {
                    Posicao P1 = new Posicao(posicao.Linhas, posicao.Colunas - 1);
                    Posicao P2 = new Posicao(posicao.Linhas, posicao.Colunas - 2);
                    Posicao P3 = new Posicao(posicao.Linhas, posicao.Colunas - 3);
                    if (tab.peca(P1) == null && tab.peca(P2) == null && tab.peca(P3) == null)
                    {
                        mat[posicao.Linhas, posicao.Colunas - 2] = true;
                    }
                }
            }
                
                
                
                return mat; 
    
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
