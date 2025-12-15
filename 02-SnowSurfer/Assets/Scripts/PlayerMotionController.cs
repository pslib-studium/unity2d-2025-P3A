using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotionController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    InputAction moveAction;
    Rigidbody2D rb;

    Vector2 moveVector;
    float previousRotation = 0f;
    float totalRotation = 0f;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        CalculateFlips();
    }

    void RotatePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        //Debug.Log($"Move Vector: {moveVector}");
        if (moveVector.x < 0)
        {
            rb.AddTorque(moveVector.x / 10);
        }
        else if (moveVector.x > 0)
        {
            rb.AddTorque(-1 * moveVector.x / 10);
        }
    }

    void CalculateFlips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);
        if (totalRotation > 340 || totalRotation < -340)
        {
            totalRotation = 0;
            Debug.Log("Flip detected!");
        }
        previousRotation = currentRotation;
    }
}
