using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Json_Player_Armor        //�o�O���a��o���˳Ƥ��e
{
    public int Id;                    //�b���a�˳ƦC�����ܪ���o������
    public int ArmorEquip;            //�O�_���Q�˳Ʀb���a���W
    public int ArmorBasicId;          //��O�o�Ӹ˳ƪ��򥻯�O�O�̷ӭ���˳ƽs��
    public int ArmorLv;               //�˳Ƶ���=�i�˳ƪ��ݨD����
    public int ArmorType;             //�˳������A0 = �D��Z��, 1 = �Ƥ�Z��, 2 = �Y��, 3 = ����, 4 = �Ǥl, 5 = �c�l, 6 = ��M, 7 = �٫�, 8 = ���N, 9 = ����
    public int ArmorBasicPowerType;   //�˳ư�¦��O�����A0 = HP�A1 = MP�A2 = ���z�����O�A3 = �]�k�����O�A4 = �O�q�A5 = ���z�A6 = �ӱ�
    public float ArmorBasicPowerMin;  //�˳ư�¦��O�̤p�ƭ�
    public float ArmorBasicPowerMax;  //�˳ư�¦��O�̤j�ƭ�
    public int ArmorRank;             //�˳ƫ~���A�M�w�˳Ƶ��󦳴X���A0 = 0�����Y�A1 = 2�����Y�A2 = 4�����Y�A3 = 6�����Y
    public int ArmorIconId;           //�˳ƹϽs��
    public int ArmorPowerType_1;      //�Ӹ˳ƲĤ@�����Y������
    public int ArmorPowerMin_1;       //�Ӹ˳ƲĤ@�����Y���̤p��
    public int ArmorPowerMax_1;       //�Ӹ˳ƲĤ@�����Y���̤p��
    public int ArmorPowerType_2;      //�Ӹ˳ƲĤG�����Y������
    public int ArmorPowerMin_2;       //�Ӹ˳ƲĤG�����Y���̤p��
    public int ArmorPowerMax_2;       //�Ӹ˳ƲĤG�����Y���̤p��
    public int ArmorPowerType_3;      //�Ӹ˳ƲĤT�����Y������
    public int ArmorPowerMin_3;       //�Ӹ˳ƲĤT�����Y���̤p��
    public int ArmorPowerMax_3;       //�Ӹ˳ƲĤT�����Y���̤p��
    public int ArmorPowerType_4;      //�Ӹ˳Ʋĥ|�����Y������
    public int ArmorPowerMin_4;       //�Ӹ˳Ʋĥ|�����Y���̤p��
    public int ArmorPowerMax_4;       //�Ӹ˳Ʋĥ|�����Y���̤p��
    public int ArmorPowerType_5;      //�Ӹ˳ƲĤ������Y������
    public int ArmorPowerMin_5;       //�Ӹ˳ƲĤ������Y���̤p��
    public int ArmorPowerMax_5;       //�Ӹ˳ƲĤ������Y���̤p��
    public int ArmorPowerType_6;      //�Ӹ˳ƲĤ������Y������
    public int ArmorPowerMin_6;       //�Ӹ˳ƲĤ������Y���̤p��
    public int ArmorPowerMax_6;       //�Ӹ˳ƲĤ������Y���̤p��
}
