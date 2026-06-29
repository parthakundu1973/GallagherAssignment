Overview


## This project is a full-stack web application consisting of:
Frontend: React (Vite v8.1.0)
Backend: ASP.NET Core Web API (.NET SDK 10)

## Running the Backend GallagherAssessment.API
It will stratight launch Swagger Page.

## Running the Frontend

cd GallagherAssessment.Client

npm install

npm run dev

This starts the Vite development server. By default, the application is available at:

http://localhost:5170
## Troubleshoot.
 Please check and cinfigure VITE_API_URL in .env.development in frontend.
Checke Cors=>AllowedOrigins at Program.cs see front end url is allowed or not.
vite.config.ts configured to run the site in 5170

## Cloud & DevOps Deployment.
As you wanted Briefly explain in a readme how you would deploy, scale, and update your 
system (CI/CD, containers, cloud services, etc.). 

I have Created azure-pipelines.yml,Dockerfile for API ,k8s/deployment and service in this project just to share my thought about CI CD. 

The application should deployed using an Azure DevOps CI/CD pipeline.

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

## Continuous Deployment (CD).

After a successful build:

The frontend is automatically published to Azure Static Web Apps.
Kubernetes is updated to use the latest Docker image from Azure Container Registry, enabling automated deployment of the backend.

Using Kubernetes provides rolling updates, which replace application instances gradually and minimise downtime during deployments.

## Scaling.

The backend runs on Azure Kubernetes Service, allowing multiple instances (pods) of the API to run simultaneously. If application demand increases, the number of replicas can be increased manually or automatically using the Kubernetes Horizontal Pod Autoscaler based on CPU or memory utilisation.

The frontend is hosted on Azure Static Web Apps, which automatically scales to handle increasing traffic without requiring additional infrastructure management.

## Future Improvements

For a production environment, the deployment could be enhanced by:

Using separate Development, Staging and Production environments.
Tagging Docker images with version numbers instead of latest.
Managing secrets with Azure Key Vault.
Adding monitoring and logging with Azure Monitor and Application Insights.
Implementing approval gates before deploying to production.# GallagherAssignment
Configure Azure API Management  for Rate limiting , Authorisation ussing OpenID and Oauth2, Routing ,CORS  ETC. 
