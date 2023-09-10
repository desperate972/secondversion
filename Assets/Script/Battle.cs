using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    //----角色相關數值
    public int[] PlayerAttackarray;
    public float PlayerADAttack;
    public float PlayerAPAttack;
    public float PlayerHP;
    public int PlayerAttackArrayNum;
    public float PlayerAttackNom;
    public int[] PlayerAttackRange;
    public int PlayerCanAttack;              //----判斷角色是否有攻擊到怪物，0 = 沒有，1 = 有
    //----

    //----角色技能攻擊%數
    public float Skill_AttackNum_1;
    public float Skill_AttackNum_2;
    public float Skill_AttackNum_3;
    public float Skill_AttackNum_4;
    public float Skill_AttackNum_5;
    //----

    //----角色技能使用秒數
    public float Skill_Time_1;
    public float Skill_Time_2;
    public float Skill_Time_3;
    public float Skill_Time_4;
    public float Skill_Time_5;
    //----

    //----角色技能攻擊範圍
    public int Skill_Range_1;
    public int Skill_Range_2;
    public int Skill_Range_3;
    public int Skill_Range_4;
    public int Skill_Range_5;
    //----

    //----角色技能類型，0 = 物理，1 = 魔法
    public int Skill_ADAP_1;
    public int Skill_ADAP_2;
    public int Skill_ADAP_3;
    public int Skill_ADAP_4;
    public int Skill_ADAP_5;
    //----

    //----角色接下來技能使用的秒數
    public float[] PlayerAttackArrayTime;
    //----

    //----怪物相關數值
    public int[] MonsterAttackarray;
    public float MonsterADAttack;
    public float MonsterAPAttack;
    public float MonsterHP;
    public int MonsterAttackArrayNum;
    public float MonsterAttackNom;
    public int[] MonsterAttackRange;
    public int MonsterCanAttack;              //----判斷怪物是否有攻擊到角色，0 = 沒有，1 = 有
    //----

    //----怪物技能攻擊%數
    public float MonsterSkill_AttackNum_1;
    public float MonsterSkill_AttackNum_2;
    public float MonsterSkill_AttackNum_3;
    public float MonsterSkill_AttackNum_4;
    public float MonsterSkill_AttackNum_5;
    //----

    //----怪物技能使用秒數
    public float MonsterSkill_Time_1;
    public float MonsterSkill_Time_2;
    public float MonsterSkill_Time_3;
    public float MonsterSkill_Time_4;
    public float MonsterSkill_Time_5;
    //----

    //----怪物技能攻擊範圍
    public int MonsterSkill_Range_1;
    public int MonsterSkill_Range_2;
    public int MonsterSkill_Range_3;
    public int MonsterSkill_Range_4;
    public int MonsterSkill_Range_5;
    //----

    //----怪物技能類型，0 = 物理，1 = 魔法
    public int MonsterSkill_ADAP_1;
    public int MonsterSkill_ADAP_2;
    public int MonsterSkill_ADAP_3;
    public int MonsterSkill_ADAP_4;
    public int MonsterSkill_ADAP_5;
    //----

    //----怪物接下來技能使用的秒數
    public float[] MonsterAttackArrayTime;
    //----

    //----戰鬥相關數值
    public float BattleTime;
    //----

    public void Awake()
    {
        BattleReady();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickBattleStart()
    {
        InvokeRepeating("BattleStart", 0, 0.1f);
    }

    public void BattleStart()
    {
        Debug.Log("當前時間:" + BattleTime);
        if(PlayerAttackArrayNum == 4)
        {
            PlayerAttackArrayNum = 0;
        }
        if (MonsterAttackArrayNum == 4)
        {
            MonsterAttackArrayNum = 0;
        }
        if (BattleTime == PlayerAttackArrayTime[PlayerAttackArrayNum] && BattleTime != MonsterAttackArrayTime[MonsterAttackArrayNum])    //----角色可以攻擊但怪物不能攻擊
        {
            //PlayerAttackMonster(PlayerAttackArrayNum);             //----檢查角色攻擊範圍是否可以攻擊到怪物
            switch(PlayerCanAttack == 1)
            {
                case true:
                    {
                        Debug.Log("本次角色戰鬥套路是第 " + (PlayerAttackArrayNum + 1) + " 招");
                        PlayerAttackCon(PlayerAttackArrayNum);
                        Debug.Log("本次角色造成傷害為: " + PlayerAttackNom);
                        MonsterHP = MonsterHP - PlayerAttackNom;
                        Debug.Log("怪物剩餘血量: " + MonsterHP);
                        PlayerAttackArrayTimeAdd(PlayerAttackArrayNum);
                        Debug.Log("下次角色戰鬥套路是第 " + (PlayerAttackArrayNum + 2) + " 招");
                        break;
                    }
                case false:
                    {
                        break;
                    }
            }
            ResetPlayerRange();
            PlayerAttackArrayNum++;
            if(PlayerAttackArrayNum > 4)
            {
                PlayerAttackArrayNum = 0;
            }
        }
        if(BattleTime != PlayerAttackArrayTime[PlayerAttackArrayNum] && BattleTime == MonsterAttackArrayTime[MonsterAttackArrayNum])     //----怪物可以攻擊但角色不能攻擊
        {
            //MonsterAttackPlayer(MonsterAttackArrayNum);
            switch(MonsterCanAttack == 1)
            {
                case true:
                    {
                        Debug.Log("本次怪物戰鬥套路是第 " + (MonsterAttackArrayNum + 1) + " 招");
                        MonsterAttackCon(MonsterAttackArrayNum);
                        Debug.Log("本次怪物造成傷害為: " + MonsterAttackNom);
                        PlayerHP = PlayerHP - MonsterAttackNom;
                        Debug.Log("角色剩餘血量: " + PlayerHP);
                        MonsterAttackArrayTimeAdd(MonsterAttackArrayNum);
                        Debug.Log("下次怪物戰鬥套路是第 " + (MonsterAttackArrayNum + 2) + " 招");                      
                        break;
                    }
                case false:
                    {
                        break;
                    }
            }
            ResetMonsterRange();
            MonsterAttackArrayNum++;
            if (MonsterAttackArrayNum > 4)
            {
                MonsterAttackArrayNum = 0;
            }
        }
        if(BattleTime == PlayerAttackArrayTime[PlayerAttackArrayNum] && BattleTime == MonsterAttackArrayTime[MonsterAttackArrayNum])      //----角色跟怪物同時攻擊
        {
            //PlayerAttackMonster(PlayerAttackArrayNum);             //----檢查角色攻擊範圍是否可以攻擊到怪物
            switch (PlayerCanAttack == 1)
            {
                case true:
                    {
                        Debug.Log("本次角色戰鬥套路是第 " + (PlayerAttackArrayNum + 1) + " 招");
                        PlayerAttackCon(PlayerAttackArrayNum);
                        Debug.Log("本次角色造成傷害為: " + PlayerAttackNom);
                        MonsterHP = MonsterHP - PlayerAttackNom;
                        Debug.Log("怪物剩餘血量: " + MonsterHP);
                        PlayerAttackArrayTimeAdd(PlayerAttackArrayNum);
                        Debug.Log("下次角色戰鬥套路是第 " + (PlayerAttackArrayNum + 2) + " 招");
                        break;
                    }
                case false:
                    {
                        break;
                    }
            }
            ResetPlayerRange();
            PlayerAttackArrayNum++;
            PlayerAttackArrayNum++;
            if (PlayerAttackArrayNum > 4)
            {
                PlayerAttackArrayNum = 0;
            }

            //MonsterAttackPlayer(MonsterAttackArrayNum);            //----檢查怪物攻擊範圍是否可以攻擊到角色
            switch (MonsterCanAttack == 1)
            {
                case true:
                    {
                        Debug.Log("本次怪物戰鬥套路是第 " + (MonsterAttackArrayNum + 1) + " 招");
                        MonsterAttackCon(MonsterAttackArrayNum);
                        Debug.Log("本次怪物造成傷害為: " + MonsterAttackNom);
                        PlayerHP = PlayerHP - MonsterAttackNom;
                        Debug.Log("角色剩餘血量: " + PlayerHP);
                        MonsterAttackArrayTimeAdd(MonsterAttackArrayNum);
                        Debug.Log("下次怪物戰鬥套路是第 " + (MonsterAttackArrayNum + 2) + " 招");
                        break;
                    }
                case false:
                    {
                        break;
                    }
            }
            ResetMonsterRange();
            MonsterAttackArrayNum++;
            if (MonsterAttackArrayNum > 4)
            {
                MonsterAttackArrayNum = 0;
            }
        }

        BattleTime = BattleTime + 0.1f;
        string BattleString = BattleTime.ToString("0.0");
        BattleTime = float.Parse(BattleString);

        if(PlayerHP <= 0 && MonsterHP > 0)                         //----角色血量歸零但怪物沒有
        {
            Debug.Log("戰鬥結束，角色血量低於零，怪物勝利!");
            BattleReady();
            CancelInvoke("BattleStart");
        }
        if (MonsterHP <= 0 && PlayerHP > 0)                         //----怪物血量歸零但角色沒有
        {
            Debug.Log("戰鬥結束，怪物血量低於零，角色勝利!");
            BattleReady();
            CancelInvoke("BattleStart");
        }
        if (PlayerHP <= 0 && MonsterHP <= 0)                         //----雙方血量歸零
        {
            Debug.Log("戰鬥結束，雙方血量低於零，怪物勝利!");
            BattleReady();
            CancelInvoke("BattleStart");
        }
    }

    public void PlayerNumSetting()                                           //-----設定角色屬性跟戰鬥套路
    {
        //-----設定角色屬性跟戰鬥套路
        PlayerAttackarray = new int[5];
        PlayerAttackarray[0] = 1;
        PlayerAttackarray[1] = 2;
        PlayerAttackarray[2] = 3;
        PlayerAttackarray[3] = 4;
        PlayerAttackarray[4] = 5;
        PlayerAttackArrayNum = 0;

        PlayerADAttack = 10f;
        PlayerAPAttack = 5f;
        PlayerHP = 100f;

        PlayerAttackArrayTime = new float[5];
        //-----

        //----技能設定
        Skill_AttackNum_1 = 100;
        Skill_AttackNum_2 = 200;
        Skill_AttackNum_3 = 130;
        Skill_AttackNum_4 = 250;
        Skill_AttackNum_5 = 80;

        Skill_Time_1 = 1f;
        Skill_Time_2 = 1.5f;
        Skill_Time_3 = 1.2f;
        Skill_Time_4 = 2f;
        Skill_Time_5 = 0.7f;

        Skill_Range_1 = 1;
        Skill_Range_2 = 3;
        Skill_Range_3 = 1;
        Skill_Range_4 = 3;
        Skill_Range_5 = 1;

        Skill_ADAP_1 = 0;
        Skill_ADAP_2 = 1;
        Skill_ADAP_3 = 0;
        Skill_ADAP_4 = 1;
        Skill_ADAP_5 = 0;
        //----

        //----
        PlayerAttackArrayTime[0] = Skill_Time_1;
        PlayerAttackArrayTime[1] = PlayerAttackArrayTime[0] + Skill_Time_2;
        PlayerAttackArrayTime[2] = PlayerAttackArrayTime[1] + Skill_Time_3;
        PlayerAttackArrayTime[3] = PlayerAttackArrayTime[2] + Skill_Time_4;
        PlayerAttackArrayTime[4] = PlayerAttackArrayTime[3] + Skill_Time_5;
        //----

        //----
        PlayerCanAttack = 0;
        PlayerAttackRange = new int[5];
        PlayerAttackRange[0] = 0;
        PlayerAttackRange[1] = 0;
        PlayerAttackRange[2] = 0;
        PlayerAttackRange[3] = 0;
        PlayerAttackRange[4] = 0;
        //----
    }

    public void MonterNumSetting()                                           //-----設定怪物屬性跟戰鬥套路
    {
        //-----設定怪物屬性跟戰鬥套路
        MonsterAttackarray = new int[5];
        MonsterAttackarray[0] = 1;
        MonsterAttackarray[1] = 2;
        MonsterAttackarray[2] = 3;
        MonsterAttackarray[3] = 4;
        MonsterAttackarray[4] = 5;
        MonsterAttackArrayNum = 0;

        MonsterADAttack = 5f;
        MonsterAPAttack = 3f;
        MonsterHP = 500;

        MonsterAttackArrayTime = new float[5];
        //-----

        //----技能設定
        MonsterSkill_AttackNum_1 = 100;
        MonsterSkill_AttackNum_2 = 200;
        MonsterSkill_AttackNum_3 = 130;
        MonsterSkill_AttackNum_4 = 250;
        MonsterSkill_AttackNum_5 = 80;

        MonsterSkill_Time_1 = 1f;
        MonsterSkill_Time_2 = 1f;
        MonsterSkill_Time_3 = 1.5f;
        MonsterSkill_Time_4 = 0.5f;
        MonsterSkill_Time_5 = 0.7f;

        MonsterSkill_Range_1 = 2;
        MonsterSkill_Range_2 = 1;
        MonsterSkill_Range_3 = 1;
        MonsterSkill_Range_4 = 3;
        MonsterSkill_Range_5 = 2;

        MonsterSkill_ADAP_1 = 1;
        MonsterSkill_ADAP_2 = 0;
        MonsterSkill_ADAP_3 = 1;
        MonsterSkill_ADAP_4 = 0;
        MonsterSkill_ADAP_5 = 1;
        //----

        //----
        MonsterAttackArrayTime[0] = MonsterSkill_Time_1;
        MonsterAttackArrayTime[1] = MonsterAttackArrayTime[0] + MonsterSkill_Time_2;
        MonsterAttackArrayTime[2] = MonsterAttackArrayTime[1] + MonsterSkill_Time_3;
        MonsterAttackArrayTime[3] = MonsterAttackArrayTime[2] + MonsterSkill_Time_4;
        MonsterAttackArrayTime[4] = MonsterAttackArrayTime[3] + MonsterSkill_Time_5;
        //----

        //----
        MonsterAttackRange = new int[5];
        MonsterAttackRange[0] = 0;
        MonsterAttackRange[1] = 0;
        MonsterAttackRange[2] = 0;
        MonsterAttackRange[3] = 0;
        MonsterAttackRange[4] = 0;
        //----
    }

    public void PlayerAttackCon(int PlayerAttackNum)                         //----計算本次角色攻擊攻擊造成的傷害數值
    {
        switch(PlayerAttackNum)
        {
            case 0:
                {
                    PlayerAttackNom = PlayerADAttack * (Skill_AttackNum_1 / 100);
                    PlayerAttackNom = Mathf.Round(PlayerAttackNom);
                    break;
                }
            case 1:
                {
                    PlayerAttackNom = PlayerAPAttack * (Skill_AttackNum_2 / 100);
                    PlayerAttackNom = Mathf.Round(PlayerAttackNom);
                    break;
                }
            case 2:
                {
                    PlayerAttackNom = PlayerADAttack * (Skill_AttackNum_3 / 100);
                    PlayerAttackNom = Mathf.Round(PlayerAttackNom);
                    break;
                }
            case 3:
                {
                    PlayerAttackNom = PlayerAPAttack * (Skill_AttackNum_4 / 100);
                    PlayerAttackNom = Mathf.Round(PlayerAttackNom);
                    break;
                }
            case 4:
                {
                    PlayerAttackNom = PlayerADAttack * (Skill_AttackNum_5 / 100);
                    PlayerAttackNom = Mathf.Round(PlayerAttackNom);
                    break;
                }
            default:
                {
                    PlayerAttackNom = PlayerADAttack;
                    break;
                }
        }
    }

    public void MonsterAttackCon(int MonsterAttackNum)                       //----計算本次怪物攻擊攻擊造成的傷害數值
    {
        switch (MonsterAttackNum)
        {
            case 0:
                {
                    MonsterAttackNom = MonsterADAttack * (MonsterSkill_AttackNum_1 / 100);
                    MonsterAttackNom = Mathf.Round(MonsterAttackNom);
                    break;
                }
            case 1:
                {
                    MonsterAttackNom = MonsterAPAttack * (MonsterSkill_AttackNum_2 / 100);
                    MonsterAttackNom = Mathf.Round(MonsterAttackNom);
                    break;
                }
            case 2:
                {
                    MonsterAttackNom = MonsterADAttack * (MonsterSkill_AttackNum_3 / 100);
                    MonsterAttackNom = Mathf.Round(MonsterAttackNom);
                    break;
                }
            case 3:
                {
                    MonsterAttackNom = MonsterAPAttack * (MonsterSkill_AttackNum_4 / 100);
                    MonsterAttackNom = Mathf.Round(MonsterAttackNom);
                    break;
                }
            case 4:
                {
                    MonsterAttackNom = MonsterADAttack * (MonsterSkill_AttackNum_5 / 100);
                    MonsterAttackNom = Mathf.Round(MonsterAttackNom);
                    break;
                }
            default:
                {
                    MonsterAttackNom = MonsterADAttack;
                    break;
                }
        }
    }

    public void PlayerAttackArrayTimeAdd(int PlayerAttackNum)                //----角色攻擊後將攻擊的時間加上
    {
        switch(PlayerAttackNum)
        {
            case 0:
                {
                    PlayerAttackArrayTime[0] = PlayerAttackArrayTime[4] + Skill_Time_1;
                    break;
                }
            case 1:
                {
                    PlayerAttackArrayTime[1] = PlayerAttackArrayTime[0] + Skill_Time_2;
                    break;
                }
            case 2:
                {
                    PlayerAttackArrayTime[2] = PlayerAttackArrayTime[1] + Skill_Time_3;
                    break;
                }
            case 3:
                {
                    PlayerAttackArrayTime[3] = PlayerAttackArrayTime[2] + Skill_Time_4;
                    break;
                }
            case 4:
                {
                    PlayerAttackArrayTime[4] = PlayerAttackArrayTime[3] + Skill_Time_5;
                    break;
                }
        }
    }

    public void MonsterAttackArrayTimeAdd(int MonsterAttackNum)              //----怪物攻擊後將攻擊的時間加上
    {
        switch (MonsterAttackNum)
        {
            case 0:
                {
                    MonsterAttackArrayTime[0] = MonsterAttackArrayTime[4] + MonsterSkill_Time_1;
                    break;
                }
            case 1:
                {
                    MonsterAttackArrayTime[1] = MonsterAttackArrayTime[0] + MonsterSkill_Time_2;
                    break;
                }
            case 2:
                {
                    MonsterAttackArrayTime[2] = MonsterAttackArrayTime[1] + MonsterSkill_Time_3;
                    break;
                }
            case 3:
                {
                    MonsterAttackArrayTime[3] = MonsterAttackArrayTime[2] + MonsterSkill_Time_4;
                    break;
                }
            case 4:
                {
                    MonsterAttackArrayTime[4] = MonsterAttackArrayTime[3] + MonsterSkill_Time_5;
                    break;
                }
        }
    }

    /*public void PlayerAttackMonster(int PlayerSkillNum)                      //----檢查角色攻擊範圍是否可以攻擊到怪物
    {
        switch(PlayerSkillNum)
        {
            case 0:
                {
                    PlayerAttackRange[Player.PlayerPosition - 1] = 1;
                    MonsterPositionInPlayerRange();
                    break;
                }
            case 1:
                {
                    PlayerAttackRange[Player.PlayerPosition - 2] = 1;
                    PlayerAttackRange[Player.PlayerPosition - 1] = 1;
                    PlayerAttackRange[Player.PlayerPosition ] = 1;
                    MonsterPositionInPlayerRange();
                    break;
                }
            case 2:
                {
                    PlayerAttackRange[Player.PlayerPosition - 1] = 1;
                    MonsterPositionInPlayerRange();
                    break;
                }
            case 3:
                {
                    PlayerAttackRange[Player.PlayerPosition - 2] = 1;
                    PlayerAttackRange[Player.PlayerPosition - 1] = 1;
                    PlayerAttackRange[Player.PlayerPosition] = 1;
                    MonsterPositionInPlayerRange();
                    break;
                }
            case 4:
                {
                    PlayerAttackRange[Player.PlayerPosition - 1] = 1;
                    MonsterPositionInPlayerRange();
                    break;
                }
        }
    }*/

    /*public void MonsterPositionInPlayerRange()
    {
        switch(PlayerAttackRange[Monster.MonsterPosition - 1] == 1)
        {
            case true:
                {
                    PlayerCanAttack = 1;
                    break;
                }
            case false:
                {
                    PlayerCanAttack = 0;
                    break;
                }
        }
    }*/

    public void ResetPlayerRange()                                           //----重製角色攻擊範圍陣列
    {
        PlayerAttackRange[0] = 0;
        PlayerAttackRange[1] = 0;
        PlayerAttackRange[2] = 0;
        PlayerAttackRange[3] = 0;
        PlayerAttackRange[4] = 0;
    }

    /*public void MonsterAttackPlayer(int MonsterSkillNum)                     //----檢查角色攻擊範圍是否可以攻擊到怪物
    {
        switch (MonsterSkillNum)
        {
            case 0:
                {
                    MonsterAttackRange[Monster.MonsterPosition - 1] = 1;
                    PlayerPositionInMonsterRange();
                    break;
                }
            case 1:
                {
                    MonsterAttackRange[Monster.MonsterPosition - 2] = 1;
                    MonsterAttackRange[Monster.MonsterPosition - 1] = 1;
                    MonsterAttackRange[Monster.MonsterPosition] = 1;
                    PlayerPositionInMonsterRange();
                    break;
                }
            case 2:
                {
                    MonsterAttackRange[Monster.MonsterPosition - 1] = 1;
                    PlayerPositionInMonsterRange();
                    break;
                }
            case 3:
                {
                    MonsterAttackRange[Monster.MonsterPosition - 2] = 1;
                    MonsterAttackRange[Monster.MonsterPosition - 1] = 1;
                    MonsterAttackRange[Monster.MonsterPosition] = 1;
                    PlayerPositionInMonsterRange();
                    break;
                }
            case 4:
                {
                    MonsterAttackRange[Monster.MonsterPosition - 1] = 1;
                    PlayerPositionInMonsterRange();
                    break;
                }
        }
    }*/

    /*public void PlayerPositionInMonsterRange()
    {
        switch (MonsterAttackRange[Monster.MonsterPosition - 1] == 1)
        {
            case true:
                {
                    MonsterCanAttack = 1;
                    break;
                }
            case false:
                {
                    MonsterCanAttack = 0;
                    break;
                }
        }
    }*/

    public void ResetMonsterRange()                                          //----重製怪物攻擊範圍陣列
    {
        MonsterAttackRange[0] = 0;
        MonsterAttackRange[1] = 0;
        MonsterAttackRange[2] = 0;
        MonsterAttackRange[3] = 0;
        MonsterAttackRange[4] = 0;
    }

    public void BattleReady()                                                //----戰鬥前準備
    {
        PlayerNumSetting();
        MonterNumSetting();
        BattleTime = 0;
    }
}
