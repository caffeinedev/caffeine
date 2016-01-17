// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:0,nrsp:1,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:34397,y:32220,varname:node_3138,prsc:2|normal-6216-OUT,emission-4173-OUT,custl-8648-OUT;n:type:ShaderForge.SFN_Tex2d,id:1342,x:33483,y:32203,ptovrint:False,ptlb:node_1342,ptin:_node_1342,varname:node_1342,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:23ae31268fd59423f9578178e79d9f8e,ntxv:3,isnm:True|UVIN-5576-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:877,x:33029,y:32224,varname:node_877,prsc:2,uv:0;n:type:ShaderForge.SFN_NormalVector,id:7841,x:32512,y:33074,prsc:2,pt:True;n:type:ShaderForge.SFN_Fresnel,id:1053,x:33414,y:32589,varname:node_1053,prsc:2|NRM-5119-OUT,EXP-6356-OUT;n:type:ShaderForge.SFN_Slider,id:6356,x:33032,y:32863,ptovrint:False,ptlb:Fresnel 2 Intensity,ptin:_Fresnel2Intensity,varname:node_6356,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:1.676923,max:10;n:type:ShaderForge.SFN_Multiply,id:2138,x:33631,y:32825,varname:node_2138,prsc:2|A-6416-OUT,B-5644-RGB,C-2673-OUT;n:type:ShaderForge.SFN_Color,id:5644,x:33239,y:33008,ptovrint:False,ptlb:Fresnel Tint 1,ptin:_FresnelTint1,varname:node_5644,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4314446,c2:0.5482818,c3:0.5588235,c4:1;n:type:ShaderForge.SFN_Posterize,id:6416,x:33550,y:32696,varname:node_6416,prsc:2|IN-1053-OUT,STPS-3537-OUT;n:type:ShaderForge.SFN_Color,id:965,x:33747,y:32440,ptovrint:False,ptlb:node_965,ptin:_node_965,varname:node_965,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9264706,c2:0.7493512,c3:0.7493512,c4:1;n:type:ShaderForge.SFN_Blend,id:8648,x:34170,y:32697,varname:node_8648,prsc:2,blmd:6,clmp:True|SRC-2138-OUT,DST-8502-OUT;n:type:ShaderForge.SFN_Fresnel,id:5413,x:33472,y:33082,varname:node_5413,prsc:2|NRM-5119-OUT,EXP-7209-OUT;n:type:ShaderForge.SFN_Color,id:7341,x:33472,y:33287,ptovrint:False,ptlb:Fresnel Tint 2,ptin:_FresnelTint2,varname:node_7341,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9338235,c2:0.4737781,c3:0.4737781,c4:1;n:type:ShaderForge.SFN_Multiply,id:2746,x:33975,y:32990,varname:node_2746,prsc:2|A-7817-OUT,B-7341-RGB;n:type:ShaderForge.SFN_Slider,id:7209,x:33062,y:33246,ptovrint:False,ptlb:Frenel 2 Intensity,ptin:_Frenel2Intensity,varname:node_7209,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.7606843,max:10;n:type:ShaderForge.SFN_Posterize,id:7817,x:33727,y:33097,varname:node_7817,prsc:2|IN-5413-OUT,STPS-3865-OUT;n:type:ShaderForge.SFN_Panner,id:5576,x:32774,y:32224,varname:node_5576,prsc:2,spu:0,spv:0.5|UVIN-877-UVOUT,DIST-3289-OUT;n:type:ShaderForge.SFN_Panner,id:3557,x:32774,y:32370,varname:node_3557,prsc:2,spu:0,spv:0.2|UVIN-877-UVOUT,DIST-3591-OUT;n:type:ShaderForge.SFN_Slider,id:9835,x:32350,y:32466,ptovrint:False,ptlb:pan 1,ptin:_pan1,varname:node_9835,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.2307692,max:1;n:type:ShaderForge.SFN_Slider,id:623,x:32097,y:32833,ptovrint:False,ptlb:pan 2,ptin:_pan2,varname:node_623,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.07692305,max:1;n:type:ShaderForge.SFN_Tex2d,id:4166,x:33474,y:32414,ptovrint:False,ptlb:node_4166,ptin:_node_4166,varname:node_4166,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:23ae31268fd59423f9578178e79d9f8e,ntxv:3,isnm:True|UVIN-3557-UVOUT;n:type:ShaderForge.SFN_Time,id:7455,x:32291,y:32606,varname:node_7455,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3289,x:32569,y:32572,varname:node_3289,prsc:2|A-9835-OUT,B-7455-T;n:type:ShaderForge.SFN_Multiply,id:3591,x:32569,y:32754,varname:node_3591,prsc:2|A-623-OUT,B-7455-TDB;n:type:ShaderForge.SFN_NormalBlend,id:6216,x:33772,y:32230,varname:node_6216,prsc:2|BSE-1342-RGB,DTL-4166-RGB;n:type:ShaderForge.SFN_Vector1,id:3537,x:33711,y:32978,varname:node_3537,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:3865,x:33686,y:33287,varname:node_3865,prsc:2,v1:2;n:type:ShaderForge.SFN_Clamp01,id:8502,x:34178,y:33025,varname:node_8502,prsc:2|IN-2746-OUT;n:type:ShaderForge.SFN_Vector1,id:2673,x:33506,y:32950,varname:node_2673,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:5119,x:33000,y:32644,varname:node_5119,prsc:2|A-9197-OUT,B-8338-OUT,C-6323-OUT;n:type:ShaderForge.SFN_LightVector,id:2358,x:32512,y:32945,varname:node_2358,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4173,x:34189,y:32430,varname:node_4173,prsc:2|A-965-RGB,B-188-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:1598,x:33747,y:32588,varname:node_1598,prsc:2;n:type:ShaderForge.SFN_ViewVector,id:6323,x:32765,y:32754,varname:node_6323,prsc:2;n:type:ShaderForge.SFN_Dot,id:9197,x:32870,y:32984,varname:node_9197,prsc:2,dt:2|A-7841-OUT,B-2358-OUT;n:type:ShaderForge.SFN_ViewReflectionVector,id:8338,x:32765,y:32534,varname:node_8338,prsc:2;n:type:ShaderForge.SFN_Max,id:188,x:33990,y:32525,varname:node_188,prsc:2|A-1598-OUT,B-5990-RGB;n:type:ShaderForge.SFN_Color,id:5990,x:33766,y:32729,ptovrint:False,ptlb:Shadow Color,ptin:_ShadowColor,varname:node_5990,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7426471,c2:0.9254564,c3:1,c4:1;n:type:ShaderForge.SFN_ViewPosition,id:3287,x:32765,y:32644,varname:node_3287,prsc:2;proporder:1342-6356-5644-965-7341-7209-9835-623-4166-5990;pass:END;sub:END;*/

