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

    [Header("����")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("���ӿ���")]
    [SerializeField] private GameObject gameoverScreen;

    [Header("�ְ�����")]
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int highScore;

    [Header("�����")]
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
        //�������� ��ü
        PlayGameAudio(audioClips[1], true);
    }
    private void GameOver()
    {
        //���ӻ��� ���ӿ����� ����
        state = GameState.GameOver;
        gameoverScreen.SetActive(true);

        //�ְ����� Ȯ��
        if(playerScore> PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            highScoreText.text = playerScore.ToString();
        }
        //���ӿ��� ���Ǳ�ü
        PlayGameAudio(audioClips[2], false);


    }
    public void ResetGame()
    {
        state = GameState.Waiting;
        //Ÿ�̸� �� ���� ����
        sliderCurrentFill = 1f;
        timerImage.fillAmount = 1f;
        playerScore = 0;
        scoreText.text = "0";

        //��Ʈ������ ��ü
        PlayGameAudio(audioClips[0], true);
    }

    private void PlayGameAudio(AudioClip clipToPlay, bool shouldLoop)
    {
        audioSource.clip = clipToPlay;
        audioSource.loop = shouldLoop;
        audioSource.Play();
    }
}
