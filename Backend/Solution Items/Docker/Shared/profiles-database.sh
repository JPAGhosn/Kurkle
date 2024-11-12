#!/usr/bin/env bash

REGISTRY_URL="localhost:9870";

docker build \
  -t ${REGISTRY_URL}/kurkle/profiles-database \
  -f ../Dockerfiles/ProfilesDatabaseDockerfile ../../..;
  
docker push ${REGISTRY_URL}/kurkle/profiles-database