Shader "Water/CameraBasedWater" {
    Properties {
        _node_1342 ("node_1342", 2D) = "bump" {}
        _Fresnel2Intensity ("Fresnel 2 Intensity", Range(0.1, 10)) = 1.676923
        _FresnelTint1 ("Fresnel Tint 1", Color) = (0.4314446,0.5482818,0.5588235,1)
        _node_965 ("node_965", Color) = (0.9264706,0.7493512,0.7493512,1)
        _FresnelTint2 ("Fresnel Tint 2", Color) = (0.9338235,0.4737781,0.4737781,1)
        _Frenel2Intensity ("Frenel 2 Intensity", Range(0.1, 10)) = 0.7606843
        _pan1 ("pan 1", Range(-1, 1)) = 0.2307692
        _pan2 ("pan 2", Range(-1, 1)) = 0.07692305
        _node_4166 ("node_4166", 2D) = "bump" {}
        _ShadowColor ("Shadow Color", Color) = (0.7426471,0.9254564,1,1)
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
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _node_1342; uniform float4 _node_1342_ST;
            uniform float _Fresnel2Intensity;
            uniform float4 _FresnelTint1;
            uniform float4 _node_965;
            uniform float4 _FresnelTint2;
            uniform float _Frenel2Intensity;
            uniform float _pan1;
            uniform float _pan2;
            uniform sampler2D _node_4166; uniform float4 _node_4166_ST;
            uniform float4 _ShadowColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 recipObjScale = float3( length(_World2Object[0].xyz), length(_World2Object[1].xyz), length(_World2Object[2].xyz) );
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_7455 = _Time + _TimeEditor;
                float2 node_5576 = (i.uv0+(_pan1*node_7455.g)*float2(0,0.5));
                float3 _node_1342_var = UnpackNormal(tex2D(_node_1342,TRANSFORM_TEX(node_5576, _node_1342)));
                float2 node_3557 = (i.uv0+(_pan2*node_7455.b)*float2(0,0.2));
                float3 _node_4166_var = UnpackNormal(tex2D(_node_4166,TRANSFORM_TEX(node_3557, _node_4166)));
                float3 node_6216_nrm_base = _node_1342_var.rgb + float3(0,0,1);
                float3 node_6216_nrm_detail = _node_4166_var.rgb * float3(-1,-1,1);
                float3 node_6216_nrm_combined = node_6216_nrm_base*dot(node_6216_nrm_base, node_6216_nrm_detail)/node_6216_nrm_base.z - node_6216_nrm_detail;
                float3 node_6216 = node_6216_nrm_combined;
                float3 normalLocal = node_6216;
                float3 normalDirection = mul( _World2Object, float4(normalLocal,0)) / recipObjScale;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float3 emissive = (_node_965.rgb*max(attenuation,_ShadowColor.rgb));
                float3 node_5119 = (min(0,dot(normalDirection,lightDirection))*viewReflectDirection*viewDirection);
                float node_3537 = 2.0;
                float node_3865 = 2.0;
                float3 finalColor = emissive + saturate((1.0-(1.0-(floor(pow(1.0-max(0,dot(node_5119, viewDirection)),_Fresnel2Intensity) * node_3537) / (node_3537 - 1)*_FresnelTint1.rgb*0.5))*(1.0-saturate((floor(pow(1.0-max(0,dot(node_5119, viewDirection)),_Frenel2Intensity) * node_3865) / (node_3865 - 1)*_FresnelTint2.rgb)))));
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
