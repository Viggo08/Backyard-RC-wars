using UnityEngine;

public class Drill : MonoBehaviour
{
    [SerializeField] float DamageTimer = 1f;
    [SerializeField] int DrillDamage;

    //[SerializeField] Health health;
    private Health playerHealth;

    AudioManager audioManager;

    private void Awake()
    {
        //health = FindAnyObjectByType<Health>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerHealth = collision.collider.GetComponent<Health>();

            InvokeRepeating(nameof(DoDamage), 0f, DamageTimer);

            Debug.Log("Started damaging player");
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            CancelInvoke(nameof(DoDamage));
        }
    }

    public void DoDamage()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(DrillDamage);

            audioManager.playSFX(audioManager.Drill);

            Debug.Log("Do damage");
        }
    }
}
