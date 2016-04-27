// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|normal-4943-RGB,emission-7241-RGB,custl-8437-OUT,alpha-3597-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32409,y:32267,ptovrint:False,ptlb:Water Color,ptin:_WaterColor,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.4558824,c3:0.4558824,c4:1;n:type:ShaderForge.SFN_Tex2d,id:203,x:31515,y:32860,ptovrint:False,ptlb:node_203,ptin:_node_203,varname:node_203,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:23ae31268fd59423f9578178e79d9f8e,ntxv:3,isnm:False|UVIN-8802-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9324,x:31098,y:32784,varname:node_9324,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:8802,x:31309,y:33057,varname:node_8802,prsc:2,spu:0,spv:0.3|UVIN-9324-UVOUT,DIST-2791-OUT;n:type:ShaderForge.SFN_OneMinus,id:7488,x:31515,y:33057,varname:node_7488,prsc:2|IN-203-G;n:type:ShaderForge.SFN_Power,id:6803,x:31715,y:33057,varname:node_6803,prsc:2|VAL-7488-OUT,EXP-1697-OUT;n:type:ShaderForge.SFN_Vector1,id:1697,x:31515,y:33199,varname:node_1697,prsc:2,v1:5;n:type:ShaderForge.SFN_Multiply,id:2915,x:31947,y:33091,varname:node_2915,prsc:2|A-6803-OUT,B-9412-OUT,C-4910-R;n:type:ShaderForge.SFN_Vector1,id:9412,x:31715,y:33199,varname:node_9412,prsc:2,v1:12;n:type:ShaderForge.SFN_Tex2d,id:4910,x:31515,y:33332,ptovrint:False,ptlb:2nnnn,ptin:_2nnnn,varname:node_4910,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:673faf023b0d9492ba37bf59b95d5fe6,ntxv:0,isnm:False|UVIN-1525-UVOUT;n:type:ShaderForge.SFN_Fresnel,id:3326,x:31787,y:32621,varname:node_3326,prsc:2|NRM-3763-OUT,EXP-8185-OUT;n:type:ShaderForge.SFN_Vector1,id:8185,x:31564,y:32706,varname:node_8185,prsc:2,v1:3;n:type:ShaderForge.SFN_NormalVector,id:3763,x:31564,y:32551,prsc:2,pt:True;n:type:ShaderForge.SFN_Panner,id:1525,x:31309,y:33240,varname:node_1525,prsc:2,spu:0,spv:0.2|UVIN-9324-UVOUT,DIST-2791-OUT;n:type:ShaderForge.SFN_Add,id:9149,x:32162,y:33224,varname:node_9149,prsc:2|A-7419-OUT,B-6803-OUT,C-6394-OUT,D-8160-OUT;n:type:ShaderForge.SFN_Subtract,id:7419,x:32141,y:32984,varname:node_7419,prsc:2|A-2915-OUT,B-203-G;n:type:ShaderForge.SFN_Tex2d,id:6156,x:31515,y:33522,ptovrint:False,ptlb:node_6156,ptin:_node_6156,varname:node_6156,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:23ae31268fd59423f9578178e79d9f8e,ntxv:0,isnm:False|UVIN-524-UVOUT;n:type:ShaderForge.SFN_Panner,id:524,x:31309,y:33414,varname:node_524,prsc:2,spu:0,spv:0.1|UVIN-9324-UVOUT,DIST-2791-OUT;n:type:ShaderForge.SFN_Tex2d,id:4943,x:31515,y:33726,ptovrint:False,ptlb:node_4943,ptin:_node_4943,varname:node_4943,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:23ae31268fd59423f9578178e79d9f8e,ntxv:3,isnm:True|UVIN-524-UVOUT;n:type:ShaderForge.SFN_Power,id:5530,x:31719,y:33743,varname:node_5530,prsc:2|VAL-4943-G,EXP-1697-OUT;n:type:ShaderForge.SFN_Multiply,id:6394,x:31913,y:33598,varname:node_6394,prsc:2|A-6156-R,B-5530-OUT,C-9962-OUT;n:type:ShaderForge.SFN_Vector1,id:9962,x:31719,y:33632,varname:node_9962,prsc:2,v1:7;n:type:ShaderForge.SFN_Vector1,id:8160,x:32340,y:33381,varname:node_8160,prsc:2,v1:0.4;n:type:ShaderForge.SFN_Multiply,id:4673,x:31968,y:32791,varname:node_4673,prsc:2|A-3326-OUT,B-7687-RGB;n:type:ShaderForge.SFN_Color,id:7687,x:31715,y:32846,ptovrint:False,ptlb:Normal Color,ptin:_NormalColor,varname:node_7687,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.3455882,c2:1,c3:0.9187627,c4:1;n:type:ShaderForge.SFN_Bitangent,id:8262,x:31394,y:32241,varname:node_8262,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7772,x:32139,y:32439,varname:node_7772,prsc:2|A-7048-OUT,B-2674-RGB,C-8185-OUT;n:type:ShaderForge.SFN_Fresnel,id:7048,x:31674,y:32242,varname:node_7048,prsc:2|NRM-8262-OUT;n:type:ShaderForge.SFN_Color,id:2674,x:31787,y:32425,ptovrint:False,ptlb:Bitangent Color,ptin:_BitangentColor,varname:node_2674,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.3676471,c3:0.4592291,c4:1;n:type:ShaderForge.SFN_Blend,id:6542,x:32175,y:32719,varname:node_6542,prsc:2,blmd:2,clmp:True|SRC-7772-OUT,DST-4673-OUT;n:type:ShaderForge.SFN_Tex2d,id:5801,x:32176,y:33516,ptovrint:False,ptlb:node_5801,ptin:_node_5801,varname:node_5801,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e7184f963dfc2415c98e692b4a0bab72,ntxv:0,isnm:False|UVIN-524-UVOUT;n:type:ShaderForge.SFN_Multiply,id:3597,x:32615,y:33394,varname:node_3597,prsc:2|A-9149-OUT,B-5801-R,C-7594-OUT;n:type:ShaderForge.SFN_Vector1,id:7594,x:32380,y:33529,varname:node_7594,prsc:2,v1:1;n:type:ShaderForge.SFN_ConstantClamp,id:8437,x:32413,y:32685,varname:node_8437,prsc:2,min:0.5,max:1|IN-6542-OUT;n:type:ShaderForge.SFN_Slider,id:8969,x:30718,y:33242,ptovrint:False,ptlb:node_8969,ptin:_node_8969,varname:node_8969,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.06837607,max:1;n:type:ShaderForge.SFN_Time,id:6055,x:30875,y:33349,varname:node_6055,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2791,x:31064,y:33260,varname:node_2791,prsc:2|A-8969-OUT,B-6055-T;proporder:7241-203-4910-6156-4943-7687-2674-5801-8969;pass:END;sub:END;*/

