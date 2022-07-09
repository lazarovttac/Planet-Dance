using System.Collections;
using UnityEngine;

public class OrbitAround : MonoBehaviour
{
    public Vector3 position;    

    public float a = 10, b = 10;
    public float angle = 0;
    public float w = 2; // Angular velocity in radians/s
    public TrailRenderer trail;

    void Start() {
        StartCoroutine(InitialReset());
    }

    void Update()
    {
        angle += w * Time.deltaTime;
       
        float x = a * Mathf.Cos(angle);
        float y = b * Mathf.Sin(angle);
        float z = 0;

        position = new Vector3(x, y, z);
        transform.localPosition = position;

        // // Catetos adyacente y opuesto
        // // (con .position se obtiene la distancia al (0,0,0))
        // float Ca = transform.localPosition.x;
        // float Co = transform.localPosition.y; 
        // // Elevados al cuadrado
        // Ca *= Ca; 
        // Co *= Co;
        // // Hipotenusa
        // currentRadius = Mathf.Sqrt(Ca + Co);

        // Trying to dynamicaly change the radius to rotate around another object :[
        // radius =  ((a*a) + (b*b)) / ((2 * a * Mathf.Cos(angle)) + (2 * b * Mathf.Sin(angle)));
        // radius = r + 2 * a * Mathf.Cos(angle) + 2 * b * Mathf.Sin(angle);
    }

    public IEnumerator InitialReset() {
        yield return new WaitForSeconds(0.1f);
        trail.Clear();
    }

}
