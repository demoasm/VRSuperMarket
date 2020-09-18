using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightControll : MonoBehaviour
{
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

    }

    public void open()
    {
        if (state == State.FoldOff)
        {
            anim.Play("rightOpen1");
            state = State.FoldOn;
        }
    }

    public void close()
    {
        if (state == State.FoldOn)
        {
            anim.Play("rightClose");
            state = State.FoldOff;
        }
    }
}
