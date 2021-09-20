using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jogador_status : MonoBehaviour
{
    private int chgclass;
    public GameObject end;

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

            if (level == 5) {
                ChooseClass();
            }

        }
        else if (level == maxlevel ) {
            ismax = true;
            MaxXp = 10000000000000;
        }
    }

    #region Telas

    public GameObject Inventory;
    public GameObject Status;
    public GameObject Evolution;
    public GameObject Pause;

    public void OpenInv() {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Inventory.activeSelf)
            {
                Inventory.SetActive(false);
                Time.timeScale = 1;

            }
            else
            {
                Inventory.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void OpenStatus()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Status.activeSelf)
            {
                Status.SetActive(false);
                Time.timeScale = 1;

            }
            else
            {
                Status.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void OpenPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause.activeSelf)
            {
                Pause.SetActive(false);
                Time.timeScale = 1;

            }
            else
            {
                Pause.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void ChooseClass() { 
        
    }
    #endregion

    private void Update()
    {
        OpenInv();
        OpenStatus();
        OpenPause();


        endGame();
    }

    public void endGame() {
        if (currentlife <= 0) {
            end.SetActive(true);
        }
    }
}
