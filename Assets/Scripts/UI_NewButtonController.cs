using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_NewButtonController : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{

    public GameObject[] spawnedObject;
    private GameObject[] buttons;
    private GameObject Controller;
    private GameObject SpawnController;
    private GameObject backupObject;
    private bool firstClick;
    public bool isClicked;
    // Placement ID
    public int ID;
    // Category item image
    public CategoryImageList[]categoryImages;
    private int random;
    private int backRandom;

    void Awake()
    {
        SpawnController = GameObject.FindGameObjectWithTag("SpawnController");
        Controller = GameObject.FindGameObjectWithTag("GameController");

        for (int i = 0; i < categoryImages.Length; i++)
        { 
            backRandom = categoryImages[i].selectedImage.Length;
            //Debug.Log(random);
        }

        random = Random.Range(0, backRandom);
        //Debug.Log("Image List Count : " +categoryImages.Length);
        //Debug.Log("Random number : " + random);
    }

    private void Start()
    {
        GetComponent<Image>().sprite = categoryImages[SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID].selectedImage[random];
    }

    public void disableAll()
    {
        buttons = GameObject.FindGameObjectsWithTag("clickableObjects");
        foreach (GameObject clickedbuttons in buttons)
        {
            //Debug.Log("Disabled");
            clickedbuttons.GetComponent<Image>().color = new Color32(255, 255, 255, 145);
            clickedbuttons.GetComponent<UI_NewButtonController>().isClicked = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isClicked)
        {
            SpawnController.GetComponent<UI_NewSpawnerControl>().spawnOneObject();
            if (ID == 0)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(0f, 0.5f, -1f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;
                
                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);
            }

            if (ID == 1)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(0f, 0.5f, -0.25f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;
                
                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);

            }

            if (ID == 2)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(-1f, 0.5f, -1f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;
                
                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);
            }

            if (ID == 3)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(0.15f, 0.5f, -1f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;
                
                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);
            }

            if (ID == 4)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(-1.55f, 0.5f, -1f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;
                
                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID,random);
            }

            if (ID == 5)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(-1.05f, 0.5f, -1f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;
                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);

            }

            if (ID == 6)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(-1.05f, 0.5f, -1f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;

                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);

            }

            if (ID == 7)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(-0.5f, 0.5f, -1.55f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;

                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);
            }

            if (ID == 8)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(0f, 0.5f, -1.55f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;

                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);
            }

            if (ID == 9)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(-0.15f, 0.5f, -2.45f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;

                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);
            }

            if (ID == 10)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(-0.15f, 0.5f, -0.85f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;

                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);
            }

            if (ID == 11)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(-0.15f, 0.5f, -0.85f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;

                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);
            }

            if (ID == 12)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(-0.15f, 0.5f, -0.85f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;

                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);
            }


            if (ID == 13)
            {
                var spawned = Instantiate(spawnedObject[ID], new Vector3(-0.15f, 0.5f, -0.85f), Quaternion.identity);
                spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
                Controller.GetComponent<ObjectController>().selectedObject = spawned;

                backupObject = spawned;
                backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);
            }

            isClicked = true;
            disableAll();
        }
    }




    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("pointerup");
        if (!firstClick)
        {
            firstClick = true;
            backupObject.GetComponent<ObjectSelector>().resetPositionFirst();
            Destroy(gameObject);
        }
        
    }
}
