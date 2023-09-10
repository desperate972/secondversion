using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.U2D;
using System.IO;

public class Page_Skill_Change : MonoBehaviour
{
    public GameObject Load_ChangeSkillItem;

    public GameObject SkillChooseObj_1;
    public GameObject SkillChooseObj_2;
    public GameObject SkillChooseObj_3;

    public GameObject ItemChooseObj_1;
    public GameObject ItemChooseObj_2;

    public Image SkillChoose_1;
    public Image SkillChoose_2;
    public Image SkillChoose_3;
    public Image ItemChoose_1;
    public Image ItemChoose_2;

    public Image Attack_1;
    public Image Attack_2;
    public Image Attack_3;
    public Image Item_1;
    public Image Item_2;

    public SpriteAtlas Grid_SkillIconSpriteAtlas;

    public Gamemanager gameobj;

    public Image Choose_Icon;
    public Text Choose_Name;
    public Text Choose_Info;
    public Text Choose_Potion_Count;
    public Text Choose_CD;
    public Text Potion_Time;
    public Text Potion_Info;

    public GameObject Skill_InfoObj;
    public GameObject Potion_InfoObj;
    public GameObject Potion_TimeObj;

    public GameObject Button_Attack_1;
    public GameObject Button_Attack_2;
    public GameObject Button_Attack_3;
    public GameObject Button_Item_1;
    public GameObject Button_Item_2;

    public GameObject Skill_InfoObj_Change;
    public GameObject Potion_InfoObj_Change;
    public GameObject Potion_TimeObj_Change;

    public Image Change_Icon;
    public Text Change_Name;
    public Text Change_Info;
    public Text Change_Potion_Count;
    public Text Change_CD;
    public Text Potion_Time_Change;
    public Text Potion_Info_Change;

    public GameObject FirstObj;

    private float imagealpha;
    private bool imagealphachange;
    
    private void Awake()
	{
        //imagealpha = 0.1f;
        imagealphachange = false;
        imagealpha = 1f;
        SetButtonId();
    }

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void FixedUpdate()
	{
        
    }

	public void ClickChangeButton() //�}�ҭn�󴫧ޯ���Ĥ�������
	{
        Load_ChangeSkillItem.SetActive(true);
        ChooseId();        
    }

    public void ClosePage_Load_ChangeSkillItem()   //�����n�󴫧ޯ���Ĥ�������
    {
        Load_ChangeSkillItem.SetActive(false);
        FirstObj.SetActive(true);
        CancelInvoke("ChangeFunction");
    }

    public void ChooseId()   //�̷Ӫ��a��ܭn�󴫪��O�ޯ��٬O�Ĥ��A�N��T��ܦb�󴫪������W
	{
        switch(Gamemanager.SkillOrPotion)
		{
            case 0:
				{
                    Debug.Log("�o���˳ƪ����e�O�ޯ�");
                    SkillChooseObj_1.SetActive(true);
                    SkillChooseObj_2.SetActive(true);
                    SkillChooseObj_3.SetActive(true);
                    ItemChooseObj_1.SetActive(false);
                    ItemChooseObj_2.SetActive(false);
                    InvokeRepeating("ChangeFunction", 0f, 0.05f);
                    ShowAlreadySkillAndPotion();
                    ShowChangeSkillOrPotionInfo(Gamemanager.SkillId_Choose, 0);
                    break;
				}
            case 1:
				{
                    Debug.Log("�o���˳ƪ����e�O�Ĥ�");
                    SkillChooseObj_1.SetActive(false);
                    SkillChooseObj_2.SetActive(false);
                    SkillChooseObj_3.SetActive(false);
                    ItemChooseObj_1.SetActive(true);
                    ItemChooseObj_2.SetActive(true);
                    InvokeRepeating("ChangeFunction", 0f, 0.05f);
                    ShowAlreadySkillAndPotion();
                    ShowChangeSkillOrPotionInfo(Gamemanager.PotionId_Choose, 1);
                    break;
				}
		}
	}

