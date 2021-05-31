using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenControler : MonoBehaviour
{
    int telaAntes;

    public void Cadastrar() {
        SceneManager.LoadScene(2);//tela de cadastro
    }
    public void VoltarLogin() {
        SceneManager.LoadScene(0);//tela de login
    }
    public void VoltarTelaInicial() {
        SceneManager.LoadScene(1);//tela de inicio
    }
    public void IniciarJogo() {
        SceneManager.LoadScene(5);//comeca o jogo

    }
    public void TelaConfig() {
        telaAntes = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("indiceAntesConfig", telaAntes);
        SceneManager.LoadScene(3);//tela de configuracoes
    }
    public void TelaCreditos() {
        SceneManager.LoadScene(4);//tela de creditos
    }
    public void Sair() {
        Application.Quit();//fechar jogo
    }
    public void SalvarConfig() {//salvar configs e voltar pra tela anterior
        int indiceAtual = PlayerPrefs.GetInt("indiceAntesConfig");
        Debug.Log(indiceAtual);
        SceneManager.LoadScene(indiceAtual);
    }
    
    
}
