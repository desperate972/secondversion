using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Json_Armor                     //�o�O�˳ƪ��򥻯�O���e�A0 = �D��Z��, 1 = �Ƥ�Z��, 2 = �Y��, 3 = ����, 4 = �Ǥl, 5 = �c�l, 6 = ��M, 7 = �٫�, 8 = ���N, 9 = ����
{
    public int ArmorId;                     //�˳ƪ��s��
    public string ArmorName;                //�˳ƦW��
    public int ArmorType;                   //�˳������A0 = �D��Z��, 1 = �Ƥ�Z��, 2 = �Y��, 3 = ����, 4 = �Ǥl, 5 = �c�l, 6 = ��M, 7 = �٫�, 8 = ���N, 9 = ����
    public int ArmorLv;                     //�˳Ƶ���=�i�˳ƪ��ݨD����
    public int ArmorBasicPowerType;         //�˳ư�¦��O�����A0 = HP�A1 = MP�A2 = ���z�����O�A3 = �]�k�����O�A4 = �O�q�A5 = ���z�A6 = �ӱ�
    public float ArmorBasicPowerMin;        //�˳ư�¦��O�̤p�ƭ�
    public float ArmorBasicPowerMax;        //�˳ư�¦��O�̤j�ƭ�
    public float ArmorBasicPowerMinRage_1;  //�˳ư�¦��O�̤p�ƭȪ��̤p�ƭȽd��
    public float ArmorBasicPowerMinRage_2;  //�˳ư�¦��O�̤p�ƭȪ��̤j�ƭȽd��
    public float ArmorBasicPowerMaxRage_1;  //�˳ư�¦��O�̤j�ƭȪ��̤p�ƭȽd��
    public float ArmorBasicPowerMaxRage_2;  //�˳ư�¦��O�̤j�ƭȪ��̤j�ƭȽd��
    public int ArmorRank;                   //�˳ƫ~���A�M�w�˳Ƶ��󦳴X���A0 = 0�����Y�A1 = 2�����Y�A2 = 4�����Y�A3 = 6�����Y
    public int ArmorIconId;                 //�˳ƹϽs��
}
