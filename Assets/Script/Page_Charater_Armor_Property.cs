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

	public void UnEquipArmor()  //卸下裝備
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

    public void EquipArmor()  //穿上裝備
    {
		int EquipId = 0;
		int Exchange = 0;  //判斷裝備欄裡是否有相同類型的裝備，0 = 沒有，1 = 有

		Debug.Log("目前選擇的裝備ID: " + ArmorId);

		foreach (Json_Player_Armor date in Gamemanager.Json_PlayerArmorFile.JsonPlayerArmor)
		{
			if (date.ArmorEquip == 1)
			{
				Debug.Log("要裝備的裝備類型 " + ArmorType);

				if(date.ArmorType == ArmorType)
				{
					EquipId = date.Id;
					Exchange = 1;
				}
			}
		}

		Debug.Log("是否有相同類型的裝備: " + Exchange);
		Debug.Log("要卸下的裝備ID: " + EquipId);
		Debug.Log("要裝備的裝備ID: " + ArmorId);

		Help_UnEquipArmor(EquipId, ArmorId, Exchange);
	}

	public void Help_UnEquipArmor(int EquipArmorId, int ArmorId, int Exchange)  //用來幫忙穿上裝備的Function的卸下裝備Function
	{
		Debug.Log("是否有相同類型的裝備是多少: " + Exchange);
		Debug.Log("要卸下的裝備ID是多少: " + EquipArmorId);
		Debug.Log("要裝備的裝備ID是多少: " + ArmorId);

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
