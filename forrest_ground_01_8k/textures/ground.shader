Shader "Custom/ground"{
    Properties{
        _MixColor ("MixCol", Color) = (1,1,1,1)
        _Color ("MainCol", Color) = (1,1,1,1)
        _SecColor ("SecCol", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _SecondaryTex ("SecAlbedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _TopBrightness ("Y-SPLIT", Range(-100,100)) = 0.0
        _Blur ("Blur", Range(0,20)) = 0.0
    } SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows
        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0
        sampler2D _MainTex;
        sampler2D _SecondaryTex;
        struct Input{
            float2 uv_MainTex;
            float3 worldPos;
        };
        half _Glossiness;
        half _Metallic;
        half _Blur;
        half _TopBrightness;
        fixed4 _MixColor;
        fixed4 _Color;
        fixed4 _SecColor;
        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)
        void surf (Input IN, inout SurfaceOutputStandard o){
            fixed4 c = _Color;
            float3 localPos = IN.worldPos - mul(unity_ObjectToWorld, float4(0,0,0,1)).xyz;
            // Albedo comes from a texture tinted by color
            if (localPos.y >= _TopBrightness){
                c = tex2D (_SecondaryTex, IN.uv_MainTex) * _SecColor;
            }else{
                c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            }
            
            fixed4 MainCol = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 SecCol = tex2D (_SecondaryTex, IN.uv_MainTex) * _SecColor;
            if (localPos.y < _TopBrightness + _Blur && localPos.y > _TopBrightness){
                c += _MixColor;
            }
            
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }ENDCG
    }FallBack "Diffuse"
}
