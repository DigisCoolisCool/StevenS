using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    Camera Playercamera;
    Ray rayFromPlayer;
    RaycastHit hit;
    public GameObject sparkles;
    public int ammo = 10;
    public ParticleSystem muzzleFlash;
   // public AudioSource Lasersound;
   // public AudioSource ammopickup;
        // Start is called before the first frame update
    void Start()
    {
        Playercamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        rayFromPlayer = Playercamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        Debug.DrawRay(rayFromPlayer.origin, rayFromPlayer.direction * 100, Color.red);
        if (Input.GetKeyDown(KeyCode.E))
            {
            if(Physics.Raycast(rayFromPlayer,out hit, 100) && ammo > 0)
            {
                print("The object is" + hit.collider.gameObject.name + "it front of player");
                Vector3 positionoFimpact;
                positionoFimpact = hit.point;
                    Instantiate(sparkles, positionoFimpact, Quaternion.identity);
                GameObject objectTargerted;
               muzzleFlash.Play();

                
               
                if (hit.collider.gameObject.tag == "Target")
                    {
                    objectTargerted = hit.collider.gameObject;
                    objectTargerted.GetComponent<ManagerPC>().GotHit();
                }

            }
            ammo--;
            print("you have " + ammo + "ammo left");
            //Lasersound.Play();
        } 
    }

    public void ManageCollisions(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "ammogun")
        {
            ammo += 5;
            if (ammo > 25) ammo = 25;
            Destroy(hit.collider.gameObject);
            //ammopickup.Play();
        }
    }
}
