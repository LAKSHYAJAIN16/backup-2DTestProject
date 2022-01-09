using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text, status;
    public string time;
    private float timer = 1;
    public deathscreen ds;
    public spawnerforenemies spawner;
    public static Timer Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public void StartTimer()
    {
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = Mathf.Floor(timer % 60).ToString("00");

        text.text = string.Format("{0}:{1}", minutes, seconds);

        status.text = StatusText(Mathf.Floor(timer / 60));
        time = text.text;
        CheckForDifficulty();
    }

    private string StatusText(float f)
    {
        if (f < 1) return "Very Easy";
        if (f < 2) return "easy";
        if (f < 3) return "medium";
        if (f < 4) return "hard";
        if (f < 16) return "very hard";
        if (f < 20) return "impossible";
        if (f < 25) return "die";
        if (f < 30) return "crazy";
        return "f";
    }

    public int GetMinutes()
    {
        return (int)Mathf.Floor(timer / 60);
    }

    public int GetSeconds()
    {
        return (int)Mathf.Floor(timer % 60);
    }

    public void ded()
    {
        ds.TimeOver(time);
        Debug.Log("DED CALLED");
        this.enabled = false;
    }

    public void CheckForDifficulty()
    {
        if(time == "Very Easy")
        {
            spawner.veryeasy();
        }
        if (time == "easy")
        {
            spawner.easy();
        }
        if (time == "medium")
        {
            spawner.medium();
        }
    }

}