using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bullet;
    private float speed = 90;
    RaycastHit hit;
    public int designatedCamera;
    public Camera cameraObject;
    AudioSource audio;
    public AudioClip bang;
    public float reload = 0;
    void Start()
    {
       // hit = new RaycastHit();
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 startPoint = new Vector3(0, 0, 0);
        Ray ray = cameraObject.ScreenPointToRay(Input.mousePosition);
        audio = GetComponent<AudioSource>();
        reload += Time.deltaTime;

        if (GameObject.Find("Controller").GetComponent<CameraSwitching>().CurrentMaterialIndex == designatedCamera)
        {
            if ((Input.GetMouseButton(0) && reload > .2f) || Input.GetMouseButtonDown(0))
            {
         

                reload = 0;
            

            audio.PlayOneShot(bang);
                if (Physics.Raycast(ray, out hit, 400.0f))
                {
               // Debug.DrawLine(ray.origin, hit.point, Color.red);

                GameObject newBullet =
                    Instantiate(bullet, cameraObject.transform.position, cameraObject.transform.rotation) as GameObject;
                       bullet.transform.LookAt(hit.point);
                newBullet.GetComponent<Rigidbody>().velocity = ((hit.point - cameraObject.transform.position).normalized)* speed;
                    //Debug.Log(newBullet.GetComponent<Rigidbody>().velocity);
                  //  Debug.Log(newBullet.GetComponent<Rigidbody>().velocity);
                  //  Debug.Log(speed);

                  //  if (hit.collider.CompareTag("Enemy"))
                    {
                        // Code Emily wrote because Aaron wanted us to try:
                        //  hit.transform.gameObject.GetComponent<EnemyBehavior>().alive = false;
                    //    if (hit.transform.gameObject.GetComponent<EnemyBehavior>().alive == true)
                      //  {
                        //    GameObject.Find("score").GetComponent<ScoringScript>().score++;
                          //  Debug.Log("an enemy was hit, yo");
                       // }
                    }
                }
        }
        }

    }

   // void OnCollisionEnter(Collision collision)
   // {
   //     Destroy(newBullet);
   // }
}
