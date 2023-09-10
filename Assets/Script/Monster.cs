using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public int MonsterPosition;

    public GameObject MonsterHpObj;
    public Player PlayerObj;
    public Text MonsterPositionText;
    public Text MonsterHpText;
    public int MonsterAttackNum;
    public float MonsterAttackCDNow;
    public float MonsterAttackDamge;

    public Text MonsterAttackCDText;

    public float MonsterHp;
    public float MonsterHpNow;

    public float MonsterDageRate;
    public float MonsterArmorRate;
    public float MonsterCritRate;

    private GameObject emptyObj;

    private int[] MonsterAttackArray;
    private int MonsterAttackNumNow;
    private float MonsterAttackCD;
    private int MonsterProject;

    public GameObject Road_1;
    public GameObject Road_2;
    public GameObject Road_3;
    public GameObject Road_4;
    public GameObject Road_5;
    public GameObject ProjectileObj;
    private GameObject EmptyObj_Projectile;

    public Battle_Calculate CalculateObj;

    public void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("�Ǫ���m:" + MonsterPosition);
        MonsterPositionText.text = MonsterPosition.ToString();
        SetMonster();
        //MonsterAttackNum = Random.Range(0, 3);
        //MonsterAttackRandom();
        //MonsterAttackCDText.text = Mathf.Round(MonsterAttackCD).ToString();
        //Debug.Log("�Ǫ�����CD:" + Mathf.Round(MonsterAttackCD));

        Road_1 = GameObject.Find("Road_1");
        Road_2 = GameObject.Find("Road_2");
        Road_3 = GameObject.Find("Road_3");
        Road_4 = GameObject.Find("Road_4");
        Road_5 = GameObject.Find("Road_5");

        InvokeRepeating("MonsterAttack", 1, 1);
        PlayerObj = GameObject.Find("Player").GetComponent<Player>();
        CalculateObj = GameObject.Find("BackGround").GetComponent<Battle_Calculate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMonster()   //²��]�m�Ǫ��ƭ�
    {
        MonsterStaticToNum(MonsterPosition);
        //MonsterHp = 11f;
        //MonsterHpNow = 11f;
        MonsterHpText.text = MonsterHpNow + "/" + MonsterHp;
        MonsterAttackNumNow = 0;
        MonsterProject = 0;
        //MonsterDageRate = 0.1f;
        //MonsterArmorRate = 0.1f;
        //MonsterCritRate = 0.1f;


        MonsterAttackArray = new int[5];
        MonsterAttackArray[0] = 0;
        MonsterAttackArray[1] = 0;
        MonsterAttackArray[2] = 0;
        MonsterAttackArray[3] = 0;
        MonsterAttackArray[4] = 0;

        for (int i = 0; i < 5; i++)
        {
            int num = Random.Range(0, 4);
            MonsterAttackArray[i] = num;
            Debug.Log("�Ǫ��������ǲ�" + (i + 1) + "�Ӫ������s���O:" + MonsterAttackArray[i]);
        }
        MonsterAttackNum = MonsterAttackArray[0];
        MonsterAttackRandom();
        MonsterAttackCDText.text = Mathf.Round(MonsterAttackCD).ToString();
        Debug.Log("�Ǫ�����CD:" + Mathf.Round(MonsterAttackCD));
        Debug.Log("�Ǫ������ˮ`:" + Mathf.Round(MonsterAttackDamge));
    }

    public void Reflash()   //��s�Ǫ��ƭ�
    {
        MonsterHpText.text = MonsterHpNow + "/" + MonsterHp;
        MonsterNumToStatic(MonsterPosition);
        MonsterDie();
    }

    public void OnTriggerEnter(Collider Obj)  //�I�����g��
    {
        Debug.Log("����Ǫ��F!");
        //float takedamge = Obj.GetComponent<Projectile>().ProjectileDamge;
        /*switch (Obj.GetComponent<Projectile>().AttackType)
        {
            case 0:
                {
                    MonsterHpNow = MonsterHpNow - takedamge;
                    Reflash();
                    Destroy(Obj.gameObject);
                    break;
                }
            case 1:
                {
                    break;
                }
        }   */

        switch (Obj.tag == "Project")
        {
            case true:
                {
                    switch (Obj.GetComponent<Projectile>().AttackType)    //�]����g���|�����A�ҥH��g�����ܼ�AttackType�|�n�ϥΨ�0, 2, 3, 4, 5�A�]���u���T�w�o�X�ӡA�ҥH�������g�N�����B�z�A����A���u��
                    {
                        case 0:
                            {
                                //float takedamge = Obj.GetComponent<Projectile>().ProjectileDamge;
                                Debug.Log("�Ǫ����Q��g������!!");
                                MonsterHpNow = MonsterHpNow - Obj.GetComponent<Projectile>().ProjectileDamge;
                                Reflash();
                                Destroy(Obj.gameObject);
                                break;
                            }
                        case 2:
                            {
                                //float takedamge = Obj.GetComponent<Projectile>().ProjectileDamge;
                                Debug.Log("�Ǫ����Q��g������!!");
                                MonsterHpNow = MonsterHpNow - Obj.GetComponent<Projectile>().ProjectileDamge;
                                Reflash();
                                Destroy(Obj.gameObject);
                                break;
                            }
                        case 3:
                            {
                                //float takedamge = Obj.GetComponent<Projectile>().ProjectileDamge;
                                Debug.Log("�Ǫ����Q��g������!!");
                                MonsterHpNow = MonsterHpNow - Obj.GetComponent<Projectile>().ProjectileDamge;
                                Reflash();
                                Destroy(Obj.gameObject);
                                break;
                            }
                        case 4:
                            {
                                //float takedamge = Obj.GetComponent<Projectile>().ProjectileDamge;
                                Debug.Log("�Ǫ����Q��g������!!");
                                MonsterHpNow = MonsterHpNow - Obj.GetComponent<Projectile>().ProjectileDamge;
                                Reflash();
                                Destroy(Obj.gameObject);
                                break;
                            }
                        case 5:
                            {
                                //float takedamge = Obj.GetComponent<Projectile>().ProjectileDamge;
                                Debug.Log("�Ǫ����Q��g������!!");
                                MonsterHpNow = MonsterHpNow - Obj.GetComponent<Projectile>().ProjectileDamge;
                                Reflash();
                                Destroy(Obj.gameObject);
                                break;
                            }
                    }
                    break;
                }
            case false:
                {
                    break;
                }
        }
    }

    public void MonsterDie()    //�Ǫ����`
    {
        switch(MonsterHpNow <= 0)
        {
            case true:
                {
                    Debug.Log("�Ǫ����`!");
                    CancelInvoke("MonsterAttack");
                    emptyObj = GameObject.Find("BackGround");
                    emptyObj.GetComponent<Battle_Second>().MonsterNum--;
                    switch (emptyObj.GetComponent<Battle_Second>().MonsterNum == 0)   //�ΨӧP�_���W�Ǫ��Ѿl�X��
                    {
                        case true:
                            {
                                Debug.Log("�Ǫ����Ʀ��`");
                                emptyObj.GetComponent<Battle_Second>().MonsterWaveNum++;
                                emptyObj.GetComponent<Battle_Second>().BattleEndDeleteProjectile();
                                switch (emptyObj.GetComponent<Battle_Second>().MonsterWaveNum == 3)
                                {
                                    case true:
                                        {
                                            emptyObj.GetComponent<Battle_Second>().MonsterWaveNum = 0;
                                            emptyObj.GetComponent<Battle_Second>().WavePauseNum = 2;
                                            break;
                                        }
                                    case false:
                                        {
                                            break;
                                        }
                                }
                                emptyObj.GetComponent<Battle_Second>().WavePause();
                                break;
                            }
                        case false:
                            {
                                Debug.Log("�Ǫ��ѤU:" + emptyObj.GetComponent<Battle_Second>().MonsterNum + "��");
                                break;
                            }
                    }
                    Destroy(gameObject);
                    break;
                }
            case false:
                {
                    break;
                }
        }
    }

    public void MonsterAttackRandom()   //�Ǫ��������e�H��
    {
        switch (MonsterAttackNum)
        {
            case 0:
                {
                    MonsterAttackCD = 3f;
                    MonsterAttackCDNow = 3f;
                    MonsterAttackDamge = 2f;
                    MonsterProject = 0;
                    break;
                }
            case 1:
                {
                    MonsterAttackCD = 2f;
                    MonsterAttackCDNow = 2f;
                    MonsterAttackDamge = 1f;
                    MonsterProject = 1;
                    break;
                }
            case 2:
                {
                    MonsterAttackCD = 5f;
                    MonsterAttackCDNow = 5f;
                    MonsterAttackDamge = 5f;
                    MonsterProject = 1;
                    break;
                }
            case 3:
                {
                    MonsterAttackCD = 5f;
                    MonsterAttackCDNow = 5f;
                    MonsterAttackDamge = 5f;
                    MonsterProject = 1;
                    break;
                }
        }
    }

    public void MonsterAttack()        //�Ǫ�����
    {
        float MonsterTrueDamge = 0;
        MonsterAttackCDNow = Mathf.Round(MonsterAttackCDNow) - 1f;
        MonsterAttackCDText.text = Mathf.Round(MonsterAttackCDNow).ToString();
        switch (MonsterAttackCDNow == 0)
        {
            case true:
                {                   
                    switch(Player.PlayerPosition == MonsterPosition)     //�P�_�Ǫ��򪱮a�O�_�b�P�@��m
                    {
                        case true:
                            {
                                switch(MonsterProject == 1)
                                {
                                    case true:
                                        {
                                            Debug.Log("���a�Q��g�������A��g���|�y��" + MonsterAttackDamge + "�ˮ`");
                                            MonsterProjectAttack();
                                            break;
                                        }
                                    case false:
                                        {
                                            Debug.Log("���a�Q�����A����" + MonsterAttackDamge + "�ˮ`");
                                            switch(PlayerObj.Cover_PlayerNow == 1)    //�P�_���a�O�_�b�L�Ī��A
                                            {
                                                case true:
                                                    {
                                                        break;
                                                    }
                                                case false:
                                                    {
                                                        CalculateObj.CalulatePlayerArmor(MonsterAttackDamge, out MonsterTrueDamge);
                                                        Json_Battle_Static.HpNow = Json_Battle_Static.HpNow - MonsterTrueDamge;
                                                        break;
                                                    }
                                            }                                            
                                            PlayerObj.Reflash();
                                            break;
                                        }
                                }                                
                                break;
                            }
                        case false:
                            {
                                switch (MonsterProject == 1)   //�P�_�Y�Ϫ��a��Ǫ����b�P�@��m�W�A���O�����O��g���]�n����
                                {
                                    case true:
                                        {
                                            MonsterProjectAttack();
                                            break;
                                        }
                                    case false:
                                        {
                                            break;
                                        }
                                }
                                PlayerObj.Reflash();
                                break;
                            }
                    }
                    MonsterAttackNumNow++;
                    switch (MonsterAttackNumNow == 5)
                    {
                        case true:
                            {
                                MonsterAttackNumNow = 0;
                                break;
                            }
                        case false:
                            {
                                break;
                            }
                    }
                    MonsterAttackNum = MonsterAttackArray[MonsterAttackNumNow];
                    MonsterAttackRandom();
                    break;
                }
            case false:
                {
                    break;
                }
        }
    }

    public void MonsterProjectAttack()   //�Ǫ��ϥΧ�g������
    {
        GameObject RoadSpwan = Road_3;
        switch (MonsterPosition)
        {
            case 1:
                {
                    RoadSpwan = Road_1;
                    break;
                }
            case 2:
                {
                    RoadSpwan = Road_2;
                    break;
                }
            case 3:
                {
                    RoadSpwan = Road_3;
                    break;
                }
            case 4:
                {
                    RoadSpwan = Road_4;
                    break;
                }
            case 5:
                {
                    RoadSpwan = Road_5;
                    break;
                }
        }
        EmptyObj_Projectile = Instantiate(ProjectileObj, RoadSpwan.transform);
        EmptyObj_Projectile.GetComponent<Projectile>().AttackType = 1;
        EmptyObj_Projectile.GetComponent<Projectile>().ProjectileDamge = MonsterAttackDamge;
        EmptyObj_Projectile.transform.localPosition = new Vector3(0, 770, 0);
        //EmptyObj_Projectile.GetComponent<Projectile>().ProjectileNum = PlayerSkillNum;  �o�q�O�O�d������o�ӧ����|�h�Y�ޯ�s��
    }

    public void MonsterStaticToNum(int MonsterPotionNum)  //�N�Ǫ����R�A������ܦ��o��Ǫ����ݩʼƭ�
    {
        switch (MonsterPotionNum)
        {
            case 1:
                {
                    MonsterHp = Json_Battle_Monster_Static.MonsterHp_1;
                    MonsterHpNow = Json_Battle_Monster_Static.MonsterHpNow_1;
                    MonsterDageRate = Json_Battle_Monster_Static.MonsterArmorRate_1;
                    MonsterArmorRate = Json_Battle_Monster_Static.MonsterDodgeRate_1;
                    MonsterCritRate = Json_Battle_Monster_Static.MonsterCritRate_1;
                    break;
                }
            case 2:
                {
                    MonsterHp = Json_Battle_Monster_Static.MonsterHp_2;
                    MonsterHpNow = Json_Battle_Monster_Static.MonsterHpNow_2;
                    MonsterDageRate = Json_Battle_Monster_Static.MonsterArmorRate_2;
                    MonsterArmorRate = Json_Battle_Monster_Static.MonsterDodgeRate_2;
                    MonsterCritRate = Json_Battle_Monster_Static.MonsterCritRate_2;
                    break;
                }
            case 3:
                {
                    MonsterHp = Json_Battle_Monster_Static.MonsterHp_3;
                    MonsterHpNow = Json_Battle_Monster_Static.MonsterHpNow_3;
                    MonsterDageRate = Json_Battle_Monster_Static.MonsterArmorRate_3;
                    MonsterArmorRate = Json_Battle_Monster_Static.MonsterDodgeRate_3;
                    MonsterCritRate = Json_Battle_Monster_Static.MonsterCritRate_3;
                    break;
                }
            case 4:
                {
                    MonsterHp = Json_Battle_Monster_Static.MonsterHp_4;
                    MonsterHpNow = Json_Battle_Monster_Static.MonsterHpNow_4;
                    MonsterDageRate = Json_Battle_Monster_Static.MonsterArmorRate_4;
                    MonsterArmorRate = Json_Battle_Monster_Static.MonsterDodgeRate_4;
                    MonsterCritRate = Json_Battle_Monster_Static.MonsterCritRate_4;
                    break;
                }
            case 5:
                {
                    MonsterHp = Json_Battle_Monster_Static.MonsterHp_5;
                    MonsterHpNow = Json_Battle_Monster_Static.MonsterHpNow_5;
                    MonsterDageRate = Json_Battle_Monster_Static.MonsterArmorRate_5;
                    MonsterArmorRate = Json_Battle_Monster_Static.MonsterDodgeRate_5;
                    MonsterCritRate = Json_Battle_Monster_Static.MonsterCritRate_5;
                    break;
                }
        }
        Debug.Log("���\�N�Ǫ����R�A������ܦ��o��Ǫ����ݩʼƭ�");
    }

    public void MonsterNumToStatic(int MonsterPotionNum)  //�N�o��Ǫ����ݩʼƭ����ܦ��Ǫ����R�A���
    {
        switch (MonsterPotionNum)
        {
            case 1:
                {
                    Json_Battle_Monster_Static.MonsterHp_1 = MonsterHp;
                    Json_Battle_Monster_Static.MonsterHpNow_1 = MonsterHpNow;
                    Json_Battle_Monster_Static.MonsterArmorRate_1 = MonsterDageRate;
                    Json_Battle_Monster_Static.MonsterDodgeRate_1 = MonsterArmorRate;
                    Json_Battle_Monster_Static.MonsterCritRate_1 = MonsterCritRate;
                    break;
                }
            case 2:
                {
                    Json_Battle_Monster_Static.MonsterHp_2 = MonsterHp;
                    Json_Battle_Monster_Static.MonsterHpNow_2 = MonsterHpNow;
                    Json_Battle_Monster_Static.MonsterArmorRate_2 = MonsterDageRate;
                    Json_Battle_Monster_Static.MonsterDodgeRate_2 = MonsterArmorRate;
                    Json_Battle_Monster_Static.MonsterCritRate_2 = MonsterCritRate;
                    break;
                }
            case 3:
                {
                    Json_Battle_Monster_Static.MonsterHp_3 = MonsterHp;
                    Json_Battle_Monster_Static.MonsterHpNow_3 = MonsterHpNow;
                    Json_Battle_Monster_Static.MonsterArmorRate_3 = MonsterDageRate;
                    Json_Battle_Monster_Static.MonsterDodgeRate_3 = MonsterArmorRate;
                    Json_Battle_Monster_Static.MonsterCritRate_3 = MonsterCritRate;
                    break;
                }
            case 4:
                {
                    Json_Battle_Monster_Static.MonsterHp_4 = MonsterHp;
                    Json_Battle_Monster_Static.MonsterHpNow_4 = MonsterHpNow;
                    Json_Battle_Monster_Static.MonsterArmorRate_4 = MonsterDageRate;
                    Json_Battle_Monster_Static.MonsterDodgeRate_4 = MonsterArmorRate;
                    Json_Battle_Monster_Static.MonsterCritRate_4 = MonsterCritRate;
                    break;
                }
            case 5:
                {
                    Json_Battle_Monster_Static.MonsterHp_5 = MonsterHp;
                    Json_Battle_Monster_Static.MonsterHpNow_5 = MonsterHpNow;
                    Json_Battle_Monster_Static.MonsterArmorRate_5 = MonsterDageRate;
                    Json_Battle_Monster_Static.MonsterDodgeRate_5 = MonsterArmorRate;
                    Json_Battle_Monster_Static.MonsterCritRate_5 = MonsterCritRate;
                    break;
                }
        }
        Debug.Log("���\�N�o��Ǫ����ݩʼƭ����ܦ��Ǫ����R�A���" + "\n" + "�өǪ�����m" + MonsterPotionNum);
    }
}
