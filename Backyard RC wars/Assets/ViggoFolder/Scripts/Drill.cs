using UnityEngine;

public class Drill : MonoBehaviour
{
    [SerializeField] float DamageTimer = 1f;
    [SerializeField] int Damage;

    public int tankHealth;
    int currentHealth;

    Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        currentHealth = tankHealth;
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //How often damage is dealt:
        InvokeRepeating(nameof(DoDamage), 0f, DamageTimer);
    }

    void DoDamage()
    {
        Debug.Log("Do damage");
    }

}
