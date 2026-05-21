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
    GameObject bullet;


    private void Awake()
    {
        playerInput = GetComponentInParent<PlayerInput>();
    }

    private void Start()
    {


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
            bullet = Instantiate(Bullet, shootPointTransform.position, shootPointTransform.rotation, this.transform);
            bulletScript = bullet.GetComponent<BulletScript>();
            bulletScript.Stun = true;
            Hits = 0;
        }
        else
        {
            bullet = Instantiate(Bullet, shootPointTransform.position, shootPointTransform.rotation, this.transform);
            bulletScript = bullet.GetComponent<BulletScript>();
        }
       
    }
}

