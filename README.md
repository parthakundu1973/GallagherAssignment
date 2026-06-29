Cloud & DevOps
Deployment

The application is deployed using an Azure DevOps CI/CD pipeline.

The React frontend is built and deployed to Azure Static Web Apps.
The ASP.NET Core Web API is built into a Docker image.
The Docker image is pushed to Azure Container Registry (ACR).
The backend is deployed to Azure Kubernetes Service (AKS) using Kubernetes deployment and service manifests.
Continuous Integration (CI)

Whenever changes are pushed to the main branch, the pipeline automatically:

Restores .NET and Node.js dependencies.
Builds the frontend and backend projects.
Runs backend unit tests.
Builds a Docker image for the API.
Pushes the image to Azure Container Registry.

This ensures that only successfully built and tested code is prepared for deployment.

Continuous Deployment (CD)

After a successful build:

The frontend is automatically published to Azure Static Web Apps.
Kubernetes is updated to use the latest Docker image from Azure Container Registry, enabling automated deployment of the backend.

Using Kubernetes provides rolling updates, which replace application instances gradually and minimise downtime during deployments.

Scaling

The backend runs on Azure Kubernetes Service, allowing multiple instances (pods) of the API to run simultaneously. If application demand increases, the number of replicas can be increased manually or automatically using the Kubernetes Horizontal Pod Autoscaler based on CPU or memory utilisation.

The frontend is hosted on Azure Static Web Apps, which automatically scales to handle increasing traffic without requiring additional infrastructure management.

Future Improvements

For a production environment, the deployment could be enhanced by:

Using separate Development, Staging and Production environments.
Tagging Docker images with version numbers instead of latest.
Managing secrets with Azure Key Vault.
Adding monitoring and logging with Azure Monitor and Application Insights.
Implementing approval gates before deploying to production.# GallagherAssignment