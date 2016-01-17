// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:True,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:2865,x:32719,y:32712,varname:node_2865,prsc:2|emission-5660-OUT,custl-1558-OUT,alpha-7189-OUT;n:type:ShaderForge.SFN_Slider,id:9206,x:31147,y:33063,ptovrint:False,ptlb:Draw Distance,ptin:_DrawDistance,varname:node_9206,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Color,id:5173,x:31832,y:32362,ptovrint:False,ptlb:Base Color,ptin:_BaseColor,varname:node_5173,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4779412,c2:0.4872211,c3:0.5,c4:1;n:type:ShaderForge.SFN_FragmentPosition,id:8851,x:31209,y:32703,varname:node_8851,prsc:2;n:type:ShaderForge.SFN_ViewPosition,id:8888,x:31209,y:32848,varname:node_8888,prsc:2;n:type:ShaderForge.SFN_Distance,id:5777,x:31503,y:32813,varname:node_5777,prsc:2|A-8851-XYZ,B-8888-XYZ;n:type:ShaderForge.SFN_Power,id:7778,x:31788,y:32988,varname:node_7778,prsc:2|VAL-5777-OUT,EXP-9206-OUT;n:type:ShaderForge.SFN_RemapRange,id:9404,x:32049,y:32971,varname:node_9404,prsc:2,frmn:-10,frmx:10,tomn:0,tomx:1|IN-7778-OUT;n:type:ShaderForge.SFN_Subtract,id:7189,x:32280,y:33025,varname:node_7189,prsc:2|A-9404-OUT,B-6252-OUT;n:type:ShaderForge.SFN_Fresnel,id:1056,x:31902,y:33168,varname:node_1056,prsc:2|NRM-4758-OUT,EXP-7942-OUT;n:type:ShaderForge.SFN_OneMinus,id:6252,x:32074,y:33168,varname:node_6252,prsc:2|IN-1056-OUT;n:type:ShaderForge.SFN_NormalVector,id:4758,x:31596,y:33169,prsc:2,pt:True;n:type:ShaderForge.SFN_Slider,id:7942,x:31449,y:33360,ptovrint:False,ptlb:Edge Sharpness,ptin:_EdgeSharpness,varname:node_7942,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:15,cur:1,max:0;n:type:ShaderForge.SFN_Multiply,id:5660,x:32200,y:32552,varname:node_5660,prsc:2|A-5173-RGB,B-6623-OUT;n:type:ShaderForge.SFN_Max,id:6623,x:31917,y:32578,varname:node_6623,prsc:2|A-3665-OUT,B-3130-RGB;n:type:ShaderForge.SFN_Color,id:3130,x:31706,y:32676,ptovrint:False,ptlb:Shadow Color,ptin:_ShadowColor,varname:node_3130,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7867647,c2:0.4396626,c3:0.5904725,c4:1;n:type:ShaderForge.SFN_LightAttenuation,id:3665,x:31588,y:32494,varname:node_3665,prsc:2;n:type:ShaderForge.SFN_Fresnel,id:1558,x:32278,y:32819,varname:node_1558,prsc:2;proporder:9206-5173-7942-3130;pass:END;sub:END;*/

Shader "Shader Forge/AlphaXDistance" {
    Properties {
        _DrawDistance ("Draw Distance", Range(0, 5)) = 0
        _BaseColor ("Base Color", Color) = (0.4779412,0.4872211,0.5,1)
        _EdgeSharpness ("Edge Sharpness", Range(15, 0)) = 1
        _ShadowColor ("Shadow Color", Color) = (0.7867647,0.4396626,0.5904725,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _DrawDistance;
            uniform float4 _BaseColor;
            uniform float _EdgeSharpness;
            uniform float4 _ShadowColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
                float attenuation = 1;
////// Emissive:
                float3 emissive = (_BaseColor.rgb*max(attenuation,_ShadowColor.rgb));
                float node_1558 = (1.0-max(0,dot(normalDirection, viewDirection)));
                float3 finalColor = emissive + float3(node_1558,node_1558,node_1558);
                fixed4 finalRGBA = fixed4(finalColor,((pow(distance(i.posWorld.rgb,_WorldSpaceCameraPos),_DrawDistance)*0.05+0.5)-(1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_EdgeSharpness))));
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
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _DrawDistance;
            uniform float4 _BaseColor;
            uniform float _EdgeSharpness;
            uniform float4 _ShadowColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_1558 = (1.0-max(0,dot(normalDirection, viewDirection)));
                float3 finalColor = float3(node_1558,node_1558,node_1558);
                return fixed4(finalColor * ((pow(distance(i.posWorld.rgb,_WorldSpaceCameraPos),_DrawDistance)*0.05+0.5)-(1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),_EdgeSharpness))),0);
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _BaseColor;
            uniform float4 _ShadowColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
/////// Vectors:
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                o.Emission = (_BaseColor.rgb*max(attenuation,_ShadowColor.rgb));
                
                float3 diffColor = float3(0,0,0);
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
