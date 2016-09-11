salesforceiq-api
============

.NET wrapper for Salesforce IQ Api

This project is under active development. If you wish to contribute, please follow the existing coding conventions and submit a pull request.

### Running unit tests
Add a `Secrets.config` file to the `SalesforceIQApi.Test` project.

```xml
<appSettings>
  <add key="ApiKey" value="<your_api_key>"/>
  <add key="ApiSecret" value="<your_api_secret>"/>
  <add key="KnownListId" value="<a known list id>"/>
  <add key="KnownListItemId" value="<a known list item id that belongs to the above list>"/>
  <add key="KnownAccountId" value="<a known account id>"/>
  <add key="KnownContactId" value="<a known contact id>"/>
  <add key="KnownContactEmail" value="<email for known contact above>"/>
  <add key="KnownUserId" value="<a known user id>"/>
</appSettings>
```