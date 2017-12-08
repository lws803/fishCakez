// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

/*
 * Copyright 2012 Sander Homan
 */


Shader "Tilemap/Tilemap2DWorldCoord" {
	Properties {
		_MainTex ("Tileset", 2D) = "black" {}
		_Tilemap ("Tilemap", 2D) = "black" {}
		_MapSize ("MapSize/tileCount", vector) = (0,0,0,0)
		_TilesetSize ("Size/Tilesize", vector) = (0,0,0,0)
		_OrthoSize ("Ortho Size",vector) = (0,0,0,0)
		_OrthoSize2 ("Ortho Size2",vector) = (0,0,0,0)
		//_OrthoMatrix ("Ortho Matrix", Matrix) = ((0,0,0,0),(0,0,0,0),(0,0,0,0),(0,0,0,0))
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		pass
		{
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
	
			sampler2D _MainTex;
			sampler2D _Tilemap;
			float4 _MapSize;
			float4 _TilesetSize;
			float4 _OrthoSize;
			float4 _OrthoSize2;
			uniform float4x4 _OrthoMatrix;
			
			struct Vin
			{
				float4 vertex : POSITION;
			};
			
			struct Vout
			{
				float4 vertex : SV_POSITION;
				float2 texcoord : TEXCOORD0;
			};
			
			Vout vert(Vin vin)
			{
				Vout result;
				//float4x4 projection;
				/*projection[0][0] = _OrthoSize.x / _OrthoSize.w-_OrthoSize.z;
				projection[1][1] = _OrthoSize.y / _OrthoSize2.y-_OrthoSize2.x;;
				projection[2][2] = 1;
				projection[3][3] = 1;
				projection[0][3] = 1;
				projection[1][3] = 1;
				projection[2][3] = 1;*/
				//projection = mul(UNITY_MATRIX_MV, _OrthoMatrix);
				result.vertex = UnityObjectToClipPos(vin.vertex);
				result.texcoord = mul(unity_ObjectToWorld, vin.vertex).xz / _TilesetSize.zw;
				return result;
			}
			
			float4 frag(Vout vout) : COLOR
			{
				// get tile; tile.x and tile.y is the tileposition
				float4 tile = tex2D(_Tilemap, vout.texcoord);
				
				//float2 tileOffset = float2(fmod(vout.texcoord.x,1/_TilesetSize.x)*_MapSize.z,fmod(vout.texcoord.y,1/_TilesetSize.y)*_MapSize.w);
				
				float2 tileOffset = frac(vout.texcoord * _MapSize.xy) / _TilesetSize.zw;
				
				//float2 bias = float2(0,0);
				float2 bias = float2(-0.001, 0);
				
				//return tex2D(_MainTex, tile.xy);
				return tex2D(_MainTex, tile.xy + tileOffset+bias);
			}
	
			
			ENDCG
		}
	} 
	FallBack "Diffuse"
}
