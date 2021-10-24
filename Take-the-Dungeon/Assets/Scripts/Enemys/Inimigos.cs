using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigos : MonoBehaviour
{
    [SerializeField] private Inimigo_Anim animEnemy;
    [SerializeField] public NavMeshAgent agent;
    private Jogador player;
    
    void Start()
    {
        player = FindObjectOfType<Jogador>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(player.transform.position);

        if (Vector2.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
        { 
            animEnemy.playAnim(1);
        }
        else {
            animEnemy.playAnim(2);
        }

        float posx = player.transform.position.x - transform.position.x;

        if (posx > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else {
            transform.eulerAngles = new Vector2(0, 180);
        }        
    }
}
