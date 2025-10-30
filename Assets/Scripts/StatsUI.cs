using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI statsTextMesh;

    [SerializeField] private GameObject LeftSpeedArrowObject;
    [SerializeField] private GameObject RightSpeedArrowObject;
    [SerializeField] private GameObject UpSpeedArrowObject;
    [SerializeField] private GameObject DownSpeedArrowObject;
    [SerializeField] private Image FuelBar;


    private void UpdateStatsTextMesh()
    {
        LeftSpeedArrowObject.SetActive(Lander.Instance.GetSpeedX() < 0f);
        RightSpeedArrowObject.SetActive(Lander.Instance.GetSpeedX() > 0f);
        UpSpeedArrowObject.SetActive(Lander.Instance.GetSpeedY() > 0f);
        DownSpeedArrowObject.SetActive(Lander.Instance.GetSpeedY() < 0f);

        FuelBar.fillAmount = Lander.Instance.GetFuelAlpha();


        statsTextMesh.text = GameManager.Instance.GetScore() + "\n" +
                             Mathf.Round(GameManager.Instance.GetTime()) + "\n" +
                             Mathf.Abs(Mathf.Round(Lander.Instance.GetSpeedX() * 10f)) + "\n" +
                             Mathf.Abs(Mathf.Round(Lander.Instance.GetSpeedY() * 10f)) + "\n";
                             
    }

    private void Update()
    {
        UpdateStatsTextMesh();
    }
}


