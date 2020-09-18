using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move4 : MonoSingleton<Move4>
{
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
    public void ControllDoor()
    {
        // 摄像机3秒后移动到客厅内
        Invoke("MoveIn", 3f);
    }
    void MoveIn()
    {
        // 先将之前的路径清除
        CameraMoveNav.instance.Clean();
        // 摄像机移动
        CameraMoveNav.instance.Move(CameraMoveNav.instance.targetGameObjectPosition["03"]);
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
