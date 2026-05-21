using UnityEngine;

public class TankCameraLogic : MonoBehaviour
{
    CameraController _cameraController;

    void Start()
    {
        _cameraController = FindFirstObjectByType<CameraController>();

        if (_cameraController.Targets.Count == 0)
        {
            _cameraController.Targets.Add(gameObject);
        }
        else if (_cameraController.Targets.Count == 1)
        {
            _cameraController.Targets.Add(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}