
grammar Shader;

/*
##############################################################################################################################################
#######################################################################    PARSER RULES      ##################################################
##############################################################################################################################################
*/


@header
{
	#pragma warning disable 3021
    using System.Globalization;
	using ShaderLib;
	using ShaderLib.Elements;
    using ShaderLib.Elements.Directives;
    using ShaderLib.Elements.Directives.Attributes;
    using ShaderLib.Elements.Directives.ShaderDirectives;
    using ShaderLib.Elements.Directives.ShaderDirectives.General;
    using ShaderLib.Elements.Directives.ShaderDirectives.Q3Map;
    using ShaderLib.Elements.Directives.ShaderDirectives.Qer;
    using ShaderLib.Elements.Directives.StageDirectives;
}

shaderList returns [List<Shader> value]
    : {$value = new List<Shader>();}
      (a1=shader {$value.Add($a1.value);})?
      ( 
        WS* NL (WS | NL)*
        a2=shader {$value.Add($a2.value);} 
      )*
    ;

shader returns [Shader value]
    : {
       $value = new Shader()
		   {
				CompileTime = false,
				Directives = new List<ShaderDirective>(),
				Stages = new List<Stage>()
		   };
       }
      a1=pathParam {$value.Name = $a1.value;} (COMPILETIME {$value.CompileTime = true;})? 
      (WS | NL)+
      LCURLYBRACKET
      (
        (WS | NL)+
        a2=shaderDirectiveList {$value.Directives = $a2.value;}
      )?
      (
        WS* NL (WS | NL)*
        a3=stageList {$value.Stages = $a3.value;}
      )?
      WS* NL (WS | NL)*
      RCURLYBRACKET
    ;

stage returns [Stage value]
    :
      { $value = new Stage() 
       { 
            Directives = new List<StageDirective>()
       }; 
       }
      LCURLYBRACKET
      (
        WS* NL (WS | NL)*
        a=stageDirectiveList {$value.Directives = $a.value;}
        WS* NL (WS | NL)*
      )?
      RCURLYBRACKET 
    ;

shaderDirectiveList returns [List<ShaderDirective> value]
    : {$value = new List<ShaderDirective>();}
      (a1=shaderDirective {$value.Add($a1.value);})? 
      ( 
        WS* NL (WS | NL)*
        a2=shaderDirective {$value.Add($a2.value);} 
      )*
    ;

stageList returns [List<Stage> value]
    : {$value = new List<Stage>();}
      (a1=stage {$value.Add($a1.value);})? 
      ( 
        WS* NL (WS | NL)* 
        a2=stage {$value.Add($a2.value);} 
      )*
    ;

stageDirectiveList returns [List<StageDirective> value]
    : {$value = new List<StageDirective>();}
      (a1=stageDirective {$value.Add($a1.value);})? 
      ( 
        WS* NL (WS | NL)*
        a2=stageDirective {$value.Add($a2.value);} 
      )*
    ;

shaderDirective returns [ShaderDirective value]
    : a1=generalDirective           {$value = $a1.value;}
    | a2=surfaceParmDirective       {$value = $a2.value;}
    | a3=q3mapDirective             {$value = $a3.value;}
    | a4=editorDirective            {$value = $a4.value;}
    ;

//GENERAL DIRECTIVES DEFINITIONS

generalDirective returns [GeneralDirective value]
    : a1=cullDirective                 {$value = $a1.value;}
    | a2=deformVertexesDirective       {$value = $a2.value;}
    | a3=fogParmsDirective             {$value = $a3.value;}
    | a4=noMipMapsDirective            {$value = $a4.value;}
    | a5=noPicMipDirective             {$value = $a5.value;}
    | a6=polygonOffsetDirective        {$value = $a6.value;}
    | a7=portalDirective               {$value = $a7.value;}
    | a8=skyParmsDirective             {$value = $a8.value;}
    | a9=sortDirective                 {$value = $a9.value;}
    | a10=tessSizeDirective            {$value = $a10.value;}
    | a11=lightDirective               {$value = $a11.value;}
    | a12=entityMergableDirective               {$value = $a12.value;}
    ;

cullDirective                       returns [Cull value]
    : CULL                          {$value = new Cull();}
    | CULL WS a=cullType            {$value = new Cull($a.value);}
    ;


deformVertexesDirective             returns [DeformVertexes value]
    : DEFORMVERTEXES WS AUTOSPRITE  {$value = new DeformVertexesAutoSprite();}
    | DEFORMVERTEXES WS AUTOSPRITE2  {$value = new DeformVertexesAutoSprite2();}
    | DEFORMVERTEXES WS BULGE WS a1=numberParam WS  a2=numberParam  WS a3=numberParam  {$value = new DeformVertexesBulge($a1.value, $a2.value, $a3.value);}
    | DEFORMVERTEXES WS MOVE WS b1=numberParam WS b2=numberParam  WS b3=numberParam  WS b4=waveFormFunctionType WS b5=numberParam WS b6=numberParam WS b7=numberParam  WS b8=numberParam  {$value = new DeformVertexesMove($b1.value, $b2.value, $b3.value, $b4.value, $b5.value, $b6.value, $b7.value, $b8.value);}
    | DEFORMVERTEXES WS NORMAL WS c1=numberParam WS c2=waveFormFunctionType WS c3=numberParam WS c4=numberParam WS c5=numberParam {$value = new DeformVertexesNormal($c1.value, $c2.value, $c3.value, $c4.value, $c5.value);}
    | DEFORMVERTEXES WS NORMAL WS f1=numberParam WS f2=numberParam {$value = new DeformVertexesNormal(0, null, 0, $f1.value, $f2.value);}
    | DEFORMVERTEXES WS WAVE WS g1=numberParam WS g2=waveFormFunctionType WS g3=numberParam WS g4=numberParam WS g5=numberParam WS g6=numberParam {$value = new DeformVertexesWave($g1.value, $g2.value, $g3.value, $g4.value, $g5.value, $g6.value);}
    | DEFORMVERTEXES WS TEXT e=intParam {$value = new DeformVertexesText($e.value);}
    | DEFORMVERTEXES WS PROJECTIONSHADOW {$value = new DeformVertexesProjectionShadow();}
    ;

fogParmsDirective returns [FogParms value]
    : FOGPARMS WS? LROUNDBRACKET WS? a1=numberParam WS a2=numberParam WS a3=numberParam WS? RROUNDBRACKET WS? a4=numberParam {$value = new FogParms($a1.value, $a2.value, $a3.value, $a4.value);}
    ;

noMipMapsDirective returns [NoMipMaps value]
    : NOMIPMAPS    {$value = new NoMipMaps();}
    ;

noPicMipDirective returns [NoPicMip value]
    : NOPICMIP    {$value = new NoPicMip();}
    ;

polygonOffsetDirective returns [PolygonOffset value]
    : POLYGONOFFSET    {$value = new PolygonOffset();}
    ;

portalDirective returns [Portal value]
    : PORTAL    {$value = new Portal();}
    ;

skyParmsDirective returns [SkyParms value]
    : {string path1 = null; float float1 = 128; string path2 = null;}
        SKYPARMS WS (DEFAULT | a1=pathParam {path1=$a1.value;})  WS (DEFAULT | a2=numberParam {float1=$a2.value;})  WS (DEFAULT | a3=pathParam {path2=$a3.value;})  {$value = new SkyParms(path1, float1, path2);}
    ;

sortDirective returns [Sort value]
    : SORT WS a=sortType {$value = new Sort($a.value);} 
    | SORT WS b=intParam {$value = new Sort($b.value);} 
    ;

tessSizeDirective returns [TessSize value]
    : TESSSIZE WS a=numberParam    {$value = new TessSize($a.value);}
    ;

lightDirective returns [Light value]
    : LIGHT WS a=intParam    {$value = new Light($a.value);}
    ;

entityMergableDirective returns [EntityMergable value]
    : ENTITYMERGABLE    {$value = new EntityMergable();}
    ;

//SURFACEPARM DIRECTIVES DEFINITIONS

surfaceParmDirective returns [SurfaceParm value]
    : SURFACEPARM WS a1=surfaceParmType  {$value = new SurfaceParm($a1.value);}
    ;

//Q3MAP DIRECTIVES DEFINITIONS

