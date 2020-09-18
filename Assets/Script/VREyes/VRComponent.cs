using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Collider))]
public class VRComponent : MonoBehaviour
{
    #region 变量
    /// <summary>
    /// 交互需要等待的时间
    /// </summary>
    public float waitingTime = 1.5f;

    /// <summary>
    /// 在Inspector面板中隐藏
    /// 是否等待过
    /// </summary>
    [HideInInspector]
    public bool isWaitted = false;

    /// <summary>
    /// 门的动画播放的时间
    /// </summary>
    public float time = 3.5f;

    /// <summary>
    /// 创建单例
    /// </summary>
    public static VRComponent instance;
    public bool isBind = false;
    #endregion
    #region 方法

    private void Awake()
    {
        instance = this;
    }
    /// <summary>
    /// 射线检测之后响应的方法
    /// </summary>
    /// <param name="name">射线检测到的物体名字</param>
    /// <param name="trans">射线检测到的物体的Transform</param>
    public void ResponEvent(string name, Transform trans)
    {
        switch (name)
        {
            /*
            
            */
            case "PREF_atm_01 (1)":
                {
                    // 显示购物导航UI面板
                    //UICanvasShow.instance.IsShow();
                    NavUICanvasShow.instance.IsShow();
                    break;
                }
            case "FoldImage":
                {
                    // 控制动画收缩
                    UIAnimation.instance.FoldOff();
                    break;
                }
            case "drinkS4G1":
            case "drinkS1G1":
            case "drinkS1G2":
            case "drinkS2G3":
            case "snacksS1G2":
            case "snacksS1G4":
            case "snacksS2G3":
            case "snacksS1G5":
            case "snacksS2G1":
            case "snacksS2G5":
            case "snacksS2G4":
            case "wineS1G3":
            case "meatB1G4":
            case "meatB1G5":
            case "meatS1G3":
            case "meatS2G3":
            case "fishB1G3":
            case "fishS1G3":
            case "fishS2G3":
            case "milkS2G1":
            case "milkB1G4":
            case "pizzaB1G2":
            case "pizzaS2G2":
                {
                    // 客厅的门的控制
                    Move1.instance.ControllDoor(name);
                    break;
                }
            case "Exit":
                {
                    LightAlarm.instance.OpenAlarmLight();
                    break;
                }
            case "drink":
            case "snacks":
            case "wine":
            case "meat":
            case "fish":
            case "milk":
            case "pizza":
                {
                    NavUIContul.instance.showUI(name);
                    break;
                }
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
