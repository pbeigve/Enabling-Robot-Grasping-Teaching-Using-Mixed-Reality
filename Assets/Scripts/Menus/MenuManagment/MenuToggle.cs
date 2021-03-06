using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    MenuManager menuManager;
    GameObject MenuScripts;
    [HideInInspector] public bool currentMenu = false;

    private void Awake()
    {
        MenuScripts = GameObject.Find("MenuScripts");
        menuManager = MenuScripts.GetComponent<MenuManager>();
    }

    public void ButtonPressed()
    {
        if(currentMenu)
        {
            currentMenu = false;
            menuManager.ManageMenus();
        }
        else
        {
            menuManager.DeactivateOtherMenu();
            currentMenu = true;
            menuManager.ManageMenus();
        }
    }
}
