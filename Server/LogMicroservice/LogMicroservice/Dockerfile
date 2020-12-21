FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app 

# copy csproj and restore as distinct layers
COPY LogMicroservice/*.sln ./LogMicroservice/
COPY LogMicroservice/LogMicroservice/*.csproj ./LogMicroservice/LogMicroservice/
COPY LogMicroservice/LogMicroservice.DataAccess/*.csproj ./LogMicroservice/LogMicroservice.DataAccess/
COPY LogMicroservice/LogMicroservice.DataPresentation/*.csproj ./LogMicroservice/LogMicroservice.DataPresentation/
COPY LogMicroservice/LogMicroservice.Services/*.csproj ./LogMicroservice/LogMicroservice.Services/
COPY Common/*.sln ./Common/
COPY Common/Common/*.csproj ./Common/Common/

#restore packages
WORKDIR /app/LogMicroservice
RUN dotnet restore 

WORKDIR /app/Common
RUN dotnet restore

WORKDIR /app 

# copy everything else and build app
COPY LogMicroservice/LogMicroservice/. ./LogMicroservice/LogMicroservice/
COPY LogMicroservice/LogMicroservice.DataAccess/. ./LogMicroservice/LogMicroservice.DataAccess/
COPY LogMicroservice/LogMicroservice.DataPresentation/. ./LogMicroservice/LogMicroservice.DataPresentation/
COPY LogMicroservice/LogMicroservice.Services/. ./LogMicroservice/LogMicroservice.Services/
COPY Common/Common/. ./Common/Common/

WORKDIR /app/LogMicroservice/LogMicroservice
RUN dotnet publish -c Release -o out 

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app 

COPY --from=build /app/LogMicroservice/LogMicroservice/out ./
ENTRYPOINT ["dotnet", "LogMicroservice.dll"]
