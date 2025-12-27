#!/bin/bash

# Navigate to the project root directory
cd "$(dirname "$0")/../../"

# Clean previous builds
echo "Cleaning previous builds..."
rm -rf build/

# Create a new build directory
mkdir build

# Copy assets to the build directory
echo "Copying assets..."
cp -r Assets/* build/

# Build the server
echo "Building server..."
cd Server
npm install
npm run build

# Copy server build to the build directory
cp -r dist/* ../build/

# Return to the root directory
cd ..

# Package the build for deployment
echo "Packaging build..."
tar -czf build.tar.gz build/

# Clean up the build directory
rm -rf build/

echo "Build process completed successfully!"