using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonEgg : MonoBehaviour
{
    [SerializeField]   public static float bottomY = -10f; // нижн€€ граница €йца
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) //вроде как включаем отображение дл€ €йца
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = true;

        Renderer rend;
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    void Update() 
    {
        if (transform.position.y < bottomY) //проверка на нижнюю границу €йца
        {
            Destroy(this.gameObject); 
            dragonPicker apScript = Camera.main.GetComponent<dragonPicker>();
            apScript.DraggonEggDestroyed(); //ссылка на метод из драгонѕикер
        }
    }
}
