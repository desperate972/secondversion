using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Json_Potion
{
    public int PotionId;        //藥水ID
    public string PotionName;   //藥水名稱
    public float PotionCD;      //藥水使用間隔時間，藥水CD
    public int PotionType;      //藥水類型，0 = 回血，1 = 回魔力
    public int PotionCount;     //藥水最多充能幾次
    public float Potionml;      //藥水使用一次回復多少
    public string PotionInfo;   //藥水說明
    public float PotinTime;     //藥水持續時間
    public int PotionUse;       //藥水是否要被裝備
    public int PotionIcon;      //藥水ICON圖
}
