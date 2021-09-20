using System;
using System.IO;
using System.Windows.Forms;

namespace Hashing
{
    class HashQuadratica
    {
        private string[] colisoes;
        private Pessoa[] dados;          // instancio o arraylist dados
        private int qtd;


        public HashQuadratica(int tamanho)
        {
            qtd = 0;
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

        public int Qtd
        {
            get => qtd;
            set
            {
                if (value < 0 || value > this.Tamanho)
                {
                    throw new IndexOutOfRangeException("Quantidade inválida!");
                }

                qtd = value;

            }
        }

        public int Tamanho
        {
            get => dados.Length;            
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

                if (this.Tamanho == this.Qtd)
                    RedimensioneSe(this.Tamanho * 2);

                int pos = 1;
                this.colisoes = new string[this.dados.Length];
                int qtdColisao = 0;

                while (valorDeHash <= this.Tamanho - 1)
                {
                    if (this.dados[valorDeHash] == null)
                    {
                        this.dados[valorDeHash] = item;      // não existe, portanto inclui
                        Qtd++;
                        return true;            // informa que conseguiu incluir o novo item na tabela de hash
                    }
                    else
                    {
                        colisoes[qtdColisao] = $"Colisao na {valorDeHash}° posição, entre {this.dados[valorDeHash].Nome.Trim()} e {item.Nome.Trim()}";
                        qtdColisao++;                        
                        valorDeHash = valorDeHash + (pos * pos);
                        pos++;


                    }                   
                }
            }
            return false; // já existe, não incluiu
        }


        public bool Existe(string chaveProcurada, out int ondeDados)
        {
            ondeDados = Hash(chaveProcurada);  // posição do vetor onde deveria estar a pessoa com essa chave

            int aux = 1;
            for (int pos = ondeDados; pos <= this.Tamanho - 1; pos+=(aux*aux))
            {
                if (this.dados[pos] != null)
                    if (this.dados[pos].Chave.CompareTo(chaveProcurada) == 0)
                    {
                        ondeDados = pos;        // não existe, portanto inclui
                        return true;            // informa que conseguiu incluir o novo item na tabela de hash
                    }
            }

            return false;
        }

        public bool Alterar(Pessoa item)
        {
            int onde = 0;
            if (!Existe(item.Chave, out onde))
                return false;

            this.dados[onde].Nome = item.Nome;

            return true;
        }


        public bool Remover(string chaveARemover)
        {
            int onde = 0;
            if (!Existe(chaveARemover, out onde))
                return false;


            this.dados[onde] = null;
            Qtd--;

            return true;
        }

        private void RedimensioneSe(int novaCap)
        {
            Pessoa[] novo = new Pessoa[novaCap];

            for (int i = 0; i < this.Tamanho; i++)
                novo[i] = this.dados[i];

            this.dados = novo;
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
                    dgv[1, numeroLinha].Value = dados[numeroLinha].Chave.Trim();
                    dgv[2, numeroLinha].Value = dados[numeroLinha].Nome.Trim();
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
        }

        public void LerDados(string nomeArquivo)
        {
            if (!File.Exists(nomeArquivo))
            {
                var novoArq = File.CreateText(nomeArquivo);
                novoArq.Close();
            }

            var arquivo = new StreamReader(nomeArquivo);

            while (!arquivo.EndOfStream)
            {
                var umaPessoa = new Pessoa(arquivo.ReadLine());
                Inserir(umaPessoa);
            }
            arquivo.Close();
        }

        public void GravarDados(string nomeArquivo)
        {
            var arquivo = new StreamWriter(nomeArquivo);

            foreach (Pessoa pessoa in dados)
            {
                if (pessoa != null)
                    arquivo.WriteLine(pessoa.FormatoDeArquivo());
            }

            arquivo.Close();
        }
    }
}
