using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int AttackType;
    public int ProjectileNum;
    public float ProjectileDamge;

    // Start is called before the first frame update
    void Start()
    {
        //ProjectileDamge = 2f;   要注意的是這個會優先於其他script所賦予的值，在其他script給予值的話，就不能在此給予值
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void FixedUpdate()
	{
        switch (Time.timeScale == 0f)   //判斷當遊戲暫停時投射物也要暫停
        {
            case true:
                {
                    break;
                }
            case false:
                {
                    ObjType();
                    break;
                }
        }
    }

	public void OnTriggerEnter(Collider Obj)
	{
        if(Obj.tag == "Wall")
		{
            Destroy(gameObject);
        }
	}

    public void ObjType()
	{
        switch(AttackType)
		{
            case 0:  //玩家的投射物
				{
                    ProjectileDamge = 1f;
                    gameObject.transform.position = gameObject.transform.position + new Vector3(0f, 20f, 0);
                    Debug.Log("投射物編號:" + ProjectileNum);
                    break;
				}
            case 1:  //怪物的投射物
                {
                    gameObject.transform.position = gameObject.transform.position + new Vector3(0, -20f, 0);
                    break;
				}
            case 2:  //玩家分裂投射物往右邊一個位置攻擊的
                {
                    ProjectileDamge = 1f;
                    gameObject.transform.position = gameObject.transform.position + new Vector3(12.8f, 20f, 0);
                    break;
				}
            case 3:  //玩家分裂投射物往左邊一個位置攻擊的
                {
                    ProjectileDamge = 1f;
                    gameObject.transform.position = gameObject.transform.position + new Vector3(-12.8f, 20f, 0);
                    break;
				}
            case 4:  //玩家分裂投射物往右邊兩個位置攻擊的
                {
                    ProjectileDamge = 1f;
                    gameObject.transform.position = gameObject.transform.position + new Vector3(25.6f, 20f, 0);
                    break;
                }
            case 5:  //玩家分裂投射物往左邊兩個位置攻擊的
                {
                    ProjectileDamge = 1f;
                    gameObject.transform.position = gameObject.transform.position + new Vector3(-25.6f, 20f, 0);
                    break;
                }
        }
	}
}
