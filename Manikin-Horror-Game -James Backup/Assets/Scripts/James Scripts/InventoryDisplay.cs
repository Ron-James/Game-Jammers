using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] ItemDisplay[] items;
    [SerializeField] GameObject menu;
    [SerializeField] CraftController craftController;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateCraftButtons()
    {
        if (Inventory.instance.CraftController.Craft1 != null && Inventory.instance.CraftController.Craft2 != null)
        {
            foreach (var element in items)
            {
                element.CraftButton.interactable = false;
            }
            return;
        }
        else
        {


            for (int loop = 0; loop < items.Length; loop++)
            {
                if (craftController.IsCrafting(items[loop].Current))
                {
                    items[loop].CraftButton.interactable = false;
                }
                else
                {
                    items[loop].CraftButton.interactable = true;
                }
            }
        }
    }
    
    public void UpdateDisplays()
    {
        if (Inventory.instance.Items.Length != items.Length)
        {
            Debug.Log("not enough slots");
            return;
        }
        else
        {
            Inventory.instance.OrderItems();
            for (int loop = 0; loop < Inventory.instance.Items.Length; loop++)
            {
                items[loop].UpdateDisplay(Inventory.instance.Items[loop]);

            }
        }
    }

    
}
