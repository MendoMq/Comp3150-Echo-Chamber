Shader "Custom/DoorBubbleShader"
{
    SubShader
    {
        Pass{
            Tags { "RenderType"="Opaque" "Queue"="Geometry+1"}
            ColorMask 0
            ZWrite off
            cull off

            Stencil{
                Ref 3
                Comp always
                Pass replace
            }
        }
    }
}
