using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InicializadorDoJogo : MonoBehaviour
{
    public List<GameObject> cavalos = new List<GameObject>();
    public Transform spawn1, spawn2, spawn3, spawn4;

    public int i;
    public bool acabou;

    public GameObject fade;
    public GameObject canvas;

    public Image vencedor;

    void Start()
    {
        i = Selecao.NumeroJogadores;

        if (Selecao.NumeroJogadores == 2)
        {
            Instantiate(cavalos[Selecao.cavalo1], spawn1.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.A;
            Instantiate(cavalos[Selecao.cavalo2], spawn2.position, Quaternion.identity).GetComponent<Cavalo>().tecla = KeyCode.Return;
        }
        else if (Selecao.NumeroJogadores == 3)
        {
            Instantiate(cavalos[Selecao.cavalo1], spawn1.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.A;
            Instantiate(cavalos[Selecao.cavalo2], spawn2.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.Return;
            Instantiate(cavalos[Selecao.cavalo3], spawn3.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.G;
        }
        else
        {
            Instantiate(cavalos[Selecao.cavalo1], spawn1.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.A;
            Instantiate(cavalos[Selecao.cavalo2], spawn2.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.Return;
            Instantiate(cavalos[Selecao.cavalo3], spawn3.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.G;
            Instantiate(cavalos[Selecao.cavalo4], spawn4.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.L;
        }
    }

    public void Morreu()
    {
        i--;
        Debug.Log(i);
    }

    void Update()
    {
        if (i <= 1 && !acabou)
        {
            Time.timeScale = 0.0001f;
            acabou = true;
            fade.SetActive(true);
            canvas.SetActive(true);

            vencedor.sprite = GameObject.FindGameObjectWithTag("cavalo").GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void Recomeca()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Selecao");
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Inicial");
    }
}