using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExemplo : MonoBehaviour
{
    Ray ray;
    RaycastHit hitData;
    public Vector3 point;
    public float hitDistance;
    //private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
       // _camera = GetComponent<Camera>();
        Debug.Log("Inicio!");

    }

    // Update is called once per frame
    void Update()
    {


        if (UnityEngine.Input.GetKey(KeyCode.Space))
        {
            //point = new Vector3(_camera.pixelWidth / 2, _camera. pixelHeight / 2, 0);
            //ray = _camera.ScreenPointToRay(point);
            ray = new Ray(transform.position, transform.forward);

            Debug.Log("Origem: " + ray.origin);
            RaycastHit hitData;
            Debug.Log("Dire��o: " + ray.direction);

            if (Physics.Raycast(ray, out hitData))
            {

                

                Vector3 hitPosition = hitData.point;
                Debug.Log(" hitPosition:" + hitPosition);

                
                hitDistance = hitData.distance;
                Debug.Log("Distancia: " + hitDistance);
                string tag = hitData.collider.tag;
                Debug.Log("Tag:" + tag);
                GameObject hitObject = hitData.transform.gameObject;
                Debug.DrawRay(ray.origin, hitPosition * hitDistance, Color.green);
                StartCoroutine(SphereIndicator(hitPosition));


            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * 1000, Color.magenta);
                Debug.Log("Target missed");
            }




        }
    }
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object
        Gizmos.color = Color.red;
        
        Gizmos.DrawRay(ray);
    }
}
