# TabInfo
(*ConnectedFields.TabInfo*)

## Overview

### Available Operations

* [GetConnectedFieldsTabGroups](#getconnectedfieldstabgroups) - Returns all tabs associated with the given account

## GetConnectedFieldsTabGroups

Returns all tabs associated with the given account. 

 **Note**: Unlike the Connected Fields UI, this endpoint returns only fields that are either mandatory or have the **IsRequiredForVerifyingType** <a href="https://concerto.accordproject.org/docs/design/specification/model-decorators/" target="_blank">decorator</a>

### Example Usage

```csharp
using Docusign.IAM;
using Docusign.IAM.Models.Components;

var sdk = new DocusignIamSDK(accessToken: "<YOUR_ACCESS_TOKEN_HERE>");

var res = await sdk.ConnectedFields.TabInfo.GetConnectedFieldsTabGroupsAsync(
    accountId: "<id>",
    appId: "<id>"
);

// handle response
```

### Parameters

| Parameter          | Type               | Required           | Description        |
| ------------------ | ------------------ | ------------------ | ------------------ |
| `AccountId`        | *string*           | :heavy_check_mark: | N/A                |
| `AppId`            | *string*           | :heavy_minus_sign: | N/A                |

### Response

**[ConnectedFieldsApiGetTabGroupsResponse](../../Models/Requests/ConnectedFieldsApiGetTabGroupsResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Docusign.IAM.Models.Errors.APIException | 4XX, 5XX                                | \*/\*                                   |