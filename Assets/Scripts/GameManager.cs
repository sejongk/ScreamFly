using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private GameObject player;

    private float height = 0f;
    private float world_height;
    private float buffer_offset;
    private float back_speed = -200f;
    private float back_offset_speed = 0.15f;
    private float up_speed = 200f;
    private float down_speed = -50f;
    private bool isStart = false;
    public bool isEnd = false;
    private float up_limit_y = 0.4f;
    private float down_limit_y = 0.1f;
    private float moveY;
    private float newOffsetY;
    private Vector2 newOffset;

    public Material back1, back2, back3, back4, back5;
    public GameObject background1, background2, background3, background4, background5;

    public Text score_text;
    private float booster_buffer;
    public bool isMove = false;


    void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //isStart = true;
        buffer_offset = 0f;
        world_height = 0f;
        booster_buffer = 0f;
        isEnd = false;
        isStart = false;
        height = 0f;

        player = GameObject.FindWithTag("Player");
        score_text.text = "Score: " + Mathf.RoundToInt(height);

    }

    void StartGame()
    {
        //CreateManager.instance.isCreate = true;
    }



    // Update is called once per frame
    void Update()
    {


        if (Timer.instance.LimitTime < 0)
        {

            GameAudio.instance.score = Mathf.RoundToInt(height);
            EndGame();
            SceneManager.LoadScene("LastScene");
        }
        

        if (CreateManager.instance.isBooster)
        {
            isStart = true;
            isMove = true;

            if (booster_buffer < 0.5f)
            {
                CreateManager.instance.isUp = true;

                ScreenManage(5f);
                booster_buffer += Time.deltaTime;
            }

            else
            {
                CreateManager.instance.isBooster = false;
                booster_buffer = 0f;
            }


        }

        if (!isEnd) {
            if (isStart)
            {
                if (MP.instance.isSoundRec)
                {
                    isMove = true;
                    CreateManager.instance.isUp = true;


                    ScreenManage(0);
                }

                else
                {
                    isMove = false;
                    CreateManager.instance.isUp = false;
                    CreateManager.instance.weight = 1;

                    if (Camera.main.WorldToViewportPoint(player.transform.position).y > down_limit_y)
                    {
                        moveY = down_speed * Time.deltaTime;
                        player.transform.Translate(0, moveY, 0);
                        height -= 1 * Time.deltaTime;
                    }
                }
            }
            else
            {
                if (MP.instance.isSoundRec)
                {
                    isMove = true;
                    isStart = true;

                    CreateManager.instance.isUp = true;
                    ScreenManage(0);
                }
            }
        }
    }

    void EndGame()
    {
        isEnd = true;
        Destroy(player);
    }




    void ScreenManage(float givenVal)
    {

        float weight = 1;

        if (givenVal == 0)
        {
            float sum = MP.instance.sum;

            if (sum > 3000 && sum < 4000) weight += 1;
            else if (sum > 4000 && sum < 5000) weight += 2;
            else if (sum > 5000 && sum < 6000) weight += 3;
            else if (sum > 6000 && sum < 7000) weight += 6;
            else if (sum > 7000 && sum < 8000) weight += 9;
            else if (sum > 8000 && sum < 9000) weight += 12;
            else if (sum > 9000) weight += 15;
            else weight += 0;
        }
        else
        {
            weight = givenVal;
        }

        CreateManager.instance.weight = weight;

        if (Camera.main.WorldToViewportPoint(player.transform.position).y < up_limit_y)
        {

            moveY = up_speed * Time.deltaTime * weight;
            player.transform.Translate(0, moveY, 0);

        }
        else
        {
            if (world_height >= 1800 && world_height <= 1900)
            {

                if (buffer_offset < 10f)
                {
                    newOffsetY = back2.mainTextureOffset.y + back_offset_speed * Time.deltaTime * weight;
                    newOffset = new Vector2(0, newOffsetY);
                    back2.mainTextureOffset = newOffset;
                    buffer_offset += back_offset_speed * Time.deltaTime * weight;
                }
                else
                {
                    world_height += 100f;
                    buffer_offset = 0f;
                }



            }
            else if (world_height >= 4700f && world_height <= 4800f)
            {
                if (buffer_offset < 20f)
                {
                    newOffsetY = back4.mainTextureOffset.y + back_offset_speed * Time.deltaTime * weight;
                    newOffset = new Vector2(0, newOffsetY);
                    back4.mainTextureOffset = newOffset;
                    buffer_offset += back_offset_speed * Time.deltaTime * weight;
                }
                else
                {
                    world_height += 100f;
                    buffer_offset = 0f;
                }
            }
            else if (world_height >= 6100f && world_height <= 6200f)
            {
                newOffsetY = back5.mainTextureOffset.y + back_offset_speed * Time.deltaTime * weight;
                newOffset = new Vector2(0, newOffsetY);
                back5.mainTextureOffset = newOffset;
            }
            else
            {
                moveY = back_speed * Time.deltaTime * weight;
                background1.transform.Translate(0, moveY, 0);
                background2.transform.Translate(0, moveY, 0);
                background3.transform.Translate(0, moveY, 0);
                background4.transform.Translate(0, moveY, 0);
                background5.transform.Translate(0, moveY, 0);
                world_height -= moveY;

            }

        }

        height += 1 * Time.deltaTime * weight;
        score_text.text = "Score: " + Mathf.RoundToInt(height);

    }

}
