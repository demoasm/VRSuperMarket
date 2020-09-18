using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanItem : MonoBehaviour
{
    // 声明鼠标水平偏移量
    float hor;
    // 声明鼠标竖直偏移量
    float ver;
    // 旋转速度
    public float roSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 初始化水平偏移量
        hor = Input.GetAxis("Mouse X");
        // 初始化竖直偏移量
        ver = Input.GetAxis("Mouse Y");
        if (hor != 0 || ver != 0)
        {
            // 让物体跟着旋转
            transform.Rotate
                (Vector3.up * hor * Time.deltaTime * roSpeed, Space.World);
            transform.Rotate
                (-Vector3.right * ver * Time.deltaTime * roSpeed);
        }
    }
}
