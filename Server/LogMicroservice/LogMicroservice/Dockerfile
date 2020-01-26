FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src/mic
COPY ["LogMicroservice/LogMicroservice/LogMicroservice.csproj", "LogMicroservice/"]
COPY ["LogMicroservice/LogMicroservice.DataAccess/LogMicroservice.DataAccess.csproj", "LogMicroservice.DataAccess/"]
COPY ["Common/Common/Common.csproj", "../Common/Common/"]
COPY ["LogMicroservice/LogMicroservice.Services/LogMicroservice.Services.csproj", "LogMicroservice.Services/"]
COPY ["LogMicroservice/LogMicroservice.DataPresentation/LogMicroservice.DataPresentation.csproj", "LogMicroservice.DataPresentation/"]
RUN dotnet restore "LogMicroservice/LogMicroservice.csproj"
COPY . .
WORKDIR "/src/mic/LogMicroservice.DataAccess"
RUN dotnet build "LogMicroservice.DataAccess.csproj" -c Release -o /app
WORKDIR "/src/mic/LogMicroservice.Services"
RUN dotnet build "LogMicroservice.Services.csproj" -c Release -o /app
WORKDIR "/src/mic/LogMicroservice"
RUN dotnet build "LogMicroservice.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LogMicroservice.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LogMicroservice.dll"]