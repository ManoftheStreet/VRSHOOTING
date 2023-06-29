using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("운석 소환존 크기")]
    public Vector3 spawnerSize;

    [Header("운석 소환 간격")]
    public float spawnRate = 1f;

    [Header("운석 종류")]
    [SerializeField]private GameObject asteroidModel;

    private float spawnTimer = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,1,0,0.5f);
        Gizmos.DrawCube(transform.position, spawnerSize);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnRate)
        {
            spawnTimer = 0;
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        //랜덤위치를 가져옴
        Vector3 spawnPoint = transform.position + new Vector3(UnityEngine.Random.Range(-spawnerSize.x / 2, spawnerSize.x / 2),
                                                              UnityEngine.Random.Range(-spawnerSize.y / 2, spawnerSize.y / 2),
                                                              UnityEngine.Random.Range(-spawnerSize.z / 2, spawnerSize.z / 2));
        GameObject asteroid = Instantiate(asteroidModel,spawnPoint,transform.rotation);

        asteroid.transform.SetParent(this.transform);
    }
}
