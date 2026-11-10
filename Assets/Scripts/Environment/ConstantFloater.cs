using UnityEngine;

public class ConstantFloater : MonoBehaviour
{
    //VARIABLES INICIALES
    [SerializeField] [Range (-10f,10f)]
    float final_frequency;

    [SerializeField] [Range (-10f,10f)]
    float amplitude;
    Vector3 startPos; //(x,y,z)


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Guardo posicion original del objeto
        startPos = transform.localPosition; 
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * final_frequency) * amplitude;
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
        
    }
}


//Vector3 es la clase de Unity para crear un vector tridimensional
//Exponer una variable: Si no pongo ningún valor a los parametros son privados pero si hago lo de los corchetes podemos cambiar variables en unity
    //[SerializeField]
    //float amplitude;
//Si manejo floats, pongo 5f y no 5

