using System;
using System.Collections.Generic;
using System.Text;
using ProjetoXadrez.tabuleiro;

namespace ProjetoXadrez.Xadrez
{
    class Peao : Peca
    {
        private PartidadeXadrez partida;

        public Peao(Tabuleiro tab, Cor cor, PartidadeXadrez partida) : base(cor, tab)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] LugaresPecas()
        {
            bool[,] mat = new bool[tab.linha, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                pos.DefinirValores(posicao.Linhas - 1, posicao.Colunas);
                if (tab.PosicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
                pos.DefinirValores(posicao.Linhas - 2, posicao.Colunas);
                Posicao p2 = new Posicao(posicao.Linhas - 1, posicao.Colunas);
                if (tab.PosicaoValida(p2) && livre(p2) && tab.PosicaoValida(pos) && livre(pos) && QtdMovimentos == 0)
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
                pos.DefinirValores(posicao.Linhas - 1, posicao.Colunas - 1);
                if (tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
                pos.DefinirValores(posicao.Linhas - 1, posicao.Colunas + 1);
                if (tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }

                // #jogadaespecial en passant
                if (posicao.Linhas == 3)
                {
                    Posicao esquerda = new Posicao(posicao.Linhas, posicao.Colunas - 1);
                    if (tab.PosicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.Linhas - 1, esquerda.Colunas] = true;
                    }
                    Posicao direita = new Posicao(posicao.Linhas, posicao.Colunas + 1);
                    if (tab.PosicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.Linhas - 1, direita.Colunas] = true;
                    }
                }
            }
            else
            {
                pos.DefinirValores(posicao.Linhas + 1, posicao.Colunas);
                if (tab.PosicaoValida(pos) && livre(pos))
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
                pos.DefinirValores(posicao.Linhas + 2, posicao.Colunas);
                Posicao p2 = new Posicao(posicao.Linhas + 1, posicao.Colunas);
                if (tab.PosicaoValida(p2) && livre(p2) && tab.PosicaoValida(pos) && livre(pos) && QtdMovimentos == 0)
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
                pos.DefinirValores(posicao.Linhas + 1, posicao.Colunas - 1);
                if (tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }
                pos.DefinirValores(posicao.Linhas + 1, posicao.Colunas + 1);
                if (tab.PosicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.Linhas, pos.Colunas] = true;
                }

                // #jogadaespecial en passant
                if (posicao.Linhas == 4)
                {
                    Posicao esquerda = new Posicao(posicao.Linhas, posicao.Colunas - 1);
                    if (tab.PosicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.Linhas + 1, esquerda.Colunas] = true;
                    }
                    Posicao direita = new Posicao(posicao.Linhas, posicao.Colunas + 1);
                    if (tab.PosicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.Linhas + 1, direita.Colunas] = true;
                    }
                }
            }

            return mat;
        }
    }
}
