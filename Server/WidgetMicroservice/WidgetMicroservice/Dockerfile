FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app 

# copy csproj and restore as distinct layers
COPY WidgetMicroservice/*.sln ./WidgetMicroservice/
COPY WidgetMicroservice/WidgetMicroservice/*.csproj ./WidgetMicroservice/WidgetMicroservice/
COPY WidgetMicroservice/WidgetMicroservice.DataAccess/*.csproj ./WidgetMicroservice/WidgetMicroservice.DataAccess/
COPY WidgetMicroservice/WidgetMicroservice.DataPresentation/*.csproj ./WidgetMicroservice/WidgetMicroservice.DataPresentation/
COPY WidgetMicroservice/WidgetMicroservice.Services/*.csproj ./WidgetMicroservice/WidgetMicroservice.Services/
COPY Common/*.sln ./Common/
COPY Common/Common/*.csproj ./Common/Common/

#restore packages
WORKDIR /app/WidgetMicroservice
RUN dotnet restore 

WORKDIR /app/Common
RUN dotnet restore

WORKDIR /app 

# copy everything else and build app
COPY WidgetMicroservice/WidgetMicroservice/. ./WidgetMicroservice/WidgetMicroservice/
COPY WidgetMicroservice/WidgetMicroservice.DataAccess/. ./WidgetMicroservice/WidgetMicroservice.DataAccess/
COPY WidgetMicroservice/WidgetMicroservice.DataPresentation/. ./WidgetMicroservice/WidgetMicroservice.DataPresentation/
COPY WidgetMicroservice/WidgetMicroservice.Services/. ./WidgetMicroservice/WidgetMicroservice.Services/
COPY Common/Common/. ./Common/Common/

WORKDIR /app/WidgetMicroservice/WidgetMicroservice
RUN dotnet publish -c Release -o out 

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app 

COPY --from=build /app/WidgetMicroservice/WidgetMicroservice/out ./
ENTRYPOINT ["dotnet", "WidgetMicroservice.dll"]
