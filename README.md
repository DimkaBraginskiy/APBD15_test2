# Laundry Management System

A REST API for managing customers, their purchase history and laundry machines accountancy

##  Table of Contents
- [Tech Stack](#-tech-stack)
- [API Endpoints](#-api-endpoints)
- [Example Output](#-example-output)


## Tech Stack
![ASP.NET](https://img.shields.io/badge/ASP.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![EF Core](https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
##  API Endpoints

### Customers
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/customers/{id}/purchases` | Get purchases of a specified client | 


### Washing Machine
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/api/washing-machines` | Create new washing machine |

##  Example Output
| GET | `/api/customers/{id}/purchases` | Get purchases of a specified client | 
```json
{
  "firstName": "John",
  "lastName": "Doe",
  "phoneNumber": null,
  "purchases": [
  {
    "date": "2025-06-03T09:00:00",
    "rating": 4,
    "price": 33.4,
    "washingMachine": {
    "serial": "WM2012/S431/12",
    "maxWeight": 32.23
  },
    "program": {
      "name": "Quick Wash",
      "duration": 69
      }
  },
  {
    "date": "2025-06-04T09:00:00",
    "rating": null,
    "price": 48.7,
    "washingMachine": {
    "serial": "WM2014/S491/28",
    "maxWeight": 52.23
  },
    "program": {
      "name": "Cotton Cycle",
      "duration": 143
      }
  }
  ]
}
```
| POST | `/api/washing-machines` | Create new washing machine |
```json
{
  "washingMachine": {
    "maxWeight": 9.52,
    "serialNumber": "WM2025/S1431/13"
    },
    "availablePrograms": [
    {
    "programName": "Quick Wash",
    "price": 12.99
    },
    {
    "programName": "Cotton Cycle",
    "price": 17.29
    },
    {
    "programName": "Synthetic",
    "price": 23.99
    }
  ]
}
```