Shader "Shader Forge/TransparentWater" {
    Properties {
        _WaterColor ("Water Color", Color) = (1,0.4558824,0.4558824,1)
        _node_203 ("node_203", 2D) = "bump" {}
        _2nnnn ("2nnnn", 2D) = "white" {}
        _node_6156 ("node_6156", 2D) = "white" {}
        _node_4943 ("node_4943", 2D) = "bump" {}
        _NormalColor ("Normal Color", Color) = (0.3455882,1,0.9187627,1)
        _BitangentColor ("Bitangent Color", Color) = (1,0.3676471,0.4592291,1)
        _node_5801 ("node_5801", 2D) = "white" {}
        _node_8969 ("node_8969", Range(-1, 1)) = 0.06837607
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
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _WaterColor;
            uniform sampler2D _node_203; uniform float4 _node_203_ST;
            uniform sampler2D _2nnnn; uniform float4 _2nnnn_ST;
            uniform sampler2D _node_6156; uniform float4 _node_6156_ST;
            uniform sampler2D _node_4943; uniform float4 _node_4943_ST;
            uniform float4 _NormalColor;
            uniform float4 _BitangentColor;
            uniform sampler2D _node_5801; uniform float4 _node_5801_ST;
            uniform float _node_8969;
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
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_6055 = _Time + _TimeEditor;
                float node_2791 = (_node_8969*node_6055.g);
                float2 node_524 = (i.uv0+node_2791*float2(0,0.1));
                float3 _node_4943_var = UnpackNormal(tex2D(_node_4943,TRANSFORM_TEX(node_524, _node_4943)));
                float3 normalLocal = _node_4943_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
////// Lighting:
////// Emissive:
                float3 emissive = _WaterColor.rgb;
                float node_8185 = 3.0;
                float3 finalColor = emissive + clamp(saturate((1.0-((1.0-(pow(1.0-max(0,dot(normalDirection, viewDirection)),node_8185)*_NormalColor.rgb))/((1.0-max(0,dot(i.bitangentDir, viewDirection)))*_BitangentColor.rgb*node_8185)))),0.5,1);
                float2 node_8802 = (i.uv0+node_2791*float2(0,0.3));
                float4 _node_203_var = tex2D(_node_203,TRANSFORM_TEX(node_8802, _node_203));
                float node_1697 = 5.0;
                float node_6803 = pow((1.0 - _node_203_var.g),node_1697);
                float2 node_1525 = (i.uv0+node_2791*float2(0,0.2));
                float4 _2nnnn_var = tex2D(_2nnnn,TRANSFORM_TEX(node_1525, _2nnnn));
                float4 _node_6156_var = tex2D(_node_6156,TRANSFORM_TEX(node_524, _node_6156));
                float4 _node_5801_var = tex2D(_node_5801,TRANSFORM_TEX(node_524, _node_5801));
                return fixed4(finalColor,((((node_6803*12.0*_2nnnn_var.r)-_node_203_var.g)+node_6803+(_node_6156_var.r*pow(_node_4943_var.g,node_1697)*7.0)+0.4)*_node_5801_var.r*1.0));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
