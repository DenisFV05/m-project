using UnityEngine;

public class PewPew : MonoBehaviour
{
    public Transform Laser; 
    public GameObject bala; 
    public AudioSource audio;

    public AudioClip pewpew;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject nuevaBala = Instantiate(bala, Laser.position, Laser.rotation);
            
            nuevaBala.tag = "Pew";
            
            audio.PlayOneShot(pewpew);
        }
    }
}
