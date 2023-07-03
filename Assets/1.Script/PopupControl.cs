using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupControl : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        //팝업캔버스의 회전 설정
        transform.LookAt(Camera.main.transform);


        //그리고 지움

        Destroy(gameObject,3f);
    }
}
