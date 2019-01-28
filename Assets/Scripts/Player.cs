using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed = 1000f;

    public AudioClip booster;
    public AudioClip hourglass;
    public AudioClip timebomb;

    AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
 
    }

    public void MoveControl()
    {
        float x = Input.acceleration.x;
        float moveX = speed * Time.deltaTime * x;
        

        if (x < -0.1f || x > 0.1f)
        {
            transform.Translate(moveX, 0, 0);
        }

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hourglass")
        {
            Destroy(collision.gameObject);
            myAudio.PlayOneShot(hourglass);
            Timer.instance.LimitTime += 10;
        }

        if (collision.gameObject.tag == "Booster")
        {
            Destroy(collision.gameObject);
            myAudio.PlayOneShot(booster);
            CreateManager.instance.isBooster = true;

            GameObject[] hourglasses = GameObject.FindGameObjectsWithTag("Hourglass");
            GameObject[] timebombs = GameObject.FindGameObjectsWithTag("Timebomb");

            for(int i= 0; i < hourglasses.Length; i++)
            {
                Destroy(hourglasses[i]);
            }
            for (int j = 0; j < timebombs.Length; j++)
            {
                Destroy(timebombs[j]);
            }

        }
        if (collision.gameObject.tag == "Timebomb")
        {
            Destroy(collision.gameObject);
            myAudio.PlayOneShot(timebomb);
            Timer.instance.LimitTime -= 10;
        }



    }
}
