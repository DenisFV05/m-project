using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instancia;

    public AudioSource audio;
    public AudioClip victoria;
    public TextMeshProUGUI scoreText;
    public CambiarEscena cambiarEscena;
    private Animator animator;
    int score = 0;
    bool victoriaSonidoReproducido = false;
    Vector3 escalaOriginal;

    private void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        escalaOriginal = scoreText.transform.localScale;
        scoreText.text = "PUNTS: " + score.ToString();
        animator = scoreText.GetComponent<Animator>(); 

    }

    void Update()
    {
        if (score >= 10 && !victoriaSonidoReproducido)
        {
            audio.PlayOneShot(victoria);
            victoriaSonidoReproducido = true;
            animator.SetBool("Ganar", true); 
            StartCoroutine(Pausa());
        }
    }

    public void afegirPunts()
    {
        score++;
        scoreText.text = "PUNTS: " + score.ToString();
    }
    IEnumerator Pausa()
    {
        yield return new WaitForSeconds(3);
        cambiarEscena.LoadScene("GameOver");
    }
}
