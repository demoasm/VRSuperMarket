using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavUIContul : MonoSingleton<NavUIContul>
{
    public GameObject[] drinkText;
    public GameObject[] snacksText;
    public GameObject[] wineText;
    public GameObject[] meatText;
    public GameObject[] fishText;
    public GameObject[] milkText;
    public GameObject[] pizzaText;
    public GameObject[] navigateType;
    public float size;//标签展开时其他标签下降的步进
    private Dictionary<string, Boolean> isShow = new Dictionary<string, Boolean>();
    protected override void Awake()
    {
        base.Awake();
    }
    public void showUI(string Type) {
        switch (Type) {
            case "drink": 
                {
                    if (isShow["drink"])
                    {
                        //此时被折叠按钮处于显示状态，将按钮隐藏并调整其他按钮的位置
                        for (int i = 0; i < drinkText.Length; i++)
                        {
                            drinkText[i].SetActive(false);
                        }
                        isShow["drink"] = false;
                        /*此处填入调整按钮位置的代码*/
                        navigateType[1].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.6f, 0f);
                        navigateType[2].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.3f, 0f);
                        navigateType[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0f, 0f);
                        navigateType[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.3f, 0f);
                        navigateType[5].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.6f, 0f);
                        navigateType[6].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.9f, 0f);
                    }
                    else {
                        hiddenAll();
                        //此时被折叠按钮处于隐藏状态，将按钮显示并调整其他按钮位置
                        for (int i = 0; i < drinkText.Length; i++)
                        {
                            drinkText[i].SetActive(true);
                        }
                        isShow["drink"] = true;
                        /*此处填入调整按钮位置的代码*/
                        navigateType[1].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.6f - size * getdown(drinkText.Length), 0f);
                        navigateType[2].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.3f- size * getdown(drinkText.Length), 0f);
                        navigateType[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0f - size * getdown(drinkText.Length), 0f);
                        navigateType[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.3f - size * getdown(drinkText.Length), 0f);
                        navigateType[5].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.6f - size * getdown(drinkText.Length), 0f);
                        navigateType[6].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.9f - size * getdown(drinkText.Length), 0f);
                    }
                    break;
                }
            case "snacks":
                {
                    if (isShow["snacks"])
                    {
                        //此时被折叠按钮处于显示状态，将按钮隐藏并调整其他按钮的位置
                        for (int i = 0; i < snacksText.Length; i++)
                        {
                            snacksText[i].SetActive(false);
                        }
                        isShow["snakcs"] = false;
                        /*此处填入调整按钮位置的代码*/
                        navigateType[2].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.3f, 0f);
                        navigateType[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0f, 0f);
                        navigateType[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.3f, 0f);
                        navigateType[5].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.6f, 0f);
                        navigateType[6].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.9f, 0f);
                    }
                    else
                    {
                        hiddenAll();
                        //此时被折叠按钮处于隐藏状态，将按钮显示并调整其他按钮位置
                        for (int i = 0; i < snacksText.Length; i++)
                        {
                            snacksText[i].SetActive(true);
                        }
                        isShow["snacks"] = true;
                        /*此处填入调整按钮位置的代码*/
                        navigateType[1].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.6f, 0f);
                        navigateType[2].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.3f- size * getdown(snacksText.Length), 0f);
                        navigateType[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0f - size * getdown(snacksText.Length), 0f);
                        navigateType[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.3f - size * getdown(snacksText.Length), 0f);
                        navigateType[5].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.6f - size * getdown(snacksText.Length), 0f);
                        navigateType[6].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.9f - size * getdown(snacksText.Length), 0f);
                    }
                    break;
                }
            case "wine":
                {
                    if (isShow["wine"])
                    {
                        //此时被折叠按钮处于显示状态，将按钮隐藏并调整其他按钮的位置
                        for (int i = 0; i < wineText.Length; i++)
                        {
                            wineText[i].SetActive(false);
                        }
                        isShow["wine"] = false;
                        /*此处填入调整按钮位置的代码*/
                        navigateType[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0f, 0f);
                        navigateType[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.3f, 0f);
                        navigateType[5].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.6f, 0f);
                        navigateType[6].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.9f, 0f);
                    }
                    else
                    {
                        hiddenAll();
                        //此时被折叠按钮处于隐藏状态，将按钮显示并调整其他按钮位置
                        for (int i = 0; i < wineText.Length; i++)
                        {
                            wineText[i].SetActive(true);
                        }
                        isShow["wine"] = true;
                        /*此处填入调整按钮位置的代码*/
                        navigateType[1].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.6f, 0f);
                        navigateType[2].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.3f, 0f);
                        navigateType[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0f - size * getdown(wineText.Length), 0f);
                        navigateType[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.3f - size * getdown(wineText.Length), 0f);
                        navigateType[5].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.6f - size * getdown(wineText.Length), 0f);
                        navigateType[6].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.9f - size * getdown(wineText.Length), 0f);
                    }
                    break;
                }
            case "meat":
                {
                    if (isShow["meat"])
                    {
                        //此时被折叠按钮处于显示状态，将按钮隐藏并调整其他按钮的位置
                        for (int i = 0; i < meatText.Length; i++)
                        {
                            meatText[i].SetActive(false);
                        }
                        isShow["meat"] = false;
                        /*此处填入调整按钮位置的代码*/
                        //navigateType[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0f, 0f);
                        navigateType[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.3f, 0f);
                        navigateType[5].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.6f, 0f);
                        navigateType[6].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.9f, 0f);
                    }
                    else
                    {
                        hiddenAll();
                        //此时被折叠按钮处于隐藏状态，将按钮显示并调整其他按钮位置
                        for (int i = 0; i < meatText.Length; i++)
                        {
                            meatText[i].SetActive(true);
                        }
                        isShow["meat"] = true;
                        /*此处填入调整按钮位置的代码*/
                        navigateType[1].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.6f, 0f);
                        navigateType[2].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.3f, 0f);
                        navigateType[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0f, 0f);
                        navigateType[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.3f - size * getdown(meatText.Length), 0f);
                        navigateType[5].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.6f - size * getdown(meatText.Length), 0f);
                        navigateType[6].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.9f - size * getdown(meatText.Length), 0f);
                    }
                    break;
                }
            case "fish":
                {
                    if (isShow["fish"])
                    {
                        //此时被折叠按钮处于显示状态，将按钮隐藏并调整其他按钮的位置
                        for (int i = 0; i < fishText.Length; i++)
                        {
                            fishText[i].SetActive(false);
                        }
                        isShow["fish"] = false;
                        /*此处填入调整按钮位置的代码*/
                        //navigateType[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.3f, 0f);
                        navigateType[5].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.6f, 0f);
                        navigateType[6].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.9f, 0f);
                    }
                    else
                    {
                        hiddenAll();
                        //此时被折叠按钮处于隐藏状态，将按钮显示并调整其他按钮位置
                        for (int i = 0; i < fishText.Length; i++)
                        {
                            fishText[i].SetActive(true);
                        }
                        isShow["fish"] = true;
                        /*此处填入调整按钮位置的代码*/
                        navigateType[1].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.6f, 0f);
                        navigateType[2].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.3f, 0f);
                        navigateType[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0f, 0f);
                        navigateType[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.3f, 0f);
                        navigateType[5].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.6f - size * getdown(fishText.Length), 0f);
                        navigateType[6].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.9f - size * getdown(fishText.Length), 0f);
                    }
                    break;
                }
            case "milk":
                {
                    if (isShow["milk"])
                    {
                        //此时被折叠按钮处于显示状态，将按钮隐藏并调整其他按钮的位置
                        for (int i = 0; i < milkText.Length; i++)
                        {
                            milkText[i].SetActive(false);
                        }
                        isShow["milk"] = false;
                        /*此处填入调整按钮位置的代码*/
                        navigateType[6].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.9f, 0f);
                    }
                    else
                    {
                        hiddenAll();
                        //此时被折叠按钮处于隐藏状态，将按钮显示并调整其他按钮位置
                        for (int i = 0; i < milkText.Length; i++)
                        {
                            milkText[i].SetActive(true);
                        }
                        isShow["milk"] = true;
                        /*此处填入调整按钮位置的代码*/
                        navigateType[1].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.6f, 0f);
                        navigateType[2].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.3f, 0f);
                        navigateType[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0f, 0f);
                        navigateType[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.3f, 0f);
                        navigateType[5].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.6f, 0f);
                        navigateType[6].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.9f - size * getdown(milkText.Length), 0f);
                    }
                    break;
                }
            case "pizza":
                {
                    if (isShow["pizza"])
                    {
                        //此时被折叠按钮处于显示状态，将按钮隐藏并调整其他按钮的位置
                        for (int i = 0; i < pizzaText.Length; i++)
                        {
                            pizzaText[i].SetActive(false);
                        }
                        isShow["pizza"] = false;
                        /*此处填入调整按钮位置的代码*/
                    }
                    else
                    {
                        hiddenAll();
                        //此时被折叠按钮处于隐藏状态，将按钮显示并调整其他按钮位置
                        for (int i = 0; i < pizzaText.Length; i++)
                        {
                            pizzaText[i].SetActive(true);
                        }
                        isShow["pizza"] = true;
                        /*此处填入调整按钮位置的代码*/
                        navigateType[1].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.6f, 0f);
                        navigateType[2].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0.3f, 0f);
                        navigateType[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, 0f, 0f);
                        navigateType[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.3f, 0f);
                        navigateType[5].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.6f, 0f);
                        navigateType[6].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-0.5f, -0.9f, 0f);
                    }
                    break;
                }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isShow.Add("drink", false);
        isShow.Add("snacks", false);
        isShow.Add("wine", false);
        isShow.Add("meat", false);
        isShow.Add("fish", false);
        isShow.Add("milk", false);
        isShow.Add("pizza", false);
        hiddenAll();
    }
    //开始时将全部按钮折叠
    private void hiddenAll() {
        for (int i = 0; i < drinkText.Length; i++)
        {
            drinkText[i].SetActive(false);
        }
        for (int i = 0; i < snacksText.Length; i++)
        {
            snacksText[i].SetActive(false);
        }
        for (int i = 0; i < wineText.Length; i++)
        {
            wineText[i].SetActive(false);
        }
        for (int i = 0; i < meatText.Length; i++)
        {
            meatText[i].SetActive(false);
        }
        for (int i = 0; i < fishText.Length; i++)
        {
            fishText[i].SetActive(false);
        }
        for (int i = 0; i < milkText.Length; i++)
        {
            milkText[i].SetActive(false);
        }
        for (int i = 0; i < pizzaText.Length; i++)
        {
            pizzaText[i].SetActive(false);
        }
        isShow["drink"] = false;
        isShow["snacks"] = false;
        isShow["wine"] = false;
        isShow["meat"] = false;
        isShow["fish"] = false;
        isShow["milk"] = false;
        isShow["pizza"] = false;
    }
    private int getdown(int Length) {
        return (int)((Length - 1) / 2 + (Length - 1) % 2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