q3mapDirective  returns [Q3MapDirective value]
    : a1=q3mapAlphaGenDirective              {$value = $a1.value;}
    | a2=q3mapAlphaModDirective              {$value = $a2.value;}
    | a3=q3mapBackShaderDirective              {$value = $a3.value;}
    | a4=q3mapBackSplashDirective              {$value = $a4.value;}
    | a5=q3mapBaseShaderDirective              {$value = $a5.value;}
    | a6=q3mapBounceDirective              {$value = $a6.value;}
    | a7=q3mapBounceScaleDirective              {$value = $a7.value;}
    | a8=q3mapClipModelDirective              {$value = $a8.value;}
    | a9=q3mapCloneShaderDirective              {$value = $a9.value;}
    | a10=q3mapColorGenDirective              {$value = $a10.value;}
    | a11=q3mapColorModDirective              {$value = $a11.value;}
    | a12=q3mapFancyWaterDirective              {$value = $a12.value;}
    | a13=q3mapFogDirDirective              {$value = $a13.value;}
    | a14=q3mapForceMetaDirective              {$value = $a14.value;}
    | a15=q3mapForceSunLightDirective              {$value = $a15.value;}
    | a16=q3mapFurDirective              {$value = $a16.value;}
    | a17=q3mapGlobalTextureDirective              {$value = $a17.value;}
    | a18=q3mapIndexedDirective              {$value = $a18.value;}
    | a19=q3mapInvertDirective              {$value = $a19.value;}
    | a20=q3mapLightImageDirective              {$value = $a20.value;}
    | a21=q3mapLightmapAxisDirective              {$value = $a21.value;}
    | a22=q3mapLightmapBrightnessDirective              {$value = $a22.value;}
    | a23=q3mapLightmapFilterRadiusDirective              {$value = $a23.value;}
    | a24=q3mapLightmapGammaDirective              {$value = $a24.value;}
    | a25=q3mapLightmapMergableDirective              {$value = $a25.value;}
    | a26=q3mapLightmapSampleOffsetDirective              {$value = $a26.value;}
    | a27=q3mapLightmapSampleSizeDirective              {$value = $a27.value;}
    | a28=q3mapLightmapSizeDirective              {$value = $a28.value;}
    | a29=q3mapLightRGBDirective              {$value = $a29.value;}
    | a30=q3mapLightStyleDirective              {$value = $a30.value;}
    | a31=q3mapLightSubdivideDirective              {$value = $a31.value;}
    | a32=q3mapNoClipDirective              {$value = $a32.value;}
    | a33=q3mapNoFastDirective              {$value = $a33.value;}
    | a34=q3mapNoFogDirective              {$value = $a34.value;}
    | a35=q3mapNoLightmapDirective              {$value = $a35.value;}
    | a36=q3mapNonPlanarDirective              {$value = $a36.value;}
    | a37=q3mapNormalImageDirective              {$value = $a37.value;}
    | a38=q3mapNoTJuncDirective              {$value = $a38.value;}
    | a39=q3mapNoVertexLightDirective              {$value = $a39.value;}
    | a40=q3mapNoVertexShadowsDirective              {$value = $a40.value;}
    | a41=q3mapOffsetDirective              {$value = $a41.value;}
    | a42=q3mapPatchShadowsDirective              {$value = $a42.value;}
    | a43=q3mapRemapShaderDirective              {$value = $a43.value;}
    | a44=q3mapRGBGenDirective              {$value = $a44.value;}
    | a45=q3mapRGBModDirective              {$value = $a45.value;}
    | a46=q3mapShadeAngleDirective              {$value = $a46.value;}
    | a47=q3mapSkyLightDirective              {$value = $a47.value;}
    | a48=q3mapSplotchFixDirective              {$value = $a48.value;}
    | a49=q3mapStyleMarkerDirective              {$value = $a49.value;}
    | a50=q3mapStyleMarker2Directive              {$value = $a50.value;}
    | a51=q3mapSunDirective              {$value = $a51.value;}
    | a52=q3mapSunExtDirective              {$value = $a52.value;}
    | a53=q3mapSurfaceLightDirective              {$value = $a53.value;}
    | a54=q3mapSurfaceModelDirective              {$value = $a54.value;}
    | a55=q3mapTcGenDirective              {$value = $a55.value;}
    | a56=q3mapTcModDirective              {$value = $a56.value;}
    | a57=q3mapTerrainDirective              {$value = $a57.value;}
    | a58=q3mapTessSizeDirective              {$value = $a58.value;}
    | a59=q3mapTextureSizeDirective              {$value = $a59.value;}
    | a60=q3mapTraceLightDirective              {$value = $a60.value;}
    | a61=q3mapVertexScaleDirective              {$value = $a61.value;}
    | a62=q3mapVertexShadowsDirective              {$value = $a62.value;}
    | a63=q3mapVLightDirective              {$value = $a63.value;}
    | a64=q3mapNoFancyWaterDirective              {$value = $a64.value;}
    | a65=q3mapCheapWaterDirective              {$value = $a65.value;}
    ;

q3mapAlphaGenDirective returns [Q3MapAlphaGen value]
    : Q3MAP_ALPHAGEN WS CONST WS a=numberParam {$value= new Q3MapAlphaGenConst($a.value);}
    ;

q3mapAlphaModDirective returns [Q3MapAlphaMod value]
    : Q3MAP_ALPHAMOD WS DOTPRODUCT WS? LROUNDBRACKET WS? a1=numberParam WS a2=numberParam WS a3=numberParam WS? RROUNDBRACKET {$value = new Q3MapAlphaModDotProduct($a1.value, $a2.value, $a3.value);}
    | Q3MAP_ALPHAMOD WS DOTPRODUCT2 WS? LROUNDBRACKET WS? b1=numberParam WS b2=numberParam WS b3=numberParam WS? RROUNDBRACKET {$value = new Q3MapAlphaModDotProduct2($b1.value, $b2.value, $b3.value);}
    | Q3MAP_ALPHAMOD WS SCALE WS c=numberParam {$value = new Q3MapAlphaModScale($c.value);}
    | Q3MAP_ALPHAMOD WS VOLUME {$value = new Q3MapAlphaModVolume();}
    | Q3MAP_ALPHAMOD WS SET WS d=numberParam {$value = new Q3MapAlphaModSet($d.value);}
    ;

q3mapBackShaderDirective returns [Q3MapBackShader value]
    : Q3MAP_BACKSHADER WS a=pathParam {$value = new Q3MapBackShader($a.value);}
    ;

q3mapBackSplashDirective returns [Q3MapBackSplash value]
    : Q3MAP_BACKSPLASH WS a1=numberParam WS a2=numberParam {$value = new Q3MapBackSplash($a1.value, $a2.value);}
    ;

q3mapBaseShaderDirective returns [Q3MapBaseShader value]
    : Q3MAP_BASESHADER WS a=pathParam {$value = new Q3MapBaseShader($a.value);}
    ;

q3mapBounceDirective returns [Q3MapBounce value]
    : Q3MAP_BOUNCE WS a=numberParam {$value = new Q3MapBounce($a.value);}
    ;

q3mapBounceScaleDirective returns [Q3MapBounceScale value]
    : Q3MAP_BOUNCESCALE WS a=numberParam {$value = new Q3MapBounceScale($a.value);}
    ;

q3mapClipModelDirective returns [Q3MapClipModel value]
    : Q3MAP_CLIPMODEL {$value = new Q3MapClipModel();}
    ;

q3mapCloneShaderDirective returns [Q3MapCloneShader value]
    : Q3MAP_CLONESHADER WS a=pathParam {$value = new Q3MapCloneShader($a.value);}
    ;

q3mapColorGenDirective returns [Q3MapColorGen value]
    : Q3MAP_COLORGEN WS CONST WS? LROUNDBRACKET WS? a1=numberParam WS a2=numberParam WS a3=numberParam WS? RROUNDBRACKET {$value = new Q3MapColorGenConst($a1.value, $a2.value, $a3.value);}
    ;

