using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSlotColorChanger : MonoBehaviour
{
    public bool isChanged;

    GameObject Controller;
    private void Start()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        if(isChanged)
            if(Controller.GetComponent<ObjectController>().isPlaceable)
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            else
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
            
    }
}
