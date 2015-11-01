# Attribute Common PowerShell Lib
# Copyright (C) 2015 Attribute Studios LLC. All Rights Reserved.

function Wait {
	Lock-Execution -i;
}

New-Alias -Name "cdr" -Value "Set-LocationWithReport" -Description "Sets the location to a specified path and reports the results.";
New-Alias -Name "pause" -Value "Lock-Execution" -Description "Pauses the script's execution for a specific amount of time.";

Export-ModuleMember -Alias * -Function *