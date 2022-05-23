FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 5122

ENV ASPNETCORE_URLS=http://+:5122

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /
COPY ["ETutor-Api.csproj", "./"]
RUN dotnet restore "ETutor-Api.csproj"
COPY . .
WORKDIR "/src/ETutor-Api"
RUN dotnet build "ETutor-Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ETutor-Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ETutor-Api.dll"]
