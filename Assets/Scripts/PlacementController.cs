using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementController : MonoBehaviour
{
    public GameObject Controller;
    public bool isPlaceable;

    private void Start()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SelectedObject")
        {           
            Controller.GetComponent<ObjectController>().inTheBag = true;
        }
    }

}
