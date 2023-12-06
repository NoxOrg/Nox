# API Endpoints for the Tenant entity

This document provides information about the various endpoints available in our API for the Tenant entity.

## Tenant Endpoints

### Get Tenant by ID
- **GET** `/api/Tenants/{key}`
  - Description: Retrieve information about a Tenant by ID.
  
### Get Tenants
- **GET** `/api/Tenants`
  - Description: Retrieve information about Tenants.

### Create Tenant
- **POST** `/api/Tenants`
  - Description: Create a new Tenant.

### Update Tenant
- **PUT** `/api/Tenants/{key}`
  - Description: Update an existing Tenant.

### Partially Update Tenant
- **PATCH** `/api/Tenants/{key}`
  - Description: Partially update an existing Tenant.
 
### Delete Tenant
- **DELETE** `/api/Tenants/{key}`
  - Description: Delete an existing Tenant.

## Owned Relationships Endpoints

### TenantBrand

#### Get TenantBrands
- **GET** `/api/Tenants/{key}/TenantBrands`
  - Description: Retrieve all TenantBrands for a specific Tenant.
- **GET** `/api/Tenants/{key}/TenantBrands/{relatedKey}`
  - Description: Retrieve a TenantBrand by ID for a specific Tenant.

#### Create TenantBrand
- **POST** `/api/Tenants/{key}/TenantBrands`
  - Description: Create a new TenantBrand for a specific Tenant.

#### Update TenantBrand
- **PUT** `/api/Tenants/{key}/TenantBrands`
  - Description: Update an existing TenantBrand for a specific Tenant.
  
#### Partially Update TenantBrand
- **PATCH** `/api/Tenants/{key}/TenantBrands`
  - Description: Partially update an existing TenantBrand for a specific Tenant.

#### Delete TenantBrand
- **DELETE** `/api/Tenants/{key}/TenantBrands/{relatedKey}`
  - Description: Delete an existing TenantBrand for a specific Tenant.

### TenantContact

#### Get TenantContacts
- **GET** `/api/Tenants/{key}/TenantContacts`
  - Description: Retrieve all TenantContacts for a specific Tenant.

#### Create TenantContact
- **POST** `/api/Tenants/{key}/TenantContacts`
  - Description: Create a new TenantContact for a specific Tenant.

#### Update TenantContact
- **PUT** `/api/Tenants/{key}/TenantContacts`
  - Description: Update an existing TenantContact for a specific Tenant.
  
#### Partially Update TenantContact
- **PATCH** `/api/Tenants/{key}/TenantContacts`
  - Description: Partially update an existing TenantContact for a specific Tenant.

#### Delete TenantContact
- **DELETE** `/api/Tenants/{key}/TenantContacts/{relatedKey}`
  - Description: Delete an existing TenantContact for a specific Tenant.

## Relationships Endpoints

### Workplace

#### Get Workplace relations
- **GET** `/api/Tenants/{key}/TenantWorkplaces/$ref`
  - Description: Retrieve all existing Workplaces relations for a specific Tenant.
  
#### Create Workplace relation
- **POST** `/api/Tenants/{key}/TenantWorkplaces/{relatedKey}/$ref`
  - Description: Create a new Workplace relation for a specific Tenant.
  
#### Update Workplace relation
- **PUT** `/api/Tenants/{key}/TenantWorkplaces/{relatedKey}/$ref`
  - Description: Updates an existing Workplace relation for a specific Tenant.
- **PUT** `/api/Tenants/{key}/TenantWorkplaces/$ref`
  - Description: Updates the Workplace relations for a specific Tenant.

#### Delete Workplace relation
- **DELETE** `/api/Tenants/{key}/TenantWorkplaces/{relatedKey}/$ref`
  - Description: Delete an existing Workplace relation for a specific Tenant.

#### Delete Workplace relations
- **DELETE** `/api/Tenants/{key}/TenantWorkplaces/$ref`
  - Description: Delete all existing Workplaces relations for a specific Tenant.

## Related Entities

[Workplace](WorkplaceEndpoints.md)
