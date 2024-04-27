using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenomBall : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] float timeLife;

    [SerializeField] float damage;
    void Start()
    {
        Destroy(gameObject, timeLife);
    }

    
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == 8)
        {
            
        }
        Destroy(gameObject);
    }
}
