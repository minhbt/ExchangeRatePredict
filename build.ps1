$ErrorActionPreference = "Stop"

function DownloadWithRetry([string] $url, [string] $downloadLocation, [int] $retries)
{
    while($true)
    {
        try
        {
            Invoke-WebRequest $url -OutFile $downloadLocation
            break
        }
        catch
        {
            $exceptionMessage = $_.Exception.Message
            Write-Host "Failed to download '$url': $exceptionMessage"
            if ($retries -gt 0) {
                $retries--
                Write-Host "Waiting 10 seconds before retrying. Retries left: $retries"
                Start-Sleep -Seconds 10

            }
            else
            {
                $exception = $_.Exception
                throw $exception
            }
        }
    }
}

cd $PSScriptRoot

$repoFolder = $PSScriptRoot
$env:REPO_FOLDER = $repoFolder

$onsolveEPZip="https://github.com/minhbt/ExchangeRatePredict/blob/master/Deliveries/Archive.zip"
if ($env:EPBUILD_ZIP)
{
    $onsolveEPZip=$env:EPBUILD_ZIP
}

$buildFolder = ".build"
$buildFile="$buildFolder\build.ps1"

if (!(Test-Path $buildFolder)) {
    Write-Host "Downloading epbuild from $onsolveEPZip"

    $tempFolder=$env:TEMP + "\epbuild-" + [guid]::NewGuid()
    New-Item -Path "$tempFolder" -Type directory | Out-Null

    $localZipFile="$tempFolder\epbuild.zip"

    DownloadWithRetry -url $onsolveEPZip -downloadLocation $localZipFile -retries 6

    Add-Type -AssemblyName System.IO.Compression.FileSystem
    [System.IO.Compression.ZipFile]::ExtractToDirectory($localZipFile, $tempFolder)

    New-Item -Path "$buildFolder" -Type directory | Out-Null
    copy-item "$tempFolder\**\build\*" $buildFolder -Recurse

    # Cleanup
    if (Test-Path $tempFolder) {
        Remove-Item -Recurse -Force $tempFolder
    }
}

&"$buildFile" @args
