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
                for(int i = 0; i < 7; i++)
                {
                    GameManger.current.SpawnButton(0);
                }
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
