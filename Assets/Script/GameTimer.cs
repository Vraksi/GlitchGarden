using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level time in Seconds")]
    [SerializeField] float levelTime = 10;
    private bool isTimerDone = false;

    private void Update()
    {
        if (isTimerDone) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);        
        StopSpawning(timerFinished);
    }

    private void StopSpawning(bool timerFinished)
    {
        if (timerFinished)
        {
            AttackerSpawner[] spawnersArray = FindObjectsOfType<AttackerSpawner>();
            foreach (AttackerSpawner spawner in spawnersArray)
            {
                spawner.SetSpawn(false);
                isTimerDone = true;
            }
        }
    }

    public bool GetIsTimerDone()
    {
        return isTimerDone;
    }
}
