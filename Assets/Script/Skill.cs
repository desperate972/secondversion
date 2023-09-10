using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public int SkillId;
    public Page_Skill PageSkillObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickSkillIcon()
    {
        PageSkillObj.Load_FirstSkillInfo(SkillId);
        Gamemanager.SkillId_Choose = SkillId;
        //Gamemanager.SkillOrPotion_Queue = this.gameObject.name;
        //Debug.Log("這個元件的名稱:" + this.gameObject.name);
    }
}
