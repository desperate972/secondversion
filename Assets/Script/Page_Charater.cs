using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System.Runtime.InteropServices.WindowsRuntime;

public class Page_Charater : MonoBehaviour
{
    public GameObject Load_Sprite_PlayerHpObj;
    public GameObject Load_Sprite_PlayerMpObj;
    public GameObject Load_Sprite_PlayerExpObj;
    public Text Load_Text_PlayerHp;
    public Text Load_Text_PlayerMp;
    public Text Load_Text_PlayerExp;
    public Text Load_Text_PlayerLv;

    public Text Load_Text_Strength;
    public Text Load_Text_Intelligence;
    public Text Load_Text_Dexterity;

    public GameObject Page_CharaterObj;

    public GameObject Grid_PropertyChild;
    public GameObject Grid_PropertyFather;
    private Text Grid_PropertyName;
    private Text Grid_PropertyNum;

    public GameObject Grid_ArmorChild;
    public GameObject Grid_ArmorFather;
    public SpriteAtlas Grid_ArmorIconSpriteAtlas;

    public GameObject DownPage_Property;
    public GameObject DownPage_Armor;

    public Gamemanager GamemanagerObj;

    //public Page_Charater_Armor_Property EquipArmorPropertyObj;

	private int DownPageChangeNum;

