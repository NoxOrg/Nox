# API Endpoints for the Person entity

This document provides information about the various endpoints available in our API for the Person entity.

## Person Endpoints

### Get Person Count
- **GET** `/api/v1/People/$count`
  - Description: Retrieve the number of People.

### Get Person by ID
- **GET** `/api/v1/People/{key}`
  - Description: Retrieve information about a Person by ID.
  
### Get People
- **GET** `/api/v1/People`
  - Description: Retrieve information about People.

### Create Person
- **POST** `/api/v1/People`
  - Description: Create a new Person.

### Update Person
- **PUT** `/api/v1/People/{key}`
  - Description: Update an existing Person.

### Partially Update Person
- **PATCH** `/api/v1/People/{key}`
  - Description: Partially update an existing Person.
 
### Delete Person
- **DELETE** `/api/v1/People/{key}`
  - Description: Delete an existing Person.

## Owned Relationships Endpoints

### UserContactSelection

#### Get UserContactSelections
- **GET** `/api/v1/People/{key}/UserContactSelections`
  - Description: Retrieve all UserContactSelections for a specific Person.

#### Update UserContactSelection
- **PUT** `/api/v1/People/{key}/UserContactSelections`
  - Description: Update an existing UserContactSelection for a specific Person.
  
#### Partially Update UserContactSelection
- **PATCH** `/api/v1/People/{key}/UserContactSelections`
  - Description: Partially update an existing UserContactSelection for a specific Person.
