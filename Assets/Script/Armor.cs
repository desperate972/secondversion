using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public int ArmorId;
    public Page_Charater_Armor PageCharaterArmorObj;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickArmorIcon()
    {
        PageCharaterArmorObj.ClickArmorIcon(ArmorId);
	}

}
