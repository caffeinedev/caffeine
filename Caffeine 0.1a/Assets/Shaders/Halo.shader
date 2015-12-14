// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:1,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:34617,y:32342,varname:node_3138,prsc:2|normal-6216-OUT,emission-7513-RGB,custl-8648-OUT,clip-1906-OUT;n:type:ShaderForge.SFN_Tex2d,id:1342,x:33483,y:32203,ptovrint:False,ptlb:node_1342,ptin:_node_1342,varname:node_1342,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:91f6adaf1d0ca426c8542a8dafbd9d78,ntxv:2,isnm:False|UVIN-6671-UVOUT;n:type:ShaderForge.SFN_NormalVector,id:7841,x:33032,y:32576,prsc:2,pt:True;n:type:ShaderForge.SFN_Fresnel,id:1053,x:33495,y:32627,varname:node_1053,prsc:2|NRM-8503-OUT,EXP-6356-OUT;n:type:ShaderForge.SFN_Slider,id:6356,x:33032,y:32863,ptovrint:False,ptlb:Fresnel 2 Intensity,ptin:_Fresnel2Intensity,varname:node_6356,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:1.676923,max:10;n:type:ShaderForge.SFN_Multiply,id:2138,x:33550,y:32808,varname:node_2138,prsc:2|A-6416-OUT,B-5644-RGB;n:type:ShaderForge.SFN_Color,id:5644,x:33208,y:33043,ptovrint:False,ptlb:Fresnel Tint 1,ptin:_FresnelTint1,varname:node_5644,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4314446,c2:0.5482818,c3:0.5588235,c4:1;n:type:ShaderForge.SFN_Posterize,id:6416,x:33782,y:32757,varname:node_6416,prsc:2|IN-1053-OUT,STPS-3537-OUT;n:type:ShaderForge.SFN_Blend,id:8648,x:34037,y:32702,varname:node_8648,prsc:2,blmd:10,clmp:True|SRC-2138-OUT,DST-2746-OUT;n:type:ShaderForge.SFN_Fresnel,id:5413,x:33472,y:33125,varname:node_5413,prsc:2|NRM-8503-OUT,EXP-7209-OUT;n:type:ShaderForge.SFN_Color,id:7341,x:33472,y:33287,ptovrint:False,ptlb:Fresnel Tint 2,ptin:_FresnelTint2,varname:node_7341,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9338235,c2:0.4737781,c3:0.4737781,c4:1;n:type:ShaderForge.SFN_Multiply,id:2746,x:34020,y:33006,varname:node_2746,prsc:2|A-7817-OUT,B-7341-RGB;n:type:ShaderForge.SFN_Slider,id:7209,x:33062,y:33246,ptovrint:False,ptlb:Frenel 2 Intensity,ptin:_Frenel2Intensity,varname:node_7209,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.7606843,max:10;n:type:ShaderForge.SFN_Posterize,id:7817,x:33727,y:33097,varname:node_7817,prsc:2|IN-5413-OUT,STPS-3865-OUT;n:type:ShaderForge.SFN_Tex2d,id:4166,x:33474,y:32414,ptovrint:False,ptlb:node_4166,ptin:_node_4166,varname:node_4166,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:91f6adaf1d0ca426c8542a8dafbd9d78,ntxv:2,isnm:False|UVIN-2453-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:8503,x:33248,y:32526,varname:node_8503,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0|IN-7841-OUT;n:type:ShaderForge.SFN_NormalBlend,id:6216,x:33772,y:32230,varname:node_6216,prsc:2|BSE-1342-RGB,DTL-4166-RGB;n:type:ShaderForge.SFN_Vector1,id:3537,x:33711,y:32978,varname:node_3537,prsc:2,v1:3;n:type:ShaderForge.SFN_Vector1,id:3865,x:33686,y:33287,varname:node_3865,prsc:2,v1:5;n:type:ShaderForge.SFN_TexCoord,id:189,x:32948,y:32134,varname:node_189,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:8408,x:33904,y:32476,ptovrint:False,ptlb:node_8408,ptin:_node_8408,varname:node_8408,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:dd0f60140e3df4860a5f451975b31f0e,ntxv:0,isnm:False|UVIN-6671-UVOUT;n:type:ShaderForge.SFN_Color,id:7513,x:34073,y:32112,ptovrint:False,ptlb:node_7513,ptin:_node_7513,varname:node_7513,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5882353,c2:0.4282007,c3:0.4282007,c4:1;n:type:ShaderForge.SFN_Rotator,id:2453,x:33086,y:32305,varname:node_2453,prsc:2|UVIN-189-UVOUT,ANG-633-OUT,SPD-8189-T;n:type:ShaderForge.SFN_Time,id:8189,x:32586,y:32283,varname:node_8189,prsc:2;n:type:ShaderForge.SFN_Vector1,id:633,x:32787,y:32489,varname:node_633,prsc:2,v1:3;n:type:ShaderForge.SFN_Rotator,id:6671,x:33194,y:31943,varname:node_6671,prsc:2|UVIN-189-UVOUT,ANG-8660-OUT,SPD-6232-OUT;n:type:ShaderForge.SFN_Vector1,id:8660,x:32910,y:31953,varname:node_8660,prsc:2,v1:2;n:type:ShaderForge.SFN_Divide,id:6232,x:32755,y:32040,varname:node_6232,prsc:2|A-8189-T,B-633-OUT;n:type:ShaderForge.SFN_Multiply,id:1906,x:34219,y:32439,varname:node_1906,prsc:2|A-8408-A,B-8136-OUT;n:type:ShaderForge.SFN_Slider,id:8136,x:34062,y:32587,ptovrint:False,ptlb:Opacity Clip,ptin:_OpacityClip,varname:node_8136,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4957265,max:1;proporder:1342-6356-5644-7341-7209-4166-8408-7513-8136;pass:END;sub:END;*/

