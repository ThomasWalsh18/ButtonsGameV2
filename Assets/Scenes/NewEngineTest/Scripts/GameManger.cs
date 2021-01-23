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

    //Timer Events
    public event Action timerComplete;
    public event Action<bool> pausePlayTimerEvent;
    public void outOfTime()
    {
        if (timerComplete != null)
        {
            timerComplete();
        }
    }
    public void pauseOrPlayTimer(bool play)
    {
        if (pausePlayTimerEvent != null)
        {
            pausePlayTimerEvent(play);
        }
    }


    //Row Events
    public event Action<int> revealNextRowEvent;
    public event Action hideAllRowsEvent;

    public void nextRow(int id)
    {
        if (revealNextRowEvent != null)
        {
            revealNextRowEvent(id);
        }
    }
    public void hideAllRows()
    {
        if (hideAllRowsEvent != null)
        {
            hideAllRowsEvent();
        }
    }

    //Spawn Events
    public event Action<int> SpawnButtonEvent;
    public event Action SpawnRowEvent;
    public event Action<int, int> fillRowEvent;

    public void fillTheRow(int ammount, int correct)
    {
        if (fillRowEvent != null)
        {
            fillRowEvent(ammount, correct);
        }
    }
    public void SpawnButton(int id)
    {
        if (SpawnButtonEvent != null)
        {
            SpawnButtonEvent(id);
        }
    }
    public void SpawnRow()
    {
        if (SpawnRowEvent != null)
        {
            SpawnRowEvent();
        }
    }
}