	private void Awake()
	{
        Load_PlayerInfo();
        Load_CharaterInfo();
        LoadPlayerProperty();
        DownPageChangeNum = 0;
        ChangeDownPage();
        LoadPlayerArmor();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load_PlayerInfo()
    {
        //-----主畫面上顯示角色血量數值跟血量圖片顯示
        float PlayerHp = Json_Battle_Static.HpNow / Json_Battle_Static.Hp;
		float Load_Sprite_PlayerHpImageWidth = Load_Sprite_PlayerHpObj.GetComponent<RectTransform>().rect.width;
        float Load_Sprite_PlayerHpImageHeight = Load_Sprite_PlayerHpObj.GetComponent<RectTransform>().rect.height;
        Load_Sprite_PlayerHpObj.GetComponent<RectTransform>().sizeDelta = new Vector2((Load_Sprite_PlayerHpImageWidth * PlayerHp), Load_Sprite_PlayerHpImageHeight);
        Load_Text_PlayerHp.text = Json_Battle_Static.HpNow.ToString() + "/" + Json_Battle_Static.Hp.ToString();
		//-----

		//-----主畫面上顯示角色魔量數值跟魔量圖片顯示
		float PlayerMp = Json_Battle_Static.MpNow / Json_Battle_Static.Mp;
		float Load_Sprite_PlayerMpImageWidth = Load_Sprite_PlayerMpObj.GetComponent<RectTransform>().rect.width;
        float Load_Sprite_PlayerMpImageHeight = Load_Sprite_PlayerMpObj.GetComponent<RectTransform>().rect.height;
        Load_Sprite_PlayerMpObj.GetComponent<RectTransform>().sizeDelta = new Vector2((Load_Sprite_PlayerMpImageWidth * PlayerHp), Load_Sprite_PlayerMpImageHeight);
        Load_Text_PlayerMp.text = Json_Battle_Static.MpNow.ToString() + "/" + Json_Battle_Static.Mp.ToString();
		//-----

		//-----主畫面上顯示角色經驗值數值跟經驗值圖片顯示
		float PlayerExp = (Json_Player_Static.PlayerExpNow == 0) ? 1 : Json_Player_Static.PlayerExpNow / Json_Player_Static.PlayerExp;
        float Load_Sprite_PlayerExpImageWidth = Load_Sprite_PlayerExpObj.GetComponent<RectTransform>().rect.width;
        float Load_Sprite_PlayerExpImageHeight = Load_Sprite_PlayerExpObj.GetComponent<RectTransform>().rect.height;
        Load_Sprite_PlayerExpObj.GetComponent<RectTransform>().sizeDelta = new Vector2((Load_Sprite_PlayerExpImageWidth * PlayerExp), Load_Sprite_PlayerExpImageHeight);
        Load_Text_PlayerExp.text = Json_Player_Static.PlayerExpNow.ToString() + "/" + Json_Player_Static.PlayerExp.ToString();
        //-----

        //-----顯示角色當前等級
        Load_Text_PlayerLv.text = "Lv:" + Json_Player_Static.Player_Lv.ToString();
        //-----
    }

    public void Load_CharaterInfo()   //顯示角色主要屬性的內容(力量、智力跟敏捷)
    {
        Load_Text_Strength.text = Json_Player_Static.Player_Strength.ToString();
        Load_Text_Intelligence.text = Json_Player_Static.Player_Intelligence.ToString();
        Load_Text_Dexterity.text = Json_Player_Static.Player_Dexterity.ToString();
    }

    public void ClosePageCharater()  //關閉角色介面
	{
        Page_CharaterObj.SetActive(false);
		//GamemanagerObj.SavePlayerArmor();
    }

    public void LoadPlayerProperty()   //顯示角色屬性數值
	{
        for(int i = 0; i < 11; i++)
		{
            GameObject EmptyObj = Instantiate(Grid_PropertyChild, Grid_PropertyFather.transform);
            EmptyObj.name = "PlayerProperty_" + i;
            GameObject EmptyObj_Name = GameObject.Find(EmptyObj.name + "/Load_Text_Property_Name");
            Grid_PropertyName = EmptyObj_Name.GetComponent<Text>();
            GameObject EmptyObj_Num = GameObject.Find(EmptyObj.name + "/Load_Text_Property_Num");
            Grid_PropertyNum = EmptyObj_Num.GetComponent<Text>();
            switch (i)
            {
                case 0:
                    {
                        Grid_PropertyName.text = "血量:";
                        Grid_PropertyNum.text = Json_Battle_Static.Hp.ToString();
                        break;
                    }
                case 1:
                    {
                        Grid_PropertyName.text = "魔力:";
                        Grid_PropertyNum.text = Json_Battle_Static.Mp.ToString();
                        break;
                    }
                case 2:
                    {
                        Grid_PropertyName.text = "物理攻擊:";
                        Grid_PropertyNum.text = Json_Battle_Static.AttackDamge_Min + " ~ " + Json_Battle_Static.AttackDamge_Max;
                        break;
                    }
                case 3:
                    {
                        Grid_PropertyName.text = "魔法攻擊:";
                        Grid_PropertyNum.text = Json_Battle_Static.MagicDamge_Min + " ~ " + Json_Battle_Static.MagicDamge_Max;
                        break;
                    }
                case 4:
                    {
                        Grid_PropertyName.text = "護甲值:";
                        Grid_PropertyNum.text = Json_Battle_Static.Armor.ToString();
                        break;
                    }
                case 5:
                    {
                        Grid_PropertyName.text = "物理傷害減免:";
                        Grid_PropertyNum.text = (Json_Battle_Static.Armor / 100) + "%";
                        break;
                    }
                case 6:
                    {
                        Grid_PropertyName.text = "閃避值:";
                        Grid_PropertyNum.text = Json_Battle_Static.Dodge.ToString();
                        break;
                    }
                case 7:
                    {
                        Grid_PropertyName.text = "閃避率:";
                        Grid_PropertyNum.text = (Json_Battle_Static.Dodge / 100) + "%";
                        break;
                    }
                case 8:
                    {
                        Grid_PropertyName.text = "魔法護盾:";
                        Grid_PropertyNum.text = Json_Battle_Static.MagicShield.ToString();
                        break;
                    }
                case 9:
                    {
                        Grid_PropertyName.text = "爆擊值:";
                        Grid_PropertyNum.text = Json_Battle_Static.Crit.ToString();
                        break;
                    }
                case 10:
                    {
                        Grid_PropertyName.text = "爆擊率:";
                        Grid_PropertyNum.text = (Json_Battle_Static.Crit / 100) + "%";
                        break;
                    }
            }
        }
	}

    public void ClickButtonArmor()   //按裝備按鈕
	{
        DownPageChangeNum = 1;
        ChangeDownPage();
        ChangeArmorIcon();   //因為預設armor的物件是關閉的，所以無法在awake()的時候就先把裝備的ICON讀出來，只好在切換裝備跟屬性葉面時做處理
    }

    public void ClickButtonProperty()    //按屬性按鈕
    {
        DownPageChangeNum = 0;
        ChangeDownPage();
    }

    public void ChangeDownPage()    //根據玩家按屬性或是裝備的按鈕來切換顯示的介面
	{
        switch(DownPageChangeNum)
		{
            case 0:
				{
                    DownPage_Property.SetActive(true);
                    DownPage_Armor.SetActive(false);
                    break;
				}
            case 1:
				{
                    DownPage_Property.SetActive(false);
                    DownPage_Armor.SetActive(true);
                    break;
				}
		}
    }

    public void LoadPlayerArmor()  //把所擁有的裝備先複製出來形成裝備列表
	{
        Debug.Log("顯示目前裝備數量: " + Gamemanager.Json_PlayerArmorFile.JsonPlayerArmor.Count);


		foreach (Json_Player_Armor date in Gamemanager.Json_PlayerArmorFile.JsonPlayerArmor)
		{
            if(date.ArmorEquip == 1)
            {
				GameObject ArmorObj = Instantiate(Grid_ArmorChild, Grid_ArmorFather.transform);
				ArmorObj.name = "PlayerArmor_" + date.Id;
				Armor newArmorObj = ArmorObj.GetComponent<Armor>();
				newArmorObj.ArmorId = date.Id;
			}
		}

        foreach (Json_Player_Armor date in Gamemanager.Json_PlayerArmorFile.JsonPlayerArmor)
        {
            if (date.ArmorEquip == 0)
            {
                GameObject ArmorObj = Instantiate(Grid_ArmorChild, Grid_ArmorFather.transform);
                ArmorObj.name = "PlayerArmor_" + date.Id;
				Armor newArmorObj = ArmorObj.GetComponent<Armor>();
				newArmorObj.ArmorId = date.Id;
			}
        }
	}

    public void ChangeArmorIcon()  //讀出每個裝備的ICON顯示
	{
        foreach (Json_Player_Armor date in Gamemanager.Json_PlayerArmorFile.JsonPlayerArmor)
        {
            for(int i = 0; i < Gamemanager.Json_PlayerArmorFile.JsonPlayerArmor.Count; i++)
            {
				ChangeArmorIconFunction(date.Id, date.ArmorIconId);
				LoadArmorRank(date.Id, date.ArmorRank);
                if(date.Id == i && date.ArmorEquip == 0)
                {
                    GameObject UnEquip = GameObject.Find("PlayerArmor_" + i + "/Load_Sprite_Equip_Aromr");
                    Destroy(UnEquip);
				}
			}
		}
	}

    public void ChangeArmorIconFunction(int Armorid, int IconId)    //顯示裝備圖
	{
        GameObject EmptyObj = GameObject.Find("PlayerArmor_" + Armorid + "/Load_Sprite_Armor_Icon");
        Image EmptyObj_sprite = EmptyObj.GetComponent<Image>();
        GamemanagerObj.LoadBasicArmorIconFunction(IconId);
		EmptyObj_sprite.sprite = Grid_ArmorIconSpriteAtlas.GetSprite(Gamemanager.BasicArmorString);
    }

    public void LoadArmorRank(int ArmorId, int ArmorRank)   //顯示裝備品階的外框圖
    {
		GameObject EmptyObj = GameObject.Find("PlayerArmor_" + ArmorId);
		Image EmptyObj_sprite = EmptyObj.GetComponent<Image>();
		GamemanagerObj.LoadArmorRankFrame(ArmorRank);
		EmptyObj_sprite.sprite = Grid_ArmorIconSpriteAtlas.GetSprite(Gamemanager.ArmorRankString);
    }

    public void DestoryUnEquipArmor()   //清空裝備列表跟裝備欄位裡的裝備ICON圖，因為卸下裝備後需要重新生成裝備內容
    {
		for (int i = 0; i < Grid_ArmorFather.transform.childCount; i++)
		{
			GameObject Last_Arnor_PowerObj = Grid_ArmorFather.transform.GetChild(i).gameObject;
			Destroy(Last_Arnor_PowerObj);
		}
	}
}