    public void ChangeFunction()   //�̷Ӫ��a��ܭn�󴫪��O�ޯ��٬O�Ĥ��A�b�󴫤����W�W�P���������e�{�{
	{
        ChangeChooseImage(SkillChooseObj_1, SkillChoose_1);
        ChangeChooseImage(SkillChooseObj_2, SkillChoose_2);
        ChangeChooseImage(SkillChooseObj_3, SkillChoose_3);
        ChangeChooseImage(ItemChooseObj_1, ItemChoose_1);
        ChangeChooseImage(ItemChooseObj_2, ItemChoose_2);
    }

    public void ChangeChooseImage(GameObject choose, Image chooseImage)  //�{�{���\��
	{
        chooseImage = choose.GetComponent<Image>();
        Color i = chooseImage.color;
        //i.a = imagealpha;
        //bool t = true;

        
        if (i.a >= 0f && imagealphachange == true)
		{
            //�]���@�}�l�O����������W��alpha�ȨӰ����B��l�A�����ȫܮe������p���I�H�U�ܦh��A�ɭP�p�⵲�G���p�w��
            //�ҥH�令�t���ܼƨӰ����B��l�i��B��A����A���n�᪺�Ȧ^�ǵ�����W��alpha��
            //�|�ϥ�string�O���F���p���I�H�U���Ʀr

            float num = 0.01f;
            string gg = "";
            imagealpha = imagealpha + num;  
            gg = imagealpha.ToString("f2");   //�קK�b�p��ɥX�{�W�X�w�����p���I�ƭȡA�ӥu���p���I�H�U��쪺���k
            imagealpha = float.Parse(gg);
            i.a = imagealpha;
        }

        if(i.a <= 1f && imagealphachange == false)
		{
            float num = 0.01f;
            string gg = "";
            imagealpha = imagealpha - num;
            gg = imagealpha.ToString("f2");   //�קK�b�p��ɥX�{�W�X�w�����p���I�ƭȡA�ӥu���p���I�H�U��쪺���k
            imagealpha = float.Parse(gg);
            i.a = imagealpha;
        }

        if (i.a <= 0 && imagealphachange == false)
        {
            imagealphachange = true;
        }

        if (i.a >= 1 && imagealphachange == true)
        {
            imagealphachange = false;
        }

        chooseImage.color = i;
    }

    public void ShowAlreadySkillAndPotion()   //��ܭ쥻�˳ƪ��ޯ���Ĥ����ϥ�
    {
        LoadIcon(Json_Battle_Player_Static.Attack_SkillId_1, Attack_1, 0);
        LoadIcon(Json_Battle_Player_Static.Attack_SkillId_2, Attack_2, 0);
        LoadIcon(Json_Battle_Player_Static.Attack_SkillId_3, Attack_3, 0);
        LoadIcon(Json_Battle_Player_Static.PotionId_1, Item_1, 1);
        LoadIcon(Json_Battle_Player_Static.PotionId_2, Item_2, 1);
    }

    public void LoadIcon(int Iconid, Image IconObj, int type)   //��ܧޯ�άO�Ĥ���ICON�ϥܪ�function�A0 = Skill�A1 = Potion
    {
        switch(type)
		{
            case 0:
				{
                    gameobj.LoadSkillIconFunction(Iconid);
                    IconObj.sprite = Grid_SkillIconSpriteAtlas.GetSprite(Gamemanager.SkillIconString);
                    break;
				}
            case 1:
				{
                    gameobj.LoadPotionIconFunction(Iconid);
                    IconObj.sprite = Grid_SkillIconSpriteAtlas.GetSprite(Gamemanager.PotionIconString);
                    break;
				}
		}
    }