q3mapColorModDirective returns [Q3MapColorMod value]
    : Q3MAP_COLORMOD WS SCALE WS? LROUNDBRACKET WS? a1=numberParam WS a2=numberParam WS a3=numberParam WS? RROUNDBRACKET {$value = new Q3MapColorModScale($a1.value, $a2.value, $a3.value);}
    | Q3MAP_COLORMOD WS SET WS? LROUNDBRACKET WS? b1=numberParam WS b2=numberParam WS b3=numberParam WS? RROUNDBRACKET {$value = new Q3MapColorModSet($b1.value, $b2.value, $b3.value);}
    | Q3MAP_COLORMOD WS VOLUME {$value = new Q3MapColorModVolume();}
    ;

q3mapFancyWaterDirective returns [Q3MapFancyWater value]
    : Q3MAP_FANCYWATER WS a1=numberParam WS a2=numberParam WS a3=numberParam WS a4=numberParam {$value = new Q3MapFancyWater($a1.value, $a2.value, $a3.value, $a4.value);}
    ;

q3mapFogDirDirective returns [Q3MapFogDir value]
    : Q3MAP_FOGDIR  WS a1=numberParam WS a2=numberParam WS a3=numberParam {$value = new Q3MapFogDir($a1.value, $a2.value, $a3.value);}
    ;

q3mapForceMetaDirective returns [Q3MapForceMeta value]
    : Q3MAP_FORCEMETA {$value = new Q3MapForceMeta();}
    ;

q3mapForceSunLightDirective returns [Q3MapForceSunLight value]
    : Q3MAP_FORCESUNLIGHT {$value = new Q3MapForceSunLight();}
    ;

q3mapFurDirective returns [Q3MapFur value]
    : Q3MAP_FUR WS a1=numberParam WS a2=numberParam WS a3=numberParam {$value = new Q3MapFur($a1.value, $a2.value, $a3.value);}
    ;

q3mapGlobalTextureDirective returns [Q3MapGlobalTexture value]
    : Q3MAP_GLOBALTEXTURE {$value = new Q3MapGlobalTexture();}
    ;

q3mapIndexedDirective returns [Q3MapIndexed value]
    : Q3MAP_INDEXED {$value = new Q3MapIndexed();}
    ;

q3mapInvertDirective returns [Q3MapInvert value]
    : Q3MAP_INVERT {$value = new Q3MapInvert();}
    ;

q3mapLightImageDirective returns [Q3MapLightImage value]
    : Q3MAP_LIGHTIMAGE WS a=pathParam {$value = new Q3MapLightImage($a.value);}
    ;

q3mapLightmapAxisDirective returns [Q3MapLightmapAxis value]
    : Q3MAP_LIGHTMAPAXIS WS a=q3map_lightmapAxisType {$value = new Q3MapLightmapAxis($a.value);}
    ;

q3mapLightmapBrightnessDirective returns [Q3MapLightmapBrightness value]
    : Q3MAP_LIGHTMAPBRIGHTNESS WS a=numberParam {$value = new Q3MapLightmapBrightness($a.value);}
    ;

q3mapLightmapFilterRadiusDirective returns [Q3MapLightmapFilterRadius value]
    : Q3MAP_LIGHTMAPFILTERRADIUS WS a1=numberParam WS a2=numberParam {$value = new Q3MapLightmapFilterRadius($a1.value, $a2.value);}
    ;

q3mapLightmapGammaDirective returns [Q3MapLightmapGamma value]
    : Q3MAP_LIGHTMAPGAMMA WS a=numberParam {$value = new Q3MapLightmapGamma($a.value);}
    ;
q3mapLightmapMergableDirective returns [Q3MapLightmapMergable value]
    : Q3MAP_LIGHTMAPMERGABLE {$value = new Q3MapLightmapMergable();}
    ;

q3mapLightmapSampleOffsetDirective returns [Q3MapLightmapSampleOffset value]
    : Q3MAP_LIGHTMAPSAMPLEOFFSET WS a=numberParam {$value = new Q3MapLightmapSampleOffset($a.value);}
    ;

q3mapLightmapSampleSizeDirective returns [Q3MapLightmapSampleSize value]
    : Q3MAP_LIGHTMAPSAMPLESIZE WS a=intParam {$value = new Q3MapLightmapSampleSize($a.value);}
    ;

q3mapLightmapSizeDirective returns [Q3MapLightmapSize value]
    : Q3MAP_LIGHTMAPSIZE WS a1=numberParam WS a2=numberParam {$value = new Q3MapLightmapSize($a1.value, $a2.value);}
    ;

q3mapLightRGBDirective returns [Q3MapLightRGB value]
    : Q3MAP_LIGHTRGB WS a1=numberParam WS a2=numberParam WS a3=numberParam {$value = new Q3MapLightRGB($a1.value, $a2.value, $a3.value);}
    ;

q3mapLightStyleDirective returns [Q3MapLightStyle value]
    : Q3MAP_LIGHTSTYLE WS a=intParam {$value = new Q3MapLightStyle($a.value);}
    ;

q3mapLightSubdivideDirective returns [Q3MapLightSubdivide value]
    : Q3MAP_LIGHTSUBDIVIDE WS a=intParam {$value = new Q3MapLightSubdivide($a.value);}
    ;

q3mapNoClipDirective returns [Q3MapNoClip value]
    : Q3MAP_NOCLIP {$value = new Q3MapNoClip();}
    ;

q3mapNoFastDirective returns [Q3MapNoFast value]
    : Q3MAP_NOFAST {$value = new Q3MapNoFast();}
    ;

q3mapNoFogDirective returns [Q3MapNoFog value]
    : Q3MAP_NOFOG {$value = new Q3MapNoFog();}
    ;

q3mapNoLightmapDirective returns [Q3MapNoLightmap value]
    : Q3MAP_NOLIGHTMAP {$value = new Q3MapNoLightmap();}
    ;

q3mapNonPlanarDirective returns [Q3MapNonPlanar value]
    : Q3MAP_NONPLANAR {$value = new Q3MapNonPlanar();}
    ;

q3mapNormalImageDirective returns [Q3MapNormalImage value]
    : Q3MAP_NORMALIMAGE WS a=pathParam {$value = new Q3MapNormalImage($a.value);}
    ;

q3mapNoTJuncDirective returns [Q3MapNoTJunc value]
    : Q3MAP_NOTJUNC {$value = new Q3MapNoTJunc();}
    ;

q3mapNoVertexLightDirective returns [Q3MapNoVertexLight value]
    : Q3MAP_NOVERTEXLIGHT {$value = new Q3MapNoVertexLight();}
    ;

q3mapNoVertexShadowsDirective returns [Q3MapNoVertexShadows value]
    : Q3MAP_NOVERTEXSHADOWS {$value = new Q3MapNoVertexShadows();}
    ;

q3mapOffsetDirective returns [Q3MapOffset value]
    : Q3MAP_OFFSET WS a=numberParam {$value = new Q3MapOffset($a.value);}
    ;

q3mapPatchShadowsDirective returns [Q3MapPatchShadows value]
    : Q3MAP_PATCHSHADOWS {$value = new Q3MapPatchShadows();}
    ;

q3mapRemapShaderDirective returns [Q3MapRemapShader value]
    : Q3MAP_REMAPSHADER WS a=pathParam {$value = new Q3MapRemapShader($a.value);}
    ;

q3mapRGBGenDirective returns [Q3MapRGBGen value]
    : Q3MAP_RGBGEN WS CONST WS? LROUNDBRACKET WS? a1=numberParam WS a2=numberParam WS a3=numberParam WS? RROUNDBRACKET {$value = new Q3MapRGBGenConst($a1.value, $a2.value, $a3.value);}
    ;

q3mapRGBModDirective returns [Q3MapRGBMod value]
    : Q3MAP_RGBMOD WS SCALE WS? LROUNDBRACKET WS? a1=numberParam WS a2=numberParam WS a3=numberParam WS? RROUNDBRACKET {$value = new Q3MapRGBModScale($a1.value, $a2.value, $a3.value);}
    | Q3MAP_RGBMOD WS SET WS? LROUNDBRACKET WS? b1=numberParam WS b2=numberParam WS b3=numberParam WS? RROUNDBRACKET {$value = new Q3MapRGBModSet($b1.value, $b2.value, $b3.value);}
    | Q3MAP_RGBMOD WS VOLUME {$value = new Q3MapRGBModVolume();}
    ;

q3mapShadeAngleDirective returns [Q3MapShadeAngle value]
    : Q3MAP_SHADEANGLE WS a=numberParam {$value = new Q3MapShadeAngle($a.value);}
    ;

