using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bullet;
    private float speed = 110;
    RaycastHit hit;
    public int designatedCamera;
    public Camera cameraObject;

    void Start()
    {
       // hit = new RaycastHit();
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 startPoint = new Vector3(0, 0, 0);
        Ray ray = cameraObject.ScreenPointToRay(Input.mousePosition);
       

        if (GameObject.Find("Controller").GetComponent<CameraSwitching>().CurrentMaterialIndex == designatedCamera)
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (Physics.Raycast(ray, out hit, 400.0f))
                {
                Debug.DrawLine(ray.origin, hit.point, Color.red);

                GameObject newBullet =
                    Instantiate(bullet, cameraObject.transform.position, cameraObject.transform.rotation) as GameObject;
                       bullet.transform.LookAt(hit.point);
                newBullet.GetComponent<Rigidbody>().velocity = ((hit.point - cameraObject.transform.position).normalized)* speed;
                    Debug.Log(newBullet.GetComponent<Rigidbody>().velocity);
                    Debug.Log(newBullet.GetComponent<Rigidbody>().velocity);
                    Debug.Log(speed);
                }
        }
        }

    }

   // void OnCollisionEnter(Collision collision)
   // {
   //     Destroy(newBullet);
   // }
}
