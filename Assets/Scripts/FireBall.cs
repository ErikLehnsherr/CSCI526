using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireBall : MonoBehaviour {


    //Private Elements
    //private Vector3 forwardVect;
    private float timeForFire = 0;
   // private float speedFire = 70;
    private float fireBallExistPeriod = 3; 

    //Public Elements
    public List <Transform> Enemies;
    public Transform SelectedTarget;
    
    

	// Use this for initialization
	void Start () {

        //forwardVect = Vector3.forward;
		
		SelectedTarget = null;
        Enemies = new List<Transform>();
        AddEnemiesToList();
 

	}
	
	public void AddEnemiesToList()
     {
         GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Enemy");
         foreach(GameObject _Enemy in ItemsInList)
         {
             AddTarget(_Enemy.transform);
         }
     }
	 
	 
	 public void AddTarget(Transform enemy)
     {
         Enemies.Add(enemy);
     }
	 
	 public void DistanceToTarget()
     {
         Enemies.Sort(delegate( Transform t1, Transform t2){ 
             return Vector3.Distance(t1.transform.position,transform.position).CompareTo(Vector3.Distance(t2.transform.position,transform.position)); 
         });
     
     }
	 
	 public void TargetedEnemy() 
     {
         if(SelectedTarget == null)
         {
             DistanceToTarget();
             SelectedTarget = Enemies[0];
         }
     }
	 
	 
	// Update is called once per frame
	void Update () {

		TargetedEnemy();
         float dist = Vector3.Distance(SelectedTarget.transform.position,transform.position);
         //if(dist <150)
         //{
             transform.position = Vector3.MoveTowards(transform.position, SelectedTarget.position, 60 * Time.deltaTime);
         //}
	
	
         timeForFire += Time.deltaTime;
       // this.gameObject.transform.Translate(forwardVect * speedFire * Time.deltaTime, Space.Self);


        if (timeForFire > fireBallExistPeriod)
        {

            timeForFire = 0;
            GameObject.Destroy(this.gameObject);
            
        } 

	}
}
