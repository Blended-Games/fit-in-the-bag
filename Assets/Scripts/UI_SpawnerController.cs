using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UI_SpawnerController : MonoBehaviour
{
    public GameObject spawnedUIObject;
    private GameObject[] buttons;
    public int spawnCount;
    
    
    void Start()
    {
        for (int i = 0; i < spawnCount; ++i)
        {
            var spawns = Instantiate(spawnedUIObject, transform);
        }
        StartCoroutine(setIDShorting());
    }

    public void spawnOneObject()
    {
        var spawns = Instantiate(spawnedUIObject, transform);
        spawns.GetComponent<Animator>().SetTrigger("anim");
    }

    IEnumerator setIDShorting()
    {
        yield return new WaitForSeconds(0.01f);
        buttons = GameObject.FindGameObjectsWithTag("clickableObjects");
        foreach (GameObject clickedbuttons in buttons)
        {
            if (clickedbuttons.GetComponent<UI_ButtonController>().ID == 0)
                clickedbuttons.name = "ID_0";
            if (clickedbuttons.GetComponent<UI_ButtonController>().ID == 1)
                clickedbuttons.name = "ID_1";
            if (clickedbuttons.GetComponent<UI_ButtonController>().ID == 2)
                clickedbuttons.name = "ID_2";
            if (clickedbuttons.GetComponent<UI_ButtonController>().ID == 3)
                clickedbuttons.name = "ID_3";
        }

        GameObject[] count = GameObject.FindGameObjectsWithTag("clickableObjects");
        GameObject[] countOrdered = count.OrderBy(go => go.name).ToArray();
        for (int i = 0; i < countOrdered.Length; i++)
        {
            countOrdered[i].transform.SetSiblingIndex(i);
        }

    }
}


