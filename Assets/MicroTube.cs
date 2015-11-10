using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;
public class MicroTube : MonoBehaviour
{

	class Point
	{
		public float x;
		public float y;
		public float z;

		public void setPoints (float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
	}


	int i, j, k;
	float r1 = 621.09f, r2 = 690.10f, r, theta, phi;
	List<Point> microTube = new List<Point> ();
	// Use this for initialization
	void Start ()
	{
		for (j=0; j<7; j++) {
			for (i=0; i<12; i++) {
				r = r1;
				phi = i * 30f / 180f * 3.14f;
				theta = j * 30f / 180f * 3.14f;
				float x = r * Mathf.Sin (theta) * Mathf.Cos (phi);
				float y = r * Mathf.Sin (theta) * Mathf.Sin (phi);
				float z = r * Mathf.Cos (theta);
				Point orizin = new Point ();
				Point tmp = new Point ();
				orizin.setPoints (0, 0, 0);
				tmp.setPoints (x, y, z);
				microTube.Add (orizin);
				microTube.Add (tmp);
			}
		}
		LineRenderer renderer = gameObject.GetComponent<LineRenderer> ();
		renderer.SetWidth (3f, 3f);
		renderer.material.color = Color.red;
		renderer.SetVertexCount (microTube.Count);
		for (int i=0; i<microTube.Count; i++) {
			Vector3 path = new Vector3 (microTube [i].x, microTube [i].y, microTube [i].z);
			renderer.SetPosition (i, path);
		}
	}

			
			
	// Update is called once per frame
	void Update ()
	{

	}
}
