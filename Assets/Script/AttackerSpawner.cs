using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawn = true;
    [SerializeField] float minTimeBetweenSpawns = 1f;
    [SerializeField] float maxTimeBetweenSpawns = 5f;
    [SerializeField] GameObject attackerPrefab;

    // Start is called before the first frame update


    IEnumerator Start()
    {
        while(spawn)
        {
            
            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        
        var attacker = Instantiate(attackerPrefab, transform.position, transform.rotation);
        attacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
