using System;
using System.Windows.Forms;

namespace Hashing
{
    class HashQuadratica
    {
        private int tamanho = 7; // para gerar mais colisões; o ideal é primo > 100
        private int qtd = 0;
        private string[] colisoes;
        Pessoa[] dados;          // instancio o arraylist dados


        public HashQuadratica(int tamanho)
        {
            this.tamanho = tamanho;
            this.colisoes = new string[tamanho];
            dados = new Pessoa[tamanho];
        }

        public Pessoa this[int posicao]
        {
            get
            {
                if (posicao < 0 || posicao > this.Tamanho - 1)
                {
                    throw new IndexOutOfRangeException("Posição inválida!");
                }

                return this.dados[posicao];
            }

        }

        public int Tamanho
        {
            get => tamanho;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Tamanho inválido!");
                }

                tamanho = value;
            }
        }
        public int Qtd
        {
            get => qtd;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Tamanho inválido!");
                }

                qtd = value;
            }
        }

        public int Hash(string chave)
        {
            long ret = 0;
            for (int i = 0; i < chave.Length; i++)
                ret += 37 * ret + (char)chave[i];

            ret = ret % this.dados.Length;

            if (ret < 0)
                ret += this.dados.Length;

            return (int)ret; // retorna o índice do vetor dados onde um registro será armazenado
        }

        public bool Inserir(Pessoa item)
        {

            int valorDeHash;
            int i = 0;



            if (!Existe(item.Chave, out valorDeHash))
            {

                if (this.dados.Length == this.qtd)
                    this.redimensioneSe(2 * this.dados.Length);
                int pos = valorDeHash;
                while (pos <= this.dados.Length - 1)
                {
                    if (this.dados[pos] == null)
                    {
                        this.dados[pos] = item;      // não existe, portanto inclui
                        qtd++;
                        return true;            // informa que conseguiu incluir o novo item na tabela de hash
                    }
                    else
                    {
                        colisoes[i] = $"Colisao na {pos}° posição, entre {this.dados[pos].Chave.Trim()} e {item.Chave.Trim()} - Hash{valorDeHash}";
                        i++;
                    }
                    pos++;
                    pos = valorDeHash + (pos * pos);
                }

            }
            return false; // já existe, não incluiu
        }

        private void redimensioneSe(int novaCap)
        {
            Pessoa[] novo = new Pessoa[novaCap];

            for (int i = 0; i < this.dados.Length; i++)
                novo[i] = this.dados[i];


            this.dados = novo;
            this.tamanho = this.dados.Length;
        }


        public bool Existe(string chaveProcurada, out int ondeDados)
        {
            ondeDados = Hash(chaveProcurada);  // posição do vetor onde deveria estar a pessoa com essa chave

            foreach (Pessoa pessoa in this.dados)
            {
                if (pessoa != null)
                    if (pessoa.Chave.CompareTo(chaveProcurada) == 0)
                        return true;
            }

            return false;
        }

        public bool Remover(string chaveARemover)
        {
            int onde = 0;
            if (!Existe(chaveARemover, out onde))
                return false;


            this.dados[onde] = null;

            return true;
        }

        public void ExibirDados(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.RowCount = this.Tamanho;

            for (int numeroLinha = 0; numeroLinha <= this.Tamanho - 1; numeroLinha++)
            {
                if (dados[numeroLinha] != null)
                {
                    dgv[0, numeroLinha].Value = numeroLinha;
                    dgv[1, numeroLinha].Value = dados[numeroLinha].Chave;
                    dgv[2, numeroLinha].Value = dados[numeroLinha].Nome;
                }
            }
        }

        public void ExibirColisoes(ListBox lsb)
        {
            for (int i = 0; i < this.colisoes.Length; i++)
            {
                if (this.colisoes[i] != null)
                    lsb.Items.Add(this.colisoes[i]);
            }

            lsb.Items.Add("--------------------------------------------------------");

        }
    }
}
