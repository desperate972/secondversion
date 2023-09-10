using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.U2D;
using UnityEngine.Assertions.Must;

public class Page_Skill : MonoBehaviour
{
    public GameObject Page_SkillObj;
    public GameObject Grid_SkillChild;
    public GameObject Grid_SkillFather;
    public GameObject DownPage_SkillInfo;
    public Text Load_Text_SkillName;
    public Text Load_Text_SkillInfo;
    public Text Load_Text_SkillCD;
    public Image Load_Sprite_SkillIcon;

    public SpriteAtlas Grid_SkillIconSpriteAtlas;

    public int DownPageChangeNum;

    public GameObject DownPage_Skill;
    public GameObject DownPage_Potion;
    public GameObject DownPage_PotionInfo;
    public GameObject DownPage_PotionCount;
    public GameObject DownPage_PotionTime;


    public GameObject Grid_PotionChild;
    public GameObject Grid_PotionFather;
    public Text Load_Text_PotionInfo;
    public Text Load_Text_PotionCount;
    public Text Load_Text_PotionTime;
    public Image Load_Sprite_PotionIcon;

    public Gamemanager gameobj;

    private void Awake()
	{
        //Debug.Log("gamemanager���W�r:" + gameobj.name);
		Gamemanager.SkillOrPotion = 0;
        DownPageChangeNum = 0;
        ChangeDownPage();
        LoadSkill();
        ChangeSkillIcon();
        Load_FirstSkillInfo(0);
        Load_Potion();
        ChangePotionIcon();
    }

	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSkill()  //��Ҿ֦����ޯ���ƻs�X�ӧΦ��ޯ�C��
    {
        int learnskillcount = 0;
        for (int i = 0; i < Gamemanager.Json_SkillFile.JsonSkill.Count; i++)
        {
            foreach(Json_Skill File in Gamemanager.Json_SkillFile.JsonSkill)
			{
                if(File.Id == i)
				{
                    switch(File.SkillLearn == 1)
					{
                        case true:
							{
                                GameObject SkillObj = Instantiate(Grid_SkillChild, Grid_SkillFather.transform);
                                SkillObj.name = "Skill_" + i;
                                Skill newSkillObj = SkillObj.GetComponent<Skill>();
                                newSkillObj.SkillId = i;
                                learnskillcount++;
                                break;
							}
                        case false:
							{
                                break;
							}
					}
				}
			}
        }
        Debug.Log("��ܥثe�w�ǲߪ��ޯ�ƶq: " + learnskillcount);
    }

    public void ClosePageSkill()
    {
        Page_SkillObj.SetActive(false);
    }

    public void ChangeSkillIcon()  //Ū�X�C�ӧޯ઺ICON���
    {
        foreach (Json_Skill File in Gamemanager.Json_SkillFile.JsonSkill)
        {
            switch (File.SkillLearn == 1)
            {
                case true:
                    {
                        ChangeSkillIconFunction(File.Id, File.SkillIconId);
                        break;
                    }
                case false:
                    {
                        break;
                    }
            }
        }
    }

    public void ChangeSkillIconFunction(int Skillid, int Iconid)   //��ܧޯ�ICON�ϥܪ�function�A�C�s�W�@�ӧޯ�N�ݭn�s�W
    {
        GameObject EmptyObj = GameObject.Find("Skill_" + Skillid + "/Load_Sprite_Skill_Icon");
        Image EmptyObj_sprite = EmptyObj.GetComponent<Image>();
        switch (Iconid)
        {
            case 0:
                {
                    EmptyObj_sprite.sprite = Grid_SkillIconSpriteAtlas.GetSprite("Button_Red_Choose");
                    break;
                }
            case 1:
                {
                    EmptyObj_sprite.sprite = Grid_SkillIconSpriteAtlas.GetSprite("Button_Orange_Choose");
                    break;
                }
            case 2:
                {
                    EmptyObj_sprite.sprite = Grid_SkillIconSpriteAtlas.GetSprite("Button_Blue_Choose");
                    break;
                }
            case 3:
                {
                    EmptyObj_sprite.sprite = Grid_SkillIconSpriteAtlas.GetSprite("Button_Blue");
                    break;
                }
        }
    }

    public void Load_FirstSkillInfo(int SkillId)  //��ܧޯ�Բӻ�����function
    {
        foreach (Json_Skill date in Gamemanager.Json_SkillFile.JsonSkill)
        {
            if (date.Id == SkillId)
            {
                switch (SkillId)
                {
                    case 0:
                        {
                            Load_Sprite_SkillIcon.sprite = Grid_SkillIconSpriteAtlas.GetSprite("Button_Red_Choose");
                            break;
                        }
                    case 1:
                        {
                            Load_Sprite_SkillIcon.sprite = Grid_SkillIconSpriteAtlas.GetSprite("Button_Orange_Choose");
                            break;
                        }
                    case 2:
                        {
                            Load_Sprite_SkillIcon.sprite = Grid_SkillIconSpriteAtlas.GetSprite("Button_Blue_Choose");
                            break;
                        }
                    case 3:
                        {
                            Load_Sprite_SkillIcon.sprite = Grid_SkillIconSpriteAtlas.GetSprite("Button_Blue");
                            break;
                        }
                }
                Load_Text_SkillName.text = date.SkillName;
                Load_Text_SkillInfo.text = date.SkillInfo;
                Load_Text_SkillCD.text = "�N�o:" + date.SkillCD + "��";
            }
        }
    }

