#!/bin/bash
set -e

ENVDIR=${1};
ECRIMAGEPREFIX=${2};
ECRREPOSITORY=${3};
BUILDNUMBER=${4};
WORKDIR="/home/vsts/work/_temp/${BUILDNUMBER}";
FULLIMAGENAME="${ECRIMAGEPREFIX}/${ECRREPOSITORY}:${BUILDNUMBER}";
REPOSITORY="https://uxzjtmutz73oyazhgw7bklghtm3q63pemvq4hkjyqc3gj5rdiira@dev.azure.com/VICERI-DevOps/SalesBox/_git/SalesBox.GitOps";

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
    git config --local user.email "kserain@viceri.com.br";
    git config --local user.name "kserain";
    git commit -m "Updating Kustomization Image ${ECRIMAGEPREFIX}/${ECRREPOSITORY}:${BUILDNUMBER}";
    git push "${REPOSITORY}" HEAD:main;
}

createDirectoryIfNotExists
cloneArgoGitOpsRepository
setNewImageOnKustomize
pushChangesToGitOpsRepository
