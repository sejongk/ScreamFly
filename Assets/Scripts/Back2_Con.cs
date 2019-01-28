using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back2_Con : MonoBehaviour
{

    public float speed = 0.5f;
    Material myMaterial;
    public bool isMove = false;

    public static Back2_Con instance;

    private void Awake()
    {
        if(Back2_Con.instance == null)
        {
            Back2_Con.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            float newOffsetY = myMaterial.mainTextureOffset.y + speed * Time.deltaTime;
            Vector2 newOffset = new Vector2(0, newOffsetY);
            myMaterial.mainTextureOffset = newOffset;
        }
    }
}
