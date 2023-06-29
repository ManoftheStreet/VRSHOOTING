using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [Header("� �ӵ� ����")]
    public float maxSpeed;
    public float minSpeed;

    [Header("� ȸ�� ����")]
    public float rotationalSpeedMin;
    public float rotationalSpeedMax;

    private float rotationalSpeed;
    private float xAngle, yAngle, zAngle;

    public Vector3 movementDirection;

    private float asteroidSpeed;

    private void Start()
    {
        //���� �ӵ�
        asteroidSpeed = Random.Range(minSpeed, maxSpeed);

        //���� ȸ��
        xAngle = Random.Range(0,360);
        yAngle = Random.Range(0, 360);
        zAngle = Random.Range(0, 360);

        transform.Rotate(xAngle, yAngle, zAngle);

        rotationalSpeed = Random.Range(rotationalSpeedMin, rotationalSpeedMax);
    }

    private void Update()
    {
        transform.Translate(movementDirection * Time.deltaTime * asteroidSpeed,Space.World);
        transform.Rotate(Vector2.up * Time.deltaTime * rotationalSpeed);
    }

}
