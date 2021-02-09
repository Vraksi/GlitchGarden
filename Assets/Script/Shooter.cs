using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform gunPos;

    public void Fire()
    {
        Instantiate(projectile, gunPos.position, transform.rotation);
        return;
    }
}
