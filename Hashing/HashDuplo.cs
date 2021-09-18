using System;
using System.IO;
using System.Windows.Forms;

class HashDuplo
{
    private int qtd = 0;
    private string[] colisoes;
    private Pessoa[] dados;          // instancio o arraylist dados


    public HashDuplo(int tamanho)
    {
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
        get => this.dados.Length;
    }


    public int Hash(string chave)
    {
        long ret = 0;
        for (int i = 0; i < chave.Length; i++)
            ret += 37 * ret + (char)chave[i];

        ret = ret % this.dados.Length;

        if (ret < 0)
            ret += this.dados.Length;
        else if (ret == 0)
            ret += this.dados.Length - 1;

        return (int)ret; // retorna o índice do vetor dados onde um registro será armazenado
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


    public bool Buscar(string chaveProcurada, out int ondeDados)
    {
        ondeDados = Hash(chaveProcurada);  // posição do vetor onde deveria estar a pessoa com essa chave

        for (int pos = ondeDados; pos <= this.Tamanho - 1; pos = Hash(pos.ToString()))
        {
            if (this.dados[pos].Chave.CompareTo(chaveProcurada) == 0)
            {
                ondeDados = pos;        // não existe, portanto inclui
                return true;            // informa que conseguiu incluir o novo item na tabela de hash
            }
        }

        return false;
    }

    public bool Inserir(Pessoa item)
    {

        int valorDeHash;

        if (!Existe(item.Chave, out valorDeHash))
        {

            this.colisoes = new string[this.dados.Length];
            int qtdColisao = 0;

            while (qtdColisao < this.Tamanho)
            {
                if (this.dados[valorDeHash] == null)
                {
                    this.dados[valorDeHash] = item;
                    return true;
                }
                else
                {
                    colisoes[qtdColisao] = $"Colisao na {valorDeHash}° posição, entre {this.dados[valorDeHash].Nome.Trim()} e {item.Nome.Trim()} - Hash{valorDeHash} - {Hash(valorDeHash.ToString())}";
                    valorDeHash = Hash(valorDeHash.ToString());
                    //valorDeHash *= 2;
                    qtdColisao++;
                }
            }
        }
        return false; // já existe, não incluiu
    }

    public bool Alterar(Pessoa item)
    {
        int onde = 0;
        if (!Buscar(item.Chave, out onde))
            return false;

        this.dados[onde].Nome = item.Nome;

        return true;
    }


    public bool Remover(string chaveARemover)
    {
        int onde = 0;
        if (!Buscar(chaveARemover, out onde))
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
            if(pessoa != null)
                arquivo.WriteLine(pessoa.FormatoDeArquivo());
        }
        arquivo.Close();
    }
}

