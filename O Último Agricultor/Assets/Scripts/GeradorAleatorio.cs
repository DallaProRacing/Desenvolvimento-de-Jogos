using UnityEngine;

public class GeradorAleatorio : MonoBehaviour
{
    public GameObject[] objetosParaSpawnar;
    public Transform[] pontosDeSpawn;

    public float tempoEntreSpawns;
    private float tempoAtual;

    public float tempoDificuldade;
    private float contadorDificuldade;

    public float gravityScaleAtual = 1f;
    public float aumentoGravity;


    void Update()
    {
        ControlarSpawn();
        ControlarDificuldade();
    }

    void ControlarSpawn()
    {
        tempoAtual -= Time.deltaTime;

        if (tempoAtual <= 0)
        {
            int objetoAleatorio = Random.Range(0, objetosParaSpawnar.Length);
            int pontoAleatorio = Random.Range(0, pontosDeSpawn.Length);

            GameObject objetoSpawnado = Instantiate(
                objetosParaSpawnar[objetoAleatorio],
                pontosDeSpawn[pontoAleatorio].position,
                pontosDeSpawn[pontoAleatorio].rotation
            );

            Rigidbody2D rb = objetoSpawnado.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.gravityScale = gravityScaleAtual;
            }

            tempoAtual = tempoEntreSpawns;
        }
    }

    void ControlarDificuldade()
    {
        contadorDificuldade += Time.deltaTime;

        if (contadorDificuldade >= tempoDificuldade)
        {
            AumentarDificuldade();
            contadorDificuldade = 0f;
        }
    }

    void AumentarDificuldade()
    {
        gravityScaleAtual += aumentoGravity;
        Debug.Log("Dificuldade aumentada! Nova gravidade: " + gravityScaleAtual);
    }
}