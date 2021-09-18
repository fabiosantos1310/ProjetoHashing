using System;
using System.Windows.Forms;

class HashLinear
{
   // private int tamanho = 7; // para gerar mais colisões; o ideal é primo > 100
    private string[] colisoes;
    Pessoa[] dados;          // instancio o arraylist dados


    public HashLinear(int tamanho)
    {
        this.colisoes = new string[tamanho];
        dados = new Pessoa[tamanho];
    }

    public Pessoa this[int posicao]
    {
        get
        {
            if (posicao < 0 || posicao > this.Tamanho -1)
            {
                throw new IndexOutOfRangeException("Posição inválida!");
            }

            return this.dados[posicao];
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

        ret = ret % this.Tamanho;

        if (ret < 0)
            ret += this.Tamanho;

        return (int)ret; // retorna o índice do vetor dados onde um registro será armazenado
    }

    public bool Inserir(Pessoa item)
    {

        int valorDeHash;



        if (!Existe(item.Chave, out valorDeHash))
        {
            this.colisoes = new string[this.Tamanho];
            int qtdColisao = 0;
            for (int pos = valorDeHash; pos <= this.Tamanho -1; pos++)
            {
                if(this.dados[pos] == null)
                {
                    this.dados[pos] = item;      // não existe, portanto inclui
                    return true;            // informa que conseguiu incluir o novo item na tabela de hash
                }
                else
                { 
                    colisoes[qtdColisao] = $"Colisao na {pos}° posição, entre {this.dados[pos].Chave.Trim()} e {item.Chave.Trim()}";
                    qtdColisao++;
                }

            }

            for(int pos = 0; pos < valorDeHash; pos++)
            {
                if (this.dados[pos] == null)
                {
                    this.dados[pos] = item;      // não existe, portanto inclui
                    return true;            // informa que conseguiu incluir o novo item na tabela de hash
                }
                else
                {
                    colisoes[qtdColisao] = $"Colisao na {pos}° posição, entre {this.dados[pos].Chave.Trim()} e {item.Chave.Trim()}";
                    qtdColisao++;
                }
            }
        }
        return false; // já existe, não incluiu
    }

    public bool Existe(string chaveProcurada, out int ondeDados)
    {
        ondeDados = Hash(chaveProcurada);  // posição do vetor onde deveria estar a pessoa com essa chave

        foreach(Pessoa pessoa in this.dados)
        {
            if(pessoa != null)
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

    public bool Alterar(Pessoa item)
    {
        int onde = 0;
        if (!Existe(item.Chave, out onde))
            return false;

        this.dados[onde].Nome = item.Nome;

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
}

