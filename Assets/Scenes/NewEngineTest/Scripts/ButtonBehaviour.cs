using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public bool correct = false;
    int rowNumb;
    void Start()
    {
        GameManger.current.revealNextRowEvent += revealRow;
        GameManger.current.hideAllRowsEvent += hideRows;
        rowNumb = gameObject.GetComponentInParent<RowHolder>().rowNumber;
    }

    public void buttonPress()
    {
        if (correct)
        {
            GameManger.current.nextRow(rowNumb);
        } else
        {
            GameManger.current.hideAllRows();
        }
    }

    private void revealRow(int rowNumb)
    {
        print("Reveal Next Row" + rowNumb);
    }
    private void hideRows()
    {
        print("Hide All Rows");
    }
}
