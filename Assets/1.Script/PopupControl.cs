using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupControl : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        //�˾�ĵ������ ȸ�� ����
        transform.LookAt(Camera.main.transform);


        //�׸��� ����

        Destroy(gameObject,3f);
    }
}
