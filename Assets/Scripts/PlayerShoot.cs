using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    
    public GameObject bullet;
    public PlayerMove playermove;
    // Start is called before the first frame update
    void Start()
    {
       playermove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {

        
        Quaternion rotation = Quaternion.Euler(0, 0, 90);

        if (playermove.facingRight)
        {
            rotation = Quaternion.Euler(0, 0, -90);
        }
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (Input.GetMouseButtonDown(0))
        {

            Instantiate(bullet, newPos, rotation);
        }
    }
}
