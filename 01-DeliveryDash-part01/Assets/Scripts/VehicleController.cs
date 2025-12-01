using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float steerSpeed = 10f;
    [SerializeField] float regularSpeed = 1f;
    [SerializeField] float regularSteer = 1f;

    void Start()
    {
        Debug.Log("Vehicle Exists");
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0.0f;
        float steer = 0.0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = regularSpeed;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            move = -regularSpeed;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = regularSteer;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            steer = -regularSteer;
        }
        //Debug.Log("Move: " + move + " Steer: " + steer);
        transform.Translate(0, move * currentSpeed * Time.deltaTime, 0);
        transform.Rotate(0, 0, steer * steerSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Vehicle Collided with " + collision.gameObject.name);
    }
}
