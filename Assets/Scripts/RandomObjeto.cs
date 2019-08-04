
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjeto : MonoBehaviour
{    
    // lista spawner
    public List<Transform> lista_spawner = new List<Transform>();

    // lista objeto 
    public List<GameObject> lista_objeto = new List<GameObject>();

    public float tempo;
    public float espera;
    public float retirada;

    void Update()
    {
        tempo += Time.deltaTime;

        if (tempo >= espera)
        {
            Instantiate(lista_objeto[Random.Range(0, lista_objeto.Count)], lista_spawner[Random.Range(0, lista_spawner.Count)].position, Quaternion.identity);
            espera = espera - espera / retirada;
            tempo = 0;
        }
    }
}