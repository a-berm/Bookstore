# Bookstore Microservices Backend

This is a simple backend microservices application designed as a learning project. The goal is to explore **key architectural patterns** in microservices rather than focus on complex business logic.

The application represents a **bookstore marketplace** that allows users to:
- 🛒 Browse books
- 📦 Place orders
- 🧑‍💼 Manage book stock (admin only)

---

## ⚙️ Tech Stack

- **.NET 8** – Service implementations
- **Docker & Docker Compose** – Local environment
- **Kubernetes (AKS)** – Cloud deployment
- **NGINX Ingress Controller** – TLS termination and routing
- **Azure** – Hosting via Azure Kubernetes Service
- **Cert-Manager + Let's Encrypt** – TLS certificate automation
- **In-memory Databases** – Used for simplicity in a learning context

---

## 🚀 Running the Project Locally

To run this project on your local machine, make sure you have:

- Docker installed and running
- Docker Compose

### 🔧 Run the whole system:

```bash
docker-compose up --build
```

After the services are up, you can access the API via the **API Gateway** (entry point):

```http
http://localhost:8080/api/books
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

- Acts as a **reverse proxy**
- Central entry point for all client requests
- Forwards requests to the appropriate microservices (e.g., `BookService`, `OrderService`)
- Handles path-based routing:  
  Example: `/api/books` → forwarded to BookService

---

### 📚 BookService

- Exposes endpoints to list available books
- Handles book stock management (admin only)
- Uses **in-memory database** for simplicity

---

### 📦 OrderService *(planned or stub)*

- Intended to handle user orders and payment (currently minimal or stubbed)
- Follows separation of concerns

---

## ☁️ Kubernetes Deployment

The app is designed to run on **Azure Kubernetes Service (AKS)** with:

- **System Node Pool**: Runs infrastructure services (e.g., ingress)
- **User Node Pool**: Hosts application microservices

All services are containerized and deployed as Kubernetes deployments behind a shared ingress controller.

---

## 🧪 Learning Focus

This is **not a production-ready system**, but rather an architectural playground to experiment with:

- ✅ Microservices communication
- ✅ Ingress & Gateway configuration
- ✅ Docker Compose for local development
- ✅ AKS deployment pipelines
- ✅ TLS setup with cert-manager

The **business logic is intentionally minimal**, using **in-memory databases** to keep the focus on infrastructure, service boundaries, and microservices best practices.

---

## 📄 API Access (local)

Here’s how to test it once everything is running locally:

```http
GET http://localhost:8080/api/books
```

Sample response:
```json
[
  {
    "id": 1,
    "title": "The Great Gatsby",
    "author": "F. Scott Fitzgerald",
    "price": 10.99
  },
  ...
]
```

---

## ✅ To-Do / Enhancements

- 🔁 Replace in-memory DB with PostgreSQL or MongoDB
- 🚛 Implement event-driven communication (e.g., via RabbitMQ)
- 🔐 Add authentication and role-based access
- 📦 Complete `OrderService` and add billing logic
- 🧪 Add integration tests and health checks

---

## 📚 License

MIT – Use it for learning and building cool stuff 🚀
