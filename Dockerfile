FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build

WORKDIR /app
COPY *.sln .
COPY Api/*.csproj ./Api/
COPY Domain/*.csproj ./Domain/
COPY Repository/*.csproj ./Repository/
COPY Service/*.csproj ./Service/
RUN dotnet restore

COPY Api/. ./Api/
COPY Domain/. ./Domain/
COPY Repository/. ./Repository/
COPY Service/. ./Service/
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime

WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 5000

RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

ENTRYPOINT ["dotnet", "Api.dll"]