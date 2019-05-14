FROM mcr.microsoft.com/dotnet/core/runtime:2.2

COPY ContainerizationSample/bin/Release/netcoreapp2.2/publish/ ContainerizationSample/

ENTRYPOINT ["dotnet", "ContainerizationSample/myapp.dll"]