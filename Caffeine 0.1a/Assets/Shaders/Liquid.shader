// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:33304,y:32577,varname:node_3138,prsc:2|emission-6414-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32318,y:32555,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3897059,c2:0.1977074,c3:0.1604671,c4:1;n:type:ShaderForge.SFN_Fresnel,id:6879,x:32471,y:32922,varname:node_6879,prsc:2|NRM-9289-OUT,EXP-2608-OUT;n:type:ShaderForge.SFN_Posterize,id:3316,x:32529,y:33165,varname:node_3316,prsc:2|IN-6879-OUT,STPS-5504-OUT;n:type:ShaderForge.SFN_Vector1,id:5504,x:32609,y:33074,varname:node_5504,prsc:2,v1:1.3;n:type:ShaderForge.SFN_NormalVector,id:9289,x:32247,y:32851,prsc:2,pt:False;n:type:ShaderForge.SFN_Slider,id:2608,x:32105,y:33101,ptovrint:False,ptlb:Fresnel 1 Intensity,ptin:_Fresnel1Intensity,varname:node_2608,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.025641,max:10;n:type:ShaderForge.SFN_Blend,id:8103,x:32781,y:32789,varname:node_8103,prsc:2,blmd:6,clmp:True|SRC-7241-RGB,DST-3316-OUT;n:type:ShaderForge.SFN_Fresnel,id:3150,x:32324,y:33396,varname:node_3150,prsc:2|NRM-3583-OUT,EXP-3716-OUT;n:type:ShaderForge.SFN_Slider,id:3716,x:31943,y:33446,ptovrint:False,ptlb:Fresnel 2 Intensity,ptin:_Fresnel2Intensity,varname:node_3716,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:10;n:type:ShaderForge.SFN_Posterize,id:758,x:32578,y:33396,varname:node_758,prsc:2|IN-3150-OUT,STPS-4133-OUT;n:type:ShaderForge.SFN_Vector1,id:4133,x:32324,y:33547,varname:node_4133,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:6791,x:32827,y:33499,varname:node_6791,prsc:2|A-758-OUT,B-2418-RGB;n:type:ShaderForge.SFN_Color,id:2418,x:32578,y:33573,ptovrint:False,ptlb:node_2418,ptin:_node_2418,varname:node_2418,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6838235,c2:0.397221,c3:0.397221,c4:1;n:type:ShaderForge.SFN_Blend,id:6414,x:33003,y:32962,varname:node_6414,prsc:2,blmd:6,clmp:True|SRC-8103-OUT,DST-6791-OUT;n:type:ShaderForge.SFN_NormalVector,id:2914,x:31773,y:33615,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:3583,x:32100,y:33649,varname:node_3583,prsc:2|A-2914-OUT,B-3708-OUT;n:type:ShaderForge.SFN_ViewReflectionVector,id:3708,x:31676,y:33838,varname:node_3708,prsc:2;proporder:7241-2608-3716-2418;pass:END;sub:END;*/

Shader "Shader Forge/Liquid" {
    Properties {
        _Color ("Color", Color) = (0.3897059,0.1977074,0.1604671,1)
        _Fresnel1Intensity ("Fresnel 1 Intensity", Range(0, 10)) = 1.025641
        _Fresnel2Intensity ("Fresnel 2 Intensity", Range(0, 10)) = 1
        _node_2418 ("node_2418", Color) = (0.6838235,0.397221,0.397221,1)
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
            uniform float4 _Color;
            uniform float _Fresnel1Intensity;
            uniform float _Fresnel2Intensity;
            uniform float4 _node_2418;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
////// Emissive:
                float node_5504 = 1.3;
                float node_4133 = 2.0;
                float3 emissive = saturate((1.0-(1.0-saturate((1.0-(1.0-_Color.rgb)*(1.0-floor(pow(1.0-max(0,dot(i.normalDir, viewDirection)),_Fresnel1Intensity) * node_5504) / (node_5504 - 1)))))*(1.0-(floor(pow(1.0-max(0,dot((i.normalDir*viewReflectDirection), viewDirection)),_Fresnel2Intensity) * node_4133) / (node_4133 - 1)*_node_2418.rgb))));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
