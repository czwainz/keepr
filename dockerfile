FROM microsoft/dotnet:2.2.101-sdk

WORKDIR /app

COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet keepr.dll
