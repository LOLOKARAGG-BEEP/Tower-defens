using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public Transform target; // tower
    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead || target == null) return;

        // Рух до цілі
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.LookAt(target);
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        anim.SetTrigger("Die");

        // Знищити після завершення анімації
        StartCoroutine(DestroyAfterDeath(1.5f)); // тривалість анімації
    }

    IEnumerator DestroyAfterDeath(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // знищити кулю
            Die();
        }
    }
}
