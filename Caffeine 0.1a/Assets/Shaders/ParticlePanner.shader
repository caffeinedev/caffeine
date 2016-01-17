// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:4795,x:32724,y:32693,varname:node_4795,prsc:2|emission-7241-OUT,alpha-3511-OUT;n:type:ShaderForge.SFN_Tex2d,id:4405,x:32083,y:32846,ptovrint:False,ptlb:Alpha Map 1,ptin:_AlphaMap1,varname:node_4405,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ebd4b6f52eab344e3b12ce43f5efc932,ntxv:0,isnm:False|UVIN-1419-UVOUT;n:type:ShaderForge.SFN_Panner,id:1419,x:31864,y:32846,varname:node_1419,prsc:2,spu:1.1,spv:0|UVIN-6032-UVOUT,DIST-6881-OUT;n:type:ShaderForge.SFN_TexCoord,id:6032,x:31650,y:32846,varname:node_6032,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:8592,x:31257,y:33009,ptovrint:False,ptlb:Panner Speed 1,ptin:_PannerSpeed1,varname:node_8592,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.1,max:1;n:type:ShaderForge.SFN_Multiply,id:6881,x:31623,y:33061,varname:node_6881,prsc:2|A-8592-OUT,B-1909-T;n:type:ShaderForge.SFN_Time,id:1909,x:31414,y:33099,varname:node_1909,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:2104,x:32083,y:33061,ptovrint:False,ptlb:Alpha Map 2,ptin:_AlphaMap2,varname:node_2104,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ebd4b6f52eab344e3b12ce43f5efc932,ntxv:0,isnm:False|UVIN-2511-UVOUT;n:type:ShaderForge.SFN_Panner,id:2511,x:31854,y:33061,varname:node_2511,prsc:2,spu:1.1,spv:0|UVIN-6032-UVOUT,DIST-5584-OUT;n:type:ShaderForge.SFN_Multiply,id:5584,x:31623,y:33236,varname:node_5584,prsc:2|A-4479-OUT,B-1909-T;n:type:ShaderForge.SFN_Slider,id:4479,x:31257,y:33277,ptovrint:False,ptlb:Panner Speed 2,ptin:_PannerSpeed2,varname:node_4479,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:6337,x:32334,y:33061,varname:node_6337,prsc:2|A-2104-R,B-2519-OUT;n:type:ShaderForge.SFN_Multiply,id:2492,x:32334,y:32848,varname:node_2492,prsc:2|A-4405-R,B-2519-OUT;n:type:ShaderForge.SFN_Vector1,id:2519,x:32195,y:32993,varname:node_2519,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Blend,id:3511,x:32515,y:32936,varname:node_3511,prsc:2,blmd:6,clmp:True|SRC-2492-OUT,DST-6337-OUT;n:type:ShaderForge.SFN_Color,id:5746,x:32007,y:32479,ptovrint:False,ptlb:node_5746,ptin:_node_5746,varname:node_5746,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.9026369,c3:0.6470588,c4:1;n:type:ShaderForge.SFN_Color,id:2758,x:32007,y:32639,ptovrint:False,ptlb:node_2758,ptin:_node_2758,varname:node_2758,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.8235294,c2:0.4871018,c3:0.3633218,c4:1;n:type:ShaderForge.SFN_Blend,id:7241,x:32573,y:32452,varname:node_7241,prsc:2,blmd:6,clmp:True|SRC-5973-OUT,DST-5991-OUT;n:type:ShaderForge.SFN_Blend,id:7972,x:32258,y:32583,varname:node_7972,prsc:2,blmd:1,clmp:False|SRC-2104-RGB,DST-2758-RGB;n:type:ShaderForge.SFN_Blend,id:7113,x:32258,y:32412,varname:node_7113,prsc:2,blmd:1,clmp:False|SRC-4405-RGB,DST-5746-RGB;n:type:ShaderForge.SFN_ConstantClamp,id:5991,x:32424,y:32583,varname:node_5991,prsc:2,min:0,max:1|IN-7972-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:5973,x:32424,y:32412,varname:node_5973,prsc:2,min:0.5,max:1|IN-7113-OUT;proporder:4405-8592-2104-4479-5746-2758;pass:END;sub:END;*/

Shader "Shader Forge/ParticlePanner" {
    Properties {
        _AlphaMap1 ("Alpha Map 1", 2D) = "white" {}
        _PannerSpeed1 ("Panner Speed 1", Range(-1, 1)) = 0.1
        _AlphaMap2 ("Alpha Map 2", 2D) = "white" {}
        _PannerSpeed2 ("Panner Speed 2", Range(0, 1)) = 0
        _node_5746 ("node_5746", Color) = (1,0.9026369,0.6470588,1)
        _node_2758 ("node_2758", Color) = (0.8235294,0.4871018,0.3633218,1)
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
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _AlphaMap1; uniform float4 _AlphaMap1_ST;
            uniform float _PannerSpeed1;
            uniform sampler2D _AlphaMap2; uniform float4 _AlphaMap2_ST;
            uniform float _PannerSpeed2;
            uniform float4 _node_5746;
            uniform float4 _node_2758;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
/////// Vectors:
////// Lighting:
////// Emissive:
                float4 node_1909 = _Time + _TimeEditor;
                float2 node_1419 = (i.uv0+(_PannerSpeed1*node_1909.g)*float2(1.1,0));
                float4 _AlphaMap1_var = tex2D(_AlphaMap1,TRANSFORM_TEX(node_1419, _AlphaMap1));
                float2 node_2511 = (i.uv0+(_PannerSpeed2*node_1909.g)*float2(1.1,0));
                float4 _AlphaMap2_var = tex2D(_AlphaMap2,TRANSFORM_TEX(node_2511, _AlphaMap2));
                float3 emissive = saturate((1.0-(1.0-clamp((_AlphaMap1_var.rgb*_node_5746.rgb),0.5,1))*(1.0-clamp((_AlphaMap2_var.rgb*_node_2758.rgb),0,1))));
                float3 finalColor = emissive;
                float node_2519 = 0.5;
                fixed4 finalRGBA = fixed4(finalColor,saturate((1.0-(1.0-(_AlphaMap1_var.r*node_2519))*(1.0-(_AlphaMap2_var.r*node_2519)))));
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
