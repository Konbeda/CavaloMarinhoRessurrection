
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjeto : MonoBehaviour
{    
    // lista spawner
    public List<Transform> lista_spawner = new List<Transform>();

    // listas objetos 
    public List<GameObject> cima = new List<GameObject>();
    public List<GameObject> meio = new List<GameObject>();
    public List<GameObject> baixo = new List<GameObject>();

    public float tempo;
    public float espera;
    public float retirada;

    int numero;

    void Update()
    {
        tempo += Time.deltaTime;

        if (tempo >= espera)
        {
            numero = Random.Range(1, 4);

            if(numero == 1)
            {
                Instantiate(cima[Random.Range(0, 4)], lista_spawner[0].position, Quaternion.identity);
            }
            else if(numero == 2)
            {
                Instantiate(meio[Random.Range(0, 3)], lista_spawner[1].position, Quaternion.identity);
            }
            else
            {
                Instantiate(baixo[Random.Range(0, 3)], lista_spawner[2].position, Quaternion.identity);
            }
            espera = espera - espera / retirada;
            tempo = 0;
        }
    }
}