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
    public int bagNumber;

    void Awake()
    {
        SpawnController = GameObject.FindGameObjectWithTag("SpawnController");
        Controller = GameObject.FindGameObjectWithTag("GameController");
        bagNumber = Controller.GetComponent<ObjectController>().bagID;
        for (int i = 0; i < categoryImages.Length; i++)
        {
            backRandom = categoryImages[bagNumber].selectedImage.Length;

            //Debug.Log(random);
        }
        

        //Debug.Log("Image List Count : " +categoryImages.Length);
        //Debug.Log("Random number : " + random);
    }

    public void Update()
    {
      
    }

    private void Start()
    {
        random = Random.Range(0, backRandom);
        Debug.Log(backRandom + " image length first");
        GetComponent<Image>().sprite = categoryImages[SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID].selectedImage[random];
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        GetComponent<Image>().color = new Color32(255, 255, 255, 145);

        foreach (GameObject spriteSlots in GameObject.FindGameObjectsWithTag("SpriteSlots"))
        {
            spriteSlots.GetComponent<SpriteRenderer>().enabled = true;
            spriteSlots.GetComponent<SpriteSlotColorChanger>().isChanged = false;
            spriteSlots.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (!isClicked)
        {  
            SpawnController.GetComponent<UI_NewSpawnerControl>().spawnOneObject();

            var spawned = Instantiate(spawnedObject[ID], new Vector3(0f, 0.5f, -1f), Quaternion.identity);
            spawned.gameObject.GetComponent<ObjectSelector>().ID = ID;
            Controller.GetComponent<ObjectController>().selectedObject = spawned;

            backupObject = spawned;
            backupObject.GetComponent<ObjectSelector>().matchCategory(SpawnController.GetComponent<UI_NewSpawnerControl>().categoryID, random);
        }
    }




    public void OnPointerUp(PointerEventData eventData)
    {
        GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        backupObject.GetComponent<ObjectSelector>().resetPositionFirst();
        GameObject backupButtons = GameObject.FindGameObjectWithTag("backupButtons");
        if (Controller.GetComponent<ObjectController>().isPlaceable)
        {
            if (Controller.GetComponent<ObjectController>().inTheBag)
            {
                //gameObject.SetActiveRecursively(false);
                
                gameObject.transform.SetParent(backupButtons.transform);
                backupObject.GetComponent<ObjectSelector>().selectObjectButton = gameObject;
                //Destroy(gameObject);
            }
        }
        if (!Controller.GetComponent<ObjectController>().isPlaceable)
        {
            gameObject.SetActiveRecursively(true);
        }

        if (!Controller.GetComponent<ObjectController>().inTheBag)
        {

            //gameObject.transform.SetParent(backupButtons.transform);
            Destroy(backupObject);
        }

    }
}
