using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_Anim : MonoBehaviour
{
    private Animator anim;
    private Jog_anim Player;

    [SerializeField] private Transform atakPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Player = FindObjectOfType<Jog_anim>();
    }

    public void playAnim(int value) {
        anim.SetInteger("transition", value);
    }

    public void Dano() {
        Collider2D hit = Physics2D.OverlapCircle(atakPoint.position, radius, playerLayer);

        if (hit != null)
        {
            Player.OnHit();
        }
        else { 
            
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(atakPoint.position, radius);
    }
}
