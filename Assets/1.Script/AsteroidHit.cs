using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class AsteroidHit : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;
    [SerializeField] private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }
    public void AsteroidDestroyed()
    {
        Instantiate(asteroidExplosion, transform.position,transform.rotation);

        //�������
        float distanceFromPlayer = Vector3.Distance(transform.position, Vector3.zero);
        int bonusPoint = (int)distanceFromPlayer;

        int asteroindScore = 10 * bonusPoint;
        //���� �ѱ��
        gameController.UpdateplayerScore(asteroindScore);

        Destroy(this.gameObject);
    }
}
