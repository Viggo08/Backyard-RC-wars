using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class StapleGunScript : MonoBehaviour
{
    [SerializeField] GameObject Bullet;

    public int HitsNeeded = 3;
    public int Hits;

    BulletScript  bulletScript;
    PlayerInput playerInput;

    private Transform shootPointTransform;
    [SerializeField] float shootDelayTime = 0.3f;
    [SerializeField] bool shootDelay;

    private void Start()
    {
        playerInput = GetComponentInParent<PlayerInput>();

        shootPointTransform = transform.Find("ShootPoint");
        shootDelay = false;
    }

    private void Update()
    {
        if (playerInput.actions["Attack2"].IsPressed() && shootDelay == false)
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
            Instantiate(Bullet, shootPointTransform.position, shootPointTransform.rotation, this.transform);
            bulletScript = GetComponent<BulletScript>();
            bulletScript.Stun = true;
        }
        else
        {
            Instantiate(Bullet, shootPointTransform.position, shootPointTransform.rotation, this.transform);
            bulletScript = GetComponent<BulletScript>();
        }
       
    }
}

