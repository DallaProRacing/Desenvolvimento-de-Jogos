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
    public GameObject painelGameOver;
    public TMP_Text textoPontuacao;

    // Textos do Top 3
    public TMP_Text recordista1Texto;
    public TMP_Text recordista2Texto;
    public TMP_Text recordista3Texto;

    private float temporizador = 0f;
    private float intervaloAumento = 30f;
    public float aumentoVelocidade = 0.5f;

    void Start()
    {
        quantidadeMoedas = 0;
        textoMoedasAtuais.text = "X" + quantidadeMoedas;
        oAnimador = GetComponent<Animator>();
    }

    void Update()
    {
        MovimentarJogador();
        AumentarVelocidadeComTempo();
    }

    public void AumentarVelocidadeComTempo()
    {
        temporizador += Time.deltaTime;

        if (temporizador >= intervaloAumento)
        {
            velocidadeJogador += aumentoVelocidade;
            temporizador = 0f;
            Debug.Log("Velocidade aumentada! Nova velocidade: " + velocidadeJogador);
        }
    }

    public void MovimentarJogador()
    {
        float comandosTeclado = Input.GetAxisRaw("Horizontal") * velocidadeJogador * Time.deltaTime;
        transform.position = new Vector3((transform.position.x + comandosTeclado), transform.position.y, transform.position.z);

        if (comandosTeclado > 0.01f)
            GetComponent<SpriteRenderer>().flipX = false;

        if (comandosTeclado < -0.01f)
            GetComponent<SpriteRenderer>().flipX = true;

        if (comandosTeclado == 0)
            oAnimador.Play("jogadorParado");
        else
            oAnimador.Play("jogadorAndando");
    }

    public void AumentarQuantidadeMoedas()
    {
        quantidadeMoedas += 1;
        textoMoedasAtuais.text = "x" + quantidadeMoedas;
    }

    public void gamerOver()
    {
        Time.timeScale = 0f;
        painelGameOver.SetActive(true);
        textoPontuacao.text = "Pontuação: " + quantidadeMoedas;

        // Pega os recordes salvos
        int score1 = PlayerPrefs.GetInt("Score1", 0);
        int score2 = PlayerPrefs.GetInt("Score2", 0);
        int score3 = PlayerPrefs.GetInt("Score3", 0);

        string nome1 = PlayerPrefs.GetString("Nome1", "---");
        string nome2 = PlayerPrefs.GetString("Nome2", "---");
        string nome3 = PlayerPrefs.GetString("Nome3", "---");

        string nomeAtual = PlayerPrefs.GetString("NomeJogador", "Jogador");

        // Verifica se entrou no top 3
        if (quantidadeMoedas > score1)
        {
            PlayerPrefs.SetInt("Score3", score2);    PlayerPrefs.SetString("Nome3", nome2);
            PlayerPrefs.SetInt("Score2", score1);    PlayerPrefs.SetString("Nome2", nome1);
            PlayerPrefs.SetInt("Score1", quantidadeMoedas); PlayerPrefs.SetString("Nome1", nomeAtual);
        }
        else if (quantidadeMoedas > score2)
        {
            PlayerPrefs.SetInt("Score3", score2);    PlayerPrefs.SetString("Nome3", nome2);
            PlayerPrefs.SetInt("Score2", quantidadeMoedas); PlayerPrefs.SetString("Nome2", nomeAtual);
        }
        else if (quantidadeMoedas > score3)
        {
            PlayerPrefs.SetInt("Score3", quantidadeMoedas); PlayerPrefs.SetString("Nome3", nomeAtual);
        }

        PlayerPrefs.Save();

        // Atualiza os textos na tela
        recordista1Texto.text = "1 " + PlayerPrefs.GetString("Nome1", "---") + " - " + PlayerPrefs.GetInt("Score1", 0);
        recordista2Texto.text = "2 " + PlayerPrefs.GetString("Nome2", "---") + " - " + PlayerPrefs.GetInt("Score2", 0);
        recordista3Texto.text = "3 " + PlayerPrefs.GetString("Nome3", "---") + " - " + PlayerPrefs.GetInt("Score3", 0);

        Debug.Log("GAME OVER");
    }
}