# Steg 1. Hömta bas avbilden(image)för aspnet 6.0 ...
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

#Steg 2. Ange arbetskatalog...
WORKDIR /app

#Steg 3. Kopiera all köllkod till docker ...
# COPY <src>gläm inte mellanslag<dest>
COPY . ./
RUN dotnet restore

# Steg 4. Skapa en publiceringspaket
# publish skapar ett optimerat publiceringspaket
# -c anger vilken konfiguration vi ska använda
# Release anger att det är ett bygg paket som är optimerat
# -o anger vart vill vi placera detta paket -> out katalogen
RUN dotnet publish -c Release -o out

# Steg 5. Skapa en byggprocess av applikationen ...
# Vi kommer att skapa en aspnet appliktionen
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
# COPY använder sig av build-env inställingar 
# och kopierar filer och paket ifrån katalogen
# /app/out
COPY --from=build-env /app/out .

# Steg 6. Ange hur applikation ska startas upp ...
ENTRYPOINT [ "dotnet", "westcoast-api-mongodb.dll" ]