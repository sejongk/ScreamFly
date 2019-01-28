using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveManager : MonoBehaviour
{
    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Booster" || collision.gameObject.tag == "Hourglass" || collision.gameObject.tag == "Timebomb")
        {
            Destroy(collision.gameObject);
        }
    }
}
