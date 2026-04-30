using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PotatoCanon : MonoBehaviour
{
    PlayerInput playerInput;
    bool potatoFired = false;
    float timeBetweenShots;

    [SerializeField] float potatoRange;
    [SerializeField] int potatoDamage;
    [SerializeField] GameObject originPos;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float howLongShouldWait;

    private void Awake()
    { 
        playerInput = GetComponentInParent<PlayerInput>();
        timeBetweenShots = 0f;
    }

    private void Update()
    {
        OnAttack();
        Debug.Log(potatoFired);
        Debug.Log(timeBetweenShots);

        if(potatoFired == true)
        {
            timeBetweenShots += Time.deltaTime;
        }

        if(timeBetweenShots >= howLongShouldWait)
        {
            potatoFired = false;
            timeBetweenShots = 0f;
        }
    }


    void OnAttack()
    {
        if (playerInput.actions["Attack"].IsPressed() && potatoFired == false)
        {
            var instance = Instantiate(bulletPrefab, originPos.transform.position, originPos.transform.rotation);
            instance.GetComponent<Rigidbody>().linearVelocity = originPos.transform.forward * potatoRange;
         

            potatoFired = true;
        }
    }

}
