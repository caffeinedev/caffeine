// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:9361,x:33546,y:32664,varname:node_9361,prsc:2|diff-2214-OUT,spec-2214-OUT,normal-8963-RGB,emission-7988-OUT,custl-2214-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:32103,y:32479,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_Color,id:1904,x:32103,y:32650,ptovrint:False,ptlb:shadow color,ptin:_shadowcolor,varname:node_1904,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7436743,c2:0.890553,c3:0.9632353,c4:1;n:type:ShaderForge.SFN_Blend,id:7988,x:32573,y:32563,varname:node_7988,prsc:2,blmd:1,clmp:True|SRC-4900-OUT,DST-21-OUT;n:type:ShaderForge.SFN_Fresnel,id:5726,x:32474,y:32969,varname:node_5726,prsc:2|NRM-9153-OUT,EXP-8129-OUT;n:type:ShaderForge.SFN_NormalVector,id:9153,x:32061,y:32841,prsc:2,pt:True;n:type:ShaderForge.SFN_ConstantClamp,id:5561,x:32700,y:32969,varname:node_5561,prsc:2,min:0,max:0.9|IN-5726-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:3451,x:32886,y:32954,varname:node_3451,prsc:2,min:0.1,max:0.5|IN-5561-OUT;n:type:ShaderForge.SFN_Multiply,id:2214,x:32946,y:33149,varname:node_2214,prsc:2|A-6192-OUT,B-8009-RGB,C-5855-RGB;n:type:ShaderForge.SFN_LightColor,id:8009,x:32747,y:33326,varname:node_8009,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:2681,x:32532,y:32305,ptovrint:False,ptlb:texture,ptin:_texture,varname:node_2681,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9393f83272ff7491e81340575991ff97,ntxv:0,isnm:False|UVIN-5057-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:5057,x:32297,y:32206,varname:node_5057,prsc:2,uv:0;n:type:ShaderForge.SFN_Max,id:21,x:32301,y:32583,varname:node_21,prsc:2|A-1904-RGB,B-8068-OUT;n:type:ShaderForge.SFN_Blend,id:4900,x:32903,y:32285,varname:node_4900,prsc:2,blmd:10,clmp:True|SRC-3340-RGB,DST-2681-RGB;n:type:ShaderForge.SFN_Color,id:3340,x:32688,y:32126,ptovrint:False,ptlb:Tint,ptin:_Tint,varname:node_3340,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4779412,c2:0.4779412,c3:0.4779412,c4:1;n:type:ShaderForge.SFN_Color,id:5855,x:32557,y:33326,ptovrint:False,ptlb:Gloss Color,ptin:_GlossColor,varname:node_5855,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.2352941,c3:0.4726165,c4:1;n:type:ShaderForge.SFN_Posterize,id:6192,x:32586,y:33174,varname:node_6192,prsc:2|IN-3451-OUT,STPS-5434-OUT;n:type:ShaderForge.SFN_Vector1,id:5434,x:32279,y:33254,varname:node_5434,prsc:2,v1:2;n:type:ShaderForge.SFN_Slider,id:8129,x:31970,y:33066,ptovrint:False,ptlb:fresnel intensity,ptin:_fresnelintensity,varname:node_8129,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:0.1,max:100;n:type:ShaderForge.SFN_Tex2d,id:8963,x:32915,y:32702,ptovrint:False,ptlb:normal map,ptin:_normalmap,varname:node_8963,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:fb235e67fc6c240d991837474018c7ac,ntxv:3,isnm:True|UVIN-9101-OUT;n:type:ShaderForge.SFN_Divide,id:9101,x:32664,y:32776,varname:node_9101,prsc:2|A-5057-UVOUT,B-8590-OUT;n:type:ShaderForge.SFN_Slider,id:8590,x:32268,y:32751,ptovrint:False,ptlb:normal scaling factor,ptin:_normalscalingfactor,varname:node_8590,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.01,cur:0.5,max:5;proporder:1904-2681-3340-5855-8129-8963-8590;pass:END;sub:END;*/

Shader "Shader Forge/sparkly_normals" {
    Properties {
        _shadowcolor ("shadow color", Color) = (0.7436743,0.890553,0.9632353,1)
        _texture ("texture", 2D) = "white" {}
        _Tint ("Tint", Color) = (0.4779412,0.4779412,0.4779412,1)
        _GlossColor ("Gloss Color", Color) = (1,0.2352941,0.4726165,1)
        _fresnelintensity ("fresnel intensity", Range(0.1, 100)) = 0.1
        _normalmap ("normal map", 2D) = "bump" {}
        _normalscalingfactor ("normal scaling factor", Range(0.01, 5)) = 0.5
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
            uniform float4 _shadowcolor;
            uniform sampler2D _texture; uniform float4 _texture_ST;
            uniform float4 _Tint;
            uniform float4 _GlossColor;
            uniform float _fresnelintensity;
            uniform sampler2D _normalmap; uniform float4 _normalmap_ST;
            uniform float _normalscalingfactor;
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
                UNITY_FOG_COORDS(7)
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
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float2 node_9101 = (i.uv0/_normalscalingfactor);
                float3 _normalmap_var = UnpackNormal(tex2D(_normalmap,TRANSFORM_TEX(node_9101, _normalmap)));
                float3 normalLocal = _normalmap_var.rgb;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                
                float nSign = sign( dot( viewDirection, i.normalDir ) ); // Reverse normal if this is a backface
                i.normalDir *= nSign;
                normalDirection *= nSign;
                
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float4 _texture_var = tex2D(_texture,TRANSFORM_TEX(i.uv0, _texture));
                float3 emissive = saturate((saturate(( _texture_var.rgb > 0.5 ? (1.0-(1.0-2.0*(_texture_var.rgb-0.5))*(1.0-_Tint.rgb)) : (2.0*_texture_var.rgb*_Tint.rgb) ))*max(_shadowcolor.rgb,attenuation)));
                float node_5434 = 2.0;
                float3 node_2214 = (floor(clamp(clamp(pow(1.0-max(0,dot(normalDirection, viewDirection)),_fresnelintensity),0,0.9),0.1,0.5) * node_5434) / (node_5434 - 1)*_LightColor0.rgb*_GlossColor.rgb);
                float3 finalColor = emissive + node_2214;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
