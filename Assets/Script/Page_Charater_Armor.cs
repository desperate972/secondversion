using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Page_Charater_Armor : MonoBehaviour
{
    public GameObject Load_Armor_PropertyObj;
    public GameObject Load_Armor_Equip_PropertyObj;

    public Text Load_Text_Armor_Name;
    public Text Load_Text_Armor_Basic;
    public Text Load_Text_Armor_Request;
    public Image Load_Sprite_Armor_Icon;
    public Image Load_Sprite_Armor_Rank;

    public Text Load_Text_Armor_Equip_Name;
    public Text Load_Text_Armor_Equip_Basic;
    public Text Load_Text_Armor_Equip_Request;
    public Image Load_Sprite_Armor_Equip_Icon;
    public Image Load_Sprite_Armor_Equip_Rank;

    public SpriteAtlas Grid_ArmorIconSpriteAtlas;

    public Gamemanager GamemanagerObj;

    public GameObject Armor_PowerObj_Child;
    public GameObject Grid_Armor_PowerObj_Father;
    public GameObject Grid_Equip_Armor_PowerObj_Father;

    public GameObject Grid_ArmorChild;
    public GameObject Grid_Equip_ArmorFather_0;
    public GameObject Grid_Equip_ArmorFather_1;
    public GameObject Grid_Equip_ArmorFather_2;
    public GameObject Grid_Equip_ArmorFather_3;
    public GameObject Grid_Equip_ArmorFather_4;
    public GameObject Grid_Equip_ArmorFather_5;
    public GameObject Grid_Equip_ArmorFather_6;
    public GameObject Grid_Equip_ArmorFather_7;
    public GameObject Grid_Equip_ArmorFather_8;
    public GameObject Grid_Equip_ArmorFather_9;

    private string BasicArmorName;
    private int BasicArmorType;
    private string BasicArmorString;

    private string Power_0;
    private string Power_1;
    private string Power_2;
    private string Power_3;
    private string Power_4;
    private string Power_5;

    private void Awake()
    {
        Load_Equip_ArmorIcon();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickArmorIcon(int ArmorId)   //�˳ƦC�̸˳�ICON�|���X�˳Ƹ�T
    {
        foreach (Json_Player_Armor date in Gamemanager.Json_PlayerArmorFile.JsonPlayerArmor)
        {
            switch(date.ArmorEquip)
            {
                case 0:
                    {
                        if (date.Id == ArmorId)
                        {
                            Load_Armor_PropertyObj.SetActive(true);
                            Page_Charater_Armor_Property PropertyArmorId = Load_Armor_PropertyObj.GetComponent<Page_Charater_Armor_Property>();
                            PropertyArmorId.ArmorId = date.Id;
                            PropertyArmorId.ArmorType = date.ArmorType;
                            Load_Basic_Armor_File(date.ArmorBasicId, out BasicArmorName, out BasicArmorType);
                            Load_Basic_Armor_BasicPower(date.ArmorBasicPowerType, date.ArmorBasicPowerMin, date.ArmorBasicPowerMax, out BasicArmorString);
                            GamemanagerObj.LoadBasicArmorIconFunction(date.ArmorIconId);
                            GamemanagerObj.LoadArmorRankFrame(date.ArmorRank);
                            Load_Text_Armor_Name.text = BasicArmorName;
                            Load_Text_Armor_Basic.text = BasicArmorString;
                            Load_Text_Armor_Request.text = "���ŻݨD: " + date.ArmorLv;
                            Load_Sprite_Armor_Icon.sprite = Grid_ArmorIconSpriteAtlas.GetSprite(Gamemanager.BasicArmorString);
                            Load_Sprite_Armor_Rank.sprite = Grid_ArmorIconSpriteAtlas.GetSprite(Gamemanager.ArmorRankString);

                            Load_Basic_Armor_BasicPower(date.ArmorPowerType_1, date.ArmorPowerMin_1, date.ArmorPowerMax_1, out Power_0);
                            Load_Basic_Armor_BasicPower(date.ArmorPowerType_2, date.ArmorPowerMin_2, date.ArmorPowerMax_2, out Power_1);
                            Load_Basic_Armor_BasicPower(date.ArmorPowerType_3, date.ArmorPowerMin_3, date.ArmorPowerMax_3, out Power_2);
                            Load_Basic_Armor_BasicPower(date.ArmorPowerType_4, date.ArmorPowerMin_4, date.ArmorPowerMax_4, out Power_3);
                            Load_Basic_Armor_BasicPower(date.ArmorPowerType_5, date.ArmorPowerMin_5, date.ArmorPowerMax_5, out Power_4);
                            Load_Basic_Armor_BasicPower(date.ArmorPowerType_6, date.ArmorPowerMin_6, date.ArmorPowerMax_6, out Power_5);

                            for(int i = 0; i < Grid_Armor_PowerObj_Father.transform.childCount; i++)
                            {
                                GameObject Last_Arnor_PowerObj = Grid_Armor_PowerObj_Father.transform.GetChild(i).gameObject;
                                Destroy(Last_Arnor_PowerObj);
                            }

                            switch (date.ArmorRank)
                            {
                                case 0:
                                    {
                                        break;
                                    }
                                case 1:
                                    {
                                        Load_Armor_Power(2, Grid_Armor_PowerObj_Father);
                                        break;
                                    }
                                case 2:
                                    {
                                        Load_Armor_Power(4, Grid_Armor_PowerObj_Father);
                                        break;
                                    }
                                case 3:
                                    {
                                        Load_Armor_Power(6, Grid_Armor_PowerObj_Father);
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        if(date.Id == ArmorId)
                        {
                            Load_Armor_Equip_PropertyObj.SetActive(true);
                            Page_Charater_Armor_Property PropertyArmorId = Load_Armor_Equip_PropertyObj.GetComponent<Page_Charater_Armor_Property>();
                            PropertyArmorId.ArmorId = date.Id;
                            PropertyArmorId.ArmorType = date.ArmorType;
                            Load_Basic_Armor_File(date.ArmorBasicId, out BasicArmorName, out BasicArmorType);
                            Load_Basic_Armor_BasicPower(date.ArmorBasicPowerType, date.ArmorBasicPowerMin, date.ArmorBasicPowerMax, out BasicArmorString);
                            GamemanagerObj.LoadBasicArmorIconFunction(date.ArmorIconId);
                            GamemanagerObj.LoadArmorRankFrame(date.ArmorRank);
                            Load_Text_Armor_Equip_Name.text = BasicArmorName;
                            Load_Text_Armor_Equip_Basic.text = BasicArmorString;
                            Load_Text_Armor_Equip_Request.text = "���ŻݨD: " + date.ArmorLv;
                            Load_Sprite_Armor_Equip_Icon.sprite = Grid_ArmorIconSpriteAtlas.GetSprite(Gamemanager.BasicArmorString);
                            Load_Sprite_Armor_Equip_Rank.sprite = Grid_ArmorIconSpriteAtlas.GetSprite(Gamemanager.ArmorRankString);

                            Load_Basic_Armor_BasicPower(date.ArmorPowerType_1, date.ArmorPowerMin_1, date.ArmorPowerMax_1, out Power_0);
                            Load_Basic_Armor_BasicPower(date.ArmorPowerType_2, date.ArmorPowerMin_2, date.ArmorPowerMax_2, out Power_1);
                            Load_Basic_Armor_BasicPower(date.ArmorPowerType_3, date.ArmorPowerMin_3, date.ArmorPowerMax_3, out Power_2);
                            Load_Basic_Armor_BasicPower(date.ArmorPowerType_4, date.ArmorPowerMin_4, date.ArmorPowerMax_4, out Power_3);
                            Load_Basic_Armor_BasicPower(date.ArmorPowerType_5, date.ArmorPowerMin_5, date.ArmorPowerMax_5, out Power_4);
                            Load_Basic_Armor_BasicPower(date.ArmorPowerType_6, date.ArmorPowerMin_6, date.ArmorPowerMax_6, out Power_5);

                            for (int i = 0; i < Grid_Equip_Armor_PowerObj_Father.transform.childCount; i++)
                            {
                                GameObject Last_Arnor_PowerObj = Grid_Equip_Armor_PowerObj_Father.transform.GetChild(i).gameObject;
                                Destroy(Last_Arnor_PowerObj);
                            }

                            switch (date.ArmorRank)
                            {
                                case 0:
                                    {
                                        break;
                                    }
                                case 1:
                                    {
                                        Load_Armor_Power(2, Grid_Equip_Armor_PowerObj_Father);
                                        break;
                                    }
                                case 2:
                                    {
                                        Load_Armor_Power(4, Grid_Equip_Armor_PowerObj_Father);
                                        break;
                                    }
                                case 3:
                                    {
                                        Load_Armor_Power(6, Grid_Equip_Armor_PowerObj_Father);
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }
        }
    }

    public void Close_Armor_PropertyObj()   //������ܸ˳Ƹ�T�����X����
    {
        Load_Armor_PropertyObj.SetActive(false);
    }

    public void Close_Armor_Equip_PropertyObj()   //������ܤw�˳ƪ��˳Ƹ�T�����X����
    {
        Load_Armor_Equip_PropertyObj.SetActive(false);
    }

    public void Load_Basic_Armor_File(int BasicArmorId, out string BasicArmorName, out int BasicArmorType)   //Ū��streamingasset��Ƨ��̡A�˳ƪ���¦���
    {
        BasicArmorName = "";
        BasicArmorType = 0;
        foreach (Json_Armor date in Gamemanager.Json_ArmorFile.JsonArmor)
        {
            if(date.ArmorId == BasicArmorId)
            {
                BasicArmorName = date.ArmorName;
                BasicArmorType = date.ArmorType;
            }
        }
    }

    public void Load_Basic_Armor_BasicPower(int BasicPowerType, float BasicPowerMin, float BasicPowerMax,  out string BasicPowerString)   //�N�˳ƪ��B�~��O�ഫ���r��
    {
        BasicPowerString = "";
        switch (BasicPowerType)
        {
            case 0:
                {
                    BasicPowerString = "HP: " + BasicPowerMin;
                    break;
                }
            case 1:
                {
                    BasicPowerString = "MP: " + BasicPowerMin;
                    break;
                }
            case 2:
                {
                    BasicPowerString = "���z�����O: " + BasicPowerMin + "~" + BasicPowerMax;
                    break;
                }
            case 3:
                {
                    BasicPowerString = "�]�k�����O: " + BasicPowerMin + "~" + BasicPowerMax;
                    break;
                }
            case 4:
                {
                    BasicPowerString = "�O�q: " + BasicPowerMin; ;
                    break;
                }
            case 5:
                {
                    BasicPowerString = "���z: " + BasicPowerMin; ;
                    break;
                }
            case 6:
                {
                    BasicPowerString = "�ӱ�: " + BasicPowerMin; ;
                    break;
                }
        }
    }

    public void Load_Armor_Power(int PowerNum, GameObject Grid_Father)  //�N�˳��B�~��O�ন�r�ꪺ�r�ꤺ�e��ܥX��
    {
        for (int i = 0; i < PowerNum; i++)
        {
            GameObject EmptyObj = Instantiate(Armor_PowerObj_Child, Grid_Father.transform);
            EmptyObj.name = "Power_" + i;
            GameObject EmptyObj_Power = GameObject.Find(EmptyObj.name + "/Load_Text_Armor_Power");
            Text PowerString = EmptyObj_Power.GetComponent<Text>();
            switch(i)
            {
                case 0:
                    {
                        PowerString.text = Power_0;
                        break;
                    }
                case 1:
                    {
                        PowerString.text = Power_1;
                        break;
                    }
                case 2:
                    {
                        PowerString.text = Power_2;
                        break;
                    }
                case 3:
                    {
                        PowerString.text = Power_3;
                        break;
                    }
                case 4:
                    {
                        PowerString.text = Power_4;
                        break;
                    }
                case 5:
                    {
                        PowerString.text = Power_5;
                        break;
                    }
            }
        }
    }

    public void Load_Equip_ArmorIcon()  //��ܤw�˳ƪ��˳�ICON�b�˳�����
    {
        int BasicArmorType = 0;
        foreach (Json_Player_Armor date in Gamemanager.Json_PlayerArmorFile.JsonPlayerArmor)
        {
            if (date.ArmorEquip == 1)
            {
                Load_Basic_Armor_File(date.ArmorBasicId, out BasicArmorName, out BasicArmorType);
                switch (BasicArmorType)
                {
                    case 0:
                        {
                            GameObject ArmorObj = Instantiate(Grid_ArmorChild, Grid_Equip_ArmorFather_0.transform);
                            ArmorObj.name = "Load_Armor_" + date.Id;
                            Armor newArmorObj = ArmorObj.GetComponent<Armor>();
                            newArmorObj.ArmorId = date.Id;
                            ArmorObj.transform.localPosition = new Vector3(0, 0, 0);
                            ChangeArmorIconFunction(newArmorObj.ArmorId, 0, date.ArmorIconId);
                            LoadArmorRank(0, date.ArmorRank, newArmorObj.ArmorId);
                            //GameObject EquipObj = GameObject.Find("Load_Armor" + date.Id + "/Load_Sprite_Equip_Aromr");
                            //EquipObj.SetActive(false);
                            break;
                        }
                    case 1:
                        {
                            GameObject ArmorObj = Instantiate(Grid_ArmorChild, Grid_Equip_ArmorFather_1.transform);
                            ArmorObj.name = "Load_Armor_" + date.Id;
                            Armor newArmorObj = ArmorObj.GetComponent<Armor>();
                            newArmorObj.ArmorId = date.Id;
                            ArmorObj.transform.localPosition = new Vector3(0, 0, 0);
                            ChangeArmorIconFunction(newArmorObj.ArmorId, 1, date.ArmorIconId);
                            LoadArmorRank(1, date.ArmorRank, newArmorObj.ArmorId);
                            //GameObject EquipObj = GameObject.Find("Load_Armor" + date.Id + "/Load_Sprite_Equip_Aromr");
                            //EquipObj.SetActive(false);
                            break;
                        }
                    case 2:
                        {
                            GameObject ArmorObj = Instantiate(Grid_ArmorChild, Grid_Equip_ArmorFather_2.transform);
                            ArmorObj.name = "Load_Armor_" + date.Id;
                            Armor newArmorObj = ArmorObj.GetComponent<Armor>();
                            newArmorObj.ArmorId = date.Id;
                            ArmorObj.transform.localPosition = new Vector3(0, 0, 0);
                            ChangeArmorIconFunction(newArmorObj.ArmorId, 2, date.ArmorIconId);
                            LoadArmorRank(2, date.ArmorRank, newArmorObj.ArmorId);
                            //GameObject EquipObj = GameObject.Find("Load_Armor" + date.Id + "/Load_Sprite_Equip_Aromr");
                            //EquipObj.SetActive(false);
                            break;
                        }
                    case 3:
                        {
                            GameObject ArmorObj = Instantiate(Grid_ArmorChild, Grid_Equip_ArmorFather_3.transform);
                            ArmorObj.name = "Load_Armor_" + date.Id;
                            Armor newArmorObj = ArmorObj.GetComponent<Armor>();
                            newArmorObj.ArmorId = date.Id;
                            ArmorObj.transform.localPosition = new Vector3(0, 0, 0);
                            ChangeArmorIconFunction(newArmorObj.ArmorId, 3, date.ArmorIconId);
                            LoadArmorRank(3, date.ArmorRank, newArmorObj.ArmorId);
                            //GameObject EquipObj = GameObject.Find("Load_Armor" + date.Id + "/Load_Sprite_Equip_Aromr");
                            //EquipObj.SetActive(false);
                            break;
                        }
                    case 4:
                        {
                            GameObject ArmorObj = Instantiate(Grid_ArmorChild, Grid_Equip_ArmorFather_4.transform);
                            ArmorObj.name = "Load_Armor_" + date.Id;
                            Armor newArmorObj = ArmorObj.GetComponent<Armor>();
                            newArmorObj.ArmorId = date.Id;
                            ArmorObj.transform.localPosition = new Vector3(0, 0, 0);
                            ChangeArmorIconFunction(newArmorObj.ArmorId, 4, date.ArmorIconId);
                            LoadArmorRank(4, date.ArmorRank, newArmorObj.ArmorId);
                            //GameObject EquipObj = GameObject.Find("Load_Armor" + date.Id + "/Load_Sprite_Equip_Aromr");
                            //EquipObj.SetActive(false);
                            break;
                        }
                    case 5:
                        {
                            GameObject ArmorObj = Instantiate(Grid_ArmorChild, Grid_Equip_ArmorFather_5.transform);
                            ArmorObj.name = "Load_Armor_" + date.Id;
                            Armor newArmorObj = ArmorObj.GetComponent<Armor>();
                            newArmorObj.ArmorId = date.Id;
                            ArmorObj.transform.localPosition = new Vector3(0, 0, 0);
                            ChangeArmorIconFunction(newArmorObj.ArmorId, 5, date.ArmorIconId);
                            LoadArmorRank(5, date.ArmorRank, newArmorObj.ArmorId);
                            //GameObject EquipObj = GameObject.Find("Load_Armor" + date.Id + "/Load_Sprite_Equip_Aromr");
                            //EquipObj.SetActive(false);
                            break;
                        }
                    case 6:
                        {
                            GameObject ArmorObj = Instantiate(Grid_ArmorChild, Grid_Equip_ArmorFather_6.transform);
                            ArmorObj.name = "Load_Armor_" + date.Id;
                            Armor newArmorObj = ArmorObj.GetComponent<Armor>();
                            newArmorObj.ArmorId = date.Id;
                            ArmorObj.transform.localPosition = new Vector3(0, 0, 0);
                            ChangeArmorIconFunction(newArmorObj.ArmorId, 6, date.ArmorIconId);
                            LoadArmorRank(6, date.ArmorRank, newArmorObj.ArmorId);
                            //GameObject EquipObj = GameObject.Find("Load_Armor" + date.Id + "/Load_Sprite_Equip_Aromr");
                            //EquipObj.SetActive(false);
                            break;
                        }
                    case 7:
                        {
                            GameObject ArmorObj = Instantiate(Grid_ArmorChild, Grid_Equip_ArmorFather_7.transform);
                            ArmorObj.name = "Load_Armor_" + date.Id;
                            Armor newArmorObj = ArmorObj.GetComponent<Armor>();
                            newArmorObj.ArmorId = date.Id;
                            ArmorObj.transform.localPosition = new Vector3(0, 0, 0);
                            ChangeArmorIconFunction(newArmorObj.ArmorId, 7, date.ArmorIconId);
                            LoadArmorRank(7, date.ArmorRank, newArmorObj.ArmorId);
                            //GameObject EquipObj = GameObject.Find("Load_Armor" + date.Id + "/Load_Sprite_Equip_Aromr");
                            //EquipObj.SetActive(false);
                            break;
                        }
                    case 8:
                        {
                            GameObject ArmorObj = Instantiate(Grid_ArmorChild, Grid_Equip_ArmorFather_8.transform);
                            ArmorObj.name = "Load_Armor_" + date.Id;
                            Armor newArmorObj = ArmorObj.GetComponent<Armor>();
                            newArmorObj.ArmorId = date.Id;
                            ArmorObj.transform.localPosition = new Vector3(0, 0, 0);
                            ChangeArmorIconFunction(newArmorObj.ArmorId, 8, date.ArmorIconId);
                            LoadArmorRank(8, date.ArmorRank, newArmorObj.ArmorId);
                            //GameObject EquipObj = GameObject.Find("Load_Armor" + date.Id + "/Load_Sprite_Equip_Aromr");
                            //EquipObj.SetActive(false);
                            break;
                        }
                    case 9:
                        {
                            GameObject ArmorObj = Instantiate(Grid_ArmorChild, Grid_Equip_ArmorFather_9.transform);
                            ArmorObj.name = "Load_Armor_" + date.Id;
                            Armor newArmorObj = ArmorObj.GetComponent<Armor>();
                            newArmorObj.ArmorId = date.Id;
                            ArmorObj.transform.localPosition = new Vector3(0, 0, 0);
                            ChangeArmorIconFunction(newArmorObj.ArmorId, 9, date.ArmorIconId);
                            LoadArmorRank(9, date.ArmorRank, newArmorObj.ArmorId);
                            //GameObject EquipObj = GameObject.Find("Load_Armor" + date.Id + "/Load_Sprite_Equip_Aromr");
                            //EquipObj.SetActive(false);
                            break;
                        }
                }
            }
        }
    }

    public void ChangeArmorIconFunction(int Armorid, int ArmorType, int ArmorIconId)    //��ܸ˳ƹ�
    {
        GameObject EmptyObj = GameObject.Find("Page_Charater/Armor/Load_Armor_" + ArmorType + "/Load_Armor_"+  Armorid + "/Load_Sprite_Armor_Icon");
        Image EmptyObj_sprite = EmptyObj.GetComponent<Image>();
        GamemanagerObj.LoadBasicArmorIconFunction(ArmorIconId);
        EmptyObj_sprite.sprite = Grid_ArmorIconSpriteAtlas.GetSprite(Gamemanager.BasicArmorString);
    }

    public void LoadArmorRank(int ArmorType, int ArmorRank, int Armorid)   //��ܸ˳ƫ~�����~�ع�
    {
        GameObject EmptyObj = GameObject.Find("Page_Charater/Armor/Load_Armor_" + ArmorType + "/Load_Armor_" + Armorid);
        Image EmptyObj_sprite = EmptyObj.GetComponent<Image>();
        GamemanagerObj.LoadArmorRankFrame(ArmorRank);
        EmptyObj_sprite.sprite = Grid_ArmorIconSpriteAtlas.GetSprite(Gamemanager.ArmorRankString);
    }

    public void DestoryUnEquipArmor()   //�M�Ÿ˳ƦC���˳����̪��˳�ICON�ϡA�]�����U�˳ƫ�ݭn���s�ͦ��˳Ƥ��e
    {
        switch(Grid_Equip_ArmorFather_0.transform.childCount == 0)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    GameObject Last_Arnor_PowerObj_0 = Grid_Equip_ArmorFather_0.transform.GetChild(0).gameObject;
                    Destroy(Last_Arnor_PowerObj_0);
                    break;
                }
        }

        switch (Grid_Equip_ArmorFather_1.transform.childCount == 0)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    GameObject Last_Arnor_PowerObj_1 = Grid_Equip_ArmorFather_1.transform.GetChild(0).gameObject;
                    Destroy(Last_Arnor_PowerObj_1);
                    break;
                }
        }

        switch (Grid_Equip_ArmorFather_2.transform.childCount == 0)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    GameObject Last_Arnor_PowerObj_2 = Grid_Equip_ArmorFather_2.transform.GetChild(0).gameObject;
                    Destroy(Last_Arnor_PowerObj_2);
                    break;
                }
        }

        switch (Grid_Equip_ArmorFather_3.transform.childCount == 0)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    GameObject Last_Arnor_PowerObj_3 = Grid_Equip_ArmorFather_3.transform.GetChild(0).gameObject;
                    Destroy(Last_Arnor_PowerObj_3);
                    break;
                }
        }

        switch (Grid_Equip_ArmorFather_4.transform.childCount == 0)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    GameObject Last_Arnor_PowerObj_4 = Grid_Equip_ArmorFather_4.transform.GetChild(0).gameObject;
                    Destroy(Last_Arnor_PowerObj_4);
                    break;
                }
        }

        switch (Grid_Equip_ArmorFather_5.transform.childCount == 0)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    GameObject Last_Arnor_PowerObj_5 = Grid_Equip_ArmorFather_5.transform.GetChild(0).gameObject;
                    Destroy(Last_Arnor_PowerObj_5);
                    break;
                }
        }

        switch (Grid_Equip_ArmorFather_6.transform.childCount == 0)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    GameObject Last_Arnor_PowerObj_6 = Grid_Equip_ArmorFather_6.transform.GetChild(0).gameObject;
                    Destroy(Last_Arnor_PowerObj_6);
                    break;
                }
        }

        switch (Grid_Equip_ArmorFather_7.transform.childCount == 0)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    GameObject Last_Arnor_PowerObj_7 = Grid_Equip_ArmorFather_7.transform.GetChild(0).gameObject;
                    Destroy(Last_Arnor_PowerObj_7);
                    break;
                }
        }

        switch (Grid_Equip_ArmorFather_8.transform.childCount == 0)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    GameObject Last_Arnor_PowerObj_8 = Grid_Equip_ArmorFather_8.transform.GetChild(0).gameObject;
                    Destroy(Last_Arnor_PowerObj_8);
                    break;
                }
        }

        switch (Grid_Equip_ArmorFather_9.transform.childCount == 0)
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    GameObject Last_Arnor_PowerObj_9 = Grid_Equip_ArmorFather_9.transform.GetChild(0).gameObject;
                    Destroy(Last_Arnor_PowerObj_9);
                    break;
                }
        }
    }
}
