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
    [SerializeField] Transform playerRotation;
    [SerializeField] float howLongShouldWait;

    private void Awake()
    { 
        playerInput = GetComponentInParent<PlayerInput>();
        timeBetweenShots = 0f;
    }

    private void Update()
    {
        if(potatoFired == true)
        {
            timeBetweenShots += Time.deltaTime;
        }

        if(timeBetweenShots >= howLongShouldWait)
        {
            potatoFired = false;
        }
    }


    void OnAttack()
    {
        if (playerInput.actions["Attack"].IsPressed() && potatoFired == false)
        {
            var instace = Instantiate(bulletPrefab, originPos.transform.position, playerRotation.rotation);
            instace.GetComponent<Rigidbody>().AddForce(Vector3.forward * potatoRange, ForceMode.Impulse);
            potatoFired = true;
        }
    }

}
