using UnityEngine;

public class VenomBall : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float timeLife;
    [SerializeField] private int damage;

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
        Player player = collision.gameObject.GetComponent<Player>();
        if(player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
