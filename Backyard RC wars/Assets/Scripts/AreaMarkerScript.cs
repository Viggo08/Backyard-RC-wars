using System.Collections;
using UnityEngine;

public class AreaMarkerScript : MonoBehaviour
{
    [SerializeField] public float growthSpeed;
    //decides max range
    [SerializeField] float survivalTime;
    [SerializeField] float Dmg;
    Vector3 dir;

    Rigidbody rb;
    WatterBallon WB;

    private void Awake()
    {
       StartCoroutine(WaitForDeath());
        growthSpeed = 1.022f;
    }

    private void FixedUpdate()
    {
        transform.localScale = transform.localScale * growthSpeed;
        transform.localScale = new Vector3(transform.localScale.x, 0.01f, transform.localScale.z);
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSecondsRealtime(survivalTime);
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        growthSpeed = 1f;
        //yield return new WaitForSecondsRealtime(2);
        //Destroy(gameObject);
        //WB = GetComponent<WatterBallon>();
        //WB.areaMarkerInstance = null;
    }

    private void OnDestroy()
    {
        //Put dmg dealer hear latter
    }












}
