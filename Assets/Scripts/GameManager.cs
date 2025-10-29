using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int score;

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int inScore)
    {
        score += inScore;
    }

    private void Start()
    {
        Lander.Instance.OnCoinPickup += Lander_OnCoinPickup;
        Lander.Instance.OnLanded += Lander_OnLanded;
    }

    private void Lander_OnCoinPickup(object sender, EventArgs  e)
    {
        AddScore(500);
    }

    private void Lander_OnLanded(object sender, Lander.OnLandedEventArgs e)
    {
        AddScore(e.score);
    }
}
