using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud_Controler : MonoBehaviour
{
    public int level;

    [SerializeField] private Image life;
    [SerializeField] private Image xp;
    [SerializeField] private Image energy;
    [SerializeField] private Image manaB;

    private Jogador_status jg_sts;

    private void Awake()
    {
        jg_sts = FindObjectOfType < Jogador_status>();
    }

    // Start is called before the first frame update
    void Start()
    {
        jg_sts.currentlife = 30;
        jg_sts.currentMana = 20;
        jg_sts.str = 0;
        jg_sts.dmg = 10;
        life.fillAmount = 0f;
        xp.fillAmount = 0f;
        energy.fillAmount = 0f;
        manaB.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        life.fillAmount = jg_sts.currentlife / jg_sts.Maxlife;
        xp.fillAmount = jg_sts.currentxp / jg_sts.MaxXp;
        manaB.fillAmount = jg_sts.currentMana / jg_sts.MaxMana;
        
    }

    private void FixedUpdate()
    {
        jg_sts.XPControler(jg_sts.currentxp);
    }

    public void levelup() {
        if (xp.fillAmount == 1f) {
            level += 1;
            xp.fillAmount = 0f;
        }
    }

    public void UpStatusLife() {
        if (jg_sts.Maxlife < 100) {
            jg_sts.Maxlife += 10;
        }  
    }
    public void UpStatusMana()
    {
        if (jg_sts.MaxMana < 100)
        {
            jg_sts.MaxMana += 10;
        }
    }
    public void UpStatusStr()
    {
        if (jg_sts.MaxStr < 100)
        {
            jg_sts.MaxStr += 10;
        }
    }
    public void UpStatusDmg()
    {
        if (jg_sts.MaxDmg < 100)
        {
            jg_sts.MaxDmg += 10;
        }
    }
}
