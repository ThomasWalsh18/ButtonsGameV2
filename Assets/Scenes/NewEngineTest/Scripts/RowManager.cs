using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowManager : MonoBehaviour
{
    public List<GameObject> Rows;
    public GameObject rowPrefab;
    public GameObject buttonPrefab;
    public GameObject longButtonPrefab;

    private GameObject Storage;

    private void Start()
    {
        GameManger.current.revealNextRowEvent += revealRow;
        GameManger.current.hideAllRowsEvent += hideRows;
        GameManger.current.SpawnRowEvent += spawnRows;
        GameManger.current.SpawnButtonEvent += spawnButtons;
        GameManger.current.fillRowEvent += fillRow;
        Storage = GameObject.FindGameObjectWithTag("Storage");

        //Rows = GameObject.FindGameObjectsWithTag("Row");
        for(int i = 1; i < Rows.Count; i++)
        {
            Rows[i].SetActive(false);
        }
    }
    private void revealRow(int rowNumb)
    {
        if(rowNumb != Rows.Count)
        {
            Rows[rowNumb].SetActive(true);
        }
        else
        {
            GameManger.current.pauseOrPlayTimer(false);
        }
    }
    private void hideRows()
    {
        for (int i = 1; i < Rows.Count; i++)
        {
            Rows[i].SetActive(false);
        }
    }
    private void spawnRows()
    {
        //instanciate a row as a child of the Storage 
        GameObject temp = Instantiate(rowPrefab, Storage.transform);
        Rows.Add(temp);
        temp.GetComponentInChildren<RowHolder>().rowNumber = Rows.Count;
        if (Rows.Count == 1)
        {
            //if its the first row spawn a long button
            GameManger.current.SpawnButton(1);
        }
    } 

    private void fillRow(int ammount, int correct)
    {
        for(int i= 0; i < ammount; i++)
        {
            GameManger.current.SpawnButton(0);
        }
        int correctAmmount = 0;
        //sanity checks
        if (ammount < 3)
        {
            correct = 1;
        }
        //Chose two buttons to be correct from the array of buttons
        ButtonBehaviour[] buttons = Rows[Rows.Count - 1].GetComponentsInChildren<ButtonBehaviour>();

        while (correctAmmount != correct)
        {
            int randButton = Random.Range(0, ammount-1);
            buttons[randButton].correct = true;
            correctAmmount++;
        }
    }
    private void spawnButtons(int id)
    {
        //if its the first row spawn a start button
        //Spawn from the last one

        if(id == 0)
        {
            //spawn normal button
            Instantiate(buttonPrefab, Rows[Rows.Count-1].transform.GetChild(0).transform);
        } else
        {
            //Spawn long button
            Instantiate(longButtonPrefab, Rows[Rows.Count - 1].transform.GetChild(0).transform);
        }
    }

}
