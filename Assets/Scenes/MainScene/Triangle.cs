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
	int[] vertexesIndexes;
	private bool newData = false;
	private bool renderNewData = false;

	public Material material;

	private void Awake()
	{
		mesh = new Mesh();
	}

	void HandelNewData(object sender, ISceneData e)
	{
		try
		{

			vertices = e.ObjectsVertices.ToArray();
			vertexesIndexes = new int[vertices.Length];
			for(int i=0;i< vertexesIndexes.Length; i++)
			{
				vertexesIndexes[i] = i;
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
			Debug.Log("Updating new trial data");

			GetComponent<MeshFilter>().mesh = mesh;

			renderNewData = false;
		}
	}

	void UpdateMesh()
	{
		try
		{
			Debug.Log("Computig new trial data");
			mesh = new Mesh();
			mesh.vertices = vertices;
			mesh.triangles = vertexesIndexes;
		}
		catch (Exception ex)
		{
			Debug.LogError(ex);
		}
	}
}
