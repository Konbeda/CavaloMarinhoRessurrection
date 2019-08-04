using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Selecao : MonoBehaviour
{
    public Button iniciar;
    public GameObject jogador1, jogador2, jogador3, jogador4;

    public List<Sprite> imagens = new List<Sprite>();
    public List<string> nomes = new List<string>();

    public static int cavalo1;
    public static int cavalo2;
    public static int cavalo3;
    public static int cavalo4;
    public static int NumeroJogadores;

    public List<Setas> setas = new List<Setas>();

    public void Numero(int jogadores)
    {
        foreach(Setas seta in setas)
        {
            seta.Registrar();
        }
        iniciar.enabled = true;
        switch (jogadores)
        {
            case (2):
                jogador1.SetActive(true);
                jogador2.SetActive(true);
                jogador3.SetActive(false);
                jogador4.SetActive(false);
                iniciar.interactable = true;
                NumeroJogadores = 2;
                break;

            case (3):
                jogador1.SetActive(true);
                jogador2.SetActive(true);
                jogador3.SetActive(true);
                jogador4.SetActive(false);
                iniciar.interactable = true;
                NumeroJogadores = 3;
                break;

            case (4):
                jogador1.SetActive(true);
                jogador2.SetActive(true);
                jogador3.SetActive(true);
                jogador4.SetActive(true);
                iniciar.interactable = true;
                NumeroJogadores = 4;
                break;
        }
    }

    public void Inciar()
    {
        SceneManager.LoadScene("Jogo");
    }
}
