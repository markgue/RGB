using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour {

    public Color col;
    public string coltag;
    public GameObject colorManager; 
    ColorManager cm;
    

	// Use this for initialization
	void Start () {
        cm = colorManager.GetComponent<ColorManager>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Rock")
        {
            cm.SetColor(col, coltag);
        }

    }
}
