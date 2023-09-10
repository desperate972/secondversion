using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Calculate : MonoBehaviour
{
    public Gamemanager GamemanagerObj;

	private float SkillDamageRate;
	private int SkillType;
	private int[] SkillTag;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CalculatePlayerDamge(int SkillId, out float Damge)   //
	{
        Damge = 0;
        bool CritSuccess;
		GamemanagerObj.LoadSkill();
        foreach(Json_Skill date in Gamemanager.Json_SkillFile.JsonSkill)
        {
            if(date.Id == SkillId)
            {
				SkillDamageRate = date.SkillDamageRate;
				SkillType = date.SkillType;
				SkillTag = date.SkillTag;
			}
		}
        switch(SkillType)
        {
            case 0:
                {
                    CalculatePlayerCrit(out CritSuccess);
					float PlayerDamge = UnityEngine.Random.Range(Json_Battle_Static.AttackDamge_Min, (Json_Battle_Static.AttackDamge_Max + 1));
                    //Debug.Log("這次攻擊骰出的物理攻擊力為: " + PlayerDamge);
                    PlayerDamge = Mathf.Round((PlayerDamge * SkillDamageRate) / 100);
					Debug.Log("這次攻擊骰出的物理攻擊力為: " + PlayerDamge);
					switch(CritSuccess)
                    {
                        case true:
                            {
								Damge = Mathf.Round(PlayerDamge * 1.5f);
								break;
                            }
                        case false:
                            {
								Damge = PlayerDamge;
								break;
                            }
                    }
                    
                    //Damge = PlayerDamge;
					break;
                }
            case 1:
                {
					CalculatePlayerCrit(out CritSuccess);
					float PlayerDamge = UnityEngine.Random.Range(Json_Battle_Static.MagicDamge_Min, (Json_Battle_Static.MagicDamge_Max + 1));
					//Debug.Log("這次攻擊骰出的魔法攻擊力為: " + PlayerDamge);
					PlayerDamge = Mathf.Round((PlayerDamge * SkillDamageRate) / 100);
					Debug.Log("這次攻擊骰出的魔法攻擊力為: " + PlayerDamge);
					switch (CritSuccess)
					{
						case true:
							{
								Damge = Mathf.Round(PlayerDamge * 1.5f);
								break;
							}
						case false:
							{
								Damge = PlayerDamge;
								break;
							}
					}

					//Damge = PlayerDamge;
					break;
                }
        }
	}

    public void CalculatePlayerCrit(out bool CritSuccess)
    {
        Debug.Log("爆擊機率:" + Json_Battle_Static.CritRate + "%");
        bool[] CrieArray = new bool[100];
        int critnmum = Convert.ToInt32(Json_Battle_Static.CritRate * 100);
		int crittrueorfalse = UnityEngine.Random.Range(0, 100);
		for (int i = 0; i < critnmum; i++)
        {
            CrieArray[i] = true;
		}
        switch(CrieArray[crittrueorfalse])
        {
            case true:
                {
					CritSuccess = true;
                    Debug.Log("成功造成爆擊攻擊!!");
					break;
                }
            case false: 
                {
					CritSuccess = false;
					Debug.Log("未能造成爆擊攻擊!!");
					break;
                }
        }



        //----檢查內容用
        /*for(int i = 0; i < 100; i++)
        {
			Debug.Log("目前是陣列裡的第" + i + "個，裡面的內容是" + CrieArray[i]);
		}*/
        //--
	}

    public void CalulatePlayerArmor(float MonsterDamge, out float MonsterTrueDamge)
    {
		Debug.Log("物理傷害減免: " + Json_Battle_Static.ArmorRate + "%");
        Debug.Log("怪物造成傷害: " + MonsterDamge);
        float damge = (100 - (Json_Battle_Static.ArmorRate * 100)) / 100;
        damge = Mathf.Round(damge * 100f) / 100f;
		MonsterTrueDamge = MonsterDamge * damge;

		Debug.Log("傷害減免後的怪物造成傷害: " + MonsterTrueDamge);




		/*  這裡用來判斷怪物的攻擊是物理還是魔法
        switch()
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    break;
                }
        }*/
	}
}
