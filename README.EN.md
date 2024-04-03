# automatic-app
Applications for industrial automation. Enabling communication via Modbus/TCP with PLC controllers.
Project is created for 100commit challenge by https://devmentors.io/ -> https://100commitow.pl/
## Logo
<div align="center">

<img alt="screenshot01" src="./docs/logo.png" width="500" height="157">

</div>
<br/>

## Overview
Assumptions regarding the elements that the project will consist of:
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
Distributed under the MIT License.
