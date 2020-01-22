using System;
using System.Collections.Generic;
using System.Text;
using ProjetoXadrez.tabuleiro;

namespace ProjetoXadrez.Xadrez
{
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "B";
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
