using UnityEngine;

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

    Camera _camera;

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

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _easingSpeed);
    }

    void AdjustFOV()
    {
        float distance = Vector3.Distance(_target0.transform.position, _target1.transform.position);
        float targetFOV = Mathf.Clamp(_baseFOV + distance * _fovPerUnit, _minFOV, _maxFOV);

        _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, targetFOV, Time.deltaTime * _easingSpeed);
    }
}