    public void ClickButtonSkill()
	{
        DownPageChangeNum = 0;
        ChangeDownPage();
        Load_FirstSkillInfo(0);
        Gamemanager.SkillId_Choose = 0;
        Gamemanager.SkillOrPotion = 0;
    }

    public void ClickButtonPotion()
	{
        DownPageChangeNum = 1;
        ChangeDownPage();
        Load_FirstPotionInfo(0);
        Gamemanager.PotionId_Choose = 0;
        Gamemanager.SkillOrPotion = 1;
    }

    public void ChangeDownPage()      //�����Ĥ���ޯ�C�����s�\��
	{
        switch(DownPageChangeNum)
		{
            case 0:
				{
                    DownPage_Skill.SetActive(true);
                    DownPage_SkillInfo.SetActive(true);
                    DownPage_PotionInfo.SetActive(false);
                    DownPage_PotionCount.SetActive(false);
                    DownPage_PotionTime.SetActive(false);                  
                    break;
				}
            case 1:
				{
                    DownPage_Skill.SetActive(false);
                    DownPage_SkillInfo.SetActive(false);
                    DownPage_PotionInfo.SetActive(true);
                    DownPage_PotionCount.SetActive(true);
                    DownPage_PotionTime.SetActive(true);
                    break;
				}
		}
	}

    public void Load_Potion()        //��Ҿ֦����Ĥ����ƻs�X�ӧΦ��Ĥ��C��
    {
        Debug.Log("��ܥثe�Ĥ��ƶq: " + Gamemanager.Json_PotionFile.JsonPotion.Count);

        for (int i = 0; i < Gamemanager.Json_PotionFile.JsonPotion.Count; i++)
        {
            GameObject PotionObj = Instantiate(Grid_PotionChild, Grid_PotionFather.transform);
            PotionObj.name = "Potion_" + i;
            Potion newPotionObj = PotionObj.GetComponent<Potion>();
            newPotionObj.PotionID = i;
        }
    }

    public void ChangePotionIcon()      //Ū�X�C���Ĥ���ICON���
    {
        for (int i = 0; i < Gamemanager.Json_PotionFile.JsonPotion.Count; i++)
        {
            GameObject EmptyObj = GameObject.Find("Potion_" + i + "/Load_Sprite_Potion_Icon");
            GameObject PotionObj = GameObject.Find("Potion_" + i);
            Image EmptyObj_sprite = EmptyObj.GetComponent<Image>();
            Potion newPotionObj = PotionObj.GetComponent<Potion>();
            foreach(Json_Potion date in Gamemanager.Json_PotionFile.JsonPotion)
			{
                if(date.PotionId == newPotionObj.PotionID)
				{
                    gameobj.LoadPotionIconFunction(date.PotionIcon);
                    EmptyObj_sprite.sprite = Grid_SkillIconSpriteAtlas.GetSprite(Gamemanager.PotionIconString);                   
				}
			}
        }
    }

    public void Load_FirstPotionInfo(int PotionId)   //����Ĥ��Բӻ�����function
    {
        GameObject EmptyObj = GameObject.Find("Load_Skill/Load_Sprite_Skill_Icon");
        Image EmptyObj_sprite = EmptyObj.GetComponent<Image>();
        foreach (Json_Potion date in Gamemanager.Json_PotionFile.JsonPotion)
		{
            if(date.PotionId == PotionId)
			{
                switch (date.PotionIcon)
                {
                    case 0:
                        {
                            EmptyObj_sprite.sprite = Grid_SkillIconSpriteAtlas.GetSprite("Button_Blue");
                            break;
                        }
                    case 1:
                        {
                            EmptyObj_sprite.sprite = Grid_SkillIconSpriteAtlas.GetSprite("Button_Orange_Choose");
                            break;
                        }
                    case 2:
                        {
                            EmptyObj_sprite.sprite = Grid_SkillIconSpriteAtlas.GetSprite("Button_Red_Choose");
                            break;
                        }
                    case 3:
                        {
                            EmptyObj_sprite.sprite = Grid_SkillIconSpriteAtlas.GetSprite("Button_Blue_Choose");
                            break;
                        }
                }
                Load_Text_SkillName.text = date.PotionName;
                Load_Text_PotionInfo.text = date.PotionInfo;
                Load_Text_SkillCD.text = "�N�o:" + date.PotionCD + "��";
                Load_Text_PotionTime.text = "����:" + date.PotinTime + "��";
                Load_Text_PotionCount.text = "�̤j�R�į�:" + date.PotionCount + "��";
            }
		}
    }
}
