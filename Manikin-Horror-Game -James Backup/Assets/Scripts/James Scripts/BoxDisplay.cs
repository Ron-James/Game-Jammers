using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDisplay : Singleton<BoxDisplay>
{
    [SerializeField] BoxItemDisplay [] itemSlots;
    [SerializeField] BoxInventoryDisplay[] inventorySlots;
    [SerializeField] GameObject menu;
    [SerializeField] Box currentBox;

    public Box CurrentBox { get => currentBox; set => currentBox = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateStoreButtons(){
        if(currentBox.HasEmpty()){
            for (int loop = 0; loop < inventorySlots.Length; loop++){
                inventorySlots[loop].StoreBtn.interactable = true;
            }
        }
        else{
            for (int loop = 0; loop < inventorySlots.Length; loop++){
                inventorySlots[loop].StoreBtn.interactable = false;
            }
        }
    }
    public void OrderBoxItems(){
        for (int loop = 0; loop < itemSlots.Length - 1; loop++){
            if(itemSlots[loop].IsEmpty()){
                if(!itemSlots[loop + 1].IsEmpty()){
                    itemSlots[loop].UpdateDisplay(itemSlots[loop+1].Current);
                    itemSlots[loop + 1].UpdateDisplay(null);
                }
            }
        }
    }

    public void UpdateTakeButtons(){
        if(!Inventory.instance.CheckEmpty()){
            for (int loop = 0; loop < itemSlots.Length; loop++){
                itemSlots[loop].TakeBtn.interactable = false;
            }
        }
        else{
            for (int loop = 0; loop < itemSlots.Length; loop++){
                itemSlots[loop].TakeBtn.interactable = true;
            }
        }
    }
    public bool HasEmptySlot(){
        foreach(var element in itemSlots){
            if(element.IsEmpty()){
                return true;
            }
        }
        return false;
    }
    public void AddToCurrentBox(Item item){
        currentBox.AddItem(item);
        OpenBoxMenu(currentBox.Items, currentBox);
        OrderInventorySlots();
    }


    

    public void OrderInventorySlots(){
        for (int loop = 0; loop < inventorySlots.Length -1; loop++){
            if(inventorySlots[loop].Current == null && inventorySlots[loop+1].Current != null){
                inventorySlots[loop].UpdateDisplay(inventorySlots[loop + 1].Current);
                inventorySlots[loop + 1].UpdateDisplay(null);
            }
        }
    }

    public void UpdateInventorySlots(){
        for (int k = 0; k < Inventory.instance.Items.Length; k++){
            Inventory.instance.OrderItems();
            if(Inventory.instance.Items[k] != null){
                inventorySlots[k].UpdateDisplay(Inventory.instance.Items[k]);
                inventorySlots[k].UpdateStoreButton();
            }
            else{
                inventorySlots[k].UpdateDisplay(null);
            }
            
        }
        
    }

    
    public void OpenBoxMenu(Item [] items, Box box){
        if(items.Length > itemSlots.Length){
            Debug.Log("not enough items");
            return;
        }
        currentBox = box;
        Inventory.instance.CursorAndCameraOn();
        menu.SetActive(true);
        OrderBoxItems();
        for (int loop = 0; loop < itemSlots.Length; loop++)
        {
            itemSlots[loop].UpdateDisplay(items[loop]);
            

        }
        for (int k = 0; k < Inventory.instance.Items.Length; k++){
            Inventory.instance.OrderItems();
            if(Inventory.instance.Items[k] != null){
                inventorySlots[k].UpdateDisplay(Inventory.instance.Items[k]);
                inventorySlots[k].UpdateStoreButton();
            }
            else{
                inventorySlots[k].UpdateDisplay(null);
            }
            
        }
        UpdateTakeButtons();
    }
    public void CloseBoxMenu(){
        Inventory.instance.CursorAndCameraOff();
        menu.SetActive(false);                                      
    }
}
