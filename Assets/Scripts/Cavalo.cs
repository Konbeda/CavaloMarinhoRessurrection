using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavalo : MonoBehaviour
{
    public KeyCode tecla;

    public float timer;
    public float force;
    public Rigidbody2D rb2d;

    //multiplicadores de movimentação
    public float prafrente;
    public float pracima;


    public float velPulo;

    public ParticleSystem burst;
    public ParticleSystem morte;

    public Animator animador;

    public float atraso;
    public SpriteRenderer imagem;

    public AudioSource source;
    public AudioClip pulin, pulao, morreu, tiro;

    public bool redeLetal;

    public InicializadorDoJogo inicializador;

    void Start()
    {
        inicializador = FindObjectOfType<InicializadorDoJogo>();
        source.PlayOneShot(tiro);
    }

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
            source.PlayOneShot(pulao);

        }
        else if (Input.GetKeyUp(tecla) && force < velPulo)
        {
            rb2d.AddForce(new Vector2(velPulo * prafrente, velPulo * pracima));
            force = 0;
            rb2d.gravityScale = 0.3f;
            burst.Emit(7);
            animador.SetBool("contraiu", false);
            animador.SetTrigger("pulin");
            source.PlayOneShot(pulin);
        }

        if (!redeLetal)
        {
            timer = timer += Time.deltaTime;
            if(timer > 5)
            {
                redeLetal = true;
                timer = 0;
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rede" && redeLetal)
        {
            timer = timer += Time.deltaTime;
            if(timer > 3)
            {
                StartCoroutine(Morrer());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rede")
        {
            timer = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "matador")
        {
            StartCoroutine(Morrer());
        }
        else if (collision.gameObject.tag == "atrasador")
        {
            StartCoroutine(Atrasar());
        }
    }

    IEnumerator Atrasar()
    {
        prafrente = prafrente / atraso;
        pracima = pracima / atraso;
        for(int i = 1; i < 15; i++)
        {
            imagem.color = new Color(imagem.color.r, imagem.color.g, imagem.color.b, 0.5f);
            yield return new WaitForSeconds(0.05f);
            imagem.color = new Color(imagem.color.r, imagem.color.g, imagem.color.b, 1);
            yield return new WaitForSeconds(0.05f);
        }
        prafrente = prafrente * atraso;
        pracima = pracima * atraso;
    }

    IEnumerator Morrer()
    {
        morte.Emit(300);
        morte.gameObject.transform.parent = null;
        gameObject.tag = "Untagged";
        yield return new WaitForSeconds(0.1f);
        if (!source.isPlaying)
        {
            source.PlayOneShot(morreu);
        }
        imagem.color = new Color(imagem.color.r, imagem.color.g, imagem.color.b, 0);
        yield return new WaitForSeconds(1.5f);
        inicializador.Morreu();
        Destroy(gameObject);
    }
}
