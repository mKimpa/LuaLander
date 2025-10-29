using System;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour
{

    public event EventHandler OnUpForce;
    public event EventHandler OnLeftForce;
    public event EventHandler OnRightForce;
    public event EventHandler OnNoForce;

    private Rigidbody2D landerRiggedbody2D = null;

    private float fuelConsumptionAmmount = 1;
    private float fuelAmount = 0;

    [SerializeField] private float force = 700f;
    [SerializeField] private float turnSpeed = 100f;
    [SerializeField] private float softLandingVelociyMagnitude = 4f;
    [SerializeField] private float minLandingDotVector = .9f;
    [SerializeField] private float maxScoreAmountLandingAngle = 100f;
    [SerializeField] private float scoreDotVectorMultiplyer = 10f;
    [SerializeField] private float maxScoreAmountLandingSpeed = 100f;
    [SerializeField] private float fuelCapacity = 30;

    private void Awake()
    {
        landerRiggedbody2D = GetComponent<Rigidbody2D>();
        fuelAmount = fuelCapacity;
    }

    private void FixedUpdate()
    {
        OnNoForce?.Invoke(this, EventArgs.Empty);

        if (fuelAmount <= 0f)
        {
            return;
        }

        if (Keyboard.current.upArrowKey.IsPressed() ||
            Keyboard.current.leftArrowKey.IsPressed() ||
            Keyboard.current.rightArrowKey.IsPressed())
        {
            ConsumeFuel();
        }

        if (Keyboard.current.upArrowKey.IsPressed())
        {
            landerRiggedbody2D.AddForce(force * transform.up * Time.deltaTime);
            OnUpForce?.Invoke(this, EventArgs.Empty);        
        }

        if (Keyboard.current.leftArrowKey.IsPressed())
        {
            landerRiggedbody2D.AddTorque(turnSpeed * Time.deltaTime);
            OnLeftForce?.Invoke(this, EventArgs.Empty);
        }

        if (Keyboard.current.rightArrowKey.IsPressed())
        {
            landerRiggedbody2D.AddTorque(-turnSpeed * Time.deltaTime);
            OnRightForce?.Invoke(this, EventArgs.Empty);
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

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.TryGetComponent(out FuelPickup fuelPickup))
        {
            AddFuel(fuelPickup.GetFuelAmount());
            fuelPickup.DestroySelf();
        }
    }
    private void ConsumeFuel()
    {
        fuelAmount -= Mathf.Min(fuelConsumptionAmmount * Time.deltaTime, fuelAmount);
    }

    private void AddFuel(float amount)
    {
        fuelAmount += Mathf.Min(amount, fuelCapacity - fuelAmount);
    }
}
