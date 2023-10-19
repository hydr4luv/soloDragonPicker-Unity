using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3; // счетчик энерг. щитов
    public float energyShieldBottomY = -6f; // забыл надо посмотреть первые видосы
    public float energyShieldRadius = 1.5f; //забыл надо посмотреть первые видосы

    public List<GameObject> shieldList; //лист список дл€ счетчика жизни


    void Start()
    {
        shieldList = new List<GameObject>();   //объ€вл€ем лист
        for ( int i = 0; i < numEnergyShield; i++) // цикл измени€ если тер€ем жизнь
        {
            GameObject tShield = Instantiate<GameObject>( energyShieldPrefab );
            tShield.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShield.transform.localScale = new Vector3(1 * i+1, 1 * i+1, 1); //тут костыль, у мен€ треть€ сфера была 0 0 1 скеил
            shieldList.Add( tShield );
        }
        
    }
    public void DraggonEggDestroyed() //метод уничтожени€ €йца о нижнюю границу
    {
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("dragonEgg");
        foreach (GameObject tGO in tDragonEggArray) //удаление списка €иц из массива(удал€ет €йцо в воздухе)
        {
            Destroy(tGO);
        }
        int shieldIndex = shieldList.Count - 1; // чета тоже забыл
        GameObject tShield = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex); //сокращаем жизни
        Destroy(tShield); // уничтожаем один из щитов

        if (shieldList.Count == 0) //если жизней не осталось, перезагрузка сцены
        {
            SceneManager.LoadScene("_1Scene");
        }
    }
   
    void Update()
    {
        
    }
}
