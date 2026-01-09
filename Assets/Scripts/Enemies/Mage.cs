using System;
using System.Collections;
using UnityEngine;

public class Mage : MonoBehaviour, IDahable
{
    public GameObject Target { get; set; }
    public GameObject fireBall;
    public Transform spawnPosition;
    
    public bool shooting = false;

    private void Update()
    {
        if (Target != null)
        {
            Vector3 dirToTarget = Target.transform.position - transform.position;
            dirToTarget.y = 0;
            transform.right = dirToTarget; //transform.right el eje rojo se alinea con el target
            if (!shooting)
            {
                StopAllCoroutines();
            }
        }
    }

    private IEnumerator SpawnFireBall()
    {
        Instantiate(fireBall, spawnPosition.position, spawnPosition.rotation);
        yield return new WaitForSeconds(1);
    }

    public void TakeDamage(GameObject o, float damage)
    {
        
    }
}
