using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Other()
    {
        //----角色成長表
        /*string GrowFile = "{\"JsonGrow\":[{\"Lv\":1, \"Exp\":10, \"Hp\":10, \"Mp\":10, \"AttackDamge_Min\":0, \"AttackDamge_Max\":5, \"MagicDamge_Min\":5, \"MagicDamge_Max\":10, \"Armor\":1, \"ArmorMax\":10, \"Dodge\":1, \"DodgeMax\":10, \"Crit\":1, \"CritMax\":10}]}";
        File.WriteAllText(Application.persistentDataPath + @"\Grow.json", GrowFile);

        string GrowFileText = File.ReadAllText(Application.persistentDataPath + @"\Grow.json");
        Grow<Json_Grow> JsonGrowFile = JsonUtility.FromJson<Grow<Json_Grow>>(GrowFileText);

        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 2, Exp = 50, Hp = 15, Mp = 15, AttackDamge_Min = 1, AttackDamge_Max = 6, MagicDamge_Min = 6, MagicDamge_Max = 12, Armor = 2, ArmorMax = 20, Dodge = 2, DodgeMax = 20, Crit = 2, CritMax = 20 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 3, Exp = 100, Hp = 20, Mp = 20, AttackDamge_Min = 1, AttackDamge_Max = 7, MagicDamge_Min = 7, MagicDamge_Max = 14, Armor = 3, ArmorMax = 30, Dodge = 3, DodgeMax = 30, Crit = 3, CritMax = 30 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 4, Exp = 200, Hp = 25, Mp = 25, AttackDamge_Min = 2, AttackDamge_Max = 8, MagicDamge_Min = 8, MagicDamge_Max = 16, Armor = 4, ArmorMax = 40, Dodge = 4, DodgeMax = 40, Crit = 4, CritMax = 40 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 5, Exp = 300, Hp = 30, Mp = 30, AttackDamge_Min = 2, AttackDamge_Max = 9, MagicDamge_Min = 9, MagicDamge_Max = 18, Armor = 5, ArmorMax = 50, Dodge = 5, DodgeMax = 50, Crit = 5, CritMax = 50 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 6, Exp = 400, Hp = 35, Mp = 35, AttackDamge_Min = 3, AttackDamge_Max = 10, MagicDamge_Min = 10, MagicDamge_Max = 20, Armor = 6, ArmorMax = 60, Dodge = 6, DodgeMax = 60, Crit = 6, CritMax = 60 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 7, Exp = 500, Hp = 40, Mp = 40, AttackDamge_Min = 3, AttackDamge_Max = 11, MagicDamge_Min = 11, MagicDamge_Max = 22, Armor = 7, ArmorMax = 70, Dodge = 7, DodgeMax = 70, Crit = 7, CritMax = 70 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 8, Exp = 600, Hp = 45, Mp = 45, AttackDamge_Min = 4, AttackDamge_Max = 12, MagicDamge_Min = 12, MagicDamge_Max = 24, Armor = 8, ArmorMax = 80, Dodge = 8, DodgeMax = 80, Crit = 8, CritMax = 80 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 9, Exp = 700, Hp = 50, Mp = 50, AttackDamge_Min = 4, AttackDamge_Max = 13, MagicDamge_Min = 13, MagicDamge_Max = 26, Armor = 9, ArmorMax = 90, Dodge = 9, DodgeMax = 90, Crit = 9, CritMax = 90 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 10, Exp = 800, Hp = 55, Mp = 55, AttackDamge_Min = 5, AttackDamge_Max = 14, MagicDamge_Min = 14, MagicDamge_Max = 28, Armor = 10, ArmorMax = 100, Dodge = 10, DodgeMax = 100, Crit = 10, CritMax = 100 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 11, Exp = 900, Hp = 60, Mp = 60, AttackDamge_Min = 5, AttackDamge_Max = 15, MagicDamge_Min = 15, MagicDamge_Max = 30, Armor = 11, ArmorMax = 110, Dodge = 11, DodgeMax = 110, Crit = 11, CritMax = 110 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 12, Exp = 1000, Hp = 65, Mp = 65, AttackDamge_Min = 6, AttackDamge_Max = 16, MagicDamge_Min = 16, MagicDamge_Max = 32, Armor = 12, ArmorMax = 120, Dodge = 12, DodgeMax = 120, Crit = 12, CritMax = 120 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 13, Exp = 1100, Hp = 70, Mp = 70, AttackDamge_Min = 6, AttackDamge_Max = 17, MagicDamge_Min = 17, MagicDamge_Max = 34, Armor = 13, ArmorMax = 130, Dodge = 13, DodgeMax = 130, Crit = 13, CritMax = 130 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 14, Exp = 1200, Hp = 75, Mp = 75, AttackDamge_Min = 7, AttackDamge_Max = 18, MagicDamge_Min = 18, MagicDamge_Max = 36, Armor = 14, ArmorMax = 140, Dodge = 14, DodgeMax = 140, Crit = 14, CritMax = 140 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 15, Exp = 1300, Hp = 80, Mp = 80, AttackDamge_Min = 7, AttackDamge_Max = 19, MagicDamge_Min = 19, MagicDamge_Max = 38, Armor = 15, ArmorMax = 150, Dodge = 15, DodgeMax = 150, Crit = 15, CritMax = 150 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 16, Exp = 1400, Hp = 85, Mp = 85, AttackDamge_Min = 8, AttackDamge_Max = 20, MagicDamge_Min = 20, MagicDamge_Max = 40, Armor = 16, ArmorMax = 160, Dodge = 16, DodgeMax = 160, Crit = 16, CritMax = 160 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 17, Exp = 1500, Hp = 90, Mp = 90, AttackDamge_Min = 8, AttackDamge_Max = 21, MagicDamge_Min = 21, MagicDamge_Max = 42, Armor = 17, ArmorMax = 170, Dodge = 17, DodgeMax = 170, Crit = 17, CritMax = 170 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 18, Exp = 1600, Hp = 95, Mp = 95, AttackDamge_Min = 9, AttackDamge_Max = 22, MagicDamge_Min = 22, MagicDamge_Max = 44, Armor = 18, ArmorMax = 180, Dodge = 18, DodgeMax = 180, Crit = 18, CritMax = 180 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 19, Exp = 1700, Hp = 100, Mp = 100, AttackDamge_Min = 9, AttackDamge_Max = 23, MagicDamge_Min = 23, MagicDamge_Max = 46, Armor = 19, ArmorMax = 190, Dodge = 19, DodgeMax = 190, Crit = 19, CritMax = 190 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 20, Exp = 1800, Hp = 105, Mp = 105, AttackDamge_Min = 10, AttackDamge_Max = 24, MagicDamge_Min = 24, MagicDamge_Max = 48, Armor = 20, ArmorMax = 200, Dodge = 20, DodgeMax = 200, Crit = 20, CritMax = 200 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 21, Exp = 1900, Hp = 110, Mp = 110, AttackDamge_Min = 10, AttackDamge_Max = 25, MagicDamge_Min = 25, MagicDamge_Max = 50, Armor = 21, ArmorMax = 210, Dodge = 21, DodgeMax = 210, Crit = 21, CritMax = 210 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 22, Exp = 2000, Hp = 115, Mp = 115, AttackDamge_Min = 11, AttackDamge_Max = 26, MagicDamge_Min = 26, MagicDamge_Max = 52, Armor = 22, ArmorMax = 220, Dodge = 22, DodgeMax = 220, Crit = 22, CritMax = 220 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 23, Exp = 2100, Hp = 120, Mp = 120, AttackDamge_Min = 11, AttackDamge_Max = 27, MagicDamge_Min = 27, MagicDamge_Max = 54, Armor = 23, ArmorMax = 230, Dodge = 23, DodgeMax = 230, Crit = 23, CritMax = 230 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 24, Exp = 2200, Hp = 125, Mp = 125, AttackDamge_Min = 12, AttackDamge_Max = 28, MagicDamge_Min = 28, MagicDamge_Max = 56, Armor = 24, ArmorMax = 240, Dodge = 24, DodgeMax = 240, Crit = 24, CritMax = 240 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 25, Exp = 2300, Hp = 130, Mp = 130, AttackDamge_Min = 12, AttackDamge_Max = 29, MagicDamge_Min = 29, MagicDamge_Max = 58, Armor = 25, ArmorMax = 250, Dodge = 25, DodgeMax = 250, Crit = 25, CritMax = 250 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 26, Exp = 2400, Hp = 135, Mp = 135, AttackDamge_Min = 13, AttackDamge_Max = 30, MagicDamge_Min = 30, MagicDamge_Max = 60, Armor = 26, ArmorMax = 260, Dodge = 26, DodgeMax = 260, Crit = 26, CritMax = 260 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 27, Exp = 2500, Hp = 140, Mp = 140, AttackDamge_Min = 13, AttackDamge_Max = 31, MagicDamge_Min = 31, MagicDamge_Max = 62, Armor = 27, ArmorMax = 270, Dodge = 27, DodgeMax = 270, Crit = 27, CritMax = 270 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 28, Exp = 2600, Hp = 145, Mp = 145, AttackDamge_Min = 14, AttackDamge_Max = 32, MagicDamge_Min = 32, MagicDamge_Max = 64, Armor = 28, ArmorMax = 280, Dodge = 28, DodgeMax = 280, Crit = 28, CritMax = 280 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 29, Exp = 2700, Hp = 150, Mp = 150, AttackDamge_Min = 14, AttackDamge_Max = 33, MagicDamge_Min = 33, MagicDamge_Max = 66, Armor = 29, ArmorMax = 290, Dodge = 29, DodgeMax = 290, Crit = 29, CritMax = 290 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 30, Exp = 2800, Hp = 155, Mp = 155, AttackDamge_Min = 15, AttackDamge_Max = 34, MagicDamge_Min = 34, MagicDamge_Max = 68, Armor = 30, ArmorMax = 300, Dodge = 30, DodgeMax = 300, Crit = 30, CritMax = 300 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 31, Exp = 2900, Hp = 160, Mp = 160, AttackDamge_Min = 15, AttackDamge_Max = 35, MagicDamge_Min = 35, MagicDamge_Max = 70, Armor = 31, ArmorMax = 310, Dodge = 31, DodgeMax = 310, Crit = 31, CritMax = 310 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 32, Exp = 3000, Hp = 165, Mp = 165, AttackDamge_Min = 16, AttackDamge_Max = 36, MagicDamge_Min = 36, MagicDamge_Max = 72, Armor = 32, ArmorMax = 320, Dodge = 32, DodgeMax = 320, Crit = 32, CritMax = 320 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 33, Exp = 3100, Hp = 170, Mp = 170, AttackDamge_Min = 16, AttackDamge_Max = 37, MagicDamge_Min = 37, MagicDamge_Max = 74, Armor = 33, ArmorMax = 330, Dodge = 33, DodgeMax = 330, Crit = 33, CritMax = 330 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 34, Exp = 3200, Hp = 175, Mp = 175, AttackDamge_Min = 17, AttackDamge_Max = 38, MagicDamge_Min = 38, MagicDamge_Max = 76, Armor = 34, ArmorMax = 340, Dodge = 34, DodgeMax = 340, Crit = 34, CritMax = 340 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 35, Exp = 3300, Hp = 180, Mp = 180, AttackDamge_Min = 17, AttackDamge_Max = 39, MagicDamge_Min = 39, MagicDamge_Max = 78, Armor = 35, ArmorMax = 350, Dodge = 35, DodgeMax = 350, Crit = 35, CritMax = 350 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 36, Exp = 3400, Hp = 185, Mp = 185, AttackDamge_Min = 18, AttackDamge_Max = 40, MagicDamge_Min = 40, MagicDamge_Max = 80, Armor = 36, ArmorMax = 360, Dodge = 36, DodgeMax = 360, Crit = 36, CritMax = 360 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 37, Exp = 3500, Hp = 190, Mp = 190, AttackDamge_Min = 18, AttackDamge_Max = 41, MagicDamge_Min = 41, MagicDamge_Max = 82, Armor = 37, ArmorMax = 370, Dodge = 37, DodgeMax = 370, Crit = 37, CritMax = 370 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 38, Exp = 3600, Hp = 195, Mp = 195, AttackDamge_Min = 19, AttackDamge_Max = 42, MagicDamge_Min = 42, MagicDamge_Max = 84, Armor = 38, ArmorMax = 380, Dodge = 38, DodgeMax = 380, Crit = 38, CritMax = 380 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 39, Exp = 3700, Hp = 200, Mp = 200, AttackDamge_Min = 19, AttackDamge_Max = 43, MagicDamge_Min = 43, MagicDamge_Max = 86, Armor = 39, ArmorMax = 390, Dodge = 39, DodgeMax = 390, Crit = 39, CritMax = 390 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 40, Exp = 3800, Hp = 205, Mp = 205, AttackDamge_Min = 20, AttackDamge_Max = 44, MagicDamge_Min = 44, MagicDamge_Max = 88, Armor = 40, ArmorMax = 400, Dodge = 40, DodgeMax = 400, Crit = 40, CritMax = 400 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 41, Exp = 3900, Hp = 210, Mp = 210, AttackDamge_Min = 20, AttackDamge_Max = 45, MagicDamge_Min = 45, MagicDamge_Max = 90, Armor = 41, ArmorMax = 410, Dodge = 41, DodgeMax = 410, Crit = 41, CritMax = 410 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 42, Exp = 4000, Hp = 215, Mp = 215, AttackDamge_Min = 21, AttackDamge_Max = 46, MagicDamge_Min = 46, MagicDamge_Max = 92, Armor = 42, ArmorMax = 420, Dodge = 42, DodgeMax = 420, Crit = 42, CritMax = 420 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 43, Exp = 4100, Hp = 220, Mp = 220, AttackDamge_Min = 21, AttackDamge_Max = 47, MagicDamge_Min = 47, MagicDamge_Max = 94, Armor = 43, ArmorMax = 430, Dodge = 43, DodgeMax = 430, Crit = 43, CritMax = 430 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 44, Exp = 4200, Hp = 225, Mp = 225, AttackDamge_Min = 22, AttackDamge_Max = 48, MagicDamge_Min = 48, MagicDamge_Max = 96, Armor = 44, ArmorMax = 440, Dodge = 44, DodgeMax = 440, Crit = 44, CritMax = 440 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 45, Exp = 4300, Hp = 230, Mp = 230, AttackDamge_Min = 22, AttackDamge_Max = 49, MagicDamge_Min = 49, MagicDamge_Max = 98, Armor = 45, ArmorMax = 450, Dodge = 45, DodgeMax = 450, Crit = 45, CritMax = 450 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 46, Exp = 4400, Hp = 235, Mp = 235, AttackDamge_Min = 23, AttackDamge_Max = 50, MagicDamge_Min = 50, MagicDamge_Max = 100, Armor = 46, ArmorMax = 460, Dodge = 46, DodgeMax = 460, Crit = 46, CritMax = 460 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 47, Exp = 4500, Hp = 240, Mp = 240, AttackDamge_Min = 23, AttackDamge_Max = 51, MagicDamge_Min = 51, MagicDamge_Max = 102, Armor = 47, ArmorMax = 470, Dodge = 47, DodgeMax = 470, Crit = 47, CritMax = 470 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 48, Exp = 4600, Hp = 245, Mp = 245, AttackDamge_Min = 24, AttackDamge_Max = 52, MagicDamge_Min = 52, MagicDamge_Max = 104, Armor = 48, ArmorMax = 480, Dodge = 48, DodgeMax = 480, Crit = 48, CritMax = 480 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 49, Exp = 4700, Hp = 250, Mp = 250, AttackDamge_Min = 24, AttackDamge_Max = 53, MagicDamge_Min = 53, MagicDamge_Max = 106, Armor = 49, ArmorMax = 490, Dodge = 49, DodgeMax = 490, Crit = 49, CritMax = 490 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 50, Exp = 4800, Hp = 255, Mp = 255, AttackDamge_Min = 25, AttackDamge_Max = 54, MagicDamge_Min = 54, MagicDamge_Max = 108, Armor = 50, ArmorMax = 500, Dodge = 50, DodgeMax = 500, Crit = 50, CritMax = 500 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 51, Exp = 4900, Hp = 260, Mp = 260, AttackDamge_Min = 25, AttackDamge_Max = 55, MagicDamge_Min = 55, MagicDamge_Max = 110, Armor = 51, ArmorMax = 510, Dodge = 51, DodgeMax = 510, Crit = 51, CritMax = 510 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 52, Exp = 5000, Hp = 265, Mp = 265, AttackDamge_Min = 26, AttackDamge_Max = 56, MagicDamge_Min = 56, MagicDamge_Max = 112, Armor = 52, ArmorMax = 520, Dodge = 52, DodgeMax = 520, Crit = 52, CritMax = 520 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 53, Exp = 5100, Hp = 270, Mp = 270, AttackDamge_Min = 26, AttackDamge_Max = 57, MagicDamge_Min = 57, MagicDamge_Max = 114, Armor = 53, ArmorMax = 530, Dodge = 53, DodgeMax = 530, Crit = 53, CritMax = 530 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 54, Exp = 5200, Hp = 275, Mp = 275, AttackDamge_Min = 27, AttackDamge_Max = 58, MagicDamge_Min = 58, MagicDamge_Max = 116, Armor = 54, ArmorMax = 540, Dodge = 54, DodgeMax = 540, Crit = 54, CritMax = 540 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 55, Exp = 5300, Hp = 280, Mp = 280, AttackDamge_Min = 27, AttackDamge_Max = 59, MagicDamge_Min = 59, MagicDamge_Max = 118, Armor = 55, ArmorMax = 550, Dodge = 55, DodgeMax = 550, Crit = 55, CritMax = 550 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 56, Exp = 5400, Hp = 285, Mp = 285, AttackDamge_Min = 28, AttackDamge_Max = 60, MagicDamge_Min = 60, MagicDamge_Max = 120, Armor = 56, ArmorMax = 560, Dodge = 56, DodgeMax = 560, Crit = 56, CritMax = 560 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 57, Exp = 5500, Hp = 290, Mp = 290, AttackDamge_Min = 28, AttackDamge_Max = 61, MagicDamge_Min = 61, MagicDamge_Max = 122, Armor = 57, ArmorMax = 570, Dodge = 57, DodgeMax = 570, Crit = 57, CritMax = 570 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 58, Exp = 5600, Hp = 295, Mp = 295, AttackDamge_Min = 29, AttackDamge_Max = 62, MagicDamge_Min = 62, MagicDamge_Max = 124, Armor = 58, ArmorMax = 580, Dodge = 58, DodgeMax = 580, Crit = 58, CritMax = 580 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 59, Exp = 5700, Hp = 300, Mp = 300, AttackDamge_Min = 29, AttackDamge_Max = 63, MagicDamge_Min = 63, MagicDamge_Max = 126, Armor = 59, ArmorMax = 590, Dodge = 59, DodgeMax = 590, Crit = 59, CritMax = 590 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 60, Exp = 5800, Hp = 305, Mp = 305, AttackDamge_Min = 30, AttackDamge_Max = 64, MagicDamge_Min = 64, MagicDamge_Max = 128, Armor = 60, ArmorMax = 600, Dodge = 60, DodgeMax = 600, Crit = 60, CritMax = 600 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 61, Exp = 5900, Hp = 310, Mp = 310, AttackDamge_Min = 30, AttackDamge_Max = 65, MagicDamge_Min = 65, MagicDamge_Max = 130, Armor = 61, ArmorMax = 610, Dodge = 61, DodgeMax = 610, Crit = 61, CritMax = 610 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 62, Exp = 6000, Hp = 315, Mp = 315, AttackDamge_Min = 31, AttackDamge_Max = 66, MagicDamge_Min = 66, MagicDamge_Max = 132, Armor = 62, ArmorMax = 620, Dodge = 62, DodgeMax = 620, Crit = 62, CritMax = 620 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 63, Exp = 6100, Hp = 320, Mp = 320, AttackDamge_Min = 31, AttackDamge_Max = 67, MagicDamge_Min = 67, MagicDamge_Max = 134, Armor = 63, ArmorMax = 630, Dodge = 63, DodgeMax = 630, Crit = 63, CritMax = 630 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 64, Exp = 6200, Hp = 325, Mp = 325, AttackDamge_Min = 32, AttackDamge_Max = 68, MagicDamge_Min = 68, MagicDamge_Max = 136, Armor = 64, ArmorMax = 640, Dodge = 64, DodgeMax = 640, Crit = 64, CritMax = 640 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 65, Exp = 6300, Hp = 330, Mp = 330, AttackDamge_Min = 32, AttackDamge_Max = 69, MagicDamge_Min = 69, MagicDamge_Max = 138, Armor = 65, ArmorMax = 650, Dodge = 65, DodgeMax = 650, Crit = 65, CritMax = 650 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 66, Exp = 6400, Hp = 335, Mp = 335, AttackDamge_Min = 33, AttackDamge_Max = 70, MagicDamge_Min = 70, MagicDamge_Max = 140, Armor = 66, ArmorMax = 660, Dodge = 66, DodgeMax = 660, Crit = 66, CritMax = 660 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 67, Exp = 6500, Hp = 340, Mp = 340, AttackDamge_Min = 33, AttackDamge_Max = 71, MagicDamge_Min = 71, MagicDamge_Max = 142, Armor = 67, ArmorMax = 670, Dodge = 67, DodgeMax = 670, Crit = 67, CritMax = 670 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 68, Exp = 6600, Hp = 345, Mp = 345, AttackDamge_Min = 34, AttackDamge_Max = 72, MagicDamge_Min = 72, MagicDamge_Max = 144, Armor = 68, ArmorMax = 680, Dodge = 68, DodgeMax = 680, Crit = 68, CritMax = 680 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 69, Exp = 6700, Hp = 350, Mp = 350, AttackDamge_Min = 34, AttackDamge_Max = 73, MagicDamge_Min = 73, MagicDamge_Max = 146, Armor = 69, ArmorMax = 690, Dodge = 69, DodgeMax = 690, Crit = 69, CritMax = 690 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 70, Exp = 6800, Hp = 355, Mp = 355, AttackDamge_Min = 35, AttackDamge_Max = 74, MagicDamge_Min = 74, MagicDamge_Max = 148, Armor = 70, ArmorMax = 700, Dodge = 70, DodgeMax = 700, Crit = 70, CritMax = 700 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 71, Exp = 6900, Hp = 360, Mp = 360, AttackDamge_Min = 35, AttackDamge_Max = 75, MagicDamge_Min = 75, MagicDamge_Max = 150, Armor = 71, ArmorMax = 710, Dodge = 71, DodgeMax = 710, Crit = 71, CritMax = 710 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 72, Exp = 7000, Hp = 365, Mp = 365, AttackDamge_Min = 36, AttackDamge_Max = 76, MagicDamge_Min = 76, MagicDamge_Max = 152, Armor = 72, ArmorMax = 720, Dodge = 72, DodgeMax = 720, Crit = 72, CritMax = 720 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 73, Exp = 7100, Hp = 370, Mp = 370, AttackDamge_Min = 36, AttackDamge_Max = 77, MagicDamge_Min = 77, MagicDamge_Max = 154, Armor = 73, ArmorMax = 730, Dodge = 73, DodgeMax = 730, Crit = 73, CritMax = 730 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 74, Exp = 7200, Hp = 375, Mp = 375, AttackDamge_Min = 37, AttackDamge_Max = 78, MagicDamge_Min = 78, MagicDamge_Max = 156, Armor = 74, ArmorMax = 740, Dodge = 74, DodgeMax = 740, Crit = 74, CritMax = 740 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 75, Exp = 7300, Hp = 380, Mp = 380, AttackDamge_Min = 37, AttackDamge_Max = 79, MagicDamge_Min = 79, MagicDamge_Max = 158, Armor = 75, ArmorMax = 750, Dodge = 75, DodgeMax = 750, Crit = 75, CritMax = 750 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 76, Exp = 7400, Hp = 385, Mp = 385, AttackDamge_Min = 38, AttackDamge_Max = 80, MagicDamge_Min = 80, MagicDamge_Max = 160, Armor = 76, ArmorMax = 760, Dodge = 76, DodgeMax = 760, Crit = 76, CritMax = 760 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 77, Exp = 7500, Hp = 390, Mp = 390, AttackDamge_Min = 38, AttackDamge_Max = 81, MagicDamge_Min = 81, MagicDamge_Max = 162, Armor = 77, ArmorMax = 770, Dodge = 77, DodgeMax = 770, Crit = 77, CritMax = 770 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 78, Exp = 7600, Hp = 395, Mp = 395, AttackDamge_Min = 39, AttackDamge_Max = 82, MagicDamge_Min = 82, MagicDamge_Max = 164, Armor = 78, ArmorMax = 780, Dodge = 78, DodgeMax = 780, Crit = 78, CritMax = 780 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 79, Exp = 7700, Hp = 400, Mp = 400, AttackDamge_Min = 39, AttackDamge_Max = 83, MagicDamge_Min = 83, MagicDamge_Max = 166, Armor = 79, ArmorMax = 790, Dodge = 79, DodgeMax = 790, Crit = 79, CritMax = 790 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 80, Exp = 7800, Hp = 405, Mp = 405, AttackDamge_Min = 40, AttackDamge_Max = 84, MagicDamge_Min = 84, MagicDamge_Max = 168, Armor = 80, ArmorMax = 800, Dodge = 80, DodgeMax = 800, Crit = 80, CritMax = 800 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 81, Exp = 7900, Hp = 410, Mp = 410, AttackDamge_Min = 40, AttackDamge_Max = 85, MagicDamge_Min = 85, MagicDamge_Max = 170, Armor = 81, ArmorMax = 810, Dodge = 81, DodgeMax = 810, Crit = 81, CritMax = 810 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 82, Exp = 8000, Hp = 415, Mp = 415, AttackDamge_Min = 41, AttackDamge_Max = 86, MagicDamge_Min = 86, MagicDamge_Max = 172, Armor = 82, ArmorMax = 820, Dodge = 82, DodgeMax = 820, Crit = 82, CritMax = 820 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 83, Exp = 8100, Hp = 420, Mp = 420, AttackDamge_Min = 41, AttackDamge_Max = 87, MagicDamge_Min = 87, MagicDamge_Max = 174, Armor = 83, ArmorMax = 830, Dodge = 83, DodgeMax = 830, Crit = 83, CritMax = 830 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 84, Exp = 8200, Hp = 425, Mp = 425, AttackDamge_Min = 42, AttackDamge_Max = 88, MagicDamge_Min = 88, MagicDamge_Max = 176, Armor = 84, ArmorMax = 840, Dodge = 84, DodgeMax = 840, Crit = 84, CritMax = 840 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 85, Exp = 8300, Hp = 430, Mp = 430, AttackDamge_Min = 42, AttackDamge_Max = 89, MagicDamge_Min = 89, MagicDamge_Max = 178, Armor = 85, ArmorMax = 850, Dodge = 85, DodgeMax = 850, Crit = 85, CritMax = 850 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 86, Exp = 8400, Hp = 435, Mp = 435, AttackDamge_Min = 43, AttackDamge_Max = 90, MagicDamge_Min = 90, MagicDamge_Max = 180, Armor = 86, ArmorMax = 860, Dodge = 86, DodgeMax = 860, Crit = 86, CritMax = 860 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 87, Exp = 8500, Hp = 440, Mp = 440, AttackDamge_Min = 43, AttackDamge_Max = 91, MagicDamge_Min = 91, MagicDamge_Max = 182, Armor = 87, ArmorMax = 870, Dodge = 87, DodgeMax = 870, Crit = 87, CritMax = 870 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 88, Exp = 8600, Hp = 445, Mp = 445, AttackDamge_Min = 44, AttackDamge_Max = 92, MagicDamge_Min = 92, MagicDamge_Max = 184, Armor = 88, ArmorMax = 880, Dodge = 88, DodgeMax = 880, Crit = 88, CritMax = 880 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 89, Exp = 8700, Hp = 450, Mp = 450, AttackDamge_Min = 44, AttackDamge_Max = 93, MagicDamge_Min = 93, MagicDamge_Max = 186, Armor = 89, ArmorMax = 890, Dodge = 89, DodgeMax = 890, Crit = 89, CritMax = 890 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 90, Exp = 8800, Hp = 455, Mp = 455, AttackDamge_Min = 45, AttackDamge_Max = 94, MagicDamge_Min = 94, MagicDamge_Max = 188, Armor = 90, ArmorMax = 900, Dodge = 90, DodgeMax = 900, Crit = 90, CritMax = 900 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 91, Exp = 8900, Hp = 460, Mp = 460, AttackDamge_Min = 45, AttackDamge_Max = 95, MagicDamge_Min = 95, MagicDamge_Max = 190, Armor = 91, ArmorMax = 910, Dodge = 91, DodgeMax = 910, Crit = 91, CritMax = 910 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 92, Exp = 9000, Hp = 465, Mp = 465, AttackDamge_Min = 46, AttackDamge_Max = 96, MagicDamge_Min = 96, MagicDamge_Max = 192, Armor = 92, ArmorMax = 920, Dodge = 92, DodgeMax = 920, Crit = 92, CritMax = 920 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 93, Exp = 9100, Hp = 470, Mp = 470, AttackDamge_Min = 46, AttackDamge_Max = 97, MagicDamge_Min = 97, MagicDamge_Max = 194, Armor = 93, ArmorMax = 930, Dodge = 93, DodgeMax = 930, Crit = 93, CritMax = 930 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 94, Exp = 9200, Hp = 475, Mp = 475, AttackDamge_Min = 47, AttackDamge_Max = 98, MagicDamge_Min = 98, MagicDamge_Max = 196, Armor = 94, ArmorMax = 940, Dodge = 94, DodgeMax = 940, Crit = 94, CritMax = 940 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 95, Exp = 9300, Hp = 480, Mp = 480, AttackDamge_Min = 47, AttackDamge_Max = 99, MagicDamge_Min = 99, MagicDamge_Max = 198, Armor = 95, ArmorMax = 950, Dodge = 95, DodgeMax = 950, Crit = 95, CritMax = 950 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 96, Exp = 9400, Hp = 485, Mp = 485, AttackDamge_Min = 48, AttackDamge_Max = 100, MagicDamge_Min = 100, MagicDamge_Max = 200, Armor = 96, ArmorMax = 960, Dodge = 96, DodgeMax = 960, Crit = 96, CritMax = 960 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 97, Exp = 9500, Hp = 490, Mp = 490, AttackDamge_Min = 48, AttackDamge_Max = 101, MagicDamge_Min = 101, MagicDamge_Max = 202, Armor = 97, ArmorMax = 970, Dodge = 97, DodgeMax = 970, Crit = 97, CritMax = 970 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 98, Exp = 9600, Hp = 495, Mp = 495, AttackDamge_Min = 49, AttackDamge_Max = 102, MagicDamge_Min = 102, MagicDamge_Max = 204, Armor = 98, ArmorMax = 980, Dodge = 98, DodgeMax = 980, Crit = 98, CritMax = 980 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 99, Exp = 9700, Hp = 500, Mp = 500, AttackDamge_Min = 49, AttackDamge_Max = 103, MagicDamge_Min = 103, MagicDamge_Max = 206, Armor = 99, ArmorMax = 990, Dodge = 99, DodgeMax = 990, Crit = 99, CritMax = 990 });
        JsonGrowFile.JsonGrow.Add(new Json_Grow() { Lv = 100, Exp = 9800, Hp = 505, Mp = 505, AttackDamge_Min = 50, AttackDamge_Max = 104, MagicDamge_Min = 104, MagicDamge_Max = 208, Armor = 100, ArmorMax = 1000, Dodge = 100, DodgeMax = 1000, Crit = 100, CritMax = 1000 });

        string savegrowdate = JsonUtility.ToJson(JsonGrowFile);
        File.WriteAllText(Application.persistentDataPath + @"\Grow.json", savegrowdate);*/
        //----
    }

    /*public class Grow<T>
    {
        public List<T> JsonGrow;
    }*/

}
