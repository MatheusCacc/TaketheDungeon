using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jogador_status : MonoBehaviour
{
    private int chgclass;

    #region life
    public int life = 20;
    public bool isdead = false;
    public float currentlife;
    private float maxlife = 20;

    #endregion

    #region xp
    public int xp = 0;
    public int level = 1;
    public bool ismax = false;

    public float currentxp;
    private float maxXp = 75;

    private int maxlevel = 5;
    #endregion

    public float MaxXp { get => maxXp; set => maxXp = value; }
    public float Maxlife { get => maxlife; set => maxlife = value; }
    

    public void LifeControler() {
        if (currentlife == 0) {
            isdead = true;
        }
    }

    public void XPControler(float xp) {
        if (currentxp >= MaxXp) {
            level = level + 1;
            MaxXp += 25;
            currentxp = 0;

        }
        else if (level == maxlevel ) {
            ismax = true;
            MaxXp = 10000000000000;
        }
    }
}
