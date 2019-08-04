using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moove : MonoBehaviour
{
    public float velocidade;

    void Update()
    {
        transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "deletador")
        {
            Destroy(gameObject);
        }
    }
}
