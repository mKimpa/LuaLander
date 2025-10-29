using UnityEngine;
using TMPro;

public class LandingPadVisuals : MonoBehaviour
{

    [SerializeField] private TextMeshPro scoreMultiplierTextMesh = null;

    private void Awake()
    {
        LandingPad landingPad = GetComponent<LandingPad>();
        if (scoreMultiplierTextMesh== null)
        {
            Debug.Log("scoreMultiplyerTextMesh should be setted!");
            return;
        }

        scoreMultiplierTextMesh.text = "x" + landingPad.GetScoreMultiplyer();

    }
}
