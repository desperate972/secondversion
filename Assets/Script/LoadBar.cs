using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadBar : MonoBehaviour
{
    public GameObject Load_BarObj;
    public Text Load_Text_Bar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseLoadBar()
	{
        switch(Load_Text_Bar.text == "100%")
		{
            case true:
				{
                    Destroy(Load_BarObj);
                    break;
				}
            case false:
				{
                    Debug.Log("進度還未跑完");
                    break;
				}
		}
    }

}
