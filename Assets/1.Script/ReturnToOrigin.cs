using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ReturnToOrigin : MonoBehaviour
{
    [SerializeField] private Pose originPose;

    private XRGrabInteractable grabinteractable;

    private void Awake()
    {
        grabinteractable = GetComponent<XRGrabInteractable>();
        originPose.position = transform.position;
        originPose.rotation = transform.rotation;
    }

    private void OnEnable()
    {
        grabinteractable.selectExited.AddListener(LaserGunReleasedCoroutine);
    }
    private void OnDisable()
    {
        grabinteractable.selectExited.RemoveListener(LaserGunReleasedCoroutine);
    }
    private void LaserGunReleasedCoroutine(SelectExitEventArgs arg0)
    {
        StartCoroutine(LaserGunReleased());
    }

    private IEnumerator LaserGunReleased()
    {
        yield return new WaitForSeconds(5);

        transform.position = originPose.position;
        transform.rotation = originPose.rotation;
    }
}
