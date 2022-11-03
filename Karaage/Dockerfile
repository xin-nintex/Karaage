FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Karaage/Karaage.csproj", "Karaage/"]
RUN dotnet restore "Karaage/Karaage.csproj"
COPY . .
WORKDIR "/src/Karaage"
RUN dotnet build "Karaage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Karaage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Karaage.dll"]
