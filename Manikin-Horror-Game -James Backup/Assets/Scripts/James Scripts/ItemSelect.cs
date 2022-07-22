using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSelect : MonoBehaviour
{
    RaycastHit itemHit;
    [SerializeField] Transform cam;
    [SerializeField] LayerMask itemMask;
    [SerializeField] float itemDistance = 10;

    ItemController lastItem;
    [SerializeField] Box lastBox;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(cam.transform.position, cam.position + (cam.forward * itemDistance), Color.red, Time.deltaTime);
        if (Physics.Raycast(cam.position, cam.transform.forward, out itemHit, itemDistance))
        {
            if (itemHit.collider.gameObject.GetComponentInParent<ItemController>() != null)
            {
                Debug.Log("hello");
                itemHit.collider.gameObject.GetComponentInParent<ItemController>().EnableHalo();
                lastItem = itemHit.collider.gameObject.GetComponentInParent<ItemController>();
                if (Input.GetMouseButtonDown(0))
                {
                    Inventory.instance.AddItem(itemHit.collider.gameObject.GetComponentInParent<ItemController>().Item);
                    itemHit.collider.gameObject.SetActive(false);
                }
            }
            else if (itemHit.collider.GetComponent<Box>() != null)
            {
                itemHit.collider.GetComponent<Box>().EnableHalo();
                lastBox = itemHit.collider.GetComponent<Box>();
                if (Input.GetMouseButtonDown(0))
                {
                    Inventory.instance.BoxDisplay.OpenBoxMenu(itemHit.collider.GetComponent<Box>().Items, lastBox);
                }
            }
            else
            {
                if (lastItem != null)
                {
                    lastItem.DisableHalo();

                }
                if (lastBox != null)
                {
                    lastBox.DisableHalo();

                }
            }


        }
        else
        {
            if (lastItem != null)
            {
                lastItem.DisableHalo();

            }
            if (lastBox != null)
            {
                lastBox.DisableHalo();

            }
        }
    }
}
