using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingUIControl : MonoBehaviour
{
    // 声明Animation组件
    public Animation anim;

    public enum State
    {
        FoldOff,
        FoldOn
    }
    public State state = State.FoldOff;
    private void Start()
    {
        // 初始化Animation组件
        anim = transform.GetComponent<Animation>();
        anim.Play("shut");

    }

    public void open()
    {
        if (state == State.FoldOff)
        {
            anim.Play("FoldOnAni");
            state = State.FoldOn;
        }
    }

    public void close()
    {
        if (state == State.FoldOn)
        {
            anim.Play("FoldOffAni");
            state = State.FoldOff;
        }
    }
}
