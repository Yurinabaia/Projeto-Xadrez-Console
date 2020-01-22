using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoXadrez.tabuleiro
{
     class  Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Cor cor, Tabuleiro tab)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            this.QtdMovimentos = 0;
        }
        public void IncrementaMovientos() 
        {
            QtdMovimentos++;
        } 
        public void DecrementaMovientos() 
        {
            QtdMovimentos--;
        }
        public virtual bool[,] LugaresPecas() 
        {
            throw new Exception();
        }

        public bool existeMovientosPossiveis() 
        {
            bool[,] mat = LugaresPecas();
            for(int i = 0; i< tab.linha; i++) 
            {
                for(int j = 0; j < tab.colunas; j++) 
                {
                    if(mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool movimentoPossivel(Posicao pos) 
        {
            return LugaresPecas()[pos.Linhas, pos.Colunas];
        }
    }
}
