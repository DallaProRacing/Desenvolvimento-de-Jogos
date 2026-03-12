using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    void Start()
    {
        Musicas.instancia.tocarMusicaGameOver();
    }

    public void ReiniciarPartida()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SairdoJogo()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo");
    }
}