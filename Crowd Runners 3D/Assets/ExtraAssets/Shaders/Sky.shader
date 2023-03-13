Shader "Custom/Sky" {
    Properties {
        _MainTex ("Sky Texture", 2D) = "white" {}
        _SkyTint ("Sky Tint", Color) = (1,1,1,1)
        _CloudTint ("Cloud Tint", Color) = (1,1,1,1)
        _Exposure ("Exposure", Range(0.1, 10.0)) = 1.0
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float4 texcoord : TEXCOORD0;
            };

            v2f vert (appdata v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }

            sampler2D _MainTex;
            float _Exposure;
            float4 _SkyTint;
            float4 _CloudTint;

            fixed4 frag (v2f i) : SV_Target {
                float3 texel = tex2D(_MainTex, i.texcoord.xy).rgb;
                float3 skyColor = texel * _SkyTint.rgb;
                float3 cloudColor = texel * _CloudTint.rgb;
                float4 finalColor = lerp(float4(skyColor, 1.0), float4(cloudColor, 1.0), texel.b);
                finalColor.rgb = pow(finalColor.rgb, 1.0 / _Exposure);
                return finalColor;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}