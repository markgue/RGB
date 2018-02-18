using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    // cheaty global variables :)))
    private string currentDisabledTag = "White";

    Camera cam;
    
    Color Red = Color.red;
    Color Green = Color.green;
    Color Blue = Color.blue;
    Color White = Color.white;

    // Use this for initialization
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        SetColor(White, "White");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SetColor(Red, "Red");

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SetColor(Green, "Green");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SetColor(Blue, "Blue");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SetColor(White, "White");
        }

    }

    public void SetColor(Color col, string tag)
    {
        cam.backgroundColor = col;
        GameObject[] prevOffColors = GameObject.FindGameObjectsWithTag(currentDisabledTag);
        GameObject[] taggedColors = GameObject.FindGameObjectsWithTag(tag);
        GameObject[] terrainColors = GameObject.FindGameObjectsWithTag("Terrain");
        // Old colliders
        foreach (GameObject prevOffColor in prevOffColors)
        {
            BoxCollider2D collider = prevOffColor.GetComponent<BoxCollider2D>();
            collider.enabled = true;
            SpriteRenderer sp = prevOffColor.GetComponent<SpriteRenderer>();
            sp.enabled = true;
        }
        // New colliders
        foreach (GameObject taggedColor in taggedColors)
        {
            BoxCollider2D collider = taggedColor.GetComponent<BoxCollider2D>();
            collider.enabled = false;
            SpriteRenderer sp = taggedColor.GetComponent<SpriteRenderer>();
            sp.enabled = false;
        }
        // Terrain color change
        foreach (GameObject terrain in terrainColors)
        {
            SpriteRenderer sp = terrain.GetComponent<SpriteRenderer>();
            sp.color = col;
        }

        currentDisabledTag = tag;
    }

}
