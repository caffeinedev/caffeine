// Shader created with Shader Forge v1.16 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.16;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:3138,x:33492,y:32554,varname:node_3138,prsc:2|normal-557-OUT,emission-7784-OUT,custl-4321-OUT;n:type:ShaderForge.SFN_Tex2d,id:6141,x:32660,y:32597,ptovrint:False,ptlb:node_6141,ptin:_node_6141,varname:node_6141,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:1081ee838eaa14ed98469c7eb1085075,ntxv:3,isnm:False|UVIN-7981-UVOUT;n:type:ShaderForge.SFN_ScreenPos,id:7981,x:32360,y:32613,varname:node_7981,prsc:2,sctp:0;n:type:ShaderForge.SFN_Tex2d,id:7920,x:32960,y:32393,ptovrint:False,ptlb:node_7920,ptin:_node_7920,varname:node_7920,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:497da62ef69ee4092a2685282ca2fcf6,ntxv:3,isnm:True|UVIN-3965-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:3965,x:32639,y:32308,varname:node_3965,prsc:2,uv:0;n:type:ShaderForge.SFN_Fresnel,id:577,x:32646,y:32882,varname:node_577,prsc:2|NRM-3268-OUT,EXP-6712-OUT;n:type:ShaderForge.SFN_Slider,id:6712,x:32182,y:33110,ptovrint:False,ptlb:node_6712,ptin:_node_6712,varname:node_6712,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.1,cur:5.542735,max:20;n:type:ShaderForge.SFN_Multiply,id:4321,x:32898,y:32966,varname:node_4321,prsc:2|A-577-OUT,B-9523-RGB;n:type:ShaderForge.SFN_Color,id:9523,x:32627,y:33091,ptovrint:False,ptlb:node_9523,ptin:_node_9523,varname:node_9523,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.8235294,c2:0.7298174,c3:0.2058824,c4:1;n:type:ShaderForge.SFN_Color,id:6265,x:32786,y:32712,ptovrint:False,ptlb:node_6265,ptin:_node_6265,varname:node_6265,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9188641,c2:1,c3:0.4117647,c4:1;n:type:ShaderForge.SFN_Multiply,id:7784,x:33094,y:32679,varname:node_7784,prsc:2|A-6141-RGB,B-6265-RGB;n:type:ShaderForge.SFN_Blend,id:557,x:33254,y:32337,varname:node_557,prsc:2,blmd:17,clmp:False|SRC-9860-RGB,DST-7920-RGB;n:type:ShaderForge.SFN_Color,id:9860,x:32992,y:32178,ptovrint:False,ptlb:node_9860,ptin:_node_9860,varname:node_9860,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_NormalVector,id:2066,x:31997,y:32707,prsc:2,pt:True;n:type:ShaderForge.SFN_Vector1,id:6594,x:31997,y:32907,varname:node_6594,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:3268,x:32196,y:32787,varname:node_3268,prsc:2|A-2066-OUT,B-6594-OUT;proporder:6141-7920-6712-9523-6265-9860;pass:END;sub:END;*/

Shader "Shader Forge/normal_fancy" {
    Properties {
        _node_6141 ("node_6141", 2D) = "bump" {}
        _node_7920 ("node_7920", 2D) = "bump" {}
        _node_6712 ("node_6712", Range(0.1, 20)) = 5.542735
        _node_9523 ("node_9523", Color) = (0.8235294,0.7298174,0.2058824,1)
        _node_6265 ("node_6265", Color) = (0.9188641,1,0.4117647,1)
        _node_9860 ("node_9860", Color) = (0.5,0.5,0.5,1)
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
            uniform sampler2D _node_6141; uniform float4 _node_6141_ST;
            uniform sampler2D _node_7920; uniform float4 _node_7920_ST;
            uniform float _node_6712;
            uniform float4 _node_9523;
            uniform float4 _node_6265;
            uniform float4 _node_9860;
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
                i.normalDir = normalize(i.normalDir);
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _node_7920_var = UnpackNormal(tex2D(_node_7920,TRANSFORM_TEX(i.uv0, _node_7920)));
                float3 normalLocal = abs(_node_9860.rgb-_node_7920_var.rgb);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
////// Lighting:
////// Emissive:
                float4 _node_6141_var = tex2D(_node_6141,TRANSFORM_TEX(i.screenPos.rg, _node_6141));
                float3 emissive = (_node_6141_var.rgb*_node_6265.rgb);
                float3 finalColor = emissive + (pow(1.0-max(0,dot((normalDirection*1.0), viewDirection)),_node_6712)*_node_9523.rgb);
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
