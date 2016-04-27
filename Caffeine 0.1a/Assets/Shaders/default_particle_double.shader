// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:9361,x:33234,y:32679,varname:node_9361,prsc:2|emission-7988-OUT,clip-2681-A;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:32103,y:32479,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_Color,id:1904,x:32103,y:32650,ptovrint:False,ptlb:node_1904,ptin:_node_1904,varname:node_1904,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4232267,c2:0.5139363,c3:0.5588235,c4:1;n:type:ShaderForge.SFN_Blend,id:7988,x:32573,y:32563,varname:node_7988,prsc:2,blmd:1,clmp:True|SRC-4900-OUT,DST-21-OUT;n:type:ShaderForge.SFN_Tex2d,id:2681,x:32509,y:32324,ptovrint:False,ptlb:node_2681,ptin:_node_2681,varname:node_2681,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9393f83272ff7491e81340575991ff97,ntxv:0,isnm:False|UVIN-5057-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5057,x:32297,y:32206,varname:node_5057,prsc:2,uv:0;n:type:ShaderForge.SFN_Max,id:21,x:32301,y:32583,varname:node_21,prsc:2|A-1904-RGB,B-8068-OUT;n:type:ShaderForge.SFN_Blend,id:4900,x:32903,y:32285,varname:node_4900,prsc:2,blmd:10,clmp:True|SRC-3340-RGB,DST-2681-RGB;n:type:ShaderForge.SFN_Color,id:3340,x:32688,y:32126,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_3340,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4779412,c2:0.4779412,c3:0.4779412,c4:1;proporder:1904-2681-3340;pass:END;sub:END;*/

Shader "Shader Forge/default_particle_double" {
    Properties {
        _node_1904 ("node_1904", Color) = (0.4232267,0.5139363,0.5588235,1)
        _node_2681 ("node_2681", 2D) = "white" {}
        _Tint ("Tint", Color) = (0.4779412,0.4779412,0.4779412,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _node_1904;
            uniform sampler2D _node_2681; uniform float4 _node_2681_ST;
            uniform float4 _Tint;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                LIGHTING_COORDS(1,2)
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                float4 _node_2681_var = tex2D(_node_2681,TRANSFORM_TEX(i.uv0, _node_2681));
                clip(_node_2681_var.a - 0.5);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float3 emissive = saturate((saturate(( _node_2681_var.rgb > 0.5 ? (1.0-(1.0-2.0*(_node_2681_var.rgb-0.5))*(1.0-_Tint.rgb)) : (2.0*_node_2681_var.rgb*_Tint.rgb) ))*max(_node_1904.rgb,attenuation)));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _node_1904;
            uniform sampler2D _node_2681; uniform float4 _node_2681_ST;
            uniform float4 _Tint;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                LIGHTING_COORDS(1,2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                float4 _node_2681_var = tex2D(_node_2681,TRANSFORM_TEX(i.uv0, _node_2681));
                clip(_node_2681_var.a - 0.5);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 finalColor = 0;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _node_2681; uniform float4 _node_2681_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                float4 _node_2681_var = tex2D(_node_2681,TRANSFORM_TEX(i.uv0, _node_2681));
                clip(_node_2681_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
