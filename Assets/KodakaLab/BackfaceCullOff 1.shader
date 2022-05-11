// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "BackfaceCullOff 1"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_Albedo("Albedo", 2D) = "white" {}
		[Normal]_Normal("Normal", 2D) = "bump" {}
		_albedo("albedo", Float) = 0.95
		_NormalIntensity("NormalIntensity", Float) = 1
		[HideInInspector] _texcoord("", 2D) = "white" {}
		[HideInInspector] __dirty("", Int) = 1
	}

		SubShader
		{
			Tags{ "RenderType" = "Opaque"  "Queue" = "transparent" }
			Cull Off
			CGPROGRAM
			#include "UnityStandardUtils.cginc"
			#pragma target 3.0
			#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
			struct Input
			{
				float2 uv_texcoord;
			};

			uniform sampler2D _Normal;
			uniform float4 _Normal_ST;
			uniform float _NormalIntensity;
			uniform sampler2D _Albedo;
			uniform float4 _Albedo_ST;
			uniform float _albedo;
			fixed4 _Color;

			void surf(Input i , inout SurfaceOutputStandard o)
			{
				float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
				o.Normal = UnpackScaleNormal(tex2D(_Normal, uv_Normal), _NormalIntensity);
				float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
				float4 lerpResult9 = lerp(float4(0,0,0,0) , tex2D(_Albedo, uv_Albedo) , _albedo);
				o.Albedo = lerpResult9.rgb * _Color;
				o.Metallic = 0.1;
				o.Smoothness = 0.8;
				o.Alpha = 1;
			}

			ENDCG
		}
			Fallback "Diffuse"
				//CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18912
-1920;134;1920;1005;1379.46;570.8678;1;True;True
Node;AmplifyShaderEditor.TexturePropertyNode;3;-934.7543,-367.5199;Inherit;True;Property;_Albedo;Albedo;0;0;Create;True;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.SamplerNode;4;-698.8177,-370.0948;Inherit;True;Property;_TextureSample1;Texture Sample 1;2;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;24;-455.675,-480.6987;Inherit;False;Property;_albedo;albedo;2;0;Create;True;0;0;0;False;0;False;0.95;0.95;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;51;-821.4604,116.1322;Inherit;False;Property;_NormalIntensity;NormalIntensity;3;0;Create;True;0;0;0;False;0;False;1;0.95;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TexturePropertyNode;20;-922.675,-106.6987;Inherit;True;Property;_Normal;Normal;1;1;[Normal];Create;True;0;0;0;False;0;False;None;None;False;bump;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.RangedFloatNode;8;-329.2109,258.9407;Inherit;False;Constant;_Smoothness;Smoothness;3;0;Create;True;0;0;0;False;0;False;0.8;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;7;-337.7224,173.8311;Inherit;False;Constant;_Metallic;Metallic;3;0;Create;True;0;0;0;False;0;False;0.1;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;9;-305.743,-384.7077;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0.9528302;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;45;-656.4604,-107.8678;Inherit;True;Property;_TextureSample0;Texture Sample 0;5;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;25,-200;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;BackfaceCullOff;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;4;0;3;0
WireConnection;9;1;4;0
WireConnection;9;2;24;0
WireConnection;45;0;20;0
WireConnection;45;5;51;0
WireConnection;0;0;9;0
WireConnection;0;1;45;0
WireConnection;0;3;7;0
WireConnection;0;4;8;0
ASEEND*/
//CHKSM=49C0D947E877A83F91AD0E284CE8D7EAEC7DAE87