using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioNav : MonoSingleton<AudioNav>
{
    private System.Random ra = new System.Random();
    public Boolean StartNavgate(string word) {
        Double r = ra.NextDouble();
        if (word.IndexOf("肉") >= 0)
        {
            //肉有四个导航点
            if (0 <= r * 4 && r * 4 < 1)
                Move1.instance.ControllDoor("meatB1G4");
            else if (1 <= r * 4 && r * 4 < 2)
                Move1.instance.ControllDoor("meatB1G5");
            else if (2 <= r * 4 && r * 4 < 3)
                Move1.instance.ControllDoor("meatS1G3");
            else if (3 <= r * 4 && r * 4 <= 4)
                Move1.instance.ControllDoor("meatS2G3");
            return true;
        }
        else if ((word.IndexOf("饮料") >= 0 )|| (word.IndexOf("饮品") >= 0))
        {
            //饮品有4个导航点
            if (0 <= r * 4 && r * 4 < 1)
                Move1.instance.ControllDoor("drinkS4G1");
            else if (1 <= r * 4 && r * 4 < 2)
                Move1.instance.ControllDoor("drinkS1G1");
            else if (2 <= r * 4 && r * 4 < 3)
                Move1.instance.ControllDoor("drinkS1G2");
            else if (3 <= r * 4 && r * 4 <= 4)
                Move1.instance.ControllDoor("drinkS2G3");
            return true;
        }
        else if (word.IndexOf("酒") >= 0)
        {
            //酒有一个导航点
            Move1.instance.ControllDoor("wineS1G3");
            return true;
        }
        else if (word.IndexOf("零食") >= 0)
        {
            //零食有7个导航点
            if (0 <= r * 7 && r * 7 < 1)
                Move1.instance.ControllDoor("snacksS1G2");
            if (1 <= r * 7 && r * 7 < 2)
                Move1.instance.ControllDoor("snacksS1G4");
            if (2 <= r * 7 && r * 7 < 3)
                Move1.instance.ControllDoor("snacksS2G3");
            if (3 <= r * 7 && r * 7 < 4)
                Move1.instance.ControllDoor("snacksS1G5");
            if (4 <= r * 7 && r * 7 < 5)
                Move1.instance.ControllDoor("snacksS2G1");
            if (5 <= r * 7 && r * 7 < 6)
                Move1.instance.ControllDoor("snacksS2G5");
            if (6 <= r * 7 && r * 7 <= 7)
                Move1.instance.ControllDoor("snacksS2G4");
            return true;
        }
        else if (word.IndexOf("鱼") >= 0)
        {
            //鱼有三个导航点
            if (0 <= r * 3 && r * 3 < 1)
                Move1.instance.ControllDoor("fishB1G3");
            else if (1 <= r * 3 && r * 3 < 2)
                Move1.instance.ControllDoor("fishS1G3");
            else if (2 <= r * 3 && r * 3 <= 3)
                Move1.instance.ControllDoor("fishS2G3");
            return true;
        }
        else if (word.IndexOf("奶") >= 0)
        {
            //奶有两个导航点
            if (0 <= r * 2 && r * 2 < 1)
                Move1.instance.ControllDoor("milkS2G1");
            else if (1 <= r * 2 && r * 2 <= 2)
                Move1.instance.ControllDoor("milkB1G4");
            return true;
        }
        else if (word.IndexOf("披萨") >= 0) {
            //pizza有两个导航点
            if (0 <= r * 2 && r * 2 < 1)
                Move1.instance.ControllDoor("pizzaB1G2");
            else if (1 <= r * 2 && r * 2 <= 2)
                Move1.instance.ControllDoor("pizzaS2G2");
            return true;
        }
        return false;
    }
    #region Unity回调方法
    /// <summary>
    /// 实现继承父类的单例方法
    /// </summary>
    protected override void Awake()
    {
        base.Awake();
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
