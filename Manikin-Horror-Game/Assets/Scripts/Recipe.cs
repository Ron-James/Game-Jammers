using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe", order = 2)]
public class Recipe : ScriptableObject
{
    public Item first;
    public Item second;
    public Item result;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckViable(Item item1, Item item2, out Item product)
    {
        if (item1 == first)
        {
            if (item2 == second)
            {
                product = result;
                return true;
            }
            else{
                product = null;
                return false;
            }
        }
        else if (item1 == second)
        {
            if (item2 == first)
            {
                product = result;
                return true;
            }
            else{
                product = null;
                return false;
            }
        }
        else
        {
            product = null;
            return false;
        }
    }
}
