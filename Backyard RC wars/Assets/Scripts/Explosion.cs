using System;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] int explosionDamage;
    private float timer;
    public bool destroyThisObejct;
    public ParticleSystem explosionParticle;
  

    private void Start()
    {
       Instantiate(explosionParticle, transform.position, Quaternion.Euler(-90,0,0));
     
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 2f && destroyThisObejct == true)
        {  
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Health healthScript = other.GetComponent<Health>();

            healthScript.TakeDamage(explosionDamage);
        }
    }
}
