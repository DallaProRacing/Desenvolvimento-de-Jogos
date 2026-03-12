using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class MenuInicial : MonoBehaviour
{
   public TMP_InputField campoNome;

    void Start()
    {
        Time.timeScale = 0f;
        Musicas.instancia.tocarMusicaFundo();
    }
    public void iniciarJogo()
    {
        if (campoNome.text != "")
            PlayerPrefs.SetString("NomeJogador", campoNome.text);
        else
            PlayerPrefs.SetString("NomeJogador", "Jogador");

        Time.timeScale = 1f;
        
        this.gameObject.SetActive(false);
    }
    public void sairJogo()
    {
        Application.Quit();
        Debug.Log("Saiu do Jogo");
    }
}
