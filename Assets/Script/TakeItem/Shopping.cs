using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
//存放购物清单信息，初始化，更新记录
public class Shopping : MonoBehaviour
{
    // Start is called before the first frame update
    //public static Text GoodName;
    //总额
    private static float TotalPrice = 0f;
    //用字典存储商品价目表
    private static Dictionary <string,float> GoodDictionary = new Dictionary<string, float>();
    //程序开始执行时初始化商品价目表
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void DoSomething()
    {
        GoodDictionary.Add("PREF_food_01",2.5f);
        GoodDictionary.Add("PREF_food_02", 2.5f);
        GoodDictionary.Add("PREF_food_03", 2.5f);
        GoodDictionary.Add("PREF_food_04", 3.0f);
        GoodDictionary.Add("PREF_food_05", 3.0f);
        GoodDictionary.Add("PREF_food_06", 2.0f);
        GoodDictionary.Add("PREF_food_07", 2.0f);
        GoodDictionary.Add("PREF_food_08", 2.0f);
        GoodDictionary.Add("PREF_food_09", 10.0f);
        GoodDictionary.Add("PREF_food_10", 10.0f);
        GoodDictionary.Add("PREF_food_11", 10.0f);
        GoodDictionary.Add("PREF_food_12", 10.0f);
        GoodDictionary.Add("PREF_food_13", 10.0f);
        GoodDictionary.Add("PREF_food_14", 10.0f);
        GoodDictionary.Add("PREF_food_15", 10.0f);
        GoodDictionary.Add("PREF_food_16", 15.0f);
        GoodDictionary.Add("PREF_food_17", 15.0f);
        GoodDictionary.Add("PREF_food_18", 15.0f);
        GoodDictionary.Add("PREF_food_19", 17.0f);
        GoodDictionary.Add("PREF_food_20", 25.0f);
        GoodDictionary.Add("PREF_food_21", 15.0f);
        GoodDictionary.Add("PREF_food_22", 10.0f);
        GoodDictionary.Add("PREF_food_23", 5.0f);
        GoodDictionary.Add("PREF_food_24", 5.0f);
        GoodDictionary.Add("PREF_food_25", 5.0f);
        GoodDictionary.Add("PREF_food_26", 5.0f);
        GoodDictionary.Add("PREF_food_27", 5.0f);
        GoodDictionary.Add("PREF_food_28", 5.0f);
        GoodDictionary.Add("PREF_food_29", 5.0f);
        GoodDictionary.Add("PREF_food_30", 5.0f);
        GoodDictionary.Add("PREF_food_31", 5.0f);
        GoodDictionary.Add("PREF_food_32", 5.0f);
        GoodDictionary.Add("PREF_food_33", 5.0f);
        GoodDictionary.Add("PREF_food_34", 4.0f);
        GoodDictionary.Add("PREF_food_35", 4.0f);
        GoodDictionary.Add("PREF_food_36", 7.0f);
        GoodDictionary.Add("PREF_food_37", 7.0f);
        GoodDictionary.Add("PREF_food_38", 5.0f);
        GoodDictionary.Add("PREF_food_39", 5.0f);
        GoodDictionary.Add("PREF_food_40", 8.0f);
        GoodDictionary.Add("PREF_food_41", 8.0f);
        GoodDictionary.Add("PREF_food_42", 25.0f);
        GoodDictionary.Add("PREF_food_43", 25.0f);
        GoodDictionary.Add("PREF_food_44", 25.0f);
        GoodDictionary.Add("PREF_food_45", 25.0f);
        GoodDictionary.Add("PREF_food_46", 99.9f);
        GoodDictionary.Add("PREF_food_47", 9.9f);
        GoodDictionary.Add("PREF_food_48", 9.9f);
    }
    //获取商品名
    public static string GetGoodName(string EName) {
        switch (EName) {
            case "PREF_food_01":
                {
                    return "橙汁";
                    break;
                }
            case "PREF_food_02":
                {
                    return "葡萄汁";
                    break;
                }
            case "PREF_food_03":
                {
                    return "苹果汁";
                    break;
                }
            case "PREF_food_04":
                {
                    return "饼干";
                    break;
                }
            case "PREF_food_05":
                {
                    return "牛奶曲奇";
                    break;
                }
            case "PREF_food_06":
                {
                    return "曲奇饼";
                    break;
                }
            case "PREF_food_07":
                {
                    return "Choco饼干";
                    break;
                }
            case "PREF_food_08":
                {
                    return "FRUIT饼干";
                    break;
                }
            case "PREF_food_09":
                {
                    return "曲奇饼（盒）";
                    break;
                }
            case "PREF_food_10":
                {
                    return "Choco饼干（盒）";
                    break;
                }
            case "PREF_food_11":
                {
                    return "FRUIT饼干（盒）";
                    break;
                }
            case "PREF_food_12":
                {
                    return "曲奇饼（盒）";
                    break;
                }
            case "PREF_food_14":
                {
                    return "Choco饼（盒）";
                    break;
                }
            case "PREF_food_15":
                {
                    return "FRUIT饼（盒）";
                    break;
                }
            case "PREF_food_16":
                {
                    return "牛排";
                    break;
                }
            case "PREF_food_17":
                {
                    return "猪排";
                    break;
                }
            case "PREF_food_18":
                {
                    return "培根";
                    break;
                }
            case "PREF_food_19":
                {
                    return "牛肋";
                    break;
                }
            case "PREF_food_20":
                {
                    return "羊肉卷";
                    break;
                }
            case "PREF_food_21":
                {
                    return "生鱼片";
                    break;
                }
            case "PREF_food_22":
                {
                    return "草鱼";
                    break;
                }
            case "PREF_food_23":
                {
                    return "柠檬";
                    break;
                }
            case "PREF_food_24":
                {
                    return "樱桃";
                    break;
                }
            case "PREF_food_25":
                {
                    return "苹果";
                    break;
                }
            case "PREF_food_26":
                {
                    return "葡萄";
                    break;
                }
            case "PREF_food_27":
                {
                    return "橙子";
                    break;
                }
            case "PREF_food_28":
                {
                    return "柠檬";
                    break;
                }
            case "PREF_food_29":
                {
                    return "红茶";
                    break;
                }
            case "PREF_food_30":
                {
                    return "绿茶";
                    break;
                }
            case "PREF_food_31":
                {
                    return "葡萄";
                    break;
                }
            case "PREF_food_32":
                {
                    return "咖啡";
                    break;
                }
            case "PREF_food_33":
                {
                    return "咖啡";
                    break;
                }
            case "PREF_food_34":
                {
                    return "牛奶";
                    break;
                }
            case "PREF_food_35":
                {
                    return "牛奶";
                    break;
                }
            case "PREF_food_36":
                {
                    return "牛奶（盒）";
                    break;
                }
            case "PREF_food_37":
                {
                    return "牛奶（盒）";
                    break;
                }
            case "PREF_food_38":
                {
                    return "酸奶";
                    break;
                }
            case "PREF_food_39":
                {
                    return "酸奶";
                    break;
                }
            case "PREF_food_40":
                {
                    return "黄油";
                    break;
                }
            case "PREF_food_41":
                {
                    return "黄油";
                    break;
                }
            case "PREF_food_42":
                {
                    return "红酒";
                    break;
                }
            case "PREF_food_43":
                {
                    return "红酒";
                    break;
                }
            case "PREF_food_44":
                {
                    return "红酒";
                    break;
                }
            case "PREF_food_45":
                {
                    return "红酒";
                    break;
                }
            case "PREF_food_46":
                {
                    return "红酒（箱）";
                    break;
                }
            case "PREF_food_47":
                {
                    return "披萨";
                    break;
                }
            case "PREF_food_48":
                {
                    return "披萨";
                    break;
                }
        }
        return "无";
    }
    //用字典存储购物单信息
    private static Dictionary<string, float> ShoppingInfo = new Dictionary<string, float>();
    //初始化购物单信息
    public static void clear() {
        ShoppingInfo.Clear();
        TotalPrice = 0f;
    }
    //根据放入购物车的商品名称更新购物单信息
    public static void UpdateShopping(string name) {
        float price; 
        GoodDictionary.TryGetValue(name,out price);
        if (ShoppingInfo.ContainsKey(name))
        {
            ShoppingInfo[name] += price;
            GameObject.Find("UI" + name + "Price").GetComponent<Text>().text = ShoppingInfo[name] + "元";
            GameObject.Find("UI" + name + "Name").GetComponent<Text>().text = GetGoodName(name) + "*" + ShoppingInfo[name] / GoodDictionary[name];
        }
        else
        {
            ShoppingInfo.Add(name, price);
            AddUI(name, price);
        }
        TotalPrice += price;
        GameObject.Find("TotalText").GetComponent<Text>().text = TotalPrice + "元";
    }
    private static void AddUI(string name, float price) {
        //更新购物车UI
        Text goodName;
        Text goodPrice;
        goodName = Instantiate(GameObject.Find("GoodName")).GetComponent<Text>();
        goodName.GetComponent<Transform>().SetParent(GameObject.Find("GoodText").GetComponent<Transform>(), true);
        goodPrice = Instantiate(GameObject.Find("GoodName")).GetComponent<Text>();
        goodPrice.GetComponent<Transform>().SetParent(GameObject.Find("GoodText").GetComponent<Transform>(), true);
        //调整位置
        goodName.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(3.5f, -1.0f-1.5f*(float)ShoppingInfo.Count, 0f);
        goodPrice.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(11.5f, -1.0f - 1.5f * (float)ShoppingInfo.Count, 0f);
        goodName.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        goodPrice.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        goodName.transform.localScale = new Vector3(0.05f, 0.05f, 1f);
        goodPrice.transform.localScale = new Vector3(0.05f, 0.05f, 1f);
        //调整内容
        goodName.text = GetGoodName(name) + "*1";
        goodPrice.text = price + "元";
        goodName.name = "UI" + name + "Name";
        goodPrice.name = "UI" + name + "Price";
    }
    //遍历购物清单
    public static void tostring() {
        foreach (KeyValuePair<string,float> s in ShoppingInfo) {
            Debug.Log(s.Key + ":" + s.Value);
        }
    }
    //得到指定商品的价格
    public static float getPrice(string name) {
        return GoodDictionary[name];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
