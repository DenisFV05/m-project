using UnityEngine;

public class ElementController : MonoBehaviour
{
    public float respawnTime = 2f; 
    public Spawner spawner;
    public AudioClip pickup;
    public scoreManager scoreManager;

    private bool Recollida = false; 

    public void RecollirBala()
    {
        if (Recollida) return; 

        Debug.Log("Gotcha!");
        Destroy(transform.parent.gameObject);  
        spawner.ScrewList.Remove(transform.parent.gameObject);
        spawner.audio.PlayOneShot(pickup);
        scoreManager.instancia.afegirPunts();
        Recollida = true; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            RecollirBala();
        }

        if (other.CompareTag("Pew")) 
        {
            RecollirBala(); //hacer que se borre tambien si la pos pasa de X.
            Destroy(other.gameObject);
        }
    }
}
