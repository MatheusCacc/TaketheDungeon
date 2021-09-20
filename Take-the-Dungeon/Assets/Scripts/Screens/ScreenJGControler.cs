using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenJGControler : MonoBehaviour
{
    public GameObject Status;
    public GameObject Evolution;
    public GameObject Inventory;
    public GameObject Pause;

    public void resume() {
        Pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void sair() {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void status() {
        Status.SetActive(false);
        Time.timeScale = 1;
    }

    public void inventory() {
        Inventory.SetActive(false);
        Time.timeScale = 1;
    }
}
