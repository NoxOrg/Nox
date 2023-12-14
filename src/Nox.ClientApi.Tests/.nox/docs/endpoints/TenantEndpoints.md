# API Endpoints for the Tenant entity

This document provides information about the various endpoints available in our API for the Tenant entity.

## Tenant Endpoints

### Get Tenant by ID
- **GET** `/api/v1/Tenants/{key}`
  - Description: Retrieve information about a Tenant by ID.
  
### Get Tenants
- **GET** `/api/v1/Tenants`
  - Description: Retrieve information about Tenants.

### Create Tenant
- **POST** `/api/v1/Tenants`
  - Description: Create a new Tenant.

### Update Tenant
- **PUT** `/api/v1/Tenants/{key}`
  - Description: Update an existing Tenant.

### Partially Update Tenant
- **PATCH** `/api/v1/Tenants/{key}`
  - Description: Partially update an existing Tenant.
 
### Delete Tenant
- **DELETE** `/api/v1/Tenants/{key}`
  - Description: Delete an existing Tenant.

## Owned Relationships Endpoints

### TenantBrand

#### Get TenantBrands
- **GET** `/api/v1/Tenants/{key}/TenantBrands`
  - Description: Retrieve all TenantBrands for a specific Tenant.
- **GET** `/api/v1/Tenants/{key}/TenantBrands/{relatedKey}`
  - Description: Retrieve a TenantBrand by ID for a specific Tenant.

#### Create TenantBrand
- **POST** `/api/v1/Tenants/{key}/TenantBrands`
  - Description: Create a new TenantBrand for a specific Tenant.

#### Update TenantBrand
- **PUT** `/api/v1/Tenants/{key}/TenantBrands`
  - Description: Update an existing TenantBrand for a specific Tenant.
  
#### Partially Update TenantBrand
- **PATCH** `/api/v1/Tenants/{key}/TenantBrands`
  - Description: Partially update an existing TenantBrand for a specific Tenant.

#### Delete TenantBrand
- **DELETE** `/api/v1/Tenants/{key}/TenantBrands/{relatedKey}`
  - Description: Delete an existing TenantBrand for a specific Tenant.

### TenantContact

#### Get TenantContacts
- **GET** `/api/v1/Tenants/{key}/TenantContacts`
  - Description: Retrieve all TenantContacts for a specific Tenant.

#### Create TenantContact
- **POST** `/api/v1/Tenants/{key}/TenantContacts`
  - Description: Create a new TenantContact for a specific Tenant.

#### Update TenantContact
- **PUT** `/api/v1/Tenants/{key}/TenantContacts`
  - Description: Update an existing TenantContact for a specific Tenant.
  
#### Partially Update TenantContact
- **PATCH** `/api/v1/Tenants/{key}/TenantContacts`
  - Description: Partially update an existing TenantContact for a specific Tenant.

#### Delete TenantContact
- **DELETE** `/api/v1/Tenants/{key}/TenantContacts/{relatedKey}`
  - Description: Delete an existing TenantContact for a specific Tenant.

## Relationships Endpoints

### Workplace

#### Get Workplace relations
- **GET** `/api/v1/Tenants/{key}/TenantWorkplaces/$ref`
  - Description: Retrieve all existing Workplaces relations for a specific Tenant.
  
#### Create Workplace relation
- **POST** `/api/v1/Tenants/{key}/TenantWorkplaces/{relatedKey}/$ref`
  - Description: Create a new Workplace relation for a specific Tenant.
  
#### Update Workplace relation
- **PUT** `/api/v1/Tenants/{key}/TenantWorkplaces/{relatedKey}/$ref`
  - Description: Updates an existing Workplace relation for a specific Tenant.
- **PUT** `/api/v1/Tenants/{key}/TenantWorkplaces/$ref`
  - Description: Updates the Workplace relations for a specific Tenant.

#### Delete Workplace relation
- **DELETE** `/api/v1/Tenants/{key}/TenantWorkplaces/{relatedKey}/$ref`
  - Description: Delete an existing Workplace relation for a specific Tenant.

#### Delete Workplace relations
- **DELETE** `/api/v1/Tenants/{key}/TenantWorkplaces/$ref`
  - Description: Delete all existing Workplaces relations for a specific Tenant.

## Related Entities

[Workplace](WorkplaceEndpoints.md)

## Enumerations Endpoints

This section details the API endpoints related to enumeration attributes in a specific Tenant.
- **GET** `/api/v1/Tenants/TenantStatuses`
  - **Description**: Retrieve non-conventional values of Statuses for a specific Tenant.
