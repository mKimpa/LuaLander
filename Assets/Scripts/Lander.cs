using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour
{
    
    private Rigidbody2D landerRiggedbody2D = null;

    public float force = 700f;
    public float turnSpeed = 100f;

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
}
