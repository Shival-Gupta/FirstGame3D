using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string MenuName;
    public bool Visible;
    public void Open()
    {
        gameObject.SetActive(true);
        Visible = true;
    }
    public void Close()
    {
        gameObject.SetActive(false);
        Visible = false;
    }
}
