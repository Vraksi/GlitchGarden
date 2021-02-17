using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseKillzone : MonoBehaviour
{
    [SerializeField] float damageDoneToBase = 50f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<LevelHealth>().SpendHealth(damageDoneToBase);
        }   
    }
}
