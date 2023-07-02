using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMouseCanon : MonoBehaviour
{
 
    [SerializeField] private float GrenadeRadius = 5000f;
    [SerializeField] private float  ExplosionForce = 7000f;
    [SerializeField] private float  DamageRate = 60f;
    [SerializeField] private GameObject explosion;
    [SerializeField] private ZombieManager zc;
    private List<GameObject> explodedZombies = new List<GameObject>();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Explode();
        }
    }


    public void Explode()
    {
        explodedZombies.Clear();
        Instantiate(explosion, transform.position, new Quaternion()).GetComponent<ExplosionPref>().SetSize(GrenadeRadius);
        Collider[] touchedObjects = Physics.OverlapSphere(transform.position, GrenadeRadius);
 
        foreach (Collider touchedObject in touchedObjects)
        {

            if(touchedObject.CompareTag("Zombe"))
            {
                // explodedZombies.Add(touchedObject.gameObject);
                touchedObject.GetComponent<ZombieBrain>()
                    .ExplodeZombie(ExplosionForce, transform.position, GrenadeRadius);;
            }
 
        }
        // zc.ExplodeZombie(explodedZombies, ExplosionForce, transform.position, GrenadeRadius);
    }
}
