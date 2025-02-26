# PowerShell script that recursively gathers all NuGet package files into one output folder

$CurrentPath = (Get-Location -PSProvider FileSystem).ProviderPath

# recursively get all NuGet package files
$AllFolders = Get-ChildItem .\ -include *.nupkg,*.snupkg -Recurse | foreach {$_.fullname}

# copy folders to output
if($AllFolders -ne $null)
{
    If(!(test-path -PathType container ".\Output"))
    {
        New-Item -Path "." -Name "Output" -ItemType "directory"
    }

    Write-Host
    foreach ($item in $AllFolders) 
    {
        Move-Item $item -Destination '.\Output'
        Write-Host "Moved: ." -nonewline; 
        Write-Host $item.replace($CurrentPath, ""); 
    } 
}

Write-Host