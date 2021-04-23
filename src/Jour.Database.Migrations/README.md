# Readme

Managing migrations:

```bash
dotnet ef migrations list --startup-project ../Jour.WebAPI
dotnet ef migrations add 00 --startup-project ../Jour.WebAPI
dotnet ef database update --startup-project ../Jour.WebAPI
```