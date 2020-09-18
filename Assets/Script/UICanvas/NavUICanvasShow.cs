using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavUICanvasShow : MonoSingleton<NavUICanvasShow>
{
    protected override void Awake()
    {
        base.Awake();
        gameObject.SetActive(false);
    }
    // 控制开启关闭的方法
    public void IsShow()
    {
        // 如果自身不显示
        if (gameObject.activeSelf == false)
        {
            // 让面板显示
            gameObject.SetActive(true);
        }
        // 如果自身显示
        else if (gameObject.activeSelf == true)
        {
            // 播放UI面板缩放动画
            UIAnimation.instance.FoldOn();
        }

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
