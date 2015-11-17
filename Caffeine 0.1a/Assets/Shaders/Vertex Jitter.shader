// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-7241-RGB,voffset-8687-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32018,y:32817,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07843138,c2:0.3921569,c3:0.7843137,c4:1;n:type:ShaderForge.SFN_Panner,id:2921,x:31740,y:33066,varname:node_2921,prsc:2,spu:0.1,spv:0.1|UVIN-2081-UVOUT,DIST-719-OUT;n:type:ShaderForge.SFN_TexCoord,id:2081,x:31536,y:33066,varname:node_2081,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:2435,x:31219,y:33279,ptovrint:False,ptlb:node_2435,ptin:_node_2435,varname:node_2435,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-10,cur:-0.4273503,max:10;n:type:ShaderForge.SFN_Time,id:6081,x:31364,y:33421,varname:node_6081,prsc:2;n:type:ShaderForge.SFN_Multiply,id:719,x:31740,y:33302,varname:node_719,prsc:2|A-6081-TSL,B-2435-OUT;n:type:ShaderForge.SFN_Sin,id:900,x:32126,y:33076,varname:node_900,prsc:2|IN-5803-RGB;n:type:ShaderForge.SFN_Tex2d,id:5803,x:31935,y:33098,ptovrint:False,ptlb:node_5803,ptin:_node_5803,varname:node_5803,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e80c3c84ea861404d8a427db8b7abf04,ntxv:0,isnm:False|UVIN-2921-UVOUT;n:type:ShaderForge.SFN_Vector3,id:1353,x:32126,y:33293,varname:node_1353,prsc:2,v1:0,v2:2,v3:0;n:type:ShaderForge.SFN_Multiply,id:8687,x:32434,y:33227,varname:node_8687,prsc:2|A-900-OUT,B-1353-OUT;proporder:7241-2435-5803;pass:END;sub:END;*/

Shader "Effects/Vertex Jitter" {
    Properties {
        _Color ("Color", Color) = (0.07843138,0.3921569,0.7843137,1)
        _node_2435 ("node_2435", Range(-10, 10)) = -0.4273503
        _node_5803 ("node_5803", 2D) = "white" {}
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
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform float _node_2435;
            uniform sampler2D _node_5803; uniform float4 _node_5803_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                float4 node_6081 = _Time + _TimeEditor;
                float2 node_2921 = (o.uv0+(node_6081.r*_node_2435)*float2(0.1,0.1));
                float4 _node_5803_var = tex2Dlod(_node_5803,float4(TRANSFORM_TEX(node_2921, _node_5803),0.0,0));
                v.vertex.xyz += (sin(_node_5803_var.rgb)*float3(0,2,0));
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float3 emissive = _Color.rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
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
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            #pragma glsl
            uniform float4 _TimeEditor;
            uniform float _node_2435;
            uniform sampler2D _node_5803; uniform float4 _node_5803_ST;
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
                float4 node_6081 = _Time + _TimeEditor;
                float2 node_2921 = (o.uv0+(node_6081.r*_node_2435)*float2(0.1,0.1));
                float4 _node_5803_var = tex2Dlod(_node_5803,float4(TRANSFORM_TEX(node_2921, _node_5803),0.0,0));
                v.vertex.xyz += (sin(_node_5803_var.rgb)*float3(0,2,0));
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
