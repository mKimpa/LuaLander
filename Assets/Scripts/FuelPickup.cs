using UnityEngine;
using UnityEngine.Rendering;

public class FuelPickup : MonoBehaviour
{
    [SerializeField] private float Amount = 10f;

    public float GetFuelAmount ()
    {
        return Amount;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
