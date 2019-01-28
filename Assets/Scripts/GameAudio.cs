using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{

    public static GameAudio instance;
    public int score = 0;


    private void Awake()
    {
        if(GameAudio.instance == null)
        {
            GameAudio.instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Global variable for game exiting.
    uint exitCountValue = 0;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {

            exitCountValue++;

            if (!IsInvoking("disable_DoubleClick"))

                Invoke("disable_DoubleClick", 0.3f);

        }

        if (exitCountValue == 2)
        {

            CancelInvoke("disable_DoubleClick");

            Application.Quit();

        }

    }

    void disable_DoubleClick()
    {

        exitCountValue = 0;

    }

}
