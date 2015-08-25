// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:9361,x:33234,y:32679,varname:node_9361,prsc:2|emission-7988-OUT,custl-2214-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:32225,y:32440,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_Color,id:83,x:32580,y:32464,ptovrint:False,ptlb:node_83,ptin:_node_83,varname:node_83,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9117647,c2:0.2279412,c3:0.2279412,c4:1;n:type:ShaderForge.SFN_Color,id:1904,x:32228,y:32726,ptovrint:False,ptlb:node_1904,ptin:_node_1904,varname:node_1904,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9411765,c2:0.3460208,c3:0.4568425,c4:1;n:type:ShaderForge.SFN_Blend,id:7988,x:32840,y:32729,varname:node_7988,prsc:2,blmd:1,clmp:True|SRC-83-RGB,DST-5883-OUT;n:type:ShaderForge.SFN_Max,id:5883,x:32491,y:32653,varname:node_5883,prsc:2|A-1904-RGB,B-8068-OUT;n:type:ShaderForge.SFN_Fresnel,id:5726,x:32521,y:32952,varname:node_5726,prsc:2|NRM-9153-OUT,EXP-7221-OUT;n:type:ShaderForge.SFN_NormalVector,id:9153,x:32285,y:32952,prsc:2,pt:True;n:type:ShaderForge.SFN_ConstantClamp,id:5561,x:32718,y:33002,varname:node_5561,prsc:2,min:0,max:0.9|IN-5726-OUT;n:type:ShaderForge.SFN_Vector1,id:7221,x:32343,y:33130,varname:node_7221,prsc:2,v1:3;n:type:ShaderForge.SFN_ConstantClamp,id:3451,x:32918,y:32949,varname:node_3451,prsc:2,min:0.1,max:0.2|IN-5561-OUT;n:type:ShaderForge.SFN_Multiply,id:2214,x:32946,y:33149,varname:node_2214,prsc:2|A-3451-OUT,B-8009-RGB;n:type:ShaderForge.SFN_LightColor,id:8009,x:32742,y:33235,varname:node_8009,prsc:2;proporder:83-1904;pass:END;sub:END;*/

Shader "Shader Forge/shader_unlit_shadowed" {
    Properties {
        _node_83 ("node_83", Color) = (0.9117647,0.2279412,0.2279412,1)
        _node_1904 ("node_1904", Color) = (0.9411765,0.3460208,0.4568425,1)
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
            uniform float4 _node_83;
            uniform float4 _node_1904;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                
                float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
                i.normalDir *= nSign;
                normalDirection *= nSign;
                
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float3 emissive = saturate((_node_83.rgb*max(_node_1904.rgb,attenuation)));
                float3 finalColor = emissive + (clamp(clamp(pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0),0,0.9),0.1,0.2)*_LightColor0.rgb);
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
            uniform float4 _node_83;
            uniform float4 _node_1904;
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
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                
                float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
                i.normalDir *= nSign;
                normalDirection *= nSign;
                
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 finalColor = (clamp(clamp(pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0),0,0.9),0.1,0.2)*_LightColor0.rgb);
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