q3mapSkyLightDirective returns [Q3MapSkyLight value]
    : Q3MAP_SKYLIGHT WS a1=numberParam WS a2=numberParam {$value = new Q3MapSkyLight($a1.value, $a2.value);}
    ;

q3mapSplotchFixDirective returns [Q3MapSplotchFix value]
    : Q3MAP_SPLOTCHFIX {$value = new Q3MapSplotchFix();}
    ;

q3mapStyleMarkerDirective returns [Q3MapStyleMarker value]
    : Q3MAP_STYLEMARKER {$value = new Q3MapStyleMarker();}
    ;

q3mapStyleMarker2Directive returns [Q3MapStyleMarker2 value]
    : Q3MAP_STYLEMARKER2 {$value = new Q3MapStyleMarker2();}
    ;

q3mapSunDirective returns [Q3MapSun value]
    : Q3MAP_SUN  WS a1=numberParam WS a2=numberParam WS a3=numberParam WS a4=numberParam WS a5=numberParam WS a6=numberParam {$value = new Q3MapSun($a1.value, $a2.value, $a3.value, $a4.value, $a5.value, $a6.value);}
    ;

q3mapSunExtDirective returns [Q3MapSunExt value]
    : Q3MAP_SUNEXT  WS a1=numberParam WS a2=numberParam WS a3=numberParam WS a4=numberParam WS a5=numberParam WS a6=numberParam WS a7=numberParam WS a8=numberParam {$value = new Q3MapSunExt($a1.value, $a2.value, $a3.value, $a4.value, $a5.value, $a6.value, $a7.value, $a8.value);}
    ;

q3mapSurfaceLightDirective returns [Q3MapSurfaceLight value]
    : Q3MAP_SURFACELIGHT WS a=numberParam {$value = new Q3MapSurfaceLight($a.value);}
    ;

q3mapSurfaceModelDirective returns [Q3MapSurfaceModel value]
    : Q3MAP_SURFACEMODEL WS a1=pathParam WS a2=numberParam WS a3=numberParam WS a4=numberParam WS a5=numberParam WS a6=numberParam WS a7=numberParam WS a8=boolParam  {$value = new Q3MapSurfaceModel($a1.value, $a2.value, $a3.value, $a4.value, $a5.value, $a6.value, $a7.value, $a8.value);}
    ;

q3mapTcGenDirective returns [Q3MapTcGen value]
    : Q3MAP_TCGEN WS VECTOR  WS? LROUNDBRACKET WS? a1=numberParam WS a2=numberParam WS a3=numberParam WS? RROUNDBRACKET WS? LROUNDBRACKET WS? a4=numberParam WS a5=numberParam WS a6=numberParam WS? RROUNDBRACKET {$value = new Q3MapTcGenVector($a1.value, $a2.value, $a3.value, $a4.value, $a5.value, $a6.value);}
    | Q3MAP_TCGEN WS IVECTOR  WS? LROUNDBRACKET WS? b1=numberParam WS b2=numberParam WS b3=numberParam WS? RROUNDBRACKET WS? LROUNDBRACKET WS? b4=numberParam WS b5=numberParam WS b6=numberParam WS? RROUNDBRACKET {$value = new Q3MapTcGenIVector($b1.value, $b2.value, $b3.value, $b4.value, $b5.value, $b6.value);}
    ;

q3mapTcModDirective returns [Q3MapTcMod value]
    : Q3MAP_TCMOD WS ROTATE WS a=numberParam {$value = new Q3MapTcModRotate($a.value);}
    | Q3MAP_TCMOD WS SCALE WS b1=numberParam WS b2=numberParam {$value = new Q3MapTcModScale($b1.value, $b2.value);}
    | Q3MAP_TCMOD WS TRANSLATE WS c1=numberParam WS c2=numberParam {$value = new Q3MapTcModTranslate($c1.value, $c2.value);}
    | Q3MAP_TCMOD WS MOVE WS d1=numberParam WS d2=numberParam {$value = new Q3MapTcModMove($d1.value, $d2.value);}
    | Q3MAP_TCMOD WS SHIFT WS e1=numberParam WS e2=numberParam {$value = new Q3MapTcModShift($e1.value, $e2.value);}
    ;

q3mapTerrainDirective returns [Q3MapTerrain value]
    : Q3MAP_TERRAIN {$value = new Q3MapTerrain();}
    ;

q3mapTessSizeDirective returns [Q3MapTessSize value]
    : Q3MAP_TESSSIZE WS a=numberParam {$value = new Q3MapTessSize($a.value);}
    ;

q3mapTextureSizeDirective returns [Q3MapTextureSize value]
    : Q3MAP_TEXTURESIZE WS a1=numberParam WS a2=numberParam {$value = new Q3MapTextureSize($a1.value, $a2.value);}
    ;

q3mapTraceLightDirective returns [Q3MapTraceLight value]
    : Q3MAP_TRACELIGHT {$value = new Q3MapTraceLight();}
    ;

q3mapVertexScaleDirective returns [Q3MapVertexScale value]
    : Q3MAP_VERTEXSCALE WS a=numberParam {$value = new Q3MapVertexScale($a.value);}
    ;

q3mapVertexShadowsDirective returns [Q3MapVertexShadows value]
    : Q3MAP_VERTEXSHADOWS {$value = new Q3MapVertexShadows();}
    ;

q3mapVLightDirective returns [Q3MapVLight value]
    : Q3MAP_VLIGHT {$value = new Q3MapVLight();}
    ;

q3mapNoFancyWaterDirective returns [Q3MapNoFancyWater value]
    : Q3MAP_NOFANCYWATER {$value = new Q3MapNoFancyWater();}
    ;
q3mapCheapWaterDirective returns [Q3MapCheapWater value]
    : Q3MAP_CHEAPWATER WS a1=numberParam WS a2=numberParam WS a3=numberParam WS a4=numberParam  {$value = new Q3MapCheapWater($a1.value, $a2.value, $a3.value, $a4.value);}
    ;

//EDITOR DIRECTIVES DEFINITONS

editorDirective returns [QerDirective value]
    : a1=qerEditorImageDirective {$value = $a1.value;}
    | a2=qerNoCarveDirective {$value = $a2.value;}
    | a3=qerTransDirective {$value = $a3.value;}
    | a4=qerAlphaFuncDirective {$value = $a4.value;}
    ;

qerEditorImageDirective returns [QerEditorImage value]
    : QER_EDITORIMAGE WS a=pathParam {$value = new QerEditorImage($a.value);}
    ;

qerNoCarveDirective returns [QerNoCarve value]
    : QER_NOCARVE {$value = new QerNoCarve();}
    ;

qerTransDirective returns [QerTrans value]
    : QER_TRANS WS a=numberParam {$value = new QerTrans($a.value);}
    ;

qerAlphaFuncDirective returns [QerAlphaFunc value]
    : QER_ALPHAFUNC WS a1=qer_alphaFuncType WS a2=numberParam {$value = new QerAlphaFunc($a1.value, $a2.value);}
    ;

//STAGE DIRECTIVES DEFINITONS

stageDirective returns [StageDirective value]
    : a1=mapDirective {$value = $a1.value;}
    | a2=clampMapDirective {$value = $a2.value;}
    | a3=animMapDirective {$value = $a3.value;}
    | a4=videoMapDirective {$value = $a4.value;}
    | a5=blendFuncDirective {$value = $a5.value;}
    | a6=rGBGenDirective {$value = $a6.value;}
    | a7=alphaGenDirective {$value = $a7.value;}
    | a8=tcGenDirective {$value = $a8.value;}
    | a9=tcModDirective {$value = $a9.value;}
    | a10=depthFuncDirective {$value = $a10.value;}
    | a11=depthWriteDirective {$value = $a11.value;}
    | a12=detailDirective {$value = $a12.value;}
    | a13=alphaFuncDirective {$value = $a13.value;}
    ;

mapDirective returns [Map value]
    : MAP WS a=pathParam {$value = new MapTexture($a.value);}
    | MAP WS DOLLARLIGHTMAP {$value = new MapLightmap();}
    | MAP WS DOLLARWHITEIMAGE {$value = new MapWhiteImage();}
    ;

