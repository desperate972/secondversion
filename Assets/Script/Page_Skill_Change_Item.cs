using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class Page_Skill_Change_Item : MonoBehaviour
{
    public int Id;
    public int Type;
    public Page_Skill_Change Obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickButton()
    {
        Gamemanager.SkillOrPotion_Change = Id;
        Gamemanager.SkillOrPotionType_Change = Type;
        Gamemanager.SkillOrPotion_Queue = this.gameObject.name;
        Debug.Log("這個元件的名稱:" + this.gameObject.name);
        Debug.Log("這個技能的編號:" + Id);
        Obj.ClickButton();
    }
}
