using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavalo : MonoBehaviour
{
    public KeyCode tecla;

    public float force;
    public Rigidbody2D rb2d;

    //multiplicadores de movimentação
    public int prafrente;
    public int pracima;


    public float velPulo;

    public ParticleSystem burst;

    public Animator animador;

    void Update()
    {
        if (Input.GetKeyDown(tecla))
        {
            animador.SetBool("contraiu", true);
        }

        if (Input.GetKey(tecla))
        {
            if (force < 0.6)
            {
                force += Time.deltaTime;
            }
            rb2d.velocity = new Vector2(0, 0);
            rb2d.gravityScale = 0;
            transform.Translate(new Vector2(0, 0));
        }

        if (Input.GetKeyUp(tecla) && force > velPulo)
        {
            rb2d.AddForce(new Vector2(force * prafrente, force * pracima));
            force = 0;
            rb2d.gravityScale = 0.3f;
            burst.Emit(30);
            animador.SetBool("contraiu", false);

        }
        else if (Input.GetKeyUp(tecla) && force < velPulo)
        {
            rb2d.AddForce(new Vector2(velPulo * prafrente, velPulo * pracima));
            force = 0;
            rb2d.gravityScale = 0.3f;
            burst.Emit(7);
            animador.SetBool("contraiu", false);
            animador.SetTrigger("pulin");
        }
    }
}
