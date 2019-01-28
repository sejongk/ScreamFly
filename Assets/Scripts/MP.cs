using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP : MonoBehaviour
{

    public static MP instance;

    public AudioSource _audio;
    string device;
    private float speed = 100f;
    private float back_speed = 0.5f;

    public float sum = 0;

    public bool isSoundRec = false;


    void Awake()
    {

        if (MP.instance == null)
        {
            MP.instance = this;
        }
    }

    void Start()
    {
        
        _audio = GetComponent<AudioSource>();
        //text.text = "배열 크기는" + Microphone.devices.Length;
        BeginListener(Microphone.devices.Length - 1);
        
    }

    void Update()
    {
        
        float[] spectrum = new float[1024];
        _audio.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        sum = 0;
        for (int i = 0; i < 1024; i++)
        {
            sum += spectrum[i];
        }
        sum = sum * 1000000;


        /*
        if (l4 > 0.04)
        {
            float moveY = speed * Time.deltaTime;
            obj.transform.Translate(0, moveY, 0);

            float newOffsetY = myMaterial.mainTextureOffset.y + back_speed * Time.deltaTime;
            Vector2 newOffset = new Vector2(0, newOffsetY);
            myMaterial.mainTextureOffset = newOffset;

        }
        */
        checkSound();
       

    }

    public void BeginListener(int index)
    {
        int min = 0;
        int max = 0;

        Microphone.GetDeviceCaps(Microphone.devices[index], out min, out max);

        //text2.text = "max는 " + max + " min은 " + min;
        _audio.clip = Microphone.Start(Microphone.devices[index], true, 1, max);

        while (!(Microphone.GetPosition(Microphone.devices[index]) > 1))
        {
            // Wait until the recording has started
        }

        _audio.loop = true;
        _audio.Play();
    }


    void checkSound()
    {
        if (sum > 3000)
        {
            isSoundRec = true;
        }
        else
        {
            isSoundRec = false;
        }
    }
}
