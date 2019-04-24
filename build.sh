#!/usr/bin/env bash
repoFolder="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
cd $repoFolder

onsolveEPZip="https://github.com/minhbt/ExchangeRatePredict/blob/master/Deliveries/Archive.zip"
if [ ! -z $ONSOLVEEP_ZIP ]; then
    onsolveEPZip=$ONSOLVEEP_ZIP
fi

buildFolder=".build"
buildFile="$buildFolder/KoreBuild.sh"

if test ! -d $buildFolder; then
    echo "Downloading KoreBuild from $onsolveEPZip"

    tempFolder="/tmp/KoreBuild-$(uuidgen)"
    mkdir $tempFolder

    localZipFile="$tempFolder/korebuild.zip"

    retries=6
    until (wget -O $localZipFile $onsolveEPZip 2>/dev/null || curl -o $localZipFile --location $onsolveEPZip 2>/dev/null)
    do
        echo "Failed to download '$onsolveEPZip'"
        if [ "$retries" -le 0 ]; then
            exit 1
        fi
        retries=$((retries - 1))
        echo "Waiting 10 seconds before retrying. Retries left: $retries"
        sleep 10s
    done

    unzip -q -d $tempFolder $localZipFile

    mkdir $buildFolder
    cp -r $tempFolder/**/build/** $buildFolder

    chmod +x $buildFile

    # Cleanup
    if test -d $tempFolder; then
        rm -rf $tempFolder
    fi
fi

$buildFile -r $repoFolder "$@"
