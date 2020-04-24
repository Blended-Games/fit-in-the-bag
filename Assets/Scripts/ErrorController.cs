using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorController : MonoBehaviour
{

    public Material standartMat;
    public Material errorMat;
    public GameObject Controller;
    public GameObject visualOject;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material = standartMat;
        Controller = GameObject.FindGameObjectWithTag("GameController");
        visualOject = GameObject.FindGameObjectWithTag("visualObject");
    }

    public void selectedEroorObject()
    {
        Debug.Log("Selected Object Called");
    }

    public void callNormalMaterial()
    {
        gameObject.GetComponent<Renderer>().material = standartMat;
        //if (visualOject != null)
            //visualOject.GetComponent<Renderer>().material.color = Color.white;
    }

    public void callErrorMaterial()
    {
        gameObject.GetComponent<Renderer>().material = errorMat;
        //if (visualOject != null)
            //visualOject.GetComponent<Renderer>().material.color = Color.red;
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SelectedObject" || other.tag == "PlacedObjects" || other.tag == "outsideArea")
        {
            callErrorMaterial();
            Controller.GetComponent<ObjectController>().isPlaceable = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        callNormalMaterial();
        Controller.GetComponent<ObjectController>().isPlaceable = true;
    }

}
