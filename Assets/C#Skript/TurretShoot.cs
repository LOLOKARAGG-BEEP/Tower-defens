using UnityEngine;

public class TurretSimpleTarget : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public float fireRate = 1f;
    public float detectionRadius = 10f;

    private float nextFireTime = 0f;
    private GameObject currentTarget;

    void Update()
    {
        
        if (currentTarget == null || Vector3.Distance(transform.position, currentTarget.transform.position) > detectionRadius)
        {
            currentTarget = FindClosestEnemy();
        }

        if (currentTarget != null)
        {
            Vector3 direction = (currentTarget.transform.position - transform.position).normalized;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction);

            if (Time.time >= nextFireTime)
            {
                Shoot(direction);
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < minDist && dist <= detectionRadius)
            {
                closest = enemy;
                minDist = dist;
            }
        }

        return closest;
    }

    void Shoot(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.SetTarget(currentTarget.transform);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
