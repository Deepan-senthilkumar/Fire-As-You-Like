# Deployment Guide

This document explains how to build, run and deploy the server component for Modern Reality Battle Royale.

## Local Docker test

1. Build and run locally (requires Docker):

```powershell
# from repo root
./scripts/run-server-docker.ps1
```

The server will be available on `localhost:8080`.

## CI: GitHub Actions -> GHCR

A GitHub Actions workflow is included at `.github/workflows/docker-image.yml` which builds the server Docker image and pushes it to GitHub Container Registry (GHCR) under `ghcr.io/<owner>/modern-reality-battle-royale-server:latest` when commits are pushed to `main`.

Notes:
- The workflow uses `GITHUB_TOKEN` to push to GHCR. You may need to grant `packages: write` if using a different user.

## Kubernetes deployment (example)

Kubernetes manifests for a simple Deployment, Service (LoadBalancer) and HPA are in `infra/k8s/server-deployment.yaml`.

Apply with:

```bash
kubectl apply -f infra/k8s/server-deployment.yaml
```

## Agones (GameServer) example

An Agones `GameServer` spec example is provided at `infra/agones/gameserver.yaml` for use with an Agones-enabled cluster.

## Next steps
- Configure container image registry and secrets for your cluster to pull from GHCR (or other registry).
- Add health checks and liveness/readiness probes suitable to your server.
- Add TLS/ingress / DDoS protection and autoscaling rules (Agones or GameLift if preferred).
