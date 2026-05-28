using UnityEngine;

public class Drill : MonoBehaviour
{
    [SerializeField] private float damageTimer = 1f;
    [SerializeField] private int drillDamage = 10;

    private float timer;

    private AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            timer += Time.deltaTime;

            if (timer >= damageTimer)
            {
                Health health = collision.collider.GetComponent<Health>();

                if (health != null)
                {
                    health.TakeDamage(drillDamage);
                    audioManager.playSFX(audioManager.Drill);
                }

                timer = 0f;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            timer = 0f;
        }
    }
}