#!/bin/bash

# This script deploys the battle royale game to the specified server.

# Define variables
SERVER_USER="your_username"
SERVER_IP="your_server_ip"
DEPLOY_DIR="/path/to/deploy/directory"

# Build the client and server
echo "Building the client..."
cd client
# Assuming a build command for Unity
# unity -batchmode -quit -projectPath . -executeMethod BuildScript.PerformBuild
cd ..

echo "Building the server..."
cd server
npm install
npm run build
cd ..

# Deploy to the server
echo "Deploying to the server..."
scp -r client/* $SERVER_USER@$SERVER_IP:$DEPLOY_DIR/client
scp -r server/* $SERVER_USER@$SERVER_IP:$DEPLOY_DIR/server
scp -r shared/* $SERVER_USER@$SERVER_IP:$DEPLOY_DIR/shared

echo "Deployment completed successfully!"