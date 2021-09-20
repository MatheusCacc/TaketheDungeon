using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigos : MonoBehaviour
{
    [SerializeField] private Inimigo_Anim animEnemy;
    [SerializeField] private NavMeshAgent agent;
    private Jogador player;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Jogador>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
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
