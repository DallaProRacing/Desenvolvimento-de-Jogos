using UnityEngine;

public class Moeda : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<CodigoJogador>().AumentarQuantidadeMoedas();
            Debug.Log("Moeda colidio com o jogador.");
            Destroy(this.gameObject);
        }
    }

}
