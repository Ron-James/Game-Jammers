using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{
    
    public int id;
    public string itemName;
    public string description;
    public Sprite image;
    public GameObject prefab;



    

}
