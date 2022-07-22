using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemDisplay : MonoBehaviour
{
    [SerializeField] Item current;
    [SerializeField] Text nametext;
    [SerializeField] Button craftButton;
    [SerializeField] GameObject Background;
    [SerializeField] Image image;

    public Button CraftButton { get => craftButton; set => craftButton = value; }
    public Item Current { get => current; set => current = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateDisplay(Item item){
        current = item;
        if(item != null){
            Background.SetActive(true);
            nametext.text = item.itemName;
            image.sprite = item.image;

        }
        else{
            Background.SetActive(false);
        }

    } 
    public void DropItem(){
        Vector3 position = Inventory.instance.Player.gameObject.transform.position;
        position += Inventory.instance.Player.gameObject.transform.forward * 5;
        Instantiate(current.prefab, position, Quaternion.identity);
        Inventory.instance.RemoveItem(current);
        
        
        //
        UpdateDisplay(null);


    }
    public void AddToCraft(){
        if(current == null){
            return;
        }
        CraftController craft = Inventory.instance.CraftController;
        InventoryDisplay inventoryDisplay = Inventory.instance.InventoryDisplay;

        if(craft.Craft1 == null){
            craft.Craft1 = current;
            craft.UpdateCraftSlots();
            craft.UpdateCrafting();
            inventoryDisplay.UpdateCraftButtons();
        }
        else if(craft.Craft2 == null && craft.Craft1 != null){
            craft.Craft2 = current;
            craft.UpdateCraftSlots();
            craft.UpdateCrafting();
            inventoryDisplay.UpdateCraftButtons();
        }
    }
    

}
