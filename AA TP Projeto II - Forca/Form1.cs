using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace AA_TP_Projeto_II___Forca
{
    public partial class FrmForca : Form
    {
        Palavra[] vetorDePalavras = new Palavra[100];
        StreamReader arquivo;
        int qtasPalavras = 0;
        int numero;
        int tempo = 100;
        int qtasLetras;
        int pontos = 0;
        int erros = 0;
        string palavra;
        public FrmForca()
        {
            InitializeComponent();

            if(dlgAbrirArquivo.ShowDialog() == DialogResult.OK)
            {
                arquivo = new StreamReader(dlgAbrirArquivo.FileName, System.Text.Encoding.Default,true);
                while (!arquivo.EndOfStream)
                {
                    Palavra novaPalavra = new Palavra();
                    novaPalavra.LerDados(arquivo);
                    vetorDePalavras[qtasPalavras] = novaPalavra;
                    qtasPalavras++;
                }
                arquivo.Close();
            }
        }

        private void btnBotao_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
            string letraProcurada = btn.Text;
            bool primeiroErro = true;


            for (int i = 0; i < qtasLetras; i++)
            {
                string letraAtual = palavra.Substring(i, 1);
                if (letraProcurada == letraAtual)
                {
                    dgvPalavra.Rows[0].Cells[i].Value = letraProcurada;
                    pontos++;
                    lbPontos.Text = "Pontos: " + pontos;
                    primeiroErro = false;
                }
                if (letraProcurada != letraAtual && primeiroErro)
                {
                    pontos--;
                    lbPontos.Text = "Pontos: " + pontos;
                    erros++;
                    lbErros.Text = "Erros(8): " + erros;
                    primeiroErro = false;
                }
            }
            if (erros == 1)
            {
                pbCabecaViva1.Visible = true;
            }
            if (erros == 2)
            {
                pbCabecaViva2.Visible = true;
                pbPescoco.Visible = true;
            }
            if (erros == 3)
            {
                pbCorpo1.Visible = true;          
            }
            if (erros == 4)
            {
                pbCorpo2.Visible = true;
            }
            if(erros == 5)
            {
                pbMaoDireita.Visible = true;
            }
            if(erros == 6)
            {
                pbMaoEsquerda.Visible = true;
            }
            if(erros == 7)
            {
                pbPeEsquerdo.Visible = true;
            }
            if(erros == 8)
            {
                pbPeDireito.Visible = true;
            }
            
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {           
            tempo = 100;
            Random numeroDaPalavra = new Random();
            numero = numeroDaPalavra.Next(qtasPalavras);          
            palavra = vetorDePalavras[numero].PalavraEscolhida.ToUpper();
            qtasLetras = palavra.Length;
            dgvPalavra.ColumnCount = qtasLetras;
            dgvPalavra.RowCount = 1;
            lbPontos.Text = "Pontos: ";

            for (int i = 0; i < qtasLetras; i++)
            {
                dgvPalavra.Rows[0].Cells[1].Value = null;
            }                            
            if (chbDica.Checked)
            {
                Palavra novaPalavra = new Palavra();
                vetorDePalavras[qtasPalavras] = novaPalavra;
                lbDica.Text = "Dica: " + vetorDePalavras[numero].Dica;
                tmrTempo.Enabled = true;               
            }
        }

        private void tmrTempo_Tick(object sender, EventArgs e)
        {
            if (tempo <= 0)
            {
                tmrTempo.Enabled = false;
                MessageBox.Show("Tempo esgotado!\nPerdeste, trouxa.");
            }
            else
            { 
                tempo -= 1;
                lbTempo.Text = "Tempo Restante: " + tempo + "s";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
