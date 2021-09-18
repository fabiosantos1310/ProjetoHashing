using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace apBucketHash
{
  class BucketHash
  {
    private int tamanho = 23; // para gerar mais colisões; o ideal é primo > 100
    ArrayList[] dados;

    public int Tamanho { get => tamanho; }

    public ArrayList this[int posicao]
    {
      get => dados[posicao];   // retorna um bucket com todos os itens nele armazenados
    }

    public BucketHash(int tamanho)
    {
      this.tamanho = tamanho;
      dados = new ArrayList[tamanho];

      for (int i = 0; i <= tamanho - 1; i++)
        dados[i] = new ArrayList(1);
    }

    public int Hash(string chave)
    {
      long tot = 0;
      for (int i = 0; i < chave.Length; i++)
        tot += 37 * tot + (char)chave[i];

      tot = tot % dados.Length;
      if (tot < 0)
        tot += dados.Length;

      return (int)tot;   // retorna o índice do vetor dados onde um registro será armazenado
    }

    public bool Inserir(Pessoa item)
    {
      int valorDeHash, indicePessoa = -1;
      if (!Existe(item.Chave, out valorDeHash, out indicePessoa))
      {
        dados[valorDeHash].Add(item); // não existe, portanto inclui
        return true;                  // informa que conseguiu incluir o novo item na tabela de hash
      }
      return false; // já existe, não incluiu
    }

    public bool Existe(string chaveProcurada, out int ondeDados, out int indicePessoa)
    {
      ondeDados = Hash(chaveProcurada);  // posição do vetor onde deveria estar a pessoa com essa chave
      indicePessoa = -1;            //não achou a pessoa na lista ligada (no bucket) ainda

      foreach (Pessoa pessoa in dados[ondeDados])
      {
        indicePessoa++;  // avançamos posição dentro da lista ligada
        if (pessoa.Chave.CompareTo(chaveProcurada) == 0)
          return true;
      }

      return false;
    }
    public bool Remover(string chaveARemover)
    {
      int onde = 0;
      int indicePessoa = 0;
      if (!Existe(chaveARemover, out onde, out indicePessoa))
        return false;
      dados[onde].RemoveAt(indicePessoa);
      return true;
    }

    public void LerDeArquivo(string nomeArquivo)
    {
      if (!File.Exists(nomeArquivo))
      {
        var novoArq = new StreamWriter(nomeArquivo);
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
    public void SalvarEmArquivo(string nomeArquivo)
    {
      var arquivo = new StreamWriter(nomeArquivo);
      for (int numeroLinha = 0; numeroLinha < Tamanho; numeroLinha++)
      {
        foreach (Pessoa umaPessoa in dados[numeroLinha])
          arquivo.WriteLine(umaPessoa.FormatoDeArquivo());
      }
      arquivo.Close();
    }
  }
}