// Robert-Daniel Bardin
// robdanbar@gmail.com
// 21/07/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Manager : MonoBehaviour
{

    [SerializeField]
    private GameObject player;



    public GameObject GetPlayer()
    {
        return player;
    }

   
}
