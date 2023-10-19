using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3; // ������� �����. �����
    public float energyShieldBottomY = -6f; // ����� ���� ���������� ������ ������
    public float energyShieldRadius = 1.5f; //����� ���� ���������� ������ ������

    public List<GameObject> shieldList; //���� ������ ��� �������� �����


    void Start()
    {
        shieldList = new List<GameObject>();   //��������� ����
        for ( int i = 0; i < numEnergyShield; i++) // ���� ������� ���� ������ �����
        {
            GameObject tShield = Instantiate<GameObject>( energyShieldPrefab );
            tShield.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShield.transform.localScale = new Vector3(1 * i+1, 1 * i+1, 1); //��� �������, � ���� ������ ����� ���� 0 0 1 �����
            shieldList.Add( tShield );
        }
        
    }
    public void DraggonEggDestroyed() //����� ����������� ���� � ������ �������
    {
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("dragonEgg");
        foreach (GameObject tGO in tDragonEggArray) //�������� ������ ��� �� �������(������� ���� � �������)
        {
            Destroy(tGO);
        }
        int shieldIndex = shieldList.Count - 1; // ���� ���� �����
        GameObject tShield = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex); //��������� �����
        Destroy(tShield); // ���������� ���� �� �����

        if (shieldList.Count == 0) //���� ������ �� ��������, ������������ �����
        {
            SceneManager.LoadScene("_1Scene");
        }
    }
   
    void Update()
    {
        
    }
}
