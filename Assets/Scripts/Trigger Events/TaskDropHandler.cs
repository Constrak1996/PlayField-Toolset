using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TaskDropHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textBox;
    public List<string> triggers = new List<string>();
    public List<string> items = new List<string>();
    
    public GameObject sm;
        
    public void InsertTriggerEvents()
    {

        var dropdown = this.gameObject.GetComponent<Dropdown>();
        dropdown.ClearOptions();
        dropdown.options.Add(new Dropdown.OptionData() { text = "Choose event to use" });
        foreach (var item in triggers)
        {
            
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
        }

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }
    void DropdownItemSelected(Dropdown dropdown)
    {
        int index = dropdown.value;
        textBox.text = dropdown.options[index].text;
    }

    public void InsertMainObjDropDown()
    {

        var dropdown = GameObject.Find("obj1DropDown").GetComponent<Dropdown>();
        var dropdown2 = GameObject.Find("obj2DropDown").GetComponent<Dropdown>();

        dropdown.ClearOptions();
        dropdown2.ClearOptions();
        dropdown.options.Add(new Dropdown.OptionData() { text = "Choose Main object" });
        dropdown2.options.Add(new Dropdown.OptionData() { text = "Choose Scecondary object" });
        foreach (var item in items)
        {
            dropdown.options.Add(new Dropdown.OptionData() { text = item });
            dropdown2.options.Add(new Dropdown.OptionData() { text = item });
        }
        items.Clear();

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
        DropdownItemSelected(dropdown2);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown2); });
    }
    

    public void RemoveItem()
    {
        foreach (var drop in items)
        {
            foreach (Transform item in sm.transform)
            {
                if(drop != item.name)
                {

                }
            }
        }
        
    }
   public void AddItem()
    {
        foreach (Transform item in sm.transform)
        {
            if (!items.Contains(item.name))
            {
                items.Add(item.name);    
            }
        }
        InsertMainObjDropDown();
        
        

    }
    void Update()
    {
       
        
        
        
    }

}
