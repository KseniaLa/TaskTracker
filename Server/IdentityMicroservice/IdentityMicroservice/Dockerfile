FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app 

# copy csproj and restore as distinct layers
COPY IdentityMicroservice/*.sln ./IdentityMicroservice/
COPY IdentityMicroservice/IdentityMicroservice/*.csproj ./IdentityMicroservice/IdentityMicroservice/
COPY IdentityMicroservice/IdentityMicroservice.DataAccess/*.csproj ./IdentityMicroservice/IdentityMicroservice.DataAccess/
COPY IdentityMicroservice/IdentityMicroservice.DataPresentation/*.csproj ./IdentityMicroservice/IdentityMicroservice.DataPresentation/
COPY IdentityMicroservice/IdentityMicroservice.Services/*.csproj ./IdentityMicroservice/IdentityMicroservice.Services/
COPY IdentityMicroservice/IdentityMicroservice.TokenManagement/*.csproj ./IdentityMicroservice/IdentityMicroservice.TokenManagement/
COPY Common/*.sln ./Common/
COPY Common/Common/*.csproj ./Common/Common/

#restore packages
WORKDIR /app/IdentityMicroservice
RUN dotnet restore 

WORKDIR /app/Common
RUN dotnet restore

WORKDIR /app 

# copy everything else and build app
COPY IdentityMicroservice/IdentityMicroservice/. ./IdentityMicroservice/IdentityMicroservice/
COPY IdentityMicroservice/IdentityMicroservice.DataAccess/. ./IdentityMicroservice/IdentityMicroservice.DataAccess/
COPY IdentityMicroservice/IdentityMicroservice.DataPresentation/. ./IdentityMicroservice/IdentityMicroservice.DataPresentation/
COPY IdentityMicroservice/IdentityMicroservice.Services/. ./IdentityMicroservice/IdentityMicroservice.Services/
COPY IdentityMicroservice/IdentityMicroservice.TokenManagement/. ./IdentityMicroservice/IdentityMicroservice.TokenManagement/
COPY Common/Common/. ./Common/Common/

WORKDIR /app/IdentityMicroservice/IdentityMicroservice
RUN dotnet publish -c Release -o out 

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app 

COPY --from=build /app/IdentityMicroservice/IdentityMicroservice/out ./
ENTRYPOINT ["dotnet", "IdentityMicroservice.dll"]
