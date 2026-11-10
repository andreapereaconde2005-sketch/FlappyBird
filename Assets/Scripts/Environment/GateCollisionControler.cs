using UnityEngine;

public class GateCollisionControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Primero compruebo si el objeto que me ha atravesado tiene asignada la etiqueta "Player"
        if (other.gameObject.tag == "Player")
        {
            // Busco en toda la escena el nivel
            LevelController levelController = FindAnyObjectByType<LevelController>();
            
            // Si encuentro el nivel lo que hago es llamar al método que me pasa a la siguiente escena
            if (levelController != null) levelController.LoadNextLevel(); //sanity check
           
        }
    }
}
