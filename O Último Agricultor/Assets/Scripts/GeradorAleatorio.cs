using UnityEngine;

public class GeradorAleatorio : MonoBehaviour
{

    public GameObject [] objetosParaSpawnar;
    public Transform[] pontosDeSpawn;
    public float tempoEntreSpawns;
    public float tempoAtual;


    void Update()
    {
        tempoAtual -= Time.deltaTime;
        if ( tempoAtual <= 0)
        {
            int objetoAleatorio = Random.Range(0, objetosParaSpawnar.Length);
            int pontoAleatorio = Random.Range(0, pontosDeSpawn.Length);
            Instantiate(objetosParaSpawnar[objetoAleatorio], pontosDeSpawn[pontoAleatorio].position, pontosDeSpawn[pontoAleatorio].rotation);
            tempoAtual = tempoEntreSpawns;
        }
    }
}
