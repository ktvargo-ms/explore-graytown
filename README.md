# Explore Graytown

This repo is the source of tools, samples, tutorials, and other resources for customers of Graytown.

## Features

This project provides the following:

* Pre-configured codespace with [K3s](https://k3s.io/) cluster via [K3d](https://k3d.io/)
* Graytown M4

> [!IMPORTANT]
> Codespaces are easy to setup quickly and tear down later, but they're not suitable for performance evaluation or scale testing. For those scenarios, use a validated environment from the official documentation.
>


## Getting Started

1. Use this GitHub codespace to explore Graytown in your browser without installing anything on your local machine.

2. ## 🚀 Quickstart in Codespaces

Click the button below to launch a preconfigured development environment in GitHub Codespaces:

!Open in Codespaces


   [![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://codespaces.new/ktvargo-ms/explore-graytown&ref=main)
https://github.com/codespaces/new?repository=ktvargo-ms/explore-graytown&ref=main

1. (Optional) Enter your Azure details to store them as environment variables inside the codespace.

1. **Important**: Open the codespace in VS Code Desktop with **Ctrl/Cmd + Shift + P** > **Codespaces: Open in VS Code Desktop**. This is required to login to Azure CLI properly.

1. Login into Azure and run the arcConnect.sh script to connect your new cluster to Azure Arc and install VME.

   ```bash
   az login
   scripts/arcConnect.sh
   ```


2. Explore!
```bash
kubectl get pods -A
```

3. Install WordPress
```bash 
kubectl apply -k WordPress/.
```

4. Finish WordPress install with WordPress README.md

## Contributing

Please view the developer guides in the docs directory to get started with contributions. Get started with the [Organization docs](./docs/ORGANIZATION.md) and [Code of Conduct](CODE_OF_CONDUCT.md).

## Trademark Notice

Trademarks This project may contain trademarks or logos for projects, products, or services. Authorized use of Microsoft trademarks or logos is subject to and must follow [Microsoft’s Trademark & Brand Guidelines](https://www.microsoft.com/legal/intellectualproperty/trademarks/usage/general). Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship. Any use of third-party trademarks or logos are subject to those third-party’s policies.
