using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bullet;
    public float speed = 50;
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

                    GameObject newBullet = Instantiate(bullet, cameraObject.transform.position, cameraObject.transform.rotation) as GameObject;
                    newBullet.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * speed;
                }
            }
        }

    }

   // void OnCollisionEnter(Collision collision)
   // {
   //     Destroy(newBullet);
   // }
}
