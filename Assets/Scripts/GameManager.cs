using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score;
    private float time = 0f;
    private bool isTimerActive = false;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (isTimerActive)
        {
            time += Time.deltaTime;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public float GetTime()
    {
        return time;
    }
    
    public void AddScore(int inScore)
    {
        score += inScore;
    }

    private void Start()
    {
        //Lander.Instance.OnCoinPickup += Lander_OnCoinPickup;
        Lander.Instance.OnLanded += Lander_OnLanded;
        Lander.Instance.OnStateChanged += Lander_OnStateChanged;
    }

    private void Lander_OnCoinPickup(object sender, EventArgs  e)
    {
        AddScore(500);
    }

    private void Lander_OnLanded(object sender, Lander.OnLandedEventArgs e)
    {
        AddScore(e.score);
    }

    public void Lander_OnStateChanged(object sender, Lander.OnStateChangedEventArgs e)
    {
        isTimerActive = e.state == Lander.State.Normal;
    }

}
