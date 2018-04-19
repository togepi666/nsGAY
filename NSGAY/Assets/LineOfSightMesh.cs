using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightMesh : MonoBehaviour
{
	private Mesh sectorMesh;
	void Start ()
	{
		sectorMesh = GetComponent<Mesh>();
		sectorMesh = new Mesh();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
