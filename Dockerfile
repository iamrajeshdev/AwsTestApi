#BUILD Stage
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./Api/TestAPI.csproj" --disable-parallel
RUN dotnet publish "./Api/TestAPI.csproj" -c release -o /app --no-restore


#SERVER STAGE
FROM mcr.microsoft.com/dotnet/aspnet:5.0	
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000 5001 80 443

ENTRYPOINT ["dotnet", "TestAPI.dll"]