using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FireBanco : MonoBehaviour
{
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public static FireBanco instance;
    public FirebaseAuth auth;
    public FirebaseUser User;

    [Header("Cadastro")]
    public InputField nome;
    public InputField email;
    public InputField senha;
    public InputField conf_Senha;
    private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;

            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Error: " + dependencyStatus);
            }
        });
    }
    public void InitializeFirebase() {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void CadastroButton() {
        StartCoroutine(Cadastro(nome.text, email.text, senha.text));
    }
    public IEnumerator Cadastro(string _nome, string _email, string _senha) {

        if (senha.text != conf_Senha.text) {
            Debug.LogError("Problema com senha");
        }
        else {
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _senha);
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception == null)
            {
                SceneManager.LoadScene(0);//tela de Login
            }
        }
    }
}