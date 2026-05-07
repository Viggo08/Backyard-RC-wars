using UnityEngine;

public class PotatoBullet : MonoBehaviour
{
    Health healthScript;
    float timer = 0;


    [SerializeField] int damage;
    [SerializeField] float explodeTimer;
<<<<<<< Updated upstream

    private void Awake()
    {
        healthScript = FindAnyObjectByType<Health>();
        
    }
=======
    [SerializeField] GameObject explosionCollider;
>>>>>>> Stashed changes

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > explodeTimer)
        {
            var instance = Instantiate(explosionCollider, transform.position, transform.rotation);

            Explosion explosion = instance.GetComponent<Explosion>();
            explosion.destroyThisObejct = true;

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            healthScript.TakeDamage(damage);
        }


        var instance = Instantiate(GameObject.FindGameObjectWithTag("ExplosionCollider"), transform.position, transform.rotation);
       

        Destroy(this.gameObject);
    }

}
