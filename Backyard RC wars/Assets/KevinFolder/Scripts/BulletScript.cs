using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float bulletSpeed = 10f;
    public Rigidbody bulletRB;
    public bool Stun = false;

    private Rigidbody targetRB;
    private StapleGunScript SGS;
    private bool ColliderDelay;

    private void Awake()
    {
        ColliderDelay = false;
    }

    private void Update()
    {
      
    }

    private void Start()
    {
        SGS = FindFirstObjectByType<StapleGunScript>();
        bulletRB = GetComponent<Rigidbody>();

        bulletRB.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(FreezeCollider());
        if (collision.gameObject.CompareTag("Player"))
        {
            Health healthScript = collision.collider.GetComponent<Health>();
            healthScript.TakeDamage(damage);
            Destroy(this.gameObject);
            targetRB = collision.gameObject.GetComponent<Rigidbody>();

            if (SGS != null) SGS.Hits += 1;

            if (Stun && targetRB != null)
            {
                StartCoroutine(StunTime());
            }
        }
    }

    IEnumerator StunTime()
    {
        targetRB.isKinematic = true;
        //targetRB.linearVelocity = Vector3.zero;
        Stun = false;
        yield return new WaitForSecondsRealtime(2f);

        targetRB.isKinematic = false;

        Destroy(gameObject);
    }

    IEnumerator FreezeCollider()
    {
        ColliderDelay = true;
        yield return new WaitForSecondsRealtime(0.5f);
        ColliderDelay = false;
    }
}
