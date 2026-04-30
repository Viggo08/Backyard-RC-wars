using UnityEngine;

public class BoomBarrel : MonoBehaviour
{
    [SerializeField] int _explosionPower = 10;
    [SerializeField] int _screenShakeForce = 10;
    [SerializeField] ParticleSystem _boomParticle; //Only need one particle on the scene

    void ExplosionLogic(GameObject other)
    {
        Rigidbody otherRB = other.GetComponent<Rigidbody>();
        Vector3 direction = transform.position - other.transform.position;

        if (_boomParticle)
        {
            _boomParticle.transform.position = transform.position;
            _boomParticle.Play();
        }

        Camera.main.GetComponent<CameraController>().ScreenShake(_screenShakeForce);
        otherRB.AddForce(-direction * _explosionPower, ForceMode.Impulse);

        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) ExplosionLogic(other.gameObject);
    }
}