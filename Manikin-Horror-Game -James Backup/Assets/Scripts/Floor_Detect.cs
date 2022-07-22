// Robert-Daniel Bardin
// robdanbar@gmail.com
// 21/07/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Detect : MonoBehaviour
{
    [SerializeField]
    private Timer timer_overall;
    [SerializeField]
    private Timer timer_sound;
    [SerializeField]
    private Timer timer_sight;
    [SerializeField]
    private Timer timer_smell;
        
    

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(this.gameObject.name);
        timer_overall.FloorTrue();

        if((this.gameObject.name.Equals("Hallway") || this.gameObject.name.Equals("Reception") ) && other.gameObject.name.Equals("Player"))
        {
            //Debug.Log("Not case");
            timer_sound.FloorFalse();
            timer_sight.FloorFalse();
            timer_smell.FloorFalse();
        }
        else if(other.gameObject.name.Equals("Player") && this.gameObject.name.Equals("Sound_Floor"))
        {
            timer_sound.FloorTrue();
        }
        else if (other.gameObject.name.Equals("Player") && this.gameObject.name.Equals("Sight_Floor"))
        {
            timer_sight.FloorTrue();
        }
        else if (other.gameObject.name.Equals("Player") && this.gameObject.name.Equals("Smell_Floor"))
        {
            timer_smell.FloorTrue();
        }
        
    }


    



    
}
