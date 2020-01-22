using System;
using System.Collections.Generic;
using System.Text;
using ProjetoXadrez.tabuleiro;

namespace ProjetoXadrez.Xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(cor, tab)
        {

        }

        public override string ToString()
        {
            return "T";
        }
        private bool PoderMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;

        }

        public override bool[,] LugaresPecas()
        {
            bool[,] mat = new bool[tab.linha, tab.colunas];
            Posicao pos = new Posicao(0, 0);
            // acima
            pos.DefinirValores(posicao.Linhas - 1, posicao.Colunas);
            while (tab.PosicaoValida(pos) && PoderMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.Linhas = pos.Linhas - 1;
            }

            // abaixo
            pos.DefinirValores(posicao.Linhas + 1, posicao.Colunas);
            while (tab.PosicaoValida(pos) && PoderMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.Linhas = pos.Linhas + 1;
            }

            // direita
            pos.DefinirValores(posicao.Linhas, posicao.Colunas + 1);
            while (tab.PosicaoValida(pos) && PoderMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.Colunas = pos.Colunas + 1;
            }

            // esquerda
            pos.DefinirValores(posicao.Linhas, posicao.Colunas - 1);
            while (tab.PosicaoValida(pos) && PoderMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
                if (tab.peca(pos) != null && tab.peca(pos).cor != cor)
                {
                    break;
                }
                pos.Colunas = pos.Colunas - 1;
            }

            return mat;
        }
    }
}
