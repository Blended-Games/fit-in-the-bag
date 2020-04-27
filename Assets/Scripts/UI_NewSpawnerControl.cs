using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class UI_NewSpawnerControl : MonoBehaviour
{

    private int SelectedRandomNumber;
    public int spawnCount;
    private int increase = 3;
    public bool oneByeOne;
    public int LevelNumber;
    public int difficulty;
    // Category ID
    public int categoryID;
    // level List
    public LevelList[] levelList;


    private void Start()
    {
        callBagItems();
    }

    
    public void callBagItems()
    {
        //Debug level Start
        int RandomLevel;
        //RandomLevel = Random.Range(0, 3);
        //difficulty = RandomLevel;

        if (difficulty == 0)
            spawnCount = levelList[LevelNumber].easy.Length;
        if (difficulty == 1)
            spawnCount = levelList[LevelNumber].medium.Length;
        if (difficulty == 2)
            spawnCount = levelList[LevelNumber].hard.Length;

        for (int i = 0; i < spawnCount; ++i)
        {
            if (difficulty == 0)
            {
                var spawns = Instantiate(levelList[LevelNumber].easy[i], transform);
                int randomName = Random.Range(0, 10);
                spawns.gameObject.name = randomName.ToString() + "_Object";
            }
            if (difficulty == 1)
            {
                var spawns = Instantiate(levelList[LevelNumber].medium[i], transform);
                int randomName = Random.Range(0, 10);
                spawns.gameObject.name = randomName.ToString() + "_Object";
            }
            if (difficulty == 2)
            {
                var spawns = Instantiate(levelList[LevelNumber].hard[i], transform);
                int randomName = Random.Range(0, 10);
                spawns.gameObject.name = randomName.ToString() + "_Object";
            }
        }

        GameObject[] count = GameObject.FindGameObjectsWithTag("clickableObjects");
        GameObject[] countOrdered = count.OrderBy(go => go.name).ToArray();
        for (int i = 0; i < countOrdered.Length; i++)
        {
            countOrdered[i].transform.SetSiblingIndex(i);
        }
        //hideOthers(false, false);
    }


    public void destroyAll()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        //callBagItems();

    }

    public void spawnOneObject()
    {
        if (oneByeOne)
        {
            // one bye one
            hideOthers(true, false);
        }
        else
        {
            // tree bye tree
            hideOthers(true, true);
        }
    }
    public void hideOthers(bool oneByOne , bool treeBytree)
    {
        //Debug.Log(increase);
        int children = transform.childCount;
        int childerenCount = transform.childCount;
        // one by one control
        if (!treeBytree)
        {
            if (!oneByOne)
            {
                for (int i = 3; i < children; ++i)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            if (oneByOne)
            {
                for (int i = 0; i < children; ++i)
                {
                    if (children > 3)
                        transform.GetChild(children - children + 3).gameObject.SetActive(true);
                    else
                        Debug.Log("Done");
                }
            }
        }
        // tree by tree control
        if (treeBytree)
        {
            if (!oneByOne)
            {
                for (int i = 3; i < children; ++i)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            if (oneByOne)
            {
                increase++;
                if(increase > 5)
                {
                    for (int i = 4; i < children; ++i)
                    {
                        if (increase > 5)
                        {
                            transform.GetChild(i).gameObject.SetActive(true);
                        }
                        else
                            Debug.Log("Done");
                    }
                }
                if (increase >= 6)
                {
                    for (int i = 0; i < children; ++i)
                    {
                            transform.GetChild(i).gameObject.SetActive(true);   
                    }
                }
            }
        }
    }
}
