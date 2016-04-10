// Shader created with Shader Forge Beta 0.30 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.30;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:0,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,hqsc:True,hqlp:False,blpr:0,bsrc:0,bdst:0,culm:2,dpts:2,wrdp:True,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32721,y:32690|emission-12-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:5,x:33879,y:33036;n:type:ShaderForge.SFN_Blend,id:12,x:33434,y:32732,blmd:1,clmp:True|SRC-20-RGB,DST-19-OUT;n:type:ShaderForge.SFN_Color,id:17,x:33859,y:32797,ptlb:node_17,ptin:_node_17,glob:False,c1:0.4304043,c2:0.3123378,c3:0.8014706,c4:1;n:type:ShaderForge.SFN_Max,id:19,x:33626,y:32922|A-17-RGB,B-5-OUT;n:type:ShaderForge.SFN_Tex2d,id:20,x:33743,y:32552,ptlb:node_20,ptin:_node_20,ntxv:0,isnm:False|UVIN-21-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:21,x:34042,y:32525,uv:0;proporder:17-20;pass:END;sub:END;*/

Shader "Shader Forge/FlatShadTex" {
    Properties {
        _node_17 ("node_17", Color) = (0.4304043,0.3123378,0.8014706,1)
        _node_20 ("node_20", 2D) = "white" {}
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _node_17;
            uniform sampler2D _node_20; uniform float4 _node_20_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 uv0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                LIGHTING_COORDS(1,2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.uv0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float2 node_21 = i.uv0;
                float3 emissive = saturate((tex2D(_node_20,TRANSFORM_TEX(node_21.rg, _node_20)).rgb*max(_node_17.rgb,attenuation)));
                float3 finalColor = emissive;
/// Final Color:
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _node_17;
            uniform sampler2D _node_20; uniform float4 _node_20_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float4 uv0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 uv0 : TEXCOORD0;
                LIGHTING_COORDS(1,2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.uv0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 finalColor = 0;
/// Final Color:
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
