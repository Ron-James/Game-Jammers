using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableHoverEffect(){
        Component halo = model.GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
    }

    public void DisableHoverEffect(){
        Component halo = model.GetComponent("Halo");
        halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
    }
}
