using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    float currentSpeed = 1f;
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float deathVFXDuration = 1f;

    GameObject currentTarget;
    Animator anim;

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimState();
    }

    private void UpdateAnimState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if(!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (!bullet) { return; }
        if (collision.tag == "Bullet")
        {
            DealDamage(bullet);            
        }
    }

    private void DealDamage(Bullet bullet)
    {
        health -= bullet.getDamageProjectile();
        bullet.Hit();
        if ( health <= 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject deathExplosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathExplosion, deathVFXDuration);
    }
}
