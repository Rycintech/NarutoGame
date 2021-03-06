﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionManager : MonoBehaviour {

    public int playerNum;
    public GameObject[] icons;
    public GameObject[] selectedIcons;
    public GameObject[] portraits;
    public GameObject[] nametags;
    public int numIconsPerRow = 3;

    private KeyCode right, left, up, down;
    private float horizontalValue, verticalValue;
    private int currentSelection = 0;

    private void Start()
    {
        if (playerNum == 1)
        {
            right = KeyCode.D;
            left = KeyCode.A;
            up = KeyCode.W;
            down = KeyCode.S;
        }
        else
        {
            right = KeyCode.RightArrow;
            left = KeyCode.LeftArrow;
            up = KeyCode.UpArrow;
            down = KeyCode.DownArrow;
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(left))
        {
            horizontalValue = -1f;
        }
        else if (Input.GetKeyUp(right))
        {
            horizontalValue = 1f;
        }
        else if (Input.GetKeyUp(up))
        {
            verticalValue = -1f;
        }
        else if (Input.GetKeyUp(down))
        {
            verticalValue = 1f;
        }
    }

    private void FixedUpdate()
    {
        if (horizontalValue > 0)
        {
            PreSetActiveIcons();
            currentSelection++;
            if (currentSelection >= icons.Length)
            {
                currentSelection = 0;
            }


            PostSetActiveIcons();
            
        }
        else if (horizontalValue < 0)
        {
            PreSetActiveIcons();
            currentSelection--;
            if (currentSelection < 0)
            {
                currentSelection = icons.Length - 1;
            }
            PostSetActiveIcons();
        }
        else if (verticalValue > 0)
        {
            PreSetActiveIcons();
            currentSelection += numIconsPerRow;
            if (currentSelection >= icons.Length)
            {
                currentSelection -= icons.Length;
            }
            PostSetActiveIcons();
        }
        else if (verticalValue < 0)
        {
            PreSetActiveIcons();
            currentSelection -= numIconsPerRow;
            if (currentSelection < 0)
            {
                currentSelection += icons.Length;
            }
            PostSetActiveIcons();
        }
        horizontalValue = 0;
        verticalValue = 0;
    }

    private void PreSetActiveIcons()
    {
        icons[currentSelection].SetActive(true);
        selectedIcons[currentSelection].SetActive(false);
        portraits[currentSelection].SetActive(false);
        nametags[currentSelection].SetActive(false);
    }

    private void PostSetActiveIcons()
    {
        icons[currentSelection].SetActive(false);
        selectedIcons[currentSelection].SetActive(true);
        portraits[currentSelection].SetActive(true);
        nametags[currentSelection].SetActive(true);
    }

    public int GetCurrentSelection()
    {
        return currentSelection;
    }
}
