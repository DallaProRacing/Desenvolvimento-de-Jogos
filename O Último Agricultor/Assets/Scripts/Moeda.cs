using UnityEngine;

public class Moeda : MonoBehaviour
{

    public AudioSource somMoeda;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            other.GetComponent<CodigoJogador>().AumentarQuantidadeMoedas();
            somMoeda.Play();
            Debug.Log("Moeda colidio com o jogador.");
            Destroy(this.gameObject, 0.5f);
        }
    }

}
