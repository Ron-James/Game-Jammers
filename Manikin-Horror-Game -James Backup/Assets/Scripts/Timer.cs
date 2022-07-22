// Robert-Daniel Bardin
// robdanbar@gmail.com
// 21/07/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timer = 0f;

    [SerializeField]
    private float time_limit = 6f;

    [SerializeField]
    private Floor_Detect floor;

    private bool OnFloor = false;

    private bool time_reached = false;

    // Start is called before the first frame update
    void Awake()
    {
        ResetTimer();
    }

    // Update is called once per frame
    private void Update()
    {
        if(OnFloor)
        {
            UpDateTimer();
            //Debug.Log(this.name + " : " + timer);
        }


    }

    public void FloorTrue()
    {
        OnFloor = true;
    }
    public void FloorFalse()
    {
        OnFloor = false;
    }

    private void UpDateTimer()
    {

        timer += Time.deltaTime;
    }

    public float GetTimeElapsed()
    {
        return timer;
    }

    public float GetTimerValue()
    {
        return timer;
    }

    public void ResetTimer()
    {
        timer = 0f;
    }

    public void SetTimeLimit(float lim) 
    {
        time_limit = lim;
    }

    public float GetTimeLimit()
    {
        return time_limit;
    }

    public bool CheckTimer()
    {
        if (timer > time_limit)
        {
            time_reached = true;
        }
        else
        {
            time_reached = false;
        }

        return time_reached;
    }

}
