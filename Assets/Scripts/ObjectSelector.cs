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
    public GameObject[] visualHolders;
    public Vector3 visualsDropPositions;
    public Vector3 startPos;
    public int ID;
    public bool objectisPlaced;
    public bool firstControl;
    private float dropPoint = 1f;
    private bool selectedObjectInTheBag;
    public GameObject selectObjectButton;
    private static float backupPoints;

    private void Awake()
    {
        SpawnController = GameObject.FindGameObjectWithTag("SpawnController");
    }

    private void Start()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController");
        backupPoints = dropPoint / SpawnController.GetComponent<UI_NewSpawnerControl>().spawnCount;
        Debug.Log(backupPoints);
    }

    private void OnMouseDown()
    {

        if (selectedObjectInTheBag)
        {
            Debug.Log("isInTheBag");
            selectObjectButton.transform.SetParent(SpawnController.transform);

            Controller.GetComponent<ObjectController>().levelPoint -= backupPoints;
           
            Debug.Log(backupPoints);
            selectedObjectInTheBag = false;
            Destroy(gameObject);
        }
        else
        {
            Controller.GetComponent<ObjectController>().selectedObject = this.gameObject;
            gameObject.layer = 2;
            transform.position = dropPosition;
        }


    }

     private void OnMouseUp()
     {

        if (Controller.GetComponent<ObjectController>().isPlaceable)
        {
            if (Controller.GetComponent<ObjectController>().inTheBag)
            {
                Controller.GetComponent<ObjectController>().levelPoint += dropPoint / SpawnController.GetComponent<UI_NewSpawnerControl>().spawnCount;
                
                gameObject.layer = 0;
                objectisPlaced = true;
                selectedObjectInTheBag = true;

                for (int i = 0; i < visualHolders.Length; i++)
                {
                    visualHolders[i].gameObject.transform.localPosition = visualsDropPositions;
                    Debug.Log(visualsDropPositions);
                }

                if (Controller.GetComponent<ObjectController>().bagID == 3)
                {
                    this.transform.position = new Vector3(transform.position.x, 0.35f, transform.position.z);
                    //this.gameObject.GetComponent<BoxCollider>().enabled = false;

                }
                else
                {
                    this.transform.position = new Vector3(transform.position.x, 0.05f, transform.position.z);
                    //this.gameObject.GetComponent<BoxCollider>().enabled = false;

                }

            }
        }
        if (!Controller.GetComponent<ObjectController>().isPlaceable)
        {
            objectisPlaced = false;
            Destroy(gameObject);
        }
     }

    public void resetPositionFirst()
    {
        Controller.GetComponent<ObjectController>().visualBagGrid(false);
        if (Controller.GetComponent<ObjectController>().isPlaceable)
        {
            if (Controller.GetComponent<ObjectController>().inTheBag)
            {
                gameObject.layer = 0;
                Controller.GetComponent<ObjectController>().levelPoint += dropPoint / SpawnController.GetComponent<UI_NewSpawnerControl>().spawnCount;

                selectedObjectInTheBag = true;

                for (int i = 0; i < visualHolders.Length; i++)
                {
                    visualHolders[i].gameObject.transform.localPosition = visualsDropPositions;
                }

                if (Controller.GetComponent<ObjectController>().bagID == 3)
                {
                    this.transform.position = new Vector3(transform.position.x, 0.35f, transform.position.z);
                    //this.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
                else
                {
                    this.transform.position = new Vector3(transform.position.x, 0.05f, transform.position.z);
                    //this.gameObject.GetComponent<BoxCollider>().enabled = false;
                }
            }
                
        }
        if (!Controller.GetComponent<ObjectController>().isPlaceable)
        {
            objectisPlaced = false;
            Destroy(gameObject);
        }
    }



    public void matchCategory(int categoryID,int selectedObject)
    {
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
}


