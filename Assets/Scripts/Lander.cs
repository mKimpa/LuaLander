using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour
{
    
    private Rigidbody2D landerRiggedbody2D = null;

    float force = 700f;
    float turnSpeed = 100f;
    float softLandingVelociyMagnitude = 4f;
    float minLandingDotVector = .9f;
    private void Awake()
    {
        landerRiggedbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Keyboard.current.upArrowKey.IsPressed())
        {
            landerRiggedbody2D.AddForce(force * transform.up * Time.deltaTime);
        }

        if (Keyboard.current.leftArrowKey.IsPressed())
        {
            landerRiggedbody2D.AddTorque(turnSpeed * Time.deltaTime);
        }

        if (Keyboard.current.rightArrowKey.IsPressed())
        {
            landerRiggedbody2D.AddTorque(-turnSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.relativeVelocity.magnitude > softLandingVelociyMagnitude)
        {
            Debug.Log("Crash!!!");
            return;
        }

        float dotVector = Vector2.Dot(Vector2.up, transform.up);
        if (dotVector < minLandingDotVector)
        {
            Debug.Log("Crash!!!");
            return;
        }

        Debug.Log("landed");
    }
}
