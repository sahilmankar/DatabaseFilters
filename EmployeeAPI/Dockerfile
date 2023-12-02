FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out  .
ENV ASPNETCORE_URLS=http://+:5069

EXPOSE 5069
ENTRYPOINT [ "dotnet","EmployeeAPI.dll" ]