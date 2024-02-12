using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    PLayer player;

    public GameObject explosionEffectPrefab;

    bool inactive = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PLayer>();
        
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (inactive == false)
        {
            if (other.tag == "Hole")
            {
                player.AddScore();
                Camera.main.GetComponent<CMShake>().TriggerShake();
                InstantiateExplosionEffect();
                Destroy(gameObject);
               
            }

            if(other.tag == "Player" || other.tag == "Enemy")
            {
                Camera.main.GetComponent<CMShake>().TriggerShake();
                InstantiateExplosionEffect();
                player.TakeDame();
                speed = 0;
                transform.parent = player.transform;
            }
            inactive = true;
        }
        
    }

    void InstantiateExplosionEffect()
    {
        if (explosionEffectPrefab != null)
        {
           
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
