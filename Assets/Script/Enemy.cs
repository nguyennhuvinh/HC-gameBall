using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public GameObject explosionEffectPrefab;

    bool inactive = false;
    // Start is called before the first frame update
    

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PLayer.Instance.transform.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (inactive == false)
        {
            if (other.tag == "Hole")
            {
                PLayer.Instance.AddScore();
                Camera.main.GetComponent<CMShake>().TriggerShake();
                InstantiateExplosionEffect();
                Destroy(gameObject);
               
            }

            if(other.tag == "Player" || other.tag == "Enemy")
            {
                Camera.main.GetComponent<CMShake>().TriggerShake();
                InstantiateExplosionEffect();
                PLayer.Instance.TakeDame();
                speed = 0;
                transform.parent = PLayer.Instance.transform;
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
