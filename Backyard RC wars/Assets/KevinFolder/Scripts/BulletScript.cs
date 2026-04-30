using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10;
    public Rigidbody bulletRB;

    public bool Stun = false;

    Rigidbody otherRB;

    StapleGunScript SGS;

    private void Start()
    {
        SGS = FindFirstObjectByType<StapleGunScript>();
        bulletRB = GetComponent<Rigidbody>();
        bulletRB.AddForce(transform.forward * bulletSpeed);
    }

    private void OnTriggerEnter(Collider Other)
    {
        Rigidbody otherRB = Other.gameObject.GetComponent<Rigidbody>();
        if (Other.CompareTag("Player"))
        {
            SGS.Hits += 1;

        }
        if (Stun == true && Other.CompareTag("Player"))
        {
            StartCoroutine(StunTime());
        }
    }

    IEnumerator StunTime()
    {
        otherRB.isKinematic = true;
        yield return new WaitForSecondsRealtime(2f);
        otherRB.isKinematic = false;
    }
}
