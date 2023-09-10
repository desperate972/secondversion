using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class Page_Item : MonoBehaviour
{

    public GameObject Page_ItemObj;

    public GameObject Grid_ItemChild;
    public GameObject Grid_ItemFather;
    public SpriteAtlas Grid_ItemIconSpriteAtlas;

    public Text Load_Text_ItemName;
    public Text Load_Text_ItemInfo;
    public Image Load_Sprite_ItemIcon;

	private void Awake()
	{
        LoadItem();
        ChangeItemIcon();
        Load_FirstItemInfo(0);
    }

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClosePageItem()
	{
        Page_ItemObj.SetActive(false);
	}

    public void LoadItem()  //��Ҿ֦����D����ƻs�X�ӧΦ��D��C��
    {
        Debug.Log("��ܥثe�D��ƶq: " + Gamemanager.Json_ItemFile.JsonItem.Count);

        for (int i = 0; i < Gamemanager.Json_ItemFile.JsonItem.Count; i++)
        {
            GameObject ItemObj = Instantiate(Grid_ItemChild, Grid_ItemFather.transform);
            ItemObj.name = "Item_" + i;
            Item newItemObj = ItemObj.GetComponent<Item>();
            newItemObj.ItemId = i;
        }
    }

    public void ChangeItemIcon()  //Ū�X�C�ӹD�㪺ICON���
    {
        foreach (Json_Item date in Gamemanager.Json_ItemFile.JsonItem)
        {
            ChangeItemIconFunction(date.Id, date.ItemIconId);
            ChangeItemNumFunction(date.Id, date.ItemNum);
        }
    }

    public void ChangeItemIconFunction(int Itemid, int Iconid)   //��ܹD��ICON�ϥܪ�function�A�C�s�W�@�ӹD��N�ݭn�s�W
    {
        GameObject EmptyObj = GameObject.Find("Item_" + Itemid + "/Load_Sprite_Item_Icon");
        Image EmptyObj_sprite = EmptyObj.GetComponent<Image>();
        switch (Iconid)
        {
            case 0:
                {
                    EmptyObj_sprite.sprite = Grid_ItemIconSpriteAtlas.GetSprite("Button_Red_Choose");
                    break;
                }
            case 1:
                {
                    EmptyObj_sprite.sprite = Grid_ItemIconSpriteAtlas.GetSprite("Button_Orange_Choose");
                    break;
                }
        }
    }

    public void ChangeItemNumFunction(int Itemid, int ItemNum)   //��ܹD��ƶq��function
    {
        GameObject EmptyObj = GameObject.Find("Item_" + Itemid + "/Load_Text_Num");
        Text Empty_Text = EmptyObj.GetComponent<Text>();
        Empty_Text.text = ItemNum.ToString();
    }

    public void Load_FirstItemInfo(int ItemId)  //��ܹD��Բӻ�����function
    {
        foreach (Json_Item date in Gamemanager.Json_ItemFile.JsonItem)
        {
            if (date.Id == ItemId)
            {
                switch (ItemId)
                {
                    case 0:
                        {
                            Load_Sprite_ItemIcon.sprite = Grid_ItemIconSpriteAtlas.GetSprite("Button_Red_Choose");
                            break;
                        }
                    case 1:
                        {
                            Load_Sprite_ItemIcon.sprite = Grid_ItemIconSpriteAtlas.GetSprite("Button_Orange_Choose");
                            break;
                        }
                }
                Load_Text_ItemName.text = date.ItemName;
                Load_Text_ItemInfo.text = date.ItemInfo;
            }
        }
    }
}