    public void ShowChangeSkillOrPotionInfo(int SkillOrPotionId, int SkillOrPotionType)  //��ܭn�˳ƪ��ޯ�άO�Ĥ�����T�ASkillOrPotionType���Ʀr�ӧP�_�ثe���a��ܪ��O�ƻ������A0 = Skill�A1 = Potion
    {
        switch(SkillOrPotionType)
		{
            case 0:
				{
                    Potion_TimeObj.SetActive(false);
                    Potion_InfoObj.SetActive(false);
                    Skill_InfoObj.SetActive(true);
                    gameobj.LoadSkillIconFunction(SkillOrPotionId);
                    Choose_Icon.sprite = Grid_SkillIconSpriteAtlas.GetSprite(Gamemanager.SkillIconString);
                    foreach (Json_Skill date in Gamemanager.Json_SkillFile.JsonSkill)
					{
                        if(date.Id == SkillOrPotionId)
						{
                            Choose_Name.text = date.SkillName;
                            Choose_Info.text = date.SkillInfo;
                            Choose_CD.text = "�N�o:" + date.SkillCD + "��";
                        }
					}
                    break;
				}
            case 1:
				{
                    Potion_TimeObj.SetActive(true);
                    Potion_InfoObj.SetActive(true);
                    Skill_InfoObj.SetActive(false);
                    gameobj.LoadPotionIconFunction(SkillOrPotionId);
                    Choose_Icon.sprite = Grid_SkillIconSpriteAtlas.GetSprite(Gamemanager.PotionIconString);
                    foreach (Json_Potion date in Gamemanager.Json_PotionFile.JsonPotion)
                    {
                        if (date.PotionId == SkillOrPotionId)
                        {
                            Choose_Name.text = date.PotionName;
                            Potion_Info.text = date.PotionInfo;
                            Choose_CD.text = "�N�o:" + date.PotionCD + "��";
                            Choose_Potion_Count.text = "�̤j�R��:" + date.PotionCount + "��";
                            Potion_Time.text = "����:" + date.PotinTime + "��";
                        }
                    }
                    break;
				}
		}
	}

    public void SetButtonId()    //Ū���ثe�w�˳ƪ��ޯ���Ĥ���ID��U�۪����s�W
	{
        Page_Skill_Change_Item Button_Attack_1_Obj = Button_Attack_1.GetComponent<Page_Skill_Change_Item>();
        Page_Skill_Change_Item Button_Attack_2_Obj = Button_Attack_2.GetComponent<Page_Skill_Change_Item>();
        Page_Skill_Change_Item Button_Attack_3_Obj = Button_Attack_3.GetComponent<Page_Skill_Change_Item>();
        Page_Skill_Change_Item Button_Item_1_Obj = Button_Item_1.GetComponent<Page_Skill_Change_Item>();
        Page_Skill_Change_Item Button_Item_2_Obj = Button_Item_2.GetComponent<Page_Skill_Change_Item>();
        Button_Attack_1_Obj.Id = Json_Battle_Player_Static.Attack_SkillId_1;
        Button_Attack_2_Obj.Id = Json_Battle_Player_Static.Attack_SkillId_2;
        Button_Attack_3_Obj.Id = Json_Battle_Player_Static.Attack_SkillId_3;
        Button_Item_1_Obj.Id = Json_Battle_Player_Static.PotionId_1;
        Button_Item_2_Obj.Id = Json_Battle_Player_Static.PotionId_2;
        Button_Attack_1_Obj.Type = 0;
        Button_Attack_2_Obj.Type = 0;
        Button_Attack_3_Obj.Type = 0;
        Button_Item_1_Obj.Type = 1;
        Button_Item_2_Obj.Type = 1;
    }

