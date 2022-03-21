Shader "Custom/EchoShader"
{
    SubShader
    {
        Pass{
            Tags { "RenderType"="Opaque" "Queue"="Geometry+1"}
            ColorMask 0
            ZWrite off
            cull off
            Stencil{
                Ref 1
                Comp always
                Pass replace
            }
        }
    }
}
