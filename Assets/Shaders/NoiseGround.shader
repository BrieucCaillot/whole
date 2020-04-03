﻿Shader "Custom/NoiseGround"
{
    Properties
    {
        _Tess ("Tessellation", Range(1,8)) = 4
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _NoiseScale ("Noise Scale", float) = 1
        _NoiseFrequency ("Noise Frequency", float) = 1
        _NoiseOffset ("Noise Offset", Vector) = (0,0,0,0)

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows tessellate:tess vertex:vert
 
        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
        
        #include "noiseSimplex.cginc"

        struct appData
        {
            float4 vertex : POSITION;
            float3 normal : NORMAL;
            float4 tangent : TANGENT;
            float2 texcoord : TEXCOORD0;
        };

        sampler2D _MainTex, _NormalMap;

        struct Input
        {
            float2 uv_MainTex;
        };

        float _Tess;
        float _NoiseFrequency, _NoiseScale;
        float4 _NoiseOffset;

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        float4 tess() 
        {
            return _Tess;
        }

        void vert(inout appData v) 
        {
            float3 v0 = v.vertex.xyz;
            float3 bitangent = cross(v.normal, v.tangent.xyz);
            float3 v1 = v0 + (v.tangent.xyz * 0.01);
            float3 v2 = v0 + (bitangent * 0.01);

            float ns0 = _NoiseScale * snoise(float3(v0.x + _NoiseOffset.x , v0.y + _NoiseOffset.y, v0.z + _NoiseOffset.z) * _NoiseFrequency);
            v0.xyz += ((ns0+1)/2) * v.normal;

            float ns1 = _NoiseScale * snoise(float3(v1.x + _NoiseOffset.x , v1.y + _NoiseOffset.y, v1.z + _NoiseOffset.z) * _NoiseFrequency);
            v1.xyz += ((ns1+1)/2) * v.normal;

            float ns2 = _NoiseScale * snoise(float3(v2.x + _NoiseOffset.x , v2.y + _NoiseOffset.y, v2.z + _NoiseOffset.z) * _NoiseFrequency);
            v2.xyz += ((ns2+1)/2) * v.normal;

            float3 vn = cross(v2-v0,v1-v0);

            v.normal = normalize(-vn);
            v.vertex.xyz = v0;
        }
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_MainTex));
        }
        ENDCG
    }
    FallBack "Diffuse"
}
