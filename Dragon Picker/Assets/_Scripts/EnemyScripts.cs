using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{

    public GameObject enemyEgg;

    public float speed = 1f; //скорость дракона
    public float timeBetweenEggDrops = 1f; //врем€ спавна €йца
    public float leftRightDistance = 10f; // границы лева права
    public float chanceDirection = 0.1f; // шанс изменени€ направлени€
    void Start() //вызываем €йцо
    {
        Invoke("DropeEgg", 1f);
    }

    void DropeEgg() //метод спавна €йца
    {
        Vector3 myVector = new Vector3(0.0f, 0.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(enemyEgg);
        egg.transform.position = transform.position + myVector;
        Invoke("DropeEgg", timeBetweenEggDrops);
    }

    void Update()  //проверка на границы, не дает дракону улететь за экран
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

    private void FixedUpdate() //мен€ет направление движени€ дракона
    {
        if (UnityEngine.Random.value < chanceDirection)
        {
            speed *= -1;
        }
    }
}
