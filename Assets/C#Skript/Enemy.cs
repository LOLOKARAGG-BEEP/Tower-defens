using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float deathDelay = 1.5f;
    private Transform target;
    private NavMeshAgent agent;
    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        // Автоматично знаходимо башню по тегу
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
}
