using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float deathDelay = 1.5f;
    public float maxHealth = 100f;

    private float currentHealth;
    private Transform target;
    private NavMeshAgent agent;
    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        GameObject tower = GameObject.FindGameObjectWithTag("Tower");
        if (tower != null)
        {
            target = tower.transform;
            agent.SetDestination(target.position);
            anim.SetBool("Run", true);
        }
    }

    void Update()
    {
        if (isDead || target == null) return;

        agent.SetDestination(target.position);

        // Перевірка дистанції до башти
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= 1.5f) // радіус досягнення башти
        {
            EndGame();
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        agent.isStopped = true;
        anim.SetBool("Run", false);
        anim.SetTrigger("Die");
        StartCoroutine(DestroyAfterDelay(deathDelay));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    void EndGame()
    {
        Debug.Log("Game Over! Enemy reached the tower.");
        // тут можеш додати UI, сцену поразки тощо
        Time.timeScale = 0f;
    }
}
