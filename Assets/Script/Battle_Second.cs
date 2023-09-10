using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Second : MonoBehaviour
{
    //public Text MonsterHpText;

    public GameObject MonsterSpwan;
    public GameObject MonsterObj;
    private GameObject EmptyObj;

    public int[] MonsterSpwanNumList;
    public int MonsterNum;

    public int MonsterWaveNum;
    private int[] MonsterWaveArray;

    public Text MonsterWaveText;

    public GameObject CoverObj;
    public Text WaveCountText;
    private int WaveCountNum;

    public GameObject Load_Pause;
    public int WavePauseNum;
    public GameObject Button_WavePause;
    public GameObject Load_WavePause;

    private GameObject PlayerObj;

    private void Awake()
    {
        WavePauseNum = 2;
        WavePause();
        //CoverWaveCount();
        //SetMonsterWave();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMonsterWave()    //�ͦ��C�i�Ǫ����ƶq
    {
        MonsterWaveNum = 0;
        MonsterWaveArray = new int[3];
        for(int i = 0; i < 3; i++)
        {
            MonsterWaveArray[i] = Random.Range(1, 5);
            Debug.Log("��" + (i + 1) +"�i�ĤH�ƶq:" + MonsterWaveArray[i]);
        }

        MonsterWaveText.text = "Wave:" + (MonsterWaveNum + 1) + "/3";
        //SetMonster();
    }

    public void SetMonster()    //�ͦ��Ǫ�
    {
        switch(MonsterWaveNum == 3)   //�ΨӧP�_�Ǫ��i�ơA��i�ƨ�3�ɡA�}�C�w�g�W�L�i�ơA�ҥH�k�s�A����|�a�JŪ��A��Ū�����d���Ǫ��i�Ƭ���?
        {
            case true:
                {
                    Debug.Log("�o�ӷ|���|�QĲ�o��????");
                    MonsterWaveNum = 0;
                    break;
                }
            case false:
                {
                    break;
                }
        }

        MonsterWaveText.text = "Wave:" + (MonsterWaveNum + 1) + "/3";   //��ܸӪi�Ǫ��O�ĴX�i

        switch(WaveCountNum == 0)     //�Ψ������i�ƭ˼����
        {
            case true:
                {
                    Invoke("CancelWaveCount", 1);
                    Debug.Log("Ĳ�o���Ĳ�o���Ĳ�o���");
                    break;
                }
            case false:
                {
                    break;
                }
        }

        MonsterSpwanNumList = new int[5];
        MonsterSpwanNumList[0] = 3;
        MonsterSpwanNumList[1] = 0;
        MonsterSpwanNumList[2] = 0;
        MonsterSpwanNumList[3] = 0;
        MonsterSpwanNumList[4] = 0;

        MonsterNum = MonsterWaveArray[MonsterWaveNum];
        Debug.Log("�Ǫ��ͦ�" + MonsterNum + "��");
        MonsterSpwanNum(MonsterNum);
        Debug.Log("�Ǫ��}�C" + MonsterSpwanNumList[0] + " - " + MonsterSpwanNumList[1] + " - " + MonsterSpwanNumList[2] + " - " + MonsterSpwanNumList[3] + " - " + MonsterSpwanNumList[4]);
        for (int i = 0; i < MonsterNum; i++)
        {
            Debug.Log("�Ʀr:" + i);
            Debug.Log("��e�ͦ��Ǫ��s��:" + MonsterSpwanNumList[i]);
            EmptyObj = Instantiate(MonsterObj, MonsterSpwan.transform);
            MonsterPosition(MonsterSpwanNumList[i]);
            EmptyObj.name = "Monster_" + MonsterSpwanNumList[i];
            EmptyObj.GetComponent<Monster>().MonsterPosition = MonsterSpwanNumList[i];
            MonsterStaticSet(MonsterSpwanNumList[i]);
        }
    }

    public void MonsterPosition(int MonsterNum)  //��ͦ��Ǫ��ɡA�T�w�Ǫ��ͦ������T��m
    {
        switch(MonsterNum)
        {
            case 1:
                {
                    EmptyObj.transform.localPosition = new Vector3(-640, 290, 0);
                    break;
                }
            case 2:
                {
                    EmptyObj.transform.localPosition = new Vector3(-320, 290, 0);
                    break;
                }
            case 3:
                {
                    EmptyObj.transform.localPosition = new Vector3(0, 290, 0);
                    break;
                }
            case 4:
                {
                    EmptyObj.transform.localPosition = new Vector3(320, 290, 0);
                    break;
                }
            case 5:
                {
                    EmptyObj.transform.localPosition = new Vector3(640, 290, 0);
                    break;
                }
        }
    }

    public void MonsterSpwanNum(int MonsterNum)  //�̷өǪ��ͦ��ƶq�M�w���H���ͦ��b���Ǧ�m
    {     
        switch (MonsterNum)
        {
            case 1:
                {
                    break;
                }
            case 2:
                {
                    int num = Random.Range(1, 5);
                    MonsterSpwanNumList[1] = num;
                    while (num == 3 || num == 1)
                    {
                        num = Random.Range(1, 5);
                        MonsterSpwanNumList[1] = num;
                    }
                    break;
                }
            case 3:
                {
                    MonsterSpwanNumList[1] = 2;
                    MonsterSpwanNumList[2] = 4;
                    break;
                }
            case 4:
                {
                    MonsterSpwanNumList[1] = 2;
                    MonsterSpwanNumList[2] = 4;
                    int num = Random.Range(1, 6);
                    MonsterSpwanNumList[3] = num;
                    while (num == 3 || num == 2 || num == 4)
                    {
                        num = Random.Range(1, 6);
                        MonsterSpwanNumList[3] = num;
                    }
                    break;
                }
            case 5:
                {
                    MonsterSpwanNumList[1] = 2;
                    MonsterSpwanNumList[2] = 4;
                    MonsterSpwanNumList[3] = 1;
                    MonsterSpwanNumList[4] = 5;
                    break;
                }
        }
    }

    public void CoverWaveCount()    //�Ψ���ܨC�i�԰��e������
    {
        CoverObj.SetActive(true);
        WaveCountNum = 3;
        InvokeRepeating("WaveCount", 0, 1);
        Invoke("SetMonster", 3);
    }

    public void WaveCount()   //�Ψ���ܨC�i�԰��e���˼�
    {
        switch(WaveCountNum == 0)
        {
            case true:
                {
                    WaveCountText.text = "Start";
                    break;
                }
            case false:
                {
                    WaveCountText.text = WaveCountNum.ToString();
                    break;
                }
        }
        WaveCountNum--;
    }

    public void CancelWaveCount()     //�����C�i�Ǫ��˼ƪ�����
    {
        CoverObj.SetActive(false);
        CancelInvoke("WaveCount");
    }

    public void ClickPause()   //�I���Ȱ����s
    {
        Load_Pause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClickClosePause()     //�I���~����s
    {
        Load_Pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ClickWavePause()    //�Ŀ�O�_�C�i�Ǫ����n�Ȱ������s
    {
        Debug.Log("���Ӧ�Ĳ�o��t?" + WavePauseNum);
        switch (WavePauseNum)
        {
            case 0:
                {
                    Debug.Log("��Ĳ�o��o�̶�?");
                    Button_WavePause.SetActive(true);
                    WavePauseNum = 1;
                    break;
                }
            case 1:
                {
                    Button_WavePause.SetActive(false);
                    WavePauseNum = 0;
                    break;
                }
        }
    }

    public void WavePause()   //�C�i�Ǫ������I�n�Ȱ���ܪ�
    {
        switch(WavePauseNum)
        {
            case 0:
                {
                    CoverWaveCount();
                    break;
                }
            case 1:
                {
                    Load_WavePause.SetActive(true);
                    Time.timeScale = 0f;
                    break;
                }
            case 2:
                {
                    SetMonsterWave();
                    PlayerObj = GameObject.Find("Player");
                    PlayerObj.GetComponent<Player>().ClearPlayerSkillCD();
                    Load_WavePause.SetActive(true);
                    Time.timeScale = 0f;
                    Button_WavePause.SetActive(false);
                    WavePauseNum = 0;
                    break;
                }
            case 3:
                {
                    DeleteProjectile(MonsterSpwan.transform.childCount, MonsterSpwan);    //�M�ũҦ��Ǫ�
                    BattleEndDeleteProjectile();  //�M�ŧ�g��
                    Json_Battle_Static.HpNow = Json_Battle_Static.Hp;
                    PlayerObj.GetComponent<Player>().Reflash();
                    PlayerObj.GetComponent<Player>().ClearPlayerSkillCD();
                    Load_WavePause.SetActive(true);
                    Time.timeScale = 0f;
                    Button_WavePause.SetActive(false);
                    WavePauseNum = 0;
                    break;
                }
        }
    }

    public void CliskWavePauseBattleStart()    //�I���C�i�Ǫ������I�Ȱ��̭��}�l�԰������s
    {
        Load_WavePause.SetActive(false);
        Time.timeScale = 1f;
        CoverWaveCount();
    }

    public void BattleEndDeleteProjectile()    //��԰�������Ǫ����`��n���g���M��
    {
        PlayerObj = GameObject.Find("Player");
        DeleteProjectile(PlayerObj.GetComponent<Player>().Road_1.gameObject.transform.childCount, PlayerObj.GetComponent<Player>().Road_1);
        DeleteProjectile(PlayerObj.GetComponent<Player>().Road_2.gameObject.transform.childCount, PlayerObj.GetComponent<Player>().Road_2);
        DeleteProjectile(PlayerObj.GetComponent<Player>().Road_3.gameObject.transform.childCount, PlayerObj.GetComponent<Player>().Road_3);
        DeleteProjectile(PlayerObj.GetComponent<Player>().Road_4.gameObject.transform.childCount, PlayerObj.GetComponent<Player>().Road_4);
        DeleteProjectile(PlayerObj.GetComponent<Player>().Road_5.gameObject.transform.childCount, PlayerObj.GetComponent<Player>().Road_5);
    }

    public void DeleteProjectile(int ChildCount, GameObject ProjectileObj)
    {
        for(int i = 0; i < ChildCount; i++)
        {
            Destroy(ProjectileObj.transform.GetChild(i).gameObject);
        }
    }

    public void MonsterStaticSet(int MonsterPotionNum)   //�]�m�Ǫ��R�A��ơA�b�԰����N�i�H�եγo�̪���ơA�קK��Ʒ|�����P�����p
    {
        switch(MonsterPotionNum) 
        {
            case 1:
                {
                    Json_Battle_Monster_Static.MonsterHp_1 = 10f;
                    Json_Battle_Monster_Static.MonsterHpNow_1 = 10f;
                    Json_Battle_Monster_Static.MonsterArmorRate_1 = 0.1f;
                    Json_Battle_Monster_Static.MonsterDodgeRate_1 = 0.1f;
                    Json_Battle_Monster_Static.MonsterCritRate_1 = 0.1f;
                    break;
                }
            case 2:
                {
                    Json_Battle_Monster_Static.MonsterHp_2 = 10f;
                    Json_Battle_Monster_Static.MonsterHpNow_2 = 10f;
                    Json_Battle_Monster_Static.MonsterArmorRate_2 = 0.1f;
                    Json_Battle_Monster_Static.MonsterDodgeRate_2 = 0.1f;
                    Json_Battle_Monster_Static.MonsterCritRate_2 = 0.1f;
                    break;
                }
            case 3:
                {
                    Json_Battle_Monster_Static.MonsterHp_3 = 10f;
                    Json_Battle_Monster_Static.MonsterHpNow_3 = 10f;
                    Json_Battle_Monster_Static.MonsterArmorRate_3 = 0.1f;
                    Json_Battle_Monster_Static.MonsterDodgeRate_3 = 0.1f;
                    Json_Battle_Monster_Static.MonsterCritRate_3 = 0.1f;
                    break;
                }
            case 4:
                {
                    Json_Battle_Monster_Static.MonsterHp_4 = 10f;
                    Json_Battle_Monster_Static.MonsterHpNow_4 = 10f;
                    Json_Battle_Monster_Static.MonsterArmorRate_4 = 0.1f;
                    Json_Battle_Monster_Static.MonsterDodgeRate_4 = 0.1f;
                    Json_Battle_Monster_Static.MonsterCritRate_4 = 0.1f;
                    break;
                }
            case 5:
                {
                    Json_Battle_Monster_Static.MonsterHp_5 = 10f;
                    Json_Battle_Monster_Static.MonsterHpNow_5 = 10f;
                    Json_Battle_Monster_Static.MonsterArmorRate_5 = 0.1f;
                    Json_Battle_Monster_Static.MonsterDodgeRate_5 = 0.1f;
                    Json_Battle_Monster_Static.MonsterCritRate_5 = 0.1f;
                    break;
                }
        }
    }
}
