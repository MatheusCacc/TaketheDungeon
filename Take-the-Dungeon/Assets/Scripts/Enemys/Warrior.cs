using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Warrior : MonoBehaviour
{
    private Inimigo_Anim inAn;
    private Inimigos In;
    private Jogador_status jgsts;

    #region Status
    public int life = 15;
    public int dmg = 4;

    #endregion
    void Start()
    {
        inAn = GetComponent<Inimigo_Anim>();
        In = GetComponent<Inimigos>();
        jgsts = FindObjectOfType<Jogador_status>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0) {
            inAn.OnDeath(true);
            jgsts.currentxp += 0.5f;
        }
        if (life <= 0)
        {
            In.agent.speed = 0;
        }
    }
}
