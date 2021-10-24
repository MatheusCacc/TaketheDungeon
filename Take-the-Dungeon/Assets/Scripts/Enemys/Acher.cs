using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Acher : MonoBehaviour
{
    [SerializeField] private Transform bow;
    [SerializeField] private Animator aniArcher;
    [SerializeField] private NavMeshAgent agent;
    private Jogador_status jgsts;
    private bool death = false;
    private Jogador player;
    private float timeCoutn;
    private float recoveryTime = 1.2f;
    private bool isHitting = false;
    bool detected = false;

    public GameObject arrow;
    public Transform target;
    public float range;

    #region Status
    public int life = 8;
    public int dmg = 4;

    #endregion
    void Start()
    {
        jgsts = FindObjectOfType<Jogador_status>();
        player = FindObjectOfType<Jogador>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void Update()
    {
        OnDeath();
        AniAll();

        if (isHitting)
        {
            timeCoutn += Time.deltaTime;

            if (timeCoutn >= recoveryTime)
            {
                isHitting = false;
                timeCoutn = 0f;
            }
        }
    }

    public void OnDeath()
    {
        if (life <= 0)
        {
            aniArcher.SetTrigger("death");
            agent.speed = 0;
            Destroy(gameObject, 0.7f);
            jgsts.currentxp += 0.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow") || collision.CompareTag("Magic") || collision.CompareTag("Sword"))
        {
            aniArcher.SetTrigger("Dmg");
            isHitting = true;
            life -= 4;
        }
    }

    public void shoot()
    {
        GameObject magics = Instantiate(arrow, bow.position, Quaternion.identity);
        Instantiate(arrow, bow.position, transform.rotation);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(bow.position, range);

    }


    public void AniAll()
    {
        agent.SetDestination(player.transform.position);

        if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
        {
            aniArcher.SetInteger("transition", 1);
            shoot();
        }
        else
        {
            aniArcher.SetInteger("transition", 2);
            

        }

        float posx = player.transform.position.x - transform.position.x;

        if (posx > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
