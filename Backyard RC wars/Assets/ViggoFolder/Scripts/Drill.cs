using UnityEngine;

public class Drill : MonoBehaviour
{
    [SerializeField] float DamageTimer = 1f;
    [SerializeField] int DrillDamage;

    [SerializeField] Health health;

    private void Awake()
    {
        health = FindAnyObjectByType<Health>();
    }

    public void DoDamage()
    {
        health.TakeDamage(DrillDamage);
        Debug.Log("Do damage");
    }

    private void OnCollisionEnter(Collision collision)
    {
        //How often damage is dealt:
        InvokeRepeating(nameof(DoDamage), 0f, DamageTimer);
        Debug.Log(health.currentHealth);
    }

}
