using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] float damageProjectile = 10f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

    public float getDamageProjectile()
    {
        return damageProjectile;
    }
}
