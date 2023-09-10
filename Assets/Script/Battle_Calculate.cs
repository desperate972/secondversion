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
                    //Debug.Log("�o��������X�����z�����O��: " + PlayerDamge);
                    PlayerDamge = Mathf.Round((PlayerDamge * SkillDamageRate) / 100);
					Debug.Log("�o��������X�����z�����O��: " + PlayerDamge);
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
					//Debug.Log("�o��������X���]�k�����O��: " + PlayerDamge);
					PlayerDamge = Mathf.Round((PlayerDamge * SkillDamageRate) / 100);
					Debug.Log("�o��������X���]�k�����O��: " + PlayerDamge);
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
        Debug.Log("�z�����v:" + Json_Battle_Static.CritRate + "%");
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
                    Debug.Log("���\�y���z������!!");
					break;
                }
            case false: 
                {
					CritSuccess = false;
					Debug.Log("����y���z������!!");
					break;
                }
        }



        //----�ˬd���e��
        /*for(int i = 0; i < 100; i++)
        {
			Debug.Log("�ثe�O�}�C�̪���" + i + "�ӡA�̭������e�O" + CrieArray[i]);
		}*/
        //--
	}

    public void CalulatePlayerArmor(float MonsterDamge, out float MonsterTrueDamge)
    {
		Debug.Log("���z�ˮ`��K: " + Json_Battle_Static.ArmorRate + "%");
        Debug.Log("�Ǫ��y���ˮ`: " + MonsterDamge);
        float damge = (100 - (Json_Battle_Static.ArmorRate * 100)) / 100;
        damge = Mathf.Round(damge * 100f) / 100f;
		MonsterTrueDamge = MonsterDamge * damge;

		Debug.Log("�ˮ`��K�᪺�Ǫ��y���ˮ`: " + MonsterTrueDamge);




		/*  �o�̥ΨӧP�_�Ǫ��������O���z�٬O�]�k
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
