using UnityEngine;
public class RainScript : MonoBehaviour
{
    public GameObject rainDropPrefab; // Het prefab van de regendruppel
    public int numberOfRainDrops = 1000; // Het aantal regendruppels
    public float spawnRange = 50f; // Het bereik waarin de regendruppels worden gegenereerd
    public float minFallSpeed = 5f; // Minimale snelheid van de regendruppels
    public float maxFallSpeed = 10f; // Maximale snelheid van de regendruppels
    public float rainAreaHeight = 20f; // Hoogte van het regenveld

    private void Start()
    {
       
        CreateRain(); // Maak de regen
    }

    void CreateRain()
    {
        for (int i = 0; i < numberOfRainDrops; i++)
        {
            
            GameObject rainDrop = Instantiate(rainDropPrefab);// Maak een nieuwe regendruppel

            // Zet een willekeurige positie voor de regendruppel binnen het gespecificeerde bereik
            float x = Random.Range(-spawnRange, spawnRange);
            float y = Random.Range(0, rainAreaHeight);
            float z = Random.Range(-spawnRange, spawnRange);
            rainDrop.transform.position = new Vector3(x, y, z);

           
            Rigidbody2D rb = rainDrop.AddComponent<Rigidbody2D>();
            rb.gravityScale = 1; // Voeg een RigidBody2D toe aan de regendruppel om de zwaartekracht toe te passen

            
            float fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);// Stel de snelheid van de regendruppel in
            rb.velocity = new Vector2(0, -fallSpeed); // Snelheid naar beneden

            
            rainDrop.transform.parent = this.transform;// Maak de regendruppel een child van dit object om het netjes op te ruimen bij verwijdering
        }
    }

   
    public void StopRain()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject); // Optioneel: Methode om de regen te stoppen door alle regendruppels te verwijderen
        }
    }
}
