using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float timer;
    float interval = 2f;
    float pared;
    float pared2;

    public GameObject Contenedor;

    public AudioSource audio;

    public AudioClip spawn;


    public Camera camera;
    public List<GameObject> ScrewList = new List<GameObject>();
    void Start()
    {

        camera = Camera.main; //https://discussions.unity.com/t/how-to-get-the-width-and-height-of-a-orthographic-camera/38675  
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval && ScrewList.Count < 10) 
        {
            float camheight = 2f * camera.orthographicSize;
            float camwidth = camheight * camera.aspect;
            float anchoTornillo = 1.00229f;
            float randomX = Random.Range((-camwidth / 2f) + anchoTornillo / 2f, (camwidth / 2f) - 3 - anchoTornillo/2f);
            float alturaTornillo = 0.8939343f;


            float alturaReal = -2f + alturaTornillo;
            float y = Random.Range(1.5f, alturaReal);
            
            Debug.Log("Posicion X,Y: " + randomX + "," + y);
  
            GameObject tornillo = Instantiate(Contenedor, new Vector2(randomX, y), Quaternion.identity);
            audio.clip = spawn;
            audio.Play();
            ScrewList.Add(tornillo);
            tornillo.SetActive(true);
            timer = 0f;
        }
    }
}
