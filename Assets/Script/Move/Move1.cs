using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoSingleton<Move1>
{
    private string posName;
    #region Unity回调方法
    /// <summary>
    /// 实现继承父类的单例方法
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
    }
    #endregion
    // 摄像机移动的方法
    public void ControllDoor(string posname)
    {
        // 摄像机3秒后移动到客厅内
        //UGUI



        posName = posname;
        Invoke("MoveIn", 1f);
    }
    void MoveIn()
    {
        // 先将之前的路径清除
        CameraMoveNav.instance.Clean();
        // 摄像机移动
        CameraMoveNav.instance.Move(CameraMoveNav.instance.targetGameObjectPosition[posName]);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
