using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
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
