﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
	Mesh mesh;
	MeshRenderer meshRenderer;
	Vector3[] vertices;
	int[] triangles;

	public Material material;

	// Use this for initialization
	void Start()
	{
		gameObject.AddComponent<MeshFilter>();
		meshRenderer = gameObject.AddComponent<MeshRenderer>();

		meshRenderer.material = material;

		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;

		vertices = new[] {
			new Vector3(0,0,10),
			new Vector3(0,1,10),
			new Vector3(1,0,10), 
			new Vector3(5,0,10),
			new Vector3(5,1,10),
			new Vector3(6,0,10),
		};

		mesh.vertices = vertices;

		triangles = new[] { 0, 1, 2, 3, 4, 5};

		mesh.triangles = triangles;
	}

	// Update is called once per frame
	void Update()
	{

	}
}