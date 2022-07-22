using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] GameObject model;
    [SerializeField] Behaviour halo;

    public Item Item { get => item; set => item = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableHalo(){
        halo.enabled = true;
    }
    public void DisableHalo(){
        halo.enabled = false;
    }
}
