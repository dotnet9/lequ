#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Lequ/Lequ.csproj", "Lequ/"]
COPY ["Lequ.Service/Lequ.Service.csproj", "Lequ.Service/"]
COPY ["Lequ.IRepository/Lequ.IRepository.csproj", "Lequ.IRepository/"]
COPY ["Lequ.Model/Lequ.Model.csproj", "Lequ.Model/"]
COPY ["Lequ.IService/Lequ.IService.csproj", "Lequ.IService/"]
COPY ["Lequ.Extensions/Lequ.Extensions.csproj", "Lequ.Extensions/"]
COPY ["Lequ.Repository/Lequ.Repository.csproj", "Lequ.Repository/"]
RUN dotnet restore "Lequ/Lequ.csproj"
COPY . .
WORKDIR "/src/Lequ"
RUN dotnet build "Lequ.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lequ.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lequ.dll"]