using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Json_Player_Armor_Static
{
    public static int Id;                    //在玩家裝備列表裡顯示的獲得的順序
    public static int ArmorEquip;            //是否有被裝備在玩家身上
    public static int ArmorBasicId;          //辨別這個裝備的基本能力是依照哪件裝備編號
    public static int ArmorLv;               //裝備等級=可裝備的需求等級
    public static int ArmorType;             //裝備類型，0 = 主手武器, 1 = 副手武器, 2 = 頭盔, 3 = 盔甲, 4 = 褲子, 5 = 鞋子, 6 = 手套, 7 = 戒指, 8 = 手鐲, 9 = 項鍊
    public static int ArmorBasicPowerType;   //裝備基礎能力類型，0 = HP，1 = MP，2 = 物理攻擊力，3 = 魔法攻擊力，4 = 力量，5 = 智慧，6 = 敏捷
    public static float ArmorBasicPowerMin;  //裝備基礎能力最小數值
    public static float ArmorBasicPowerMax;  //裝備基礎能力最大數值
    public static int ArmorRank;             //裝備品階，決定裝備詞綴有幾條，0 = 0條詞墜，1 = 2條詞墜，2 = 4條詞墜，3 = 6條詞墜
    public static int ArmorIconId;           //裝備圖編號
    public static int ArmorPowerType_1;      //該裝備第一條詞墜的類型
    public static int ArmorPowerMin_1;       //該裝備第一條詞墜的最小值
    public static int ArmorPowerMax_1;       //該裝備第一條詞墜的最小值
    public static int ArmorPowerType_2;      //該裝備第二條詞墜的類型
    public static int ArmorPowerMin_2;       //該裝備第二條詞墜的最小值
    public static int ArmorPowerMax_2;       //該裝備第二條詞墜的最小值
    public static int ArmorPowerType_3;      //該裝備第三條詞墜的類型
    public static int ArmorPowerMin_3;       //該裝備第三條詞墜的最小值
    public static int ArmorPowerMax_3;       //該裝備第三條詞墜的最小值
    public static int ArmorPowerType_4;      //該裝備第四條詞墜的類型
    public static int ArmorPowerMin_4;       //該裝備第四條詞墜的最小值
    public static int ArmorPowerMax_4;       //該裝備第四條詞墜的最小值
    public static int ArmorPowerType_5;      //該裝備第五條詞墜的類型
    public static int ArmorPowerMin_5;       //該裝備第五條詞墜的最小值
    public static int ArmorPowerMax_5;       //該裝備第五條詞墜的最小值
    public static int ArmorPowerType_6;      //該裝備第六條詞墜的類型
    public static int ArmorPowerMin_6;       //該裝備第六條詞墜的最小值
    public static int ArmorPowerMax_6;       //該裝備第六條詞墜的最小值
}
