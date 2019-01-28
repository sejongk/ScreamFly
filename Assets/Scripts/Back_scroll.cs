using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_scroll : MonoBehaviour
{
    public float speed = 0.5f;
    public Material myMaterial;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

}