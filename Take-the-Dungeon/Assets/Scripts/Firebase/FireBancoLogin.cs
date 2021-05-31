using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FireBancoLogin : MonoBehaviour
{
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public static FireBanco instance;
    public FirebaseAuth auth;
    public FirebaseUser User;

    [Header("Login")]
    public InputField email;
    public InputField senha;
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
    public void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void LoginButton()
    {
        StartCoroutine(Login(email.text, senha.text));
    }
    public IEnumerator Login(string _email, string _senha)
    {
            var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _senha);
            yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

            if (LoginTask.Exception == null)
            {
                SceneManager.LoadScene(1);//tela de Inicio
            }

    }
}