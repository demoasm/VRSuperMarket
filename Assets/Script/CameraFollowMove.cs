using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMove : MonoBehaviour
{
    // Start is called before the first frame update
    #region 定义的字段属性变量

    // 定义需要跟随的目标位置
    public Transform target;

    #endregion

    #region Unity回调方法
    private Vector3 offset = new Vector3(0f, 1.5f, 0f);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 让摄像机实时利用插值到达目标位置
        transform.position = Vector3.Lerp
                (transform.position, target.position + offset, Time.time);
    }
    #endregion
}
