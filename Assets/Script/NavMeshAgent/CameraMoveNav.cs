using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 用到导航组建的时候，需要引用UnityEngine.AI
using UnityEngine.AI;
public class CameraMoveNav : MonoSingleton<CameraMoveNav>
{
    #region 定义的字段属性
    // 定义导航组件
    private NavMeshAgent m_Nav;
    private Boolean isRun = false;
    // 用字典储存摄像机要去的点
    public Dictionary<string, Vector3> targetGameObjectPosition = new Dictionary<string, Vector3>();
    // 定义跟随的物体
    public Transform[] targetPosition;
    //声明vr相机
    public GameObject VRCamera;
    #endregion
    #region Unity回调方法
    // 重写继承父类的单例初始化方法
    protected override void Awake()
    {
        base.Awake();
        // 初始化导航组件
        m_Nav = this.GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // 添加去01的位置
        //targetGameObjectPosition.Add("01", targetPosition[0].position);
        // 添加去02的位置
        //targetGameObjectPosition.Add("02", targetPosition[1].position);
        // 添加去03的位置
        //targetGameObjectPosition.Add("03", targetPosition[2].position);
        // 添加去04的位置
        //targetGameObjectPosition.Add("04", targetPosition[3].position);
        // 添加去meatB1G4的位置
        targetGameObjectPosition.Add("meatB1G4", targetPosition[0].position);
        // 添加去meatB1G5的位置
        targetGameObjectPosition.Add("meatB1G5", targetPosition[1].position);
        // 添加去meatS1G3的位置
        targetGameObjectPosition.Add("meatS1G3", targetPosition[2].position);
        // 添加去meatS2G3的位置
        targetGameObjectPosition.Add("meatS2G3", targetPosition[3].position);
        // 添加去fishB1G3的位置
        targetGameObjectPosition.Add("fishB1G3", targetPosition[4].position);
        // 添加去fishS1G3的位置
        targetGameObjectPosition.Add("fishS1G3", targetPosition[5].position);
        // 添加去fishS2G3的位置
        targetGameObjectPosition.Add("fishS2G3", targetPosition[6].position);
        // 添加去milkS2G1的位置
        targetGameObjectPosition.Add("milkS2G1", targetPosition[7].position);
        // 添加去milkB1G4的位置
        targetGameObjectPosition.Add("milkB1G4", targetPosition[8].position);
        // 添加去pizzaB1G2的位置
        targetGameObjectPosition.Add("pizzaB1G2", targetPosition[9].position);
        // 添加去pizzaS1G2的位置
        targetGameObjectPosition.Add("pizzaS2G2", targetPosition[10].position);
        // 添加去drinkS4G1的位置
        targetGameObjectPosition.Add("drinkS4G1", targetPosition[11].position);
        // 添加去drinkS1G1的位置
        targetGameObjectPosition.Add("drinkS1G1", targetPosition[12].position);
        // 添加去drinkS1G2的位置
        targetGameObjectPosition.Add("drinkS1G2", targetPosition[13].position);
        // 添加去drinkS2G3的位置
        targetGameObjectPosition.Add("drinkS2G3", targetPosition[14].position);
        // 添加去snackS1G2的位置
        targetGameObjectPosition.Add("snackS1G2", targetPosition[15].position);
        // 添加去snackS1G4的位置
        targetGameObjectPosition.Add("snackS1G4", targetPosition[16].position);
        // 添加去snackS2G3的位置
        targetGameObjectPosition.Add("snackS2G3", targetPosition[17].position);
        // 添加去snackS1G5的位置
        targetGameObjectPosition.Add("snackS1G5", targetPosition[18].position);
        // 添加去snackS2G1的位置
        targetGameObjectPosition.Add("snackS2G1", targetPosition[19].position);
        // 添加去snackS2G5的位置
        targetGameObjectPosition.Add("snackS2G5", targetPosition[20].position);
        // 添加去snackS2G4的位置
        targetGameObjectPosition.Add("snackS2G4", targetPosition[21].position);
        // 添加去winkS1G3的位置
        targetGameObjectPosition.Add("winkS1G3", targetPosition[22].position);
        // 添加去entry的位置
        targetGameObjectPosition.Add("entry", targetPosition[23].position);
    }
    #endregion
    #region 方法
    // 设置导航终点的位置
    public void Move(Vector3 pos)
    {
        // 设置导航的目标点为pos
        m_Nav.SetDestination(pos);
        //MoveTo.IsMove = false;
        isRun = true;
    }
    // 清除导航原有的路径，清除目标点
    public void Clean()
    {
        m_Nav.ResetPath();
        isRun = false;
    }
    // 移动到客厅的方法
    public void MoveLiving()
    {
        m_Nav.destination = targetGameObjectPosition["meatB1G4"];

    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        //GUI左上角实时显示坐标

        if (isRun)
        {
            //Debug.Log(Vector3.Distance(m_Nav.destination, m_Nav.nextPosition));
            if (Vector3.Distance(m_Nav.destination, m_Nav.nextPosition) < 0.1f)
            {
                Invoke("Clean", 1.2f);
                //MoveTo.IsMove = true;
                //UGUI
                OnGUI();
            }
            //校准相机与Cube的角度
            VRCamera.transform.eulerAngles = Vector3.Lerp(VRCamera.transform.eulerAngles, gameObject.transform.eulerAngles, 1.0f);
        }   
    }
    //var textureToDisplay:Texture2D;
    void OnGUI()
    {   
        GUI.Label(new Rect(10,10, 120, 20), Math.Round(m_Nav.nextPosition.x,2)+", "+ Math.Round(m_Nav.nextPosition.y,2) + ", "+ Math.Round(m_Nav.nextPosition.z,2));
        //GUI.Label(Rect(10, 40, textureToDisplay.width, textureToDisplay.height), textureToDisplay);
        if (isRun) {
            GUIStyle fontStyle = new GUIStyle();
            fontStyle.normal.background = null;    //设置背景填充
            fontStyle.normal.textColor = new Color(255, 255, 255);   //设置字体颜色
            fontStyle.fontSize = 40;       //字体大小
            GUI.Label(new Rect(170, 200,100, 100),"导航中。。。",fontStyle);

        }
    }
}
