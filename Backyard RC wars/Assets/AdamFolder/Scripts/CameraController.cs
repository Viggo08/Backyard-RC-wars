using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [Header("Targets")]
    [SerializeField] GameObject _target0;
    [SerializeField] GameObject _target1;

    [Header("Settings")]
    [SerializeField] float _easingSpeed = 10f;
    [SerializeField] float _baseFOV = 20f;
    [SerializeField] float _fovPerUnit = 2f;
    [SerializeField] float _minFOV = 20f;
    [SerializeField] float _maxFOV = 120f;

    [Header("Screen Shake")]
    [SerializeField] float _shakeBaseDuration = 0.3f;

    Camera _camera;
    Vector3 _shakeOffset;

    void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    void Start()
    {
        _camera.fieldOfView = _baseFOV;
    }

    void Update()
    {
        FollowMidpoint();
        AdjustFOV();
    }

    void FollowMidpoint()
    {
        Vector3 midpoint = (_target0.transform.position + _target1.transform.position) / 2f;
        Vector3 targetPosition = new Vector3(midpoint.x, transform.position.y, midpoint.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _easingSpeed) + _shakeOffset;
    }

    void AdjustFOV()
    {
        float distance = Vector3.Distance(_target0.transform.position, _target1.transform.position);
        float targetFOV = Mathf.Clamp(_baseFOV + distance * _fovPerUnit, _minFOV, _maxFOV);

        _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, targetFOV, Time.deltaTime * _easingSpeed);
    }

    public void ScreenShake(int intensity)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine(intensity));
    }

    IEnumerator ShakeRoutine(int intensity)
    {
        float duration = _shakeBaseDuration * intensity;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float progress = elapsed / duration;
            float currentIntensity = Mathf.Lerp(intensity, 0f, progress);

            _shakeOffset = new Vector3(
                Random.Range(-currentIntensity, currentIntensity),
                Random.Range(-currentIntensity, currentIntensity),
                0f
            );

            elapsed += Time.deltaTime;
            yield return null;
        }

        _shakeOffset = Vector3.zero;
    }
}