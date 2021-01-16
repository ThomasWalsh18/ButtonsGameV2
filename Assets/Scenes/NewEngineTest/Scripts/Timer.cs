using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 60;
    public int speed = 1;
    public float delayAmount = 1.0f;
    public bool count = true;

    private Slider timer;
    private float time = 0f;
    void Start()
    {
        GameManger.current.timerComplete += CompleteTimer;
        GameManger.current.pausePlayTimerEvent += stopOrStartTimer;

        timer = gameObject.GetComponent<Slider>();
        timer.maxValue = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (count)
        {
            time = Mathf.Lerp(0, 1, Time.deltaTime * (1 * speed));
            if (time + timer.value <= totalTime)
            {
                timer.value = timer.value + time;
                timer.maxValue = totalTime;
            }
            else
            {
                GameManger.current.outOfTime();
                count = false;
            }
        }
    }

    private void stopOrStartTimer(bool action)
    {
        count = action; 
    }
    private void CompleteTimer()
    {
        print("Timer Complete");
    }
}
