using System;
using System.Collections.Generic;
using System.Text;
using ProjetoXadrez.tabuleiro;

namespace ProjetoXadrez.Xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "C";
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

            pos.DefinirValores(posicao.Linhas - 1, posicao.Colunas - 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            pos.DefinirValores(posicao.Linhas - 2, posicao.Colunas - 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            pos.DefinirValores(posicao.Linhas - 2, posicao.Colunas + 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            pos.DefinirValores(posicao.Linhas - 1, posicao.Colunas + 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            pos.DefinirValores(posicao.Linhas + 1, posicao.Colunas + 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            pos.DefinirValores(posicao.Linhas + 2, posicao.Colunas + 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            pos.DefinirValores(posicao.Linhas + 2, posicao.Colunas - 1);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }
            pos.DefinirValores(posicao.Linhas + 1, posicao.Colunas - 2);
            if (tab.PosicaoValida(pos) && podeMover(pos))
            {
                mat[pos.Linhas, pos.Colunas] = true;
            }

            return mat;
        }
    }
}
