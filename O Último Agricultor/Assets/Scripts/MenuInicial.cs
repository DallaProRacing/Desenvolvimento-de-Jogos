using UnityEngine;
using UnityEngine.Rendering;

public class MenuInicial : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
    }
    public void iniciarJogo()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }
    public void sairJogo()
    {
        Application.Quit();
        Debug.Log("Saiu do Jogo");
    }
}
