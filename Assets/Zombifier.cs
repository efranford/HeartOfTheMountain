using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Zombifier : MonoBehaviour {
	
	GameObject[] enemies;
	public Material ZombieBody;
	public Material ZombieEyeLid;
	public Mesh ZombieMesh;
	
	// Use this for initialization
	void Start () {
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
	}
	
	public void Zombify()
	{
		foreach(GameObject squirrel in enemies)
		{
			EnemyWanderingSquirrel ews = squirrel.GetComponent<EnemyWanderingSquirrel>();
			if(ews != null)
			{
				ews.Body.renderer.material = ZombieBody;
				ews.EyeLidL.renderer.material = ews.EyeLidR.renderer.material = ZombieEyeLid;
				ews.EnemyMesh =  ZombieMesh;
			}
		}
	}
}
