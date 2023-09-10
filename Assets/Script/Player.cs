using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int PlayerPosition;

    public GameObject Button_Left;
    public GameObject Button_Right;
    public Text PlayerPositionText;
    public Text PlayerHpText;
    public int PlayerAttackRange;
    public int PlayerAttackRangeProject;

    public float PlayerHp;
    public float PlayerHpNow;
    public int PlayerSkillNum;

    public GameObject MonsterGroupObj;
    private float MoveX;

    public GameObject Cover_Attack;
    public GameObject Cover_Attack_Projectile;
    public GameObject Cover_Attack_All;
    public GameObject Cover_Attack_Split;
    public GameObject Cover_Item_Heal;

    public GameObject Road_1;
    public GameObject Road_2;
    public GameObject Road_3;
    public GameObject Road_4;
    public GameObject Road_5;

    public GameObject ProjectileObj;
    public GameObject EmptyObj;
    private GameObject EmptyObj_Projectile;

    public GameObject EmptyObj_Attack_More_1;
    public GameObject EmptyObj_Attack_More_2;

    public GameObject AttackCD_1;
    public Image Sprite_AttackCD_1;
    public Text Text_AttackCD_1;
    public GameObject AttackCD_2;
    public Image Sprite_AttackCD_2;
    public Text Text_AttackCD_2;
    public GameObject AttackCD_3;
    public Image Sprite_AttackCD_3;
    public Text Text_AttackCD_3;
    public GameObject ItemCD_1;
    public Image Sprite_ItemCD_1;
    public Text Text_ItemCD_1;
    public GameObject ItemCD_2;
    public Image Sprite_ItemCD_2;
    public Text Text_ItemCD_2;

    private float AttackCDNum_1;
    private float AttackCDCountNum_1;
    private float AttackCDNum_2;
    private float AttackCDCountNum_2;
    private float AttackCDNum_3;
    private float AttackCDCountNum_3;
    private float ItemCDNum_1;
    private float ItemCDCountNum_1;
    private float ItemCDNum_2;
    private float ItemCDCountNum_2;

    private float ItemNum_1;
    private float ItemNum_2;

    public GameObject Cover_Player;
    public int Cover_PlayerNow;

    public Gamemanager GamemanagerObj;
    public Battle_Calculate CalculateObj;

    private GameObject emptyObj;

    private void Awake()
    {
        MoveX = 0;
        PlayerPosition = 3;
        PlayerPositionText.text = PlayerPosition.ToString();
        SetPlayer();
        PlayerSkillNum = 6;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackClick(int Attack_SkillId)  //���a�D�n�������s
    {
        float PlayerDamge = 0;
        switch(PlayerAttackRange)  //�P�_���a�����d��A�p�G�O1�N�n�P�_���a�Ҧb����m���S���Ǫ��A�p�G�����d��W�L1�A���N��ܴN�⪱�a�Ҧb����m�S���Ǫ����M�i�H�i���������Ǫ�
        {
            case 1:
                {
                    for (int i = 0; i < 6; i++)   //�|���o�q�O���F����p�G�Ǫ��|���ʡA���Ǫ��W�٤��|�H�۩Ǫ�����m(MonsterPosition)�o�ӭȰ��ܤơA�ҥH�����n�ˬd�Ҧ��Ǫ�����m�Ӱ��O�_�|�Q�������P�_
                    {
                        EmptyObj = GameObject.Find("Monster_" + i);
                        switch (EmptyObj == true)
                        {
                            case true:
                                {
                                    Debug.Log("�ثe�Ǫ���:" + "Monster_" + i);
                                    Debug.Log("�Ǫ���m:" + EmptyObj.GetComponent<Monster>().MonsterPosition);
                                    switch (PlayerPosition == EmptyObj.GetComponent<Monster>().MonsterPosition)
                                    {
                                        case true:
                                            {
                                                CalculateObj.CalculatePlayerDamge(Attack_SkillId, out PlayerDamge);
                                                Debug.Log("���\��Ǫ��y�� " + PlayerDamge + " �I�ˮ`");
                                                EmptyObj.GetComponent<Monster>().MonsterHpNow = EmptyObj.GetComponent<Monster>().MonsterHpNow - PlayerDamge;
                                                EmptyObj.GetComponent<Monster>().Reflash();
                                                break;
                                            }
                                        case false:
                                            {
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case false:
                                {
                                    break;
                                }
                        }
                    }
                    break;
                }
            case 3:
                {
                    for (int m = 0; m < 6; m++)    //�]�����a�b����m�i�ण�|���ǡA���]�������d�����Y�i�H������䪺�ǡA�ҥH�o�˰��P�_
                    {
                        EmptyObj = GameObject.Find("Monster_" + m);
                        switch (EmptyObj == true)
                        {
                            case true:
                                {
                                    switch (EmptyObj.GetComponent<Monster>().MonsterPosition == PlayerPosition - 1 || EmptyObj.GetComponent<Monster>().MonsterPosition == PlayerPosition || EmptyObj.GetComponent<Monster>().MonsterPosition == PlayerPosition + 1)
                                    {
                                        case true:
                                            {
                                                CalculateObj.CalculatePlayerDamge(Attack_SkillId, out PlayerDamge);
                                                EmptyObj.GetComponent<Monster>().MonsterHpNow = EmptyObj.GetComponent<Monster>().MonsterHpNow - PlayerDamge;
                                                EmptyObj.GetComponent<Monster>().Reflash();
                                                break;
                                            }
                                        case false:
                                            {
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case false:
                                {
                                    break;
                                }
                        }
                    }
                    break;
                }
            case 5:    //��������Ǫ�
                {
                    for (int m = 0; m < 6; m++)
                    {
                        EmptyObj = GameObject.Find("Monster_" + m);
                        switch (EmptyObj == true)
                        {
                            case true:
                                {
                                    CalculateObj.CalculatePlayerDamge(Attack_SkillId, out PlayerDamge);
                                    EmptyObj.GetComponent<Monster>().MonsterHpNow = EmptyObj.GetComponent<Monster>().MonsterHpNow - PlayerDamge;
                                    EmptyObj.GetComponent<Monster>().Reflash();
                                    break;
                                }
                            case false:
                                {
                                    break;
                                }
                        }
                    }
                    break;
                }
            default:
                {
                    Debug.Log("�����d����~�A�L�k�������");
                    break;
                }
        }
    }

    public void Attack_ProjectileClic(int Attack_SkillId)  //�ϥΧ�g�����s����
    {
        GameObject RoadSpwan = Road_3;
        switch (PlayerPosition)
        {
            case 1:
                {
                    RoadSpwan = Road_1;
                    break;
                }
            case 2:
                {
                    RoadSpwan = Road_2;
                    break;
                }
            case 3:
                {
                    RoadSpwan = Road_3;
                    break;
                }
            case 4:
                {
                    RoadSpwan = Road_4;
                    break;
                }
            case 5:
                {
                    RoadSpwan = Road_5;
                    break;
                }
        }

        switch(PlayerAttackRangeProject)
        {
            case 1:
                {
                    EmptyObj_Projectile = Instantiate(ProjectileObj, RoadSpwan.transform);
                    EmptyObj_Projectile.GetComponent<Projectile>().AttackType = 0;
                    EmptyObj_Projectile.transform.localPosition = new Vector3(0, 250, 0);
                    EmptyObj_Projectile.GetComponent<Projectile>().ProjectileNum = PlayerSkillNum;
                    break;
                }
            case 3:
                {
                    for(int p = 0; p < 4; p++)
                    {
                        switch(p)
                        {
                            case 0:
                                {
                                    EmptyObj_Projectile = Instantiate(ProjectileObj, RoadSpwan.transform);
                                    EmptyObj_Projectile.GetComponent<Projectile>().AttackType = 0;
                                    EmptyObj_Projectile.transform.localPosition = new Vector3(0, 250, 0);
                                    EmptyObj_Projectile.GetComponent<Projectile>().ProjectileNum = PlayerSkillNum;
                                    break;
                                }
                            case 1:
                                {
                                    EmptyObj_Projectile = Instantiate(ProjectileObj, RoadSpwan.transform);
                                    EmptyObj_Projectile.GetComponent<Projectile>().AttackType = 2;
                                    EmptyObj_Projectile.transform.localPosition = new Vector3(0, 250, 0);
                                    EmptyObj_Projectile.GetComponent<Projectile>().ProjectileNum = PlayerSkillNum;
                                    break;
                                }
                            case 2:
                                {
                                    EmptyObj_Projectile = Instantiate(ProjectileObj, RoadSpwan.transform);
                                    EmptyObj_Projectile.GetComponent<Projectile>().AttackType = 3;
                                    EmptyObj_Projectile.transform.localPosition = new Vector3(0, 250, 0);
                                    EmptyObj_Projectile.GetComponent<Projectile>().ProjectileNum = PlayerSkillNum;
                                    break;
                                }
                        }
                    }
                    break;
                }
            case 5:
                {
                    for (int p = 0; p < 6; p++)
                    {
                        switch (p)
                        {
                            case 0:
                                {
                                    EmptyObj_Projectile = Instantiate(ProjectileObj, RoadSpwan.transform);
                                    EmptyObj_Projectile.GetComponent<Projectile>().AttackType = 0;
                                    EmptyObj_Projectile.transform.localPosition = new Vector3(0, 250, 0);
                                    EmptyObj_Projectile.GetComponent<Projectile>().ProjectileNum = PlayerSkillNum;
                                    break;
                                }
                            case 1:
                                {
                                    EmptyObj_Projectile = Instantiate(ProjectileObj, RoadSpwan.transform);
                                    EmptyObj_Projectile.GetComponent<Projectile>().AttackType = 2;
                                    EmptyObj_Projectile.transform.localPosition = new Vector3(0, 250, 0);
                                    EmptyObj_Projectile.GetComponent<Projectile>().ProjectileNum = PlayerSkillNum;
                                    break;
                                }
                            case 2:
                                {
                                    EmptyObj_Projectile = Instantiate(ProjectileObj, RoadSpwan.transform);
                                    EmptyObj_Projectile.GetComponent<Projectile>().AttackType = 3;
                                    EmptyObj_Projectile.transform.localPosition = new Vector3(0, 250, 0);
                                    EmptyObj_Projectile.GetComponent<Projectile>().ProjectileNum = PlayerSkillNum;
                                    break;
                                }
                            case 3:
                                {
                                    EmptyObj_Projectile = Instantiate(ProjectileObj, RoadSpwan.transform);
                                    EmptyObj_Projectile.GetComponent<Projectile>().AttackType = 4;
                                    EmptyObj_Projectile.transform.localPosition = new Vector3(0, 250, 0);
                                    EmptyObj_Projectile.GetComponent<Projectile>().ProjectileNum = PlayerSkillNum;
                                    break;
                                }
                            case 4:
                                {
                                    EmptyObj_Projectile = Instantiate(ProjectileObj, RoadSpwan.transform);
                                    EmptyObj_Projectile.GetComponent<Projectile>().AttackType = 5;
                                    EmptyObj_Projectile.transform.localPosition = new Vector3(0, 250, 0);
                                    EmptyObj_Projectile.GetComponent<Projectile>().ProjectileNum = PlayerSkillNum;
                                    break;
                                }
                        }
                    }
                    break;
                }
        }

        
    }

    public void ShowPlayerPosition()   //��ܪ��a��m�Ʀr
    {
        PlayerPositionText.text = PlayerPosition.ToString();
        Debug.Log("�ثe����Ҧb��m:" + PlayerPosition);
    }

    public void Button_LeftClick()  //���a�V�����ʮɡA���a��m�Ʀr��֡A�Ǫ��|�������a�쥻��m�ҥH�W�[
    {
        switch(PlayerPosition == 1)
        {
            case true:
                {
                    ShowPlayerPosition();
                    break;
                }
            case false:
                {
                    KnowPlayerPositionNowGoLeft();
                    StartCoroutine(MonsterGroupMove());
                    Debug.Log("��Ĳ�o���?");
                    PlayerPosition--;
                    ShowPlayerPosition();
                    break;
                }
        }
    }

    public void Button_RightClick()  //���a�V�k���ʮɡA���a��m�Ʀr�W�[�A�Ǫ��|�������a�쥻��m�ҥH���
    {
        switch (PlayerPosition == 5)
        {
            case true:
                {
                    ShowPlayerPosition();
                    break;
                }
            case false:
                {
                    KnowPlayerPositionNowGoRight();
                    StartCoroutine(MonsterGroupMove());
                    PlayerPosition++;
                    ShowPlayerPosition();
                    break;
                }
        }
    }

    public void KnowPlayerPositionNowGoLeft()
    {
        switch(PlayerPosition)
        {
            case 1:
                {
                    Debug.Log("�z�פW��������ܳo��Left");
                    break;
                }
            case 2:
                {
                    MoveX = 640;
                    break;
                }
            case 3:
                {
                    MoveX = 320;
                    break;
                }
            case 4:
                {
                    MoveX = 0;
                    break;
                }
            case 5:
                {
                    MoveX = -320;
                    break;
                }

        }
    }

    public void KnowPlayerPositionNowGoRight()
    {
        switch (PlayerPosition)
        {
            case 1:
                {
                    MoveX = 320;
                    break;
                }
            case 2:
                {
                    MoveX = 0;
                    break;
                }
            case 3:
                {
                    MoveX = -320;
                    break;
                }
            case 4:
                {
                    MoveX = -640;
                    break;
                }
            case 5:
                {
                    Debug.Log("�z�פW��������ܳo��Right");
                    break;
                }

        }
    }

    IEnumerator MonsterGroupMove()     //���a���ʪ�function�A���]���ù���ܪ�����A�e���W�ݰ_�ӬO���a�b���ʡA��ڤW�O�Ǫ�������b����
    {
        Debug.Log("�O�_��Ĳ�o?");
        while(MonsterGroupObj.transform.localPosition.x != MoveX)
        {
            Cover_Attack.SetActive(true);
            Cover_Attack_Projectile.SetActive(true);
            Cover_Attack_All.SetActive(true);
            Cover_Attack_Split.SetActive(true);
            Cover_Item_Heal.SetActive(true);
            MonsterGroupObj.transform.localPosition = Vector3.MoveTowards(MonsterGroupObj.transform.localPosition, new Vector3(MoveX, 0, 0), 10f);
            yield return null;
        }
        Cover_Attack.SetActive(false);
        Cover_Attack_Projectile.SetActive(false);
        Cover_Attack_All.SetActive(false);
        Cover_Attack_Split.SetActive(false);
        Cover_Item_Heal.SetActive(false);
    }

    public void SetPlayer()  //²��]�m���a�ƭ�
    {
        PlayerHp = Json_Battle_Static.Hp;
        PlayerHpNow = Json_Battle_Static.HpNow;
        PlayerHpText.text = Json_Battle_Static.HpNow + "/" + Json_Battle_Static.Hp;
        PlayerAttackRange = 1;  //���a�����d��
        PlayerAttackRangeProject = 5;  //���a��g���������d��A����|�R���A����|����ڧޯ൹���ƭ�
        AttackCDNum_1 = Json_Battle_Player_Static.AttackCD_1;
        AttackCDNum_2 = Json_Battle_Player_Static.AttackCD_2;
        AttackCDNum_3 = Json_Battle_Player_Static.AttackCD_3;
        ItemCDNum_1 = Json_Battle_Player_Static.PotionCD_1;
        ItemCDNum_2 = Json_Battle_Player_Static.PotionCD_2;
    }

    public void Reflash()    //��s���a�ƭ�
    {
        switch(Json_Battle_Static.HpNow <= 0)
        {
            case true:
                {
                    emptyObj = GameObject.Find("BackGround");
                    emptyObj.GetComponent<Battle_Second>().WavePauseNum = 3;
                    emptyObj.GetComponent<Battle_Second>().WavePause();
                    break;
                }
            case false:
                {
                    PlayerHpText.text = Json_Battle_Static.HpNow + "/" + Json_Battle_Static.Hp;
                    break;
                }
        }
    }

    public void OnTriggerEnter(Collider Obj)   //collider�I���P�w
    {
        Debug.Log("����Ǫ��F!");
        float takedamge = Obj.GetComponent<Projectile>().ProjectileDamge;
        switch(Obj.GetComponent<Projectile>().AttackType)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    switch(Cover_PlayerNow == 1)
                    {
                        case true:
                            {
                                break;
                            }
                        case false:
                            {
                                Json_Battle_Static.HpNow = Json_Battle_Static.HpNow - takedamge;
                                break;
                            }
                    }
                    Reflash();
                    Destroy(Obj.gameObject);
                    break;
                }
        }       
    }

    public void Button_Attack_1()   //�Ĥ@�ӧ������s(�D�n����)
    {
        //�o�̻ݭn�h�쪱�a�]�w���D�n�����ޯ�s���ӧP�_�O�ƻ�����覡
        Debug.Log("��Ĳ�o�������?");
        bool AttackOrProject;
        judgeAttackOrProject(Json_Battle_Player_Static.Attack_SkillId_1, out AttackOrProject);
        switch(AttackOrProject)
        {
            case true:
                {
                    Attack_ProjectileClic(Json_Battle_Player_Static.Attack_SkillId_1);
                    break;
                }
            case false:
                {
                    AttackClick(Json_Battle_Player_Static.Attack_SkillId_1);
                    break;
                }
        }
        AttackCDCountNum_1 = AttackCDNum_1;
        InvokeRepeating("AttackCDType_1", 0, 0.1f);
    }
    public void Button_Attack_2()   //�ĤG�ӧ������s
    {
        //�o�̻ݭn�h�쪱�a�]�w���D�n�����ޯ�s���ӧP�_�O�ƻ�����覡
        bool AttackOrProject;
        judgeAttackOrProject(Json_Battle_Player_Static.Attack_SkillId_2, out AttackOrProject);
        switch (AttackOrProject)
        {
            case true:
                {
                    Attack_ProjectileClic(Json_Battle_Player_Static.Attack_SkillId_2);
                    break;
                }
            case false:
                {
                    AttackClick(Json_Battle_Player_Static.Attack_SkillId_2);
                    break;
                }
        }
        AttackCDCountNum_2 = AttackCDNum_2;
        InvokeRepeating("AttackCDType_2", 0, 0.1f);
    }
    public void Button_Attack_3()   //�ĤT�ӧ������s
    {
        //�o�̻ݭn�h�쪱�a�]�w���D�n�����ޯ�s���ӧP�_�O�ƻ�����覡
        bool AttackOrProject;
        judgeAttackOrProject(Json_Battle_Player_Static.Attack_SkillId_3, out AttackOrProject);
        switch (AttackOrProject)
        {
            case true:
                {
                    Attack_ProjectileClic(Json_Battle_Player_Static.Attack_SkillId_3);
                    break;
                }
            case false:
                {
                    AttackClick(Json_Battle_Player_Static.Attack_SkillId_3);
                    break;
                }
        }
        AttackCDCountNum_3 = AttackCDNum_3;
        InvokeRepeating("AttackCDType_3", 0, 0.1f);
    }
    public void Button_Item_1()     //�Ĥ@�ӹD����s
    {
        //�o�̻ݭn�h�쪱�a�]�w���D��s���ӧP�_�O�ƻ�D��A�ثe�����@�Ӱ����e�������s���\��
        ItemNum_1 = 5f;
        Json_Battle_Static.HpNow = Json_Battle_Static.HpNow + ItemNum_1;
        switch (Json_Battle_Static.HpNow > Json_Battle_Static.Hp)
        {
            case true:
                {
                    Json_Battle_Static.HpNow = Json_Battle_Static.Hp;
                    Reflash();
                    break;
                }
            case false:
                {
                    Reflash();
                    break;
                }
        }
        ItemCDCountNum_1 = ItemCDNum_1;
        InvokeRepeating("ItemCDType_1", 0, 0.1f);
    }
    public void Button_Item_2()     //�ĤG�ӹD����s
    {
        //�o�̻ݭn�h�쪱�a�]�w���D��s���ӧP�_�O�ƻ�D��
        ItemNum_2 = 5f;
        Json_Battle_Static.HpNow = Json_Battle_Static.HpNow + ItemNum_2;
        switch (Json_Battle_Static.HpNow > Json_Battle_Static.Hp)
        {
            case true:
                {
                    Json_Battle_Static.HpNow = Json_Battle_Static.Hp;
                    Reflash();
                    break;
                }
            case false:
                {
                    Reflash();
                    break;
                }
        }
        ItemCDCountNum_2 = ItemCDNum_2;
        InvokeRepeating("ItemCDType_2", 0, 0.1f);
    }
    public void AttackCDType_1()   //�Ĥ@�ӧ������s�˼���ܪ�function
    {
        AttackCDCount(AttackCD_1, ref AttackCDCountNum_1, Text_AttackCD_1, AttackCDNum_1, Sprite_AttackCD_1, "AttackCDType_1");
    }
    public void AttackCDType_2()   //�ĤG�ӧ������s�˼���ܪ�function
    {
        AttackCDCount(AttackCD_2, ref AttackCDCountNum_2, Text_AttackCD_2, AttackCDNum_2, Sprite_AttackCD_2, "AttackCDType_2");
    }
    public void AttackCDType_3()   //�ĤT�ӧ������s�˼���ܪ�function
    {
        AttackCDCount(AttackCD_3, ref AttackCDCountNum_3, Text_AttackCD_3, AttackCDNum_3, Sprite_AttackCD_3, "AttackCDType_3");
    }
    public void ItemCDType_1()   //�Ĥ@�ӹD����s�˼���ܪ�function
    {
        AttackCDCount(ItemCD_1, ref ItemCDCountNum_1, Text_ItemCD_1, ItemCDNum_1, Sprite_ItemCD_1, "ItemCDType_1");
    }
    public void ItemCDType_2()   //�Ĥ@�ӹD����s�˼���ܪ�function
    {
        AttackCDCount(ItemCD_2, ref ItemCDCountNum_2, Text_ItemCD_2, ItemCDNum_2, Sprite_ItemCD_2, "ItemCDType_2");
    }
    public void AttackCDCount_1()    //�����Ѧҧ@�k�d�ۡA�Ĥ@�ӧ������s(�D�n����)�A�b�I����i�J������CD�ɶ�
    {
        AttackCD_1.SetActive(true);
        switch (AttackCDCountNum_1 == 0f)
        {
            case true:
                {
                    AttackCD_1.SetActive(false);
                    CancelInvoke();
                    break;
                }
            case false:
                {
                    Text_AttackCD_1.text = AttackCDCountNum_1.ToString();
                    Sprite_AttackCD_1.fillAmount = AttackCDCountNum_1 / AttackCDNum_1;
                    break;
                }
        }
        AttackCDCountNum_1 = float.Parse((AttackCDCountNum_1 - 0.1f).ToString("0.0"));   //�i�H�Nfloat�u��ܤp���I��@�쪺��k�A�p���I�᭱�X��0�A�N�����ܨ�p���I��X��
    }
    public void AttackCDCount(GameObject AttaclName, ref float AttackCDCount, Text AttackCDText, float AttackCD, Image AttackSprite, string CancelName)    //�Ĥ@�ӧ������s(�D�n����)�A�b�I����i�J������CD�ɶ�
    {
        AttaclName.SetActive(true);
        switch (AttackCDCount == 0f)
        {
            case true:
                {
                    AttaclName.SetActive(false);
                    CancelInvoke(CancelName);
                    break;
                }
            case false:
                {
                    AttackCDText.text = AttackCDCount.ToString();
                    AttackSprite.fillAmount = AttackCDCount / AttackCD;
                    break;
                }
        }
        AttackCDCount = float.Parse((AttackCDCount - 0.1f).ToString("0.0"));   //�i�H�Nfloat�u��ܤp���I��@�쪺��k�A�p���I�᭱�X��0�A�N�����ܨ�p���I��X��
    }

    public void Button_LeftClickFast()    //�ֳt�V�����ʡA�i�J�L�Ī��A�A�i�H�K�̥���ˮ`
    {
        switch (PlayerPosition == 1)
        {
            case true:
                {
                    ShowPlayerPosition();
                    break;
                }
            case false:
                {
                    KnowPlayerPositionNowGoLeft();
                    StartCoroutine(MonsterGroupMoveFast());
                    PlayerPosition--;
                    ShowPlayerPosition();
                    break;
                }
        }
    }

    public void Button_RightClickFast()    //�ֳt�V�k���ʡA�i�J�L�Ī��A�A�i�H�K�̥���ˮ`
    {
        switch (PlayerPosition == 5)
        {
            case true:
                {
                    ShowPlayerPosition();
                    break;
                }
            case false:
                {
                    KnowPlayerPositionNowGoRight();
                    StartCoroutine(MonsterGroupMoveFast());
                    PlayerPosition++;
                    ShowPlayerPosition();
                    break;
                }
        }
    }

    IEnumerator MonsterGroupMoveFast()   //�L�Ī��A�����ʥ\��
    {
        Debug.Log("�O�_��Ĳ�o?");
        while (MonsterGroupObj.transform.localPosition.x != MoveX)
        {
            Cover_PlayerNow = 1;
            Cover_Player.SetActive(true);
            Cover_Attack.SetActive(true);
            Cover_Attack_Projectile.SetActive(true);
            Cover_Attack_All.SetActive(true);
            Cover_Attack_Split.SetActive(true);
            Cover_Item_Heal.SetActive(true);
            MonsterGroupObj.transform.localPosition = Vector3.MoveTowards(MonsterGroupObj.transform.localPosition, new Vector3(MoveX, 0, 0), 5f);
            yield return null;
        }
        Cover_Attack.SetActive(false);
        Cover_Attack_Projectile.SetActive(false);
        Cover_Attack_All.SetActive(false);
        Cover_Attack_Split.SetActive(false);
        Cover_Item_Heal.SetActive(false);
        Cover_Player.SetActive(false);
        Cover_PlayerNow = 0;
    }

    public void ClearPlayerSkillCD()   //���m���a�ޯ઺�\��
    {
        AttackCDCountNum_1 = 0f;
        AttackCDCountNum_2 = 0f;
        AttackCDCountNum_3 = 0f;
        ItemCDCountNum_1 = 0f;
        ItemCDCountNum_2 = 0f;
    }

    public void judgeAttackOrProject(int SkillId, out bool Or)  //�P�_�o�������O���O��g��
    {
        Or = false;
        int TagNum = 0;
        int[] SkillTag;
        GamemanagerObj.LoadSkill();
        foreach (Json_Skill date in Gamemanager.Json_SkillFile.JsonSkill)
        {
            if(date.Id == SkillId)
            {
                SkillTag = date.SkillTag;
                TagNum = date.SkillTag.Length;
                for (int i = 0; i <= TagNum - 1 ; i++)
                {
                    if (SkillTag[i] == 3)
                    {
                        Debug.Log("�ӧޯ�]�t��g��Tag!");
                        Or = true;
                    }
                }
            }
        }
    }
}
