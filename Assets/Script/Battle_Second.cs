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

    public void SetMonsterWave()    //生成每波怪物的數量
    {
        MonsterWaveNum = 0;
        MonsterWaveArray = new int[3];
        for(int i = 0; i < 3; i++)
        {
            MonsterWaveArray[i] = Random.Range(1, 5);
            Debug.Log("第" + (i + 1) +"波敵人數量:" + MonsterWaveArray[i]);
        }

        MonsterWaveText.text = "Wave:" + (MonsterWaveNum + 1) + "/3";
        //SetMonster();
    }

    public void SetMonster()    //生成怪物
    {
        switch(MonsterWaveNum == 3)   //用來判斷怪物波數，當波數到3時，陣列已經超過波數，所以歸零，之後會帶入讀表，來讀該關卡的怪物波數為何?
        {
            case true:
                {
                    Debug.Log("這個會不會被觸發到????");
                    MonsterWaveNum = 0;
                    break;
                }
            case false:
                {
                    break;
                }
        }

        MonsterWaveText.text = "Wave:" + (MonsterWaveNum + 1) + "/3";   //顯示該波怪物是第幾波

        switch(WaveCountNum == 0)     //用來關閉波數倒數顯示
        {
            case true:
                {
                    Invoke("CancelWaveCount", 1);
                    Debug.Log("觸發到喔觸發到喔觸發到喔");
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
        Debug.Log("怪物生成" + MonsterNum + "隻");
        MonsterSpwanNum(MonsterNum);
        Debug.Log("怪物陣列" + MonsterSpwanNumList[0] + " - " + MonsterSpwanNumList[1] + " - " + MonsterSpwanNumList[2] + " - " + MonsterSpwanNumList[3] + " - " + MonsterSpwanNumList[4]);
        for (int i = 0; i < MonsterNum; i++)
        {
            Debug.Log("數字:" + i);
            Debug.Log("當前生成怪物編號:" + MonsterSpwanNumList[i]);
            EmptyObj = Instantiate(MonsterObj, MonsterSpwan.transform);
            MonsterPosition(MonsterSpwanNumList[i]);
            EmptyObj.name = "Monster_" + MonsterSpwanNumList[i];
            EmptyObj.GetComponent<Monster>().MonsterPosition = MonsterSpwanNumList[i];
            MonsterStaticSet(MonsterSpwanNumList[i]);
        }
    }

    public void MonsterPosition(int MonsterNum)  //當生成怪物時，確定怪物生成的正確位置
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

    public void MonsterSpwanNum(int MonsterNum)  //依照怪物生成數量決定該隨機生成在那些位置
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

    public void CoverWaveCount()    //用來顯示每波戰鬥前的延遲
    {
        CoverObj.SetActive(true);
        WaveCountNum = 3;
        InvokeRepeating("WaveCount", 0, 1);
        Invoke("SetMonster", 3);
    }

    public void WaveCount()   //用來顯示每波戰鬥前的倒數
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

    public void CancelWaveCount()     //關閉每波怪物倒數的物件
    {
        CoverObj.SetActive(false);
        CancelInvoke("WaveCount");
    }

    public void ClickPause()   //點擊暫停按鈕
    {
        Load_Pause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClickClosePause()     //點擊繼續按鈕
    {
        Load_Pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ClickWavePause()    //勾選是否每波怪物都要暫停的按鈕
    {
        Debug.Log("應該有觸發到ㄅ?" + WavePauseNum);
        switch (WavePauseNum)
        {
            case 0:
                {
                    Debug.Log("有觸發到這裡嗎?");
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

    public void WavePause()   //每波怪物中間點要暫停顯示的
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
                    DeleteProjectile(MonsterSpwan.transform.childCount, MonsterSpwan);    //清空所有怪物
                    BattleEndDeleteProjectile();  //清空投射物
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

    public void CliskWavePauseBattleStart()    //點擊每波怪物中間點暫停裡面開始戰鬥的按鈕
    {
        Load_WavePause.SetActive(false);
        Time.timeScale = 1f;
        CoverWaveCount();
    }

    public void BattleEndDeleteProjectile()    //當戰鬥結束跟怪物死亡後要把投射物清空
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

    public void MonsterStaticSet(int MonsterPotionNum)   //設置怪物靜態資料，在戰鬥中就可以調用這裡的資料，避免資料會有不同的情況
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
