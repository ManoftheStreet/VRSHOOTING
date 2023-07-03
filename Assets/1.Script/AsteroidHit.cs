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

        //�������
        if(GameController.state == GameController.GameState.Playing)
        {
            float distanceFromPlayer = Vector3.Distance(transform.position, Vector3.zero);
            int bonusPoint = (int)distanceFromPlayer;

            int asteroidScore = 10 * bonusPoint;

            //�˾�ĵ���� ����� ���� ����
            popupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = asteroidScore.ToString();



            GameObject asteroidPopup = Instantiate(popupCanvas, transform.position, Quaternion.identity);

            //�˾�ĵ���� ũ�� ����
            asteroidPopup.transform.localScale = new Vector3(transform.localScale.x * (distanceFromPlayer / 10),
                                                             transform.localScale.y * (distanceFromPlayer / 10),
                                                             transform.localScale.z * (distanceFromPlayer / 10));



            //���� �ѱ��
            gameController.UpdateplayerScore(asteroidScore);
        }
        

        Destroy(this.gameObject);
    }
}
