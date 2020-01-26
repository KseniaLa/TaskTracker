FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TaskTracker/TaskMicroservice/TaskMicroservice.csproj", "TaskMicroservice/"]
COPY ["TaskTracker/TaskMicroservice.DataPresentation/TaskMicroservice.DataPresentation.csproj", "TaskMicroservice.DataPresentation/"]
COPY ["TaskTracker/TaskMicroservice.Services/TaskMicroservice.Services.csproj", "TaskMicroservice.Services/"]
COPY ["TaskTracker/TaskMicroservice.DataAccess/TaskMicroservice.DataAccess.csproj", "TaskMicroservice.DataAccess/"]
COPY ["Common/Common/Common.csproj", "../Common/Common/"]
RUN dotnet restore "TaskMicroservice/TaskMicroservice.csproj"
COPY . .
WORKDIR "/src/TaskMicroservice"
RUN dotnet build "TaskMicroservice.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TaskMicroservice.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TaskMicroservice.dll"]