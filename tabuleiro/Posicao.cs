

namespace ProjetoXadrez.tabuleiro
{
     class Posicao
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        public Posicao(int linha, int coluna)
        {
            Linhas = linha;
            Colunas = coluna;
        }
        public override string ToString()
        {
            return Linhas + ", " + Colunas;
        }
        public void DefinirValores (int linha, int coluna) 
        {
            Linhas = linha;
            Colunas = coluna;
        }
    }
}
