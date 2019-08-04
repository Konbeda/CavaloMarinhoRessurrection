using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializadorDoJogo : MonoBehaviour
{
    public List<GameObject> cavalos = new List<GameObject>();
    public Transform spawn1, spawn2, spawn3, spawn4;

    void Start()
    {
        if(Selecao.NumeroJogadores == 2)
        {
            Instantiate(cavalos[Selecao.cavalo1], spawn1.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.A;
            Instantiate(cavalos[Selecao.cavalo2], spawn2.position, Quaternion.identity).GetComponent<Cavalo>().tecla = KeyCode.Return;
        }
        else if(Selecao.NumeroJogadores == 3)
        {
            Instantiate(cavalos[Selecao.cavalo1], spawn1.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.A;
            Instantiate(cavalos[Selecao.cavalo2], spawn2.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.Return;
            Instantiate(cavalos[Selecao.cavalo3], spawn3.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.G;
        }
        else
        {
            Instantiate(cavalos[Selecao.cavalo1], spawn1.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.A;
            Debug.Log(Selecao.cavalo1);
            Instantiate(cavalos[Selecao.cavalo2], spawn2.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.Return;
            Debug.Log(Selecao.cavalo2);
            Instantiate(cavalos[Selecao.cavalo3], spawn3.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.G;
            Debug.Log(Selecao.cavalo3);
            Instantiate(cavalos[Selecao.cavalo4], spawn4.position, Quaternion.Euler(0, 0, -23.33f)).GetComponent<Cavalo>().tecla = KeyCode.L;
            Debug.Log(Selecao.cavalo4);
        }
    }
}
