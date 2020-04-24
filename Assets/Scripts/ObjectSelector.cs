using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectSelector : MonoBehaviour
{
    public Vector3 stockPosition;
    public Vector3 dropPosition;
    public GameObject Controller;
    public GameObject SpawnController;
    private GameObject[] buttons;
    public Vector3 startPos;
    public int ID;
    public bool objectisPlaced;
    public bool firstControl;
    private float dropPoint = 1f;

    private void Awake()
    {
        SpawnController = GameObject.FindGameObjectWithTag("SpawnController");
    }

    private void Start()
    {
        if (ID == 0)
            startPos = new Vector3(0f, 0.5f, -1f);
        if (ID == 1)
            startPos = new Vector3(0f, 0.5f, -2f);
        if (ID == 2)
            startPos = new Vector3(0f, 0.5f, -2f);
        if (ID == 3)
            startPos = new Vector3(-1.35f, 0.5f, -1.55f);
        if (ID == 4)
            startPos = new Vector3(-0.05f, 0.5f, -4.05f);
        if (ID == 5)
            startPos = new Vector3(-1.05f, 0.5f, -1f);
        if (ID == 6)
            startPos = new Vector3(-1.05f, 0.5f, -1f);
        if (ID == 7)
            startPos = new Vector3(-0.5f, 0.5f, -1.55f);
        if (ID == 8)
            startPos = new Vector3(0f, 0.5f, -0.25f);
        if (ID == 9)
            startPos = new Vector3(-0.15f, 0.5f, -2.45f);
        if (ID == 10)
            startPos = new Vector3(-0.55f, 0.5f, -0.85f);
        if (ID == 11)
            startPos = new Vector3(-0.15f, 0.5f, -0.85f);
        if (ID == 12)
            startPos = new Vector3(-0.05f, 0.5f, -0.85f);
        if (ID == 13)
            startPos = new Vector3(-0.15f, 0.5f, -0.85f);


        dropPosition = transform.position;
        Controller = GameObject.FindGameObjectWithTag("GameController");
        
    }

    private void OnMouseDown()
     {
         //Debug.Log("ObjectSelected");
         Controller.GetComponent<ObjectController>().selectedObject = this.gameObject;
         gameObject.layer = 2;
         transform.position = dropPosition;
     }

     private void OnMouseUp()
     {
        gameObject.layer = 0;
        dropPosition = transform.position;
        objectisPlaced = true;
        enabledleAll(true);

        if (Controller.GetComponent<ObjectController>().isPlaceable)
        {
            if (Controller.GetComponent<ObjectController>().inTheBag)
            {
                Controller.GetComponent<ObjectController>().levelPoint += dropPoint / SpawnController.GetComponent<UI_NewSpawnerControl>().spawnCount;

                if (Controller.GetComponent<ObjectController>().bagID == 3)
                {
                    this.transform.position = new Vector3(transform.position.x, 0.35f, transform.position.z);
                }
                else
                {
                    this.transform.position = new Vector3(transform.position.x, 0.05f, transform.position.z);
                }
                
            }
        }
        if (!Controller.GetComponent<ObjectController>().isPlaceable)
        {
            enabledleAll(false);
            objectisPlaced = false;
            transform.position = startPos;
        }
     }

    public void resetPositionFirst()
    {
        gameObject.layer = 0;
        dropPosition = transform.position;
        objectisPlaced = true;
        enabledleAll(true);
        Controller.GetComponent<ObjectController>().visualBagGrid(false);
        if (Controller.GetComponent<ObjectController>().isPlaceable)
        {
            if (Controller.GetComponent<ObjectController>().inTheBag)
            {
                Controller.GetComponent<ObjectController>().levelPoint += dropPoint / SpawnController.GetComponent<UI_NewSpawnerControl>().spawnCount;
                if (Controller.GetComponent<ObjectController>().bagID == 3)
                {
                    this.transform.position = new Vector3(transform.position.x, 0.35f, transform.position.z);
                }
                /*else if (Controller.GetComponent<ObjectController>().bagID == 4)
                {
                    this.transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
                }*/
                else
                {
                    this.transform.position = new Vector3(transform.position.x, 0.05f, transform.position.z);
                }
            }
                
        }
        if (!Controller.GetComponent<ObjectController>().isPlaceable)
        {
            enabledleAll(false);
            objectisPlaced = false;
            transform.position = startPos;
        }
    }



    public void matchCategory(int categoryID,int selectedObject)
    {
        //Debug.Log("Category matched : " + SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID);
        int count = transform.childCount;
        
        for (int i = 0; i < count; i++)
        {
            var child = transform.GetChild(i);
            this.transform.GetChild(categoryID);
            child.gameObject.SetActiveRecursively(false);
            transform.GetChild(count - 1).gameObject.SetActive(true);
            transform.GetChild(categoryID).gameObject.SetActive(true);
            transform.GetChild(categoryID).transform.GetChild(selectedObject).gameObject.SetActive(true);
            
        }
    }

    public void enabledleAll(bool checker)
    {
        buttons = GameObject.FindGameObjectsWithTag("clickableObjects");
        if (checker)
        {
            foreach (GameObject clickedbuttons in buttons)
            {
                clickedbuttons.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                clickedbuttons.GetComponent<UI_NewButtonController>().isClicked = false;
            }
        }
        else
        {
            foreach (GameObject clickedbuttons in buttons)
            {
                clickedbuttons.GetComponent<Image>().color = new Color32(255, 255, 255, 145);
                clickedbuttons.GetComponent<UI_NewButtonController>().isClicked = true;
            }
        }
    }
}


