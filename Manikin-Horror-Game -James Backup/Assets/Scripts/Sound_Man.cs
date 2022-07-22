// Robert-Daniel Bardin
// robdanbar@gmail.com
// 21/07/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Man : Entity
{
    enum Danger_Level
    {
        one,
        two,
        three,
        four,
        five,
        death
    }

    [SerializeField]
    private Timer timer;

    [SerializeField]
    private GameObject marker;

    private float phase_window;

    private float checkpoint;
    private float prevCheckpoint;

    private int teleport_count = 0;

    Danger_Level d_level = Danger_Level.one;


    private void Start()
    {
        phase_window = timer.GetTimeLimit() / 6;
        checkpoint = timer.GetTimerValue();
        prevCheckpoint = checkpoint;

    }

    void Update()
    {
        ConfigShift();
        PhaseShift();
        
        
        
        
        if (timer.CheckTimer() && !(teleport_count > 0))
        {
            Teleport(marker.transform);
            Flip();
            teleport_count ++;
        }
    }

    private void PhaseShift()
    {
        checkpoint = timer.GetTimerValue();
        if((checkpoint - prevCheckpoint) > phase_window)
        {
            prevCheckpoint = checkpoint;
            d_level += 1;
        }
    }

    private void ConfigShift()
    {
        switch(d_level)
        {
            case Danger_Level.one:
                this.GetComponent<Renderer>().material.color = Color.green;
                break;
            case Danger_Level.two:
                this.GetComponent<Renderer>().material.color = Color.yellow;
                break;

            case Danger_Level.three:
                this.GetComponent<Renderer>().material.color = Color.magenta;
                break;

            case Danger_Level.four:
                this.GetComponent<Renderer>().material.color = Color.red;
                break;

            case Danger_Level.five:
                this.GetComponent<Renderer>().material.color = Color.black;
                break;
        }
    }


    private void Teleport(Transform transfrom)
    {
        this.transform.position = transfrom.position;
    }

    private void Flip()
    {
        transform.Rotate(0, 0, 180, Space.Self);
    }
}
