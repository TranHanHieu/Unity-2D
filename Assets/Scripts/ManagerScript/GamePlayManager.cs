using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour {
    public static GamePlayManager instance;
    [SerializeField]
    private Button instrucsion, resumseButton;
    [SerializeField]
    private Text gameOver, endScoreText, hightScoreText;
    [SerializeField]
    private GameObject pausePanel,scoreText;
    [SerializeField]
    private Text scoreText1;
    private const string HIGHT_SOCRE = "Hight Score";
    public void InscreasementScore(int score)
    {
        scoreText1.text = "" + score;
    }
    public void SetHightScore(int score)
    {
        PlayerPrefs.SetInt(HIGHT_SOCRE, score);
    }
    public int GetHightScore()
    {
        return PlayerPrefs.GetInt(HIGHT_SOCRE);
    }
    void Awake()
    {
        MakeInstance();
        //resumseButton = GameObject.Find("Resumse Game Button").GetComponent<Button>();
        //instrucsion = GameObject.Find("Instruction").GetComponent<Button>();
        Time.timeScale = 0f;
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void PauseGameButton()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        resumseButton.onClick.RemoveAllListeners();
        resumseButton.onClick.AddListener(() => ResumseGameButton());
    }
    public void ResumseGameButton()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Flappy Brid");
        //Application.LoadScene;
        //Application.DontDestroyOnLoad("Flappy Brid");
        //Application.LoadLevel("");
    }
	public void BridDiedShowPanel(int score)
    {

        //Time.timeScale = 0f;
        pausePanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
        endScoreText.text = ""+ score;
        int temp = GetHightScore();
        if (score > temp)
        {
            SetHightScore(score);
        }
        hightScoreText.text = "" + GetHightScore();
        resumseButton.onClick.RemoveAllListeners();
        resumseButton.onClick.AddListener(() => RestartButton());
    }
    public void InstrucsionButton()
    {
        Time.timeScale = 1f;
        instrucsion.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
    public void MainMenuButton()
    {
        //Application.LoadLevel("MainMenu");
        SceneManager.LoadScene("MainMenu");
    }
}
