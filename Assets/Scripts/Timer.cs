using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LimitTime;
    public Text text_timer;

    public static Timer instance;

    void Awake()
    {


        if (Timer.instance == null)
        {
            Timer.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LimitTime -= Time.deltaTime;
        text_timer.text = "Time: " + Mathf.Round(LimitTime);
    }

}
