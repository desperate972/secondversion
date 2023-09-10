using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager GamemanagerClone;
    public GameObject Load_BarObj;
    public GameObject GamemanagerObj;

    public static string PlayerFile;
    public static Json_Player Json_PlayerFile;

    public static string PlayerArmorFile;
    public static PlayerArmor<Json_Player_Armor> Json_PlayerArmorFile;

    public static string ItemFile;
    public static Item<Json_Item> Json_ItemFile;

    public static string SkillFile;
    public static Skill<Json_Skill> Json_SkillFile;
    public static int SkillId_Choose;

    public static int SkillOrPotion_Change;
    public static int SkillOrPotionType_Change;
    public static string SkillOrPotion_Queue;

    public static int SkillOrPotion;

    private GameObject EmptyObj;
    private GameObject Sprite_LoadBarObj;
    public Text Text_LoadingObj;

    public static string Player_BattleFile;
    public static Json_Battle_Player Json_Player_BattleFile;

    public static string PotionFile;
    public static Potion<Json_Potion> Json_PotionFile;
    public static int PotionId_Choose;

    public static string SkillIconString;
    public static string PotionIconString;
    public static string BasicArmorString;
    public static string ArmorRankString;

    public static string ArmorFile;
    public static Armor<Json_Armor> Json_ArmorFile;

    public static string BattleFile;
    public static Json_Battle Json_BattleFile;

    public static string GrowFile;
    public static Grow<Json_Grow> Json_GrowFile;

    private void Awake()
    {
        DontDestoryGamemanager();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DontDestoryGamemanager()
    {
        if(GamemanagerClone == null)
        {
            GamemanagerClone = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(GamemanagerClone != this)
        {
            Destroy(gameObject);
        }
    }

    public void LoadSence()
    {
        StartCoroutine("LoadMainSence");
    }

    public void LoadBattleSenceFunction()
    {
        StartCoroutine("LoadBattleSence");
    }

    IEnumerator LoadMainSence()
    {
        AsyncOperation LoadingAsync = SceneManager.LoadSceneAsync("Main");

        //EmptyObj = GameObject.Find("UI");
        Instantiate(Load_BarObj, GamemanagerObj.transform);

        EmptyObj = GameObject.Find("Load_Text_BarPrecentage");
        Text_LoadingObj = EmptyObj.GetComponent<Text>();
        Sprite_LoadBarObj = GameObject.Find("Load_Sprite_Bar");
        float RectWidth = Sprite_LoadBarObj.GetComponent<RectTransform>().rect.width;
        float RealHeight = Sprite_LoadBarObj.GetComponent<RectTransform>().rect.height;
        float LoadingWidth = RectWidth / 100;

        while (!LoadingAsync.isDone)  //�]���D�e���W�����󦳨ǬO�|��active���A�ҥH�L�kŪ����ơA�ҥH�C����ƻݭnŪ�����ɭԴN�n�b�o�̷s�W
        {
            LoadingPlayerInfo();  //Ū�������ݩʸ��
            LoadPlayerArmor();    //Ū������˳Ƹ��
            LoadItem();           //Ū������D����
            LoadSkill();          //Ū������ޯ���
            Load_Player_Battle(); //Ū������԰��θ��
            LoadPotion();         //Ū�������Ĥ����
            LoadArmor();          //Ū���򥻸˳Ƹ��
            LoadBattle();         //Ū������԰����
            LoadGrow();           //Ū�����⦨�����

            int countdownNum = 0;
            while(countdownNum < (LoadingAsync.progress * 100))
            {
                //Debug.Log("�i�ױ� : " + LoadingAsync.progress);
                countdownNum++;
                float RealWidth = countdownNum * LoadingWidth;

                //Debug.Log("�ק�e���Ϥ��e�� : " + RectWidth);
                //Debug.Log("�ק�e���i�ױ��j�p : " + RealWidth);

                Text_LoadingObj.text = countdownNum + "%";                                                 //��ܦbLoading�����W���ʤ���
                string LoadingTextString = Text_LoadingObj.text;

                //Debug.Log("�ק�e���i�ױ��i�צʤ��� : " + LoadingTextString);

                Sprite_LoadBarObj.GetComponent<RectTransform>().sizeDelta = new Vector2(RealWidth, RealHeight);            //��ܶi�ױ��Ϫ��j�p

                //Debug.Log("�ק�᪺�Ϥ��e�� : " + RectWidth);
                //Debug.Log("�ק�᪺�i�ױ��j�p : " + RealWidth);
                //Debug.Log("�ק�᪺�i�ױ��i�צʤ��� : " + LoadingTextString);
                yield return new WaitForEndOfFrame();
            }
            yield return null;
        }
    }

    IEnumerator LoadBattleSence()
    {
        SceneManager.LoadSceneAsync("Battle");
        yield return null;
    }

    public void LoadingPlayerInfo()
    {
        //----Ū������򥻸��
        PlayerFile = File.ReadAllText(Application.persistentDataPath + @"\Player.json");
        Json_PlayerFile = JsonUtility.FromJson<Json_Player>(PlayerFile);
        Json_Player_Static.Player_Name = Json_PlayerFile.Player_Name;
        Json_Player_Static.Player_Lv = Json_PlayerFile.Player_Lv;
        Json_Player_Static.PlayerExp = Json_PlayerFile.PlayerExp;
        Json_Player_Static.PlayerExpNow = Json_PlayerFile.PlayerExpNow;
        Json_Player_Static.Player_Hp = Json_PlayerFile.Player_Hp;
        Json_Player_Static.Player_HpNow = Json_PlayerFile.Player_HpNow;
        Json_Player_Static.Player_Mp = Json_PlayerFile.Player_Mp;
        Json_Player_Static.Player_MpNow = Json_PlayerFile.Player_MpNow;
        Json_Player_Static.Player_AttackDamge_Min = Json_PlayerFile.Player_AttackDamge_Min;
        Json_Player_Static.Player_AttackDamge_Max = Json_PlayerFile.Player_AttackDamge_Max;
        Json_Player_Static.Player_MagicDamge_Min = Json_PlayerFile.Player_MagicDamge_Min;
        Json_Player_Static.Player_MagicDamge_Max = Json_PlayerFile.Player_MagicDamge_Max;
        Json_Player_Static.Player_Strength = Json_PlayerFile.Player_Strength;
        Json_Player_Static.Player_Intelligence = Json_PlayerFile.Player_Intelligence;
        Json_Player_Static.Player_Dexterity = Json_PlayerFile.Player_Dexterity;
        Json_Player_Static.Player_Armor = Json_PlayerFile.Player_Armor;
        Json_Player_Static.Player_ArmorMax = Json_PlayerFile.Player_ArmorMax;
        Json_Player_Static.Player_ArmorRate = Json_PlayerFile.Player_ArmorRate;
        Json_Player_Static.Player_Dodge = Json_PlayerFile.Player_Dodge;
        Json_Player_Static.Player_DodgeMax = Json_PlayerFile.Player_DodgeMax;
        Json_Player_Static.Player_DodgeRate = Json_PlayerFile.Player_DodgeRate;
        Json_Player_Static.Player_MagicShield = Json_PlayerFile.Player_MagicShield;
        Json_Player_Static.Player_Crit = Json_PlayerFile.Player_Crit;
        Json_Player_Static.Player_CritMax = Json_PlayerFile.Player_CritMax;
        Json_Player_Static.Player_CritRate = Json_PlayerFile.Player_CritRate;
        //----
    }

    public void LoadPlayerArmor()
    {
        PlayerArmorFile = File.ReadAllText(Application.persistentDataPath + @"\Player_Armor.json");
        Json_PlayerArmorFile = JsonUtility.FromJson<PlayerArmor<Json_Player_Armor>>(PlayerArmorFile);
    }

    public void SavePlayerArmor()
    {
        string SaveFile = JsonUtility.ToJson(Json_PlayerArmorFile);
        File.WriteAllText(Application.persistentDataPath + @"\Player_Armor.json", SaveFile);
    }

    public void LoadItem()
    {
        ItemFile = File.ReadAllText(Application.persistentDataPath + @"\Item.json");
        Json_ItemFile = JsonUtility.FromJson<Item<Json_Item>>(ItemFile);
    }

    public void LoadSkill()
    {
        SkillFile = File.ReadAllText(Application.persistentDataPath + @"\Skill.json");
        Json_SkillFile = JsonUtility.FromJson<Skill<Json_Skill>>(SkillFile);
    }

    public void Load_Player_Battle()  //�N�������ন�R�A��ơA�H��K�b�C����Ū�����
    {
        Player_BattleFile = File.ReadAllText(Application.persistentDataPath + @"\Player_Battle.json");
        Json_Player_BattleFile = JsonUtility.FromJson<Json_Battle_Player>(Player_BattleFile);
        Json_Battle_Player_Static.Attack_SkillId_1 = Json_Player_BattleFile.Attack_SkillId_1;
        Json_Battle_Player_Static.Attack_Queue_1 = Json_Player_BattleFile.Attack_Queue_1;
        Json_Battle_Player_Static.AttackCD_1 = Json_Player_BattleFile.AttackCD_1;
        Json_Battle_Player_Static.AttackDamageRate_1 = Json_Player_BattleFile.AttackDamageRate_1;
        Json_Battle_Player_Static.AttackType_1 = Json_Player_BattleFile.AttackType_1;
        Json_Battle_Player_Static.AttackSkillName_1 = Json_Player_BattleFile.AttackSkillName_1;

        Json_Battle_Player_Static.Attack_SkillId_2 = Json_Player_BattleFile.Attack_SkillId_2;
        Json_Battle_Player_Static.Attack_Queue_2 = Json_Player_BattleFile.Attack_Queue_2;
        Json_Battle_Player_Static.AttackCD_2 = Json_Player_BattleFile.AttackCD_2;
        Json_Battle_Player_Static.AttackDamageRate_2 = Json_Player_BattleFile.AttackDamageRate_2;
        Json_Battle_Player_Static.AttackType_2 = Json_Player_BattleFile.AttackType_2;
        Json_Battle_Player_Static.AttackSkillName_2 = Json_Player_BattleFile.AttackSkillName_2;

        Json_Battle_Player_Static.Attack_SkillId_3 = Json_Player_BattleFile.Attack_SkillId_3;
        Json_Battle_Player_Static.Attack_Queue_3 = Json_Player_BattleFile.Attack_Queue_3;
        Json_Battle_Player_Static.AttackCD_3 = Json_Player_BattleFile.AttackCD_3;
        Json_Battle_Player_Static.AttackDamageRate_3 = Json_Player_BattleFile.AttackDamageRate_3;
        Json_Battle_Player_Static.AttackType_3 = Json_Player_BattleFile.AttackType_3;
        Json_Battle_Player_Static.AttackSkillName_3 = Json_Player_BattleFile.AttackSkillName_3;

        Json_Battle_Player_Static.PotionId_1 = Json_Player_BattleFile.PotionId_1;
        Json_Battle_Player_Static.Potion_Queue_1 = Json_Player_BattleFile.Potion_Queue_1;
        Json_Battle_Player_Static.PotionCD_1 = Json_Player_BattleFile.PotionCD_1;
        Json_Battle_Player_Static.PotionType_1 = Json_Player_BattleFile.PotionType_1;
        Json_Battle_Player_Static.PotionCount_1 = Json_Player_BattleFile.PotionCount_1;
        Json_Battle_Player_Static.Potion_ml_1 = Json_Player_BattleFile.Potion_ml_1;
        Json_Battle_Player_Static.PotinTime_1 = Json_Player_BattleFile.PotinTime_1;
        Json_Battle_Player_Static.PotionName_1 = Json_Player_BattleFile.PotionName_1;

        Json_Battle_Player_Static.PotionId_2 = Json_Player_BattleFile.PotionId_2;
        Json_Battle_Player_Static.Potion_Queue_2 = Json_Player_BattleFile.Potion_Queue_2;
        Json_Battle_Player_Static.PotionCD_2 = Json_Player_BattleFile.PotionCD_2;
        Json_Battle_Player_Static.PotionType_2 = Json_Player_BattleFile.PotionType_2;
        Json_Battle_Player_Static.PotionCount_2 = Json_Player_BattleFile.PotionCount_2;
        Json_Battle_Player_Static.Potion_ml_2 = Json_Player_BattleFile.Potion_ml_2;
        Json_Battle_Player_Static.PotinTime_2 = Json_Player_BattleFile.PotinTime_2;
        Json_Battle_Player_Static.PotionName_2 = Json_Player_BattleFile.PotionName_2;
    }

    public void Change_Player_Battle_ToFile() //�N�R�A����ন�i�H�s�ɪ���Ƥ��e
    {
        Json_Player_BattleFile.Attack_SkillId_1 = Json_Battle_Player_Static.Attack_SkillId_1;
        Json_Player_BattleFile.Attack_Queue_1 = Json_Battle_Player_Static.Attack_Queue_1;
        Json_Player_BattleFile.AttackCD_1 = Json_Battle_Player_Static.AttackCD_1;
        Json_Player_BattleFile.AttackDamageRate_1 = Json_Battle_Player_Static.AttackDamageRate_1;
        Json_Player_BattleFile.AttackType_1 = Json_Battle_Player_Static.AttackType_1;
        Json_Player_BattleFile.AttackSkillName_1 = Json_Battle_Player_Static.AttackSkillName_1;

        Json_Player_BattleFile.Attack_SkillId_2 = Json_Battle_Player_Static.Attack_SkillId_2;
        Json_Player_BattleFile.Attack_Queue_2 = Json_Battle_Player_Static.Attack_Queue_2;
        Json_Player_BattleFile.AttackCD_2 = Json_Battle_Player_Static.AttackCD_2;
        Json_Player_BattleFile.AttackDamageRate_2 = Json_Battle_Player_Static.AttackDamageRate_2;
        Json_Player_BattleFile.AttackType_2 = Json_Battle_Player_Static.AttackType_2;
        Json_Player_BattleFile.AttackSkillName_2 = Json_Battle_Player_Static.AttackSkillName_2;

        Json_Player_BattleFile.Attack_SkillId_3 = Json_Battle_Player_Static.Attack_SkillId_3;
        Json_Player_BattleFile.Attack_Queue_3 = Json_Battle_Player_Static.Attack_Queue_3;
        Json_Player_BattleFile.AttackCD_3 = Json_Battle_Player_Static.AttackCD_3;
        Json_Player_BattleFile.AttackDamageRate_3 = Json_Battle_Player_Static.AttackDamageRate_3;
        Json_Player_BattleFile.AttackType_3 = Json_Battle_Player_Static.AttackType_3;
        Json_Player_BattleFile.AttackSkillName_3 = Json_Battle_Player_Static.AttackSkillName_3;

        Json_Player_BattleFile.PotionId_1 = Json_Battle_Player_Static.PotionId_1;
        Json_Player_BattleFile.Potion_Queue_1 = Json_Battle_Player_Static.Potion_Queue_1;
        Json_Player_BattleFile.PotionCD_1 = Json_Battle_Player_Static.PotionCD_1;
        Json_Player_BattleFile.PotionType_1 = Json_Battle_Player_Static.PotionType_1;
        Json_Player_BattleFile.PotionCount_1 = Json_Battle_Player_Static.PotionCount_1;
        Json_Player_BattleFile.Potion_ml_1 = Json_Battle_Player_Static.Potion_ml_1;
        Json_Player_BattleFile.PotinTime_1 = Json_Battle_Player_Static.PotinTime_1;
        Json_Player_BattleFile.PotionName_1 = Json_Battle_Player_Static.PotionName_1;

        Json_Player_BattleFile.PotionId_2 = Json_Battle_Player_Static.PotionId_2;
        Json_Player_BattleFile.Potion_Queue_2 = Json_Battle_Player_Static.Potion_Queue_2;
        Json_Player_BattleFile.PotionCD_2 = Json_Battle_Player_Static.PotionCD_2;
        Json_Player_BattleFile.PotionType_2 = Json_Battle_Player_Static.PotionType_2;
        Json_Player_BattleFile.PotionCount_2 = Json_Battle_Player_Static.PotionCount_2;
        Json_Player_BattleFile.Potion_ml_2 = Json_Battle_Player_Static.Potion_ml_2;
        Json_Player_BattleFile.PotinTime_2 = Json_Battle_Player_Static.PotinTime_2;
        Json_Player_BattleFile.PotionName_2 = Json_Battle_Player_Static.PotionName_2;
    }

    public void LoadPotion()
    {
        PotionFile = File.ReadAllText(Application.persistentDataPath + @"\Potion.json");
        Json_PotionFile = JsonUtility.FromJson<Potion<Json_Potion>>(PotionFile);
    }

    public void LoadArmor()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Json", "Armor.json");
        //string jsonpath = Application.streamingAssetsPath + "/Json/Armor.json";
        //UnityWebRequest jsonfile = new UnityWebRequest(filePath);
        //while (!jsonfile.isDone) { };
        //ArmorFile = jsonfile.downloadHandler.text;
        ArmorFile = File.ReadAllText(filePath);
        Json_ArmorFile = JsonUtility.FromJson<Armor<Json_Armor>>(ArmorFile);
    }

    public void LoadBattle()
    {
        //----Ū������԰���ơA����|�ݭn��˳Ƹ򨤦��¦�ݩʥ[���������e�[���Ƹ�
        BattleFile = File.ReadAllText(Application.persistentDataPath + @"\Battle.json");
        Json_BattleFile = JsonUtility.FromJson<Json_Battle>(BattleFile);
        Json_Battle_Static.Hp = Json_Player_Static.Player_Hp;
        Json_Battle_Static.HpNow = Json_Player_Static.Player_HpNow;
        Json_Battle_Static.Mp = Json_Player_Static.Player_Mp;
        Json_Battle_Static.MpNow = Json_Player_Static.Player_MpNow;
        Json_Battle_Static.AttackDamge_Min = Json_Player_Static.Player_AttackDamge_Min;
        Json_Battle_Static.AttackDamge_Max = Json_Player_Static.Player_AttackDamge_Max;
        Json_Battle_Static.MagicDamge_Min = Json_Player_Static.Player_MagicDamge_Min;
        Json_Battle_Static.MagicDamge_Max = Json_Player_Static.Player_MagicDamge_Max;
        Json_Battle_Static.Armor = Json_Player_Static.Player_Armor;
        Json_Battle_Static.ArmorMax = Json_Player_Static.Player_ArmorMax;
        Json_Battle_Static.ArmorRate = Json_Player_Static.Player_Armor / Json_Player_Static.Player_ArmorMax;
        Json_Battle_Static.Dodge = Json_Player_Static.Player_Dodge;
        Json_Battle_Static.DodgeMax = Json_Player_Static.Player_DodgeMax;
        Json_Battle_Static.DodgeRate = Json_Player_Static.Player_Dodge / Json_Player_Static.Player_DodgeMax;
        Json_Battle_Static.MagicShield = Json_Player_Static.Player_MagicShield;
        Json_Battle_Static.Crit = Json_Player_Static.Player_Crit;
        Json_Battle_Static.CritMax = Json_Player_Static.Player_CritMax;
        Json_Battle_Static.CritRate = Json_Player_Static.Player_Crit / Json_Player_Static.Player_CritMax;
        //----
    }

    public void LoadGrow()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Json", "Grow.json");
        GrowFile = File.ReadAllText(filePath);
        Json_GrowFile = JsonUtility.FromJson<Grow<Json_Grow>>(GrowFile);
    }

    public class PlayerArmor<T>
    {
        public List<T> JsonPlayerArmor;
    }

    public class Item<T>
    {
        public List<T> JsonItem;
    }

    public class Skill<T>
    {
        public List<T> JsonSkill;
    }

    public class Potion<T>
    {
        public List<T> JsonPotion;
    }

    public class Armor<T>
    {
        public List<T> JsonArmor;
    }

    public class Grow<T>
    {
        public List<T> JsonGrow;
    }

    public void LoadSkillIconFunction(int Iconid)   //�̷ӧޯ�s���ӧ��ܧޯ�ϥܪ��W�١A�ҥH�ݭn�եΧޯ�ϥܪ��a�賣�i�H�ϥγo��function�A�N���ΦA�B�~�g�ۦP�\��
    {
        switch (Iconid)
        {
            case 0:
                {
                    SkillIconString = "Button_Red_Choose";
                    break;
                }
            case 1:
                {
                    SkillIconString = "Button_Orange_Choose";
                    break;
                }
            case 2:
                {
                    SkillIconString = "Button_Blue_Choose";
                    break;
                }
            case 3:
                {
                    SkillIconString = "Button_Blue";
                    break;
                }
        }
    }

    public void LoadPotionIconFunction(int Iconid)   //�̷ӧޯ�s���ӧ����Ĥ��ϥܪ��W�١A�ҥH�ݭn�ե��Ĥ��ϥܪ��a�賣�i�H�ϥγo��function�A�N���ΦA�B�~�g�ۦP�\��
    {
        //Debug.Log("����Ū�o��?");
        switch (Iconid)
        {
            case 0:
                {
                    PotionIconString = "Button_Blue";
                    break;
                }
            case 1:
                {
                    PotionIconString = "Button_Orange_Choose";
                    break;
                }
            case 2:
                {
                    PotionIconString = "Button_Red_Choose";
                    break;
                }
            case 3:
                {
                    PotionIconString = "Button_Blue_Choose";
                    break;
                }
        }
    }

    public void LoadBasicArmorIconFunction(int Iconid)   //�Ψ�Ū���˳ƪ���¦�˳ƹϡA�p�G���ݭn���ܴN�i�H�եγo��function�A�N���ΦA�B�~�g�ۦP�\��
    {
        //Debug.Log("Ū���˳ư�¦��");
        switch (Iconid)
        {
            case 0:
                {
                    BasicArmorString = "Button_Red_Choose";
                    break;
                }
            case 1:
                {
                    BasicArmorString = "Button_Orange";
                    break;
                }
            case 2:
                {
                    BasicArmorString = "Button_Orange_Choose";
                    break;
                }
            case 3:
                {
                    BasicArmorString = "Button_Blue";
                    break;
                }
            case 4:
                {
                    BasicArmorString = "Button_Red";
                    break;
                }
            case 5:
                {
                    BasicArmorString = "Button_Blue_Choose";
                    break;
                }
            case 6:
                {
                    BasicArmorString = "Button_Black_Circle";
                    break;
                }
            case 7:
                {
                    BasicArmorString = "gray";
                    break;
                }
            case 8:
                {
                    BasicArmorString = "Button_Red_Circle";
                    break;
                }
            case 9:
                {
                    BasicArmorString = "Button_Blue_Choose_Circle";
                    break;
                }
        }
    }

    public void LoadArmorRankFrame(int IconRank)      //�Ψ�Ū���˳ƪ��~���~�عϡA�p�G���ݭn���ܴN�i�H�եγo��function�A�N���ΦA�B�~�g�ۦP�\��
    {
        //Debug.Log("Ū���˳ƫ~���~�ع�");
        switch (IconRank)
        {
            case 0:
                {
                    ArmorRankString = ("RankFrame_0");
                    break;
                }
            case 1:
                {
                    ArmorRankString = ("RankFrame_1");
                    break;
                }
            case 2:
                {
                    ArmorRankString = ("RankFrame_2");
                    break;
                }
            case 3:
                {
                    ArmorRankString = ("RankFrame_3");
                    break;
                }
        }
    }
}
