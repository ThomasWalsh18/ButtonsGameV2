using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManger : MonoBehaviour
{
    /// <summary>
    /// Use an event system so that I can manage all the events easy 
    /// such as pressing the  wrong button, trigger wrong event which hides all rows par the start
    /// and pressing the right button will look at the row number and reveal the next row
    /// And lose game hide all and reveal replay button, then its really easy to add different kind of events
    /// </summary>
    public static GameManger current;
    private void Awake()
    {
        current = this;
    }

    public event Action timerComplete;
    public void outOfTime()
    {
        if (timerComplete != null)
        {
            timerComplete();
        }
    }

}
