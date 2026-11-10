using UnityEngine;

public class Spinner : MonoBehaviour
{

    //VARIABLES
    [SerializeField] [Range (-30f,30f)]
    float xAngle;

    [SerializeField] [Range (-30f,30f)]
    float yAngle;

    [SerializeField] [Range (-30f,30f)]
    float zAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAngle* Time.deltaTime, yAngle* Time.deltaTime, zAngle* Time.deltaTime);
    }
}
