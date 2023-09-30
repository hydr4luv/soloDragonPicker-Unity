using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{

    public GameObject enemyEgg;

    public float speed = 1f;
    public float timeBetweenEggDrops = 1f;
    public float leftRightDistance = 10f;
    public float chanceDirection = 0.1f;
    void Start()
    {
        Invoke("DropeEgg", 2f);
    }

    void DropeEgg()
    {
        Vector3 myVector = new Vector3(0.0f, 0.5f, 0.0f);
        GameObject egg = Instantiate<GameObject>(enemyEgg);
        egg.transform.position = transform.position + myVector;
        Invoke("DropeEgg", timeBetweenEggDrops);
    }

    void Update() 
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if(pos.x < -leftRightDistance)
        {
            speed = Math.Abs(speed);
        }
        else if (pos.x > leftRightDistance)
        {
            speed = -Math.Abs(speed);  
        }
    }

    private void FixedUpdate()
    {
        if (UnityEngine.Random.value < chanceDirection)
        {
            speed *= -1;
        }
    }
}
