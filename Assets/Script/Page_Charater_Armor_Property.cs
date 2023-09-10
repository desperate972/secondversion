using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page_Charater_Armor_Property : MonoBehaviour
{

    public int ArmorId;
	public int ArmorType;

    public Page_Charater Page_CharaterObj;
    public Page_Charater_Armor Page_Charater_ArmorObj;

	public GameObject Load_Armor_PropertyObj;
	public GameObject Load_Armor_Equip_PropertyObj;

    public Gamemanager GamemangerObj;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void UnEquipArmor()  //���U�˳�
	{
		foreach (Json_Player_Armor date in Gamemanager.Json_PlayerArmorFile.JsonPlayerArmor)
        {
            if(date.Id == ArmorId)
            {
                date.ArmorEquip = 0;
            }
		}
		Page_CharaterObj.DestoryUnEquipArmor();
		Page_Charater_ArmorObj.DestoryUnEquipArmor();
		Load_Armor_Equip_PropertyObj.SetActive(false);
		Invoke("ReCreateArmor", 0.1f);
	}

    public void ReCreateArmor()
    {
		Page_CharaterObj.LoadPlayerArmor();
		Page_CharaterObj.ClickButtonArmor();
		Page_Charater_ArmorObj.Load_Equip_ArmorIcon();
		GamemangerObj.SavePlayerArmor();
	}

    public void EquipArmor()  //��W�˳�
    {
		int EquipId = 0;
		int Exchange = 0;  //�P�_�˳���̬O�_���ۦP�������˳ơA0 = �S���A1 = ��

		Debug.Log("�ثe��ܪ��˳�ID: " + ArmorId);

		foreach (Json_Player_Armor date in Gamemanager.Json_PlayerArmorFile.JsonPlayerArmor)
		{
			if (date.ArmorEquip == 1)
			{
				Debug.Log("�n�˳ƪ��˳����� " + ArmorType);

				if(date.ArmorType == ArmorType)
				{
					EquipId = date.Id;
					Exchange = 1;
				}
			}
		}

		Debug.Log("�O�_���ۦP�������˳�: " + Exchange);
		Debug.Log("�n���U���˳�ID: " + EquipId);
		Debug.Log("�n�˳ƪ��˳�ID: " + ArmorId);

		Help_UnEquipArmor(EquipId, ArmorId, Exchange);
	}

	public void Help_UnEquipArmor(int EquipArmorId, int ArmorId, int Exchange)  //�Ψ�������W�˳ƪ�Function�����U�˳�Function
	{
		Debug.Log("�O�_���ۦP�������˳ƬO�h��: " + Exchange);
		Debug.Log("�n���U���˳�ID�O�h��: " + EquipArmorId);
		Debug.Log("�n�˳ƪ��˳�ID�O�h��: " + ArmorId);

		foreach (Json_Player_Armor date in Gamemanager.Json_PlayerArmorFile.JsonPlayerArmor)
		{
			switch(Exchange)
			{
				case 0:
					{
						if (date.Id == ArmorId)
						{
							date.ArmorEquip = 1;
						}
						break;
					}
				case 1:
					{
						if (date.Id == EquipArmorId)
						{
							date.ArmorEquip = 0;
						}
						if (date.Id == ArmorId)
						{
							date.ArmorEquip = 1;
						}
						break;
					}
			}
		}

		Page_CharaterObj.DestoryUnEquipArmor();
		Page_Charater_ArmorObj.DestoryUnEquipArmor();
		Load_Armor_PropertyObj.SetActive(false);
		Load_Armor_Equip_PropertyObj.SetActive(false);
		Invoke("ReCreateArmor", 0.1f);
	}
}
