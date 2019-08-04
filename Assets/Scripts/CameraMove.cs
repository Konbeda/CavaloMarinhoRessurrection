using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float velocidade;

    void Update()
    {
        transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
    }
}
