using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string CurrentMenuName = "";
    public string PreviousMenuName = "";
    [SerializeField] Menu[] Menus;
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    public void OpenMenu(string MenuName)
    {
        for (int i = 0; i < Menus.Length; i++)
        {
            if (Menus[i].MenuName == MenuName)
                OpenMenu(Menus[i]);
            else if (Menus[i].Visible)
                CloseMenu(Menus[i]);
        }
    }
    public void OpenMenu(Menu Menu)
    {

        for (int i = 0; i < Menus.Length; i++)
        {
            if (Menus[i].Visible)
                CloseMenu(Menus[i]);
        }
        if (Menu.MenuName != "Loading")
        {
            if(Menu.MenuName != CurrentMenuName)
                PreviousMenuName = CurrentMenuName;
            CurrentMenuName = Menu.MenuName;
        }
        Menu.Open();
    }
    public void CloseMenu(Menu Menu)
    {
        Menu.Close();
    }

    public string previousMenuName()
    {
        string MenuName = PreviousMenuName;
        if (PreviousMenuName == "")
            MenuName = "MainMenu";
        if (PreviousMenuName == "Room")
            MenuName = "PlayMenu";
        return MenuName;
    }
}
