FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app 

# copy csproj and restore as distinct layers
COPY TaskTracker/*.sln ./TaskTracker/
COPY TaskTracker/TaskMicroservice/*.csproj ./TaskTracker/TaskMicroservice/
COPY TaskTracker/TaskMicroservice.DataAccess/*.csproj ./TaskTracker/TaskMicroservice.DataAccess/
COPY TaskTracker/TaskMicroservice.DataPresentation/*.csproj ./TaskTracker/TaskMicroservice.DataPresentation/
COPY TaskTracker/TaskMicroservice.Services/*.csproj ./TaskTracker/TaskMicroservice.Services/
COPY Common/*.sln ./Common/
COPY Common/Common/*.csproj ./Common/Common/

#restore packages
WORKDIR /app/TaskTracker
RUN dotnet restore 

WORKDIR /app/Common
RUN dotnet restore

WORKDIR /app 

# copy everything else and build app
COPY TaskTracker/TaskMicroservice/. ./TaskTracker/TaskMicroservice/
COPY TaskTracker/TaskMicroservice.DataAccess/. ./TaskTracker/TaskMicroservice.DataAccess/
COPY TaskTracker/TaskMicroservice.DataPresentation/. ./TaskTracker/TaskMicroservice.DataPresentation/
COPY TaskTracker/TaskMicroservice.Services/. ./TaskTracker/TaskMicroservice.Services/
COPY Common/Common/. ./Common/Common/

WORKDIR /app/TaskTracker/TaskMicroservice
RUN dotnet publish -c Release -o out 

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app 

COPY --from=build /app/TaskTracker/TaskMicroservice/out ./
ENTRYPOINT ["dotnet", "TaskMicroservice.dll"]
