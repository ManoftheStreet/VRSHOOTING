using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private Animator laserAnim;
    [SerializeField] private AudioClip laserSFX;
    [SerializeField] private Transform raycastOrigin;
    private AudioSource laserAudioSource;

    private RaycastHit hit;
    private void Awake()
    {
        if(GetComponent<AudioSource>() != null)
        {
            laserAudioSource = GetComponent<AudioSource>();
        }
    }

    public void LaserGunFired()
    {
        //�ִϸ��̼�
        laserAnim.SetTrigger("Fire");
        //�߻� ȿ��
        laserAudioSource.PlayOneShot(laserSFX);
        //���� ĳ��Ʈ
        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.forward,out hit, 800))
        {
            if(hit.transform.GetComponent<AsteroidHit>() != null)
            {
                hit.transform.GetComponent<AsteroidHit>().AsteroidDestroyed();
            }
            
        }
    }
}
