using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenControler : MonoBehaviour
{
    public GameObject[] gm_obj;
    public int x = 0;

    public void ScreenSwitchTI(int requestCode) {
        switch (requestCode) {
            case 0:
                gm_obj[0].SetActive(false);
                gm_obj[1].SetActive(true);
                break;
            case 1:
                gm_obj[1].SetActive(false);
                gm_obj[2].SetActive(true);
                break;
            case 2:
                gm_obj[2].SetActive(false);
                gm_obj[1].SetActive(true);
                break;
        }
    }
    public void ScreenSwitchTP(int requestCode) {
        switch (requestCode) {
            case 1:
                SceneManager.LoadScene(2);
                break;
            case 2:
                gm_obj[0].SetActive(false);
                gm_obj[6].SetActive(true);
                break;
            case 7:
                gm_obj[6].SetActive(false);
                gm_obj[0].SetActive(true);
                break;

        }

    }

    public void Princ_Conf() {
        SceneManager.LoadScene(3);
        x = 1;
    }
    public void Jogo_Conf() {
        SceneManager.LoadScene(3);
        x = 2;
    }
    public void Princ_Jogo_Config() {
        switch (x) {
            case 1:
                //implementar a mudança de cenas entre jogo/tela inicio para configurações.
                //raciocinio atual seria se vier da tela de incio, o x recebe 1 e se vier da tela jogo, o x recebe 2.
                //assim, quando clicasse em voltar, o usuario iria pra tela anterior.
                x = 0;
                break;
            case 2:
                SceneManager.LoadScene(2);
                x = 0;
                break;
        }
    }
}
