using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hashing
{        
    public enum Situacao
    {
        incluindo, pesquisando, editando, excluindo
    }

    public enum Sondagem
    {
        linear, duplo, quadratica
    }

    public partial class FrmHash : Form
    {


        Situacao situacao;
        Sondagem sondagem;
        HashLinear tabelaLinear;
        HashDuplo tabelaDuplo;
        HashQuadratica tabelaQuadratica;

        public FrmHash()
        {
            tabelaQuadratica = new HashQuadratica(50);
            tabelaLinear = new HashLinear(7);
            InitializeComponent();
        }



        private void FrmHashLinear_Load(object sender, EventArgs e)
        {
            // Exibição das imagens nos botões do menu de navegação
            tsBotoes.ImageList = imlBotoes;
            int indice = 0;
            foreach (ToolStripItem item in tsBotoes.Items)
            {
                if (item is ToolStripButton) // se não é separador:
                {
                    (item as ToolStripButton).ImageIndex = indice++; // Adiciona a imagem no botão
                }
            }

            rbLinear.PerformClick();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            /**/ 
            if ((!String.IsNullOrEmpty(txtChave.Text) && !String.IsNullOrWhiteSpace(txtNome.Text)))
             {
                 var umaNovaPessoa = new Pessoa(txtChave.Text, txtNome.Text);

                 switch(sondagem)
                 {
                     case Sondagem.linear:
                         {
                            if (!tabelaLinear.Inserir(umaNovaPessoa))
                                 MessageBox.Show("Chave repetida; inclusão não efetuada!");
                             else
                             {
                                 tabelaLinear.ExibirDados(dgvTabela);
                                 tabelaLinear.ExibirColisoes(lsbColisoes);
                             }
                             break;
                         }

                     case Sondagem.duplo:
                         {
                            if (!tabelaDuplo.Inserir(umaNovaPessoa))
                                MessageBox.Show("Chave repetida; inclusão não efetuada!");
                            else
                            {
                                tabelaLinear.ExibirDados(dgvTabela);
                                tabelaLinear.ExibirColisoes(lsbColisoes);
                            }

                            break;
                         }

                     case Sondagem.quadratica:
                         {
                            if (!tabelaQuadratica.Inserir(umaNovaPessoa))
                                MessageBox.Show("Chave repetida; inclusão não efetuada!");
                            else
                            {
                                tabelaQuadratica.ExibirDados(dgvTabela);
                                tabelaQuadratica.ExibirColisoes(lsbColisoes);
                            }
                            break;
                         }
                 }               
             }
             else
                 MessageBox.Show("Preencha os dois campos de dados!");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

        }

        private void rbLinear_Click_1(object sender, EventArgs e)
        {
            if (rbLinear.Checked)
                sondagem = Sondagem.linear;
        }

        private void rbQuadratica_Click_1(object sender, EventArgs e)
        {
            if (rbQuadratica.Checked)
                sondagem = Sondagem.quadratica;
        }

        private void rbDuplo_Click_1(object sender, EventArgs e)
        {
            if (rbDuplo.Checked)
                sondagem = Sondagem.duplo;
        }
    }
}

