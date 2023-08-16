Shader "Custom/Hologram"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _RimColor("RimColor",Color) = (1,1,1,1)
        _RimPower("RimPower", Range(1, 10)) = 5
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" "Queue" = "Transparent" }
            LOD 200

            CGPROGRAM
            #pragma surface surf Standard Lambert noambient alpha:fade

            sampler2D _MainTex;
            float4 _RimColor;
            float _RimPower;

            struct Input 
            {
                float2 uv_MainTex;
                float3 viewDir;
                float3 worldPos;
            };


            UNITY_INSTANCING_BUFFER_START(Props)

            UNITY_INSTANCING_BUFFER_END(Props)

            void surf(Input IN, inout SurfaceOutputStandard o)
            {
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
                //o.Albedo = c.rgb;
                float rim = saturate(dot(o.Normal, IN.viewDir));
                //rim = pow(1 - rim, _RimPower) + pow(frac(IN.worldPos.y));
                rim = pow(1 - rim, _RimPower);
                o.Emission = _RimColor;
                //o.Emission = IN.worldPos.g;
                o.Alpha = rim;
            }
            ENDCG
        }
        Fallback "Diffuse"
}
