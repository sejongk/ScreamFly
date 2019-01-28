using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{

    public float speed = 200f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


         MoveControl();


    }

    void MoveControl()
    {

        float yMove = speed * Time.deltaTime * CreateManager.instance.weight;
        if (!CreateManager.instance.isUp)
        {
            yMove = yMove * -0.4f;
        }
        transform.Translate(0, -yMove, 0);
    }
}
