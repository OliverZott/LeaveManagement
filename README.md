
# Content

- Automapper
- MediatR
- CQRS

## Automapper
- Mediator Pattern is used as messaging mechanism between client and database
- Therefore: We DONT want direct interaction --> No domain object types will be send
- Therefore: we create DTOs
	- Automapper helps with mapping between entity and Dto

### Steps:

- Install Package (DI)
- Create profiles for mapping
- Service Registration


## MediatR

## CQRS

Pattern separats commands from queries (separat folder).
Either command/query will be handled by **handlers**.

### Steps
- Install Package (DI)
- Folder per domain type
	- Folderstructure debatable
