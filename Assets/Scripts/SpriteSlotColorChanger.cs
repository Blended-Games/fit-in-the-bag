using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSlotColorChanger : MonoBehaviour
{
    public bool isChanged;
    
    void Update()
    {
        if(isChanged)
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
            
    }
}
