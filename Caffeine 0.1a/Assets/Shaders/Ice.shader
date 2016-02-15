// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:9361,x:33565,y:32706,varname:node_9361,prsc:2|normal-2739-RGB,emission-7988-OUT,custl-2214-OUT,alpha-5953-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:31435,y:32602,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_Color,id:1904,x:31692,y:32422,ptovrint:False,ptlb:node_1904,ptin:_node_1904,varname:node_1904,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4963235,c2:0.6955374,c3:0.7941176,c4:1;n:type:ShaderForge.SFN_Blend,id:7988,x:32573,y:32563,varname:node_7988,prsc:2,blmd:1,clmp:False|SRC-4900-OUT,DST-21-OUT;n:type:ShaderForge.SFN_Fresnel,id:5726,x:32474,y:32969,varname:node_5726,prsc:2|NRM-9153-OUT,EXP-8129-OUT;n:type:ShaderForge.SFN_NormalVector,id:9153,x:32283,y:32821,prsc:2,pt:True;n:type:ShaderForge.SFN_ConstantClamp,id:5561,x:32700,y:32969,varname:node_5561,prsc:2,min:0,max:0.9|IN-5726-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:3451,x:32888,y:32949,varname:node_3451,prsc:2,min:0.1,max:0.5|IN-5561-OUT;n:type:ShaderForge.SFN_Multiply,id:2214,x:32946,y:33149,varname:node_2214,prsc:2|A-6192-OUT,B-8009-RGB,C-5855-RGB;n:type:ShaderForge.SFN_LightColor,id:8009,x:32742,y:33235,varname:node_8009,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:2681,x:32509,y:32324,ptovrint:False,ptlb:node_2681,ptin:_node_2681,varname:node_2681,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9393f83272ff7491e81340575991ff97,ntxv:0,isnm:False|UVIN-5057-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5057,x:32297,y:32206,varname:node_5057,prsc:2,uv:0;n:type:ShaderForge.SFN_Max,id:21,x:31994,y:32493,varname:node_21,prsc:2|A-1904-RGB,B-8068-OUT;n:type:ShaderForge.SFN_Blend,id:4900,x:32903,y:32285,varname:node_4900,prsc:2,blmd:10,clmp:True|SRC-3340-RGB,DST-2681-RGB;n:type:ShaderForge.SFN_Color,id:3340,x:32688,y:32126,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_3340,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4779412,c2:0.4779412,c3:0.4779412,c4:1;n:type:ShaderForge.SFN_Color,id:5855,x:32557,y:33326,ptovrint:False,ptlb:Gloss Color,ptin:_GlossColor,varname:node_5855,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.2352941,c3:0.4726165,c4:1;n:type:ShaderForge.SFN_Posterize,id:6192,x:32586,y:33174,varname:node_6192,prsc:2|IN-3451-OUT,STPS-5434-OUT;n:type:ShaderForge.SFN_Vector1,id:5434,x:32279,y:33254,varname:node_5434,prsc:2,v1:2;n:type:ShaderForge.SFN_Slider,id:8129,x:31970,y:33066,ptovrint:False,ptlb:node_8129,ptin:_node_8129,varname:node_8129,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.1,max:10;n:type:ShaderForge.SFN_Fresnel,id:2989,x:33125,y:33239,varname:node_2989,prsc:2|EXP-4337-OUT;n:type:ShaderForge.SFN_Slider,id:4337,x:32812,y:33430,ptovrint:False,ptlb:node_4337,ptin:_node_4337,varname:node_4337,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.159052,max:10;n:type:ShaderForge.SFN_RemapRange,id:5953,x:33376,y:33069,varname:node_5953,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:1|IN-2764-OUT;n:type:ShaderForge.SFN_Add,id:2764,x:33299,y:33254,varname:node_2764,prsc:2|A-2989-OUT,B-5561-OUT;n:type:ShaderForge.SFN_Tex2d,id:2739,x:33144,y:32803,ptovrint:False,ptlb:node_2739,ptin:_node_2739,varname:node_2739,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e80c3c84ea861404d8a427db8b7abf04,ntxv:3,isnm:True;proporder:1904-2681-3340-5855-8129-4337-2739;pass:END;sub:END;*/

Shader "Water/Ice" {
    Properties {
        _node_1904 ("node_1904", Color) = (0.4963235,0.6955374,0.7941176,1)
        _node_2681 ("node_2681", 2D) = "white" {}
        _Tint ("Tint", Color) = (0.4779412,0.4779412,0.4779412,1)
        _GlossColor ("Gloss Color", Color) = (1,0.2352941,0.4726165,1)
        _node_8129 ("node_8129", Range(0.1, 10)) = 0.1
        _node_4337 ("node_4337", Range(0, 10)) = 1.159052
        _node_2739 ("node_2739", 2D) = "bump" {}
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
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _node_1904;
            uniform sampler2D _node_2681; uniform float4 _node_2681_ST;
            uniform float4 _Tint;
            uniform float4 _GlossColor;
            uniform float _node_8129;
            uniform float _node_4337;
            uniform sampler2D _node_2739; uniform float4 _node_2739_ST;
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
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _node_2739_var = UnpackNormal(tex2D(_node_2739,TRANSFORM_TEX(i.uv0, _node_2739)));
                float3 normalLocal = _node_2739_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                
                float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
                i.normalDir *= nSign;
                normalDirection *= nSign;
                
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
////// Emissive:
                float4 _node_2681_var = tex2D(_node_2681,TRANSFORM_TEX(i.uv0, _node_2681));
                float3 emissive = (saturate(( _node_2681_var.rgb > 0.5 ? (1.0-(1.0-2.0*(_node_2681_var.rgb-0.5))*(1.0-_Tint.rgb)) : (2.0*_node_2681_var.rgb*_Tint.rgb) ))*max(_node_1904.rgb,attenuation));
                float node_5561 = clamp(pow(1.0-max(0,dot(normalDirection, viewDirection)),_node_8129),0,0.9);
                float node_5434 = 2.0;
                float3 finalColor = emissive + (floor(clamp(node_5561,0.1,0.5) * node_5434) / (node_5434 - 1)*_LightColor0.rgb*_GlossColor.rgb);
                fixed4 finalRGBA = fixed4(finalColor,((pow(1.0-max(0,dot(normalDirection, viewDirection)),_node_4337)+node_5561)*0.5+0.5));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}