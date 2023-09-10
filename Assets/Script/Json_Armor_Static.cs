using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Json_Armor_Static        //這是裝備的基本能力內容
{
	public static int ArmorId;                     //裝備的編號
	public static string ArmorName;                //裝備名稱
	public static int ArmorType;                   //裝備類型，0 = 主手武器, 1 = 副手武器, 2 = 頭盔, 3 = 盔甲, 4 = 褲子, 5 = 鞋子, 6 = 手套, 7 = 戒指, 8 = 手鐲, 9 = 項鍊
	public static int ArmorLv;                     //裝備等級=可裝備的需求等級
	public static int ArmorBasicPowerType;         //裝備基礎能力類型，0 = HP，1 = MP，2 = 物理攻擊力，3 = 魔法攻擊力，4 = 力量，5 = 智慧，6 = 敏捷
	public static float ArmorBasicPowerMin;        //裝備基礎能力最小數值
	public static float ArmorBasicPowerMax;        //裝備基礎能力最大數值
	public static float ArmorBasicPowerMinRage_1;  //裝備基礎能力最小數值的最小數值範圍
	public static float ArmorBasicPowerMinRage_2;  //裝備基礎能力最小數值的最大數值範圍
	public static float ArmorBasicPowerMaxRage_1;  //裝備基礎能力最大數值的最小數值範圍
	public static float ArmorBasicPowerMaxRage_2;  //裝備基礎能力最大數值的最大數值範圍
	public static int ArmorRank;                   //裝備品階，決定裝備詞綴有幾條，0 = 0條詞墜，1 = 2條詞墜，2 = 4條詞墜，3 = 6條詞墜
	public static int ArmorIconId;                 //裝備圖編號
}