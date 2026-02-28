using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;
public class CodigoJogador : MonoBehaviour
{

    public float velocidadeJogador;
    public Animator oAnimador;

    public int quantidadeMoedas;

    public TMP_Text textoMoedasAtuais;

    void Start()
    {
        quantidadeMoedas = 0;
        textoMoedasAtuais.text = "X" + quantidadeMoedas;
        oAnimador = GetComponent <Animator>();
    }
     void Update()
     {
        MovimentarJogador();
        
     }

     public void MovimentarJogador()
    {
        float comandosTeclado = Input.GetAxisRaw("Horizontal") * velocidadeJogador * Time.deltaTime;
        transform.position = new Vector3((transform.position.x + comandosTeclado), transform.position.y, transform.position.z);

        //Funcao para virificar em qual lado esta andando o jogador

        if (comandosTeclado > 0.01f)
        {
            GetComponent < SpriteRenderer > ().flipX = false;
        }
        if (comandosTeclado < -0.01f)
        {
            GetComponent < SpriteRenderer > ().flipX = true;
        }

        if (comandosTeclado == 0)
        {
            oAnimador.Play("jogadorParado");
        }
        else
        {
            oAnimador.Play("jogadorAndando");
        }
    }

    public void AumentarQuantidadeMoedas()
    {
        quantidadeMoedas += 1;
        textoMoedasAtuais.text = "x" + quantidadeMoedas;
    }


    public void gamerOver()
    {
        Debug.Log("GAMER OVER");
    }
}
