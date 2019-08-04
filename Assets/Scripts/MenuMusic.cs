using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Jogo")
        {
            Destroy(gameObject);
        }
    }
}
