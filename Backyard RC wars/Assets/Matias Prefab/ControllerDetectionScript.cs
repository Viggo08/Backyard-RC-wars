using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerDetectionScript : MonoBehaviour
{

    public Gamepad playerGamepad1;
    public Gamepad playerGamepad2;

    void Start()
    {
        AssignExistingControllers();
    }

    void OnEnable()
    {
   
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    void AssignExistingControllers()
    {

        var allGamepads = Gamepad.all;

        if (allGamepads.Count > 0) playerGamepad1 = allGamepads[0];
        if (allGamepads.Count > 1) playerGamepad2 = allGamepads[1];

        LogControllers();
    }

    void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
     
        if (change == InputDeviceChange.Added || change == InputDeviceChange.Removed)
        {
           
            playerGamepad1 = null;
            playerGamepad2 = null;

            AssignExistingControllers();
        }
    }

    void Update()
    {
        
        if (playerGamepad1 != null && playerGamepad1.buttonSouth.wasPressedThisFrame)
        {
            Debug.Log("Player 1 pressed");
        }

        
        if (playerGamepad2 != null && playerGamepad2.buttonSouth.wasPressedThisFrame)
        {
            Debug.Log("Player 2 pressed");
        }
    }

    void LogControllers()
    {
        if (playerGamepad1 != null) Debug.Log($"Player 1 assigned: {playerGamepad1.displayName}");
        if (playerGamepad2 != null) Debug.Log($"Player 2 assigned: {playerGamepad2.displayName}");
    }
}

