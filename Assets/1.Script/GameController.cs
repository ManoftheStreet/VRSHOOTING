using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float gameTime;

    private float sliderCurrentFill = 1f;

    [Header("점수")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("게임오버")]
    [SerializeField] private GameObject gameoverScreen;

    [Header("최고점수")]
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int highScore;

    [Header("오디오")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    private int playerScore;
    public enum GameState
    {
        Waiting,
        Playing,
        GameOver
    }

    public static GameState state;

    private void Awake()
    {
        state = GameState.Waiting;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreText.text = PlayerPrefs.GetInt("HigScore").ToString();
        }
    }


    private void Update()
    {
        if(state == GameState.Playing)
        {
            AdjustTimer();
        }  
    }

    private void AdjustTimer()
    {
        timerImage.fillAmount = sliderCurrentFill - (Time.deltaTime/gameTime);

        sliderCurrentFill = timerImage.fillAmount;

        if(sliderCurrentFill <= 0f)
        {
            GameOver();
        }
    }
    
    public void UpdateplayerScore(int astroidHitPoints)
    {
        if(state != GameState.Playing)
        {
            return;
        }

        playerScore += astroidHitPoints;
        scoreText.text = playerScore.ToString();
    }

    public void StartGame()
    {
        state = GameState.Playing;
        //시작음악 교체
        PlayGameAudio(audioClips[1], true);
    }
    private void GameOver()
    {
        //게임상태 게임오버로 변경
        state = GameState.GameOver;
        gameoverScreen.SetActive(true);

        //최고점수 확인
        if(playerScore> PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScoreText.text = playerScore.ToString();
        }
        //게임오버 음악교체
        PlayGameAudio(audioClips[2], false);


    }
    public void ResetGame()
    {
        state = GameState.Waiting;
        //타이머 및 점수 리셋
        sliderCurrentFill = 1f;
        timerImage.fillAmount = 1f;
        playerScore = 0;
        scoreText.text = "0";

        //인트로음악 교체
        PlayGameAudio(audioClips[0], true);
    }

    private void PlayGameAudio(AudioClip clipToPlay, bool shouldLoop)
    {
        audioSource.clip = clipToPlay;
        audioSource.loop = shouldLoop;
        audioSource.Play();
    }
}
