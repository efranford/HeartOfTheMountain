using UnityEngine;
using System.Collections;

public class NavigationPath : MonoBehaviour {
	
	public Transform[] PointsInPath;

	void OnDrawGizmos() 
	{
		foreach(Transform t in PointsInPath)
        	Gizmos.DrawIcon(t.position, "node.png", true);
    }
}
