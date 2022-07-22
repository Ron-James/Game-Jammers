using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftController : MonoBehaviour
{
    [SerializeField] Item craft1;
    [SerializeField] Item craft2;
    [SerializeField] Recipe[] recipes;
    [SerializeField] Button craftBtn;
    [SerializeField] Button craft1Remove;
    [SerializeField] Button craft2Remove;
    [SerializeField] Image craft1Img;
    [SerializeField] Image craft2Img;
    [SerializeField] Image craftImg;
    [SerializeField] Item currentCraft;
    [SerializeField] Sprite emptyCraft;



    public Item Craft1 { get => craft1; set => craft1 = value; }
    public Item Craft2 { get => craft2; set => craft2 = value; }
    // Start is called before the first frame update
    void Start()
    {
        UpdateCrafting();
        UpdateCraftSlots();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Remove(int num)
    {
        if (num < 1 || num > 2)
        {
            Debug.Log("invalid remove");
            return;
        }
        else
        {
            switch (num)
            {
                case 1:
                    craft1 = null;
                    Inventory.instance.UpdateAll();
                    break;
                case 2:
                    craft2 = null;
                    Inventory.instance.UpdateAll();
                    break;
            }
        }
    }
    public void UpdateCraftSlots()
    {
        if (craft1 == null && craft2 == null)
        {
            craft1Img.sprite = emptyCraft;
            craft2Img.sprite = emptyCraft;
            craft1Remove.interactable = false;
            craft2Remove.interactable = false;
        }
        else if (craft1 != null && craft2 == null)
        {
            craft1Img.sprite = craft1.image;
            craft2Img.sprite = emptyCraft;
            craft1Remove.interactable = true;
            craft2Remove.interactable = false;
        }
        else if (craft1 == null && craft2 != null)
        {
            craft1Img.sprite = emptyCraft;
            craft2Img.sprite = craft2.image;
            craft1Remove.interactable = false;
            craft2Remove.interactable = true;
        }
        else
        {
            craft1Img.sprite = craft1.image;
            craft2Img.sprite = craft2.image;
            craft1Remove.interactable = true;
            craft2Remove.interactable = true;
        }
    }
    public bool IsCrafting(Item item)
    {
        if (craft1 == item || craft2 == item)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CraftCurrentItem()
    {
        if (!Inventory.instance.CheckEmpty())
        {
            Debug.Log("no space in inv");
            return;
        }
        else
        {
            Inventory.instance.RemoveItem(craft1);
            Inventory.instance.RemoveItem(craft2);
            Inventory.instance.AddItem(currentCraft);
            craft1 = null;
            craft2 = null;
            Inventory.instance.UpdateAll();
        }
    }
    public void UpdateCrafting()
    {
        Item prod = null;

        if (craft1 != null && craft2 != null)
        {
            for (int loop = 0; loop < recipes.Length; loop++)
            {
                if (recipes[loop].CheckViable(craft1, craft2, out prod) && prod != null)
                {
                    if (Inventory.instance.CheckEmpty())
                    {
                        craftBtn.interactable = true;
                    }
                    else
                    {
                        craftBtn.interactable = false;
                    }

                    craftImg.sprite = prod.image;
                    currentCraft = prod;
                }

            }
        }
        else
        {
            craftBtn.interactable = false;
            craftImg.sprite = emptyCraft;
            currentCraft = null;
        }
    }
}
