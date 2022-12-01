using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ManagerPC : MonoBehaviour
{

    public int health;
    public GameObject Lastsmoke;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) DestroyNPC();
      
    }
    public  void GotHit()
    {
        health -= 25;
}
        
    public void DestroyNPC()
    {
        GameObject Smoke = Instantiate(Lastsmoke, transform.position, Quaternion.identity);
        Destroy(Smoke, 1);
        Destroy(gameObject);
    }

}
