using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// 用来实现交互，用射线检测
/// 步骤：
/// 1.从当前位置向前发一条射线，无限远；
/// 2.射线碰到物体后，进行判断，判断选择中的物体是否被触发过
/// 3.根据射线的名字判断是什么物体
/// 4.将射线检测的信息传递出去
public class VRResponse : MonoBehaviour
{
    #region 变量，字段或者属性
    // 交互的时候发生变化的Image
    private Image waitingImage;
    // 射线是否检测过
    private bool isHovered = false;
    // 射线检测到的物体的信息
    private RaycastHit hitInfo;
    // 射线检测到的物体的名字
    private string hitInfoName;
    // 射线检测到的物体的Transform
    private Transform hitInfoTrans;
    // UI选中物体的时候所等待的时间
    private float enterTime;
    // 选择中的物体
    private VRComponent selectComponent;
    #endregion
    #region Unity回调方法

    // Start is called before the first frame update
    void Start()
    {
        // 初始化Image
        waitingImage = transform.Find
            ("UIWaiting/Waiting").GetComponent<Image>();
        // 并且填充为0
        waitingImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 实时调用射线检测
        CastRay();
        // 如果被检测过，直接返回
        if (isHovered)
        {
            return;
        }
        // 如果没有被检测过，首先让Image中的外圈图片隐藏
        waitingImage.gameObject.SetActive(false);
        // 检测到的物体不为空的话
        if (selectComponent != null)
        {
            // 记录从射线检测到目前位置的时间
            float selectTime = Time.time - enterTime;
            if (selectTime <= selectComponent.waitingTime)
            {
                // 先将外圈图片显示出来
                waitingImage.gameObject.SetActive(true);
                waitingImage.fillAmount =
                     selectTime / selectComponent.waitingTime;
            }
            else
            {
                // 如果时间大于selectComponent.waitingTime
                // 开始执行所选中对应的方法
                isHovered = true;
                selectComponent.ResponEvent(hitInfoName, hitInfoTrans);
            }
        }
    }
    #endregion
    #region 方法
    // 射线检测
    void CastRay()
    {
        // 射线目前检测到的物体为空
        VRComponent currentComponent = null;

        // 定义射线发射的方向
        Vector3 rayDirection = transform.forward;

        // 如果碰到物体，返回碰撞信息
        if (Physics.Raycast(transform.position, rayDirection, out hitInfo, float.MaxValue))
        {
            currentComponent = hitInfo.collider.GetComponent<VRComponent>();
            // 返回射线检测到的物体的名字和Transform
            hitInfoName = hitInfo.collider.name;
            hitInfoTrans = hitInfo.collider.transform;
        }
        // 如果选择中的物体不是当前检测到的物体
        if (currentComponent != selectComponent)
        {
            // 说明没有被检测过
            isHovered = false;
            selectComponent = currentComponent;
            // 记录当前时间
            enterTime = Time.time;
        }
    }
    #endregion
}