    public void ClickButton()  //��ܭn�󴫪��ޯ���Ĥ���ܥX��T
	{
        FirstObj.SetActive(false);
        switch (Gamemanager.SkillOrPotionType_Change == Gamemanager.SkillOrPotion)
        {
            case true:
				{
                    switch(Gamemanager.SkillOrPotionType_Change)
					{
                        case 0:
							{
                                Skill_InfoObj_Change.SetActive(true);
                                Potion_InfoObj_Change.SetActive(false);
                                Potion_TimeObj_Change.SetActive(false);
                                gameobj.LoadSkillIconFunction(Gamemanager.SkillOrPotion_Change);
                                Change_Icon.sprite = Grid_SkillIconSpriteAtlas.GetSprite(Gamemanager.SkillIconString);
                                foreach (Json_Skill date in Gamemanager.Json_SkillFile.JsonSkill)
                                {
                                    if (date.Id == Gamemanager.SkillOrPotion_Change)
                                    {
                                        Change_Name.text = date.SkillName;
                                        Change_Info.text = date.SkillInfo;
                                        Change_CD.text = "�N�o:" + date.SkillCD + "��";
                                    }
                                }
                                break;
							}
                        case 1:
							{
                                Skill_InfoObj_Change.SetActive(false);
                                Potion_InfoObj_Change.SetActive(true);
                                Potion_TimeObj_Change.SetActive(true);
                                gameobj.LoadPotionIconFunction(Gamemanager.SkillOrPotion_Change);
                                Change_Icon.sprite = Grid_SkillIconSpriteAtlas.GetSprite(Gamemanager.PotionIconString);
                                foreach (Json_Potion date in Gamemanager.Json_PotionFile.JsonPotion)
                                {
                                    if (date.PotionId == Gamemanager.SkillOrPotion_Change)
                                    {
                                        Change_Name.text = date.PotionName;
                                        Potion_Info_Change.text = date.PotionInfo;
                                        Change_CD.text = "�N�o:" + date.PotionCD + "��";
                                        Change_Potion_Count.text = "�̤j�R��:" + date.PotionCount + "��";
                                        Potion_Time_Change.text = "����:" + date.PotinTime + "��";
                                    }
                                }
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

    public void ChangeSkillOrPotion()  //�T��n�����ޯ���Ĥ����\��
	{
        string Queue;
        KnowSkillOrPotionQueue(out Queue);
        Debug.Log("��e��ܪ��ޯस��:" + Queue);
        Debug.Log("��e�n����������:" + Gamemanager.SkillOrPotionType_Change);
        switch (Gamemanager.SkillOrPotionType_Change)
		{
            case 0:  //�n�󴫪��O�ޯ�
				{
                    Debug.Log("��e��ܪ��ޯ�s��:" + Gamemanager.SkillId_Choose); 
                    gameobj.LoadSkill();
                    switch (Queue)
					{
                        case "Attack_Queue_1":
							{
                                foreach (Json_Skill date in Gamemanager.Json_SkillFile.JsonSkill)
                                {
                                    if (date.Id == Gamemanager.SkillId_Choose)
                                    {
                                        Json_Battle_Player_Static.Attack_SkillId_1 = date.Id;
                                        Json_Battle_Player_Static.AttackCD_1 = date.SkillCD;
                                        Json_Battle_Player_Static.AttackDamageRate_1 = date.SkillDamageRate;
                                        Json_Battle_Player_Static.AttackType_1 = date.SkillType;
                                        Json_Battle_Player_Static.AttackSkillName_1 = date.SkillName;
                                    }
                                }
                                gameobj.Change_Player_Battle_ToFile();
                                string FileNew = JsonUtility.ToJson(Gamemanager.Json_Player_BattleFile);
                                File.WriteAllText(Application.persistentDataPath + @"\Player_Battle.json", FileNew);
                                ClosePage_Load_ChangeSkillItem();                                
                                break;
							}
                        case "Attack_Queue_2":
                            {
                                foreach (Json_Skill date in Gamemanager.Json_SkillFile.JsonSkill)
                                {
                                    if (date.Id == Gamemanager.SkillId_Choose)
                                    {
                                        Json_Battle_Player_Static.Attack_SkillId_2 = date.Id;
                                        Json_Battle_Player_Static.AttackCD_2 = date.SkillCD;
                                        Json_Battle_Player_Static.AttackDamageRate_2 = date.SkillDamageRate;
                                        Json_Battle_Player_Static.AttackType_2 = date.SkillType;
                                        Json_Battle_Player_Static.AttackSkillName_2 = date.SkillName;
                                    }
                                }
                                gameobj.Change_Player_Battle_ToFile();
                                string FileNew = JsonUtility.ToJson(Gamemanager.Json_Player_BattleFile);
                                File.WriteAllText(Application.persistentDataPath + @"\Player_Battle.json", FileNew);
                                ClosePage_Load_ChangeSkillItem();
                                break;
                            }
                        case "Attack_Queue_3":
                            {
                                foreach (Json_Skill date in Gamemanager.Json_SkillFile.JsonSkill)
                                {
                                    if (date.Id == Gamemanager.SkillId_Choose)
                                    {
                                        Json_Battle_Player_Static.Attack_SkillId_3 = date.Id;
                                        Json_Battle_Player_Static.AttackCD_3 = date.SkillCD;
                                        Json_Battle_Player_Static.AttackDamageRate_3 = date.SkillDamageRate;
                                        Json_Battle_Player_Static.AttackType_3 = date.SkillType;
                                        Json_Battle_Player_Static.AttackSkillName_3 = date.SkillName;
                                    }
                                }
                                gameobj.Change_Player_Battle_ToFile();
                                string FileNew = JsonUtility.ToJson(Gamemanager.Json_Player_BattleFile);
                                File.WriteAllText(Application.persistentDataPath + @"\Player_Battle.json", FileNew);
                                ClosePage_Load_ChangeSkillItem();
                                break;
                            }
                    }
                    break;
				}
            case 1:  //�n�󴫪��O�Ĥ�
                {
                    Debug.Log("��e��ܪ��ޯ�s��:" + Gamemanager.PotionId_Choose);
                    gameobj.LoadPotion();
                    switch(Queue)
					{
                        case "Potion_Queue_1":
							{
                                foreach (Json_Potion date in Gamemanager.Json_PotionFile.JsonPotion)
                                {
                                    if (date.PotionId == Gamemanager.PotionId_Choose)
                                    {
                                        Json_Battle_Player_Static.PotionId_1 = date.PotionId;
                                        Json_Battle_Player_Static.PotionCD_1 = date.PotionCD;
                                        Json_Battle_Player_Static.PotionType_1 = date.PotionType;
                                        Json_Battle_Player_Static.PotionCount_1 = date.PotionCount;
                                        Json_Battle_Player_Static.Potion_ml_1 = date.Potionml;
                                        Json_Battle_Player_Static.PotinTime_1 = date.PotinTime;
                                        Json_Battle_Player_Static.PotionName_1 = date.PotionName;
                                    }
                                }
                                gameobj.Change_Player_Battle_ToFile();
                                string FileNew = JsonUtility.ToJson(Gamemanager.Json_Player_BattleFile);
                                File.WriteAllText(Application.persistentDataPath + @"\Player_Battle.json", FileNew);
                                ClosePage_Load_ChangeSkillItem();
                                break;
							}
                        case "Potion_Queue_2":
                            {
                                foreach (Json_Potion date in Gamemanager.Json_PotionFile.JsonPotion)
                                {
                                    if (date.PotionId == Gamemanager.PotionId_Choose)
                                    {
                                        Json_Battle_Player_Static.PotionId_2 = date.PotionId;
                                        Json_Battle_Player_Static.PotionCD_2 = date.PotionCD;
                                        Json_Battle_Player_Static.PotionType_2 = date.PotionType;
                                        Json_Battle_Player_Static.PotionCount_2 = date.PotionCount;
                                        Json_Battle_Player_Static.Potion_ml_2 = date.Potionml;
                                        Json_Battle_Player_Static.PotinTime_2 = date.PotinTime;
                                        Json_Battle_Player_Static.PotionName_2 = date.PotionName;
                                    }
                                }
                                gameobj.Change_Player_Battle_ToFile();
                                string FileNew = JsonUtility.ToJson(Gamemanager.Json_Player_BattleFile);
                                File.WriteAllText(Application.persistentDataPath + @"\Player_Battle.json", FileNew);
                                ClosePage_Load_ChangeSkillItem();
                                break;
                            }
                    }
                    break;
				}
        }
        gameobj.Load_Player_Battle();
        SetButtonId();
    }

    public void KnowSkillOrPotionQueue(out string QueueString)
	{
        QueueString = "";
        switch (Gamemanager.SkillOrPotion_Queue)
		{
            case "Button_Attack_1":
				{
                    QueueString = "Attack_Queue_1";
                    break;
				}
            case "Button_Attack_2":
                {
                    QueueString = "Attack_Queue_2";
                    break;
                }
            case "Button_Attack_3":
                {
                    QueueString = "Attack_Queue_3";
                    break;
                }
            case "Button_Item_1":
                {
                    QueueString = "Potion_Queue_1";
                    break;
                }
            case "Button_Item_2":
                {
                    QueueString = "Potion_Queue_2";
                    break;
                }
        }
	}
}
