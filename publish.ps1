param([string]$key, [string]$vnext)

Get-ChildItem . -recurse -Filter *.csproj | 
Foreach-Object {
    $file = $_.FullName

    (Get-Content $file) | ForEach-Object { $_ -replace "<Version>(.+)</Version>", "<Version>$vnext</Version>" } | Set-Content -Path $file
}

$root = Get-Location
$publish = Join-Path -Path $root -ChildPath ".publish"

Write-Host $publish

Remove-Item $publish -Force -Recurse -ErrorAction Ignore

iex "dotnet pack -c Release -o $publish"

Set-Location -Path $publish

#Get-ChildItem . -recurse -Filter *.nupkg | Write-Host

iex "dotnet nuget push *.nupkg -k $key -s https://api.nuget.org/v3/index.json"

Set-Location -Path $root

Remove-Item $publish -Force -Recurse -ErrorAction Ignore