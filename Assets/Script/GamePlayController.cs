using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    [SerializeField]
    private Button instructionButton;

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;
    [SerializeField]
    private GameObject gameOverPanel, pausePanel;

    private void Awake()
    {
        Time.timeScale = 0; 
        _MakeInstance();


    }
    void _MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void _InstructionButton()
    {
        Time.timeScale = 1;
        //An button instruction dau scene 
        instructionButton.gameObject.SetActive(false);

    }
    //hien thi score len text
    public void _SetScore(int score)
    {
        scoreText.text = "" + score;
    }
    public void _BirdDiedShowPanel(int score)
    {
        gameOverPanel.SetActive(true); //hien thi panel died

        endScoreText.text = "" + score; 
        // neu diem endscore> betscore thi lay luon lam diem best
        if(score > GameManager.instance.GetHighScore())
        {
            GameManager.instance.SetHighScore(score);

        }
        bestScoreText.text = "" + GameManager.instance.GetHighScore();
    }

    public void _MenuButton()
    {
        Application.LoadLevel("MainMenu");
    }

    public void _RestartButton()
    {
        Application.LoadLevel("GamePlay");
        //Application.LoadLevel(Application.loadedLevel); ~~su dung neu muon load den man hinh hien tai
    }
    public void _PauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void _ResumeButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
