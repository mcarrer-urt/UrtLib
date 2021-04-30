grammar Map;

/*
##############################################################################################################################################
#######################################################################    PARSER RULES      ##################################################
##############################################################################################################################################
*/
 
@header
{
	#pragma warning disable 3021
    using System.Globalization;
    using MapLib;
    using MapLib.Elements;
    using MapLib.Geometry;
}


map returns [Map value]
    :	{ $value = new Map(); }
		(
			NL*
			a=entity NL { $value.Entities.Add($a.value); }
		)*
    ;

entity returns [Entity value]
	:	{$value = new Entity() { Keys = new List<EntityKey>(), Elements = new List<EntityElement>()};}
		LCURLYBRACKET NL
		(
			a=entityKey NL { $value.Keys.Add($a.value); }
		)*
		(
			b=entityElement NL{ $value.Elements.Add($b.value); }
		)*
		RCURLYBRACKET
	;
	
entityKey returns [EntityKey value]
	:
		WS* a1=keyValueParam WS a2=keyValueParam
		{ $value = new EntityKey() { Name=$a1.value.Replace("\"", string.Empty), Value=$a2.value.Replace("\"", string.Empty) }; }
	;
	
entityElement returns [EntityElement value]
	:
		a1=brushElement {$value = $a1.value;}
	|	a2=patchElement {$value = $a2.value;}
	;

brushElement returns [Brush value]
	:
		{$value = new Brush() { Faces = new List<Face>()};}
		WS* LCURLYBRACKET NL
		(
			WS* b=brushFace NL { $value.Faces.Add($b.value); }
		)*
		WS* RCURLYBRACKET
	;

brushFace returns [Face value]
	:	
		LROUNDBRACKET WS a1=numberParam WS a2=numberParam WS a3=numberParam WS RROUNDBRACKET WS
		LROUNDBRACKET WS b1=numberParam WS b2=numberParam WS b3=numberParam WS RROUNDBRACKET WS
		LROUNDBRACKET WS c1=numberParam WS c2=numberParam WS c3=numberParam WS RROUNDBRACKET WS
		d=pathParam WS e1=numberParam WS  e2=numberParam WS  e3=numberParam WS  e4=numberParam WS  e5=numberParam WS  e6=intParam WS  e7=intParam WS  e8=numberParam
		{ 
			$value = new Face(new Point3D($a1.value, $a2.value, $a3.value), new Point3D($b1.value, $b2.value, $b3.value), new Point3D($c1.value, $c2.value, $c3.value));

			$value.Texture = $d.value;
			$value.XOffset = $e1.value;
			$value.YOffset = $e2.value;
			$value.Rotation = $e3.value;
			$value.XScale = $e4.value;
			$value.YScale = $e5.value;
			$value.ContentFlags = $e6.value;
			$value.SurfaceFlags = $e7.value;
			$value.Unknown = $e8.value;
		}
	;

patchElement returns [Patch value]
	:
		{ $value = new Patch();}
		WS* LCURLYBRACKET NL
		WS* PATCHDEF2 NL
		WS* LCURLYBRACKET NL
		WS* a=pathParam NL { $value.Texture =  $a.value; }
		WS* LROUNDBRACKET WS b1 = intParam WS b2=intParam WS b3=numberParam WS b4=numberParam WS b5=numberParam WS RROUNDBRACKET NL
		{ 
			$value.Vertices = new PatchVertex[$b1.value, $b2.value];
			var list = new List<List<PatchVertex>>();
		}
		WS* LROUNDBRACKET NL
		(
			{
				var line = new List<PatchVertex>();
			}
			WS* LROUNDBRACKET
			( 
				WS c=patchVertex (WS NL?)?
				{ 
					line.Add($c.value);
				} 
			)+
			WS* RROUNDBRACKET NL 
			{ 
				list.Add(line);
			}
		)*
		{
			for(int i = 0; i < list.Count; i++)
				for(int j = 0; j < list[i].Count; j++)
					$value.Vertices[i, j] = list[i][j];
		}
		WS* RROUNDBRACKET NL
		WS* RCURLYBRACKET NL
		WS* RCURLYBRACKET
	;

patchVertex returns [PatchVertex value]
	:
		WS* LROUNDBRACKET WS a1=numberParam WS a2=numberParam WS a3=numberParam WS a4=numberParam WS a5=numberParam WS RROUNDBRACKET
		{
			$value = new PatchVertex()
			{
				X = $a1.value,
				Y = $a2.value,
				Z = $a3.value,
				TextureCoordX = $a4.value,
				TextureCoordY = $a5.value
			};
		}
	;

keyValueParam                               returns [string value]
    : a=KEYVALUE							{$value = $a.text;}
    ;
	
pathParam                               returns [string value]
    : a=(WORD|PATH)							{$value = $a.text;}
    ;

intParam                                returns [int value]
    : a=INT                             {$value = int.Parse($a.text);}
	;

numberParam                              returns [double value]
    : a=(INT|DECIMAL|EXP)                      {$value = double.Parse($a.text, CultureInfo.GetCultureInfo("en-US"));}
    ;

/*
##############################################################################################################################################
#######################################################################    LEXER RULES      ##################################################
##############################################################################################################################################
*/

PATCHDEF2: 'patchDef2';

QUOTE: '"';

LROUNDBRACKET: '(';
RROUNDBRACKET: ')';

LCURLYBRACKET: '{';
RCURLYBRACKET: '}';

KEYVALUE: '"' ~('"')* '"';
PATH: (WORD '/')+ WORD (DOT WORD)?;
EXP: DECIMAL 'E' INT;
DECIMAL:  SIGN? DIGIT* DOT DIGIT+;
INT: SIGN? DIGIT+;

WS: (' ' | '\t')+;
NL: ('\r' | '\n')+;

WORD: (LETTER | DIGIT | '_' | '-' | '+' | DOT)+;

fragment LETTER : ('a'..'z' | 'A'..'Z') ;
fragment SIGN : '+' | '-';
fragment DIGIT : '0'..'9' ;
fragment DOT: '.';

//  skip

COMMENT: NL? WS* '//' ~('\n' | '\r')*  {Skip();};