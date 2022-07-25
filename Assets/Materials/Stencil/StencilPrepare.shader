/*-------------------------------------------------------
Writer: Alvaro Pazmiño
Source: https://www.ronja-tutorials.com/post/022-stencil-buffers/
Project: Travel n Transit (Elevator)
---------------------------------------------------------*/
Shader "Custom/StencilPrepare"
{
    Properties
    {
        [IntRange] _StencilID ("Stencil ID", Range(0, 255)) = 0
    }
    SubShader
    {
        Tags 
        { 
            "RenderType"="Opaque" 
            "Queue"="Geometry"
            "RenderPipeline" = "UniversalPipeline"
        }

        Pass
        {
            Blend Zero One
            Zwrite Off

            Stencil
            {
                Ref [_StencilID]
                Comp Always
                Pass Replace
                Fail Keep
            }
        }
    }
}
