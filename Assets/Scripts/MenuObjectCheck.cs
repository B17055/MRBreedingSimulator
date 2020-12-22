using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuObjectCheck : MonoBehaviour
{
    bool check = false;

    public void MenuChange()
    {
        if (!check)
        {
            gameObject.SetActive(true);
            check = true;
        }
        else
        {
            gameObject.SetActive(false);
            check = false;
        }
    }

    public void MenuClose()
    {
        gameObject.SetActive(false);
        check = false;
    }
}
