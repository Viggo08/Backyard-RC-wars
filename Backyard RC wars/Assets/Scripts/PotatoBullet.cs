using UnityEngine;

public class PotatoBullet : MonoBehaviour
{ 
    float timer = 0;


    [SerializeField] int damage;
    [SerializeField] float explodeTimer;


    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > explodeTimer)
        {
            var instance = Instantiate(GameObject.FindGameObjectWithTag("ExplosionCollider"), transform.position, transform.rotation);

            Explosion explosion = instance.GetComponent<Explosion>();
            explosion.destroyThisObejct = true;

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Health healthScript = collision.collider.GetComponent<Health>();
            healthScript.TakeDamage(damage);
        }


        var instance = Instantiate(GameObject.FindGameObjectWithTag("ExplosionCollider"), transform.position, transform.rotation);
       

        Destroy(this.gameObject);
    }

}
