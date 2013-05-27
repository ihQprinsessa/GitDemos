Shader "Custom/NewShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color ("Color", Color) = (1.0, 1.0, 1.0, 1.0)
	}
	SubShader {
		Pass{
			Material {
	        Diffuse [_Color]
	        Ambient [_Color]
	        Shininess [_Shininess]
	        Specular [_SpecColor]
	        Emission [_Emission]
		    }
		    Lighting On
		    SeparateSpecular On
		    SetTexture [_MainTex] {
		        constantColor [_Color]
		        Combine texture * primary DOUBLE, texture * constant
		    }
		}	
	}
		
	FallBack "Diffuse"
}
