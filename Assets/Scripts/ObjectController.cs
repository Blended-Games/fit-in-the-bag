using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ObjectController : MonoBehaviour
{
    public bool isMoveable;
    public bool inTheBag;
    public float rayLenght;
    public LayerMask layerMask;
    public GameObject selectedObject;
    public GameObject freeMoveFloor;
    public bool isPlaceable;
    public float levelPoint;
    public Image levelProgressBar;
    private GameObject SpawnController;
    public int bagID;
    public GameObject[] bags;
    public GameObject nextLevelButton;
    public GameObject closeBagButton;

    public bool levelComplete;
    
    private void Awake()
    {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
       
        DontDestroyOnLoad(this.gameObject);
        levelProgressBar.rectTransform.localScale = new Vector2(levelPoint, 1f);
        visualBagGrid(false);
        SpawnController = GameObject.FindGameObjectWithTag("SpawnController");
        SpawnController.GetComponent<UI_NewSpawnerControl>().LevelNumber = bagID;
        closeBagButton.SetActive(false);

        for (int i = 0; i < bags.Length; i++)
        {
            bags[i].SetActive(false);
            bags[bagID].SetActive(true);
        }
    }

    public void visualBagGrid(bool enable)
    {
        if (enable)
        {
            foreach (GameObject bagSlotsPlaceable in GameObject.FindGameObjectsWithTag("PlaceableSlots"))
            {
                bagSlotsPlaceable.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else
        {
            foreach (GameObject bagSlotsPlaceable in GameObject.FindGameObjectsWithTag("PlaceableSlots"))
            {
                bagSlotsPlaceable.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    private void Update()
    {
        if (levelPoint >= 1f)
        {
            if (!levelComplete)
            {
                levelPoint = 1f;
                StartCoroutine(showNextLevelBTN());
                GameObject.FindGameObjectWithTag("BagCap").GetComponent<Animator>().SetTrigger("closeBag");
                levelComplete = true;
            }   
        }  
        else if (levelPoint < 0f)
        {
            levelPoint = 0f;      
        }
        else if (levelPoint > 0.6f)
        {
            closeBagButton.SetActive(true);
            Debug.Log("ClosebagBTN Active");
         
        }
        else
        {
            closeBagButton.SetActive(false);
            nextLevelButton.SetActive(false);
        }
        SpawnController.GetComponent<UI_NewSpawnerControl>().LevelNumber = bagID;
        levelProgressBar.rectTransform.localScale = new Vector2(levelPoint, 1f);

        if (Input.GetMouseButtonDown(0))
        {
            if (!selectedObject)
            {
                //Debug.LogWarning("Object is not selected!");
            }
            else
            {
                isMoveable = true;
            }      
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoveable = false;
            selectedObject = null;
            inTheBag = false;
            freeMoveFloor.layer = 8;
            visualBagGrid(false);
        }
        if (isMoveable)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLenght, layerMask))
            {
                if (!inTheBag)
                {
                    selectedObject.transform.position = new Vector3(hit.point.x, 1.5f, hit.point.z);
                    visualBagGrid(false);
                }
                
                if (inTheBag)
                {
                    visualBagGrid(true);
                    Vector3 temp = new Vector3(hit.transform.position.x, 1.5f, hit.transform.position.z);
                    selectedObject.transform.position = temp;
                    freeMoveFloor.layer = 0;

                }        
            }
        }
    }

 
    public void LoadLevel(int number)
    {
        StartCoroutine(callLevel(number));
    }
    public void callRestartCurrentLevel()
    {
        StartCoroutine(restartCurrentlLevel());
    }

    public void callRestartGame()
    {
        StartCoroutine(restartGame());
    }

    public void callCloseBag()
    {
        for (int i = 0; i < bags.Length; i++)
        {
            bags[bagID].transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("closeBag");
        }
        StartCoroutine(showNextLevelBTN());
    }


    public IEnumerator showNextLevelBTN()
    {
        yield return new WaitForSeconds(1f);
        nextLevelButton.SetActive(true);
    }

    public IEnumerator callLevel(int number)
    {
        
        levelComplete = false;
        levelPoint = 0f;
        bagID++;
        closeBagButton.SetActive(false);
        foreach (GameObject placedAfter in GameObject.FindGameObjectsWithTag("PlacedAfter"))
        {
            Destroy(placedAfter);
        }
        for (int i = 0; i < bags.Length; i++)
        {
            bags[i].SetActive(false);
            bags[bagID].SetActive(true);
        }
        
        SpawnController.GetComponent<UI_NewSpawnerControl>().destroyAll();

        yield return new WaitForSeconds(0.00001f);
        SceneManager.LoadScene(number);
        SpawnController.GetComponent<UI_NewSpawnerControl>().callBagItems();
        inTheBag = false;
        if (bagID == 4)
        {
            Camera.main.fieldOfView = 75;
        }

    }


    public IEnumerator restartCurrentlLevel()
    {

        levelComplete = false;
        levelPoint = 0f;
        closeBagButton.SetActive(false);
        foreach (GameObject placedAfter in GameObject.FindGameObjectsWithTag("PlacedAfter"))
        {
            Destroy(placedAfter);
        }
        for (int i = 0; i < bags.Length; i++)
        {
            bags[i].SetActive(false);
            bags[bagID].SetActive(true);
        }

        SpawnController.GetComponent<UI_NewSpawnerControl>().destroyAll();
        yield return new WaitForSeconds(0.00001f);
        SceneManager.LoadScene(0);
        SpawnController.GetComponent<UI_NewSpawnerControl>().callBagItems();
        inTheBag = false;
        if (bagID == 4)
        {
            Camera.main.fieldOfView = 75;
        }

    }


    public IEnumerator restartGame()
    {
        levelComplete = false;
        levelPoint = 0f;
        bagID = 0;
        Camera.main.fieldOfView = 65;
        closeBagButton.SetActive(false);
        foreach (GameObject placedAfter in GameObject.FindGameObjectsWithTag("PlacedAfter"))
        {
            Destroy(placedAfter);
        }
        for (int i = 0; i < bags.Length; i++)
        {
            bags[i].SetActive(false);
            bags[bagID].SetActive(true);
        }

        SpawnController.GetComponent<UI_NewSpawnerControl>().destroyAll();
        yield return new WaitForSeconds(0.00001f);
        SceneManager.LoadScene(bagID);
        SpawnController.GetComponent<UI_NewSpawnerControl>().callBagItems();
        inTheBag = false;

    }


}