clampMapDirective returns [ClampMap value]
    : CLAMPMAP WS a=pathParam {$value = new ClampMap($a.value);}
    ;

animMapDirective returns [AnimMap value]
    : {List<string> textures = new List<string>();}
        ANIMMAP WS a=numberParam ((WS|NL) b=pathParam {textures.Add($b.value);})+ {$value = new AnimMap($a.value, textures);}
    ;

videoMapDirective returns [VideoMap value]
    : VIDEOMAP WS a=pathParam {$value = new VideoMap($a.value);}
    ;

blendFuncDirective returns [BlendFunc value]
    : BLENDFUNC WS a=blendFuncSimplifiedType {$value = new BlendFuncSimplified($a.value);}
    | BLENDFUNC WS b1=blendFuncExplicitSrcType WS b2=blendFuncExplicitDestType {$value = new BlendFuncExplicit($b1.value, $b2.value);}
    ;

rGBGenDirective returns [RGBGen value]
    : RGBGEN WS IDENTITY  {$value = new RGBGenIdentity();}
    | RGBGEN WS IDENTITYLIGHTING   {$value = new RGBGenIdentityLighting();}
    | RGBGEN WS VERTEX   {$value = new RGBGenVertex();}
    | RGBGEN WS ONEMINUSVERTEX   {$value = new RGBGenOneMinusVertex();}
    | RGBGEN WS EXACTVERTEX   {$value = new RGBGenExactVertex();}
    | RGBGEN WS FROMVERTEX   {$value = new RGBGenFromVertex();}
    | RGBGEN WS ENTITY   {$value = new RGBGenEntity();}
    | RGBGEN WS ONEMINUSENTITY   {$value = new RGBGenOneMinusEntity();}
    | RGBGEN WS LIGHTINGDIFFUSE   {$value = new RGBGenLightingDiffuse();}
    | RGBGEN WS NOISE  {$value = new RGBGenNoise();}
    | RGBGEN WS WAVE WS a1=waveFormFunctionType WS a2=numberParam WS a3=numberParam WS a4=numberParam WS a5=numberParam  {$value = new RGBGenWave($a1.value, $a2.value, $a3.value, $a4.value, $a5.value);}
    | RGBGEN WS CONST WS? LROUNDBRACKET WS? b1=numberParam WS b2=numberParam WS b3=numberParam WS? RROUNDBRACKET  {$value = new RGBGenConst($b1.value, $b2.value, $b3.value);}
    ;

alphaGenDirective returns [AlphaGen value]
    : ALPHAGEN WS LIGHTINGSPECULAR   {$value = new AlphaGenLightingSpecular();}
    | ALPHAGEN WS ENTITY    {$value = new AlphaGenEntity();}
    | ALPHAGEN WS ONEMINUSENTITY    {$value = new AlphaGenOneMinusEntity();}
    | ALPHAGEN WS VERTEX    {$value = new AlphaGenVertex();}
    | ALPHAGEN WS ONEMINUSVERTEX    {$value = new AlphaGenOneMinusVertex();}
    | ALPHAGEN WS PORTAL WS a=numberParam  {$value = new AlphaGenPortal($a.value);}
    | ALPHAGEN WS CONST WS b=numberParam   {$value = new AlphaGenConst($b.value);}
    | ALPHAGEN WS WAVE WS c1=waveFormFunctionType WS c2=numberParam WS c3=numberParam WS c4=numberParam WS c5=numberParam  {$value = new AlphaGenWave($c1.value, $c2.value, $c3.value, $c4.value, $c5.value);}
    ;

tcGenDirective returns [TcGen value]
    : TCGEN WS BASE {$value = new TcGenBase();}
    | TCGEN WS LIGHTMAP  {$value = new TcGenLightmap();}
    | TCGEN WS ENVIRONMENT {$value = new TcGenEnvironment();}
    | TCGEN WS VECTOR WS? LROUNDBRACKET WS? a1=numberParam WS a2=numberParam WS a3=numberParam WS? RROUNDBRACKET WS? LROUNDBRACKET WS? a4=numberParam WS a5=numberParam WS a6=numberParam WS? RROUNDBRACKET {$value = new TcGenVector($a1.value, $a2.value, $a3.value, $a4.value, $a5.value, $a6.value);}
    ;

tcModDirective returns [TcMod value]
    : TCMOD WS ROTATE WS a=numberParam {$value = new TcModRotate($a.value);}
    | TCMOD WS SCALE WS b1=numberParam WS b2=numberParam {$value = new TcModScale($b1.value, $b2.value);}
    | TCMOD WS SCROLL WS c1=numberParam WS c2=numberParam {$value = new TcModScroll($c1.value, $c2.value);}
    | TCMOD WS STRETCH  WS d1=waveFormFunctionType WS d2=numberParam WS d3=numberParam WS d4=numberParam WS d5=numberParam {$value = new TcModStretch($d1.value, $d2.value, $d3.value, $d4.value, $d5.value);}
    | TCMOD WS TRANSFORM WS e1=numberParam WS e2=numberParam WS e3=numberParam WS e4=numberParam WS e5=numberParam WS e6=numberParam {$value = new TcModTransform($e1.value, $e2.value, $e3.value, $e4.value, $e5.value, $e6.value);}
    | TCMOD WS TURB WS f1=numberParam WS f2=numberParam WS f3=numberParam WS f4=numberParam {$value = new TcModTurb($f1.value, $f2.value, $f3.value, $f4.value);}
    ;

depthFuncDirective returns [DepthFunc value]
    : DEPTHFUNC WS a=depthFuncType {$value = new DepthFunc($a.value);}
    ;

depthWriteDirective returns [DepthWrite value]
    : DEPTHWRITE {$value = new DepthWrite();}
    ;

detailDirective returns [Detail value]
    : DETAIL {$value = new Detail();}
    ;

alphaFuncDirective returns [AlphaFunc value]
    : ALPHAFUNC WS a=alphaFuncType {$value = new AlphaFunc($a.value);}
    ;

// PARAMETERS

boolParam                               returns [bool value]
    : a=INT                            {$value = $a.text.Equals("1");}
    | SQUOTE b=INT SQUOTE              {$value = $b.text.Equals("1");}
    | DQUOTE c=INT DQUOTE              {$value = $c.text.Equals("1");}
    ;

intParam                                returns [int value]
    : a=INT                             {$value = int.Parse($a.text);}
    | SQUOTE b=INT SQUOTE               {$value = int.Parse($b.text);}
    | DQUOTE c=INT DQUOTE               {$value = int.Parse($c.text);}
    ;

numberParam                              returns [float value]
    : a=(INT|FLOAT|EXP)                           {$value = float.Parse($a.text, CultureInfo.GetCultureInfo("en-US"));}
    | SQUOTE b=(INT|FLOAT|EXP) SQUOTE             {$value = float.Parse($b.text, CultureInfo.GetCultureInfo("en-US"));}
    | DQUOTE c=(INT|FLOAT|EXP) DQUOTE             {$value = float.Parse($c.text, CultureInfo.GetCultureInfo("en-US"));}
    ;

pathParam                               returns [string value]
    : a=PATH                            {$value = $a.text;}
    | SQUOTE b=PATH SQUOTE              {$value = $b.text;}
    | DQUOTE c=PATH DQUOTE              {$value = $c.text;}
    ;

cullType                                returns [CullType value]
    : FRONT                             {$value = CullType.Front;}
    | BACK                              {$value = CullType.Back;}
    | DISABLE                           {$value = CullType.Disable;}
    | NONE                              {$value = CullType.None;}
    ;

waveFormFunctionType                    returns [WaveFormFunctionType value]
    : SIN                               {$value = WaveFormFunctionType.Sin;}
    | TRIANGLE                          {$value = WaveFormFunctionType.Triangle;}
    | SQUARE                            {$value = WaveFormFunctionType.Square;}
    | SAWTOOTH                          {$value = WaveFormFunctionType.SawTooth;}
    | INVERSESAWTOOTH                    {$value = WaveFormFunctionType.InverseSawTooth;}
    | NOISE                             {$value = WaveFormFunctionType.Noise;}
    ;

