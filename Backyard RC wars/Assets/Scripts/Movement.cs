using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float rotationSpeed = 1f;

    Vector2 moveAmt;
    Vector2 rotationAmt;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        moveAmt = value.Get<Vector2>();
    }

    public void OnRotate(InputValue value)
    {
        rotationAmt = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        moveCalc();
        rotateCalc();
    }

    public void moveCalc()
    {
        Vector3 move = new Vector3(moveAmt.x, 0, moveAmt.y);
        Vector3 velocity = transform.TransformDirection(move) * moveSpeed;

        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);
    }

    public void rotateCalc()
    {
        float rotate = rotationAmt.x;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, rotate * rotationSpeed * Time.fixedDeltaTime, 0f));
    }

    void Update()
    {
        Debug.Log(moveAmt);
    }
}