Shader "Water/Halo" {
    Properties {
        _node_1342 ("node_1342", 2D) = "black" {}
        _Fresnel2Intensity ("Fresnel 2 Intensity", Range(0.1, 10)) = 1.676923
        _FresnelTint1 ("Fresnel Tint 1", Color) = (0.4314446,0.5482818,0.5588235,1)
        _FresnelTint2 ("Fresnel Tint 2", Color) = (0.9338235,0.4737781,0.4737781,1)
        _Frenel2Intensity ("Frenel 2 Intensity", Range(0.1, 10)) = 0.7606843
        _node_4166 ("node_4166", 2D) = "black" {}
        _node_8408 ("node_8408", 2D) = "white" {}
        _node_7513 ("node_7513", Color) = (0.5882353,0.4282007,0.4282007,1)
        _OpacityClip ("Opacity Clip", Range(0, 1)) = 0.4957265
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
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
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 2x2 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither2x2( float value, float2 sceneUVs ) {
                float2x2 mtx = float2x2(
                    float2( 1, 3 )/5.0,
                    float2( 4, 2 )/5.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,2);
                int ySmp = fmod(px.y,2);
                float2 xVec = 1-saturate(abs(float2(0,1) - xSmp));
                float2 yVec = 1-saturate(abs(float2(0,1) - ySmp));
                float2 pxMult = float2( dot(mtx[0],yVec), dot(mtx[1],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform float4 _TimeEditor;
            uniform sampler2D _node_1342; uniform float4 _node_1342_ST;
            uniform float _Fresnel2Intensity;
            uniform float4 _FresnelTint1;
            uniform float4 _FresnelTint2;
            uniform float _Frenel2Intensity;
            uniform sampler2D _node_4166; uniform float4 _node_4166_ST;
            uniform sampler2D _node_8408; uniform float4 _node_8408_ST;
            uniform float4 _node_7513;
            uniform float _OpacityClip;
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
                float4 screenPos : TEXCOORD5;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( _Object2World, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_8189 = _Time + _TimeEditor;
                float node_633 = 3.0;
                float node_6671_ang = 2.0;
                float node_6671_spd = (node_8189.g/node_633);
                float node_6671_cos = cos(node_6671_spd*node_6671_ang);
                float node_6671_sin = sin(node_6671_spd*node_6671_ang);
                float2 node_6671_piv = float2(0.5,0.5);
                float2 node_6671 = (mul(i.uv0-node_6671_piv,float2x2( node_6671_cos, -node_6671_sin, node_6671_sin, node_6671_cos))+node_6671_piv);
                float4 _node_1342_var = tex2D(_node_1342,TRANSFORM_TEX(node_6671, _node_1342));
                float node_2453_ang = node_633;
                float node_2453_spd = node_8189.g;
                float node_2453_cos = cos(node_2453_spd*node_2453_ang);
                float node_2453_sin = sin(node_2453_spd*node_2453_ang);
                float2 node_2453_piv = float2(0.5,0.5);
                float2 node_2453 = (mul(i.uv0-node_2453_piv,float2x2( node_2453_cos, -node_2453_sin, node_2453_sin, node_2453_cos))+node_2453_piv);
                float4 _node_4166_var = tex2D(_node_4166,TRANSFORM_TEX(node_2453, _node_4166));
                float3 node_6216_nrm_base = _node_1342_var.rgb + float3(0,0,1);
                float3 node_6216_nrm_detail = _node_4166_var.rgb * float3(-1,-1,1);
                float3 node_6216_nrm_combined = node_6216_nrm_base*dot(node_6216_nrm_base, node_6216_nrm_detail)/node_6216_nrm_base.z - node_6216_nrm_detail;
                float3 node_6216 = node_6216_nrm_combined;
                float3 normalLocal = node_6216;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float4 _node_8408_var = tex2D(_node_8408,TRANSFORM_TEX(node_6671, _node_8408));
                clip( BinaryDither2x2((_node_8408_var.a*_OpacityClip) - 1.5, sceneUVs) );
////// Lighting:
////// Emissive:
                float3 emissive = _node_7513.rgb;
                float3 node_8503 = (normalDirection*-1.0+1.0);
                float node_3537 = 3.0;
                float node_3865 = 5.0;
                float3 finalColor = emissive + saturate(( (floor(pow(1.0-max(0,dot(node_8503, viewDirection)),_Frenel2Intensity) * node_3865) / (node_3865 - 1)*_FresnelTint2.rgb) > 0.5 ? (1.0-(1.0-2.0*((floor(pow(1.0-max(0,dot(node_8503, viewDirection)),_Frenel2Intensity) * node_3865) / (node_3865 - 1)*_FresnelTint2.rgb)-0.5))*(1.0-(floor(pow(1.0-max(0,dot(node_8503, viewDirection)),_Fresnel2Intensity) * node_3537) / (node_3537 - 1)*_FresnelTint1.rgb))) : (2.0*(floor(pow(1.0-max(0,dot(node_8503, viewDirection)),_Frenel2Intensity) * node_3865) / (node_3865 - 1)*_FresnelTint2.rgb)*(floor(pow(1.0-max(0,dot(node_8503, viewDirection)),_Fresnel2Intensity) * node_3537) / (node_3537 - 1)*_FresnelTint1.rgb)) ));
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
            // Dithering function, to use with scene UVs (screen pixel coords)
            // 2x2 Bayer matrix, based on https://en.wikipedia.org/wiki/Ordered_dithering
            float BinaryDither2x2( float value, float2 sceneUVs ) {
                float2x2 mtx = float2x2(
                    float2( 1, 3 )/5.0,
                    float2( 4, 2 )/5.0
                );
                float2 px = floor(_ScreenParams.xy * sceneUVs);
                int xSmp = fmod(px.x,2);
                int ySmp = fmod(px.y,2);
                float2 xVec = 1-saturate(abs(float2(0,1) - xSmp));
                float2 yVec = 1-saturate(abs(float2(0,1) - ySmp));
                float2 pxMult = float2( dot(mtx[0],yVec), dot(mtx[1],yVec) );
                return round(value + dot(pxMult, xVec));
            }
            uniform float4 _TimeEditor;
            uniform sampler2D _node_8408; uniform float4 _node_8408_ST;
            uniform float _OpacityClip;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float4 screenPos : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.screenPos = o.pos;
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                #if UNITY_UV_STARTS_AT_TOP
                    float grabSign = -_ProjectionParams.x;
                #else
                    float grabSign = _ProjectionParams.x;
                #endif
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float2 sceneUVs = float2(1,grabSign)*i.screenPos.xy*0.5+0.5;
/////// Vectors:
                float4 node_8189 = _Time + _TimeEditor;
                float node_633 = 3.0;
                float node_6671_ang = 2.0;
                float node_6671_spd = (node_8189.g/node_633);
                float node_6671_cos = cos(node_6671_spd*node_6671_ang);
                float node_6671_sin = sin(node_6671_spd*node_6671_ang);
                float2 node_6671_piv = float2(0.5,0.5);
                float2 node_6671 = (mul(i.uv0-node_6671_piv,float2x2( node_6671_cos, -node_6671_sin, node_6671_sin, node_6671_cos))+node_6671_piv);
                float4 _node_8408_var = tex2D(_node_8408,TRANSFORM_TEX(node_6671, _node_8408));
                clip( BinaryDither2x2((_node_8408_var.a*_OpacityClip) - 1.5, sceneUVs) );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
