// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:3,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:True,rprd:True,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:9361,x:33204,y:32028,varname:node_9361,prsc:2|diff-7988-OUT,spec-4297-OUT,emission-2214-OUT,alpha-9940-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:31411,y:32246,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_Color,id:1904,x:31668,y:32193,ptovrint:False,ptlb:Shadow Color,ptin:_ShadowColor,varname:node_1904,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4963235,c2:0.6955374,c3:0.7941176,c4:1;n:type:ShaderForge.SFN_Blend,id:7988,x:32340,y:31986,varname:node_7988,prsc:2,blmd:1,clmp:False|SRC-3340-RGB,DST-21-OUT;n:type:ShaderForge.SFN_Fresnel,id:5726,x:32198,y:32733,varname:node_5726,prsc:2|NRM-9153-OUT,EXP-8129-OUT;n:type:ShaderForge.SFN_NormalVector,id:9153,x:31978,y:32733,prsc:2,pt:True;n:type:ShaderForge.SFN_ConstantClamp,id:5561,x:32383,y:32733,varname:node_5561,prsc:2,min:0,max:0.9|IN-5726-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:3451,x:32573,y:32733,varname:node_3451,prsc:2,min:0.1,max:0.5|IN-5561-OUT;n:type:ShaderForge.SFN_Multiply,id:2214,x:32667,y:32912,varname:node_2214,prsc:2|A-3451-OUT,B-8009-RGB,C-5855-RGB;n:type:ShaderForge.SFN_LightColor,id:8009,x:32816,y:33063,varname:node_8009,prsc:2;n:type:ShaderForge.SFN_Max,id:21,x:31979,y:32179,varname:node_21,prsc:2|A-1904-RGB,B-8068-OUT;n:type:ShaderForge.SFN_Color,id:3340,x:31750,y:31973,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_3340,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4779412,c2:0.4779412,c3:0.4779412,c4:1;n:type:ShaderForge.SFN_Color,id:5855,x:32438,y:32952,ptovrint:False,ptlb:Gloss Color,ptin:_GlossColor,varname:node_5855,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.2352941,c3:0.4726165,c4:1;n:type:ShaderForge.SFN_Slider,id:8129,x:31811,y:32944,ptovrint:False,ptlb:Fresnel Sharpness,ptin:_FresnelSharpness,varname:node_8129,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:5.27,max:10;n:type:ShaderForge.SFN_ViewPosition,id:7541,x:30719,y:32589,varname:node_7541,prsc:2;n:type:ShaderForge.SFN_Distance,id:7131,x:31610,y:32435,varname:node_7131,prsc:2|A-2738-OUT,B-1224-OUT;n:type:ShaderForge.SFN_Slider,id:7898,x:31651,y:32606,ptovrint:False,ptlb:Falloff,ptin:_Falloff,varname:node_7898,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:79.1453,max:100;n:type:ShaderForge.SFN_Slider,id:4297,x:32629,y:32111,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:node_4297,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Divide,id:3734,x:31977,y:32440,varname:node_3734,prsc:2|A-7131-OUT,B-7898-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:6341,x:30694,y:32287,varname:node_6341,prsc:2;n:type:ShaderForge.SFN_Power,id:9940,x:32699,y:32411,varname:node_9940,prsc:2|VAL-3734-OUT,EXP-3263-OUT;n:type:ShaderForge.SFN_Slider,id:3263,x:32238,y:32572,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:node_3263,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:28.7,max:30;n:type:ShaderForge.SFN_Max,id:2738,x:31188,y:32415,varname:node_2738,prsc:2|A-6341-XYZ,B-4963-OUT;n:type:ShaderForge.SFN_Vector1,id:4963,x:30938,y:32505,varname:node_4963,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Max,id:1224,x:31188,y:32621,varname:node_1224,prsc:2|A-7541-XYZ,B-4963-OUT;proporder:1904-3340-5855-8129-7898-4297-3263;pass:END;sub:END;*/

