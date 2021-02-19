using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] float timeToWaitForSound;

    //AudioSource myAudioSource;
    private int attackersInScene = 0;
    private GameTimer gameTimer;



    private void Start()
    {
        winLabel.SetActive(false);
        gameTimer = FindObjectOfType<GameTimer>();
        //myAudioSource = GetComponent<AudioSource>();
    }

    public void AddAttacker()
    {
        attackersInScene++;
    }

    public void RemoveAttacker()
    {
        attackersInScene--;
        IsLevelCompleted();
    }

    private void IsLevelCompleted()
    {
        if (attackersInScene <= 0 && gameTimer.GetIsTimerDone())
        {
            attackersInScene = 1;
            GetComponent<AudioSource>().Play();
            StartCoroutine(HandleWinCondition());          
        }
    }


    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        
        yield return new WaitForSeconds(timeToWaitForSound);
        FindObjectOfType<Level>().LoadNextScene();
    }
   
}
