using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        Animator anim;

        if (otherObject.GetComponent<GraveStone>())
        {
            anim = GetComponent<Animator>();
            anim.SetTrigger("JumpTrigger");
        }        
        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
