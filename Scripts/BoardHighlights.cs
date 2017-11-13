﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardHighlights : MonoBehaviour {

    public static BoardHighlights Instance { set; get; }

    public GameObject highlightPrefab;
    private List<GameObject> highlights;

    // Looks for gameobject and creates an instance for this to be used in the BoardManager script.
    private void Start()
    {
        Instance = this;
        highlights = new List<GameObject>();
    }

    // Gets gameobject and adds it the the game.
    private GameObject GetHighlightObject()
    {
        GameObject go = highlights.Find(g => !g.activeSelf);

        if (go == null)
        {
            go = Instantiate(highlightPrefab);
            highlights.Add(go);
        }
        return go;
    }

    // If chess piece is selected, then an array is casted to highlight the moves the player can achieve per class.
    public void HighlightAllowedMoves(bool[,]moves)
    {
        for(int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (moves[i, j])
                {
                    GameObject go = GetHighlightObject();
                    go.SetActive(true);
                    go.transform.position = new Vector3(i+0.5f, 0, j+0.5f);
                }
            }
        }
    }

    // Will hide gameobject if not selected or when selection has been made.
    public void HideHighlights()
    {
        foreach (GameObject go in highlights)
            go.SetActive(false);
     }
}