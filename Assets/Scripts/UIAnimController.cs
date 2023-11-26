using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimController : MonoBehaviour
{
    public GameObject[] colors;
   // public Sprite[] openAndCloseICon;
    public Image selectedIconPlacement;
    public Vector3[] selectedcolorposition;
    public bool isColorEnable = false;
    bool isDefaultColor = true;
    Color defaultcarcolor = Color.green;
    [SerializeField]
    Material primaryColor;
    Image openandclosebutton;
    Image selectedIcon;

    private void Start()
    {
        primaryColor.color = Color.black;
        openandclosebutton = GetComponent<Image>();
        
    }

    

    public void EnableColors()
    {
        if(!isColorEnable)
        {
            foreach (GameObject g in colors)
            {
                g.SetActive(true);
            }
            isColorEnable = true;
        }
        else
        {
            foreach (GameObject g in colors)
            {
                g.SetActive(false);
            }
            isColorEnable = false;
        }
    }

    public void ChangeRedColor()
    {
        isDefaultColor = true;
        if (isDefaultColor)
        {
            if (primaryColor.color != Color.red)
            {
                primaryColor.color = Color.red;
                isDefaultColor = false;
            }
            else
            {
                return;
            }

        }
    }
        
    public void ChangeBlueColor()   
    {
        isDefaultColor = true;
        if (isDefaultColor)
        {
            if (primaryColor.color != Color.blue)
            {
                primaryColor.color = Color.blue;
                isDefaultColor = false;
            }
        }
    }

    public void ChangeYellowColor()
    {
        isDefaultColor = true;
        if (isDefaultColor)
        {
            if (primaryColor.color != Color.gray)
            {
                primaryColor.color = Color.gray;
                isDefaultColor = false;
            }
        }
    }

    public void ChangeBlackColor()
    {
        isDefaultColor = true;
        if (isDefaultColor)
        {
            if (primaryColor.color != Color.black)
            {
                primaryColor.color = Color.black;
                isDefaultColor = false;
            }
        }
    }

    public void ChangeWhiteColor()
    {
        isDefaultColor = true;
        if (isDefaultColor)
        {
            if (primaryColor.color != Color.white)
            {
                primaryColor.color = Color.white;
                isDefaultColor = false;
            }
        }
    }

}

