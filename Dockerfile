# https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-3.1

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy sln,csproj and restore as distinct layers
COPY *.sln .
COPY BierpediaApi/*.csproj ./BierpediaApi/
RUN dotnet restore

# copy everything else and build app
COPY BierpediaApi/. ./BierpediaApi/
WORKDIR /app/BierpediaApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/BierpediaApi/out ./
ENTRYPOINT ["dotnet", "BierpediaApi.dll"]
