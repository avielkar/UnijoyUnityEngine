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
	Mesh _mesh;
	MeshRenderer _meshRenderer;
	Vector3[] _vertices;
	int[] _vertexesIndexes;
	private bool _newData = false;
	private bool _renderNewData = false;

	public Material material;

	private void Awake()
	{
		_mesh = new Mesh();
	}

	void HandelNewData(object sender, ISceneData e)
	{
		try
		{

			_vertices = e.ObjectsVertices.ToArray();
			_vertexesIndexes = new int[_vertices.Length];
			for(int i=0;i< _vertexesIndexes.Length; i++)
			{
				_vertexesIndexes[i] = i;
			}


			Debug.Log("Handling new trial data");

			_newData = true;
		}
		catch (Exception ex)
		{
			Debug.LogError($"Exception with {ex.ToString()}");
		}
	}

	private void HandleStartRenderCommand(object sender, EventArgs e)
	{
		_renderNewData = true;
	}

	// Use this for initialization
	void Start()
	{
		ScenesEventRegister.NewSceneReceivedRegistration(HandelNewData);
		ScenesEventRegister.StartRenderCommandReceivedRegistraion(HandleStartRenderCommand);

		gameObject.AddComponent<MeshFilter>();
		_meshRenderer = gameObject.AddComponent<MeshRenderer>();
		_meshRenderer.material = material;
		_mesh = new Mesh();
	}



	// Update is called once per frame
	void Update()
	{
		if(_newData)
		{
			UpdateMesh();
			_newData = false;
		}

		if(_renderNewData)
		{
			Debug.Log("Updating new trial data");

			GetComponent<MeshFilter>().mesh = _mesh;

			_renderNewData = false;
		}
	}

	void UpdateMesh()
	{
		try
		{
			Debug.Log("Computig new trial data");
			_mesh = new Mesh();
			_mesh.vertices = _vertices;
			_mesh.triangles = _vertexesIndexes;
		}
		catch (Exception ex)
		{
			Debug.LogError(ex);
		}
	}
}
