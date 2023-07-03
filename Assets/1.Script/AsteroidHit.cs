using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using TMPro;

public class AsteroidHit : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;
    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject popupCanvas;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }
    public void AsteroidDestroyed()
    {
        Instantiate(asteroidExplosion, transform.position,transform.rotation);

        //점수계산
        if(GameController.state == GameController.GameState.Playing)
        {
            float distanceFromPlayer = Vector3.Distance(transform.position, Vector3.zero);
            int bonusPoint = (int)distanceFromPlayer;

            int asteroidScore = 10 * bonusPoint;

            //팝업캔버스 만들고 문자 설정
            popupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = asteroidScore.ToString();



            GameObject asteroidPopup = Instantiate(popupCanvas, transform.position, Quaternion.identity);

            //팝업캔버스 크기 설정
            asteroidPopup.transform.localScale = new Vector3(transform.localScale.x * (distanceFromPlayer / 10),
                                                             transform.localScale.y * (distanceFromPlayer / 10),
                                                             transform.localScale.z * (distanceFromPlayer / 10));



            //점수 넘기기
            gameController.UpdateplayerScore(asteroidScore);
        }
        

        Destroy(this.gameObject);
    }
}
