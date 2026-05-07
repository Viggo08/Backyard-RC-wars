using UnityEngine;

public class PotatoBullet : MonoBehaviour
{ 
    float timer = 0;


    [SerializeField] int damage;
    [SerializeField] float explodeTimer;
    [SerializeField] GameObject explosionCollider;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > explodeTimer)
        {
            var instance = Instantiate(explosionCollider, transform.position, transform.rotation);

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Health healthScript = collision.collider.GetComponent<Health>();
            healthScript.TakeDamage(damage);
            Debug.Log("PotatoDamageHit");
        }


        var instance = Instantiate(explosionCollider, transform.position, transform.rotation);
       

        Destroy(this.gameObject);
    }

}
