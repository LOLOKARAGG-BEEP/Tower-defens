using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private Transform[] waypoints;
    private int currentIndex = 0;
    private Animator anim;
    private bool isDead = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Run", true);
    }

    void Update()
    {
        if (isDead || waypoints == null || currentIndex >= waypoints.Length) return;

        Transform targetPoint = waypoints[currentIndex];
        Vector3 dir = (targetPoint.position - transform.position).normalized;

        transform.Translate(dir * speed * Time.deltaTime, Space.World);
        transform.LookAt(targetPoint);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            currentIndex++;
        }
    }

    public void SetWaypoints(Transform[] _waypoints)
    {
        waypoints = _waypoints;
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        anim.SetBool("Run", false);
        anim.SetTrigger("Die");
        StartCoroutine(DestroyAfterDeath(1.5f));
    }

    IEnumerator DestroyAfterDeath(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
