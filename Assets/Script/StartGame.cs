using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.ComponentModel;
using System;
using System.Linq;
using UnityEngine.Networking;
using System.Text;

public class StartGame : MonoBehaviour
{
    public Gamemanager GamemanagerClone;

    private string JsonPlayerFile;
    private string JsonArmorFile;
    private string JsonItemFile;
    private string JsonSkillFile;
    private string JsonPotionFile;
    private string JsonPlayerBattleFile;
    private string JsonBattleFile;

    // Start is called before the first frame update
    void Start()
    {
        JsonPlayerFile = Application.persistentDataPath + @"\Player.json";
        JsonArmorFile = Application.persistentDataPath + @"\Player_Armor.json";
        JsonItemFile = Application.persistentDataPath + @"\Item.json";
        JsonSkillFile = Application.persistentDataPath + @"\Skill.json";
        JsonPotionFile = Application.persistentDataPath + @"\Potion.json";
        JsonPlayerBattleFile = Application.persistentDataPath + @"\Player_Battle.json";
		JsonBattleFile = Application.persistentDataPath + @"\Battle.json";
	}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()    //���}�C��
	{
        Application.Quit();
	}

    public void FindPlayerFileExsit()  //�ˬd�����ƬO�_�w�Q�إ�
	{
        switch(File.Exists(JsonPlayerFile) && File.Exists(JsonArmorFile) && File.Exists(JsonItemFile) && File.Exists(JsonSkillFile) && File.Exists(JsonPotionFile) && File.Exists(JsonPlayerBattleFile) && File.Exists(JsonBattleFile))
		{
            case true:
				{
                    Debug.Log("����w�g�إ�!");
                    GamemanagerClone.LoadSence();
					break;
				}
            case false:
				{
                    CreateCharater();
                    break;
				}
		}
	}

