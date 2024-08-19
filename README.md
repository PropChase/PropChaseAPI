# PropChase API

- [PropChase API](#propchase-api)
  - [Get Listings](#create-listings)
    - [Create Request](#create-get-listings-request)
    - [Response](#create-get-listings-response)
  

## Get Listings

### Create Get Listings Request
This GET request is meant to retrieve listings. It takes in two parameters (string id and int numListings) by route. The id parameter identifies from which listing in the database you would like to start and the numListing param identifies how many listings you wish to get in returned. To take a single listing for example, one can simply enter in the id of the listing they wish to retive and a numListing value of 1. If you want to retrieve all the listings, you can simply make id equal to "0" and numListings equal to 0. If you simply want a certain amount of listings but dont care about which, simply leave the id at "0" and set the numListings to the desired amount. NOTE: if you ask for more listings then are currently available, you will recieve all listings in the database.

```js
GET https://propchaseapi-ghgfaybdaeefdxd4.eastus-01.azurewebsites.net/listings/id/numListings
```

```json
{
  "request": null
}
```

### Create Get Listings Response

```js
200 OK
```

```json
{
  "listings": [
    {
      "id": "00000002-0000-0000-0000-000000000000",
      "type": "Condo",
      "site": "Realtor.ca",
      "sqft": 12000,
      "address": "62701",
      "url": "3",
      "numBedrooms": 2,
      "numBathrooms": 1500,
      "price": 200000,
      "rawListing": "<div></div>"
    }
  ]
}
```
