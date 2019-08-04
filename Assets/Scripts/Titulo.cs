using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titulo : MonoBehaviour
{
    float tempo;

    void Update()
    {
        if (tempo < 1)
        {
            tempo += Time.deltaTime;
        }
        else
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Botoes");
            }
        }
    }
}
