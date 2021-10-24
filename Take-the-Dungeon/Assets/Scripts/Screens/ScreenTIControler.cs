using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTIControler : MonoBehaviour
{

    public static ScreenTIControler instance;

    public GameObject Inicio;
    public GameObject Credito;
    public Animator PanelAnimator;
    public int sceneIndex;

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

    #region Comando Bot�es
    public void playgame()
    {
        SceneManager.LoadScene(4);

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

    public void LoadScene()
    {
        StartCoroutine(LoadSceneCoroutine(sceneIndex));
    }

    private IEnumerator LoadSceneCoroutine(int sceneIndex)
    {
        PanelAnimator.SetBool("animateOut", true);
        yield return new WaitForSeconds(2f);

        //Carregar Cena
        SceneManager.LoadScene(sceneIndex);
    }
}
