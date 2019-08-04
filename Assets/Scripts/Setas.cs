using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setas : MonoBehaviour
{
    public Selecao selecao;
    public Image imagem;
    public Text texto;

    public int n;

    public int NumeroJogador;

    void Start()
    {
        n = Random.Range(0, selecao.imagens.Count);
        imagem.sprite = selecao.imagens[n];
        texto.text = selecao.nomes[n];

        Registrar();
    }

    public void Left()
    {
        if(n == 0)
        {
            n = selecao.imagens.Count -1;
        }
        else
        {
            n--;
        }
        imagem.sprite = selecao.imagens[n];
        texto.text = selecao.nomes[n];

        Registrar();
    }

    public void Right()
    {
        if(n == selecao.imagens.Count -1)
        {
            n = 0;
        }
        else
        {
            n++;
        }
        imagem.sprite = selecao.imagens[n];
        texto.text = selecao.nomes[n];

        Registrar();
    }

    public void Registrar()
    {
        if(NumeroJogador == 1)
        {
            Selecao.cavalo1 = n;
        }
        else if (NumeroJogador == 2)
        {
            Selecao.cavalo2 = n;
        }
        else if (NumeroJogador == 3)
        {
            Selecao.cavalo3 = n;
        }
        else
        {
            Selecao.cavalo4 = n;
        }
    }
}
