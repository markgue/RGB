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

        // Old color 
        GameObject[] prevOffColors = GameObject.FindGameObjectsWithTag(currentDisabledTag);
        foreach (GameObject prevOffColor in prevOffColors)
        {
            BoxCollider2D collider = prevOffColor.GetComponent<BoxCollider2D>();
            collider.enabled = true;
            SpriteRenderer sp = prevOffColor.GetComponent<SpriteRenderer>();
            sp.enabled = true;
        }

        // New color
        GameObject[] taggedColors = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject taggedColor in taggedColors)
        {
            BoxCollider2D collider = taggedColor.GetComponent<BoxCollider2D>();
            collider.enabled = false;
            SpriteRenderer sp = taggedColor.GetComponent<SpriteRenderer>();
            sp.enabled = false;
        }

        // Terrain color change
        SpriteRenderer[] terrainColors = (SpriteRenderer[])GameObject.FindObjectsOfType(typeof(SpriteRenderer));
        foreach (SpriteRenderer sp in terrainColors)
        {
            sp.color = col;
        }

        // Mesh color change
        MeshRenderer[] terrainMeshColors = (MeshRenderer[])GameObject.FindObjectsOfType(typeof(MeshRenderer));
        foreach (MeshRenderer mesh in terrainMeshColors)
        {
            mesh.material.color = col;
        }
        // Change the current disabled color
        currentDisabledTag = tag;
    }

}
