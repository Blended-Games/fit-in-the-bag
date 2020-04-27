using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySlotController : MonoBehaviour
{
    public LayerMask layers;
    private GameObject backupObject;



    void Update()
    {   
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);

                if(hit.transform.tag == "SpriteSlots")
                {
                    /*Debug.Log("Did Hit : " + hit.transform.gameObject.name);
                    Debug.Log("Hit Position : " + hit.transform.position.y);*/
                    this.gameObject.transform.position = new Vector3(transform.position.x, hit.transform.position.y, transform.position.z);   
                }    
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 1000f, Color.white);
                //Debug.Log("Did not Hit");
            }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag== "SpriteSlots")
        {
            //Debug.Log("other name" + other.transform.name);
            other.GetComponent<SpriteSlotColorChanger>().isChanged = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "SpriteSlots")
        {
            other.GetComponent<SpriteSlotColorChanger>().isChanged = false;
        }
    }
}
