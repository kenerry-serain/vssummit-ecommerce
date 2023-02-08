#!/bin/bash
set -e

ENVDIR=${1};
ECRIMAGEPREFIX=${2};
ECRREPOSITORY=${3};
BUILDNUMBER=${4};
WORKDIR="/home/vsts/work/_temp/${BUILDNUMBER}";
FULLIMAGENAME="${ECRIMAGEPREFIX}/${ECRREPOSITORY}:${BUILDNUMBER}";
REPOSITORY="https://g3o5pftxou53w3gfvqyqg6tndmxexh5jex3r72wk2tggg4pdpsqa@dev.azure.com/kenerrysoftwareengineer/VSSummit-2023/_git/vssummit-gitops";

createDirectoryIfNotExists(){
    if [ ! -d "${WORKDIR}" ]; then
        mkdir "${WORKDIR}";
    fi

    cd "${WORKDIR}";
}

cloneArgoGitOpsRepository(){
    git init;
    git pull "${REPOSITORY}" main:main;

    cd "${ENVDIR}";
}

setNewImageOnKustomize(){
    kustomize edit set image "${ECRIMAGEPREFIX}/${ECRREPOSITORY}"="${FULLIMAGENAME}";
}

pushChangesToGitOpsRepository(){
    git add ./kustomization.yaml;
    git config --local user.email "kenerry.software.engineer@gmail.com";
    git config --local user.name "Kenrry Serain";
    git commit -m "Updating Kustomization Image ${ECRIMAGEPREFIX}/${ECRREPOSITORY}:${BUILDNUMBER}";
    git push "${REPOSITORY}" HEAD:main;
}

createDirectoryIfNotExists
cloneArgoGitOpsRepository
setNewImageOnKustomize
pushChangesToGitOpsRepository
