using UnityEngine;

public class Drill : MonoBehaviour
{
    [SerializeField] float DamageTimer = 1f;
    [SerializeField] float Damage = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //How often DoDmage will be:
        InvokeRepeating(nameof(DoDamage), 0f, DamageTimer);
    }

    void DoDamage()
    {
        Debug.Log("Do damage");
    }

}
