using System.Collections;
using UnityEngine;
using UnityEngine.UI;
/*
public class ScoreManager : MonoBehaviour {
    public static ScoreManager instance;
    private const string HIGHT_SOCRE = "Hight Score";

    [SerializeField]
    private Text scoreText;
    void Awake()
    {
        MakeInstance();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void InscreasementScore(int score)
    {
        scoreText.text = "" + score;
    }
    public void SetHightScore(int score)
    {
        PlayerPrefs.SetInt(HIGHT_SOCRE, score);
    }
    public int GetHightScore()
    {
        return PlayerPrefs.GetInt(HIGHT_SOCRE);
    }

}
*/