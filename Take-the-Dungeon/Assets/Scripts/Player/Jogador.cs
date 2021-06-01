using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    [Header("Status")]
    public int vida;
    public int energia;
    public int xp;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            SceneManager.LoadScene(7);
        }   
        if (xp >= 300) {
            SceneManager.LoadScene(8);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene(6);
        }
    }
}
