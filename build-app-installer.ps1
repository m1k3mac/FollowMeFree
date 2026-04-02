<#
<#
.SYNOPSIS
  Builds the FollowMeFree WinForms application and packages the output into the
  Installer project's app-publish folder, then builds the installer itself.

.DESCRIPTION
  1. Builds the FollowMeFree WinForms project in Release configuration.
  2. Copies the build output into FollowMeFree.Installer\app-publish\.
  3. Builds the FollowMeFree.Installer project so the bundled files are included.

.EXAMPLE
  .\build-app-installer.ps1
#>

param(
    [string]$Configuration = "Release"
)

$ErrorActionPreference = "Stop"
$solutionDir = Split-Path -Parent $MyInvocation.MyCommand.Definition

$winformsProject = Join-Path $solutionDir "FollowMeFree\FollowMeFree.csproj"
$installerProject = Join-Path $solutionDir "FollowMeFree.Installer\FollowMeFree.Installer.csproj"
$appPublishDir = Join-Path $solutionDir "FollowMeFree.Installer\app-publish"

# ?? Locate MSBuild via vswhere (required for .NET Framework 4.8 projects) ????
$vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"
if (-not (Test-Path $vswhere)) {
    throw "vswhere.exe not found. Please install Visual Studio (any edition) or the Visual Studio Build Tools."
}

$msbuildPath = & $vswhere -latest -requires Microsoft.Component.MSBuild -find "MSBuild\**\Bin\MSBuild.exe" | Select-Object -First 1
if (-not $msbuildPath) {
    throw "MSBuild.exe not found. Please install the '.NET desktop development' workload in Visual Studio."
}
Write-Host "Using MSBuild: $msbuildPath" -ForegroundColor Gray

Write-Host "=== Building FollowMeFree WinForms application ===" -ForegroundColor Cyan
& $msbuildPath $winformsProject /p:Configuration=$Configuration /p:Platform=AnyCPU /restore /verbosity:minimal
if ($LASTEXITCODE -ne 0) { throw "WinForms build failed." }

$buildOutput = Join-Path $solutionDir "FollowMeFree\bin\$Configuration"
if (-not (Test-Path $buildOutput)) {
    throw "Build output not found at: $buildOutput"
}

Write-Host ""
Write-Host "=== Copying build output to app-publish ===" -ForegroundColor Cyan
if (Test-Path $appPublishDir) {
    Remove-Item $appPublishDir -Recurse -Force
}
Copy-Item $buildOutput $appPublishDir -Recurse
Write-Host "Copied to: $appPublishDir"

Write-Host ""
Write-Host "=== Building FollowMeFree.Installer ===" -ForegroundColor Cyan
& dotnet build $installerProject -c $Configuration
if ($LASTEXITCODE -ne 0) { throw "Installer build failed." }

Write-Host ""
Write-Host "=== Done ===" -ForegroundColor Green
Write-Host "The installer is ready in:"
Write-Host "  FollowMeFree.Installer\bin\$Configuration\net8.0-windows\"
