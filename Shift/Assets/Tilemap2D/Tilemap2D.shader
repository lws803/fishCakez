// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

/*
 * Copyright 2012 Sander Homan
 */

Shader "Tilemap/Tilemap2D" {
	Properties {
		_MainTex ("Tileset", 2D) = "black" {}
		_Tilemap ("Tilemap", 2D) = "black" {}
		_MapSize ("MapSize/tileCount", vector) = (0,0,0,0)
		_TilesetSize ("Size/Tilesize", vector) = (0,0,0,0)
		
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
			
			struct Vin
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};
			
			struct Vout
			{
				float4 vertex : SV_POSITION;
				float2 texcoord : TEXCOORD0;
			};
			
			Vout vert(Vin vin)
			{
				Vout result;
				result.vertex = UnityObjectToClipPos(vin.vertex);
				result.texcoord = vin.texcoord;
				return result;
			}
			
			float4 frag(Vout vout) : COLOR
			{
				// get tile; tile.x and tile.y is the tileposition
				float4 tile = tex2D(_Tilemap, vout.texcoord);
				
				//float2 tileOffset = float2(fmod(vout.texcoord.x,1/_TilesetSize.x)*_MapSize.z,fmod(vout.texcoord.y,1/_TilesetSize.y)*_MapSize.w);
				
				float2 tileOffset = frac(vout.texcoord * _MapSize.xy) / _TilesetSize.zw;
				
				float2 bias = float2(-0.001, 0);
				
				//return tex2D(_MainTex, tile.xy);
				return tex2D(_MainTex, tile.xy + tileOffset+bias);
			}
	
			
			ENDCG
		}
	} 
	FallBack "Diffuse"
}
