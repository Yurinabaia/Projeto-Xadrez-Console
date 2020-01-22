using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoXadrez.tabuleiro
{
    class TabuleiroExcpetion : Exception
    {
        public TabuleiroExcpetion(string mensagem) : base(mensagem) { }
    }
}
