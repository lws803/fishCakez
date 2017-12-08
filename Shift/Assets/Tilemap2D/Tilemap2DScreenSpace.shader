// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

/*
 * Copyright 2012 Sander Homan
 */


Shader "Tilemap/Tilemap2DScreenSpace" {
	Properties {
		_MainTex ("Tileset", 2D) = "black" {}
		_Tilemap ("Tilemap", 2D) = "black" {}
		_MapSize ("MapSize/tileCount", vector) = (0,0,0,0)
		_TilesetSize ("Size/Tilesize", vector) = (0,0,0,0)
		_Position ("Position",vector) = (0,0,0,0)
		_ScreenSize ("_ScreenSize", vector) = (0,0,0,0)
		_TileSize ("TileSize", vector) = (0,0,0,0)
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
			float4 _Position;
			float4 _ScreenSize;
			float4 _TileSize;
			
			struct Vin
			{
				float4 vertex : POSITION;
			};
			
			struct Vout
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};
			
			Vout vert(Vin vin)
			{
				Vout result;
				result.vertex = UnityObjectToClipPos(vin.vertex);
				result.uv = (result.vertex.xy+1)/2; // map it to 0/1 instead of -1/1
				if (frac(_Position.x) == 0) _Position.x+=0.001;
				result.uv = (result.uv * _ScreenSize.xy) / _TileSize.xy + _Position.xy;
				return result;
			}
			
			float4 frag(Vout vout) : COLOR
			{
				// get tile; tile.x and tile.y is the tileposition
				float4 tile = tex2D(_Tilemap, vout.uv/_MapSize.xy);
				float2 tileOffset = frac(vout.uv)/ _MapSize.zw;
				
				float2 bias = float2(0,0);
				//float2 bias = float2(-0.475, -0.475)/_TilesetSize.xy;
				
				//return tile;
				return tex2D(_MainTex, tile.xy + tileOffset+bias);
				//return float4(vout.texcoord.x, vout.texcoord.y,0,1);
			}
	
			
			ENDCG
		}
	} 
	FallBack "Diffuse"
}
