# Bookstore Microservices Backend

This is a simple backend microservices application. The goal is to explore **key architectural patterns** in microservices using docker and kubernetes rather than focus on complex business logic.

The application represents a **bookstore marketplace** that allows users to:
- 🛒 Browse books
- 📦 Place orders
- 🧑‍💼 Manage book stock (admin only)

---

## ⚙️ Tech Stack

- **C# .NET 8** – Service implementations
- **RabbitMq & MassTransit** – Async communication
- **Docker & Docker Compose** – Local environment
- **Kubernetes (AKS)** – Cloud deployment
- **NGINX Ingress Controller** – TLS termination and routing
- **Azure** – Hosting via Azure Kubernetes Service
- **Cert-Manager + Let's Encrypt** – TLS certificate automation
- **In-memory Databases** – Used for simplicity

---

## 🚀 Running the Project Locally

To run this project on your local machine, make sure you have:

- Docker installed and running

### 🔧 Run the whole system:

```bash
docker-compose up --build
```

After the services are up, you can access the API via the **API Gateway** (entry point):

```http
http://localhost:8080/api/catalog
```

---

## 🧱 Services Overview

### 🔐 Ingress Controller (Kubernetes)

- **TLS Termination & Routing**
- Handles HTTPS in production (via Let's Encrypt)
- Routes external traffic to the API Gateway
- Configured using **NGINX Ingress Controller**

> In production, it sits behind an **Azure Load Balancer**.

---

### 🌐 API Gateway

- Acts as a **reverse proxy** using yarp
- Central entry point for all client requests
- Forwards requests to the appropriate microservices (e.g., `BookService`, `OrderService`)
- Handles path-based routing:  
  Example: `/api/books` → forwarded to BookService

---
### 📚 CatalogService

- Acts as a BFF
- Fetches and aggregate books and their available stock from bookservice and inventoryservice

---

### 📦 InventoryService 

- Handles book stock management 
- Uses **in-memory database** for simplicity

---

### 📚 BookService

- Exposes endpoints to list available books
- Uses **in-memory database** for simplicity

---

### 📦 OrderService 

- Intended to handle user orders 
- Follows separation of concerns

---

## ☁️ Kubernetes Deployment

The app is designed to run on **Azure Kubernetes Service (AKS)** with:

- **System Node Pool**: Runs infrastructure services
- **User Node Pool**: Hosts application microservices

If the bookstore.aks.it.com/api/catalog endpoint is unresponsive, the cluster may be shut down to avoid unnecessary billing

---

## 🧪 Learning Focus

This is **not a production-ready system**, but rather an architectural playground to experiment with:

- ✅ Microservices communication
- ✅ Ingress & Gateway configuration
- ✅ Docker Compose for local development
- ✅ AKS deployment 
- ✅ TLS setup with cert-manager

The **business logic is intentionally minimal**, to keep the focus on infrastructure, service boundaries, and microservices best practices.

---

## 📚 License

MIT – Use it for learning and building cool stuff 🚀
