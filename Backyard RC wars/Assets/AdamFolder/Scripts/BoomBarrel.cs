using UnityEngine;

public class BoomBarrel : MonoBehaviour
{
    [SerializeField] int _power = 10;
    [SerializeField] int _radius = 5;
    [SerializeField] int _screenShakeIntensity = 10;
    [SerializeField] ParticleSystem _boomParticle; //Only need one particle on the scene

    void ExplosionLogic()
    {
        if (_boomParticle)
        {
            _boomParticle.transform.position = transform.position;
            _boomParticle.Play();
        }

        Camera.main.GetComponent<CameraController>().ScreenShake(_screenShakeIntensity);

        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, _radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player")) //Rigidbodies to knockback
            {
                Rigidbody hitRB = hitCollider.GetComponent<Rigidbody>();
                Vector3 direction = transform.position - hitCollider.transform.position;

                hitRB.AddForce(-direction * _power, ForceMode.Impulse);
            }
        }

        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Bullet")) ExplosionLogic(); //Tags to explode barrel
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, _radius);
    }
}