sortType                                returns [SortType value]
    : PORTAL                            {$value = SortType.Portal;}
    | SKY                               {$value = SortType.Sky;}
    | OPAQUE                            {$value = SortType.Opaque;}
    | BANNER                            {$value = SortType.Banner;}
    | UNDERWATER                        {$value = SortType.UnderWater;}
    | ADDITIVE                          {$value = SortType.Additive;}
    | NEAREST                           {$value = SortType.Nearest;}
    ;

surfaceParmType                         returns [SurfaceParmType value]
    : ALPHASHADOW                       {$value = SurfaceParmType.AlphaShadow;}
    | ANTIPORTAL                        {$value = SurfaceParmType.AntiPortal;}
    | AREAPORTAL                        {$value = SurfaceParmType.AreaPortal;}
    | BOTCLIP                           {$value = SurfaceParmType.BotClip;}
    | CLUSTERPORTAL                     {$value = SurfaceParmType.ClusterPortal;}
    | DETAIL                            {$value = SurfaceParmType.Detail;}
    | DONOTENTER                        {$value = SurfaceParmType.DoNotEnter;}
    | DUST                              {$value = SurfaceParmType.Dust;}
    | FLESH                             {$value = SurfaceParmType.Flesh;}
    | FOG                               {$value = SurfaceParmType.Fog;}
    | HINT                              {$value = SurfaceParmType.Hint;}
    | LADDER                            {$value = SurfaceParmType.Ladder;}
    | LAVA                              {$value = SurfaceParmType.Lava;}
    | LIGHTFILTER                       {$value = SurfaceParmType.LightFilter;}
    | LIGHTGRID                         {$value = SurfaceParmType.LightGrid;}
    | METALSTEPS                        {$value = SurfaceParmType.MetalSteps;}
    | MONSTERCLIP                       {$value = SurfaceParmType.MonsterClip;}
    | NODAMAGE                          {$value = SurfaceParmType.NoDamage;}
    | NODLIGHT                          {$value = SurfaceParmType.NoDLight;}
    | NODRAW                            {$value = SurfaceParmType.NoDraw;}
    | NODROP                            {$value = SurfaceParmType.NoDrop;}
    | NOIMPACT                          {$value = SurfaceParmType.NoImpact;}
    | NOMARKS                           {$value = SurfaceParmType.NoMarks;}
    | NOSTEPS                           {$value = SurfaceParmType.NoSteps;}
    | NONSOLID                          {$value = SurfaceParmType.NonSolid;}
    | ORIGIN                            {$value = SurfaceParmType.Origin;}
    | PLAYERCLIP                        {$value = SurfaceParmType.PlayerClip;}
    | POINTLIGHT                        {$value = SurfaceParmType.PointLight;}
    | SKY                               {$value = SurfaceParmType.Sky;}
    | SLICK                             {$value = SurfaceParmType.Slick;}
    | SLIME                             {$value = SurfaceParmType.Slime;}
    | STRIP                             {$value = SurfaceParmType.Strip;}
    | STRUCTURAL                        {$value = SurfaceParmType.Structural;}
    | TRANS                             {$value = SurfaceParmType.Trans;}
    | WATER                             {$value = SurfaceParmType.Water;}

      //Surfaceparm extended by custinfoparms

    | TIN                               {$value = SurfaceParmType.Tin;}
    | ALUMINIUM                         {$value = SurfaceParmType.Aluminium;}
    | IRON                              {$value = SurfaceParmType.Iron;}
    | TITANIUM                          {$value = SurfaceParmType.Titanium;}
    | STEEL                             {$value = SurfaceParmType.Steel;}
    | COPPER                            {$value = SurfaceParmType.Copper;}
    | BRASS                             {$value = SurfaceParmType.Brass;}
    | CEMENT                            {$value = SurfaceParmType.Cement;}
    | ROCK                              {$value = SurfaceParmType.Rock;}
    | GRAVEL                            {$value = SurfaceParmType.Gravel;}
    | PAVEMENT                          {$value = SurfaceParmType.Pavement;}
    | BRICK                             {$value = SurfaceParmType.Brick;}
    | CLAY                              {$value = SurfaceParmType.Clay;}
    | GRASS                             {$value = SurfaceParmType.Grass;}
    | DIRT                              {$value = SurfaceParmType.Dirt;}
    | MUD                               {$value = SurfaceParmType.Mud;}
    | SNOW                              {$value = SurfaceParmType.Snow;}
    | ICE                               {$value = SurfaceParmType.Ice;}
    | SAND                              {$value = SurfaceParmType.Sand;}
    | CERAMICTILE                       {$value = SurfaceParmType.CeramicTile;}
    | LINOLEUM                          {$value = SurfaceParmType.Linoleum;}
    | RUG                               {$value = SurfaceParmType.Rug;}
    | PLASTER                           {$value = SurfaceParmType.Plaster;}
    | PLASTIC                           {$value = SurfaceParmType.Plastic;}
    | CARDBOARD                         {$value = SurfaceParmType.CardBoard;}
    | HARDWOOD                          {$value = SurfaceParmType.HardWood;}
    | SOFTWOOD                          {$value = SurfaceParmType.SoftWood;}
    | PLANK                             {$value = SurfaceParmType.Plank;}
    | GLASS                             {$value = SurfaceParmType.Glass;}
    | STUCCO                            {$value = SurfaceParmType.Stucco;}

      //Other custom Surfaceparms

    | SSKIP                              {$value = SurfaceParmType.Skip;}
    | NOLIGHTMAP                        {$value = SurfaceParmType.NoLightmap;}
    | NONOPAQUE                         {$value = SurfaceParmType.NonOpaque;}
    ;

qer_alphaFuncType                       returns [QerAlphaFuncType value]
    : GREATER                           {$value = QerAlphaFuncType.Greater;}
    | LESS                              {$value = QerAlphaFuncType.Less;}
    | GEQUAL                            {$value = QerAlphaFuncType.GEqual;}
    ;

q3map_lightmapAxisType                  returns [Q3MapLightmapAxisType value]
    : X                                 {$value = Q3MapLightmapAxisType.X;}
    | Y                                 {$value = Q3MapLightmapAxisType.Y;}
    | Z                                 {$value = Q3MapLightmapAxisType.Z;}
    ;

blendFuncSimplifiedType                 returns [BlendFuncSimplifiedType value]
    : ADD                               {$value = BlendFuncSimplifiedType.Add;}
    | BLEND                             {$value = BlendFuncSimplifiedType.Blend;}
    | FILTER                            {$value = BlendFuncSimplifiedType.Filter;}
    ;

blendFuncExplicitSrcType                returns [BlendFuncExplicitSrcType value]
    : GL_ONE                            {$value = BlendFuncExplicitSrcType.GL_ONE;}
    | GL_ZERO                           {$value = BlendFuncExplicitSrcType.GL_ZERO;}
    | GL_DST_COLOR                      {$value = BlendFuncExplicitSrcType.GL_DST_COLOR;}
    | GL_ONE_MINUS_DST_COLOR            {$value = BlendFuncExplicitSrcType.GL_ONE_MINUS_DST_COLOR;}
    | GL_SRC_ALPHA                      {$value = BlendFuncExplicitSrcType.GL_SRC_ALPHA;}
    | GL_ONE_MINUS_SRC_ALPHA            {$value = BlendFuncExplicitSrcType.GL_ONE_MINUS_SRC_ALPHA;}
    ;

blendFuncExplicitDestType               returns [BlendFuncExplicitDestType value]
    : GL_ONE                            {$value = BlendFuncExplicitDestType.GL_ONE;}
    | GL_ZERO                           {$value = BlendFuncExplicitDestType.GL_ZERO;}
    | GL_SRC_COLOR                      {$value = BlendFuncExplicitDestType.GL_SRC_COLOR;}
    | GL_ONE_MINUS_SRC_COLOR            {$value = BlendFuncExplicitDestType.GL_ONE_MINUS_SRC_COLOR;}
    | GL_SRC_ALPHA                      {$value = BlendFuncExplicitDestType.GL_SRC_ALPHA;}
    | GL_ONE_MINUS_SRC_ALPHA            {$value = BlendFuncExplicitDestType.GL_ONE_MINUS_SRC_ALPHA;}
    | GL_ONE_MINUS_DST_ALPHA            {$value = BlendFuncExplicitDestType.GL_ONE_MINUS_DST_ALPHA;}
    ;

