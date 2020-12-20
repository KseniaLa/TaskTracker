FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app 

# copy csproj and restore as distinct layers
COPY DashboardMicroservice/*.sln ./DashboardMicroservice/
COPY DashboardMicroservice/DashboardMicroservice/*.csproj ./DashboardMicroservice/DashboardMicroservice/

#restore packages
WORKDIR /app/DashboardMicroservice
RUN dotnet restore 

WORKDIR /app 

# copy everything else and build app
COPY DashboardMicroservice/DashboardMicroservice/. ./DashboardMicroservice/DashboardMicroservice/

WORKDIR /app/DashboardMicroservice/DashboardMicroservice
RUN dotnet publish -c Release -o out 

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app 

COPY --from=build /app/DashboardMicroservice/DashboardMicroservice/out ./
ENTRYPOINT ["dotnet", "DashboardMicroservice.dll"]