    public void CreateCharater()
	{
        //----�إߨ�����
        Json_Player PlayerDate = new Json_Player();

        PlayerDate.Player_Name = "player";
        PlayerDate.Player_Lv = 1;
        PlayerDate.Player_Hp = 10f;
        PlayerDate.Player_HpNow = 10f;
        PlayerDate.Player_Mp = 10f;
        PlayerDate.Player_MpNow = 10f;
        PlayerDate.PlayerExp = 10;
        PlayerDate.PlayerExpNow = 0;
        PlayerDate.Player_AttackDamge_Min = 1f;
        PlayerDate.Player_AttackDamge_Max = 5f;
        PlayerDate.Player_MagicDamge_Min = 5f;
        PlayerDate.Player_MagicDamge_Max = 10f;
        PlayerDate.Player_Strength = 1;
        PlayerDate.Player_Intelligence = 1;
        PlayerDate.Player_Dexterity = 1;
        PlayerDate.Player_Armor = 5;
		PlayerDate.Player_ArmorMax = 10;
        PlayerDate.Player_ArmorRate = PlayerDate.Player_Armor / PlayerDate.Player_ArmorMax;
		PlayerDate.Player_Dodge = 1;
		PlayerDate.Player_DodgeMax = 10;
        PlayerDate.Player_DodgeRate = PlayerDate.Player_Dodge / PlayerDate.Player_DodgeMax;
		PlayerDate.Player_MagicShield = 0;
		PlayerDate.Player_Crit = 1;
		PlayerDate.Player_CritMax = 10;
        PlayerDate.Player_CritRate = PlayerDate.Player_Crit / PlayerDate.Player_CritMax;
		string playerdate = JsonUtility.ToJson(PlayerDate);
        File.WriteAllText(Application.persistentDataPath + @"\Player.json", playerdate);
        //----

        //----�إߨ���˳Ƹ��

        //�]������˳ƪ�|�O�G���}�C��Json��ƧΦ��A��unity������JsonUtility�ä��䴩�G���}�C���x�s
        //�ҥH�����]��h�A�N�G���}�C����ƥ]��List�A�A�NList������নJson�Aunity�|�P�_List�O�@���}�C�ӥi�H�Q�নJson
        //���ڤ����D�p��b�]��h����Ƹ̭��[�W�G���}�C����ơA�u�n�����N��List�]�G���}�C������ন�r�ꪽ���s���ɮ�
        //�A�z�LŪ���ɮר��নJson��ƨӶi��ק鷺�e
        //�̫�A�নJson��ƨ��x�s

		string PlayerArmorText = "{\"JsonPlayerArmor\":[{\"Id\":0, \"ArmorEquip\":1, \"ArmorBasicId\":0, \"ArmorLv\":0, \"ArmorType\":0, \"ArmorBasicPowerType\":2, \"ArmorBasicPowerMin\":1, \"ArmorBasicPowerMax\":3, \"ArmorRank\":0, \"ArmorIconId\":0, \"ArmorPowerType_1\":0, \"ArmorPowerMin_1\":0, \"ArmorPowerMax_1\":0, \"ArmorPowerType_2\":0, \"ArmorPowerMin_2\":0, \"ArmorPowerMax_2\":0, \"ArmorPowerType_3\":0, \"ArmorPowerMin_3\":0, \"ArmorPowerMax_3\":0, \"ArmorPowerType_4\":0, \"ArmorPowerMin_4\":0, \"ArmorPowerMax_4\":0, \"ArmorPowerType_5\":0, \"ArmorPowerMin_5\":0, \"ArmorPowerMax_5\":0, \"ArmorPowerType_6\":0, \"ArmorPowerMin_6\":0, \"ArmorPowerMax_6\":0}]}";
        File.WriteAllText(Application.persistentDataPath + @"\Player_Armor.json", PlayerArmorText);

        string armorText = File.ReadAllText(Application.persistentDataPath + @"\Player_Armor.json");
        PlayerArmor<Json_Player_Armor> JsonArmorDate = JsonUtility.FromJson<PlayerArmor<Json_Player_Armor>>(armorText);

        JsonArmorDate.JsonPlayerArmor.Add(new Json_Player_Armor() { Id = 1, ArmorEquip = 1, ArmorBasicId = 1, ArmorLv = 0, ArmorType = 1, ArmorBasicPowerType = 0, ArmorBasicPowerMin = 5, ArmorBasicPowerMax = 0, ArmorRank = 0, ArmorIconId = 1, ArmorPowerType_1 = 0, ArmorPowerMin_1 = 0, ArmorPowerMax_1 = 0, ArmorPowerType_2 = 0, ArmorPowerMin_2 = 0, ArmorPowerMax_2 = 0, ArmorPowerType_3 = 0, ArmorPowerMin_3 = 0, ArmorPowerMax_3 = 0, ArmorPowerType_4 = 0, ArmorPowerMin_4 = 0, ArmorPowerMax_4 = 0, ArmorPowerType_5 = 0, ArmorPowerMin_5 = 0, ArmorPowerMax_5 = 0, ArmorPowerType_6 = 0, ArmorPowerMin_6 = 0, ArmorPowerMax_6 = 0 });

        string savearmordate = JsonUtility.ToJson(JsonArmorDate);
        File.WriteAllText(Application.persistentDataPath + @"\Player_Armor.json", savearmordate);
		//----


        //�o�ӥΤ���F�A�ҥH�Ƶ����A�d�۪��ت��O����p�G���ۦP�ݨD�ɥi�H�Ѧ�
		//----�إ߰�¦�˳Ƥ��e�A�ت��O�n�N�o�ɮש��StreamingAssets��Ƨ��̷�@�u��Ū�������
		/*string ArmorFile = "{\"JsonArmor\":[{\"ArmorId\":0, \"ArmorName\":\"���C\", \"ArmorType\":0, \"ArmorLv\":0, \"ArmorBasicPowerType\":0, \"ArmorBasicPowerMin\":5, \"ArmorBasicPowerMax\":0, \"ArmorBasicPowerMinRage_1\":1, \"ArmorBasicPowerMinRage_2\":5, \"ArmorBasicPowerMaxRage_1\":0, \"ArmorBasicPowerMaxRage_2\":0, \"ArmorRank\":0, \"ArmorIconId\":0}]}";
		File.WriteAllText(Application.persistentDataPath + @"\Armor.json", ArmorFile);

		string ArmorFeilText = File.ReadAllText(Application.persistentDataPath + @"\Armor.json");
		Armor<Json_Armor> JsonArmorFile = JsonUtility.FromJson<Armor<Json_Armor>>(ArmorFeilText);

        JsonArmorFile.JsonArmor.Add(new Json_Armor() { ArmorId = 1, ArmorName = "�޵P", ArmorType = 1, ArmorLv = 0, ArmorBasicPowerType = 0, ArmorBasicPowerMin = 5, ArmorBasicPowerMax = 0, ArmorBasicPowerMinRage_1 = 1, ArmorBasicPowerMinRage_2 = 5, ArmorBasicPowerMaxRage_1 = 0, ArmorBasicPowerMaxRage_2 = 0, ArmorRank = 0, ArmorIconId = 1 });

		string savearmorfile = JsonUtility.ToJson(JsonArmorFile);
		File.WriteAllText(Application.persistentDataPath + @"\Armor.json", savearmorfile);*/
		//----

		//----�إߨ���D����
		string ItemText = "{\"JsonItem\":[{\"Id\":0, \"ItemNum\":1, \"ItemIconId\":0, \"ItemName\":\"����\", \"ItemInfo\":\"�Ұ�q�γf���A�Ұ�Ҥ����������i�H�ϥΡC\"}]}";
        File.WriteAllText(Application.persistentDataPath + @"\Item.json", ItemText);

        string itemText = File.ReadAllText(Application.persistentDataPath + @"\Item.json");
        Item<Json_Item> ItemDate = JsonUtility.FromJson<Item<Json_Item>>(itemText);

        ItemDate.JsonItem.Add(new Json_Item() { Id = 1, ItemNum = 1, ItemIconId = 1, ItemName = "�T��", ItemInfo = "�q�T���W��֤U�Ӫ��A�i�H�c�浹�ӤH�C"});

        string saveitemdate = JsonUtility.ToJson(ItemDate);
        File.WriteAllText(Application.persistentDataPath + @"\Item.json", saveitemdate);
		//----

		//----�إߨ���ޯ���
		string SkillText = "{\"JsonSkill\":[{\"Id\":0, \"SkillName\":\"����\", \"SkillCD\":1, \"SkillDamageRate\":100, \"SkillType\":0, \"SkillLearn\":1, \"SkillInfo\":\"�ϥΪZ���V�e���C\", \"SkillIconId\":0, \"SkillTag\":[0,1]}]}";
        File.WriteAllText(Application.persistentDataPath + @"\Skill.json", SkillText);

        string skillText = File.ReadAllText(Application.persistentDataPath + @"\Skill.json");
        Skill<Json_Skill> SkillDate = JsonUtility.FromJson<Skill<Json_Skill>>(skillText);

        int[] SkillArray_1 = new int[2];
		SkillArray_1[0] = 0;
		SkillArray_1[1] = 1;

		int[] SkillArray_2 = new int[3];
		SkillArray_2[0] = 2;
		SkillArray_2[1] = 3;
		SkillArray_2[2] = 4;

		int[] SkillArray_3 = new int[2];
		SkillArray_3[0] = 1;
		SkillArray_3[1] = 2;

		SkillDate.JsonSkill.Add(new Json_Skill() { Id = 1, SkillName = "����", SkillCD = 5, SkillDamageRate = 150, SkillType = 0, SkillLearn = 1, SkillInfo = "������Z���ΤO�¼ĤH�����C", SkillIconId = 1, SkillTag = SkillArray_1});
        SkillDate.JsonSkill.Add(new Json_Skill() { Id = 2, SkillName = "���y", SkillCD = 3, SkillDamageRate = 120, SkillType = 1, SkillLearn = 1, SkillInfo = "�۳�X�y�����K�V�e��X�C", SkillIconId = 2, SkillTag = SkillArray_2});
        SkillDate.JsonSkill.Add(new Json_Skill() { Id = 3, SkillName = "�a��", SkillCD = 10, SkillDamageRate = 200, SkillType = 1, SkillLearn = 0, SkillInfo = "�q�a�W�۳��g���Ϊ��y��V�e���C", SkillIconId = 3, SkillTag = SkillArray_3});

        string saveskilldate = JsonUtility.ToJson(SkillDate);
        File.WriteAllText(Application.persistentDataPath + @"\Skill.json", saveskilldate);
        //----

        //----�إߨ���԰����Ĥ����
        string PotionText = "{\"JsonPotion\":[{\"PotionId\":0, \"PotionName\":\"�v���Ĥ�\", \"PotionCD\":5, \"PotionType\":0, \"PotionCount\":3, \"Potion_ml\":10, \"PotionInfo\":\"�ϥΫ��_10�I��q�C\", \"PotinTime\":1, \"PotionUse\":1, \"PotionIcon\":0}]}";
        File.WriteAllText(Application.persistentDataPath + @"\Potion.json", PotionText);

        string potionText = File.ReadAllText(Application.persistentDataPath + @"\Potion.json");
        Potion<Json_Potion> PotionDate = JsonUtility.FromJson<Potion<Json_Potion>>(potionText);

        PotionDate.JsonPotion.Add(new Json_Potion() { PotionId = 1, PotionName = "�]�O�Ĥ�", PotionCD = 5, PotionType = 1, PotionCount = 3, Potionml = 10, PotionInfo = "�ϥΫ��_10�I�]�O�C", PotinTime = 1, PotionUse = 1, PotionIcon = 1});
        PotionDate.JsonPotion.Add(new Json_Potion() { PotionId = 2, PotionName = "�j�O���z�Ĥ�", PotionCD = 10, PotionType = 2, PotionCount = 2, Potionml = 10, PotionInfo = "�ϥΫ�W�[���z�̤p�ˮ`10�I�C", PotinTime = 5, PotionUse = 0, PotionIcon = 2});

        string savepotiondate = JsonUtility.ToJson(PotionDate);
        File.WriteAllText(Application.persistentDataPath + @"\Potion.json", savepotiondate);
        //----

        //----�إߨ���԰��ϥΧޯ���
        Json_Battle_Player BattlePlayer = new Json_Battle_Player();
        BattlePlayer.Attack_SkillId_1 = 0;
        BattlePlayer.Attack_Queue_1 = "Attack_Queue_1";
        BattlePlayer.AttackCD_1 = 1;
        BattlePlayer.AttackDamageRate_1 = 100;
        BattlePlayer.AttackType_1 = 0;
        BattlePlayer.AttackSkillName_1 = "����";

        BattlePlayer.Attack_SkillId_2 = 1;
        BattlePlayer.Attack_Queue_2 = "Attack_Queue_2";
        BattlePlayer.AttackCD_2 = 5;
        BattlePlayer.AttackDamageRate_2 = 150;
        BattlePlayer.AttackType_2 = 0;
        BattlePlayer.AttackSkillName_2 = "����";

        BattlePlayer.Attack_SkillId_3 = 2;
        BattlePlayer.Attack_Queue_3 = "Attack_Queue_3";
        BattlePlayer.AttackCD_3 = 3;
        BattlePlayer.AttackDamageRate_3 = 120;
        BattlePlayer.AttackType_3 = 1;
        BattlePlayer.AttackSkillName_3 = "���y";

        BattlePlayer.PotionId_1 = 0;
        BattlePlayer.Potion_Queue_1 = "Potion_Queue_1";
        BattlePlayer.PotionCD_1 = 5;
        BattlePlayer.PotionType_1 = 0;
        BattlePlayer.PotionCount_1 = 3;
        BattlePlayer.Potion_ml_1 = 10;
        BattlePlayer.PotinTime_1 = 1;
        BattlePlayer.PotionName_1 = "�v���Ĥ�";

        BattlePlayer.PotionId_2 = 1;
        BattlePlayer.Potion_Queue_2 = "Potion_Queue_2";
        BattlePlayer.PotionCD_2 = 5;
        BattlePlayer.PotionType_2 = 1;
        BattlePlayer.PotionCount_2 = 3;
        BattlePlayer.Potion_ml_2 = 10;
        BattlePlayer.PotinTime_2 = 1;
        BattlePlayer.PotionName_2 = "�]�O�Ĥ�";

        string battleplayer = JsonUtility.ToJson(BattlePlayer);
        File.WriteAllText(Application.persistentDataPath + @"\Player_Battle.json", battleplayer);
        //----

        //----����԰���ơA����ƥu�|�b�i�C���ɡA�N�����ݩʼƭȡB�˳Ƶ���...�|�v�T��԰����ƭȭp�⦨����ƪ��ƭȡA�����|�i���x�s
        Json_Battle Battle = new Json_Battle();
        Battle.Hp = 0;
        Battle.HpNow = 0;
        Battle.Mp = 0;
        Battle.MpNow = 0;
        Battle.AttackDamge_Min = 0;
		Battle.AttackDamge_Max = 0; ;
		Battle.MagicDamge_Min = 0;
		Battle.MagicDamge_Max = 0;
		Battle.Armor = 0;
		Battle.ArmorMax = 0;
		Battle.ArmorRate = 0;
		Battle.Dodge = 0;
		Battle.DodgeMax = 0;
		Battle.DodgeRate = 0;
		Battle.MagicShield = 0;
		Battle.Crit = 0;
		Battle.CritMax = 0;
		Battle.CritRate = 0;

		string battle = JsonUtility.ToJson(Battle);
		File.WriteAllText(Application.persistentDataPath + @"\Battle.json", battle);
		//----		

		Debug.Log("���\�Ыب���!");
        GamemanagerClone.LoadSence();
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

    public void CreatePlayerArmorFile()   //���ӬO�Ψ����s�ت�����˳ƤW���H���z¾���\��A�ȮɫO�d
    {
		string jsonpath = Application.streamingAssetsPath + "/Json/Armor.json";
		UnityWebRequest jsonfile = new UnityWebRequest(jsonpath);
		while (!jsonfile.isDone) { };
		string jsonfileload = jsonfile.downloadHandler.text;
		Armor<Json_Armor> jsonfileloadtext = JsonUtility.FromJson<Armor<Json_Armor>>(jsonfileload);

        //int Id, ArmorEquip, ArmorBasicId, ArmorLv, ArmorBasicPowerType, ArmorRankint,ArmorIconId, ArmorPowerType_1, ArmorPowerMin_1, ArmorPowerMax_1, ArmorPowerType_2, ArmorPowerMin_2, ArmorPowerMax_2, ArmorPowerType_3, ArmorPowerMin_3, ArmorPowerMax_3, ArmorPowerType_4, ArmorPowerMin_4, ArmorPowerMax_4, ArmorPowerType_5, ArmorPowerMin_5, ArmorPowerMax_5, ArmorPowerType_6, ArmorPowerMin_6, ArmorPowerMax_6;
		//float ArmorBasicPowerMin, ArmorBasicPowerMax;

        foreach(Json_Armor date in jsonfileloadtext.JsonArmor)
        {
            if(date.ArmorId == 0)
            {

            }
        }
    }
}
