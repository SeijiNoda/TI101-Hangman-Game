using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AA_TP_Projeto_II___Forca
{
    class Palavra
    {
        const int inicioPalavra = 0;
        const int inicioDica = inicioPalavra + tamanhoPalavra;

        const int tamanhoPalavra = 15;

        string palavraEscolhida;
        string dica;

        public string PalavraEscolhida { get => palavraEscolhida.Trim(); set => palavraEscolhida = value; }
        public string Dica { get => dica; set => dica = value; }

        public void LerDados(StreamReader arq)   // ler de um arquivo texto
        {
            if (!arq.EndOfStream)
            {
                string linha = arq.ReadLine();
                palavraEscolhida = linha.Substring(inicioPalavra, tamanhoPalavra);
                dica = linha.Substring(inicioDica);
            }
        }

        public override string ToString()
        {
            string resultado =
                    PalavraEscolhida + Dica;
            return resultado;
        }
    }
}
