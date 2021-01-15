using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string itemID;
    // Start is called before the first frame update
    void Start()
    {
        itemID = GameObject.Find("ItemDropdownLabel").GetComponent<Text>().text;
    }

    public void Found()
    {
        EventController.ItemFound(itemID);
    }
}
