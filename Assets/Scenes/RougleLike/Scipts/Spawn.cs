using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float currDiff = 1;

    void Start()
    {
        //spawn buttons based on current difficulty 
        //Spawn a row and then if its  the first row add a int 1 to the call
        float tempDiff = 0;
        bool firstrun = true;
        while(tempDiff < currDiff)
        {
            //Spawn a row
            GameManger.current.SpawnRow();
            //Fill a row with buttons if its not the first row
            if (!firstrun)
            {
                //random ammount of buttons varying from 1 to 10, below 5 needs to be more rare
                int ammountChose= Random.Range(1, 100);
                int ammount = 5; // default 
                if (ammountChose <= 5)
                {
                    ammount = 1;
                }
                else if (ammountChose <= 10)
                {
                    ammount = 2;
                }
                else if (ammountChose <= 15)
                {
                    ammount = 3;
                }
                else if (ammountChose <= 20)
                {
                    ammount = 4;
                }
                else if (ammountChose <= 40)
                {
                    ammount = 5;
                }
                else if (ammountChose <= 60)
                {
                    ammount = 6;
                }
                else if (ammountChose <= 75)
                {
                    ammount = 7;
                }
                else if (ammountChose <= 85)
                {
                    ammount = 8;
                }
                else if (ammountChose <= 95)
                {
                    ammount = 9;
                }
                else if (ammountChose <= 100)
                {
                    ammount = 10;
                }
                //how many buttons are correct
                int correct = Random.Range(1, 3);
                print(correct);
                GameManger.current.fillTheRow(ammount, correct);
                //Chose a button to be correct

            }else
            {
                firstrun = !firstrun;
            }
            
            //Calc the diff for the curr row add it to temp diff
            tempDiff++;
        }
        GameManger.current.hideAllRows();
    }
}
