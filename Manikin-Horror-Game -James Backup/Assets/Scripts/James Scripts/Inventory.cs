using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERCharacter;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] Item [] items = new Item[6];
    [SerializeField] InventoryDisplay inventoryDisplay;
    [SerializeField] CraftController craftController;
    [SerializeField] BoxDisplay boxDisplay;
    [SerializeField] GameObject inventoryMenu;
    bool inventoryOpen;
    SUPERCharacterAIO player;

    public Item[] Items { get => items; set => items = value; }
    public InventoryDisplay InventoryDisplay { get => inventoryDisplay; set => inventoryDisplay = value; }
    public CraftController CraftController { get => craftController; set => craftController = value; }
    public bool InventoryOpen { get => inventoryOpen; set => inventoryOpen = value; }
    public BoxDisplay BoxDisplay { get => boxDisplay; set => boxDisplay = value; }
    public SUPERCharacterAIO Player { get => player; set => player = value; }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<SUPERCharacterAIO>();
        CloseInventory();
        player.enableCameraControl = true;
        inventoryDisplay.UpdateDisplays();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)){
            if(inventoryOpen){
                CloseInventory();
            }
            else{
                OpenInventory();
            }
        }
    }

    public void CursorAndCameraOn(){
        player.enableCameraControl = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CursorAndCameraOff(){
        player.enableCameraControl = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OpenInventory(){
        inventoryMenu.SetActive(true);
        inventoryMenu.GetComponentInChildren<InventoryDisplay>().UpdateDisplays();
        inventoryOpen = true;
        player.enableCameraControl = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void CloseInventory(){
        inventoryOpen = false;
        inventoryMenu.SetActive(false);
        player.enableCameraControl = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void AddItem(Item item){
        if(!CheckEmpty()){
            Debug.Log("not enough space");
            return;
        }
        else{
            items[LastPosition()] = item;
            inventoryDisplay.UpdateDisplays();
        }

    }
    public void OrderItems(){
        for (int loop = 0; loop < items.Length - 1; loop++){
            if(items[loop] == null && items[loop+1] != null){
                items[loop] = items[loop + 1];
                items[loop + 1] = null;
            }
        }
    }

    public void RemoveItem(Item i){

        for (int loop = 0; loop < items.Length; loop++){
            if(items[loop] == i){
                Debug.Log(items[loop].itemName);
                items[loop] = null;
                OrderItems();
                inventoryMenu.GetComponentInChildren<InventoryDisplay>().UpdateDisplays();
                return;
            }
        }
    }

    public void RemoveItem(int position){
        if(position < 0 || position > items.Length-1){
            return;
        }
        else{
            items[position] = null;
            OrderItems();
            UpdateAll();

        }
    }

    public bool CheckEmpty(){
        for (int loop = 0; loop < items.Length; loop++){
            if(items[loop] == null){
                return true;
            }
        }
        return false;
    }

    public int LastPosition(){
        for (int loop = 0; loop < items.Length; loop++){
            if(items[loop] == null){
                return loop;
            }
        }
        return -1;
    }
    public void UpdateAll(){
        craftController.UpdateCrafting();
        craftController.UpdateCraftSlots();
        inventoryDisplay.UpdateCraftButtons();
        inventoryDisplay.UpdateDisplays();
    }
}
