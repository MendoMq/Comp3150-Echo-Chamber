Shader "Custom/AntiShader"
{
    SubShader
    {
        Pass{
            Tags { "RenderType"="Opaque" "Queue"="Geometry+1"}
            ColorMask 0
            ZWrite off
            cull off
            Stencil{
                Ref 2
                Comp always
                Pass replace
            }
        }
    }
}
