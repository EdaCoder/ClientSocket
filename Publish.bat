cd %~dp0

dotnet publish ClientSocket\ClientSocket.csproj -c Release -o ..\ClientSocket\Release -f net8.0-windows --sc true -r win-x64 /p:DebugType=None /p:DebugSymbols=false

rd /S /Q ClientSocket\obj ClientSocket\bin\Release

pause