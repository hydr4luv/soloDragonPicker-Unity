using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonEgg : MonoBehaviour
{
    [SerializeField]   public static float bottomY = -10f;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
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
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);   
        }
    }
}
