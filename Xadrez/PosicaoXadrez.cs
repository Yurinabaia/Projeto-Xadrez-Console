using ProjetoXadrez.tabuleiro;

namespace ProjetoXadrez.Xadrez
{
    class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }
        public Posicao ConverterPosicao() 
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }
        public override string ToString()
        {
            return "" + Linha +  Coluna;
        }
    }
}
