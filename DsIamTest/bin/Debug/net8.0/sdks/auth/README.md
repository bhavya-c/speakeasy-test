# Auth
(*Auth*)

## Overview

### Available Operations

* [GetTokenFromConfidentialAuthCode](#gettokenfromconfidentialauthcode) - Obtains an access token from the Docusign API using an authorization code.
* [GetTokenFromPublicAuthCode](#gettokenfrompublicauthcode) - Obtains an access token from the Docusign API using an authorization code.
* [GetTokenFromJwtGrant](#gettokenfromjwtgrant) - Obtains an access token from the Docusign API using a JWT grant.
* [GetTokenFromRefreshToken](#gettokenfromrefreshtoken) - Obtains an access token from the Docusign API using an authorization code.
* [GetUserInfo](#getuserinfo) - Get user information

## GetTokenFromConfidentialAuthCode

Obtains an access token from the Docusign API using the confidential flow.
For the developer environment, the URI is https://account-d.docusign.com/oauth/token
For the production environment, the URI is https://account.docusign.com/oauth/token
You do not need an integration key to obtain an access token.

### Example Usage

```csharp
using Docusign.IAM;
using Docusign.IAM.Models.Components;
using Docusign.IAM.Models.Requests;

var sdk = new DocusignIamSDK();

ConfidentialAuthCodeGrantRequestBody req = new ConfidentialAuthCodeGrantRequestBody() {
    Code = "eyJ0eXAi.....QFsje43QVZ_gw",
};

var res = await sdk.Auth.GetTokenFromConfidentialAuthCodeAsync(
    security: new GetTokenFromConfidentialAuthCodeSecurity() {
        ClientId = "app-speakeasy-123",
        SecretKey = "MTIzNDU2Nzg5MDEyMzQ1Njc4OTAxMjM0NTY3ODkwMTI",
    },
    request: req
);

// handle response
```

### Parameters

| Parameter                                                                                                                                  | Type                                                                                                                                       | Required                                                                                                                                   | Description                                                                                                                                |
| ------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------ |
| `request`                                                                                                                                  | [ConfidentialAuthCodeGrantRequestBody](../../Models/Components/ConfidentialAuthCodeGrantRequestBody.md)                                    | :heavy_check_mark:                                                                                                                         | The request object to use for the request.                                                                                                 |
| `security`                                                                                                                                 | [Docusign.IAM.Models.Requests.GetTokenFromConfidentialAuthCodeSecurity](../../Models/Requests/GetTokenFromConfidentialAuthCodeSecurity.md) | :heavy_check_mark:                                                                                                                         | The security requirements to use for the request.                                                                                          |
| `serverURL`                                                                                                                                | *string*                                                                                                                                   | :heavy_minus_sign:                                                                                                                         | An optional server URL to use.                                                                                                             |

### Response

**[GetTokenFromConfidentialAuthCodeResponse](../../Models/Requests/GetTokenFromConfidentialAuthCodeResponse.md)**

### Errors

| Error Type                                    | Status Code                                   | Content Type                                  |
| --------------------------------------------- | --------------------------------------------- | --------------------------------------------- |
| Docusign.IAM.Models.Errors.OAuthErrorResponse | 400                                           | application/json                              |
| Docusign.IAM.Models.Errors.APIException       | 4XX, 5XX                                      | \*/\*                                         |

## GetTokenFromPublicAuthCode

Obtains an access token from the Docusign API using the confidential flow.
For the developer environment, the URI is https://account-d.docusign.com/oauth/token
For the production environment, the URI is https://account.docusign.com/oauth/token
You do not need an integration key to obtain an access token.

### Example Usage

```csharp
using Docusign.IAM;
using Docusign.IAM.Models.Components;

var sdk = new DocusignIamSDK(accessToken: "<YOUR_ACCESS_TOKEN_HERE>");

PublicAuthCodeGrantRequestBody req = new PublicAuthCodeGrantRequestBody() {
    ClientId = "2da1cb14-xxxx-xxxx-xxxx-5b7b40829e79",
    Code = "eyJ0eXAi.....QFsje43QVZ_gw",
    CodeVerifier = "R8zFoqs0yey29G71QITZs3dK1YsdIvFNBfO4D1bukBw",
};

var res = await sdk.Auth.GetTokenFromPublicAuthCodeAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                   | Type                                                                                        | Required                                                                                    | Description                                                                                 |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `request`                                                                                   | [PublicAuthCodeGrantRequestBody](../../Models/Components/PublicAuthCodeGrantRequestBody.md) | :heavy_check_mark:                                                                          | The request object to use for the request.                                                  |
| `serverURL`                                                                                 | *string*                                                                                    | :heavy_minus_sign:                                                                          | An optional server URL to use.                                                              |

### Response

**[GetTokenFromPublicAuthCodeResponse](../../Models/Requests/GetTokenFromPublicAuthCodeResponse.md)**

### Errors

| Error Type                                    | Status Code                                   | Content Type                                  |
| --------------------------------------------- | --------------------------------------------- | --------------------------------------------- |
| Docusign.IAM.Models.Errors.OAuthErrorResponse | 400                                           | application/json                              |
| Docusign.IAM.Models.Errors.APIException       | 4XX, 5XX                                      | \*/\*                                         |

## GetTokenFromJwtGrant

Obtains an access token from the Docusign API.
                                                                                                                      
For the developer environment, the URI is https://account-d.docusign.com/oauth/token
                                                                                                                      
For the production environment, the URI is https://account.docusign.com/oauth/token
                                                                                                                      
                                                                                                                      
You do not need an integration key to obtain an access token.

### Example Usage

```csharp
using Docusign.IAM;
using Docusign.IAM.Models.Components;
using Docusign.IAM.Models.Requests;

var sdk = new DocusignIamSDK(accessToken: "<YOUR_ACCESS_TOKEN_HERE>");

JWTGrant req = new JWTGrant() {
    Assertion = "YOUR_JSON_WEB_TOKEN",
};

var res = await sdk.Auth.GetTokenFromJwtGrantAsync(req);

// handle response
```

### Parameters

| Parameter                                     | Type                                          | Required                                      | Description                                   |
| --------------------------------------------- | --------------------------------------------- | --------------------------------------------- | --------------------------------------------- |
| `request`                                     | [JWTGrant](../../Models/Requests/JWTGrant.md) | :heavy_check_mark:                            | The request object to use for the request.    |
| `serverURL`                                   | *string*                                      | :heavy_minus_sign:                            | An optional server URL to use.                |

### Response

**[GetTokenFromJWTGrantResponse](../../Models/Requests/GetTokenFromJWTGrantResponse.md)**

### Errors

| Error Type                                    | Status Code                                   | Content Type                                  |
| --------------------------------------------- | --------------------------------------------- | --------------------------------------------- |
| Docusign.IAM.Models.Errors.OAuthErrorResponse | 400                                           | application/json                              |
| Docusign.IAM.Models.Errors.APIException       | 4XX, 5XX                                      | \*/\*                                         |

## GetTokenFromRefreshToken

Obtains an access token from the Docusign API.
For the developer environment, the URI is https://account-d.docusign.com/oauth/token
For the production environment, the URI is https://account.docusign.com/oauth/token

You do not need an integration key to obtain an access token.

### Example Usage

```csharp
using Docusign.IAM;
using Docusign.IAM.Models.Requests;

var sdk = new DocusignIamSDK();

AuthorizationCodeGrant req = new AuthorizationCodeGrant() {
    RefreshToken = "<value>",
    ClientId = "2da1cb14-xxxx-xxxx-xxxx-5b7b40829e79",
};

var res = await sdk.Auth.GetTokenFromRefreshTokenAsync(
    security: new GetTokenFromRefreshTokenSecurity() {
        ClientId = "app-speakeasy-123",
        SecretKey = "MTIzNDU2Nzg5MDEyMzQ1Njc4OTAxMjM0NTY3ODkwMTI",
    },
    request: req
);

// handle response
```

### Parameters

| Parameter                                                                                                                  | Type                                                                                                                       | Required                                                                                                                   | Description                                                                                                                |
| -------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                                  | [AuthorizationCodeGrant](../../Models/Requests/AuthorizationCodeGrant.md)                                                  | :heavy_check_mark:                                                                                                         | The request object to use for the request.                                                                                 |
| `security`                                                                                                                 | [Docusign.IAM.Models.Requests.GetTokenFromRefreshTokenSecurity](../../Models/Requests/GetTokenFromRefreshTokenSecurity.md) | :heavy_check_mark:                                                                                                         | The security requirements to use for the request.                                                                          |
| `serverURL`                                                                                                                | *string*                                                                                                                   | :heavy_minus_sign:                                                                                                         | An optional server URL to use.                                                                                             |

### Response

**[GetTokenFromRefreshTokenResponse](../../Models/Requests/GetTokenFromRefreshTokenResponse.md)**

### Errors

| Error Type                                    | Status Code                                   | Content Type                                  |
| --------------------------------------------- | --------------------------------------------- | --------------------------------------------- |
| Docusign.IAM.Models.Errors.OAuthErrorResponse | 400                                           | application/json                              |
| Docusign.IAM.Models.Errors.APIException       | 4XX, 5XX                                      | \*/\*                                         |

## GetUserInfo

This endpoint retrieves user information from the Docusign API using an access token.
For the developer environment, the URI is https://account-d.docusign.com/oauth/userinfo
For the production environment, the URI is https://account.docusign.com/oauth/userinfo

### Example Usage

```csharp
using Docusign.IAM;
using Docusign.IAM.Models.Components;

var sdk = new DocusignIamSDK(accessToken: "<YOUR_ACCESS_TOKEN_HERE>");

var res = await sdk.Auth.GetUserInfoAsync();

// handle response
```

### Parameters

| Parameter                      | Type                           | Required                       | Description                    |
| ------------------------------ | ------------------------------ | ------------------------------ | ------------------------------ |
| `serverURL`                    | *string*                       | :heavy_minus_sign:             | An optional server URL to use. |

### Response

**[GetUserInfoResponse](../../Models/Requests/GetUserInfoResponse.md)**

### Errors

| Error Type                                    | Status Code                                   | Content Type                                  |
| --------------------------------------------- | --------------------------------------------- | --------------------------------------------- |
| Docusign.IAM.Models.Errors.OAuthErrorResponse | 400                                           | application/json                              |
| Docusign.IAM.Models.Errors.APIException       | 4XX, 5XX                                      | \*/\*                                         |