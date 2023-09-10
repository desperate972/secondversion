using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Json_Potion_Static
{
	public static int PotionId;        //藥水ID
	public static string PotionName;   //藥水名稱
	public static float PotionCD;      //藥水使用間隔時間，藥水CD
	public static int PotionType;      //藥水類型，0 = 回血，1 = 回魔力
	public static int PotionCount;     //藥水最多充能幾次
	public static float Potionml;     //藥水使用一次回復多少
	public static string PotionInfo;   //藥水說明
	public static float PotinTime;     //藥水持續時間
	public static int PotionUse;       //藥水是否要被裝備
	public static int PotionIcon;      //藥水ICON圖
}
