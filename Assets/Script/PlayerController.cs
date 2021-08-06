using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float bulletSpeed;
    public GameObject bullet;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
             GameObject bulletObj = Instantiate(bullet);
            bulletObj.transform.position = transform.position + this.transform.forward;
            bulletObj.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        }
       
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<EnemyController>()  != null)
        {
            Time.timeScale = 0;
            this.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        }
    }
}
