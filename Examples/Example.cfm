<!--

TEST CASE EXPORT FROM REFERENCE IMPLEMENTATION:

Source Code:               TestSourceCode
Source Code Hash (Binary): 8F B3 B3 68 D6 F2 73 0F 03 CE 9A 03 65 84 44 F9 87 35 5A EA 12 FF DE 2B F5 25 0C 89 62 C1 DA 89
Shared Password:           TestPassword123456
Shared Key (Binary):       95 47 95 2A B5 83 59 C7 49 70 D6 3D BB 4C EF 70 5E 7B A9 0A 5C 79 9C F5 78 99 DA C1 BD B1 38 37
Event Code:                XYZ123
Event Code Hash (Binary):  16 25 76 E7 8F 6D 26 69 A9 41 BD 67 0D 03 43 9D B9 38 22 C1 3D 68 58 EB 09 B1 81 A9 7C 8B F3 EB
Badge ID:                  1001
Badge ID Hash (Binary):    FE 67 5F E7 AA EE 83 0B 6F ED 09 B6 4E 03 4F 84 DC BD AE B4 29 D9 CC CD 4E BB 90 E1 5A F8 DD 71
Token Gen Date/Time:       2017-08-01T12:27:31.0030699-04:00 Eastern Daylight Time (UTC-4)
Token Gen Timestamp:       1501604851003
Token Gen Hash (Binary):   09 26 A6 EC 2C 99 C1 B7 45 69 11 D6 4D 8A 93 04 B7 B9 05 FA 27 BE E3 19 C9 CE 2B CF AC 8F 8D C2
Full HMAC Input (Binary):  8F B3 B3 68 D6 F2 73 0F 03 CE 9A 03 65 84 44 F9 87 35 5A EA 12 FF DE 2B F5 25 0C 89 62 C1 DA 89 16 25 76 E7 8F 6D 26 69 A9 41 BD 67 0D 03 43 9D B9 38 22 C1 3D 68 58 EB 09 B1 81 A9 7C 8B F3 EB FE 67 5F E7 AA EE 83 0B 6F ED 09 B6 4E 03 4F 84 DC BD AE B4 29 D9 CC CD 4E BB 90 E1 5A F8 DD 71 09 26 A6 EC 2C 99 C1 B7 45 69 11 D6 4D 8A 93 04 B7 B9 05 FA 27 BE E3 19 C9 CE 2B CF AC 8F 8D C2
HMAC Value (Binary):       C7 DC C0 61 3B 6E 4B 73 CB 94 CE B0 9D BE 68 F6 3E 9F F6 52 CD EB 36 83 7F 9C 4D D7 61 3A 0B 9C
Truncated HMAC (Binary):   C7 DC C0 61 3B 6E 4B 73 CB 94 CE B0 9D BE 68 F6
Truncated HMAC (Base64):   x9zAYTtuS3PLlM6wnb5o9g__
Complete Query:            SourceCode=TestSourceCode&EventCode=XYZ123&BadgeID=1001&Stamp=1501604851003&Auth=x9zAYTtuS3PLlM6wnb5o9g__

TESTED USING https://www.trycf.com/

-->

<cfset variables.sourceCode = 'TestSourceCode' />
<cfset variables.sourceCodeHash = hash(variables.sourceCode, 'SHA-256') />

<cfset variables.eventCode = 'XYZ123' />
<cfset variables.eventCodeHash = hash(variables.eventCode, 'SHA-256') />

<cfset variables.badgeID = '1001' />
<cfset variables.badgeIDHash = hash(variables.badgeID, 'SHA-256') />

<!--- <cfset variables.token = getTickCount() /> --->
<cfset variables.token = '1501604851003' />
<cfset variables.tokenHash = hash(variables.token, 'SHA-256') />

<cfset variables.sharedPassword = 'TestPassword123456' />
<cfset variables.sharedPasswordHash = hash(variables.sharedPassword, 'SHA-256') />

<cfset variables.fullString = '#variables.sourceCodeHash##variables.eventCodeHash##variables.badgeIDHash##variables.tokenHash#' />
<!-- N.B. CFM silently hex-encodes hashes, which needs to be reversed before using -->
<cfset variables.hmac = hmac(BinaryDecode(variables.fullString, 'Hex'), BinaryDecode(variables.sharedPasswordHash, 'Hex'), 'HMACSHA256') />

<cfset variables.trunchmac = Left(variables.hmac, 32) />

<!-- N.B. CFM silently hex-encodes hashes, which needs to be reversed before using -->
<cfset variables.hmacb64 = Replace(Replace(Replace(BinaryEncode(BinaryDecode(variables.trunchmac, 'Hex'), 'Base64'), '+', '.', 'All'), '/', '-', 'All'), '=', '_', 'All')/>

<cfset variables.completeQuery = 'SourceCode=#variables.sourceCode#&EventCode=#variables.eventCode#&BadgeID=#variables.badgeID#&Stamp=#variables.token#&Auth=#variables.hmacb64#' />

<cfdump var="#variables#" abort />