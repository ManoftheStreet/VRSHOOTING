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

    [Header("Á¡¼ö")]
    [SerializeField] private TextMeshProUGUI scoreText;

    private int playerScore;
    private void Update()
    {
        AdjustTimer();
    }

    private void AdjustTimer()
    {
        timerImage.fillAmount = sliderCurrentFill - (Time.deltaTime/gameTime);

        sliderCurrentFill = timerImage.fillAmount;
    }

    public void UpdateplayerScore(int astroidHitPoints)
    {
        playerScore += astroidHitPoints;
        scoreText.text = playerScore.ToString();
    }

}
