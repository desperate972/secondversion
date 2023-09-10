using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public int PotionID;
    public Page_Skill PageSkillObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickPotionIcon()
    {
        PageSkillObj.Load_FirstPotionInfo(PotionID);
        Gamemanager.PotionId_Choose = PotionID;
        //Gamemanager.SkillOrPotion_Queue = this.gameObject.name;
        //Debug.Log("這個元件的名稱:" + this.gameObject.name);
    }
}