depthFuncType                           returns [DepthFuncType value]
    : LEQUAL                            {$value = DepthFuncType.LEqual;}
    | EQUAL                             {$value = DepthFuncType.Equal;}
    ;

alphaFuncType                           returns [AlphaFuncType value]
    : GT0                               {$value = AlphaFuncType.GT0;}
    | LT128                             {$value = AlphaFuncType.LT128;}
    | GE128                             {$value = AlphaFuncType.GE128;}
    ;
/*
##############################################################################################################################################
#######################################################################    LEXER RULES      ##################################################
##############################################################################################################################################
*/

ADD: A D D;
ADDITIVE: A D D I T I V E;
ALPHAFUNC: A L P H A F U N C;
ALPHAGEN: A L P H A G E N;
ALPHASHADOW: A L P H A S H A D O W;
ALUMINIUM: A L U M I N I U M;
ANIMMAP: A N I M M A P;
ANTIPORTAL: A N T I P O R T A L;
AREAPORTAL: A R E A P O R T A L;
AUTOSPRITE: A U T O S P R I T E;
AUTOSPRITE2: A U T O S P R I T E '2';
BACK: B A C K;
BANNER: B A N N E R;
BASE: B A S E;
BLEND: B L E N D;
BLENDFUNC: B L E N D F U N C;
BOTCLIP: B O T C L I P;
BRASS: B R A S S;
BRICK: B R I C K;
BULGE: B U L G E;
CARDBOARD: C A R D B O A R D;
CEMENT: C E M E N T;
CERAMICTILE: C E R A M I C T I L E;
CLAMPMAP: C L A M P M A P;
CLAY: C L A Y;
CONST: C O N S T;
COPPER: C O P P E R;
CLUSTERPORTAL: C L U S T E R P O R T A L;
CULL: C U L L;
DEFORMVERTEXES: D E F O R M V E R T E X E S;
DEPTHFUNC: D E P T H F U N C;
DEPTHWRITE: D E P T H W R I T E;
DETAIL: D E T A I L;
DOLLARLIGHTMAP: '$' L I G H T M A P;
DOLLARWHITEIMAGE: '$' W H I T E I M A G E;
DIRT: D I R T;
DONOTENTER: D O N O T E N T E R;
DOTPRODUCT: D O T P R O D U C T;
DOTPRODUCT2: D O T P R O D U C T '2';
DUST: D U S T;
DISABLE: D I S A B L E;
ENTITY: E N T I T Y;
ENTITYMERGABLE: E N T I T Y M E R G A B L E;
ENVIRONMENT: E N V I R O N M E N T;
EQUAL: E Q U A L;
EXACTVERTEX: E X A C T V E R T E X;
FILTER: F I L T E R;
FLESH: F L E S H;
FOG: F O G;
FOGPARMS: F O G P A R M S;
FROMVERTEX: F R O M V E R T E X;
FRONT: F R O N T;
GE128: G E '128';
GEQUAL: G E Q U A L;
GL_DST_COLOR: G L '_' D S T '_' C O L O R;
GL_ONE: G L '_' O N E;
GL_ONE_MINUS_DST_ALPHA: G L '_' O N E '_' M I N U S '_' D S T '_' A L P H A;
GL_ONE_MINUS_DST_COLOR: G L '_' O N E '_' M I N U S '_' D S T '_' C O L O R;
GL_ONE_MINUS_SRC_ALPHA: G L '_' O N E '_' M I N U S '_' S R C '_' A L P H A;
GL_ONE_MINUS_SRC_COLOR: G L '_' O N E '_' M I N U S '_' S R C '_' C O L O R;
GL_SRC_ALPHA: G L '_' S R C '_' A L P H A;
GL_SRC_COLOR: G L '_' S R C '_' C O L O R;
GL_ZERO: G L '_' Z E R O;
GLASS: G L A S S;
GRAVEL: G R A V E L;
GRASS: G R A S S;
GREATER: G R E A T E R;
GT0: G T '0';
HARDWOOD: H A R D W O O D;
HINT: H I N T;
ICE: I C E;
IDENTITY: I D E N T I T Y;
IDENTITYLIGHTING: I D E N T I T Y L I G H T I N G;
INVERSESAWTOOTH: I N V E R S E S A W T O O T H;
IRON: I R O N;
IVECTOR: I V E C T O R;
LADDER: L A D D E R;
LAVA: L A V A;
LEQUAL: L E Q U A L;
LESS: L E S S;
LIGHT: L I G H T;
LIGHTFILTER: L I G H T F I L T E R;
LIGHTGRID: L I G H T G R I D;
LIGHTINGDIFFUSE: L I G H T I N G D I F F U S E;
LIGHTINGSPECULAR: L I G H T I N G S P E C U L A R;
LIGHTMAP: L I G H T M A P;
LINOLEUM: L I N O L E U M;
LT128: L T '128';
MAP: M A P;
METALSTEPS: M E T A L S T E P S;
MONSTERCLIP: M O N S T E R C L I P;
MOVE: M O V E;
MUD: M U D;
NEAREST: N E A R E S T;
NODAMAGE: N O D A M A G E;
NODLIGHT: N O D L I G H T;
NODRAW: N O D R A W;
NODROP: N O D R O P;
NOIMPACT: N O I M P A C T;
NOISE: N O I S E;
NOLIGHTMAP: N O L I G H T M A P;
NOMARKS: N O M A R K S;
NOMIPMAPS: N O M I P M A P S;
NONE: N O N E;
NONOPAQUE: N O N O P A Q U E;
NONSOLID: N O N S O L I D;
NOPICMIP: N O P I C M I P;
NORMAL: N O R M A L;
NOSTEPS: N O S T E P S;
ONEMINUSENTITY: O N E M I N U S E N T I T Y;
ONEMINUSVERTEX: O N E M I N U S V E R T E X;
OPAQUE: O P A Q U E;
ORIGIN: O R I G I N;
PAVEMENT: P A V E M E N T;
PLANK: P L A N K;
PLASTER: P L A S T E R;
PLASTIC: P L A S T I C;
PLAYERCLIP: P L A Y E R C L I P;
POINTLIGHT: P O I N T L I G H T;
POLYGONOFFSET: P O L Y G O N O F F S E T;
PORTAL: P O R T A L;
PROJECTIONSHADOW: P R O J E C T I O N S H A D O W;
Q3MAP_ALPHAGEN: Q '3' M A P '_' A L P H A G E N;
Q3MAP_ALPHAMOD: Q '3' M A P '_' A L P H A M O D;
Q3MAP_BACKSHADER: Q '3' M A P '_' B A C K S H A D E R;
Q3MAP_BACKSPLASH: Q '3' M A P '_' B A C K S P L A S H;
Q3MAP_BASESHADER: Q '3' M A P '_' B A S E S H A D E R;
Q3MAP_BOUNCE: Q '3' M A P '_' B O U N C E;
Q3MAP_BOUNCESCALE: Q '3' M A P '_' B O U N C E S C A L E;
Q3MAP_CHEAPWATER: Q '3' M A P '_' C H E A P W A T E R;
Q3MAP_CLIPMODEL: Q '3' M A P '_' C L I P M O D E L;
Q3MAP_CLONESHADER: Q '3' M A P '_' C L O N E S H A D E R;
Q3MAP_COLORGEN: Q '3' M A P '_' C O L O R G E N;
Q3MAP_COLORMOD: Q '3' M A P '_' C O L O R M O D;
Q3MAP_FANCYWATER: Q '3' M A P '_' F A N C Y W A T E R;
Q3MAP_FOGDIR: Q '3' M A P '_' F O G D I R;
Q3MAP_FORCEMETA: Q '3' M A P '_' F O R C E M E T A;
Q3MAP_FORCESUNLIGHT: Q '3' M A P '_' F O R C E S U N L I G H T;
Q3MAP_FUR: Q '3' M A P '_' F U R;
Q3MAP_GLOBALTEXTURE: Q '3' M A P '_' G L O B A L T E X T U R E;
Q3MAP_INDEXED: Q '3' M A P '_' I N D E X E D;
Q3MAP_INVERT: Q '3' M A P '_' I N V E R T;
Q3MAP_LIGHTIMAGE: Q '3' M A P '_' L I G H T I M A G E;
Q3MAP_LIGHTMAPAXIS: Q '3' M A P '_' L I G H T M A P A X I S;
Q3MAP_LIGHTMAPBRIGHTNESS: Q '3' M A P '_' L I G H T M A P B R I G H T N E S S;
Q3MAP_LIGHTMAPFILTERRADIUS: Q '3' M A P '_' L I G H T M A P F I L T E R R A D I U S;
Q3MAP_LIGHTMAPGAMMA: Q '3' M A P '_' L I G H T M A P G A M M A;
Q3MAP_LIGHTMAPMERGABLE: Q '3' M A P '_' L I G H T M A P M E R G A B L E;
Q3MAP_LIGHTMAPSAMPLEOFFSET: Q '3' M A P '_' L I G H T M A P S A M P L E O F F S E T;
Q3MAP_LIGHTMAPSAMPLESIZE: Q '3' M A P '_' L I G H T M A P S A M P L E S I Z E;
Q3MAP_LIGHTMAPSIZE: Q '3' M A P '_' L I G H T M A P S S I Z E;
Q3MAP_LIGHTRGB: Q '3' M A P '_' L I G H T R G B;
Q3MAP_LIGHTSTYLE: Q '3' M A P '_' L I G H T S T Y L E;
Q3MAP_LIGHTSUBDIVIDE: Q '3' M A P '_' L I G H T S U B D I V I D E;
Q3MAP_NOCLIP: Q '3' M A P '_' N O C L I P;
Q3MAP_NOFAST: Q '3' M A P '_' N O F A S T;
Q3MAP_NOFANCYWATER: Q '3' M A P '_' N O F A N C Y W A T E R;
Q3MAP_NOFOG: Q '3' M A P '_' N O F O G;
Q3MAP_NOLIGHTMAP: Q '3' M A P '_' N O L I G H T M A P;
Q3MAP_NONPLANAR: Q '3' M A P '_' N O N P L A N A R;
Q3MAP_NORMALIMAGE: Q '3' M A P '_' N O R M A L I M A G E;
Q3MAP_NOTJUNC: Q '3' M A P '_' N O T J U N C;
Q3MAP_NOVERTEXLIGHT: Q '3' M A P '_' N O V E R T E X L I G H T;
Q3MAP_NOVERTEXSHADOWS: Q '3' M A P '_' N O V E R T E X S H A D O W S;
Q3MAP_OFFSET: Q '3' M A P '_' O F F S E T;
Q3MAP_PATCHSHADOWS: Q '3' M A P '_' P A T C H S H A D O W S;
Q3MAP_REMAPSHADER: Q '3' M A P '_' R E M A P S H A D E R;
Q3MAP_RGBGEN: Q '3' M A P '_' R G B G E N;
Q3MAP_RGBMOD: Q '3' M A P '_' R G B M O D;
Q3MAP_SHADEANGLE: Q '3' M A P '_' S H A D E A N G L E;
Q3MAP_SKYLIGHT: Q '3' M A P '_' S K Y L I G H T;
Q3MAP_SPLOTCHFIX: Q '3' M A P '_' S P L O T C H F I X;
Q3MAP_STYLEMARKER: Q '3' M A P '_' S T Y L E M A R K E R;
Q3MAP_STYLEMARKER2: Q '3' M A P '_' S T Y L E M A R K E R '2';
Q3MAP_SUN: Q '3' M A P '_' S U N;
Q3MAP_SUNEXT: Q '3' M A P '_' S U N E X T;
Q3MAP_SURFACELIGHT: Q '3' M A P '_' S U R F A C E L I G H T;
Q3MAP_SURFACEMODEL: Q '3' M A P '_' S U R F A C E M O D E L;
Q3MAP_TCGEN: Q '3' M A P '_' T C G E N;
Q3MAP_TCMOD: Q '3' M A P '_' T C M O D;
Q3MAP_TERRAIN: Q '3' M A P '_' T E R R A I N;
Q3MAP_TESSSIZE: Q '3' M A P '_' T E S S S I Z E;
Q3MAP_TEXTURESIZE: Q '3' M A P '_' T E X T U R E S I Z E;
Q3MAP_TRACELIGHT: Q '3' M A P '_' T R A C E L I G H T;
Q3MAP_VERTEXSCALE: Q '3' M A P '_' V E R T E X S C A L E;
Q3MAP_VERTEXSHADOWS: Q '3' M A P '_' V E R T E X S H A D O W S;
Q3MAP_VLIGHT: Q '3' M A P '_' V L I G H T;
QER_ALPHAFUNC: Q E R '_' A L P H A F U N C;
QER_EDITORIMAGE: Q E R '_' E D I T O R I M A G E;
QER_NOCARVE: Q E R '_' N O C A R V E;
QER_TRANS: Q E R '_' T R A N S;
RGBGEN: R G B G E N;
ROCK: R O C K;
ROTATE: R O T A T E;
RUG: R U G;
SAND: S A N D;
SAWTOOTH: S A W T O O T H;
SCALE: S C A L E;
SCROLL: S C R O L L;
SET: S E T;
SHIFT: S H I F T;
SIN: S I N;
SSKIP: S K I P;
SKY: S K Y;
SKYPARMS: S K Y P A R M S;
SLICK: S L I C K;
SLIME: S L I M E;
SNOW: S N O W;
SOFTWOOD: S O F T W O O D;
SORT: S O R T;
SQUARE: S Q U A R E;
STEEL: S T E E L;
STRETCH: S T R E T C H;
STRIP: S T R I P;
STRUCTURAL: S T R U C T U R A L;
STUCCO: S T U C C O;
SURFACEPARM: S U R F A C E P A R M;
TEXT: T E X T;
TCGEN: T C G E N;
TCMOD: T C M O D;
TESSSIZE: T E S S S I Z E;
TIN: T I N;
TITANIUM: T I T A N I U M;
TRANS: T R A N S;
TRANSFORM: T R A N S F O R M;
TRANSLATE: T R A N S L A T E;
TRIANGLE: T R I A N G L E;
TURB: T U R B;
UNDERWATER: U N D E R W A T E R;
VECTOR: V E C T O R;
VERTEX: V E R T E X;
VIDEOMAP: V I D E O M A P;
VOLUME: V O L U M E;
WATER: W A T E R;
WAVE: W A V E;

