#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Lequ.Blog/Lequ.Blog.csproj", "Lequ.Blog/"]
COPY ["Lequ.Blog.Repository/Lequ.Blog.Repository.csproj", "Lequ.Blog.Repository/"]
COPY ["Lequ.Blog.IRepository/Lequ.Blog.IRepository.csproj", "Lequ.Blog.IRepository/"]
COPY ["Lequ.Blog.Model/Lequ.Blog.Model.csproj", "Lequ.Blog.Model/"]
COPY ["Lequ.Blog.Service/Lequ.Blog.Service.csproj", "Lequ.Blog.Service/"]
COPY ["Lequ.Blog.IService/Lequ.Blog.IService.csproj", "Lequ.Blog.IService/"]
COPY ["Lequ.Blog.Extensions/Lequ.Blog.Extensions.csproj", "Lequ.Blog.Extensions/"]
RUN dotnet restore "Lequ.Blog/Lequ.Blog.csproj"
COPY . .
WORKDIR "/src/Lequ.Blog"
RUN dotnet build "Lequ.Blog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lequ.Blog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lequ.Blog.dll"]