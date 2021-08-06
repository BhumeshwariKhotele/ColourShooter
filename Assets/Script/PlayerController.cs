using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float bulletSpeed;
    public GameObject bullet;
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
             GameObject bulletObj = Instantiate(bullet);
            bulletObj.transform.position = transform.position + this.transform.forward;
            bulletObj.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            bulletObj.GetComponent<Renderer>().material.SetColor("_Color", weapon.GetComponent<Renderer>().GetComponent<Renderer>().material.GetColor("_Color"));
        }
       
    }

   
}
