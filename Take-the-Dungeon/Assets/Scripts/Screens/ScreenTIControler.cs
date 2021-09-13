using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTIControler : MonoBehaviour
{

    public static ScreenTIControler instance;

    public GameObject Inicio;
    public GameObject Credito;
    public GameObject Config;

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
        Inicio.SetActive(false);
        Config.SetActive(true);
    }
    public void CreditScene()
    {
        Inicio.SetActive(false);
        Credito.SetActive(true);
    }

    public void ExitLogin() {
        SceneManager.LoadScene(0);
    }
    #endregion
}
