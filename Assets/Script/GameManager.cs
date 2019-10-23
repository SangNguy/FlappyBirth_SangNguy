using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; 
    private const string HIGH_SCORE = "High Score";

    void Awake()
    {
        _MakeSingleInstance();
        IsGameStartedForTheFirstTime();
    }
    //reset diem high score neu nguoi dung da tai game ve truoc do
    void IsGameStartedForTheFirstTime()
    {
        if (!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0); // reset diem highscore lai bang 0
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0); // ham bool cco gia tri mac dinh la false ~0, true ~1
        }
    }

    // GameObject nay se duoc goi tu scene mainmenu den scene playgame, (lay diem endscore va diem bestscore)
    void _MakeSingleInstance()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //khong huy gameobject nay de giu diem tu scene playgame neu co tro ve main menu
        }
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE); //get diem cho best score text
    }
}
