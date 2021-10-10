#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Periphery/Contact.API/Contact.API.csproj", "Periphery/Contact.API/"]
COPY ["Contact/Core/Contact.Application/Contact.Application.csproj", "Contact/Core/Contact.Application/"]
COPY ["Contact/Core/Contact.Domain/Contact.Domain.csproj", "Contact/Core/Contact.Domain/"]
COPY ["Periphery/Contact.Infrastructure/Contact.Infrastructure.csproj", "Periphery/Contact.Infrastructure/"]
RUN dotnet restore "Periphery/Contact.API/Contact.API.csproj"
COPY . .
WORKDIR "/src/Periphery/Contact.API"
RUN dotnet build "Contact.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contact.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contact.API.dll"]
