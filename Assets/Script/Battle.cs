using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    //----��������ƭ�
    public int[] PlayerAttackarray;
    public float PlayerADAttack;
    public float PlayerAPAttack;
    public float PlayerHP;
    public int PlayerAttackArrayNum;
    public float PlayerAttackNom;
    public int[] PlayerAttackRange;
    public int PlayerCanAttack;              //----�P�_����O�_��������Ǫ��A0 = �S���A1 = ��
    //----

    //----����ޯ����%��
    public float Skill_AttackNum_1;
    public float Skill_AttackNum_2;
    public float Skill_AttackNum_3;
    public float Skill_AttackNum_4;
    public float Skill_AttackNum_5;
    //----

    //----����ޯ�ϥά��
    public float Skill_Time_1;
    public float Skill_Time_2;
    public float Skill_Time_3;
    public float Skill_Time_4;
    public float Skill_Time_5;
    //----

    //----����ޯ�����d��
    public int Skill_Range_1;
    public int Skill_Range_2;
    public int Skill_Range_3;
    public int Skill_Range_4;
    public int Skill_Range_5;
    //----

    //----����ޯ������A0 = ���z�A1 = �]�k
    public int Skill_ADAP_1;
    public int Skill_ADAP_2;
    public int Skill_ADAP_3;
    public int Skill_ADAP_4;
    public int Skill_ADAP_5;
    //----

    //----���Ⱶ�U�ӧޯ�ϥΪ����
    public float[] PlayerAttackArrayTime;
    //----

    //----�Ǫ������ƭ�
    public int[] MonsterAttackarray;
    public float MonsterADAttack;
    public float MonsterAPAttack;
    public float MonsterHP;
    public int MonsterAttackArrayNum;
    public float MonsterAttackNom;
    public int[] MonsterAttackRange;
    public int MonsterCanAttack;              //----�P�_�Ǫ��O�_�������쨤��A0 = �S���A1 = ��
    //----

    //----�Ǫ��ޯ����%��
    public float MonsterSkill_AttackNum_1;
    public float MonsterSkill_AttackNum_2;
    public float MonsterSkill_AttackNum_3;
    public float MonsterSkill_AttackNum_4;
    public float MonsterSkill_AttackNum_5;
    //----

    //----�Ǫ��ޯ�ϥά��
    public float MonsterSkill_Time_1;
    public float MonsterSkill_Time_2;
    public float MonsterSkill_Time_3;
    public float MonsterSkill_Time_4;
    public float MonsterSkill_Time_5;
    //----

    //----�Ǫ��ޯ�����d��
    public int MonsterSkill_Range_1;
    public int MonsterSkill_Range_2;
    public int MonsterSkill_Range_3;
    public int MonsterSkill_Range_4;
    public int MonsterSkill_Range_5;
    //----

    //----�Ǫ��ޯ������A0 = ���z�A1 = �]�k
    public int MonsterSkill_ADAP_1;
    public int MonsterSkill_ADAP_2;
    public int MonsterSkill_ADAP_3;
    public int MonsterSkill_ADAP_4;
    public int MonsterSkill_ADAP_5;
    //----

    //----�Ǫ����U�ӧޯ�ϥΪ����
    public float[] MonsterAttackArrayTime;
    //----

    //----�԰������ƭ�
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
        Debug.Log("��e�ɶ�:" + BattleTime);
        if(PlayerAttackArrayNum == 4)
        {
            PlayerAttackArrayNum = 0;
        }
        if (MonsterAttackArrayNum == 4)
        {
            MonsterAttackArrayNum = 0;
        }
        if (BattleTime == PlayerAttackArrayTime[PlayerAttackArrayNum] && BattleTime != MonsterAttackArrayTime[MonsterAttackArrayNum])    //----����i�H�������Ǫ��������
        {
            //PlayerAttackMonster(PlayerAttackArrayNum);             //----�ˬd��������d��O�_�i�H������Ǫ�
            switch(PlayerCanAttack == 1)
            {
                case true:
                    {
                        Debug.Log("��������԰��M���O�� " + (PlayerAttackArrayNum + 1) + " ��");
                        PlayerAttackCon(PlayerAttackArrayNum);
                        Debug.Log("��������y���ˮ`��: " + PlayerAttackNom);
                        MonsterHP = MonsterHP - PlayerAttackNom;
                        Debug.Log("�Ǫ��Ѿl��q: " + MonsterHP);
                        PlayerAttackArrayTimeAdd(PlayerAttackArrayNum);
                        Debug.Log("�U������԰��M���O�� " + (PlayerAttackArrayNum + 2) + " ��");
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
        if(BattleTime != PlayerAttackArrayTime[PlayerAttackArrayNum] && BattleTime == MonsterAttackArrayTime[MonsterAttackArrayNum])     //----�Ǫ��i�H���������⤣�����
        {
            //MonsterAttackPlayer(MonsterAttackArrayNum);
            switch(MonsterCanAttack == 1)
            {
                case true:
                    {
                        Debug.Log("�����Ǫ��԰��M���O�� " + (MonsterAttackArrayNum + 1) + " ��");
                        MonsterAttackCon(MonsterAttackArrayNum);
                        Debug.Log("�����Ǫ��y���ˮ`��: " + MonsterAttackNom);
                        PlayerHP = PlayerHP - MonsterAttackNom;
                        Debug.Log("����Ѿl��q: " + PlayerHP);
                        MonsterAttackArrayTimeAdd(MonsterAttackArrayNum);
                        Debug.Log("�U���Ǫ��԰��M���O�� " + (MonsterAttackArrayNum + 2) + " ��");                      
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
        if(BattleTime == PlayerAttackArrayTime[PlayerAttackArrayNum] && BattleTime == MonsterAttackArrayTime[MonsterAttackArrayNum])      //----�����Ǫ��P�ɧ���
        {
            //PlayerAttackMonster(PlayerAttackArrayNum);             //----�ˬd��������d��O�_�i�H������Ǫ�
            switch (PlayerCanAttack == 1)
            {
                case true:
                    {
                        Debug.Log("��������԰��M���O�� " + (PlayerAttackArrayNum + 1) + " ��");
                        PlayerAttackCon(PlayerAttackArrayNum);
                        Debug.Log("��������y���ˮ`��: " + PlayerAttackNom);
                        MonsterHP = MonsterHP - PlayerAttackNom;
                        Debug.Log("�Ǫ��Ѿl��q: " + MonsterHP);
                        PlayerAttackArrayTimeAdd(PlayerAttackArrayNum);
                        Debug.Log("�U������԰��M���O�� " + (PlayerAttackArrayNum + 2) + " ��");
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

            //MonsterAttackPlayer(MonsterAttackArrayNum);            //----�ˬd�Ǫ������d��O�_�i�H�����쨤��
            switch (MonsterCanAttack == 1)
            {
                case true:
                    {
                        Debug.Log("�����Ǫ��԰��M���O�� " + (MonsterAttackArrayNum + 1) + " ��");
                        MonsterAttackCon(MonsterAttackArrayNum);
                        Debug.Log("�����Ǫ��y���ˮ`��: " + MonsterAttackNom);
                        PlayerHP = PlayerHP - MonsterAttackNom;
                        Debug.Log("����Ѿl��q: " + PlayerHP);
                        MonsterAttackArrayTimeAdd(MonsterAttackArrayNum);
                        Debug.Log("�U���Ǫ��԰��M���O�� " + (MonsterAttackArrayNum + 2) + " ��");
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

        if(PlayerHP <= 0 && MonsterHP > 0)                         //----�����q�k�s���Ǫ��S��
        {
            Debug.Log("�԰������A�����q�C��s�A�Ǫ��ӧQ!");
            BattleReady();
            CancelInvoke("BattleStart");
        }
        if (MonsterHP <= 0 && PlayerHP > 0)                         //----�Ǫ���q�k�s������S��
        {
            Debug.Log("�԰������A�Ǫ���q�C��s�A����ӧQ!");
            BattleReady();
            CancelInvoke("BattleStart");
        }
        if (PlayerHP <= 0 && MonsterHP <= 0)                         //----�����q�k�s
        {
            Debug.Log("�԰������A�����q�C��s�A�Ǫ��ӧQ!");
            BattleReady();
            CancelInvoke("BattleStart");
        }
    }

    public void PlayerNumSetting()                                           //-----�]�w�����ݩʸ�԰��M��
    {
        //-----�]�w�����ݩʸ�԰��M��
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

        //----�ޯ�]�w
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

    public void MonterNumSetting()                                           //-----�]�w�Ǫ��ݩʸ�԰��M��
    {
        //-----�]�w�Ǫ��ݩʸ�԰��M��
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

        //----�ޯ�]�w
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

    public void PlayerAttackCon(int PlayerAttackNum)                         //----�p�⥻��������������y�����ˮ`�ƭ�
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

    public void MonsterAttackCon(int MonsterAttackNum)                       //----�p�⥻���Ǫ����������y�����ˮ`�ƭ�
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

    public void PlayerAttackArrayTimeAdd(int PlayerAttackNum)                //----���������N�������ɶ��[�W
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

    public void MonsterAttackArrayTimeAdd(int MonsterAttackNum)              //----�Ǫ�������N�������ɶ��[�W
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

    /*public void PlayerAttackMonster(int PlayerSkillNum)                      //----�ˬd��������d��O�_�i�H������Ǫ�
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

    public void ResetPlayerRange()                                           //----���s��������d��}�C
    {
        PlayerAttackRange[0] = 0;
        PlayerAttackRange[1] = 0;
        PlayerAttackRange[2] = 0;
        PlayerAttackRange[3] = 0;
        PlayerAttackRange[4] = 0;
    }

    /*public void MonsterAttackPlayer(int MonsterSkillNum)                     //----�ˬd��������d��O�_�i�H������Ǫ�
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

    public void ResetMonsterRange()                                          //----���s�Ǫ������d��}�C
    {
        MonsterAttackRange[0] = 0;
        MonsterAttackRange[1] = 0;
        MonsterAttackRange[2] = 0;
        MonsterAttackRange[3] = 0;
        MonsterAttackRange[4] = 0;
    }

    public void BattleReady()                                                //----�԰��e�ǳ�
    {
        PlayerNumSetting();
        MonterNumSetting();
        BattleTime = 0;
    }
}
