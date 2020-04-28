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
        if (Controller.GetComponent<ObjectController>().isPlaceable)
        {
            if (Controller.GetComponent<ObjectController>().inTheBag)
            {
                //gameObject.SetActiveRecursively(false);
                Destroy(gameObject);
            }
        }
        if (!Controller.GetComponent<ObjectController>().isPlaceable)
        {
            gameObject.SetActiveRecursively(true);
        }

        if (!Controller.GetComponent<ObjectController>().inTheBag)
        {
           
            Destroy(backupObject);
        }

    }
}
