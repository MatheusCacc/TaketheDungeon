using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Anim : MonoBehaviour
{
    public Animator anim;
    private Jog_anim Player;
    private Jogador_status jgSts;
    private bool isHitting = false;
    private Warrior wr;
    private float timeCoutn;
    private float recoveryTime = 1.2f;

    [SerializeField] private Transform atakPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Player = FindObjectOfType<Jog_anim>();
        wr = FindObjectOfType<Warrior>();
        jgSts = FindObjectOfType<Jogador_status>();
    }

    private void Update()
    {
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

    public void playAnim(int value) {
        anim.SetInteger("transition", value);
    }

    public void Dano() {
        Collider2D hit = Physics2D.OverlapCircle(atakPoint.position, radius, playerLayer);

        if (hit != null)
        {
            Player.OnHit(wr.dmg);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow") || collision.CompareTag("Magic") || collision.CompareTag("Sword")) {
            anim.SetTrigger("hit");
            isHitting = true;
            wr.life -= 1;        
        }
    }
    public void OnDeath(bool dead = false) {
        if (dead == true) {
            anim.SetTrigger("death");
            Destroy(gameObject, 0.7f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(atakPoint.position, radius);
    }
}
