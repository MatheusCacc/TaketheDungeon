using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTIControler : MonoBehaviour
{

    public static ScreenTIControler instance;

    public GameObject Inicio;
    public GameObject Credito;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    #region Comando Botões
    public void playgame()
    {
        SceneManager.LoadScene(2);

    }
    public void ConfigScene()
    {
        SceneManager.LoadScene(3);
    }

    public void CreditScene()
    {
        Inicio.SetActive(false);
        Credito.SetActive(true);
    }

    public void ExitLogin() {
        SceneManager.LoadScene(0);
    }
    public void ReturnIn()
    {
        Inicio.SetActive(true);
        Credito.SetActive(false);
    }
    #endregion
}
