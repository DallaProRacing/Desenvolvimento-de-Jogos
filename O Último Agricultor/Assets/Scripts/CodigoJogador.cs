using Unity.VisualScripting;
using UnityEngine;

public class CodigoJogador : MonoBehaviour
{

    public float velocidadeJogador;
    void Start()
    {
        
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
    }
}
