# Content

Part I
[repo](https://github.com/trevoirwilliams/HR.LeaveManagement.CleanArchitecture-dotnet5/tree/52c0bfbc46e9a39e421eb71799096e3a908cf9d9)

- Automapper
- MediatR
- CQRS
- FluentValidation
- Exceptionhandling & Custom Responses

Part II

## Automapper

- Mediator Pattern is used as messaging mechanism between client and database
- Therefore: We DONT want direct interaction --> No domain object types will be send
- Therefore: we create DTOs
  - Automapper helps with mapping between entity and Dto

### Steps

- Install Package (AutoMapper.Extensions.Microsoft.DependencyInjection)
- Create profiles for mapping
- Service Registration
- CRUD (requests/handlers for queries/commands)

## MediatR & CQRS

Pattern separats commands from queries (separat folder).
Either command/query will be handled by **handlers**.

### Steps

- Install Package (MediatR.Extensions.Microsoft.DependencyInjection)
- Folder per domain type
  - Folderstructure debatable

## FluentValidation

- breaking change:
       - <https://stackoverflow.com/questions/70944146/argument-1cannot-convert-from-netsatis-entities-interfaces-ientity-to-fluentval>
       - <https://docs.fluentvalidation.net/en/latest/upgrading-to-9.html#removal-of-non-generic-validate-overload>

### Steps

- Install package `FluentValidation.DependencyInjectionExtensions`
- Create DtoValidator classes
