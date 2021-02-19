using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawn = true;
    [SerializeField] float minTimeBetweenSpawns = 1f;
    [SerializeField] float maxTimeBetweenSpawns = 5f;
    [SerializeField] Attacker[] attackerPrefab;

 

    IEnumerator Start()
    {
        while(spawn)
        {           
            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));
            if (spawn)
            {
                SpawnAttacker();
            }           
        }
    }

    public void SetSpawn(bool spawning)
    {
        spawn = spawning;
    }

    private void SpawnAttacker()
    {
        int i = Random.Range(0, attackerPrefab.Length);
        Spawn(attackerPrefab[i]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate
           (attacker, transform.position, transform.rotation)
           as Attacker;
        newAttacker.transform.parent = transform;
    }
}