Shader "Shader Forge/custom_lit_alpha" {
    Properties {
        _ShadowColor ("Shadow Color", Color) = (0.4963235,0.6955374,0.7941176,1)
        _Tint ("Tint", Color) = (0.4779412,0.4779412,0.4779412,1)
        _GlossColor ("Gloss Color", Color) = (1,0.2352941,0.4726165,1)
        _FresnelSharpness ("Fresnel Sharpness", Range(0.1, 10)) = 5.27
        _Falloff ("Falloff", Range(0, 100)) = 79.1453
        _Specular ("Specular", Range(0, 10)) = 0
        _Ramp ("Ramp", Range(0, 30)) = 28.7
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
            #define _GLOSSYENV 1
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "UnityPBSLighting.cginc"
            #include "UnityStandardBRDF.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _ShadowColor;
            uniform float4 _Tint;
            uniform float4 _GlossColor;
            uniform float _FresnelSharpness;
            uniform float _Falloff;
            uniform float _Specular;
            uniform float _Ramp;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
                float Pi = 3.141592654;
                float InvPi = 0.31830988618;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
/////// GI Data:
                UnityLight light;
                #ifdef LIGHTMAP_OFF
                    light.color = lightColor;
                    light.dir = lightDirection;
                    light.ndotl = LambertTerm (normalDirection, light.dir);
                #else
                    light.color = half3(0.f, 0.f, 0.f);
                    light.ndotl = 0.0f;
                    light.dir = half3(0.f, 0.f, 0.f);
                #endif
                UnityGIInput d;
                d.light = light;
                d.worldPos = i.posWorld.xyz;
                d.worldViewDir = viewDirection;
                d.atten = attenuation;
                d.boxMax[0] = unity_SpecCube0_BoxMax;
                d.boxMin[0] = unity_SpecCube0_BoxMin;
                d.probePosition[0] = unity_SpecCube0_ProbePosition;
                d.probeHDR[0] = unity_SpecCube0_HDR;
                d.boxMax[1] = unity_SpecCube1_BoxMax;
                d.boxMin[1] = unity_SpecCube1_BoxMin;
                d.probePosition[1] = unity_SpecCube1_ProbePosition;
                d.probeHDR[1] = unity_SpecCube1_HDR;
                UnityGI gi = UnityGlobalIllumination (d, 1, gloss, normalDirection);
                lightDirection = gi.light.dir;
                lightColor = gi.light.color;
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float LdotH = max(0.0,dot(lightDirection, halfDirection));
                float3 specularColor = float3(_Specular,_Specular,_Specular);
                float specularMonochrome = max( max(specularColor.r, specularColor.g), specularColor.b);
                float NdotV = max(0.0,dot( normalDirection, viewDirection ));
                float NdotH = max(0.0,dot( normalDirection, halfDirection ));
                float VdotH = max(0.0,dot( viewDirection, halfDirection ));
                float visTerm = SmithBeckmannVisibilityTerm( NdotL, NdotV, 1.0-gloss );
                float normTerm = max(0.0, NDFBlinnPhongNormalizedTerm(NdotH, RoughnessToSpecPower(1.0-gloss)));
                float specularPBL = max(0, (NdotL*visTerm*normTerm) * unity_LightGammaCorrectionConsts_PIDiv4 );
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularPBL*lightColor*FresnelTerm(specularColor, LdotH);
                half grazingTerm = saturate( gloss + specularMonochrome );
                float3 indirectSpecular = (gi.indirect.specular);
                indirectSpecular *= FresnelLerp (specularColor, grazingTerm, NdotV);
                float3 specular = (directSpecular + indirectSpecular);
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                half fd90 = 0.5 + 2 * LdotH * LdotH * (1-gloss);
                float3 directDiffuse = ((1 +(fd90 - 1)*pow((1.00001-NdotL), 5)) * (1 + (fd90 - 1)*pow((1.00001-NdotV), 5)) * NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = (_Tint.rgb*max(_ShadowColor.rgb,attenuation));
                diffuseColor *= 1-specularMonochrome;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = (clamp(clamp(pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelSharpness),0,0.9),0.1,0.5)*_LightColor0.rgb*_GlossColor.rgb);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                float node_4963 = 0.5;
                fixed4 finalRGBA = fixed4(finalColor,pow((distance(max(i.posWorld.rgb,node_4963),max(_WorldSpaceCameraPos,node_4963))/_Falloff),_Ramp));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
