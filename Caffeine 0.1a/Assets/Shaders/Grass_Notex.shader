// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:32829,y:32565,varname:node_3138,prsc:2|normal-5669-RGB,emission-5854-OUT,custl-6921-OUT;n:type:ShaderForge.SFN_Tex2d,id:5669,x:31926,y:32728,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:node_5669,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5a252c182ff354a8b99f9a72de6f9fc0,ntxv:3,isnm:True|UVIN-4927-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:4927,x:31666,y:32625,varname:node_4927,prsc:2,uv:0;n:type:ShaderForge.SFN_Fresnel,id:1238,x:31735,y:32984,varname:node_1238,prsc:2|NRM-2636-OUT,EXP-4749-OUT;n:type:ShaderForge.SFN_Power,id:9769,x:31926,y:32984,varname:node_9769,prsc:2|VAL-1238-OUT,EXP-6253-OUT;n:type:ShaderForge.SFN_Vector1,id:6253,x:31735,y:33123,varname:node_6253,prsc:2,v1:5;n:type:ShaderForge.SFN_Slider,id:4749,x:31369,y:33008,ptovrint:False,ptlb:Fresnel Intensity,ptin:_FresnelIntensity,varname:node_4749,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:4.794872,max:15;n:type:ShaderForge.SFN_Blend,id:5011,x:32143,y:32984,varname:node_5011,prsc:2,blmd:1,clmp:True|SRC-9769-OUT,DST-8066-RGB;n:type:ShaderForge.SFN_Color,id:8066,x:31926,y:33147,ptovrint:False,ptlb:node_8066,ptin:_node_8066,varname:node_8066,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7783976,c2:1,c3:0.1544118,c4:1;n:type:ShaderForge.SFN_Fresnel,id:2049,x:31735,y:33359,varname:node_2049,prsc:2|NRM-2636-OUT,EXP-4749-OUT;n:type:ShaderForge.SFN_Blend,id:1937,x:32143,y:33222,varname:node_1937,prsc:2,blmd:1,clmp:True|SRC-2049-OUT,DST-2107-RGB;n:type:ShaderForge.SFN_Color,id:2107,x:31735,y:33526,ptovrint:False,ptlb:node_2107,ptin:_node_2107,varname:node_2107,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3917193,c2:0.8235294,c3:0.2543253,c4:1;n:type:ShaderForge.SFN_Blend,id:3941,x:32336,y:33102,varname:node_3941,prsc:2,blmd:1,clmp:True|SRC-1937-OUT,DST-5011-OUT;n:type:ShaderForge.SFN_NormalVector,id:911,x:31369,y:33180,prsc:2,pt:True;n:type:ShaderForge.SFN_ConstantClamp,id:6921,x:32539,y:33102,varname:node_6921,prsc:2,min:0,max:0.5|IN-3941-OUT;n:type:ShaderForge.SFN_Subtract,id:2636,x:31541,y:33264,varname:node_2636,prsc:2|A-911-OUT,B-6435-OUT;n:type:ShaderForge.SFN_ViewReflectionVector,id:6435,x:31353,y:33397,varname:node_6435,prsc:2;n:type:ShaderForge.SFN_Color,id:354,x:32243,y:32052,ptovrint:False,ptlb:Shadow Color,ptin:_ShadowColor,varname:node_354,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7132353,c2:0.8576065,c3:1,c4:1;n:type:ShaderForge.SFN_LightAttenuation,id:6805,x:32243,y:32215,varname:node_6805,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5854,x:32428,y:32469,varname:node_5854,prsc:2|A-6559-RGB,B-4645-OUT;n:type:ShaderForge.SFN_Max,id:4645,x:32469,y:32126,varname:node_4645,prsc:2|A-354-RGB,B-6805-OUT;n:type:ShaderForge.SFN_Color,id:6559,x:32073,y:32479,ptovrint:False,ptlb:node_6559,ptin:_node_6559,varname:node_6559,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1996107,c2:0.291612,c3:0.3823529,c4:1;proporder:5669-4749-8066-2107-354-6559;pass:END;sub:END;*/

Shader "Grass/Grass_Notex" {
    Properties {
        _Normal ("Normal", 2D) = "bump" {}
        _FresnelIntensity ("Fresnel Intensity", Range(0, 15)) = 4.794872
        _node_8066 ("node_8066", Color) = (0.7783976,1,0.1544118,1)
        _node_2107 ("node_2107", Color) = (0.3917193,0.8235294,0.2543253,1)
        _ShadowColor ("Shadow Color", Color) = (0.7132353,0.8576065,1,1)
        _node_6559 ("node_6559", Color) = (0.1996107,0.291612,0.3823529,1)
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
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _FresnelIntensity;
            uniform float4 _node_8066;
            uniform float4 _node_2107;
            uniform float4 _ShadowColor;
            uniform float4 _node_6559;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float3 emissive = (_node_6559.rgb*max(_ShadowColor.rgb,attenuation));
                float3 node_2636 = (normalDirection-viewReflectDirection);
                float3 finalColor = emissive + clamp(saturate((saturate((pow(1.0-max(0,dot(node_2636, viewDirection)),_FresnelIntensity)*_node_2107.rgb))*saturate((pow(pow(1.0-max(0,dot(node_2636, viewDirection)),_FresnelIntensity),5.0)*_node_8066.rgb)))),0,0.5);
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            uniform float _FresnelIntensity;
            uniform float4 _node_8066;
            uniform float4 _node_2107;
            uniform float4 _ShadowColor;
            uniform float4 _node_6559;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normal_var = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(i.uv0, _Normal)));
                float3 normalLocal = _Normal_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 node_2636 = (normalDirection-viewReflectDirection);
                float3 finalColor = clamp(saturate((saturate((pow(1.0-max(0,dot(node_2636, viewDirection)),_FresnelIntensity)*_node_2107.rgb))*saturate((pow(pow(1.0-max(0,dot(node_2636, viewDirection)),_FresnelIntensity),5.0)*_node_8066.rgb)))),0,0.5);
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
