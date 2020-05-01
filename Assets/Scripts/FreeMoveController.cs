using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMoveController : MonoBehaviour
{

    public GameObject Controller;
    public bool isPlaceable;

    private void Start()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SelectedObject")
        {
            Controller.GetComponent<ObjectController>().inTheBag = false;
            //Debug.Log("FreeMove");
        }
    }
}
