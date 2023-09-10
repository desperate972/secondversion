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
        //ProjectileDamge = 2f;   �n�`�N���O�o�ӷ|�u�����Lscript�ҽᤩ���ȡA�b��Lscript�����Ȫ��ܡA�N����b��������
    }

    // Update is called once per frame
    void Update()
    {

    }

	private void FixedUpdate()
	{
        switch (Time.timeScale == 0f)   //�P�_��C���Ȱ��ɧ�g���]�n�Ȱ�
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
            case 0:  //���a����g��
				{
                    ProjectileDamge = 1f;
                    gameObject.transform.position = gameObject.transform.position + new Vector3(0f, 20f, 0);
                    Debug.Log("��g���s��:" + ProjectileNum);
                    break;
				}
            case 1:  //�Ǫ�����g��
                {
                    gameObject.transform.position = gameObject.transform.position + new Vector3(0, -20f, 0);
                    break;
				}
            case 2:  //���a������g�����k��@�Ӧ�m������
                {
                    ProjectileDamge = 1f;
                    gameObject.transform.position = gameObject.transform.position + new Vector3(12.8f, 20f, 0);
                    break;
				}
            case 3:  //���a������g��������@�Ӧ�m������
                {
                    ProjectileDamge = 1f;
                    gameObject.transform.position = gameObject.transform.position + new Vector3(-12.8f, 20f, 0);
                    break;
				}
            case 4:  //���a������g�����k���Ӧ�m������
                {
                    ProjectileDamge = 1f;
                    gameObject.transform.position = gameObject.transform.position + new Vector3(25.6f, 20f, 0);
                    break;
                }
            case 5:  //���a������g���������Ӧ�m������
                {
                    ProjectileDamge = 1f;
                    gameObject.transform.position = gameObject.transform.position + new Vector3(-25.6f, 20f, 0);
                    break;
                }
        }
	}
}
