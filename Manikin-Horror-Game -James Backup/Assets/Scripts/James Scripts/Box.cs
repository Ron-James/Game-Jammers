using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] Item[] items;
    [SerializeField] Behaviour halo;

    public Item[] Items { get => items; set => items = value; }

    // Start is called before the first frame update
    void Start()
    {
        OrderItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OrderItems(){
        for (int loop = 0; loop < items.Length - 1; loop++){
            if(items[loop] == null && items[loop + 1] != null){
                items[loop] = items[loop + 1];
                items[loop + 1] = null;
            }
            else{
                continue;
            }
        }
    }

    public void AddItem(Item item){
        OrderItems();
        if(HasEmpty()){
            items[EmptySlotIndex()] = item;
            OrderItems();
            //Inventory.instance.BoxDisplay.OpenBoxMenu(items, this.gameObject.GetComponent<Box>());
        }
    }

    public void RemoveItem(Item item){
        for (int loop = 0; loop < items.Length; loop++){
            if(items[loop] == item){
                items[loop] = null;
                Inventory.instance.BoxDisplay.OpenBoxMenu(items, this.GetComponent<Box>());
            }
        }

    }

    public bool HasEmpty(){
        for (int loop = 0; loop < items.Length; loop++){
            if(items[loop] == null){
                return true;
            }
        }
        return false;
    }
    public int EmptySlotIndex(){
        for (int loop = 0; loop < items.Length; loop++){
            if(items[loop] == null){
                return loop;
            }
        }
        return -1;
    }
    public void EnableHalo(){
        halo.enabled = true;
    }
    public void DisableHalo(){
        halo.enabled = false;
    }

}
