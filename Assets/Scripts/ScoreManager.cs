using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text[] scores;
    public Text curText;
    int cur_score = 0;
    int[] rank = new int[5];
    // Start is called before the first frame update
    void Start()
    {

        cur_score = GameAudio.instance.score;

        curText.text = cur_score.ToString();
        for (int i = 0; i < 5; i++)
        {
            rank[i] = PlayerPrefs.GetInt((i + 1).ToString(), 0);
            scores[i].text = rank[i] + " km";
        }
        int val = 6;
        for (int i = 4; i >= 0; i--)
        {
            if (cur_score > rank[i]) val = i + 1;
        }
        if (val != 6)
        {
            PlayerPrefs.SetInt(val.ToString(), cur_score);
            scores[val - 1].text = cur_score + " km";
            scores[val - 1].color = Color.red;
            for (int i = val + 1; i <= 5; i++)
            {
                PlayerPrefs.SetInt(i.ToString(), rank[i - 2]);
                scores[i - 1].text = rank[i - 2] + " km";
            }
        }
    }




}