COMPILETIME: ':' Q '3' M A P;

DEFAULT : '-' ;
EXP: (FLOAT|INT) 'e' INT;
FLOAT:  SIGN? DIGIT* DOT DIGIT+ (E INT)?;
INT:  SIGN? DIGIT+;
BOOL: '0'|'1';
PATH: (WORD ('/'|'\\'))* WORD (DOT WORD)?;

LCURLYBRACKET: '{';
RCURLYBRACKET: '}';

LROUNDBRACKET: '(';
RROUNDBRACKET: ')';

DQUOTE: '"';
SQUOTE: '\'';

WS:  (' ' | '\t')+;
NL: ('\r' '\n' | '\n' | '\r')+;

//  COMMENTAIRES

COMMENT:  '//' ~( '\r' | '\n' )* {Skip();};
MULTILINECOMMENT:  '/*' .*? '*/' {Skip();};

//  FRAGMENTS


fragment WORD: (LETTER | DIGIT | '_' | '-' | '+' | DOT)+;
fragment LETTER : ('a'..'z' | 'A'..'Z') ;
fragment SIGN : '+' | '-';
fragment DIGIT : '0'..'9' ;
fragment DOT: '.';

fragment A:('a'|'A');
fragment B:('b'|'B');
fragment C:('c'|'C');
fragment D:('d'|'D');
fragment E:('e'|'E');
fragment F:('f'|'F');
fragment G:('g'|'G');
fragment H:('h'|'H');
fragment I:('i'|'I');
fragment J:('j'|'J');
fragment K:('k'|'K');
fragment L:('l'|'L');
fragment M:('m'|'M');
fragment N:('n'|'N');
fragment O:('o'|'O');
fragment P:('p'|'P');
fragment Q:('q'|'Q');
fragment R:('r'|'R');
fragment S:('s'|'S');
fragment T:('t'|'T');
fragment U:('u'|'U');
fragment V:('v'|'V');
fragment W:('w'|'W');
fragment X:('x'|'X');
fragment Y:('y'|'Y');
fragment Z:('z'|'Z');