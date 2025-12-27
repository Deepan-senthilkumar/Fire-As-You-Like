# Build stage
FROM node:18-alpine AS builder
WORKDIR /app

# Install deps
COPY package*.json ./
RUN npm ci

# Copy rest and build
COPY . .
RUN npm run build

# Runtime stage
FROM node:18-alpine
WORKDIR /app
ENV NODE_ENV=production
ENV PORT=8080

COPY --from=builder /app/package*.json ./
COPY --from=builder /app/dist ./dist

# Install production deps
RUN npm ci --only=production

EXPOSE 8080

HEALTHCHECK --interval=30s --timeout=5s CMD node -e "process.exit(0)" || exit 1

CMD ["node", "dist/index.js"]
