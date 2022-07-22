using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxItemDisplay : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Item current;
    [SerializeField] GameObject background;
    [SerializeField] Button takeBtn;
    [SerializeField] Image itemImage;

    public Item Current { get => current; set => current = value; }
    public Button TakeBtn { get => takeBtn; set => takeBtn = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool IsEmpty(){
        if(current == null){
            return true;
        }
        else{
            return false;
        }
    }
    public void TakeItem()
    {
        if (!Inventory.instance.CheckEmpty() || current == null)
        {
            return;
        }

        else
        {
            Inventory.instance.AddItem(current);
            Inventory.instance.BoxDisplay.CurrentBox.RemoveItem(current);
            
            current = null;
            UpdateDisplay(current);
            Inventory.instance.BoxDisplay.UpdateInventorySlots();
            UpdateTakeButton();
            Inventory.instance.BoxDisplay.UpdateTakeButtons();
        }
    }

    public void UpdateTakeButton()
    {
        if (Inventory.instance.CheckEmpty())
        {
            takeBtn.interactable = true;
        }
        else
        {
            takeBtn.interactable = false;
        }
    }

    public void UpdateDisplay(Item item)
    {
        current = item;
        if (item != null)
        {
            background.SetActive(true);
            nameText.text = item.itemName;
            itemImage.sprite = item.image;
            UpdateTakeButton();
        }
        else
        {
            background.SetActive(false);
        }
    }
}
