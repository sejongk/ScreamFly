using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{

    public static CreateManager instance;

    Vector3[] positions = new Vector3[9];

    public GameObject booster;
    public GameObject hourglass;
    public GameObject timebomb;
        
    public bool isUp;
    public float createDelay = 0.2f;
    public bool isBooster = false;
    float createTimer = 0f;

   
    public float weight = 1;



    void Awake()
    {
        if (CreateManager.instance == null)
        {
            CreateManager.instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        createPositions();
    }

    // Update is called once per frame
    void Update()
    {
        createStar();
    }

    void createPositions()
    {
        float viewPosY = 1.1f;
        float gapX = 1.0f / 9.0f;
        float viewPosX = 0f;
        for (int i = 0; i < positions.Length; i++)
        {
            viewPosX = gapX + gapX * i;
            Vector3 viewPos = new Vector3(viewPosX, viewPosY, 0);
            Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
            worldPos.z = -8f;
            positions[i] = worldPos;
        }
    }

    void createStar()
    {
        if(GameManager.instance.isMove && !GameManager.instance.isEnd)
        {
            if(createTimer > createDelay)
            {
                int i = Random.Range(0, positions.Length);
                float poss = Random.Range(0.0f,1.1f);
                float crea = Random.Range(0.0f, 1.0f);
                if (crea > 0.0f)
                {
                    if (poss > 0.9f)
                    {
                        Instantiate(hourglass, positions[i], Quaternion.identity);
                    }
                    else if (poss > 0.5f && poss < 0.9f)
                    {
                        Instantiate(booster, positions[i], Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(timebomb, positions[i], Quaternion.identity);
                    }
                }
                createTimer = 0;
            }
            createTimer += Time.deltaTime;
        }
    }
}
