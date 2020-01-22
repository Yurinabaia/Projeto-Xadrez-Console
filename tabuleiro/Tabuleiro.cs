using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoXadrez.tabuleiro
{
    class Tabuleiro
    {
        public int linha { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;



        public Tabuleiro(int linha, int colunas)
        {
            this.linha = linha;
            this.colunas = colunas;
            pecas = new Peca[linha, colunas];
        }
        public Peca peca (int linha, int coluna)
        {
            return pecas[linha, coluna];

        }    
        public Peca peca (Posicao pos )
        {
            return pecas[pos.Linhas, pos.Colunas];

        }
        public bool existePecas ( Posicao poss) 
        {
            validarPosicao(poss);
            return peca(poss) != null;
        }
        public void colocarPeca(Peca p, Posicao pos) 
        {
            if(existePecas(pos)) 
            {
                throw new TabuleiroExcpetion("Posicação invalida");
            }
            pecas[pos.Linhas, pos.Colunas] = p;
            p.posicao = pos;

        }
        public Peca RetirarPecas(Posicao pos) 
        {
            if (peca(pos) == null) 
            { return null; 
            }
            Peca aux = peca(pos);
            aux.posicao = null;
            pecas[pos.Linhas, pos.Colunas] = null;
            return aux;
        }
        public bool PosicaoValida(Posicao pos) 
        {
            if(pos.Linhas< 0|| pos.Linhas>= linha || pos.Colunas < 0 || pos.Colunas >= colunas ) 
            {
                return false;
            }
            return true;
        }
        public void validarPosicao(Posicao pos)
        {
            if(!PosicaoValida(pos)) //Se minha posicao não for valida
            {
                throw new TabuleiroExcpetion("Erro posição invalida");
            }
        }
    }
}
