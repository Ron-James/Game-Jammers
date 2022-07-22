using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxInventoryDisplay : MonoBehaviour
{
    [SerializeField] Item current;
    [SerializeField] Text nameText;
    [SerializeField] Button storeBtn;
    [SerializeField] Image currentImg;
    [SerializeField] GameObject background;

    public Item Current { get => current; set => current = value; }
    public Button StoreBtn { get => storeBtn; set => storeBtn = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DropItem(){
        Vector3 position = Inventory.instance.Player.playerCamera.transform.position + 5 * (Inventory.instance.Player.playerCamera.transform.forward);
        Instantiate(current.prefab, position, Quaternion.identity);
        Inventory.instance.RemoveItem(current);
        Inventory.instance.UpdateAll();
        UpdateStoreButton();
        UpdateDisplay(null);
        
    }
    public void StoreItem(){
        if(current == null){
            Debug.Log("cannot store empty object");
            return;
        }
        else{
            Inventory.instance.BoxDisplay.AddToCurrentBox(current);
            Inventory.instance.RemoveItem(current);
            Inventory.instance.UpdateAll();
            UpdateStoreButton();
            UpdateDisplay(null);
            Inventory.instance.BoxDisplay.UpdateStoreButtons();


        }
    }
    public void UpdateStoreButton(){
        if(Inventory.instance.BoxDisplay.HasEmptySlot()){
            storeBtn.interactable = true;
        }
        else{
            storeBtn.interactable = false;
        }
    }
    public void UpdateDisplay(Item item){
        current = item;
        if(item != null){
            nameText.text = item.itemName;
            currentImg.sprite = item.image;
            background.SetActive(true);
        }
        else{
            background.SetActive(false);
        }
    }
}
