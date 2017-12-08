/*
 * Copyright 2012 Sander Homan
 */

using UnityEngine;
using System.Collections;

public class Tilemap2D : MonoBehaviour {
	
	public Vector2 size;
	public Vector2 tileSize;
	public Texture2D tilesetTexture;
	
	private const int MAX_ANIM_LENGTH = 1;
	private const int MAX_ANIM_FRAMERATE = 1;
	
	public Vector3 orthoSize;
	
	// Use this for initialization
	void Start () {
		
		// color layout
		// r: x index
		// g: y index
		// b: animation length
		// a: animation framerate
		
		// TODO make size square and power of 2
		
		// create texture from data
		Texture2D texture = new Texture2D((int)size.x, (int)size.y, TextureFormat.ARGB32, false);
		texture.filterMode = FilterMode.Point;
		Vector2 tileCount = new Vector2(tilesetTexture.width/tileSize.x,tilesetTexture.height/tileSize.y);
		for (int i=0; i<size.x; i++)
		{
			for (int j=0; j<size.y; j++)
			{
				texture.SetPixel(i,j, new Color(0,0,1/MAX_ANIM_LENGTH, 1/MAX_ANIM_FRAMERATE));
				if (i==5) texture.SetPixel(i,j, new Color(1/tileCount.x,0/tileCount.y,1/MAX_ANIM_LENGTH, 1/MAX_ANIM_FRAMERATE));
				if (j==5) texture.SetPixel(i,j, new Color(2/tileCount.x,0/tileCount.y,1/MAX_ANIM_LENGTH, 1/MAX_ANIM_FRAMERATE));
			}
		}
		
		texture.Apply();
		
		// set shader properties
		renderer.material.SetTexture("_MainTex", tilesetTexture);
		renderer.material.SetTexture("_Tilemap", texture);
		renderer.material.SetVector("_TilesetSize",new Vector4(tilesetTexture.width, tilesetTexture.height, tileSize.x, tileSize.y));
		renderer.material.SetVector("_MapSize",new Vector4(size.x, size.y,tileCount.x,tileCount.y));
		
		
		// create projection matrix
		Matrix4x4 projection = new Matrix4x4();
		projection.m00 = orthoSize.x / Screen.width;
		projection.m11 = orthoSize.y / Screen.height;
		projection.m22 = -orthoSize.z / (Camera.main.far-Camera.main.near);
		projection.m33 = 1;
		projection.m03 = -Screen.width/2;
		projection.m13 = -Screen.height/2;
		projection.m23 = -(Camera.main.far-Camera.main.near)/2;
		renderer.material.SetMatrix("_OrthoMatrix",projection);
	}
	
	// Update is called once per frame
	void Update () {
		// update texture if necessary
	}
}


