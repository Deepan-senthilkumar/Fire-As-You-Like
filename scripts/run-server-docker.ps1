# Build local Docker image and run it (Windows PowerShell)
$tag = "mrbr-server:local"
Write-Output "Building image $tag..."
docker build -t $tag ./server

Write-Output "Running container (map port 8080)..."
docker run -p 8080:8080 --rm $tag
