<#
.SYNOPSIS
    Builds the FollowMeFree API Installer for distribution.

.DESCRIPTION
    1. Publishes the API project (Release, framework-dependent, no PDBs).
    2. Publishes the Installer project as a self-contained Windows executable.
    3. Bundles the API files into the installer output folder.

    The resulting folder can be zipped and distributed to target machines.
    End users only need IIS and the ASP.NET Core 8.0 Hosting Bundle installed.

.PARAMETER Configuration
    Build configuration (Debug or Release). Default: Release.

.EXAMPLE
    .\build-api-installer.ps1
    .\build-api-installer.ps1 -Configuration Debug
#>
param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release"
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

$root            = $PSScriptRoot
$apiProj         = Join-Path $root "FollowMeFree.API\FollowMeFree.API.csproj"
$installerProj   = Join-Path $root "FollowMeFree.API.Installer\FollowMeFree.API.Installer.csproj"
$apiPublishDir   = Join-Path $root "FollowMeFree.API.Installer\api-publish"
$outputDir       = Join-Path $root "FollowMeFree.API.Installer\bin\installer-output"

# ── Step 1: Publish the API ──────────────────────────────────────────────────
Write-Host "`n== Publishing FollowMeFree.API ==" -ForegroundColor Cyan
if (Test-Path $apiPublishDir) { Remove-Item $apiPublishDir -Recurse -Force }
dotnet publish $apiProj -c $Configuration -o $apiPublishDir -p:DebugType=none -p:DebugSymbols=false
if ($LASTEXITCODE -ne 0) { throw "dotnet publish (API) failed (exit code $LASTEXITCODE)." }
Write-Host "API published to: $apiPublishDir" -ForegroundColor Green

# ── Step 2: Publish the Installer (self-contained) ──────────────────────────
Write-Host "`n== Publishing FollowMeFree.API.Installer ==" -ForegroundColor Cyan
if (Test-Path $outputDir) { Remove-Item $outputDir -Recurse -Force }
dotnet publish $installerProj -c $Configuration -o $outputDir -r win-x64 --self-contained
if ($LASTEXITCODE -ne 0) { throw "dotnet publish (Installer) failed (exit code $LASTEXITCODE)." }
Write-Host "Installer published to: $outputDir" -ForegroundColor Green

# ── Step 3: Bundle API files alongside the installer ────────────────────────
Write-Host "`n== Bundling API files into installer output ==" -ForegroundColor Cyan
$destApiDir = Join-Path $outputDir "api-publish"
Copy-Item -Path $apiPublishDir -Destination $destApiDir -Recurse
$fileCount = (Get-ChildItem -Path $destApiDir -File -Recurse).Count
Write-Host "Bundled $fileCount API file(s) into installer." -ForegroundColor Green

# ── Done ─────────────────────────────────────────────────────────────────────
Write-Host "`n== Build Complete ==" -ForegroundColor Cyan
Write-Host "Distributable installer folder:" -ForegroundColor Yellow
Write-Host "  $outputDir" -ForegroundColor White
Write-Host ""
Write-Host "To deploy, copy this entire folder to the target machine and run:" -ForegroundColor Yellow
Write-Host "  FollowMeFree.API.Installer.exe" -ForegroundColor White
Write-Host ""
Write-Host "Target machine prerequisites:" -ForegroundColor Yellow
Write-Host "  - IIS enabled" -ForegroundColor White
Write-Host "  - ASP.NET Core 8.0 Hosting Bundle installed" -ForegroundColor White
