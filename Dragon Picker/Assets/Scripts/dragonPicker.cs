using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6f;
    public float energyShieldRadius = 1.5f;

    void Start()
    {
        for ( int i = 0; i < numEnergyShield; i++ )
        {
            GameObject tShield = Instantiate<GameObject>( energyShieldPrefab );
            tShield.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShield.transform.localScale = new Vector3(1 * i, 1 * i, 1);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
