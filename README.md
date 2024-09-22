# PropChase API

- [PropChase API](#propchase-api)
  - [Introduction](#introduction)
  - [Get Listings](#get-listings)
    - [Create Request](#get-listings-request)
    - [Response](#get-listings-response)
  

## Introduction
PropChase API gives clients access to our aggregated and calculated data sets. Weather a client is looking for 
individual real estate listings and their associated data, or weather they're looking for calculated statistics like the 
average house price in an neighbourhood. Below is the PropChase API documentation showing all possible request types and 
their associated responses.

## Get Listings

### Create Get Listings Request
This GET request is meant to retrieve listings. It takes in two parameters (string id and int numListings) by route. The id parameter identifies from which listing in the database you would like to start and the numListing param identifies how many listings you wish to get in returned. 

To take a single listing for example, one can simply enter in the id of the listing they wish to retive and a numListing value of 1. If you want to retrieve all the listings, you can simply make id equal to "0" and numListings equal to 0. If you simply want a certain amount of listings but dont care about which, simply leave the id at "0" and set the numListings to the desired amount. NOTE: if you ask for more listings then are currently available, you will recieve all listings in the database.

Here is an example of how to get a single random listing using a https call. This can be adapted to any programming language.

```js
GET https://propchaseapi-ghgfaybdaeefdxd4.eastus-01.azurewebsites.net/listings/id/numListings
```

```https
@PropChase_HostAddress = https://propchaseapi-ghgfaybdaeefdxd4.eastus-01.azurewebsites.net
@id = 0
@numListings = 1
@apiKey = ************************

GET {{PropChase_HostAddress}}/listings/{{id}}/{{numListings}}
Content-Type: application/json
Authorization: Bearer {{apiKey}}

{
  "request": null
}
```

### Get Listings Response

```js
200 OK
```

```json
{
  "listings": [
    {
      "id": {
        "timestamp": 1726672393,
        "machine": 10106952,
        "pid": 15625,
        "increment": 4924723,
        "creationTime": "2024-09-18T15:13:13Z"
      },
      "type": "Condo for sale or for rent",
      "site": "Centris",
      "sqft": 611,
      "address": "1265, Rue Lambert-Closse, apt. 207, Montr&#xE9;al (Ville-Marie), Neighbourhood Central West",
      "url": "https://www.centris.ca/en/condos~for-sale~montreal-ville-marie/14086887?view=Summary",
      "numBedrooms": 0,
      "numBathrooms": 0,
      "price": 489000,
      "rawListing": null,
      "numRooms": 5,
      "score": 60,
      "neighbourhood": "Central West"
    }
  ]
}
```
