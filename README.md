# automatic-app
Aplikacji dla automatyki przemysłowej. Umożliwiającej komunikacje poprzez modbus/tcp z sterownikami PLC.
Project is created for 100commit challenge by https://devmentors.io/ -> https://100commitow.pl/
## Logo
<div align="center">

<img alt="screenshot01" src="./docs/logo.png" width="500" height="157">

</div>
<br/>

## Overview
Założenia jeśli chodzi o elementy na którego będzie się składał projekt :
* .NET MAUI
* Onion Architecture
* Entity Framework Core
* ASP.NET Core 8.0 WebApi
* Swagger
* CQRS / Mediator Pattern using MediatR Library
* CRUD Operations

## Features

### Must Have

- [ ] Możliwość dodawania oraz modyfikowania definicji sterownika PLC
- [ ] Pobieranie oraz zapis danych na sterowniki.
- [ ] Zapis histori odczytanych danych
- [ ] Generownie wykresów dla paramtrów sterownika.
- [ ] Instalacja za pomocą docker

### Nice to have


## docker-compose
Building Docker Image
<br>
` docker-compose build `
<br>
Running Docker Container
<br>
` docker-compose up -d `



## License
Dystrybuowane na licencji MIT.
