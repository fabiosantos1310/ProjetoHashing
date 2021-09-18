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

    public enum Sondagem
    {
        linear, duplo, quadratica
    }

    public partial class FrmHash : Form
    {

        Sondagem sondagem;
        HashLinear tabelaLinear;
        HashDuplo tabelaDuplo;
        HashQuadratica tabelaQuadratica;

        public FrmHash()
        {
            tabelaLinear = new HashLinear(7);
            tabelaDuplo = new HashDuplo(7);
            tabelaQuadratica = new HashQuadratica(50);
            InitializeComponent();
            dgvTabela.ClearSelection();
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

            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                tabelaQuadratica.LerDados(dlgAbrir.FileName);
                tabelaDuplo.LerDados(dlgAbrir.FileName);
                tabelaLinear.LerDados(dlgAbrir.FileName);

            }

            rbLinear.PerformClick();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if ((!String.IsNullOrEmpty(txtChave.Text) && !String.IsNullOrWhiteSpace(txtNome.Text)))
            {
                var umaNovaPessoa = new Pessoa(txtChave.Text, txtNome.Text);

                switch (sondagem)
                {
                    case Sondagem.linear:
                        {
                            if (!tabelaLinear.Inserir(umaNovaPessoa))
                                MessageBox.Show("Chave repetida; Inclusão não efetuada!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                            {
                                tabelaLinear.ExibirDados(dgvTabela);
                                tabelaLinear.ExibirColisoes(lsbColisoes);
                                MessageBox.Show("Inclusão efetuada!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                            break;
                        }

                    case Sondagem.duplo:
                        {
                            if (!tabelaDuplo.Inserir(umaNovaPessoa))
                                MessageBox.Show("Chave repetida; exclusão não efetuada!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                            {
                                tabelaDuplo.ExibirDados(dgvTabela);
                                tabelaDuplo.ExibirColisoes(lsbColisoes);
                                MessageBox.Show("Inclusão efetuada!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            break;
                        }

                    case Sondagem.quadratica:
                        {
                            if (!tabelaQuadratica.Inserir(umaNovaPessoa))
                                MessageBox.Show("Chave repetida; exclusão não efetuada!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                            {
                                tabelaQuadratica.ExibirDados(dgvTabela);
                                tabelaQuadratica.ExibirColisoes(lsbColisoes);
                                MessageBox.Show("Inclusão efetuada!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        }
                }
            }
            else
                MessageBox.Show("Preencha corretamente os campos de digitação!", "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtChave.Text) && !String.IsNullOrWhiteSpace(txtNome.Text))
            {
                switch (sondagem)
                {
                    case Sondagem.linear:
                        {
                            var pessoa = new Pessoa(txtChave.Text, txtNome.Text);

                            if (tabelaLinear.Alterar(pessoa))
                            {
                                tabelaLinear.ExibirDados(dgvTabela);
                                MessageBox.Show("Edição efetuada!", "Edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Chave inexiste; Edição não efetuada!", "Edição", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            break;
                        }

                    case Sondagem.duplo:
                        {
                            var pessoa = new Pessoa(txtChave.Text, txtNome.Text);

                            if (tabelaDuplo.Alterar(pessoa))
                            {
                                tabelaDuplo.ExibirDados(dgvTabela);
                                MessageBox.Show("Edição efetuada!", "Edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Chave inexiste; Edição não efetuada!", "Edição", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            break;
                        }

                    case Sondagem.quadratica:
                        {
                            break;

                        }
                }
            }
            else
                MessageBox.Show("Preencha a chave de pesquisa!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtChave.Text))
            {
                switch (sondagem)
                {
                    case Sondagem.linear:
                        {
                            var pessoa = new Pessoa(txtChave.Text, " ");
                            int onde;

                            if (tabelaLinear.Buscar(pessoa.Chave, out onde))
                            {
                                txtNome.Text = tabelaLinear[onde].Nome;
                                MessageBox.Show("Busca efetuada!", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Chave inexiste; Busca não efetuada!", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            break;
                        }

                    case Sondagem.duplo:
                        {

                            var pessoa = new Pessoa(txtChave.Text, " ");
                            int onde;

                            if (tabelaDuplo.Buscar(pessoa.Chave, out onde))
                            {
                                txtNome.Text = tabelaDuplo[onde].Nome;
                                MessageBox.Show("Busca efetuada!", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Chave inexiste; Busca não efetuada!", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            break;
                        }

                    case Sondagem.quadratica:
                        {


                            break;

                        }
                }
            }
            else
                MessageBox.Show("Preencha a chave de pesquisa!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void rbLinear_Click_1(object sender, EventArgs e)
        {
            if (rbLinear.Checked)
            {
                sondagem = Sondagem.linear;
                Clear();
                tabelaLinear.ExibirDados(dgvTabela);
                tabelaLinear.ExibirColisoes(lsbColisoes);

            }
        }

        private void rbQuadratica_Click_1(object sender, EventArgs e)
        {
            if (rbQuadratica.Checked)
            {
                sondagem = Sondagem.quadratica;
                Clear();
                tabelaQuadratica.ExibirDados(dgvTabela);
                tabelaQuadratica.ExibirColisoes(lsbColisoes);
            }
        }

        private void rbDuplo_Click_1(object sender, EventArgs e)
        {
            if (rbDuplo.Checked)
            {
                sondagem = Sondagem.duplo;
                Clear();
                tabelaDuplo.ExibirDados(dgvTabela);
                tabelaDuplo.ExibirColisoes(lsbColisoes);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        void Clear()
        {
            dgvTabela.Rows.Clear();
            lsbColisoes.Items.Clear();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente excluir?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (!String.IsNullOrEmpty(txtChave.Text))
                {
                    switch (sondagem)
                    {
                        case Sondagem.linear:
                            {
                                var pessoa = new Pessoa(txtChave.Text, " ");

                                if (tabelaLinear.Remover(pessoa.Chave))
                                {
                                    tabelaLinear.ExibirDados(dgvTabela);
                                    MessageBox.Show("Exclusão efetuada!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show("Chave inexiste; exclusão não efetuada!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                break;
                            }

                        case Sondagem.duplo:
                            {

                                var pessoa = new Pessoa(txtChave.Text, " ");

                                if (tabelaDuplo.Remover(pessoa.Chave))
                                {
                                    tabelaDuplo.ExibirDados(dgvTabela);
                                    MessageBox.Show("Exclusão efetuada!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show("Chave inexiste; exclusão não efetuada!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                break;
                            }

                        case Sondagem.quadratica:
                            {

                                break;
                            }
                    }
                }
                else
                    MessageBox.Show("Preencha a chave de pesquisa!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            switch (sondagem)
            {
                case Sondagem.linear:
                    {
                        tabelaLinear.ExibirDados(dgvTabela);
                        break;
                    }

                case Sondagem.duplo:
                    {
                        tabelaDuplo.ExibirDados(dgvTabela);
                        break;
                    }

                case Sondagem.quadratica:
                    {
                        tabelaQuadratica.ExibirDados(dgvTabela);
                        break;
                    }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void FrmHash_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch (sondagem)
            {
                case Sondagem.linear:
                    {
                        tabelaLinear.GravarDados(dlgAbrir.FileName);
                        break;
                    }

                case Sondagem.duplo:
                    {
                        tabelaDuplo.GravarDados(dlgAbrir.FileName);
                        break;
                    }

                case Sondagem.quadratica:
                    {
                        tabelaQuadratica.GravarDados(dlgAbrir.FileName);
                        break;
                    }
            }
        }
    }
}

