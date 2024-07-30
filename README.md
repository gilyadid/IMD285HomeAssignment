# IMD285HomeAssignment

## Simple "ERD" for DB tables and relationships

Category -1----M- Product -1----M- OrderItem -M----1- Order

## General Architecture

Docker technology will be used to containerize the parts.

1. Container for SQL Server Express which will host the DB.

2. Container for Backend Asp.Net Core Server
   (It should be able to connect to the DB in section 1)

3. Container for Frontend React (Just a server to serve the client app)
   (It should be able to connect to the backend servers from section 2 and section 4)

4. Conatiner for Backend Node (or NestJs)
   (It should be able to connect to the elastic search from section 5)

5. Container with Elastic Search.

## Setup Instructions

### Prerequisites

Please Note:
While the architecture requirements for cloud deployment present and were accounted for,
I was not asked to actually buy a cloud account and deploy it there..
So, to see it work you will have to run it locally, on-premises.
As said deployment to cloud is certainly possible with a bit of configuration
for communications between the programs as everything is working with dockers here.

So, the following technologies need to be installed on your machine:

1. Make sure you have visual studio 2022 professional installed.
   Please note that "visual studio code" is irrelevant for this setup.

2. Make sure you have SQL Server Express installed.
   Please note you will need Microsoft SQL Server Management Studio as well.

3. Make sure you have Docker Desktop installed.

### Get the DB working step

The Db could run on a docker, but every cloud has a 

docker pull mcr.microsoft.com/mssql/server:2019-latest

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrong!Passw0rd' -p 1434:1433 --name Imd285SqlDbDocker -d mcr.microsoft.com/mssql/server:2019-latest

