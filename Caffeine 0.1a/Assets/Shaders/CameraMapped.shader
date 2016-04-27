// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:33100,y:32728,varname:node_3138,prsc:2|emission-7820-OUT;n:type:ShaderForge.SFN_Tex2d,id:2209,x:32391,y:32785,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_2209,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:673faf023b0d9492ba37bf59b95d5fe6,ntxv:0,isnm:False|UVIN-3575-UVOUT;n:type:ShaderForge.SFN_ScreenPos,id:3575,x:32166,y:32785,varname:node_3575,prsc:2,sctp:2;n:type:ShaderForge.SFN_Multiply,id:2654,x:32629,y:32904,varname:node_2654,prsc:2|A-2209-RGB,B-8998-RGB;n:type:ShaderForge.SFN_Color,id:8998,x:32391,y:33016,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_8998,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Blend,id:2547,x:32629,y:33089,varname:node_2547,prsc:2,blmd:1,clmp:True|SRC-7077-OUT,DST-2410-RGB;n:type:ShaderForge.SFN_Fresnel,id:8256,x:32119,y:33226,varname:node_8256,prsc:2|NRM-6264-OUT,EXP-6685-OUT;n:type:ShaderForge.SFN_Slider,id:6685,x:31733,y:33223,ptovrint:False,ptlb:node_6685,ptin:_node_6685,varname:node_6685,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:20;n:type:ShaderForge.SFN_NormalVector,id:6264,x:31890,y:33336,prsc:2,pt:True;n:type:ShaderForge.SFN_Color,id:2410,x:32376,y:33412,ptovrint:False,ptlb:node_2410,ptin:_node_2410,varname:node_2410,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7172362,c2:0.9852941,c3:0.952018,c4:1;n:type:ShaderForge.SFN_Blend,id:7820,x:32818,y:32959,varname:node_7820,prsc:2,blmd:6,clmp:True|SRC-2654-OUT,DST-2547-OUT;n:type:ShaderForge.SFN_Posterize,id:7077,x:32360,y:33226,varname:node_7077,prsc:2|IN-8256-OUT,STPS-3075-OUT;n:type:ShaderForge.SFN_Vector1,id:3075,x:32178,y:33388,varname:node_3075,prsc:2,v1:3;proporder:2209-8998-6685-2410;pass:END;sub:END;*/

Shader "Effects/CameraMapped" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _Tint ("Tint", Color) = (0.5,0.5,0.5,1)
        _node_6685 ("node_6685", Range(0, 20)) = 2
        _node_2410 ("node_2410", Color) = (0.7172362,0.9852941,0.952018,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Tint;
            uniform float _node_6685;
            uniform float4 _node_2410;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 screenPos : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(sceneUVs.rg, _MainTex));
                float node_3075 = 3.0;
                float3 emissive = saturate((1.0-(1.0-(_MainTex_var.rgb*_Tint.rgb))*(1.0-saturate((floor(pow(1.0-max(0,dot(normalDirection, viewDirection)),_node_6685) * node_3075) / (node_3075 - 1)*_node_2410.rgb)))));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
