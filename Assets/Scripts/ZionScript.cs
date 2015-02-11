using UnityEngine;
using System.Collections;

public class ZionScript : MonoBehaviour {


    public GameObject FireBall;
    private Vector3 firePoint;

    private GameObject FB;
    private float bulletSpawner = 0;
    private float newTimerExistPeriod = 2;

	// Use this for initialization
	void Start () {

        firePoint = new Vector3(this.transform.position.x, this.transform.position.y + 5, this.transform.position.z);

        FB = (GameObject)Instantiate(FireBall, firePoint, Quaternion.identity);
    
    }
	
	// Update is called once per frame
	void Update () {

        bulletSpawner += Time.deltaTime;

        if (bulletSpawner > newTimerExistPeriod)
        {
            FB = (GameObject)Instantiate(FireBall, firePoint, Quaternion.identity);
            bulletSpawner = 0;
        }

	}
}
