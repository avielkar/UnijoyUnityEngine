using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnijoyData.Shared.Data;
using Assets.SceneManager;
using Assets.SceneBuilders;
using Assets.Network.Retrievers;
using Assets.Network.Handlers;
using System;
using Assets.Scenes.Shared;

public class Triangle : MonoBehaviour
{
	Mesh mesh;
	MeshRenderer meshRenderer;
	Vector3[] vertices;
	int[] triangles;
	bool newData = false;
	private bool renderNewData = false;
	System.Random _rand;

	public Material material;

	int frameNumber = 0;

	private void Awake()
	{
		mesh = new Mesh();
	}

	void HandelNewData(object sender, ISceneData e)
	{
		try
		{

			vertices = e.ObjectsVertices.ToArray();
			triangles = new int[3000];
			for(int i=0;i<3000;i++)
			{
				triangles[i] = i;
			}


			Debug.Log("Handling new trial data");

			newData = true;
		}
		catch (Exception ex)
		{
			Debug.LogError($"Exception with {ex.ToString()}");
		}
	}

	private void HandleStartRenderCommand(object sender, EventArgs e)
	{
		renderNewData = true;
	}

	// Use this for initialization
	void Start()
	{
		ScenesEventRegister.NewSceneReceivedRegistration(HandelNewData);
		ScenesEventRegister.StartRenderCommandReceivedRegistraion(HandleStartRenderCommand);

		gameObject.AddComponent<MeshFilter>();
		meshRenderer = gameObject.AddComponent<MeshRenderer>();
		meshRenderer.material = material;
		mesh = new Mesh();
	}



	// Update is called once per frame
	void Update()
	{
		if(newData)
		{
			UpdateMesh();
			newData = false;
		}

		if(renderNewData)
		{
			Debug.Log("Rendering new trial data");
			//triangles = new[] { 0, 1, 2 };
			GetComponent<MeshFilter>().mesh = mesh;

			renderNewData = false;
		}
	}

	void UpdateMesh()
	{
		try
		{
			Debug.Log("Updating new trial data");
			mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.triangles = triangles;
		}
		catch (Exception ex)
		{
			Debug.LogError(ex);
		}
	}
}
