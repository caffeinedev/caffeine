// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:34545,y:32688,varname:node_1,prsc:2|emission-12-OUT,voffset-3047-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:5,x:33360,y:33036,varname:node_5,prsc:2;n:type:ShaderForge.SFN_Blend,id:12,x:33805,y:32732,varname:node_12,prsc:2,blmd:1,clmp:True|SRC-20-RGB,DST-19-OUT;n:type:ShaderForge.SFN_Color,id:17,x:33380,y:32797,ptovrint:False,ptlb:node_17,ptin:_node_17,varname:node_4877,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4304043,c2:0.3123378,c3:0.8014706,c4:1;n:type:ShaderForge.SFN_Max,id:19,x:33613,y:32922,varname:node_19,prsc:2|A-17-RGB,B-5-OUT;n:type:ShaderForge.SFN_Tex2d,id:20,x:33496,y:32552,ptovrint:False,ptlb:node_20,ptin:_node_20,varname:node_6915,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-21-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:21,x:33197,y:32525,varname:node_21,prsc:2,uv:0;n:type:ShaderForge.SFN_TexCoord,id:2196,x:33176,y:33189,varname:node_2196,prsc:2,uv:0;n:type:ShaderForge.SFN_Time,id:9897,x:33112,y:33420,varname:node_9897,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3047,x:34281,y:33142,varname:node_3047,prsc:2|A-7585-OUT,B-4396-OUT;n:type:ShaderForge.SFN_Multiply,id:7585,x:34067,y:33142,varname:node_7585,prsc:2|A-3115-G,B-5820-OUT;n:type:ShaderForge.SFN_VertexColor,id:3115,x:33865,y:33124,varname:node_3115,prsc:2;n:type:ShaderForge.SFN_Vector3,id:4396,x:34281,y:33289,varname:node_4396,prsc:2,v1:0.3,v2:-0.1,v3:0.3;n:type:ShaderForge.SFN_ComponentMask,id:5820,x:33879,y:33274,varname:node_5820,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-2204-OUT;n:type:ShaderForge.SFN_Multiply,id:3063,x:33318,y:33480,varname:node_3063,prsc:2|A-9897-T,B-1316-OUT;n:type:ShaderForge.SFN_Add,id:8059,x:33578,y:33431,varname:node_8059,prsc:2|A-3063-OUT,B-2571-X,C-3615-X;n:type:ShaderForge.SFN_FragmentPosition,id:2571,x:33527,y:33568,varname:node_2571,prsc:2;n:type:ShaderForge.SFN_Sin,id:4658,x:33755,y:33507,varname:node_4658,prsc:2|IN-8059-OUT;n:type:ShaderForge.SFN_RemapRange,id:2204,x:33947,y:33460,varname:node_2204,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-4658-OUT;n:type:ShaderForge.SFN_Slider,id:1316,x:32812,y:33634,ptovrint:False,ptlb:node_1316,ptin:_node_1316,varname:node_1316,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.001,cur:0.001,max:30;n:type:ShaderForge.SFN_ObjectPosition,id:3615,x:33527,y:33708,varname:node_3615,prsc:2;proporder:17-20-1316;pass:END;sub:END;*/

Shader "Experimental/Windy" {
    Properties {
        _node_17 ("node_17", Color) = (0.4304043,0.3123378,0.8014706,1)
        _node_20 ("node_20", 2D) = "white" {}
        _node_1316 ("node_1316", Range(0.001, 30)) = 0.001
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
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _node_17;
            uniform sampler2D _node_20; uniform float4 _node_20_ST;
            uniform float _node_1316;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
                float4 node_9897 = _Time + _TimeEditor;
                v.vertex.xyz += ((o.vertexColor.g*(sin(((node_9897.g*_node_1316)+mul(_Object2World, v.vertex).r+objPos.r))*0.5+0.5).r)*float3(0.3,-0.1,0.3));
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
/////// Vectors:
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float4 _node_20_var = tex2D(_node_20,TRANSFORM_TEX(i.uv0, _node_20));
                float3 emissive = saturate((_node_20_var.rgb*max(_node_17.rgb,attenuation)));
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
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _node_17;
            uniform sampler2D _node_20; uniform float4 _node_20_ST;
            uniform float _node_1316;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(2,3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
                float4 node_9897 = _Time + _TimeEditor;
                v.vertex.xyz += ((o.vertexColor.g*(sin(((node_9897.g*_node_1316)+mul(_Object2World, v.vertex).r+objPos.r))*0.5+0.5).r)*float3(0.3,-0.1,0.3));
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
/////// Vectors:
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
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _node_1316;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 posWorld : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
                float4 node_9897 = _Time + _TimeEditor;
                v.vertex.xyz += ((o.vertexColor.g*(sin(((node_9897.g*_node_1316)+mul(_Object2World, v.vertex).r+objPos.r))*0.5+0.5).r)*float3(0.3,-0.1,0.3));
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
/////// Vectors:
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
