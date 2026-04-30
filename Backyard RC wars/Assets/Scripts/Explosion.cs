using System;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] int explosionDamage;
    private float timer;
    private Health healthScript;
    public bool destroyThisObejct;

    private void Awake()
    {
        healthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
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
            healthScript.TakeDamage(explosionDamage);
        }
    }
}
