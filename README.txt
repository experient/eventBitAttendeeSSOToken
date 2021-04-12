+----------------------------------------------------------------------+
|    Maritz Global Events eventBit Attendee Single-Sign-On Protocol    |
+----------------------------------------------------------------------+

------------------------------------------------------------------------
OVERVIEW

This application demonstrates the protocol used to sign attendees who
have been authenticated by an external system into eventBit.

------------------------------------------------------------------------
V1 PROTOCOL

In order to use this protocol, you must first receive from Maritz Global 
Events, for each environment:

	1. A Shared Password.
	2. An API URL.
	3. A "Source Code" string.

Each of these will be specific to your company and should not be shared.
In particular, you should take whatever precautions possible to control
access to the Shared Password, e.g. only store or use it on machines you
control, except when unavoidable (e.g. for offline mobile device apps).

You will also need to receive from Maritz Global Events, once per event:
	3. The Event Code that identifies the event.

You will also need to gather, at runtime:
	4. The Badge ID of the person you want to sign in as; this person
	   should already be otherwise authenticated by your app.
	5. The current date/time.

Follow the instructions on the v1 Protocol tab in this application to
see how to assemble the parameters for the final URL.  Highlighting a
textbox will display help text below explaining how its value was
derived, and the code in the v1ProtocolControl provides a working C#.NET
example.  You can also use this application to produce test vectors,
and compare them with Maritz Global Events or other implementations.

------------------------------------------------------------------------
LICENSE

Copyright (c)2016 Maritz Global Events.

Permission is hereby granted, free of charge, to any person obtaining a
copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be included
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

------------------------------------------------------------------------