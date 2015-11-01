ECHO Processing Post Build Events for Attribute.PowerShell.Common.dll...

XCOPY %~1.\Attribute.PowerShell.Common.dll-Help.xml %~2 /Y /Q
XCOPY %~1.\Attribute.PowerShell.Common.psd1 %~2 /Y /Q

ECHO Post Build Event Processing Complete