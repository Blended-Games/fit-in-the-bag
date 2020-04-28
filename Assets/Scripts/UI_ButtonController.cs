using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_ButtonController : MonoBehaviour,IPointerClickHandler
{
    public Sprite[] spriteImage;
    public GameObject[] spawnedObject;
    private GameObject[] buttons;
    private GameObject Controller;
    private GameObject SpawnController;
    public int ID;
    public bool isClicked;

    float square_shape_dropChance;
    float s_shape_dropChance;
    float sinle_shape_dropChance;
    float t_shape_dropChance;


    void Start()
    {
        
        GetComponent<Image>().sprite = spriteImage[ID];
        Controller = GameObject.FindGameObjectWithTag("GameController");
        SpawnController = GameObject.FindGameObjectWithTag("SpawnController");
        //diffculty(Controller.GetComponent<ObjectController>().difficultyNumber);

        if (Random.Range(0f, 1f) <= square_shape_dropChance)
            ID = 0;
        if (Random.Range(0f, 1f) <= t_shape_dropChance)
            ID = 1;
        if (Random.Range(0f, 1f) <= s_shape_dropChance)
            ID = 2;
        if (Random.Range(0f, 1f) <= sinle_shape_dropChance)
            ID = 3;


        if (ID == 0)
            GetComponent<Image>().sprite = spriteImage[ID];
        if (ID == 1)
            GetComponent<Image>().sprite = spriteImage[ID];
        if (ID == 2)
            GetComponent<Image>().sprite = spriteImage[ID];
        if (ID == 3)
            GetComponent<Image>().sprite = spriteImage[ID];
        
    }

    public void diffculty(int selector)
    {
        if (selector == 1)
        {
            square_shape_dropChance = 1f / 2f; // Drop chance şu sekilde 2 defada 1 kere çıksın gibi....
            s_shape_dropChance = 1f / 4f;
            sinle_shape_dropChance = 1f / 5f;
            t_shape_dropChance = 1f / 3.5f;
        }
        if (selector == 2)
        {
            square_shape_dropChance = 1f / 3f;
            s_shape_dropChance = 1f / 2f;
            sinle_shape_dropChance = 1f / 6f;
            t_shape_dropChance = 1f / 2f;
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {

     

        if (!isClicked)
        {
            SpawnController.GetComponent<UI_SpawnerController>().spawnOneObject();
            if (ID == 0)
                Instantiate(spawnedObject[ID], new Vector3(-0.5f, 0.5f, -0.25f), Quaternion.identity);
            if (ID == 1)
                Instantiate(spawnedObject[ID], new Vector3(0f,0.5f,-0.25f), Quaternion.identity);
            if (ID == 2)
                Instantiate(spawnedObject[ID], new Vector3(-1f, 0.5f, -1f), Quaternion.identity);
            if (ID == 3)
                Instantiate(spawnedObject[ID], new Vector3(0.15f, 0.5f, -1f), Quaternion.identity);

            disableAll();
            isClicked = true;
            Destroy(gameObject);
        }   
    }

    public void disableAll()
    {
        
        buttons = GameObject.FindGameObjectsWithTag("clickableObjects");
        foreach (GameObject clickedbuttons in buttons)
        {
            Debug.Log("Disabled");
            clickedbuttons.GetComponent<Image>().color = new Color32(255, 255, 255, 145);
            clickedbuttons.GetComponent<UI_ButtonController>().isClicked = true;
        }
    }
    
}
