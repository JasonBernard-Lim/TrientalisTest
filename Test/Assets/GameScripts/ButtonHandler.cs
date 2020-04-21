using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public GameObject spread1;
    public GameObject spread2;
    public GameObject spread3;
    public static int which = 2;

    // Update is called once per frame
    public void Shoot()
    {
        if(which == 1)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
        else 
        {
            Instantiate(spread1, firePoint.position, firePoint.rotation);
            Instantiate(spread2, firePoint.position, firePoint.rotation);
            Instantiate(spread3, firePoint.position, firePoint.rotation);
        }
        
    }

    public void ChangeWeapon()
    {
        if(which == 1)
        {
            which = 2;
        }
        else
            which = 1;
    }
}
