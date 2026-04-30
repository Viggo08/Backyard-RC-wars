using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class WatterBallon : MonoBehaviour
{
    [SerializeField] float loadupSpeed;
    [SerializeField] float travelTime;
    [SerializeField] float arcHeight;

    [SerializeField] public GameObject areaMarkerPrefab; 
    [SerializeField] GameObject BallMarker;

    Transform target;
    public GameObject areaMarkerInstance;
    GameObject ball;

    PlayerInput input;
    AreaMarkerScript AMS;


    private void Awake()
    {
        input = GetComponentInParent<PlayerInput>();
    }
    private void Update()
    {

        if (input.actions["Attack1"].triggered && areaMarkerInstance != null && ball == null)
        {
            AMS = areaMarkerInstance.GetComponent<AreaMarkerScript>();
            Rigidbody rb = areaMarkerInstance.GetComponent<Rigidbody>();
            if (rb != null)
            {
                AMS.growthSpeed = 1f;
                rb.isKinematic = true;
            }
            Shoot();
            StartCoroutine(WaitFor());
            


        }
        else if (input.actions["Attack1"].triggered && areaMarkerInstance == null)
        {
            MarkArea();
        }
        else
        {
            return;
        }

    }

    void MarkArea()
    {
        areaMarkerInstance = Instantiate(areaMarkerPrefab, transform.position, transform.rotation);

        Rigidbody rb = areaMarkerInstance.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        if (rb != null)
        {
            Vector3 direction = transform.forward;
            direction.y = 0f;
            direction = direction.normalized;

            rb.linearVelocity = direction * loadupSpeed;
        }
    }

    void Shoot()
    {
        if (areaMarkerInstance != null)
        {
            Vector3 targetPosition = areaMarkerInstance.transform.position;

            ball = Instantiate(BallMarker, transform.position, Quaternion.identity);

            StartCoroutine(MoveInArc(ball, targetPosition));
        }
    }


    IEnumerator MoveInArc(GameObject obj, Vector3 target)
    {
        Vector3 start = transform.position;
        float elapsed = 0;

        while (elapsed < travelTime)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / travelTime;

            Vector3 position = Vector3.Lerp(start, target, t);
            float height = Mathf.Sin(Mathf.PI * t) * arcHeight;

            obj.transform.position = position + Vector3.up * height;

            yield return null;
        }
    }

    IEnumerator WaitFor()
    {
        yield return new WaitForSeconds(travelTime+0.5f);
        Destroy(areaMarkerInstance);
        Destroy(ball);
    }




}
