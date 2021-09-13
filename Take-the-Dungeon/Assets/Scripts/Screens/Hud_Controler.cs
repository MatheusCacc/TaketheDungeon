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
    [SerializeField] private Image mana;

    private Jogador_status jg_sts;

    private void Awake()
    {
        jg_sts = FindObjectOfType < Jogador_status>();
    }

    // Start is called before the first frame update
    void Start()
    {
        jg_sts.currentlife = 20;
        life.fillAmount = 0f;
        xp.fillAmount = 0f;
        energy.fillAmount = 0f;
        mana.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        life.fillAmount = jg_sts.currentlife / jg_sts.Maxlife;
        xp.fillAmount = jg_sts.currentxp / jg_sts.MaxXp;
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
}
