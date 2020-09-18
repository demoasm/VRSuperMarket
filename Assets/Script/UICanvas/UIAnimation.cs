using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 使用到UI的话，要引用UnityEngine.UI
using UnityEngine.UI;
/// <summary>
/// 记录缩放的状态
/// </summary>
public enum State
{
    On,
    Off
}
/// <summary>
/// 实现UI收缩的动画
/// </summary>
public class UIAnimation : MonoSingleton<UIAnimation>
{
        #region 字段
        /// <summary>
        /// 物体自身动画组件
        /// </summary>
        private Animation anim;

        /// <summary>
        /// 控制缩放的按钮图片
        /// </summary>
        public Image image;

        /// <summary>
        /// 记录当前的缩放状态
        /// </summary>
        public State state = State.On;
        #endregion

        #region Unity回调
        /// <summary>
        /// 重写继承父类单例
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
        }

        /// <summary>
        /// 初始化动画组件
        /// </summary>
        void Start()
        {
            anim = GetComponent<Animation>();
        }
        #endregion
        #region 方法
        /// <summary>
        /// UI面板缩放动画
        /// </summary>
        public void FoldOff()
        {
            // 如果目前UI面板收缩状态是展开的
            if (state == State.On)
            {
                // 播放UI面板折叠动画
                anim.Play("FoldOffAni");
                // 等待1.2秒将自身消失
                StartCoroutine(IsShowImage(1.2f, false));
                // 改变目前的收缩状态
                state = State.Off;
            }

        }
        /// <summary>
        /// UI动画展开的动画
        /// </summary>
        public void FoldOn()
        {
            // 如果状态是关闭的
            if (state == State.Off)
            {
                // 先将自身显示出来
                image.gameObject.SetActive(true);
                // 播放UI面板展开动画
                anim.Play("FoldOnAni");
                // 改变收缩状态为展开状态
                state = State.On;
            }

        }
        /// <summary>
        /// 当UI面板缩放动画播放结束后，将按钮图片消失
        /// </summary>
        /// <param name="time">等待的时间</param>
        /// <param name="isShow">显示状态</param>
        /// <returns></returns>
        IEnumerator IsShowImage(float time, bool isShow)
        {
            yield return new WaitForSeconds(time);
            // 自身显示关闭的方法
            image.gameObject.SetActive(isShow);
        }

        #endregion

        // Update is called once per frame
        void Update()
    {
        
    }
}
