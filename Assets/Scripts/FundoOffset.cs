using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundoOffset : MonoBehaviour
{
    public Material currentMaterial;
    public float velocidade;
    float offset;

    void Start()
    {
        currentMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * velocidade;
        currentMaterial.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
