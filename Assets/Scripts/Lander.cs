using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour
{
    
    private Rigidbody2D landerRiggedbody2D = null;

    [SerializeField] private float force = 700f;
    [SerializeField] private float turnSpeed = 100f;
    [SerializeField] private float softLandingVelociyMagnitude = 4f;
    [SerializeField] private float minLandingDotVector = .9f;
    [SerializeField] private float maxScoreAmountLandingAngle = 100f;
    [SerializeField] private float scoreDotVectorMultiplyer = 10f;
    [SerializeField] private float maxScoreAmountLandingSpeed = 100f;

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
        float relativeVelocityMagnitude = collision2D.relativeVelocity.magnitude;

        if (!collision2D.gameObject.TryGetComponent(out LandingPad landingPad))
        {
            Debug.Log("Crash on the terrain!");
            return;
        }
        if (relativeVelocityMagnitude > softLandingVelociyMagnitude)
        {
            Debug.Log("Crash!!!");
            return;
        }

        float dotVector = Vector2.Dot(Vector2.up, transform.up);
        if (dotVector < minLandingDotVector)
        {
            Debug.Log("Wrong landing angle!!!");
            return;
        }

        Debug.Log("landed");

        float landingSpeedScore = (softLandingVelociyMagnitude - relativeVelocityMagnitude) * maxScoreAmountLandingSpeed;
        float landingAngleScore = maxScoreAmountLandingAngle - Mathf.Abs(dotVector - 1f) * scoreDotVectorMultiplyer * maxScoreAmountLandingAngle;


        Debug.Log("landingAngleScore: " + landingAngleScore);
        Debug.Log("landingSpeedScore: " + landingSpeedScore);

        int score = Mathf.RoundToInt((landingAngleScore + landingSpeedScore) * landingPad.GetScoreMultiplyer());

        Debug.Log("score: " + score);
    }
}
