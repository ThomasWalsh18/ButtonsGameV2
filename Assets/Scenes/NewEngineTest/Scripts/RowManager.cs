using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowManager : MonoBehaviour
{
    public GameObject[] Rows;
    private void Start()
    {
        GameManger.current.revealNextRowEvent += revealRow;
        GameManger.current.hideAllRowsEvent += hideRows;

        Rows = GameObject.FindGameObjectsWithTag("Row");
        for(int i = 1; i < Rows.Length; i++)
        {
            Rows[i].SetActive(false);
        }
    }
    private void revealRow(int rowNumb)
    {
        if(rowNumb != Rows.Length)
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
        for (int i = 1; i < Rows.Length; i++)
        {
            Rows[i].SetActive(false);
        }
    }

}
