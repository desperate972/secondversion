using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ItemId;
    public Page_Item PageItemObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickItemIcon()
    {
        PageItemObj.Load_FirstItemInfo(ItemId);
    }
}
