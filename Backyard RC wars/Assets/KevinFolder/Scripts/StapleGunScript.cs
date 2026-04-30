using UnityEngine;
using System.Collections;

public class StapleGunScript : MonoBehaviour
{
    [SerializeField] GameObject Bullet;

    public int HitsNeeded = 3;
    public int Hits;

    BulletScript  bulletScript;

    private Transform shootPointTransform;
    [SerializeField] float shootDelayTime = 0.3f;
    [SerializeField] bool shootDelay;

    private void Start()
    {
        bulletScript = GetComponent<BulletScript>();

        shootPointTransform = transform.Find("ShootPoint");
        shootDelay = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && shootDelay == false)
        {
            Shoot();
            StartCoroutine(ShootCoroutine());
        }
    }

    IEnumerator ShootCoroutine()
    {
        shootDelay = true;
        yield return new WaitForSeconds(shootDelayTime);

        yield return null;

        shootDelay = false;
    }


private void Shoot()
    {
        if(Hits >= HitsNeeded)
        {
            Instantiate(Bullet, shootPointTransform.position, shootPointTransform.rotation);
            bulletScript.Stun = true;
        }
        else
        {
            Instantiate(Bullet, shootPointTransform.position, shootPointTransform.rotation);
        }
       
    }
}

