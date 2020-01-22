using System;
using System.Collections.Generic;
using System.Text;
using ProjetoXadrez.tabuleiro;

namespace ProjetoXadrez.Xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tab, Cor cor) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "D";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] LugaresPecas()
        {
            bool[,] mat = new bool[tab.linha, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            // esquerda
            pos.DefinirValores(posicao.Linhas, posicao.Colunas - 1);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linhas, pos.Colunas - 1);
            }

            // direita
            pos.DefinirValores(posicao.Linhas, posicao.Colunas + 1);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linhas, pos.Colunas + 1);
            }

            // acima
            pos.DefinirValores(posicao.Linhas - 1, posicao.Colunas);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linhas - 1, pos.Colunas);
            }

            // abaixo
            pos.DefinirValores(posicao.Linhas + 1, posicao.Colunas);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linhas + 1, pos.Colunas);
            }

            // NO
            pos.DefinirValores(posicao.Linhas - 1, posicao.Colunas - 1);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linhas - 1, pos.Colunas - 1);
            }

            // NE
            pos.DefinirValores(posicao.Linhas - 1, posicao.Colunas + 1);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linhas - 1, pos.Colunas + 1);
            }

            // SE
            pos.DefinirValores(posicao.Linhas + 1, posicao.Colunas + 1);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linhas + 1, pos.Colunas + 1);
            }

            // SO
            pos.DefinirValores(posicao.Linhas + 1, posicao.Colunas - 1);
            while (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linhas + 1, pos.Colunas - 1);
            }

            return mat;
        }
    }
}

