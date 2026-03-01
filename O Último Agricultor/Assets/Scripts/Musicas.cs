using UnityEngine;

public class Musicas : MonoBehaviour
{
    public static Musicas instancia;

    public AudioSource musicaDeFundo;
    public AudioSource musicaDeGameOver;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void tocarMusicaFundo()
    {
        musicaDeGameOver.Stop();
        musicaDeFundo.Play();
    }

    public void tocarMusicaGameOver()
    {
        musicaDeFundo.Stop();
        musicaDeGameOver.Play();
    }
}