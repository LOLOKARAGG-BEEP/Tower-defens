using UnityEngine;

public class TurretSimpleTarget : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    public float fireRate = 1f;
    public float detectionRadius = 10f;

    private float nextFireTime = 0f;

    void Update()
    {
        GameObject target = FindClosestEnemy();

        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            direction.y = 0; // не нахилятись по вертикалі
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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = direction * fireForce;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

