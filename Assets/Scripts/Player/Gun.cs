using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float range = 20f;
    public float verticalRange = 20f;
    public float fireRate;
    public float damage = 2f;

    private float nextTimeToFire;
    private BoxCollider gunTrigger;


    public LayerMask raycastLayerMask;
    public EnemyManager enemyManager;

    [Header("Muzzle flash UI")]
    public Image muzzleFlash;

    [Header("Muzzle flash Sprite")]
    public Sprite muzzleFlashSprite;

    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();

        // Activate muzzle flash
        if (muzzleFlash != null)
        {
            muzzleFlash.sprite = muzzleFlashSprite;
            muzzleFlash.enabled = true;
            StartCoroutine(DisableMuzzleFlash());
        }

        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            var dir = enemy.transform.position - transform.position;

            RaycastHit hit;
            if(Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    // damage enemy
                    enemy.TakeDamage(damage);
                }
                
            }            
        }

        // Coroutine to disable muzzle flash after a short time
        IEnumerator DisableMuzzleFlash()
        {
            yield return new WaitForSeconds(0.05f); // Flash duration - adjust as needed
            muzzleFlash.enabled = false;
        }

        nextTimeToFire = Time.time + fireRate;
    }

    // Detect enemies in range
    private void OnTriggerEnter(Collider other)
    {
        //Add potential enemy to shoot
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    // Remove enemies out of range
    private void OnTriggerExit(Collider other)
    {
        //Remove enemy to shoot
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }

}