FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS base
WORKDIR /app

COPY ThirdPersonDemoIMGs.sln .

COPY ThirdPersonDemoIMGs/ThirdPersonDemoIMGs.csproj ./ThirdPersonDemoIMGs/

COPY ThirdPersonDemoIMGsDomain/ThirdPersonDemoIMGsDomain.csproj ./ThirdPersonDemoIMGsDomain/

COPY ThirdPersonDemoIMGsInfrasturcture/ThirdPersonDemoIMGsInfrasturcture.csproj ./ThirdPersonDemoIMGsInfrasturcture/

RUN dotnet restore

COPY . ./

RUN dotnet publish ThirdPersonDemoIMGs.sln -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=base /app .
EXPOSE 4220
ENTRYPOINT ["dotnet", "ThirdPersonDemoIMGs.dll"]
