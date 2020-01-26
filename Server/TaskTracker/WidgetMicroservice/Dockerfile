FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["TaskTracker/WidgetMicroservice/WidgetMicroservice.csproj", "WidgetMicroservice/"]
COPY ["TaskTracker/WidgetMicroservice.DataPresentation/WidgetMicroservice.DataPresentation.csproj", "WidgetMicroservice.DataPresentation/"]
COPY ["TaskTracker/WidgetMicroservice.Services/WidgetMicroservice.Services.csproj", "WidgetMicroservice.Services/"]
COPY ["TaskTracker/WidgetMicroservice.DataAccess/WidgetMicroservice.DataAccess.csproj", "WidgetMicroservice.DataAccess/"]
COPY ["Common/Common/Common.csproj", "../Common/Common/"]
RUN dotnet restore "WidgetMicroservice/WidgetMicroservice.csproj"
COPY . .
WORKDIR "/src/WidgetMicroservice"
RUN dotnet build "WidgetMicroservice.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WidgetMicroservice.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WidgetMicroservice.dll"]