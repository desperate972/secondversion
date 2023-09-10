using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject Load_Sprite_PlayerHpObj;
    public GameObject Load_Sprite_PlayerMpObj;
    public GameObject Load_Sprite_PlayerExpObj;
    public Text Load_Text_PlayerHp;
    public Text Load_Text_PlayerMp;
    public Text Load_Text_PlayerExp;
    public Text Load_Text_PlayerLv;

    public GameObject Page_Charater;
    public GameObject Page_Item;
    public GameObject Page_Skill;

    public GameObject GamemanagerObj;

    public Gamemanager GamemangerObj;

    private void Awake()
    {
        Load_PlayerInfo();
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
        //-----�D�e���W��ܨ����q�ƭȸ��q�Ϥ����
        float PlayerHp = Json_Battle_Static.HpNow / Json_Battle_Static.Hp;
        float Load_Sprite_PlayerHpImageWidth = Load_Sprite_PlayerHpObj.GetComponent<RectTransform>().rect.width;
        float Load_Sprite_PlayerHpImageHeight = Load_Sprite_PlayerHpObj.GetComponent<RectTransform>().rect.height;
        Load_Sprite_PlayerHpObj.GetComponent<RectTransform>().sizeDelta = new Vector2((Load_Sprite_PlayerHpImageWidth * PlayerHp), Load_Sprite_PlayerHpImageHeight);
        Load_Text_PlayerHp.text = Json_Battle_Static.HpNow.ToString() + "/" + Json_Battle_Static.Hp.ToString();
        //-----

        //-----�D�e���W��ܨ����]�q�ƭȸ��]�q�Ϥ����
        float PlayerMp = Json_Battle_Static.MpNow / Json_Battle_Static.Mp;
        float Load_Sprite_PlayerMpImageWidth = Load_Sprite_PlayerMpObj.GetComponent<RectTransform>().rect.width;
        float Load_Sprite_PlayerMpImageHeight = Load_Sprite_PlayerMpObj.GetComponent<RectTransform>().rect.height;
        Load_Sprite_PlayerMpObj.GetComponent<RectTransform>().sizeDelta = new Vector2((Load_Sprite_PlayerMpImageWidth * PlayerHp), Load_Sprite_PlayerMpImageHeight);
        Load_Text_PlayerMp.text = Json_Battle_Static.MpNow.ToString() + "/" + Json_Battle_Static.Mp.ToString();
        //-----

        //-----�D�e���W��ܨ���g��ȼƭȸ�g��ȹϤ����
        float PlayerExp = (Json_Player_Static.PlayerExpNow == 0) ? 1 : Json_Player_Static.PlayerExpNow / Json_Player_Static.PlayerExp;
        float Load_Sprite_PlayerExpImageWidth = Load_Sprite_PlayerExpObj.GetComponent<RectTransform>().rect.width;
        float Load_Sprite_PlayerExpImageHeight = Load_Sprite_PlayerExpObj.GetComponent<RectTransform>().rect.height;
        Load_Sprite_PlayerExpObj.GetComponent<RectTransform>().sizeDelta = new Vector2((Load_Sprite_PlayerExpImageWidth * PlayerExp), Load_Sprite_PlayerExpImageHeight);
        Load_Text_PlayerExp.text = Json_Player_Static.PlayerExpNow.ToString() + "/" + Json_Player_Static.PlayerExp.ToString();
        //-----

        //-----��ܨ����e����
        Load_Text_PlayerLv.text = "Lv:" + Json_Player_Static.Player_Lv.ToString();
        //-----
    }    

    public void OpenPageCharater()
    {
        Page_Charater.SetActive(true);
    }

    public void OpenPageItem()
    {
        Page_Item.SetActive(true);
    }

    public void OpenPageSkill()
    {
        Page_Skill.SetActive(true);
    }

    public void LoadBattle()
    {
        GamemanagerObj = GameObject.Find("GameManager");
        GamemangerObj = GamemanagerObj.GetComponent<Gamemanager>();
        GamemangerObj.LoadBattleSenceFunction();
    }
}
