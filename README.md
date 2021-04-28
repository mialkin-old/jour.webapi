# Jour.WebAPI

## Pushing image to gcr

Auth to GCP first:

```bash
gcloud config set project helical-patrol-307414
gcloud auth login
gcloud auth configure-docker

```

Build, tag and push:

```bash
docker build -t gcr.io/helical-patrol-307414/jour.webapi .
docker push gcr.io/helical-patrol-307414/jour.webapi
```

## Running in GKE

```bash
cd deploy
kubectl kubectl apply -f deployment.yaml
```

Make sure that the service is runnig:

```bash
kubectl port-forward --namespace mialkin svc/jour-webapi 8080:80
```

## Creating secret

```bash
kubectl create secret generic jour-secrets \
--namespace=mialkin \
--from-literal=username=YOUR_USERNAME \
--from-literal=password='YOUR_PASSWORD' \
--from-literal=connection-string='YOUR_CONNECTION_STRING'
--from-literal=workout-bot-token='WORKOUT_BOT_TOKEN'
```

## Running in Docker

```bash
cd Jour.React
docker run -d -p 4000:80 --name jour.webapi gcr.io/helical-patrol-307414/jour.webapi
```

## Set bot webhook

Run this in web browser:

```text
https://api.telegram.org/bot<YOUR_TOKEN>/setWebhook?url=https://21c8cd2509f4.ngrok.io
```