using UnityEngine;

public class LandingPad : MonoBehaviour
{

    [SerializeField] private int scoreMultiplier = 1;

    public int GetScoreMultiplyer()
    {
        return scoreMultiplier;
    }
}
