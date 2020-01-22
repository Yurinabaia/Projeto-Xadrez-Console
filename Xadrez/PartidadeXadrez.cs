using ProjetoXadrez.tabuleiro;
using System.Collections.Generic;

namespace ProjetoXadrez.Xadrez
{
    class PartidadeXadrez
    {
        public Tabuleiro tab { get;  set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public Peca vulneravelEnPassant { get; private set; }

        public bool xeque { get; private set; }

        public PartidadeXadrez()
        {
            this.tab = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            xeque = false;
            vulneravelEnPassant = null;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();

        }
        public Peca ExecutarMoviento (Posicao origem, Posicao destino) 
        {
            Peca p = tab.RetirarPecas(origem);
            p.IncrementaMovientos();
          Peca pecacapturada =  tab.RetirarPecas(destino);
            tab.colocarPeca(p, destino);
            if(pecacapturada != null) 
            {
                capturadas.Add(pecacapturada);
            }
            //Todo - JogadarEspecial Roque pequeno
            if(p is Rei && destino.Colunas == origem.Colunas + 2) 
            {
                Posicao origemDaTorre = new Posicao(origem.Linhas, origem.Colunas + 3);
                Posicao destinoDaTorre = new Posicao(origem.Linhas, origem.Colunas + 1);
                Peca T = tab.RetirarPecas(origemDaTorre);
                T.IncrementaMovientos();
                tab.colocarPeca(T,destinoDaTorre);
            }
            //Todo - JogadarEspecial Roque grande
            if (p is Rei && destino.Colunas == origem.Colunas - 2)
            {
                Posicao origemDaTorre = new Posicao(origem.Linhas, origem.Colunas - 4);
                Posicao destinoDaTorre = new Posicao(origem.Linhas, origem.Colunas - 1);
                Peca T = tab.RetirarPecas(origemDaTorre);
                T.IncrementaMovientos();
                tab.colocarPeca(T, destinoDaTorre);
            }



            // #jogadaespecial en passant
            if (p is Peao)
            {
                if (origem.Colunas != destino.Colunas && pecacapturada == null)
                {
                    Posicao posP;
                    if (p.cor == Cor.Branca)
                    {
                        posP = new Posicao(destino.Linhas + 1, destino.Colunas);
                    }
                    else
                    {
                        posP = new Posicao(destino.Linhas - 1, destino.Colunas);
                    }
                    pecacapturada = tab.RetirarPecas(posP);
                    capturadas.Add(pecacapturada);
                }
            }

            return pecacapturada;

            
        }
        public void ColocarNovasPecas(char coluna, int linha, Peca peca) 
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).ConverterPosicao());
            pecas.Add(peca);
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }
        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }
        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }
        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroExcpetion("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.LugaresPecas();
                if (mat[R.posicao.Linhas, R.posicao.Colunas])
                {
                    return true;
                }
            }
            return false;
        }

        private void ColocarPecas() 
        {
            ColocarNovasPecas('a', 1, new Torre(tab, Cor.Branca));
            ColocarNovasPecas('b', 1, new Cavalo(tab, Cor.Branca));
            ColocarNovasPecas('c', 1, new Bispo(tab, Cor.Branca));
            ColocarNovasPecas('d', 1, new Dama(tab, Cor.Branca));
            ColocarNovasPecas('e', 1, new Rei(tab, Cor.Branca, this));
            ColocarNovasPecas('f', 1, new Bispo(tab, Cor.Branca));
            ColocarNovasPecas('g', 1, new Cavalo(tab, Cor.Branca));
            ColocarNovasPecas('h', 1, new Torre(tab, Cor.Branca));
            ColocarNovasPecas('a', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovasPecas('b', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovasPecas('c', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovasPecas('d', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovasPecas('e', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovasPecas('f', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovasPecas('g', 2, new Peao(tab, Cor.Branca, this));
            ColocarNovasPecas('h', 2, new Peao(tab, Cor.Branca, this));

            ColocarNovasPecas('a', 8, new Torre(tab, Cor.Preta));
            ColocarNovasPecas('b', 8, new Cavalo(tab, Cor.Preta));
            ColocarNovasPecas('c', 8, new Bispo(tab, Cor.Preta));
            ColocarNovasPecas('d', 8, new Dama(tab, Cor.Preta));
            ColocarNovasPecas('e', 8, new Rei(tab, Cor.Preta, this));
            ColocarNovasPecas('f', 8, new Bispo(tab, Cor.Preta));
            ColocarNovasPecas('g', 8, new Cavalo(tab, Cor.Preta));
            ColocarNovasPecas('h', 8, new Torre(tab, Cor.Preta));
            ColocarNovasPecas('a', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovasPecas('b', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovasPecas('c', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovasPecas('d', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovasPecas('e', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovasPecas('f', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovasPecas('g', 7, new Peao(tab, Cor.Preta, this));
            ColocarNovasPecas('h', 7, new Peao(tab, Cor.Preta, this));

        }
        public void RealizarJogadas(Posicao origem, Posicao destino)
        {
          Peca percaCapturada =  ExecutarMoviento(origem, destino);
            if (estaEmXeque(JogadorAtual))
            {
                desfazMovimento(origem, destino, percaCapturada);
                throw new TabuleiroExcpetion("Você não pode se colocar em xeque!");
            }
            if(estaEmXeque(adversaria(JogadorAtual) ) )
                {
                xeque = true;
            }
            else 
            {
                xeque = false;
            }
            if (testeXequemate(adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                MudarJogador();
                Turno++;
            }
            // #jogadaespecial en passant
            Peca p = tab.peca(destino);
            if (p is Peao && (destino.Linhas == origem.Linhas - 2 || destino.Linhas == origem.Linhas + 2))
            {
                vulneravelEnPassant = p;
            }
            else
            {
                vulneravelEnPassant = null;
            }

            // #jogadaespecial promocao
            if (p is Peao)
            {
                if ((p.cor == Cor.Branca && destino.Linhas == 0) || (p.cor == Cor.Preta && destino.Linhas == 7))
                {
                    p = tab.RetirarPecas(destino);
                    pecas.Remove(p);
                    Peca dama = new Dama(tab, p.cor);
                    tab.colocarPeca(dama, destino);
                    pecas.Add(dama);
                }
            }

        }
        public bool testeXequemate(Cor cor)
        {
            if (!estaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.LugaresPecas();
                for (int i = 0; i < tab.linha; i++)
                {
                    for (int j = 0; j < tab.colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutarMoviento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }



        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.RetirarPecas(destino);
            p.DecrementaMovientos();
            if (pecaCapturada != null)
            {
                tab.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPeca(p, origem);

            //Todo - JogadarEspecial Roque pequeno Desfazer
            if (p is Rei && destino.Colunas == origem.Colunas + 2)
            {
                Posicao origemDaTorre = new Posicao(origem.Linhas, origem.Colunas + 3);
                Posicao destinoDaTorre = new Posicao(origem.Linhas, origem.Colunas + 1);
                Peca T = tab.RetirarPecas(destinoDaTorre);
                T.DecrementaMovientos();
                tab.colocarPeca(T, origemDaTorre);
            }
            //Todo - JogadarEspecial Roque grande Desfazer
            if (p is Rei && destino.Colunas == origem.Colunas - 2)
            {
                Posicao origemDaTorre = new Posicao(origem.Linhas, origem.Colunas - 4);
                Posicao destinoDaTorre = new Posicao(origem.Linhas, origem.Colunas - 1);
                Peca T = tab.RetirarPecas(destinoDaTorre);
                T.IncrementaMovientos();
                tab.colocarPeca(T, origemDaTorre);
            }

            // #jogadaespecial en passant
            if (p is Peao)
            {
                if (origem.Colunas != destino.Colunas && pecaCapturada == vulneravelEnPassant)
                {
                    Peca peao = tab.RetirarPecas(destino);
                    Posicao posP;
                    if (p.cor == Cor.Branca)
                    {
                        posP = new Posicao(3, destino.Colunas);
                    }
                    else
                    {
                        posP = new Posicao(4, destino.Colunas);
                    }
                    tab.colocarPeca(peao, posP);
                }
            }
        }
        private void MudarJogador() 
        {
            if(JogadorAtual == Cor.Branca) 
            {
                JogadorAtual = Cor.Preta;
            }
            else 
            {
                JogadorAtual = Cor.Branca;
            }
        }
        public void ValidarPecas(Posicao pos) 
        {
            if(tab.peca(pos) == null) 
            {
                throw new TabuleiroExcpetion("Posição esolida não possuir peças");
            }
            if (JogadorAtual != tab.peca(pos).cor) 
            {
                throw new TabuleiroExcpetion("Jogador não pode jogar com está peça");
            }
            if (!tab.peca(pos).existeMovientosPossiveis()) 
            {
                throw new TabuleiroExcpetion("Peça bloqueada");
            }
        }
        public void ValidarPecasDestino(Posicao origem, Posicao destino) 
        {
            if (!tab.peca(origem).movimentoPossivel(destino)) 
            {
                throw new TabuleiroExcpetion("Posição de origem invalida");
            }
        }
    }
}
